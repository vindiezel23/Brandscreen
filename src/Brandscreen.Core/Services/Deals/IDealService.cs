using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Brandscreen.Core.Services.Campaigns;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Brandscreen.Framework.Services;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services.Deals
{
    public interface IDealService : IDependency
    {
        Task<Deal> GetDeal(Guid id);
        IQueryable<Deal> GetDeals();
        IQueryable<Deal> GetDeals(DealQueryOptions options);

        Task<Deal> CreateDeal(Deal deal);
        Task UpdateDeal(Deal deal);
        Task DeleteDeal(Guid id);
    }

    public class DealService : IDealService
    {
        private readonly IRepositoryAsync<Deal> _dealRepositoryAsync;
        private readonly IBrandscreenContext _brandscreenContext;
        private readonly IClock _clock;

        private static readonly Expression<Func<Deal, bool>> PredicateNotDelete =
            x => x.DealStatusId != (int) CampaignStatusEnum.Deleted;

        public DealService(IRepositoryAsync<Deal> dealRepositoryAsync, IBrandscreenContext brandscreenContext, IClock clock)
        {
            _dealRepositoryAsync = dealRepositoryAsync;
            _brandscreenContext = brandscreenContext;
            _clock = clock;
        }

        public Task<Deal> GetDeal(Guid id)
        {
            return _dealRepositoryAsync.Queryable()
                .Include(x => x.BuyerAccount)
                .Include(x => x.Publisher)
                .Include(x => x.Currency)
                .Where(PredicateNotDelete)
                .FirstOrDefaultAsync(x => x.DealUuid == id);
        }

        public IQueryable<Deal> GetDeals()
        {
            var source = _dealRepositoryAsync.Queryable()
                .Where(PredicateNotDelete)
                .OrderBy(x => x.DealName);
            return source;
        }

        public IQueryable<Deal> GetDeals(DealQueryOptions options)
        {
            var source = GetDeals();

            if (options.BuyerAccountIds.Count > 0)
            {
                source = source.Where(x => options.BuyerAccountIds.Contains(x.BuyerAccountId));
            }

            if (!string.IsNullOrEmpty(options.Text))
            {
                source = source.Where(x => x.DealName.Contains(options.Text));
            }

            return source;
        }

        public async Task<Deal> CreateDeal(Deal deal)
        {
            var tmpDeal = await _dealRepositoryAsync.Queryable().FirstOrDefaultAsync(x => x.BuyerAccountId == deal.BuyerAccountId && x.PublisherId == deal.PublisherId && x.DealKey == deal.DealKey);
            if (tmpDeal != null)
            {
                if (tmpDeal.DealStatusId != (int) CampaignStatusEnum.Deleted)
                {
                    throw new BrandscreenException("Found duplicated deal key under the same buyer account and publisher.");
                }

                // recover from deleted deal
                tmpDeal.ObjectState = ObjectState.Modified;
                tmpDeal.DealName = deal.DealName;
                tmpDeal.DealTypeId = deal.DealTypeId;
                tmpDeal.FloorPriceCents = deal.FloorPriceCents;
                tmpDeal.CeilingPriceCents = deal.CeilingPriceCents;
                tmpDeal.UtcStartDateTime = deal.UtcStartDateTime;
                tmpDeal.UtcEndDateTime = deal.UtcEndDateTime;
                tmpDeal.CurrencyId = deal.CurrencyId;
                deal = tmpDeal;
            }
            else
            {
                deal.ObjectState = ObjectState.Added;
                deal.DealUuid = IdentityValue.GenerateNewId();
            }

            deal.DealStatusId = (int) CampaignStatusEnum.Live;
            deal.UtcCreatedDateTime = _clock.UtcNow;
            deal.UtcModifiedDateTime = null;

            // save
            _dealRepositoryAsync.InsertOrUpdateGraph(deal);
            await _brandscreenContext.SaveChangesAsync();

            return deal;
        }

        public Task UpdateDeal(Deal deal)
        {
            deal.UtcModifiedDateTime = _clock.UtcNow;
            _dealRepositoryAsync.Update(deal);
            return _brandscreenContext.SaveChangesAsync();
        }

        public async Task DeleteDeal(Guid id)
        {
            var deal = await GetDeal(id);
            deal.DealStatusId = (int) CampaignStatusEnum.Deleted;
            await UpdateDeal(deal);
        }
    }
}
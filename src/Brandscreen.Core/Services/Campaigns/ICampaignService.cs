using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Brandscreen.Framework.Services;
using LinqKit;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services.Campaigns
{
    public interface ICampaignService : IDependency
    {
        Task<Campaign> GetCampaign(Guid id);
        IQueryable<Campaign> GetCampaigns();
        IQueryable<Campaign> GetCampaigns(CampaignQueryOptions options);

        Task CreateCampaign(Campaign campaign);
        Task UpdateCampaign(Campaign campaign);
        Task DeleteCampaign(Guid id);
    }

    public class CampaignService : ICampaignService
    {
        private readonly IBrandscreenContext _brandscreenContext;
        private readonly IClock _clock;
        private readonly IRepositoryAsync<Campaign> _compaignAsyncRepository;

        private static readonly Expression<Func<Campaign, bool>> PredicateNotDelete =
            x => !x.IsDeleted && !x.AdvertiserProduct.IsDeleted && !x.AdvertiserProduct.Advertiser.IsDeleted && !x.BuyerAccount.IsDeleted;

        public CampaignService(IBrandscreenContext brandscreenContext, IRepositoryAsync<Campaign> compaignAsyncRepository, IClock clock)
        {
            _brandscreenContext = brandscreenContext;
            _compaignAsyncRepository = compaignAsyncRepository;
            _clock = clock;
        }

        public Task<Campaign> GetCampaign(Guid id)
        {
            return _compaignAsyncRepository.Queryable()
                .Include(x => x.BuyerAccount)
                .Include(x => x.AdvertiserProduct)
                .Where(PredicateNotDelete)
                .FirstOrDefaultAsync(x => x.CampaignUuid == id);
        }

        public IQueryable<Campaign> GetCampaigns()
        {
            var source = _compaignAsyncRepository.Queryable()
                .Where(PredicateNotDelete)
                .OrderBy(x => x.CampaignName);
            return source;
        }

        public IQueryable<Campaign> GetCampaigns(CampaignQueryOptions options)
        {
            var source = GetCampaigns();

            if (options.BuyerAccountIds.Count > 0 || options.UserIds.Count > 0)
            {
                var predicate = PredicateBuilder.False<Campaign>();
                if (options.BuyerAccountIds.Count > 0)
                {
                    // filter by BuyerAccountId when user is AgencyAdministrator
                    predicate = predicate.Or(x => options.BuyerAccountIds.Contains(x.BuyerAccountId));
                }
                if (options.UserIds.Count > 0)
                {
                    // filter by UserAdvertiserRoles when user is AgencyUser
                    predicate = predicate.Or(x => x.AdvertiserProduct.Advertiser.UserAdvertiserRoles.Any(r => options.UserIds.Contains(r.UserId)));
                }
                source = source.AsExpandable().Where(predicate);
            }

            if (options.AdvertiserUuid.HasValue)
            {
                source = source.Where(x => x.AdvertiserProduct.Advertiser.AdvertiserUuid == options.AdvertiserUuid.Value);
            }

            if (options.BrandUuid.HasValue)
            {
                source = source.Where(x => x.AdvertiserProduct.AdvertiserProductUuid == options.BrandUuid.Value);
            }

            if (!string.IsNullOrEmpty(options.Text))
            {
                source = source.Where(x => x.CampaignName.Contains(options.Text));
            }

            return source;
        }

        public Task CreateCampaign(Campaign campaign)
        {
            campaign.CampaignUuid = IdentityValue.GenerateNewId();
            campaign.UtcCreatedDateTime = _clock.UtcNow;
            _compaignAsyncRepository.Insert(campaign);
            return _brandscreenContext.SaveChangesAsync();
        }

        public Task UpdateCampaign(Campaign campaign)
        {
            campaign.UtcModifiedDateTime = _clock.UtcNow;
            _compaignAsyncRepository.Update(campaign);
            return _brandscreenContext.SaveChangesAsync();
        }

        public async Task DeleteCampaign(Guid id)
        {
            var campaign = await GetCampaign(id);
            campaign.IsDeleted = true;
            await UpdateCampaign(campaign);
        }
    }
}
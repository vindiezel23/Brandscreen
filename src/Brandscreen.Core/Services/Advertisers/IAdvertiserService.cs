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

namespace Brandscreen.Core.Services.Advertisers
{
    public interface IAdvertiserService : IDependency
    {
        Task<Advertiser> GetAdvertiser(Guid id);
        IQueryable<Advertiser> GetAdvertisers();
        IQueryable<Advertiser> GetAdvertisers(AdvertiserQueryOptions options);

        Task CreateAdvertiser(Advertiser advertiser);
        Task UpdateAdvertiser(Advertiser advertiser);
        Task DeleteAdvertiser(Guid id);
    }

    public class AdvertiserService : IAdvertiserService
    {
        private readonly IBrandscreenContext _brandscreenContext;
        private readonly IRepositoryAsync<Advertiser> _advertiserRepositoryAsync;
        private readonly IClock _clock;

        private static readonly Expression<Func<Advertiser, bool>> PredicateNotDelete =
            x => !x.IsDeleted && !x.BuyerAccount.IsDeleted;

        public AdvertiserService(IBrandscreenContext brandscreenContext, IRepositoryAsync<Advertiser> advertiserRepositoryAsync, IClock clock)
        {
            _brandscreenContext = brandscreenContext;
            _advertiserRepositoryAsync = advertiserRepositoryAsync;
            _clock = clock;
        }

        public Task<Advertiser> GetAdvertiser(Guid id)
        {
            return _advertiserRepositoryAsync.Queryable().Where(PredicateNotDelete).FirstOrDefaultAsync(x => x.AdvertiserUuid == id);
        }

        public IQueryable<Advertiser> GetAdvertisers()
        {
            var source = _advertiserRepositoryAsync.Queryable()
                .Where(PredicateNotDelete);
            return source.OrderBy(x => x.AdvertiserName);
        }

        public IQueryable<Advertiser> GetAdvertisers(AdvertiserQueryOptions options)
        {
            var source = GetAdvertisers();

            if (options.BuyerAccountIds.Count > 0 || options.UserIds.Count > 0)
            {
                var predicate = PredicateBuilder.False<Advertiser>();
                if (options.BuyerAccountIds.Count > 0)
                {
                    // filter by BuyerAccountId when user is AgencyAdministrator
                    predicate = predicate.Or(x => options.BuyerAccountIds.Contains(x.BuyerAccountId));
                }
                if (options.UserIds.Count > 0)
                {
                    // filter by UserAdvertiserRoles when user is AgencyUser
                    predicate = predicate.Or(x => x.UserAdvertiserRoles.Any(r => options.UserIds.Contains(r.UserId)));
                }
                source = source.AsExpandable().Where(predicate);
            }

            if (!string.IsNullOrEmpty(options.Text))
            {
                source = source.Where(x => x.AdvertiserName.Contains(options.Text));
            }

            return source;
        }

        public Task CreateAdvertiser(Advertiser advertiser)
        {
            advertiser.AdvertiserUuid = IdentityValue.GenerateNewId();
            advertiser.UtcCreatedDateTime = _clock.UtcNow;
            _advertiserRepositoryAsync.Insert(advertiser);
            return _brandscreenContext.SaveChangesAsync();
        }

        public Task UpdateAdvertiser(Advertiser advertiser)
        {
            advertiser.UtcModifiedDateTime = _clock.UtcNow;
            _advertiserRepositoryAsync.Update(advertiser);
            return _brandscreenContext.SaveChangesAsync();
        }

        public async Task DeleteAdvertiser(Guid id)
        {
            var advertiser = await GetAdvertiser(id);
            advertiser.IsDeleted = true;
            await UpdateAdvertiser(advertiser);
        }
    }
}
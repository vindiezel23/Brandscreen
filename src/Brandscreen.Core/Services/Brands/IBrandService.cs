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

namespace Brandscreen.Core.Services.Brands
{
    public interface IBrandService : IDependency
    {
        Task<AdvertiserProduct> GetBrand(Guid id);
        IQueryable<AdvertiserProduct> GetBrands();
        IQueryable<AdvertiserProduct> GetBrands(BrandQueryOptions options);

        Task CreateBrand(AdvertiserProduct brand);
        Task UpdateBrand(AdvertiserProduct brand);
        Task DeleteBrand(Guid id);
    }

    public class BrandService : IBrandService
    {
        private readonly IRepositoryAsync<AdvertiserProduct> _advertiserProductRepositoryAsync;
        private readonly IBrandscreenContext _brandscreenContext;
        private readonly IClock _clock;

        private static readonly Expression<Func<AdvertiserProduct, bool>> PredicateNotDelete =
            x => !x.IsDeleted && !x.Advertiser.IsDeleted && !x.BuyerAccount.IsDeleted;

        public BrandService(IBrandscreenContext brandscreenContext, IRepositoryAsync<AdvertiserProduct> advertiserProductRepositoryAsync, IClock clock)
        {
            _brandscreenContext = brandscreenContext;
            _advertiserProductRepositoryAsync = advertiserProductRepositoryAsync;
            _clock = clock;
        }

        public Task<AdvertiserProduct> GetBrand(Guid id)
        {
            return _advertiserProductRepositoryAsync.Queryable()
                .Include(x => x.BuyerAccount)
                .Include(x => x.Advertiser)
                .Include(x => x.ProductCategory)
                .Where(PredicateNotDelete)
                .FirstOrDefaultAsync(x => x.AdvertiserProductUuid == id);
        }

        public IQueryable<AdvertiserProduct> GetBrands()
        {
            var source = _advertiserProductRepositoryAsync.Queryable()
                .Where(PredicateNotDelete)
                .OrderBy(x => x.ProductName);
            return source;
        }

        public IQueryable<AdvertiserProduct> GetBrands(BrandQueryOptions options)
        {
            var source = GetBrands();

            if (options.BuyerAccountIds.Count > 0 || options.UserIds.Count > 0)
            {
                var predicate = PredicateBuilder.False<AdvertiserProduct>();
                if (options.BuyerAccountIds.Count > 0)
                {
                    // filter by BuyerAccountId when user is AgencyAdministrator
                    predicate = predicate.Or(x => options.BuyerAccountIds.Contains(x.BuyerAccountId));
                }
                if (options.UserIds.Count > 0)
                {
                    // filter by UserAdvertiserRoles when user is AgencyUser
                    predicate = predicate.Or(x => x.Advertiser.UserAdvertiserRoles.Any(r => options.UserIds.Contains(r.UserId)));
                }
                source = source.AsExpandable().Where(predicate);
            }

            if (options.AdvertiserUuid.HasValue)
            {
                source = source.Where(x => x.Advertiser.AdvertiserUuid == options.AdvertiserUuid.Value);
            }

            if (!string.IsNullOrEmpty(options.Text))
            {
                source = source.Where(x => x.ProductName.Contains(options.Text));
            }

            return source;
        }

        public Task CreateBrand(AdvertiserProduct brand)
        {
            brand.AdvertiserProductUuid = IdentityValue.GenerateNewId();
            brand.UtcCreatedDateTime = _clock.UtcNow;
            _advertiserProductRepositoryAsync.Insert(brand);
            return _brandscreenContext.SaveChangesAsync();
        }

        public Task UpdateBrand(AdvertiserProduct brand)
        {
            brand.UtcModifiedDateTime = _clock.UtcNow;
            _advertiserProductRepositoryAsync.Update(brand);
            return _brandscreenContext.SaveChangesAsync();
        }

        public async Task DeleteBrand(Guid id)
        {
            var brand = await GetBrand(id);
            brand.IsDeleted = true;
            await UpdateBrand(brand);
        }
    }
}
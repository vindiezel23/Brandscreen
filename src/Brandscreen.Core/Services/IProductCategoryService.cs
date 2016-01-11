using System.Linq;
using System.Threading.Tasks;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Brandscreen.Framework.Caching;
using Brandscreen.Framework.Services;
using Repository.Pattern.Repositories;
using TimeSpan = System.TimeSpan;

namespace Brandscreen.Core.Services
{
    public interface IProductCategoryService : IDependency
    {
        IQueryable<ProductCategory> GetProductCategorys();
        Task<ProductCategory> GetProductCategory(int id);
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepositoryAsync<ProductCategory> _productCategoryRepositoryAsync;
        private readonly ICacheManager _cacheManager;
        private readonly IClock _clock;

        public ProductCategoryService(IRepositoryAsync<ProductCategory> productCategoryRepositoryAsync, ICacheManager cacheManager, IClock clock)
        {
            _productCategoryRepositoryAsync = productCategoryRepositoryAsync;
            _cacheManager = cacheManager;
            _clock = clock;
        }

        public IQueryable<ProductCategory> GetProductCategorys()
        {
            var retVal = _cacheManager.Get(GetType(), context =>
            {
                context.Monitor(_clock.When(TimeSpan.FromMinutes(10))); // cache for 10 mins
                return _productCategoryRepositoryAsync.Queryable().Where(x => x.IsActive).OrderBy(x => x.ProductCategoryName).ToList();
            });
            return retVal.AsQueryable();
        }

        public Task<ProductCategory> GetProductCategory(int id)
        {
            return Task.FromResult(GetProductCategorys().FirstOrDefault(x => x.ProductCategoryId == id));
        }
    }
}
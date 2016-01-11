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
    public interface IIndustryCategoryService : IDependency
    {
        IQueryable<IndustryCategory> GetIndustryCategories();
        Task<IndustryCategory> GetIndustryCategory(int id);
    }

    public class IndustryCategoryService : IIndustryCategoryService
    {
        private readonly IRepositoryAsync<IndustryCategory> _industryCategoryRepositoryAsync;
        private readonly ICacheManager _cacheManager;
        private readonly IClock _clock;

        public IndustryCategoryService(IRepositoryAsync<IndustryCategory> industryCategoryRepositoryAsync, ICacheManager cacheManager, IClock clock)
        {
            _industryCategoryRepositoryAsync = industryCategoryRepositoryAsync;
            _cacheManager = cacheManager;
            _clock = clock;
        }

        public IQueryable<IndustryCategory> GetIndustryCategories()
        {
            var retVal = _cacheManager.Get(GetType(), context =>
            {
                context.Monitor(_clock.When(TimeSpan.FromMinutes(10))); // cache for 10 mins
                return _industryCategoryRepositoryAsync.Queryable().Where(x => x.IsActive).OrderBy(x => x.IndustryCategoryName).ToList();
            });
            return retVal.AsQueryable();
        }

        public Task<IndustryCategory> GetIndustryCategory(int id)
        {
            return Task.FromResult(GetIndustryCategories().FirstOrDefault(x => x.IndustryCategoryId == id));
        }
    }
}
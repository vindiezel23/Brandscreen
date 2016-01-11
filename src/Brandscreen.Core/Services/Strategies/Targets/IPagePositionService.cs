using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Brandscreen.Framework.Caching;
using Brandscreen.Framework.Services;
using Repository.Pattern.Repositories;
using TimeSpan = System.TimeSpan;

namespace Brandscreen.Core.Services.Strategies.Targets
{
    public interface IPagePositionService : IDependency
    {
        IQueryable<PagePosition> GetPagePositions();
        Task<PagePosition> GetPagePosition(int id);
    }

    public class PagePositionService : IPagePositionService
    {
        private readonly IRepositoryAsync<PagePosition> _pagePositionRepositoryAsync;
        private readonly ICacheManager _cacheManager;
        private readonly IClock _clock;

        public PagePositionService(IRepositoryAsync<PagePosition> pagePositionRepositoryAsync, ICacheManager cacheManager, IClock clock)
        {
            _pagePositionRepositoryAsync = pagePositionRepositoryAsync;
            _cacheManager = cacheManager;
            _clock = clock;
        }

        public IQueryable<PagePosition> GetPagePositions()
        {
            var retVal = _cacheManager.Get(GetType(), context =>
            {
                context.Monitor(_clock.When(TimeSpan.FromMinutes(10))); // cache for 10 mins
                var source = _pagePositionRepositoryAsync.Queryable();
                return source.OrderBy(x => x.PagePositionName).ToList();
            });
            return retVal.ToAsyncEnumerable();
        }

        public Task<PagePosition> GetPagePosition(int id)
        {
            return GetPagePositions().FirstOrDefaultAsync(x => x.PagePositionId == id);
        }
    }
}
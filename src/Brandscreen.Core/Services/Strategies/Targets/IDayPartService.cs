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
    public interface IDayPartService : IDependency
    {
        IQueryable<DayPart> GetDayParts();
        Task<DayPart> GetDayPart(int id);
    }

    public class DayPartService : IDayPartService
    {
        private readonly IRepositoryAsync<DayPart> _dayPartRepositoryAsync;
        private readonly ICacheManager _cacheManager;
        private readonly IClock _clock;

        public DayPartService(IRepositoryAsync<DayPart> dayPartRepositoryAsync, ICacheManager cacheManager, IClock clock)
        {
            _dayPartRepositoryAsync = dayPartRepositoryAsync;
            _cacheManager = cacheManager;
            _clock = clock;
        }

        public IQueryable<DayPart> GetDayParts()
        {
            var retVal = _cacheManager.Get(GetType(), context =>
            {
                context.Monitor(_clock.When(TimeSpan.FromMinutes(10))); // cache for 10 mins
                var source = _dayPartRepositoryAsync.Queryable();
                return source.Where(x => x.IsEnabled).OrderBy(x => x.DayPartId).ToList();
            });
            return retVal.ToAsyncEnumerable();
        }

        public Task<DayPart> GetDayPart(int id)
        {
            return GetDayParts().FirstOrDefaultAsync(x => x.DayPartId == id);
        }
    }
}
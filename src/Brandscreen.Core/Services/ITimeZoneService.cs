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

namespace Brandscreen.Core.Services
{
    public interface ITimeZoneService : IDependency
    {
        IQueryable<TimeZone> GeTimeZones();
        Task<TimeZone> GetTimeZone(int id);
        Task<TimeZone> GetTimeZone(string code);
    }

    public class TimeZoneService : ITimeZoneService
    {
        private readonly IRepositoryAsync<TimeZone> _timeZoneRepositoryAsync;
        private readonly ICacheManager _cacheManager;
        private readonly IClock _clock;

        public TimeZoneService(IRepositoryAsync<TimeZone> timeZoneRepositoryAsync, ICacheManager cacheManager, IClock clock)
        {
            _timeZoneRepositoryAsync = timeZoneRepositoryAsync;
            _cacheManager = cacheManager;
            _clock = clock;
        }

        public IQueryable<TimeZone> GeTimeZones()
        {
            var retVal = _cacheManager.Get(GetType(), context =>
            {
                context.Monitor(_clock.When(TimeSpan.FromMinutes(10))); // cache for 10 mins
                return _timeZoneRepositoryAsync.Queryable().OrderBy(x => x.DisplayIndex).ToList();
            });
            return retVal.ToAsyncEnumerable();
        }

        public Task<TimeZone> GetTimeZone(int id)
        {
            return GeTimeZones().FirstOrDefaultAsync(x => x.TimeZoneId == id);
        }

        public Task<TimeZone> GetTimeZone(string code)
        {
            return GeTimeZones().FirstOrDefaultAsync(x => x.TimeZoneCode.Contains(code));
        }
    }

    public static class TimeZoneServiceExtensions
    {
        public static Task<TimeZone> GetDefaultTimeZone(this ITimeZoneService timeZoneService)
        {
            return timeZoneService.GetTimeZone("AUS Eastern Standard Time");
        }

        public static async Task<TimeZone> GetTimeZoneOrDefault(this ITimeZoneService timeZoneService, string code)
        {
            if (string.IsNullOrEmpty(code)) return await timeZoneService.GetDefaultTimeZone();
            return await timeZoneService.GetTimeZone(code) ?? await timeZoneService.GetDefaultTimeZone();
        }
    }
}
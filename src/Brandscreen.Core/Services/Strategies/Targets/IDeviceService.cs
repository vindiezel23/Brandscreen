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
    public interface IDeviceService : IDependency
    {
        IQueryable<Device> GetDevices();
        Task<Device> GetDevice(int id);
    }

    public class DeviceService : IDeviceService
    {
        private readonly IRepositoryAsync<Device> _deviceRepositoryAsync;
        private readonly ICacheManager _cacheManager;
        private readonly IClock _clock;

        public DeviceService(IRepositoryAsync<Device> deviceRepositoryAsync, ICacheManager cacheManager, IClock clock)
        {
            _deviceRepositoryAsync = deviceRepositoryAsync;
            _cacheManager = cacheManager;
            _clock = clock;
        }

        public IQueryable<Device> GetDevices()
        {
            var retVal = _cacheManager.Get(GetType(), context =>
            {
                context.Monitor(_clock.When(TimeSpan.FromMinutes(10))); // cache for 10 mins
                var source = _deviceRepositoryAsync.Queryable();
                return source.OrderBy(x => x.DeviceName).ToList();
            });
            return retVal.ToAsyncEnumerable();
        }

        public Task<Device> GetDevice(int id)
        {
            return GetDevices().FirstOrDefaultAsync(x => x.DeviceId == id);
        }
    }
}
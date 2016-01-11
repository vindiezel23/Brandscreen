using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Brandscreen.Framework.Caching;
using Brandscreen.Framework.Services;
using Repository.Pattern.Repositories;
using TimeSpan = System.TimeSpan;

namespace Brandscreen.Core.Services.Creatives
{
    public interface ICreativeSizeService : IDependency
    {
        IQueryable<CreativeSize> GetCreativeSizes();
        IQueryable<CreativeSize> GetCreativeSizes(CreativeSizeQueryOptions options);
        Task<CreativeSize> GetCreativeSize(int id);
        Task<CreativeSize> GetCreativeSize(CreativeSizeQueryOptions options);

        Task CreateCreativeSize(CreativeSize creativeSize);
        Task UpdateCreativeSize(CreativeSize creativeSize);
    }

    public class CreativeSizeService : ICreativeSizeService
    {
        private readonly IRepositoryAsync<CreativeSize> _creativeSizeRepositoryAsync;
        private readonly IBrandscreenContext _brandscreenContext;
        private readonly ICacheManager _cacheManager;
        private readonly IClock _clock;
        private readonly ISignals _signals;

        public CreativeSizeService(IRepositoryAsync<CreativeSize> creativeSizeRepositoryAsync, IBrandscreenContext brandscreenContext, ICacheManager cacheManager, IClock clock, ISignals signals)
        {
            _creativeSizeRepositoryAsync = creativeSizeRepositoryAsync;
            _brandscreenContext = brandscreenContext;
            _cacheManager = cacheManager;
            _clock = clock;
            _signals = signals;
        }

        private string UpdateSignal => $"{GetType()}-update";

        public IQueryable<CreativeSize> GetCreativeSizes()
        {
            var retVal = _cacheManager.Get(GetType(), context =>
            {
                context.Monitor(_clock.When(TimeSpan.FromMinutes(10))); // cache for 10 mins
                context.Monitor(_signals.When(UpdateSignal)); // wait for update signal
                return _creativeSizeRepositoryAsync.Queryable().Where(x => x.IsActive == true).ToList();
            });
            return retVal.ToAsyncEnumerable();
        }

        public IQueryable<CreativeSize> GetCreativeSizes(CreativeSizeQueryOptions options)
        {
            var source = GetCreativeSizes();

            if (options.MediaTypeId.HasValue)
            {
                source = source.Where(x => x.MediaTypeId == options.MediaTypeId.Value);
            }

            return source;
        }

        public Task<CreativeSize> GetCreativeSize(int id)
        {
            return GetCreativeSizes().FirstOrDefaultAsync(x => x.CreativeSizeId == id);
        }

        public Task<CreativeSize> GetCreativeSize(CreativeSizeQueryOptions options)
        {
            var source = GetCreativeSizes(options);
            source = source.Where(x => Math.Abs((x.Width ?? 0) - options.Width) <= options.Discrepancy &&
                                       Math.Abs((x.Height ?? 0) - options.Height) <= options.Discrepancy);
            return source.FirstOrDefaultAsync();
        }

        public async Task CreateCreativeSize(CreativeSize creativeSize)
        {
            _creativeSizeRepositoryAsync.Insert(creativeSize);
            await _brandscreenContext.SaveChangesAsync();
            _signals.Trigger(UpdateSignal);
        }

        public async Task UpdateCreativeSize(CreativeSize creativeSize)
        {
            _creativeSizeRepositoryAsync.Update(creativeSize);
            await _brandscreenContext.SaveChangesAsync();
            _signals.Trigger(UpdateSignal);
        }
    }

    public static class CreativeSizeServiceExtensions
    {
        public static IQueryable<CreativeSize> GetDoohCreativeSizes(this ICreativeSizeService creativeSizeService)
        {
            return creativeSizeService.GetCreativeSizes().Where(x => x.MediaTypeId == (int) MediaTypeEnum.Dooh);
        }

        public static Task<CreativeSize> GetVideoCreativeSize(this ICreativeSizeService creativeSizeService)
        {
            return creativeSizeService.GetCreativeSize(10); // hardcode id
        }
    }
}
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
    public interface IVerticalService : IDependency
    {
        IQueryable<Vertical> GetVerticals();
        IQueryable<Vertical> GetVerticals(VerticalQueryOptions options);
        Task<Vertical> GetVertical(int id);
    }

    public class VerticalService : IVerticalService
    {
        private readonly IRepositoryAsync<Vertical> _verticalRepositoryAsync;
        private readonly ICacheManager _cacheManager;
        private readonly IClock _clock;

        public VerticalService(IRepositoryAsync<Vertical> verticalRepositoryAsync, ICacheManager cacheManager, IClock clock)
        {
            _verticalRepositoryAsync = verticalRepositoryAsync;
            _cacheManager = cacheManager;
            _clock = clock;
        }

        public IQueryable<Vertical> GetVerticals()
        {
            var retVal = _cacheManager.Get(GetType(), context =>
            {
                context.Monitor(_clock.When(TimeSpan.FromMinutes(10))); // cache for 10 mins
                var source = _verticalRepositoryAsync.Queryable()
                    .Include(x => x.Vertical_ParentVerticalId)
                    .Include(x => x.Verticals);
                return source.OrderBy(x => x.VerticalName).ToList();
            });
            return retVal.ToAsyncEnumerable();
        }

        public IQueryable<Vertical> GetVerticals(VerticalQueryOptions options)
        {
            var source = GetVerticals();

            if (options.IsTopLevel.HasValue)
            {
                source = source.Where(x => !x.ParentVerticalId.HasValue == options.IsTopLevel.Value);
            }

            if (options.HasIabReference.HasValue)
            {
                source = source.Where(x => !string.IsNullOrEmpty(x.IabReference) == options.HasIabReference.Value);
            }

            if (!string.IsNullOrEmpty(options.Text))
            {
                source = source.Where(x => x.VerticalName.Contains(options.Text));
            }

            return source;
        }

        public Task<Vertical> GetVertical(int id)
        {
            return GetVerticals().FirstOrDefaultAsync(x => x.VerticalId == id);
        }
    }
}
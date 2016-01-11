using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services.Dooh
{
    public interface IDoohService : IDependency
    {
        IQueryable<DoohGeoLocationGroup> GetDoohGeoLocationGroups();
        Task<DoohGeoLocationGroup> GetDoohGeoLocationGroup(int id);

        IQueryable<DoohPanel> GetDoohPanels();
        Task<DoohPanel> GetDoohPanel(int id);

        IQueryable<DoohLocation> GetDoohLocations();
        Task<DoohLocation> GetDoohLocation(int id);

        IQueryable<DoohPanelLocation> GetDoohPanelLocations();
        Task<DoohPanelLocation> GetDoohPanelLocation(int id);
        Task CreateDoohPanelLocation(DoohPanelLocation doohPanelLocation);
        Task UpdateDoohPanelLocation(DoohPanelLocation doohPanelLocation);
        Task DeleteDoohPanelLocation(int id);
    }

    public class DoohService : IDoohService
    {
        private readonly IBrandscreenContext _brandscreenContext;
        private readonly ILifetimeScope _container;

        public DoohService(IBrandscreenContext brandscreenContext, ILifetimeScope container)
        {
            _brandscreenContext = brandscreenContext;
            _container = container;
        }

        public IQueryable<DoohGeoLocationGroup> GetDoohGeoLocationGroups()
        {
            var source = _container.Resolve<IRepositoryAsync<DoohGeoLocationGroup>>().Queryable()
                .OrderBy(x => x.LocationGroupName);
            return source;
        }

        public Task<DoohGeoLocationGroup> GetDoohGeoLocationGroup(int id)
        {
            var source = GetDoohGeoLocationGroups();
            return source.FirstOrDefaultAsync(x => x.DoohGeoLocationGroupId == id);
        }

        public IQueryable<DoohPanel> GetDoohPanels()
        {
            var source = _container.Resolve<IRepositoryAsync<DoohPanel>>().Queryable()
                .Include(x => x.DoohFormat)
                .Include(x => x.DoohChannel)
                .Include(x => x.CreativeSize)
                .OrderBy(x => x.DoohFormat.FormatName)
                .ThenBy(x => x.DoohChannel.ChannelName)
                .ThenBy(x => x.CreativeSize.CreativeSizeName);
            return source;
        }

        public Task<DoohPanel> GetDoohPanel(int id)
        {
            var source = GetDoohPanels();
            return source.FirstOrDefaultAsync(x => x.DoohPanelId == id);
        }

        public IQueryable<DoohLocation> GetDoohLocations()
        {
            var source = _container.Resolve<IRepositoryAsync<DoohLocation>>().Queryable()
                .OrderBy(x => x.Name);
            return source;
        }

        public Task<DoohLocation> GetDoohLocation(int id)
        {
            var source = GetDoohLocations();
            return source.FirstOrDefaultAsync(x => x.DoohLocationId == id);
        }

        public IQueryable<DoohPanelLocation> GetDoohPanelLocations()
        {
            var source = _container.Resolve<IRepositoryAsync<DoohPanelLocation>>().Queryable()
                .OrderBy(x => x.PanelLocationName);
            return source;
        }

        public Task<DoohPanelLocation> GetDoohPanelLocation(int id)
        {
            var source = GetDoohPanelLocations();
            return source.FirstOrDefaultAsync(x => x.DoohPanelLocationId == id);
        }

        public Task CreateDoohPanelLocation(DoohPanelLocation doohPanelLocation)
        {
            _container.Resolve<IRepositoryAsync<DoohPanelLocation>>().Insert(doohPanelLocation);
            return _brandscreenContext.SaveChangesAsync();
        }

        public Task UpdateDoohPanelLocation(DoohPanelLocation doohPanelLocation)
        {
            _container.Resolve<IRepositoryAsync<DoohPanelLocation>>().Update(doohPanelLocation);
            return _brandscreenContext.SaveChangesAsync();
        }

        public Task DeleteDoohPanelLocation(int id)
        {
            _container.Resolve<IRepositoryAsync<DoohPanelLocation>>().DeleteAsync(id);
            return _brandscreenContext.SaveChangesAsync();
        }
    }

    public static class DoohServiceExtensions
    {
        public static IQueryable<DoohGeoLocationGroup> GetDoohGeoLocationGroupsByIds(this IDoohService doohService, params int[] ids)
        {
            var source = doohService.GetDoohGeoLocationGroups();
            return source.Where(x => ids.Contains(x.DoohGeoLocationGroupId));
        }

        public static IQueryable<DoohPanelLocation> GetDoohPanelLocationsByIds(this IDoohService doohService, params int[] ids)
        {
            var source = doohService.GetDoohPanelLocations();
            return source.Where(x => ids.Contains(x.DoohPanelLocationId));
        }
    }
}
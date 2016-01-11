using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services.Strategies.Targets
{
    public interface IGeoLocationService : IDependency
    {
        IQueryable<GeoLocation> GetGeoLocations();
        Task<GeoLocation> GetGeoLocation(long id);

        Task<GeoCountry> GetGeoCountry(int id);
        Task<GeoRegion> GetGeoRegion(int id);
        Task<GeoMetro> GetGeoMetro(int id);
        Task<GeoCity> GetGeoCity(int id);
    }

    public class GeoLocationService : IGeoLocationService
    {
        private readonly ILifetimeScope _container;

        public GeoLocationService(ILifetimeScope container)
        {
            _container = container;
        }

        public IQueryable<GeoLocation> GetGeoLocations()
        {
            var source = _container.Resolve<IRepositoryAsync<GeoLocation>>().Queryable()
                .Include(x => x.GeoCountry)
                .Include(x => x.GeoCity)
                .Include(x => x.GeoRegion)
                .Include(x => x.GeoMetro)
                .OrderBy(x => x.GeoLocationCode);
            return source;
        }

        public Task<GeoLocation> GetGeoLocation(long id)
        {
            var source = GetGeoLocations();
            return source.FirstOrDefaultAsync(x => x.GeoLocationId == id);
        }

        public Task<GeoCountry> GetGeoCountry(int id)
        {
            return _container.Resolve<IRepositoryAsync<GeoCountry>>().FindAsync(id);
        }

        public Task<GeoRegion> GetGeoRegion(int id)
        {
            return _container.Resolve<IRepositoryAsync<GeoRegion>>().FindAsync(id);
        }

        public Task<GeoMetro> GetGeoMetro(int id)
        {
            return _container.Resolve<IRepositoryAsync<GeoMetro>>().FindAsync(id);
        }

        public Task<GeoCity> GetGeoCity(int id)
        {
            return _container.Resolve<IRepositoryAsync<GeoCity>>().FindAsync(id);
        }
    }

    public static class GeoLocationServiceExtensions
    {
        public static IQueryable<GeoLocation> GetGeoLocationsByGeoCountryIds(this IGeoLocationService geoLocationService, params int[] geoCountryIds)
        {
            var source = geoLocationService.GetGeoLocations();
            return source.Where(x => geoCountryIds.Contains(x.GeoCountryId) && x.GeoRegionId == null && x.GeoMetroId == null && x.GeoCityId == null);
        }

        public static IQueryable<GeoLocation> GetGeoLocationsByGeoRegionIds(this IGeoLocationService geoLocationService, params int[] geoRegionIds)
        {
            var source = geoLocationService.GetGeoLocations();
            return source.Where(x => x.GeoRegionId.HasValue && geoRegionIds.Contains(x.GeoRegionId.Value) && x.GeoMetroId == null && x.GeoCityId == null);
        }

        public static IQueryable<GeoLocation> GetGeoLocationsByGeoMetroIds(this IGeoLocationService geoLocationService, params int[] geoMetroIds)
        {
            var source = geoLocationService.GetGeoLocations();
            return source.Where(x => x.GeoMetroId.HasValue && geoMetroIds.Contains(x.GeoMetroId.Value) && x.GeoCityId == null);
        }

        public static IQueryable<GeoLocation> GetGeoLocationsByGeoCityIds(this IGeoLocationService geoLocationService, params int[] geoCityIds)
        {
            var source = geoLocationService.GetGeoLocations();
            return source.Where(x => x.GeoCityId.HasValue && geoCityIds.Contains(x.GeoCityId.Value));
        }
    }
}
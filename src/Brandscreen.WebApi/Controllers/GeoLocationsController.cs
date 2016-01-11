using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Services.Strategies.Targets;
using Brandscreen.WebApi.Models;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Geo location management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/geolocations")]
    public class GeoLocationsController : ApiController
    {
        private readonly IGeoLocationService _geoLocationService;
        private readonly IMappingEngine _mapping;

        public GeoLocationsController(IGeoLocationService geoLocationService, IMappingEngine mapping)
        {
            _geoLocationService = geoLocationService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves details of a geo location by id.
        /// </summary>
        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof (GeoLocationViewModel))]
        public async Task<IHttpActionResult> Get(long id)
        {
            var geoLocation = await _geoLocationService.GetGeoLocation(id).ConfigureAwait(false);
            if (geoLocation == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<GeoLocationViewModel>(geoLocation);
            return Ok(retVal);
        }

        /// <summary>
        /// Retrieves details of a geo country by id.
        /// </summary>
        [HttpGet]
        [Route("countries/{id:int}")]
        [ResponseType(typeof (GeoCountryViewModel))]
        public async Task<IHttpActionResult> GetGeoCountry(int id)
        {
            var geoCountry = await _geoLocationService.GetGeoCountry(id).ConfigureAwait(false);
            if (geoCountry == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<GeoCountryViewModel>(geoCountry);
            return Ok(retVal);
        }

        /// <summary>
        /// Retrieves details of a geo region by id.
        /// </summary>
        [HttpGet]
        [Route("regions/{id:int}")]
        [ResponseType(typeof (GeoRegionViewModel))]
        public async Task<IHttpActionResult> GetGeoRegion(int id)
        {
            var geoRegion = await _geoLocationService.GetGeoRegion(id).ConfigureAwait(false);
            if (geoRegion == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<GeoRegionViewModel>(geoRegion);
            return Ok(retVal);
        }

        /// <summary>
        /// Retrieves details of a geo metro by id.
        /// </summary>
        [HttpGet]
        [Route("metros/{id:int}")]
        [ResponseType(typeof (GeoMetroViewModel))]
        public async Task<IHttpActionResult> GetGeoMetro(int id)
        {
            var geoMetro = await _geoLocationService.GetGeoMetro(id).ConfigureAwait(false);
            if (geoMetro == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<GeoMetroViewModel>(geoMetro);
            return Ok(retVal);
        }

        /// <summary>
        /// Retrieves details of a geo city by id.
        /// </summary>
        [HttpGet]
        [Route("cities/{id:int}")]
        [ResponseType(typeof (GeoCityViewModel))]
        public async Task<IHttpActionResult> GetGeoCity(int id)
        {
            var geoCity = await _geoLocationService.GetGeoCity(id).ConfigureAwait(false);
            if (geoCity == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<GeoCityViewModel>(geoCity);
            return Ok(retVal);
        }
    }
}
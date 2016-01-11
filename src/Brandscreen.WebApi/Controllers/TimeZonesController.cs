using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Time zone management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/timezones")]
    public class TimeZonesController : ApiController
    {
        private readonly ITimeZoneService _timeZoneService;
        private readonly IMappingEngine _mapping;

        public TimeZonesController(ITimeZoneService timeZoneService, IMappingEngine mapping)
        {
            _timeZoneService = timeZoneService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of time zones.
        /// </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof (PagedListViewModel<TimeZoneListViewModel>))]
        public async Task<IHttpActionResult> Get([FromUri] Pagination model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timeZones = await _timeZoneService.GeTimeZones().ToPagedListAsync(model).ConfigureAwait(false);
            var retVal = _mapping.Map<PagedListViewModel<TimeZoneListViewModel>>(timeZones);
            return Ok(retVal);
        }
    }
}
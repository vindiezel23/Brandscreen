using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Services.Strategies.Targets;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Device management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/devices")]
    public class DevicesController : ApiController
    {
        private readonly IDeviceService _deviceService;
        private readonly IMappingEngine _mapping;

        public DevicesController(IDeviceService deviceService, IMappingEngine mapping)
        {
            _deviceService = deviceService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of devices.
        /// </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof (PagedListViewModel<DeviceListViewModel>))]
        public async Task<IHttpActionResult> Get([FromUri] Pagination model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var devices = await _deviceService.GetDevices().ToPagedListAsync(model).ConfigureAwait(false);
            var retVal = _mapping.Map<PagedListViewModel<DeviceListViewModel>>(devices);
            return Ok(retVal);
        }
    }
}
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
    /// Vertical management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/verticals")]
    public class VerticalsController : ApiController
    {
        private readonly IVerticalService _verticalService;
        private readonly IMappingEngine _mapping;

        public VerticalsController(IVerticalService verticalService, IMappingEngine mapping)
        {
            _verticalService = verticalService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of verticals.
        /// </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof (PagedListViewModel<VerticalListViewModel>))]
        public async Task<IHttpActionResult> Get([FromUri] VerticalQueryViewModel model)
        {
            model = model ?? new VerticalQueryViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var verticalQueryOptions = _mapping.Map<VerticalQueryOptions>(model);
            var verticals = await _verticalService.GetVerticals(verticalQueryOptions).ToPagedListAsync(model).ConfigureAwait(false);
            var retVal = _mapping.Map<PagedListViewModel<VerticalListViewModel>>(verticals);
            return Ok(retVal);
        }
    }
}
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Services.Dooh;
using Brandscreen.Core.Services.Partners;
using Brandscreen.Entities;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Digital out of home management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/dooh")]
    public class DoohController : ApiController
    {
        private readonly IDoohService _doohService;
        private readonly IPartnerService _partnerService;
        private readonly IMappingEngine _mapping;

        public DoohController(IDoohService doohService, IPartnerService partnerService, IMappingEngine mapping)
        {
            _doohService = doohService;
            _partnerService = partnerService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of dooh geo location groups.
        /// </summary>
        [HttpGet]
        [Route("geolocationgroups")]
        public async Task<PagedListViewModel<DoohGeoLocationGroupViewModel>> GetDoohGeoLocationGroups([FromUri] Pagination pagination)
        {
            var doohGeoLocationGroups = await _doohService.GetDoohGeoLocationGroups().ToPagedListAsync(pagination).ConfigureAwait(false);
            var retVal = _mapping.Map<PagedListViewModel<DoohGeoLocationGroupViewModel>>(doohGeoLocationGroups);
            return retVal;
        }

        /// <summary>
        /// Retrieves details of a dooh geo location group by id.
        /// </summary>
        [HttpGet]
        [Route("geolocationgroups/{id:int}")]
        [ResponseType(typeof (DoohGeoLocationGroupViewModel))]
        public async Task<IHttpActionResult> GetDoohGeoLocationGroup(int id)
        {
            var doohGeoLocationGroup = await _doohService.GetDoohGeoLocationGroup(id).ConfigureAwait(false);
            if (doohGeoLocationGroup == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<DoohGeoLocationGroupViewModel>(doohGeoLocationGroup);
            return Ok(retVal);
        }

        /// <summary>
        /// Retrieves list of dooh panels.
        /// </summary>
        [HttpGet]
        [Route("panels")]
        public async Task<PagedListViewModel<DoohPanelViewModel>> GetDoohPanels([FromUri] Pagination pagination)
        {
            var doohPanels = await _doohService.GetDoohPanels().ToPagedListAsync(pagination).ConfigureAwait(false);
            var retVal = _mapping.Map<PagedListViewModel<DoohPanelViewModel>>(doohPanels);
            return retVal;
        }

        /// <summary>
        /// Retrieves list of dooh locations.
        /// </summary>
        [HttpGet]
        [Route("locations")]
        public async Task<PagedListViewModel<DoohLocationViewModel>> GetDoohLocations([FromUri] Pagination pagination)
        {
            var doohLocations = await _doohService.GetDoohLocations().ToPagedListAsync(pagination).ConfigureAwait(false);
            var retVal = _mapping.Map<PagedListViewModel<DoohLocationViewModel>>(doohLocations);
            return retVal;
        }

        /// <summary>
        /// Retrieves list of dooh panel locations.
        /// </summary>
        [HttpGet]
        [Route("panellocations")]
        public async Task<PagedListViewModel<DoohPanelLocationViewModel>> GetDoohPanelLocations([FromUri] Pagination pagination)
        {
            var doohPanelLocations = await _doohService.GetDoohPanelLocations().ToPagedListAsync(pagination).ConfigureAwait(false);
            var retVal = _mapping.Map<PagedListViewModel<DoohPanelLocationViewModel>>(doohPanelLocations);
            return retVal;
        }

        /// <summary>
        /// Retrieves detail of dooh panel location by id.
        /// </summary>
        [HttpGet]
        [Route("panellocations/{id:int}", Name = "Dooh.PanelLocations.GetById")]
        public async Task<IHttpActionResult> GetDoohPanelLocation(int id)
        {
            var doohPanelLocation = await _doohService.GetDoohPanelLocation(id).ConfigureAwait(false);
            if (doohPanelLocation == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<DoohPanelLocationViewModel>(doohPanelLocation);
            return Ok(retVal);
        }

        /// <summary>
        /// Creates a dooh panel location.
        /// </summary>
        [HttpPost]
        [Route("panellocations")]
        public async Task<IHttpActionResult> PostDoohPanelLocation(DoohPanelLocationCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var doohPanel = await _doohService.GetDoohPanel(model.DoohPanelId.GetValueOrDefault(0)).ConfigureAwait(false);
            if (doohPanel == null)
            {
                return BadRequest("The specified dooh panel was not found.");
            }

            var doohLocation = await _doohService.GetDoohLocation(model.DoohLocationId.GetValueOrDefault(0)).ConfigureAwait(false);
            if (doohLocation == null)
            {
                return BadRequest("The specified dooh location was not found.");
            }

            var partner = await _partnerService.GetPartner(model.PartnerId.GetValueOrDefault(0)).ConfigureAwait(false);
            if (partner == null)
            {
                return BadRequest("The specified partner was not found.");
            }

            var doohPanelLocation = _mapping.Map<DoohPanelLocation>(model);
            await _doohService.CreateDoohPanelLocation(doohPanelLocation).ConfigureAwait(false); // create
            doohPanelLocation = await _doohService.GetDoohPanelLocation(doohPanelLocation.DoohPanelLocationId).ConfigureAwait(false); // reload
            var doohPanelLocationViewModel = _mapping.Map<DoohPanelLocationViewModel>(doohPanelLocation);
            return CreatedAtRoute("Dooh.PanelLocations.GetById", new {Id = doohPanelLocationViewModel.DoohPanelLocationId}, doohPanelLocationViewModel);
        }

        /// <summary>
        /// Updates a dooh panel location.
        /// </summary>
        [HttpPatch]
        [Route("panellocations/{id:int}")]
        public async Task<IHttpActionResult> PatchDoohPanelLocation(int id, DoohPanelLocationPatchViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var doohPanelLocation = await _doohService.GetDoohPanelLocation(id).ConfigureAwait(false);
            if (doohPanelLocation == null)
            {
                return NotFound();
            }

            _mapping.Map(model, doohPanelLocation);
            await _doohService.UpdateDoohPanelLocation(doohPanelLocation).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Deletes a dooh panel location.
        /// </summary>
        [HttpDelete]
        [Route("panellocations/{id:int}")]
        public async Task<IHttpActionResult> DeleteDoohPanelLocation(int id)
        {
            var doohPanelLocation = await _doohService.GetDoohPanelLocation(id).ConfigureAwait(false);
            if (doohPanelLocation == null)
            {
                return NotFound();
            }

            await _doohService.DeleteDoohPanelLocation(id).ConfigureAwait(false);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
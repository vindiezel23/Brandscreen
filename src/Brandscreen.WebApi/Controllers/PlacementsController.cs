using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Core.Services.Placements;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Placement management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/placements")]
    public class PlacementsController : ApiController
    {
        private readonly IPlacementService _placementService;
        private readonly IStrategyService _strategyService;
        private readonly ICreativeService _creativeService;
        private readonly IMappingEngine _mapping;

        public PlacementsController(IPlacementService placementService, IStrategyService strategyService, ICreativeService creativeService, IMappingEngine mapping)
        {
            _placementService = placementService;
            _strategyService = strategyService;
            _creativeService = creativeService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of placements.
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<PagedListViewModel<PlacementListViewModel>> Get([FromUri] PlacementQueryViewModel model)
        {
            var placementQueryOptions = _mapping.Map<PlacementQueryOptions>(model);
            var campaigns = await _placementService.GetPlacements(placementQueryOptions).ToPagedListAsync(model).ConfigureAwait(false);
            return _mapping.Map<PagedListViewModel<PlacementListViewModel>>(campaigns);
        }

        /// <summary>
        /// Retrieves details of a placement by id.
        /// </summary>
        [HttpGet]
        [Route("{id:guid}", Name = "Placements.GetById")]
        [ResponseType(typeof (PlacementViewModel))]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var placement = await _placementService.GetPlacement(id).ConfigureAwait(false);
            if (placement == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<PlacementViewModel>(placement);
            return Ok(retVal);
        }

        /// <summary>
        /// Associates or dissociates a strategy and a creative.
        /// </summary>
        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Put(PlacementPutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(model.StrategyUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (strategy == null)
            {
                return BadRequest("The specified strategy was not found.");
            }

            var creative = await _creativeService.GetCreative(model.CreativeUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (creative == null)
            {
                return BadRequest("The specified creative was not found.");
            }

            var placementModifyOptions = _mapping.Map<PlacementModifyOptions>(model);
            await _placementService.ModifyPlacement(placementModifyOptions).ConfigureAwait(false);
            return Ok();
        }
    }
}
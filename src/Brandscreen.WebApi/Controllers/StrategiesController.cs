using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core;
using Brandscreen.Core.Services.Campaigns;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Entities;
using Brandscreen.Framework.Caching;
using Brandscreen.Framework.Services;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Strategy management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/strategies")]
    public partial class StrategiesController : ApiController
    {
        private readonly IStrategyService _strategyService;
        private readonly IStrategyTargetingService _strategyTargetingService;
        private readonly IStrategyTargetingUpdateService _strategyTargetingUpdateService;
        private readonly ICampaignService _campaignService;
        private readonly IMappingEngine _mapping;
        private readonly IClock _clock;
        private readonly ICacheManager _cacheManager;

        public StrategiesController(IStrategyService strategyService,
            IStrategyTargetingService strategyTargetingService,
            IStrategyTargetingUpdateService strategyTargetingUpdateService,
            ICampaignService campaignService,
            IMappingEngine mapping,
            IClock clock,
            ICacheManager cacheManager)
        {
            _strategyService = strategyService;
            _strategyTargetingService = strategyTargetingService;
            _strategyTargetingUpdateService = strategyTargetingUpdateService;
            _campaignService = campaignService;
            _mapping = mapping;
            _clock = clock;
            _cacheManager = cacheManager;
        }

        /// <summary>
        /// Retrieves list of strategies.
        /// </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof (PagedListViewModel<StrategyListViewModel>))]
        public async Task<IHttpActionResult> Get([FromUri] StrategyQueryViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategyQueryOptions = _mapping.Map<StrategyQueryOptions>(model);
            var adGroups = await _strategyService.GetStrategies(strategyQueryOptions).ToPagedListAsync(model).ConfigureAwait(false);
            var retVal = _mapping.Map<PagedListViewModel<StrategyListViewModel>>(adGroups);
            return Ok(retVal);
        }

        /// <summary>
        /// Retrieves details of a strategy by id.
        /// </summary>
        [HttpGet]
        [Route("{id:guid}", Name = "Strategies.GetById")]
        [ResponseType(typeof (StrategyViewModel))]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<StrategyViewModel>(strategy);
            return Ok(retVal);
        }

        /// <summary>
        /// Creates a new strategy.
        /// </summary>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof (StrategyViewModel))]
        public async Task<IHttpActionResult> Post(StrategyCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var campaign = await _campaignService.GetCampaign(model.CampaignUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (campaign == null)
            {
                return BadRequest("The specified campaign was not found.");
            }

            var strategy = _mapping.Map<AdGroup>(model);
            await _strategyService.CreateStrategy(strategy).ConfigureAwait(false);

            strategy = await _strategyService.GetStrategy(strategy.AdGroupUuid).ConfigureAwait(false);
            var strategyViewModel = _mapping.Map<StrategyViewModel>(strategy);
            return CreatedAtRoute("Strategies.GetById", new {Id = strategy.AdGroupUuid}, strategyViewModel);
        }

        /// <summary>
        /// Updates a strategy.
        /// </summary>
        [HttpPatch]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Patch(Guid id, StrategyPatchViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyUpdateOptions = _mapping.Map<StrategyUpdateOptions>(model, options => options.Items.Add(nameof(id), id));
            try
            {
                await _strategyService.UpdateStrategy(strategyUpdateOptions).ConfigureAwait(false);
                return Ok();
            }
            catch (BrandscreenException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
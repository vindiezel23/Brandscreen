using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Services.Brands;
using Brandscreen.Core.Services.Campaigns;
using Brandscreen.Entities;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Campaign management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/campaigns")]
    public class CampaignsController : ApiController
    {
        private readonly ICampaignService _campaignService;
        private readonly IBrandService _brandService;
        private readonly IMappingEngine _mapping;

        public CampaignsController(ICampaignService campaignService, IBrandService brandService, IMappingEngine mapping)
        {
            _campaignService = campaignService;
            _brandService = brandService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of compaigns.
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<PagedListViewModel<CampaignListViewModel>> Get([FromUri] CampaignQueryViewModel model)
        {
            var campaignQueryOptions = _mapping.Map<CampaignQueryOptions>(model);
            var campaigns = await _campaignService.GetCampaigns(campaignQueryOptions).ToPagedListAsync(model).ConfigureAwait(false);
            return _mapping.Map<PagedListViewModel<CampaignListViewModel>>(campaigns);
        }

        /// <summary>
        /// Retrieves details of a campaign by id.
        /// </summary>
        [HttpGet]
        [Route("{id:guid}", Name = "Campaigns.GetById")]
        [ResponseType(typeof (CampaignViewModel))]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var campaign = await _campaignService.GetCampaign(id).ConfigureAwait(false);
            if (campaign == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<CampaignViewModel>(campaign);
            return Ok(retVal);
        }

        /// <summary>
        /// Creates a campaign.
        /// </summary>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof (CampaignViewModel))]
        public async Task<IHttpActionResult> Post(CampaignCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = await _brandService.GetBrand(model.BrandUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (brand == null)
            {
                return BadRequest("The specified brand was not found.");
            }

            var campaign = _mapping.Map<Campaign>(model);
            await _campaignService.CreateCampaign(campaign).ConfigureAwait(false);

            campaign = await _campaignService.GetCampaign(campaign.CampaignUuid).ConfigureAwait(false);
            var campaignViewModel = _mapping.Map<CampaignViewModel>(campaign);
            return CreatedAtRoute("Campaigns.GetById", new {Id = campaignViewModel.CampaignUuid}, campaignViewModel);
        }

        /// <summary>
        /// Updates a campaign.
        /// </summary>
        [HttpPatch]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Patch(Guid id, CampaignPatchViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var campaign = await _campaignService.GetCampaign(id).ConfigureAwait(false);
            if (campaign == null)
            {
                return NotFound();
            }

            _mapping.Map(model, campaign);
            await _campaignService.UpdateCampaign(campaign).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Deletes a campaign.
        /// </summary>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var campaign = await _campaignService.GetCampaign(id).ConfigureAwait(false);
            if (campaign == null)
            {
                return NotFound();
            }

            await _campaignService.DeleteCampaign(id).ConfigureAwait(false);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
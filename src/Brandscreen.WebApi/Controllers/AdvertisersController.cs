using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Core.Services.Advertisers;
using Brandscreen.Entities;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Advertiser management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/advertisers")]
    public class AdvertisersController : ApiController
    {
        private readonly IAdvertiserService _advertiserService;
        private readonly IAccountService _accountService;
        private readonly IIndustryCategoryService _industryCategoryService;
        private readonly IMappingEngine _mapping;

        public AdvertisersController(IAdvertiserService advertiserService, IAccountService accountService, IIndustryCategoryService industryCategoryService, IMappingEngine mapping)
        {
            _advertiserService = advertiserService;
            _accountService = accountService;
            _industryCategoryService = industryCategoryService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of advertisers.
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<PagedListViewModel<AdvertiserListViewModel>> Get([FromUri] AdvertiserQueryViewModel model)
        {
            var advertiserQueryOptions = _mapping.Map<AdvertiserQueryOptions>(model);
            var advertisers = await _advertiserService.GetAdvertisers(advertiserQueryOptions).ToPagedListAsync(model).ConfigureAwait(false);
            return _mapping.Map<PagedListViewModel<AdvertiserListViewModel>>(advertisers);
        }

        /// <summary>
        /// Retrieves details of an advertiser by id.
        /// </summary>
        [HttpGet]
        [Route("{id:guid}", Name = "Advertisers.GetById")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var buyerAccount = await _advertiserService.GetAdvertiser(id).ConfigureAwait(false);
            if (buyerAccount == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<AdvertiserViewModel>(buyerAccount);
            return Ok(retVal);
        }

        /// <summary>
        /// Creates an advertiser.
        /// </summary>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof (AdvertiserViewModel))]
        public async Task<IHttpActionResult> Post(AdvertiserCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var buyerAccount = await _accountService.GetAccount(model.BuyerAccountUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (buyerAccount == null)
            {
                return BadRequest("The specified buyer account was not found.");
            }

            var industryCategory = await _industryCategoryService.GetIndustryCategory(model.IndustryCategoryId.GetValueOrDefault(0)).ConfigureAwait(false);
            if (industryCategory == null)
            {
                return BadRequest("The specified industry category was not found.");
            }

            var advertiser = _mapping.Map<Advertiser>(model);
            await _advertiserService.CreateAdvertiser(advertiser).ConfigureAwait(false);

            advertiser = await _advertiserService.GetAdvertiser(advertiser.AdvertiserUuid).ConfigureAwait(false);
            var advertiserViewModel = _mapping.Map<AdvertiserViewModel>(advertiser);
            return CreatedAtRoute("Advertisers.GetById", new {Id = advertiserViewModel.AdvertiserUuid}, advertiserViewModel);
        }

        /// <summary>
        /// Updates an advertiser.
        /// </summary>
        [HttpPatch]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Patch(Guid id, AdvertiserPatchViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var advertiser = await _advertiserService.GetAdvertiser(id).ConfigureAwait(false);
            if (advertiser == null)
            {
                return NotFound();
            }

            if (model.IndustryCategoryId.HasValue)
            {
                var industryCategory = await _industryCategoryService.GetIndustryCategory(model.IndustryCategoryId.Value).ConfigureAwait(false);
                if (industryCategory == null)
                {
                    return BadRequest("The specified industry category was not found.");
                }
            }

            _mapping.Map(model, advertiser);
            await _advertiserService.UpdateAdvertiser(advertiser).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Deletes an advertiser.
        /// </summary>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var advertiser = await _advertiserService.GetAdvertiser(id).ConfigureAwait(false);
            if (advertiser == null)
            {
                return NotFound();
            }

            await _advertiserService.DeleteAdvertiser(id).ConfigureAwait(false);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
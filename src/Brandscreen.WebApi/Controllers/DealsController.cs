using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Core.Services.Deals;
using Brandscreen.Core.Services.Publishers;
using Brandscreen.Entities;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Deal management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/deals")]
    public class DealsController : ApiController
    {
        private readonly IAccountService _accountService;
        private readonly IPublisherService _publisherService;
        private readonly IDealService _dealService;
        private readonly IMappingEngine _mapping;

        public DealsController(IAccountService accountService, IPublisherService publisherService, IDealService dealService, IMappingEngine mapping)
        {
            _accountService = accountService;
            _publisherService = publisherService;
            _dealService = dealService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of deals.
        /// </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof (PagedListViewModel<DealListViewModel>))]
        public async Task<IHttpActionResult> Get([FromUri] DealQueryViewModel model)
        {
            model = model ?? new DealQueryViewModel(); // super/system admins can pass null to get all deals

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.BuyerAccountUuid.HasValue)
            {
                var account = await _accountService.GetAccount(model.BuyerAccountUuid.Value).ConfigureAwait(false);
                if (account == null)
                {
                    return BadRequest("The specified account was not found.");
                }
            }

            var dealQueryOptions = _mapping.Map<DealQueryOptions>(model);
            var deals = await _dealService.GetDeals(dealQueryOptions).ToPagedListAsync(model).ConfigureAwait(false);
            var retVal = _mapping.Map<PagedListViewModel<DealListViewModel>>(deals);
            return Ok(retVal);
        }

        /// <summary>
        /// Retrieves detail of a deal by id.
        /// </summary>
        [HttpGet]
        [Route("{id:guid}", Name = "Deals.GetById")]
        [ResponseType(typeof (DealViewModel))]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var deal = await _dealService.GetDeal(id).ConfigureAwait(false);
            if (deal == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<DealViewModel>(deal);
            return Ok(retVal);
        }

        /// <summary>
        /// Creates a new deal.
        /// </summary>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof (DealViewModel))]
        public async Task<IHttpActionResult> Post(DealCreateViewModel model)
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

            var publisher = await _publisherService.GetPublisher(model.PublisherUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (publisher == null)
            {
                return BadRequest("The specified publisher was not found.");
            }

            // map
            var deal = _mapping.Map<Deal>(model);
            deal.BuyerAccountId = buyerAccount.BuyerAccountId;
            deal.PublisherId = publisher.PartnerId;
            deal.PublishersName = publisher.PublisherName;

            try
            {
                deal = await _dealService.CreateDeal(deal).ConfigureAwait(false); // create
                deal = await _dealService.GetDeal(deal.DealUuid).ConfigureAwait(false); // reload
                var dealViewModel = _mapping.Map<DealViewModel>(deal);
                return CreatedAtRoute("Deals.GetById", new {Id = dealViewModel.DealUuid}, dealViewModel);
            }
            catch (BrandscreenException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Updates a deal.
        /// </summary>
        [HttpPatch]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Patch(Guid id, DealPatchViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deal = await _dealService.GetDeal(id).ConfigureAwait(false);
            if (deal == null)
            {
                return NotFound();
            }

            _mapping.Map(model, deal);
            await _dealService.UpdateDeal(deal).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Deletes a deal.
        /// </summary>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var deal = await _dealService.GetDeal(id).ConfigureAwait(false);
            if (deal == null)
            {
                return NotFound();
            }

            await _dealService.DeleteDeal(id).ConfigureAwait(false);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
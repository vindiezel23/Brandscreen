using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Core.Services.Users;
using Brandscreen.Entities;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;
using Castle.Core.Logging;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Buyer account management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/accounts")]
    public class AccountsController : ApiController
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IMappingEngine _mapping;

        public AccountsController(IAccountService accountService, IUserService userService, IMappingEngine mapping)
        {
            _accountService = accountService;
            _userService = userService;
            _mapping = mapping;

            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        /// <summary>
        /// Retrieves list of accounts which are linked to request user.
        /// </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof (PagedListViewModel<AccountListViewModel>))]
        public async Task<IHttpActionResult> Get([FromUri] AccountQueryViewModel model)
        {
            model = model ?? new AccountQueryViewModel(); // super/system admins can pass null to get all accounts

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.UserId.HasValue)
            {
                var user = await _userService.GetUser(model.UserId.Value).ConfigureAwait(false);
                if (user == null)
                {
                    return BadRequest("The specified user was not found.");
                }
            }

            var accountQueryOptions = _mapping.Map<AccountQueryOptions>(model);
            var accounts = await _accountService.GetAccounts(accountQueryOptions).ToPagedListAsync(model).ConfigureAwait(false);
            var retVal = _mapping.Map<PagedListViewModel<AccountListViewModel>>(accounts);
            return Ok(retVal);
        }

        /// <summary>
        /// Retrieves details of an account by id.
        /// </summary>
        [HttpGet]
        [Route("{id:guid}", Name = "Accounts.GetById")]
        [ResponseType(typeof (AccountViewModel))]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var buyerAccount = await _accountService.GetAccount(id).ConfigureAwait(false);
            if (buyerAccount == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<AccountViewModel>(buyerAccount);
            return Ok(retVal);
        }

        /// <summary>
        /// Create an account.
        /// Super/System admins only.
        /// </summary>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof (AccountViewModel))]
        public async Task<IHttpActionResult> Post(AccountCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var owner = await _userService.GetUser(model.UserId).ConfigureAwait(false);
            if (owner == null)
            {
                return BadRequest("The specified user was not found.");
            }

            var buyerAccount = _mapping.Map<BuyerAccount>(model);
            await _accountService.CreateAccount(buyerAccount, owner).ConfigureAwait(false);

            var accountViewModel = _mapping.Map<AccountViewModel>(buyerAccount);
            return CreatedAtRoute("Accounts.GetById", new {Id = accountViewModel.BuyerAccountUuid}, accountViewModel);
        }

        /// <summary>
        /// Updates an account.
        /// Account admins only.
        /// </summary>
        [HttpPatch]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Patch(Guid id, AccountPatchViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var buyerAccount = await _accountService.GetAccount(id).ConfigureAwait(false);
            if (buyerAccount == null)
            {
                return NotFound();
            }

            _mapping.Map(model, buyerAccount);
            await _accountService.UpdateAccount(buyerAccount).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates terms of an account.
        /// Super/System admins only.
        /// </summary>
        [HttpPatch]
        [Route("{id:guid}/terms")]
        public async Task<IHttpActionResult> PatchTerms(Guid id, AccountTermsPatchViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var buyerAccount = await _accountService.GetAccount(id).ConfigureAwait(false);
            if (buyerAccount == null)
            {
                return NotFound();
            }

            _mapping.Map(model, buyerAccount);
            await _accountService.UpdateAccount(buyerAccount).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Gets status of an account.
        /// </summary>
        [HttpGet]
        [Route("{id:guid}/status")]
        public async Task<AccountStatusViewModel> GetStatus(Guid id)
        {
            var status = await _accountService.GetAccountStatus(id).ConfigureAwait(false);
            return new AccountStatusViewModel {Status = status.ToString()};
        }

        /// <summary>
        /// Updates status of an account, status can be Activated, Rejected, or Suspended.
        /// Super/System admins only.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/status")]
        public async Task<IHttpActionResult> PutStatus(Guid id, AccountStatusViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var buyerAccount = await _accountService.GetAccount(id).ConfigureAwait(false);
            if (buyerAccount == null)
            {
                return NotFound();
            }

            try
            {
                var newStatus = (AccountStatusEnum) Enum.Parse(typeof (AccountStatusEnum), model.Status, true);
                await _accountService.ChangeAccountStatus(id, newStatus).ConfigureAwait(false);
                return Ok();
            }
            catch (BrandscreenException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Deletes an account.
        /// Super/System admins only.
        /// </summary>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var buyerAccount = await _accountService.GetAccount(id).ConfigureAwait(false);
            if (buyerAccount == null)
            {
                return NotFound();
            }

            await _accountService.DeleteAccount(id).ConfigureAwait(false);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
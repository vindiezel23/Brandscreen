using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Core.Services.Users;
using Brandscreen.Entities;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;
using Castle.Core.Logging;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// User management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IMappingEngine _mapping;

        public UsersController(IUserService userService, IAccountService accountService, IMappingEngine mapping)
        {
            _userService = userService;
            _accountService = accountService;
            _mapping = mapping;

            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        /// <summary>
        /// Retrieves list of users.
        /// </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof (PagedListViewModel<UserListViewModel>))]
        public async Task<IHttpActionResult> Get([FromUri] UserQueryViewModel model)
        {
            model = model ?? new UserQueryViewModel(); // super/system admins can pass null to get all users

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

            if (model.BuyerAccountUuid.HasValue)
            {
                var buyerAccount = await _accountService.GetAccount(model.BuyerAccountUuid.Value).ConfigureAwait(false);
                if (buyerAccount == null)
                {
                    return BadRequest("The specified buyer account was not found.");
                }
            }

            var userQueryOptions = _mapping.Map<UserQueryOptions>(model);
            var users = await _userService.GetUsers(userQueryOptions).ToPagedListAsync(model).ConfigureAwait(false);
            var retVal = _mapping.Map<PagedListViewModel<UserListViewModel>>(users);
            return Ok(retVal);
        }

        /// <summary>
        /// Retrieves detail of an user by id.
        /// </summary>
        [HttpGet]
        [Route("{id:guid}")]
        [ResponseType(typeof (UserViewModel))]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var user = await _userService.GetUser(id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<UserViewModel>(user);
            return Ok(retVal);
        }

        /// <summary>
        /// Registers a new pending approval user and a linked account.
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IHttpActionResult> Register(UserRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapping.Map<User>(model);
            var buyerAccount = _mapping.Map<BuyerAccount>(model);
            var result = await _userService.RegisterUser(user, model.Password, buyerAccount).ConfigureAwait(false);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        }

        /// <summary>
        /// Creates a new user for a particular buyer account.
        /// </summary>
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post(UserCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var buyerAccountUuid = model.BuyerAccountUuid.GetValueOrDefault(Guid.Empty);
            var buyerAccount = await _accountService.GetAccount(buyerAccountUuid).ConfigureAwait(false);
            if (buyerAccount == null)
            {
                return BadRequest("The specified buyer account was not found.");
            }

            var currentUserId = Request.GetOwinContext().GetCurrentUserId();
            try
            {
                var costView = (CostViewEnum) Enum.Parse(typeof (CostViewEnum), model.CostView, true);
                await _userService.AssignUserToBuyerAccount(buyerAccountUuid, model.Email, model.Role, costView, currentUserId).ConfigureAwait(false);
                return Ok();
            }
            catch (BrandscreenException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat(ex, $"failed to assign user {currentUserId} to buyer account {model.BuyerAccountUuid}");
                ModelState.AddModelError("", ex);
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Updates an user.
        /// </summary>
        [HttpPatch]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Patch(Guid id, UserPatchViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.GetUser(id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }

            _mapping.Map(model, user);
            await _userService.UpdateUser(user).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Deletes an user from a particular buyer account.
        /// </summary>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Delete(Guid id, UserDeleteViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var buyerAccountUuid = model.BuyerAccountUuid.GetValueOrDefault(Guid.Empty);
            var buyerAccount = await _accountService.GetAccount(buyerAccountUuid).ConfigureAwait(false);
            if (buyerAccount == null)
            {
                return BadRequest("The specified buyer account was not found.");
            }

            var user = await _userService.GetUser(id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.RemoveUserFromBuyerAccount(buyerAccountUuid, id).ConfigureAwait(false);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
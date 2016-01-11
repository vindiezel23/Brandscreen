using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Services.Memberships;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Membership management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/memberships")]
    public class MembershipsController : ApiController
    {
        private readonly IMembershipService _membershipService;
        private readonly IMappingEngine _mapping;

        public MembershipsController(IMembershipService membershipService, IMappingEngine mapping)
        {
            _membershipService = membershipService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of usres.
        /// </summary>
        [HttpGet]
        [Route("users")]
        public async Task<PagedListViewModel<ApplicationUserListViewModel>> Get([FromUri] Pagination model)
        {
            var applicationUsers = await _membershipService.GetUsers().ToPagedListAsync(model).ConfigureAwait(false);
            return _mapping.Map<PagedListViewModel<ApplicationUserListViewModel>>(applicationUsers);
        }

        /// <summary>
        /// Retrieves detail of an user by id.
        /// </summary>
        [HttpGet]
        [Route("users/{id:guid}", Name = "Users.GetById")]
        [ResponseType(typeof (ApplicationUserViewModel))]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var user = await _membershipService.GetUser(id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }

            var model = _mapping.Map<ApplicationUserViewModel>(user);
            return Ok(model);
        }

        /// <summary>
        /// Retrieves detail of an user by email.
        /// </summary>
        [HttpGet]
        [Route("users")]
        [ResponseType(typeof (ApplicationUserViewModel))]
        public async Task<IHttpActionResult> Get([FromUri] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest();
            }

            var user = await _membershipService.GetUser(email).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }

            var model = _mapping.Map<ApplicationUserViewModel>(user);
            return Ok(model);
        }

        /// <summary>
        /// Creates an user.
        /// </summary>
        [HttpPost]
        [Route("users")]
        [ResponseType(typeof (ApplicationUserViewModel))]
        public async Task<IHttpActionResult> Post(ApplicationUserCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applicationUserCreateOptions = _mapping.Map<ApplicationUserCreateOptions>(model);
            var result = await _membershipService.CreateUser(applicationUserCreateOptions).ConfigureAwait(false);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState);
            }

            var user = await _membershipService.GetUser(model.Email).ConfigureAwait(false);
            var applicationUserViewModel = _mapping.Map<ApplicationUserViewModel>(user);
            return CreatedAtRoute("Users.GetById", new {applicationUserViewModel.Id}, applicationUserViewModel);
        }

        /// <summary>
        /// Updates an user.
        /// </summary>
        [HttpPatch]
        [Route("users/{id:guid}")]
        public async Task<IHttpActionResult> Patch(Guid id, ApplicationUserPatchViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _membershipService.GetUser(id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }

            var applicationUserUpdateOptions = _mapping.Map<ApplicationUserUpdateOptions>(model, options => options.Items.Add(nameof(id), id));
            var result = await _membershipService.UpdateUser(applicationUserUpdateOptions).ConfigureAwait(false);
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
        /// Deletes an user.
        /// </summary>
        [HttpDelete]
        [Route("users/{id:guid}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var user = await _membershipService.GetUser(id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _membershipService.DeleteUser(id).ConfigureAwait(false);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Retrieves list of roles.
        /// </summary>
        [HttpGet]
        [Route("roles")]
        public async Task<PagedListViewModel<ApplicationRoleViewModel>> GetRoles([FromUri] Pagination model)
        {
            var roles = await _membershipService.GetRoles().ToPagedListAsync(model).ConfigureAwait(false);
            return _mapping.Map<PagedListViewModel<ApplicationRoleViewModel>>(roles);
        }

        /// <summary>
        /// Retrieves detail of a role by id.
        /// </summary>
        [HttpGet]
        [Route("roles/{id:guid}", Name = "Roles.GetById")]
        [ResponseType(typeof (ApplicationRoleViewModel))]
        public async Task<IHttpActionResult> GetRole(Guid id)
        {
            var identityRole = await _membershipService.GetRole(id).ConfigureAwait(false);
            if (identityRole == null)
            {
                return NotFound();
            }

            var model = _mapping.Map<ApplicationRoleViewModel>(identityRole);
            return Ok(model);
        }

        /// <summary>
        /// Retrieves detail of a role by role name.
        /// </summary>
        [HttpGet]
        [Route("roles")]
        [ResponseType(typeof (ApplicationRoleViewModel))]
        public async Task<IHttpActionResult> GetRole([FromUri] string role)
        {
            if (string.IsNullOrEmpty(role))
            {
                return BadRequest();
            }

            var identityRole = await _membershipService.GetRole(role).ConfigureAwait(false);
            if (identityRole == null)
            {
                return NotFound();
            }

            var model = _mapping.Map<ApplicationRoleViewModel>(identityRole);
            return Ok(model);
        }

        /// <summary>
        /// Creates a role.
        /// </summary>
        [HttpPost]
        [Route("roles")]
        [ResponseType(typeof (ApplicationRoleViewModel))]
        public async Task<IHttpActionResult> PostRole(ApplicationRoleCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _membershipService.CreateRole(model.RoleName).ConfigureAwait(false);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState);
            }

            var identityRole = await _membershipService.GetRole(model.RoleName).ConfigureAwait(false);
            var applicationRoleViewModel = _mapping.Map<ApplicationRoleViewModel>(identityRole);
            return CreatedAtRoute("Roles.GetById", new {applicationRoleViewModel.Id}, applicationRoleViewModel);
        }

        /// <summary>
        /// Deletes a role.
        /// </summary>
        [HttpDelete]
        [Route("roles/{id:guid}")]
        public async Task<IHttpActionResult> DeleteRole(Guid id)
        {
            var role = await _membershipService.GetRole(id).ConfigureAwait(false);
            if (role == null)
            {
                return BadRequest();
            }

            var result = await _membershipService.DeleteRole(id).ConfigureAwait(false);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
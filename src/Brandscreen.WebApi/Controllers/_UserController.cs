using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Brandscreen.Core.Services.Memberships;
using Brandscreen.WebApi.Jsons;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Models.Mvc.User;
using Brandscreen.WebApi.Paginations;
using ApplicationUserListViewModel = Brandscreen.WebApi.Models.Mvc.User.ApplicationUserListViewModel;

namespace Brandscreen.WebApi.Controllers
{
    [Authorize(Roles = "SuperAdministrator, SystemAdministrator")]
    public class UserController : Controller
    {
        private readonly IMembershipService _membershipService;
        private readonly IMappingEngine _mapping;

        public UserController(IMembershipService membershipService, IMappingEngine mapping)
        {
            _membershipService = membershipService;
            _mapping = mapping;
        }

        public async Task<ActionResult> Index(ApplicationUserQueryViewModel model)
        {
            var applicationUserQueryOptions = _mapping.Map<ApplicationUserQueryOptions>(model);
            var applicationUsers = await _membershipService.GetUsers(applicationUserQueryOptions).ToPagedListAsync(model).ConfigureAwait(false);
            var viewModel = _mapping.Map<PagedListViewModel<ApplicationUserListViewModel>>(applicationUsers);
            return JsonResultEx.Create(viewModel);
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var applicationUser = await _membershipService.GetUser(id).ConfigureAwait(false);
            if (applicationUser == null)
            {
                return JsonResultEx.Create(HttpStatusCode.NotFound);
            }

            return JsonResultEx.Create(new
            {
                RoleList = await _membershipService.GetRoles().Select(x => x.Name).ToListAsync().ConfigureAwait(false),
                ClaimList = await _membershipService.GetClaimTypes().ToListAsync().ConfigureAwait(false),
                Model = _mapping.Map<ApplicationUserViewModel>(applicationUser)
            });
        }

        [HttpPut]
        [ValidateJsonAntiForgeryToken]
        public async Task<ActionResult> Update(Guid id, ApplicationUserUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return JsonResultEx.Create(ModelState);
            }

            // create role if not exists
            model.Roles = (model.Roles ?? new List<string>()).Distinct();
            var roles = await _membershipService.GetRoles().Select(x => x.Name).ToListAsync().ConfigureAwait(false);
            foreach (var role in model.Roles)
            {
                if (!roles.Contains(role))
                {
                    await _membershipService.CreateRole(role);
                }
            }

            var applicationUserUpdateOptions = _mapping.Map<ApplicationUserUpdateOptions>(model, options => options.Items.Add(nameof(id), id));
            var result = await _membershipService.UpdateUser(applicationUserUpdateOptions).ConfigureAwait(false);
            return JsonResultEx.Create(result);
        }
    }
}
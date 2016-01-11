using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Memberships;
using Brandscreen.WebApi.Helpers;
using Brandscreen.WebApi.Jsons;
using Brandscreen.WebApi.Models.Mvc.Account;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Brandscreen.WebApi.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IMembershipService _membershipService;
        private readonly ApplicationSignInManager _applicationSignInManager;
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IMappingEngine _mapping;

        public AccountController(IMembershipService membershipService, ApplicationSignInManager applicationSignInManager, IAuthenticationManager authenticationManager, IMappingEngine mapping)
        {
            _membershipService = membershipService;
            _applicationSignInManager = applicationSignInManager;
            _authenticationManager = authenticationManager;
            _mapping = mapping;
        }

        [AllowAnonymous]
        public ActionResult CurrentUser()
        {
            var currentUser = _mapping.Map<CurrentUserViewModel>(User.Identity);
            return JsonResultEx.Create(currentUser);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateJsonAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return JsonResultEx.Create(ModelState);
            }

            var result = await _applicationSignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false).ConfigureAwait(false);
            switch (result)
            {
                case SignInStatus.Success:
                    return JsonResultEx.Create();
                case SignInStatus.LockedOut:
                case SignInStatus.RequiresVerification:
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return JsonResultEx.Create(ModelState);
            }
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult LogOff()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return JsonResultEx.Create();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateJsonAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var applicationUserCreateOptions = _mapping.Map<ApplicationUserCreateOptions>(model);
                var result = await _membershipService.CreateUser(applicationUserCreateOptions).ConfigureAwait(false);
                if (result.Succeeded)
                {
                    var user = await _membershipService.GetUser(model.Email).ConfigureAwait(false);
                    await _applicationSignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return JsonResultEx.Create();
                }
                AddErrors(result);
            }

            return JsonResultEx.Create(ModelState);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
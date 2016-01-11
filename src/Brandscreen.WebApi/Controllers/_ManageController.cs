using System.Threading.Tasks;
using System.Web.Mvc;
using Brandscreen.Core.Security;
using Brandscreen.WebApi.Jsons;
using Brandscreen.WebApi.Models.Mvc.Manage;
using Microsoft.AspNet.Identity;

namespace Brandscreen.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("manage")]
    public class ManageController : Controller
    {
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly ApplicationSignInManager _applicationSignInManager;

        public ManageController(ApplicationUserManager applicationUserManager, ApplicationSignInManager applicationSignInManager)
        {
            _applicationUserManager = applicationUserManager;
            _applicationSignInManager = applicationSignInManager;
        }

        [HttpPut]
        [Route("password")]
        [ValidateJsonAntiForgeryToken]
        public async Task<ActionResult> Password(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return JsonResultEx.Create(ModelState);
            }

            var result = await _applicationUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword).ConfigureAwait(false);
            if (result.Succeeded)
            {
                var user = await _applicationUserManager.FindByIdAsync(User.Identity.GetUserId()).ConfigureAwait(false);
                if (user != null)
                {
                    await _applicationSignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false).ConfigureAwait(false);
                }
                return JsonResultEx.Create();
            }

            AddErrors(result);
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
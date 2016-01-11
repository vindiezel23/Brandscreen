using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Brandscreen.Core.Services.Memberships;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Brandscreen.Core.Security
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        private readonly Lazy<IMembershipService> _lazyMembershipService;

        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager, Lazy<IMembershipService> lazyMembershipService)
            : base(userManager, authenticationManager)
        {
            _lazyMembershipService = lazyMembershipService;
        }

        public override async Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            var claimsIdentity = await _lazyMembershipService.Value.CreateIdentity(Guid.Parse(user.Id), DefaultAuthenticationTypes.ApplicationCookie);
            return claimsIdentity;
        }
    }
}
using System;
using Microsoft.AspNet.Identity;

namespace Brandscreen.Core.Security
{
    /// <summary>
    /// Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    /// </summary>
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }

        public Guid GetApplicationId()
        {
            // hardcode the application id
            // it is original from db Brandscreen_Membership.aspnet_Applications.ApplicationId
            return Guid.Parse("29973268-ACF2-49AE-8DA9-6D93D2A459B7");
        }
    }
}
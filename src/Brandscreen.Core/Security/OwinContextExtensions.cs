using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Owin;
using Brandscreen.Entities;
using Brandscreen.Framework.Caching;
using Brandscreen.Framework.Services;
using Castle.Core.Internal;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Newtonsoft.Json;
using Repository.Pattern.Repositories;
using TimeSpan = System.TimeSpan;

namespace Brandscreen.Core.Security
{
    public static class OwinContextExtensions
    {
        public static bool IsAjaxRequest(this IOwinContext owinContext)
        {
            const string xmlHttpRequestHeader = "X-Requested-With";
            const string xmlHttpRequest = "XMLHttpRequest";
            if (owinContext?.Request?.Query?[xmlHttpRequestHeader] == xmlHttpRequest) return true;
            if (owinContext?.Request?.Headers?[xmlHttpRequestHeader] == xmlHttpRequest) return true;
            return false;
        }

        /// <summary>
        /// Gets current user's buyer roles from claims and caches the result for short period of time
        /// </summary>
        public static IEnumerable<BuyerRole> GetCurrentUserBuyerRoles(this IOwinContext owinContext)
        {
            if (owinContext?.Authentication?.User == null ||
                owinContext.Authentication.User.Claims.IsNullOrEmpty())
            {
                return Enumerable.Empty<BuyerRole>();
            }

            var user = owinContext.Authentication.User;
            var scope = owinContext.GetAutofacLifetimeScope();
            var cacheManager = scope.Resolve<ICacheManager>(TypedParameter.From(typeof (OwinContextExtensions)));
            return cacheManager.Get($"BuyerRoles-{user.Identity.GetUserId()}", context =>
            {
                context.Monitor(scope.Resolve<IClock>().When(TimeSpan.FromMinutes(1))); // cache result for one min
                var buyerRolesJsonValue = user.Claims.Single(x => x.Type == ClaimTypes.UserData && x.ValueType == ClaimValueTypes.String).Value;
                return JsonConvert.DeserializeObject<IEnumerable<BuyerRole>>(buyerRolesJsonValue);
            });
        }

        /// <summary>
        /// Gets current user
        /// </summary>
        public static Task<User> GetCurrentUser(this IOwinContext owinContext)
        {
            var userId = owinContext.GetCurrentUserId();
            var scope = owinContext.GetAutofacLifetimeScope();
            return scope.Resolve<IRepositoryAsync<User>>().FindAsync(userId);
        }

        /// <summary>
        /// Gets current user id
        /// </summary>
        public static Guid GetCurrentUserId(this IOwinContext owinContext)
        {
            var userId = owinContext.Authentication.User.Identity.GetUserId();
            return Guid.Parse(userId);
        }

        /// <summary>
        /// Gets debugging flag
        /// </summary>
        public static bool IsDebuggingEnabled(this IOwinContext owinContext)
        {
            var section = ConfigurationManager.GetSection("system.web/compilation") as System.Web.Configuration.CompilationSection;
            return section == null || section.Debug;
        }
    }

    public class BuyerRole
    {
        public int BuyerId { get; set; }
        public Guid BuyerUuid { get; set; }
        public string RoleName { get; set; }
    }
}
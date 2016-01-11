using System;
using System.Net;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Brandscreen.WebApi.Jsons
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ValidateJsonAntiForgeryToken : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null) throw new ArgumentNullException(nameof(filterContext));

            var headerToken = filterContext.HttpContext.Request.Headers["X-XSRF-Token"];
            var cookieToken = filterContext.HttpContext.Request.Cookies[AntiForgeryConfig.CookieName];
            try
            {
                AntiForgery.Validate(cookieToken?.Value, headerToken);
            }
            catch (HttpAntiForgeryException ex)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = JsonResultEx.Create(HttpStatusCode.BadRequest, ex.Message);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
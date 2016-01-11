using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Owin;

namespace Brandscreen.WebApi.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static ILifetimeScope WorkScope(this HtmlHelper htmlHelper)
        {
            var owinContext = htmlHelper.ViewContext.RequestContext.HttpContext.GetOwinContext();
            return owinContext.GetAutofacLifetimeScope();
        }

        public static IAngularHelper Angular(this HtmlHelper htmlHelper)
        {
            return htmlHelper.WorkScope().Resolve<IAngularHelper>(new TypedParameter(typeof (HtmlHelper), htmlHelper));
        }

        public static IJsonHelper Json(this HtmlHelper htmlHelper)
        {
            return htmlHelper.WorkScope().Resolve<IJsonHelper>(new TypedParameter(typeof (HtmlHelper), htmlHelper));
        }
    }
}
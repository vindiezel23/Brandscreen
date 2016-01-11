using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Brandscreen.WebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Templates",
                url: "{feature}/templates/{name}",
                defaults: new {controller = "Template", action = "Render"}
                );

            routes.MapRoute(
                name: "Angular",
                url: "{*url}",
                defaults: new {controller = "Home", action = "AngularIndex"},
                constraints: new {AngularConstraint = new AngularConstraint()}
                );

            // to move help route's position to be after angular route but before default route
            var helpRoute = routes["HelpPage_Default"];
            routes.Remove(helpRoute);
            routes.Add(helpRoute);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }

        private class AngularConstraint : IRouteConstraint
        {
            /// <summary>
            /// define a list of routes where angular should be enabled.
            /// </summary>
            private static readonly RouteCollection AngularRoutes = new RouteCollection
            {
                new Route("error", null),
                new Route("error/404", null),
                new Route("account/register", null),
                new Route("account/login", null),
                new Route("manage", null),
                new Route("manage/password", null),
                new Route("user", null),
                new Route("user/edit/{userId}", null),
                new Route("help", null),
                new Route("help/api/{apiId}", null),
                new Route("help/resourceModel", null)
            };

            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                // all ajax requests go through normally
                if (httpContext.Request.IsAjaxRequest()) return false;

                var routeData = AngularRoutes.GetRouteData(httpContext);
                return routeData != null;
            }
        }
    }
}
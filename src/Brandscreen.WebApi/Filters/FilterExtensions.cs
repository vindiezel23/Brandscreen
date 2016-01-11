using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace Brandscreen.WebApi.Filters
{
    public static class FilterExtensions
    {
        public const string MessageNotAuthorized = "You are not authorized to access this resource.";

        /// <summary>
        /// Sets Unauthorized 401 sattus code to response
        /// </summary>
        public static void SetUnauthorizedResponse(this HttpActionContext actionContext, string message = MessageNotAuthorized)
        {
            actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, message);
        }

        /// <summary>
        /// Gets query string
        /// </summary>
        public static string GetQueryString(this HttpActionContext actionContext, string name)
        {
            return actionContext.Request.RequestUri.ParseQueryString()[name];
        }

        /// <summary>
        /// Get query string and cast to specified type 
        /// </summary>
        public static T GetQueryString<T>(this HttpActionContext actionContext, string name)
        {
            var queryString = GetQueryString(actionContext, name);
            return queryString != null ? ConvertFromString<T>(queryString) : default(T);
        }

        /// <summary>
        /// Gets query string or sets with default value if empty
        /// </summary>
        public static T GetOrSetQueryString<T>(this HttpActionContext actionContext, string name, T defaultValue)
        {
            var query = actionContext.Request.RequestUri.ParseQueryString();
            var queryString = query[name];
            if (queryString != null) return ConvertFromString<T>(queryString);

            // set default value and return
            query[name] = defaultValue.ToString();
            var ub = new UriBuilder(actionContext.Request.RequestUri) {Query = query.ToString()};
            actionContext.Request.RequestUri = ub.Uri;
            return defaultValue;
        }

        /// <summary>
        /// Gets route data
        /// </summary>
        public static T GetRouteData<T>(this HttpActionContext actionContext, string name)
        {
            var obj = actionContext.RequestContext.RouteData.Values[name];
            return ConvertFromObject<T>(obj);
        }

        private static T ConvertFromString<T>(string str)
        {
            try
            {
                return (T) TypeDescriptor.GetConverter(typeof (T)).ConvertFromString(str);
            }
            catch
            {
                return default(T);
            }
        }

        private static T ConvertFromObject<T>(object obj)
        {
            try
            {
                return (T) TypeDescriptor.GetConverter(typeof (T)).ConvertFrom(obj);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
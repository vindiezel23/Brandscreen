using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Brandscreen.Framework.Environment;
using Brandscreen.WebApi.Areas.HelpPage.App_Start;
using Brandscreen.WebApi.AutofacModules;
using FluentValidation.WebApi;
using MultipartDataMediaFormatter;
using Owin;

namespace Brandscreen.WebApi
{
    /// <summary>
    /// The partial startup class holds the global http configuration instance.
    /// </summary>
    public partial class Startup
    {
        private static HttpConfiguration _httpConfiguration;

        /// <summary>
        /// Key for setting current autofac test scope in HttpConfiguration.Properties
        /// </summary>
        private const string CurrentTestScopeKey = "current_test_scope";

        /// <summary>
        /// HttpConfiguration for web api
        /// Note: not using GlobalConfiguration, but using owin to handle web api calls
        /// </summary>
        public static HttpConfiguration HttpConfiguration => _httpConfiguration ?? (_httpConfiguration = new HttpConfiguration());

        /// <summary>
        /// Sets current test autofac scope
        /// </summary>
        public static void SetCurrentTestScope(ILifetimeScope scope)
        {
            HttpConfiguration.Properties[CurrentTestScopeKey] = scope;
        }

        /// <summary>
        /// Retrieves current test autofac scope
        /// </summary>
        public static ILifetimeScope GetCurrentTestScope()
        {
            if (_httpConfiguration.Properties.ContainsKey(CurrentTestScopeKey))
            {
                return HttpConfiguration.Properties[CurrentTestScopeKey] as ILifetimeScope;
            }
            return null;
        }

        public void InitializeHttp(IHost host)
        {
            var httpConfiguration = HttpConfiguration;

            // api
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(host.LifetimeScope); // no need below two lines for IExceptionLogger and IExceptionHandler since it gets from container automatically
            //httpConfiguration.Services.Replace(typeof (IExceptionLogger), container.Resolve<IExceptionLogger>()); // logger for web api error
            //httpConfiguration.Services.Replace(typeof (IExceptionHandler), container.Resolve<IExceptionHandler>());
            httpConfiguration.Formatters.Add(new FormMultipartEncodedMediaTypeFormatter()); // support multipart/form-data model binding such as file upload
            FluentValidationModelValidatorProvider.Configure(httpConfiguration, provider => provider.ValidatorFactory = new FluentValidationValidatorFactory(host.LifetimeScope)); // fluent validation support
            WebApiConfig.Register(httpConfiguration);

            // mvc
            if (HttpContext.Current != null) // Note: only enable mvc when hosting in IIS
            {
                DependencyResolver.SetResolver(new AutofacDependencyResolver(host.LifetimeScope));
                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                HelpPageConfig.Register(httpConfiguration); // web api help page
            }

            httpConfiguration.EnsureInitialized();
        }
    }
}
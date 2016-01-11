using System.Web;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Brandscreen.Framework.Environment.AutofacUtil;

namespace Brandscreen.WebApi.AutofacModules
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // assemblies
            var assemblies = AutofacAssemblyStore.GetAssemblies();

            // ------------------WebApi------------------
            // REF: http://docs.autofac.org/en/latest/integration/webapi.html

            // Get your HttpConfiguration.
            var config = Startup.HttpConfiguration;
            builder.RegisterInstance(config);

            // Register your Web API controllers.
            builder.RegisterApiControllers(assemblies).EnableClassInterceptors();

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // ------------------MVC------------------
            // REF: http://docs.autofac.org/en/latest/integration/mvc.html

            if (HttpContext.Current == null) return; // Note: only enable mvc when hosting in IIS
            
            // Register your MVC controllers.
            builder.RegisterControllers(assemblies).EnableClassInterceptors();

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(assemblies);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();
        }
    }
}
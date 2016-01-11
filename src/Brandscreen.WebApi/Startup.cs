using System;
using System.Reflection;
using Autofac;
using Brandscreen.Framework.Environment;
using Brandscreen.Framework.Environment.AutofacUtil;
using Brandscreen.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.BuilderProperties;
using Microsoft.Owin.Logging;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace Brandscreen.WebApi
{
    public partial class Startup
    {
        private static IHost _host;

        public void Configuration(IAppBuilder app)
        {
            // register assemblies
            AutofacAssemblyStore.LoadAssembly("Brandscreen.Framework");
            AutofacAssemblyStore.LoadAssembly("Brandscreen.Core");
            AutofacAssemblyStore.LoadAssembly(Assembly.GetExecutingAssembly());

            // create and activate host
            _host = HostStarter.CreateHost();
            _host.Activate(); // Note: HostEventsHandler will be called

            // ensure http configuration
            InitializeHttp(_host);

            // setting logger factory so it can do logging via NLog
            app.SetLoggerFactory(_host.LifetimeScope.Resolve<ILoggerFactory>());

            // handling begin and end request events
            app.Use(async (context, next) =>
            {
                _host.BeginRequest(); // begin request

                try
                {
                    await next();
                }
                catch (OperationCanceledException ex)
                {
                    var logger = app.CreateLogger(GetType());
                    logger.WriteWarning(ex.Message);
                }
                catch (Exception ex)
                {
                    var logger = app.CreateLogger(GetType());
                    logger.WriteError("owin error", ex);
                    throw;
                }
                finally
                {
                    _host.EndRequest(); // end request
                }
            });

            // handling application end event
            var properties = new AppProperties(app.Properties);
            properties.OnAppDisposing.Register(() => _host.Terminate()); // end app

            // setup autofac middleware
            app.UseAutofacMiddleware(_host.LifetimeScope); // IOwinContext is registered by autofac when calling this

            // setup
            ConfigureMvc(app, _host);
            ConfigureApi(app, _host);
        }
    }
}
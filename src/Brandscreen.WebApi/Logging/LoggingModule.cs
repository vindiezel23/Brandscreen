using System.Web.Http.ExceptionHandling;
using Autofac;
using Microsoft.Owin.Logging;

namespace Brandscreen.WebApi.Logging
{
    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CastleToOwinFactoryAdapter>()
                .As<ILoggerFactory>()
                .SingleInstance()
                .AutoActivate();

#if !DEBUG // only enables in non-debug environment for giving friendly message when error occurs
            builder.RegisterType<WebApiExceptionHandler>()
                .As<IExceptionHandler>()
                .SingleInstance();
#endif

            builder.RegisterType<WebApiExceptionLogger>()
                .As<IExceptionLogger>()
                .SingleInstance();
        }
    }
}
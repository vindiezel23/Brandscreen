using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Castle.Core.Logging;
using Castle.Services.Logging.NLogIntegration;

namespace Brandscreen.Framework.Logging
{
    internal class LoggingFactoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // by default, use NLog's logger that delegates to Castle's logger factory
            builder.RegisterType<NLogFactory>()
                .As<ILoggerFactory>()
                //.WithParameter(new TypedParameter(typeof (string), AppDomain.CurrentDomain.SetupInformation.ConfigurationFile))
                .SingleInstance()
                .AutoActivate();

            // call CreateLogger in response to the request for an ILogger implementation
            builder.Register(CreateLogger).As<ILogger>().InstancePerDependency();
        }

        private static ILogger CreateLogger(IComponentContext context, IEnumerable<Parameter> parameters)
        {
            // return an ILogger in response to Resolve<ILogger>(componentTypeParameter)
            var loggerFactory = context.Resolve<ILoggerFactory>();
            var containingType = parameters.TypedAs<Type>();
            return loggerFactory.Create(containingType);
        }
    }
}
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using Module = Autofac.Module;

namespace Brandscreen.Framework.Logging
{
    public class LoggingModule : Module
    {
        private readonly ConcurrentDictionary<string, ILogger> _loggerCache;

        public LoggingModule()
        {
            _loggerCache = new ConcurrentDictionary<string, ILogger>();
        }

        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            var implementationType = registration.Activator.LimitType;

            // build an array of actions on this type to assign loggers to member properties
            var injectors = BuildLoggerInjectors(implementationType).ToArray();

            // if there are no logger properties, there's no reason to hook the activated event
            if (!injectors.Any())
                return;

            // otherwise, whan an instance of this component is activated, inject the loggers on the instance
            registration.Activated += (s, e) =>
            {
                foreach (var injector in injectors)
                    injector(e.Context, e.Instance);
            };
        }

        private IEnumerable<Action<IComponentContext, object>> BuildLoggerInjectors(Type componentType)
        {
            // Look for settable properties of type "ILogger" 
            var loggerProperties = componentType
                .GetProperties(BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance)
                .Select(p => new
                {
                    PropertyInfo = p,
                    p.PropertyType,
                    IndexParameters = p.GetIndexParameters(),
                    Accessors = p.GetAccessors(false)
                })
                .Where(x => x.PropertyType == typeof (ILogger)) // must be a logger
                .Where(x => x.IndexParameters.Count() == 0) // must not be an indexer
                .Where(x => x.Accessors.Length != 1 || x.Accessors[0].ReturnType == typeof (void)); //must have get/set, or only set

            // Return an array of actions that resolve a logger and assign the property
            foreach (var entry in loggerProperties)
            {
                var propertyInfo = entry.PropertyInfo;

                yield return (ctx, instance) =>
                {
                    string component = componentType.ToString();
                    var logger = _loggerCache.GetOrAdd(component, key => ctx.Resolve<ILogger>(new TypedParameter(typeof (Type), componentType)));
                    // propertyInfo.SetValue(instance, logger, null);
                    propertyInfo.SetValue(ProxyUtil.IsProxy(instance) ? ProxyUtil.GetUnproxiedInstance(instance) : instance, logger, null);
                };
            }
        }
    }
}
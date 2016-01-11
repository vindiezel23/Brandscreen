using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy2;
using Autofac.Features.OwnedInstances;
using Brandscreen.Framework.Environment.AutofacUtil;
using Brandscreen.Framework.Events;
using Castle.Core.Logging;

namespace Brandscreen.Framework.Environment
{
    public interface IHost : IDisposable
    {
        ILifetimeScope LifetimeScope { get; }
        void Activate();
        void Terminate();
        void BeginRequest();
        void EndRequest();
    }

    public class DefaultHost : IHost
    {
        private readonly ILifetimeScope _rootLifetimeScope;
        private readonly ILifetimeScope _siteLifetimeScope;
        private readonly Owned<IHostEvents> _hostEvents;

        private bool _disposed;

        public DefaultHost(ILifetimeScope rootLifetimeScope)
        {
            _rootLifetimeScope = rootLifetimeScope;

            var intermediateScope = _rootLifetimeScope.BeginLifetimeScope(builder =>
            {
                // assemblies
                var assemblies = AutofacAssemblyStore.GetAssemblies();

                // all modules: internal class module will NOT be picked up
                foreach (var item in assemblies.SelectMany(a => a.ExportedTypes).Where(t => typeof (IModule).IsAssignableFrom(t)))
                {
                    builder.RegisterType(item)
                        .As<IModule>()
                        .InstancePerDependency();
                }
            });

            _siteLifetimeScope = intermediateScope.BeginLifetimeScope(AutofacScope.Site, builder =>
            {
                // assemblies
                var assemblies = AutofacAssemblyStore.GetAssemblies();

                // modules
                foreach (var item in intermediateScope.Resolve<IEnumerable<IModule>>())
                {
                    builder.RegisterModule(item);
                }

                // dependencies
                builder.RegisterAssemblyTypes(assemblies)
                    .Where(t => typeof (IDependency).IsAssignableFrom(t) &&
                                !typeof (ISingletonDependency).IsAssignableFrom(t) &&
                                !typeof (IUnitOfWorkDependency).IsAssignableFrom(t) &&
                                !typeof (ITransientDependency).IsAssignableFrom(t) &&
                                !typeof (IEventHandler).IsAssignableFrom(t))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope()
                    .EnableInterfaceInterceptors();
                builder.RegisterAssemblyTypes(assemblies)
                    .Where(t => typeof (ISingletonDependency).IsAssignableFrom(t) && !typeof (IEventHandler).IsAssignableFrom(t))
                    .AsImplementedInterfaces()
                    .InstancePerMatchingLifetimeScope(AutofacScope.Site)
                    .EnableInterfaceInterceptors();
                builder.RegisterAssemblyTypes(assemblies)
                    .Where(t => typeof (IUnitOfWorkDependency).IsAssignableFrom(t) && !typeof (IEventHandler).IsAssignableFrom(t))
                    .AsImplementedInterfaces()
                    .InstancePerMatchingLifetimeScope(AutofacScope.Work)
                    .EnableInterfaceInterceptors();
                builder.RegisterAssemblyTypes(assemblies)
                    .Where(t => typeof (ITransientDependency).IsAssignableFrom(t) && !typeof (IEventHandler).IsAssignableFrom(t))
                    .AsImplementedInterfaces()
                    .InstancePerDependency()
                    .EnableInterfaceInterceptors();

                // event handlers
                builder.RegisterAssemblyTypes(assemblies)
                    .Where(t => typeof (IEventHandler).IsAssignableFrom(t))
                    .ActivatorData.ConfigurationActions.Add((type, registrationBuilder) =>
                    {
                        var interfaceTypes = type.GetInterfaces();
                        foreach (var interfaceType in interfaceTypes)
                        {
                            if (interfaceType.GetInterface(typeof (IEventHandler).Name) != null)
                            {
                                // register named instance for each interface, for efficient filtering inside event bus
                                // IEventHandler derived classes only
                                registrationBuilder.Named<IEventHandler>(interfaceType.Name);
                            }
                        }
                        registrationBuilder.InstancePerLifetimeScope();
                    });
            });

            _hostEvents = _siteLifetimeScope.Resolve<Owned<IHostEvents>>();

            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public ILifetimeScope LifetimeScope
        {
            get { return _siteLifetimeScope; }
        }

        public void Activate()
        {
            Logger.Info("Activating...");

            // events
            _hostEvents.Value.Activated(_siteLifetimeScope);

            Logger.Info("Activated");
        }

        public void Terminate()
        {
            Logger.Info("Terminating...");

            // events
            SafelyTerminate(() => { SafelyTerminate(() => _hostEvents.Value.Terminating()); });

            // release resouce
            Dispose();

            Logger.Info("Terminated");
        }

        public void BeginRequest()
        {
            // called each time a request begins to offer a just-in-time reinitialization point
        }

        public void EndRequest()
        {
            // called each time a request ends to deterministically commit and dispose outstanding activity
        }

        private void SafelyTerminate(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Logger.Error("An unexcepted error occured while terminating the Shell", e);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _hostEvents.Dispose();
                _siteLifetimeScope.Dispose();
                _rootLifetimeScope.Dispose();
            }
            _disposed = true;
        }
    }
}
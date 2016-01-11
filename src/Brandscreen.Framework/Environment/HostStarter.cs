using Autofac;
using Brandscreen.Framework.Caching;
using Brandscreen.Framework.Environment.AutofacUtil;
using Brandscreen.Framework.Events;
using Brandscreen.Framework.Exceptions;
using Brandscreen.Framework.Logging;
using Brandscreen.Framework.Services;
using Brandscreen.Framework.Settings;

namespace Brandscreen.Framework.Environment
{
    public static class HostStarter
    {
        public static IContainer CreateHostContainer()
        {
            var builder = new ContainerBuilder();

            // assemblies
            var assemblies = AutofacAssemblyStore.GetAssemblies();

            // startable
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(IStartable).IsAssignableFrom(t))
                .As<IStartable>()
                .SingleInstance();

            // modules
            builder.RegisterModule(new LoggingFactoryModule());
            builder.RegisterModule(new LoggingModule());
            builder.RegisterModule(new EventsModule());
            builder.RegisterModule(new CacheModule());
            builder.RegisterModule(new SettingModule());

            // event bus
            builder.RegisterType<DefaultEventBus>().As<IEventBus>().SingleInstance();
            builder.RegisterType<DefaultExceptionPolicy>().As<IExceptionPolicy>().SingleInstance();

            // cache
            builder.RegisterType<DefaultCacheHolder>().As<ICacheHolder>().SingleInstance();
            builder.RegisterType<DefaultCacheContextAccessor>().As<ICacheContextAccessor>().SingleInstance();
            builder.RegisterType<DefaultParallelCacheContext>().As<IParallelCacheContext>().SingleInstance();
            builder.RegisterType<DefaultAsyncTokenProvider>().As<IAsyncTokenProvider>().SingleInstance();

            // volatile providers
            RegisterVolatileProvider<Clock, IClock>(builder);

            // assembly resolvers
            builder.RegisterType<DefaultAssemblyLoader>().As<IAssemblyLoader>().SingleInstance();
            builder.RegisterType<AppDomainAssemblyNameResolver>().As<IAssemblyNameResolver>().SingleInstance();
            builder.RegisterType<GacAssemblyNameResolver>().As<IAssemblyNameResolver>().SingleInstance();
            builder.RegisterType<FrameworkAssemblyNameResolver>().As<IAssemblyNameResolver>().SingleInstance();

            //
            builder.RegisterType<DefaultHost>().As<IHost>().SingleInstance().ExternallyOwned(); // manually dispose

            var container = builder.Build();

            return container;
        }

        private static void RegisterVolatileProvider<TRegister, TService>(ContainerBuilder builder) where TService : IVolatileProvider
        {
            builder.RegisterType<TRegister>()
                .As<TService>()
                .As<IVolatileProvider>()
                .SingleInstance();
        }

        public static IHost CreateHost()
        {
            var container = CreateHostContainer();
            return container.Resolve<IHost>();
        }
    }
}
using Autofac;
using Brandscreen.Analytics.Entities;
using Brandscreen.Entities;
using Brandscreen.Framework.Caching;
using Brandscreen.WebApi.Mappings;
using Castle.Components.DictionaryAdapter;
using Repository.Pattern.UnitOfWork;

namespace Brandscreen.WebApi.Tests
{
    public class UnitTestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // auto mapper
            builder.RegisterModule(new AutoMapperModule());

            // cache
            builder.RegisterModule(new CacheModule());
            builder.RegisterType<DefaultCacheHolder>().As<ICacheHolder>().SingleInstance();
            builder.RegisterType<DefaultCacheContextAccessor>().As<ICacheContextAccessor>().SingleInstance();
            builder.RegisterType<DefaultParallelCacheContext>().As<IParallelCacheContext>().SingleInstance();
            builder.RegisterType<DefaultAsyncTokenProvider>().As<IAsyncTokenProvider>().SingleInstance();

            // dictionary adapter
            builder.RegisterType<DictionaryAdapterFactory>().As<IDictionaryAdapterFactory>().SingleInstance();

            // unit of work
            // below registration helps generate a mocking UnitOfWork object via IIndex<Type, IUnitOfWorkAsync>
            builder.Register(context => context.Resolve<IUnitOfWorkAsync>()) // here providing a mock object
                .Named<IUnitOfWorkAsync>(typeof (BrandscreenContext).Namespace)
                .Named<IUnitOfWorkAsync>(typeof (BrandscreenAnalyticsContext).Namespace)
                .Keyed<IUnitOfWorkAsync>(typeof (IBrandscreenContext))
                .Keyed<IUnitOfWorkAsync>(typeof (IBrandscreenAnalyticsContext))
                .InstancePerLifetimeScope();
        }
    }
}
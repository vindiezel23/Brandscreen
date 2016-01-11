using System.Data.Entity;
using System.Linq;
using Autofac;
using Autofac.Core;
using Brandscreen.Analytics.Entities;
using Brandscreen.Core.Security;
using Brandscreen.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;

namespace Brandscreen.WebApi.AutofacModules
{
    /// <summary>
    /// This module similar to RepositoryModule, but it uses test scope to resolve instance.
    /// </summary>
    public class RepositoryTestModule : Module
    {
        private readonly string _brandscreenContextNamespace;
        private readonly string _brandscreenAnalyticsContextNamespace;

        public RepositoryTestModule()
        {
            _brandscreenContextNamespace = typeof (BrandscreenContext).Namespace;
            _brandscreenAnalyticsContextNamespace = typeof (BrandscreenAnalyticsContext).Namespace;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // only activate this module when test scope is set
            if (Startup.GetCurrentTestScope() == null) return;

            // Note: everytime resolving database context objects need to get current test scope so it will be the same instance as the one in 
            // current running test case. Also mark it as external owned as test autofac container is responsible for disposing these objects.

            builder.Register(context => Startup.GetCurrentTestScope().ResolveNamed<DbContext>("membership"))
                .Named<DbContext>("membership")
                .InstancePerLifetimeScope()
                .ExternallyOwned();

            builder.Register(context => Startup.GetCurrentTestScope().Resolve<BrandscreenContext>())
                .As<IDataContextAsync, IBrandscreenContext>()
                .AsSelf()
                .Named<IDataContextAsync>(_brandscreenContextNamespace)
                .InstancePerLifetimeScope()
                .ExternallyOwned();

            builder.Register(context => Startup.GetCurrentTestScope().Resolve<BrandscreenAnalyticsContext>())
                .As<IDataContextAsync, IBrandscreenAnalyticsContext>()
                .AsSelf()
                .Named<IDataContextAsync>(_brandscreenAnalyticsContextNamespace)
                .InstancePerLifetimeScope()
                .ExternallyOwned();

            builder.Register(context => Startup.GetCurrentTestScope().ResolveNamed<IUnitOfWorkAsync>(_brandscreenContextNamespace))
                .As<IUnitOfWorkAsync>()
                .Named<IUnitOfWorkAsync>(_brandscreenContextNamespace)
                .Keyed<IUnitOfWorkAsync>(typeof (IBrandscreenContext))
                .InstancePerLifetimeScope()
                .ExternallyOwned();

            builder.Register(context => Startup.GetCurrentTestScope().ResolveNamed<IUnitOfWorkAsync>(_brandscreenAnalyticsContextNamespace))
                .As<IUnitOfWorkAsync>()
                .Named<IUnitOfWorkAsync>(_brandscreenAnalyticsContextNamespace)
                .Keyed<IUnitOfWorkAsync>(typeof (IBrandscreenAnalyticsContext))
                .InstancePerLifetimeScope()
                .ExternallyOwned();

            builder.RegisterGeneric(typeof (Repository<>))
                .As(typeof (IRepositoryAsync<>))
                .OnPreparing(args =>
                {
                    // supplys differenct context object parameter for constructing repository object basing on its namespace
                    var entityNamespace = args.Component.Activator.LimitType.GetGenericArguments()[0].Namespace;

                    // brandscreen context
                    if (_brandscreenContextNamespace == entityNamespace)
                    {
                        var contextParameter = ResolvedParameter.ForNamed<IDataContextAsync>(_brandscreenContextNamespace);
                        var unitOfWorkParameter = ResolvedParameter.ForNamed<IUnitOfWorkAsync>(_brandscreenContextNamespace);
                        args.Parameters = args.Parameters.Concat(new[] {contextParameter, unitOfWorkParameter});
                    }

                    // brandscreen analytics context
                    if (_brandscreenAnalyticsContextNamespace == entityNamespace)
                    {
                        var contextParameter = ResolvedParameter.ForNamed<IDataContextAsync>(_brandscreenAnalyticsContextNamespace);
                        var unitOfWorkParameter = ResolvedParameter.ForNamed<IUnitOfWorkAsync>(_brandscreenAnalyticsContextNamespace);
                        args.Parameters = args.Parameters.Concat(new[] {contextParameter, unitOfWorkParameter});
                    }
                })
                .InstancePerLifetimeScope();
        }
    }
}
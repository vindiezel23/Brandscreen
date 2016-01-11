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
    /// This module enables automatically resolving repository in multiple database contexts
    /// </summary>
    public class RepositoryModule : Module
    {
        private readonly string _brandscreenContextNamespace;
        private readonly string _brandscreenAnalyticsContextNamespace;

        public RepositoryModule()
        {
            _brandscreenContextNamespace = typeof (BrandscreenContext).Namespace;
            _brandscreenAnalyticsContextNamespace = typeof (BrandscreenAnalyticsContext).Namespace;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // only activate this module when there is no test scope
            // please refer to RepositoryTestModule when the value is set
            if (Startup.GetCurrentTestScope() != null) return;

            // depend by UserStore<ApplicationUser> and RoleStore<IdentityRole> at SecurityModule
            builder.RegisterType<IdentityDbContext<ApplicationUser>>()
                .WithParameters(new[]
                {
                    new NamedParameter("nameOrConnectionString", "BrandscreenMembershipContext"),
                    new NamedParameter("throwIfV1Schema", false)
                })
                .Named<DbContext>("membership")
                .InstancePerLifetimeScope();

            // marks db context as externally owned so that autofac won't dispose it
            // db context will get disposed when unit of work is disposing

            builder.RegisterType<BrandscreenContext>()
                .As<IDataContextAsync, IBrandscreenContext>()
                .AsSelf()
                .Named<IDataContextAsync>(_brandscreenContextNamespace)
                .InstancePerLifetimeScope()
                .ExternallyOwned();

            builder.RegisterType<BrandscreenAnalyticsContext>()
                .As<IDataContextAsync, IBrandscreenAnalyticsContext>()
                .AsSelf()
                .Named<IDataContextAsync>(_brandscreenAnalyticsContextNamespace)
                .InstancePerLifetimeScope()
                .ExternallyOwned();

            builder.RegisterType<UnitOfWork>()
                .WithParameter(ResolvedParameter.ForNamed<IDataContextAsync>(_brandscreenContextNamespace))
                .As<IUnitOfWorkAsync>()
                .Named<IUnitOfWorkAsync>(_brandscreenContextNamespace)
                .Keyed<IUnitOfWorkAsync>(typeof (IBrandscreenContext))
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .WithParameter(ResolvedParameter.ForNamed<IDataContextAsync>(_brandscreenAnalyticsContextNamespace))
                .As<IUnitOfWorkAsync>()
                .Named<IUnitOfWorkAsync>(_brandscreenAnalyticsContextNamespace)
                .Keyed<IUnitOfWorkAsync>(typeof (IBrandscreenAnalyticsContext))
                .InstancePerLifetimeScope();

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
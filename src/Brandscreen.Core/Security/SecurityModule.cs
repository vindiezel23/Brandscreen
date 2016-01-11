using System.Data.Entity;
using Autofac;
using Autofac.Core;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;

namespace Brandscreen.Core.Security
{
    public class SecurityModule : Module
    {
        public const string AppName = "Brandscreen";

        protected override void Load(ContainerBuilder builder)
        {
            // depend by UserStore<ApplicationUser>
            // registration of IdentityDbContext<ApplicationUser> has been moved to RepositoryModule: membership DbContext

            // depend by ApplicationUserManager
            builder.RegisterType<UserStore<ApplicationUser>>()
                .WithParameter(ResolvedParameter.ForNamed<DbContext>("membership"))
                .As<IUserStore<ApplicationUser>>()
                .InstancePerLifetimeScope();

            // depend by ApplicationRoleManager
            builder.RegisterType<RoleStore<IdentityRole>>()
                .WithParameter(ResolvedParameter.ForNamed<DbContext>("membership"))
                .As<IRoleStore<IdentityRole, string>>()
                .InstancePerLifetimeScope();

            // depend by ApplicationUserManager
            builder.RegisterType<UserValidator<ApplicationUser>>()
                .As<IIdentityValidator<ApplicationUser>>()
                .InstancePerLifetimeScope()
                .OnActivating(args =>
                {
                    args.Instance.AllowOnlyAlphanumericUserNames = false;
                    args.Instance.RequireUniqueEmail = true;
                });

            // depend by IDataProtector
            builder.RegisterType<IdentityFactoryOptions<ApplicationUserManager>>()
                .AsSelf()
                .InstancePerLifetimeScope()
                .OnActivating(args => { args.Instance.DataProtectionProvider = new DpapiDataProtectionProvider(AppName); });

            // depend by DataProtectorTokenProvider
            builder.Register(context => context.Resolve<IdentityFactoryOptions<ApplicationUserManager>>().DataProtectionProvider.Create("ASP.NET Identity"))
                .As<IDataProtector>()
                .InstancePerLifetimeScope();

            // depend by ApplicationUserManager
            builder.RegisterType<DataProtectorTokenProvider<ApplicationUser>>()
                .As<IUserTokenProvider<ApplicationUser, string>>()
                .InstancePerLifetimeScope();

            // depend by ApplicationUserManager
            builder.RegisterType<PasswordValidator>()
                .As<IIdentityValidator<string>>()
                .OnActivating(args =>
                {
                    args.Instance.RequiredLength = 8;
                    args.Instance.RequireNonLetterOrDigit = false;
                    args.Instance.RequireDigit = false;
                    args.Instance.RequireLowercase = false;
                    args.Instance.RequireUppercase = false;
                })
                .SingleInstance();

            // depend by ApplicationUserManager
            builder.RegisterType<SqlPasswordHasher>()
                .As<IPasswordHasher>()
                .SingleInstance();

            builder.RegisterType<ApplicationUserManager>()
                .AsSelf()
                .InstancePerLifetimeScope()
                .OnActivating(args =>
                {
                    // Configure validation logic for usernames
                    args.Instance.UserValidator = args.Context.Resolve<IIdentityValidator<ApplicationUser>>(TypedParameter.From((UserManager<ApplicationUser, string>) args.Instance));

                    // Configure validation logic for passwords
                    args.Instance.PasswordValidator = args.Context.Resolve<IIdentityValidator<string>>();

                    // Configure hasherc for passwords
                    args.Instance.PasswordHasher = args.Context.Resolve<IPasswordHasher>();

                    // Configure user token provider
                    args.Instance.UserTokenProvider = args.Context.Resolve<IUserTokenProvider<ApplicationUser, string>>();
                });

            builder.Register(context => context.Resolve<IOwinContext>().Authentication)
                .As<IAuthenticationManager>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationRoleManager>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationSignInManager>()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
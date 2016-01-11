using System;
using System.Web;
using System.Web.Http;
using Autofac;
using Brandscreen.Core.Security;
using Brandscreen.Core.Security.Provides;
using Brandscreen.Core.Settings;
using Brandscreen.Framework.Environment;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace Brandscreen.WebApi
{
    /// <summary>
    /// The partial startup class contains web owin configurations.
    /// </summary>
    public partial class Startup
    {
        private static readonly PathString ApiTokenPath = new PathString("/token");
        private static readonly PathString ApiPath = new PathString("/api");

        public void ConfigureMvc(IAppBuilder app, IHost host)
        {
            var securitySettings = _host.LifetimeScope.Resolve<ISecuritySettings>();
            var cookieAuthenticationOptions = new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString(securitySettings.LoginPath),
                Provider = new CookieAuthenticationProvider
                {
                    OnApplyRedirect = context =>
                    {
                        // enforce to return 401 for ajax calls
                        // otherwise it returns 200 with X-Responded-JSON header
                        if (!context.OwinContext.IsAjaxRequest())
                        {
                            context.Response.Redirect(context.RedirectUri);
                        }
                    }
                }
            };

            // Note: only enable mvc when hosting in IIS
            if (HttpContext.Current != null)
            {
                app.MapWhen(context => !IsApiPath(context.Request.Path), innerApp =>
                {
                    // auth
                    // Enable the application to use a cookie to store information for the signed in user
                    // and to use a cookie to temporarily store information about a user logging in with a third party login provider
                    innerApp.UseCookieAuthentication(cookieAuthenticationOptions);
                    //innerApp.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

                    // mvc
                    innerApp.UseAutofacMvc();
                });
            }
        }

        public void ConfigureApi(IAppBuilder app, IHost host)
        {
            var securitySettings = _host.LifetimeScope.Resolve<ISecuritySettings>();

            var oAuthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true, // note: use http because there is proxy server in frond of the web server to do https
                TokenEndpointPath = new PathString(securitySettings.TokenEndpointPath),
                //AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                Provider = new ApplicationOAuthProvider(securitySettings.PublicClientId),
                RefreshTokenProvider = new ApplicationRefreshTokenProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                AccessTokenFormat = new JwtTokenFormat(securitySettings),
            };

            var jwtBearerAuthenticationOptions = new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] {securitySettings.AudienceId},
                IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                {
                    new SymmetricKeyIssuerSecurityTokenProvider(securitySettings.Issuer, securitySettings.AudienceSecret)
                }
            };

            // note: using MapWhen will not change PathBase, but Map does change it.
            // we don't want PathBase changed because it involves route configs changes.
            app.MapWhen(context => IsApiPath(context.Request.Path), innerApp => // api path only
            {
                // CORS - enable cross domain requests
                innerApp.UseCors(CorsOptions.AllowAll);

                // auth
                innerApp.UseOAuthAuthorizationServer(oAuthOptions);

                // jwt token
                innerApp.UseJwtBearerAuthentication(jwtBearerAuthenticationOptions);

                // api
                var config = _host.LifetimeScope.Resolve<HttpConfiguration>();
                innerApp.UseAutofacWebApi(config);
                innerApp.UseWebApi(config);
            });
        }

        private static bool IsApiPath(PathString path)
        {
            return path.StartsWithSegments(ApiTokenPath) || path.StartsWithSegments(ApiPath);
        }
    }
}
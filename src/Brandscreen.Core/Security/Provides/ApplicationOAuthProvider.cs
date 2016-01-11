using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Owin;
using Brandscreen.Core.Services.Memberships;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace Brandscreen.Core.Security.Provides
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException(nameof(publicClientId));
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var scope = context.OwinContext.GetAutofacLifetimeScope();

            // application user
            var membershipService = scope.Resolve<IMembershipService>();
            var applicationUser = await membershipService.GetUser(context.UserName, context.Password).ConfigureAwait(false);
            if (applicationUser == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            // ticket
            var ticket = await GenerateAuthenticationTicket(context.OwinContext, Guid.Parse(applicationUser.Id), applicationUser.UserName).ConfigureAwait(false);
            context.Validated(ticket);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.CompletedTask;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            // validate client id: allowing empty client id by default
            if (context.ClientId == null || context.ClientId == _publicClientId)
            {
                context.OwinContext.Set("as:client_id", clientId ?? _publicClientId);
                context.Validated();
                return Task.CompletedTask;
            }

            context.SetError("invalid_clientId", "Client id is invalid.");
            return Task.CompletedTask;
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.CompletedTask;
        }

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.OwinContext.Get<string>("as:client_id");

            // enforce client binding of refresh token
            if (originalClient != currentClient)
            {
                context.Rejected();
            }

            // ticket
            var userName = context.Ticket.Properties.Dictionary["userName"];
            var scope = context.OwinContext.GetAutofacLifetimeScope();
            var membershipService = scope.Resolve<IMembershipService>();
            var applicationUser = await membershipService.GetUser(userName).ConfigureAwait(false);
            var newTicket = await GenerateAuthenticationTicket(context.OwinContext, Guid.Parse(applicationUser.Id), applicationUser.UserName).ConfigureAwait(false);
            context.Validated(newTicket);
        }

        private static async Task<AuthenticationTicket> GenerateAuthenticationTicket(IOwinContext context, Guid userId, string userName)
        {
            var scope = context.GetAutofacLifetimeScope();

            // identity
            var membershipService = scope.Resolve<IMembershipService>();
            var oAuthIdentity = await membershipService.CreateIdentity(userId, OAuthDefaults.AuthenticationType).ConfigureAwait(false);

            // ticket
            var properties = new AuthenticationProperties(new Dictionary<string, string>
            {
                {"userName", userName},
                {"as:client_id", context.Get<string>("as:client_id")}
            });
            var ticket = new AuthenticationTicket(oAuthIdentity, properties);
            return ticket;
        }
    }
}
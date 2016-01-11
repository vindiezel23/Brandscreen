using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;

namespace Brandscreen.Core.Security.Provides
{
    public class ApplicationRefreshTokenProvider : IAuthenticationTokenProvider
    {
        private static readonly ConcurrentDictionary<string, AuthenticationTicket> RefreshTokens = new ConcurrentDictionary<string, AuthenticationTicket>();

        public void Create(AuthenticationTokenCreateContext context)
        {
        }

        public Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            // generate a new refresh token and save in memory
            var tokenValue = GetHash(Guid.NewGuid().ToString("N"));
            RefreshTokens.TryAdd(tokenValue, context.Ticket);
            context.SetToken(tokenValue);

            return Task.CompletedTask;
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
        }

        public Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            // remove saved refresh token and recall the ticket in context
            AuthenticationTicket ticket;
            if (RefreshTokens.TryRemove(context.Token, out ticket))
            {
                context.SetTicket(ticket);
            }

            return Task.CompletedTask;
        }

        private static string GetHash(string input)
        {
            using (HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider())
            {
                var byteValue = System.Text.Encoding.UTF8.GetBytes(input);
                var byteHash = hashAlgorithm.ComputeHash(byteValue);
                return Convert.ToBase64String(byteHash);
            }
        }
    }
}
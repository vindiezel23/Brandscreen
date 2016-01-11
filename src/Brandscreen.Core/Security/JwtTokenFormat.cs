using System;
using System.IdentityModel.Tokens;
using Brandscreen.Core.Settings;
using IdentityModel.Tokens;
using Microsoft.Owin.Security;

namespace Brandscreen.Core.Security
{
    public class JwtTokenFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly ISecuritySettings _securitySettings;

        public JwtTokenFormat(ISecuritySettings securitySettings)
        {
            _securitySettings = securitySettings;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var signingKey = new HmacSigningCredentials(_securitySettings.AudienceSecret);
            var token = new JwtSecurityToken(_securitySettings.Issuer, _securitySettings.AudienceId, data.Identity.Claims, data.Properties.IssuedUtc?.UtcDateTime, data.Properties.ExpiresUtc?.UtcDateTime, signingKey);
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.WriteToken(token);
            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}
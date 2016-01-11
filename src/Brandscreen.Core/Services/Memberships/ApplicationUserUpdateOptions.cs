using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Brandscreen.Core.Services.Memberships
{
    public class ApplicationUserUpdateOptions
    {
        public Guid UserId { get; set; }

        public string Password { get; set; }
        public IList<string> Roles { get; set; }
        public IList<Claim> Claims { get; set; }
    }
}
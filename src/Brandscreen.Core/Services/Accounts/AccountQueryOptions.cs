using System;

namespace Brandscreen.Core.Services.Accounts
{
    public class AccountQueryOptions : QueryOptions
    {
        public Guid? UserId { get; set; }
    }
}
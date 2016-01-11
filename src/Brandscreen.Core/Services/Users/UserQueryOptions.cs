using System.Collections.Generic;

namespace Brandscreen.Core.Services.Users
{
    public class UserQueryOptions : QueryOptions
    {
        public UserQueryOptions()
        {
            BuyerAccountIds = new List<int>();
        }

        /// <summary>
        /// Filter by UserBuyerRole
        /// </summary>
        public List<int> BuyerAccountIds { get; private set; }

        public string Email { get; set; }
    }
}
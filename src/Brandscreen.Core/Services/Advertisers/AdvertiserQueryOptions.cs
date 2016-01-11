using System;
using System.Collections.Generic;

namespace Brandscreen.Core.Services.Advertisers
{
    public class AdvertiserQueryOptions : QueryOptions
    {
        public AdvertiserQueryOptions()
        {
            BuyerAccountIds = new List<int>();
            UserIds = new List<Guid>();
        }

        /// <summary>
        /// Filter by Advertiser.BuyerAccountId
        /// </summary>
        /// <remarks> 
        /// If user is AgencyAdministrator of a BuyerAccount, should use this match.
        /// </remarks>
        public List<int> BuyerAccountIds { get; private set; }

        /// <summary>
        /// Filter by matching user in Advertiser.UserAdvertiserRoles
        /// </summary>
        /// <remarks> 
        /// if user is AgencyUser of a BuyerAccount, should use this match.
        /// </remarks>
        public List<Guid> UserIds { get; set; }
    }
}
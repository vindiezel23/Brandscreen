using System.Collections.Generic;

namespace Brandscreen.Core.Services.Deals
{
    public class DealQueryOptions : QueryOptions
    {
        public DealQueryOptions()
        {
            BuyerAccountIds = new List<int>();
        }

        /// <summary>
        /// Filter by Deal.BuyerAccountId
        /// </summary>
        public List<int> BuyerAccountIds { get; private set; }
    }
}
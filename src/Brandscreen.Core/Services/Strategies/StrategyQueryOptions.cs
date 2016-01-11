using System;
using Brandscreen.Core.Services.Campaigns;

namespace Brandscreen.Core.Services.Strategies
{
    public class StrategyQueryOptions : CampaignQueryOptions
    {
        public Guid? CampaignUuid { get; set; }
        public Guid? CreativeUuid { get; set; }
        public int? PartnerId { get; set; }
        public int? MediaTypeId { get; set; }
        public int? StrategyStatusId { get; set; }
    }
}
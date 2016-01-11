using System;
using Brandscreen.Core.Services.Brands;

namespace Brandscreen.Core.Services.Campaigns
{
    public class CampaignQueryOptions : BrandQueryOptions
    {
        public Guid? BrandUuid { get; set; }
    }
}
using System;
using Brandscreen.Core.Services.Advertisers;

namespace Brandscreen.Core.Services.Placements
{
    public class PlacementQueryOptions : AdvertiserQueryOptions
    {
        public Guid? StrategyUuid { get; set; }
        public Guid? CreativeUuid { get; set; }
    }
}
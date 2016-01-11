using System;

namespace Brandscreen.Core.Services.Placements
{
    public class PlacementModifyOptions
    {
        public Guid CreativeUuid { get; set; }
        public Guid StrategyUuid { get; set; }
        public bool IsLinking { get; set; }
    }
}
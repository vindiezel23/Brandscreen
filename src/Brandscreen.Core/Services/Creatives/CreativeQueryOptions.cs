using System;
using Brandscreen.Core.Services.Brands;

namespace Brandscreen.Core.Services.Creatives
{
    public class CreativeQueryOptions : BrandQueryOptions
    {
        public Guid? BrandUuid { get; set; }
        public Guid? StrategyUuid { get; set; }
        public int? MediaTypeId { get; set; }
    }
}
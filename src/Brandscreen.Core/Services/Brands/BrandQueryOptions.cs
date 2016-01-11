using System;
using Brandscreen.Core.Services.Advertisers;

namespace Brandscreen.Core.Services.Brands
{
    public class BrandQueryOptions : AdvertiserQueryOptions
    {
        public Guid? AdvertiserUuid { get; set; }
    }
}
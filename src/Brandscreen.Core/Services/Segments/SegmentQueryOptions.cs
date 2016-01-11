using System;
using Brandscreen.Core.Services.Advertisers;

namespace Brandscreen.Core.Services.Segments
{
    public class SegmentQueryOptions : AdvertiserQueryOptions
    {
        public Guid? AdvertiserUuid { get; set; }
    }
}
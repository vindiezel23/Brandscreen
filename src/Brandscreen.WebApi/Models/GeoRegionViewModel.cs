using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class GeoRegionViewModel
    {
        public int GeoRegionId { get; set; } // GeoRegionID (Primary key)
        public int GeoCountryId { get; set; } // GeoCountryID
        public string RegionCode { get; set; } // RegionCode
        public string RegionName { get; set; } // RegionName
        public string RegionShortName { get; set; } // RegionShortName
        public long? GeoLocationId { get; set; } // GeoLocationID 
    }

    public class GeoRegionViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<GeoRegion, GeoRegionViewModel>();
        }
    }
}
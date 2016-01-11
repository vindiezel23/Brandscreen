using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class DoohGeoLocationGroupViewModel
    {
        public int DoohGeoLocationGroupId { get; set; } // DoohGeoLocationGroupID (Primary key)
        public int GeoCountryId { get; set; } // GeoCountryID
        public int? GeoRegionId { get; set; } // GeoRegionID
        public int? GeoCityId { get; set; } // GeoCityID
        public string LocationGroupName { get; set; } // LocationGroupName
        public int GeoLocationId { get; set; } // GeoLocationID
        public decimal? Latitude { get; set; } // Latitude
        public decimal? Longitude { get; set; } // Longitude
        public decimal? RadiusInKm { get; set; } // RadiusInKm
    }

    public class DoohGeoLocationGroupViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<DoohGeoLocationGroup, DoohGeoLocationGroupViewModel>();
        }
    }
}
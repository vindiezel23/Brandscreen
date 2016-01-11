using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class GeoCityViewModel
    {
        public int GeoCityId { get; set; } // GeoCityID (Primary key)
        public int GeoCountryId { get; set; } // GeoCountryID
        public int? GeoRegionId { get; set; } // GeoRegionID
        public int? GeoMetroId { get; set; } // GeoMetroID
        public string CityName { get; set; } // CityName
        public double Latitude { get; set; } // Latitude
        public double Longitude { get; set; } // Longitude
        public long? GeoLocationId { get; set; } // GeoLocationID
    }

    public class GeoCityViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<GeoCity, GeoCityViewModel>();
        }
    }
}
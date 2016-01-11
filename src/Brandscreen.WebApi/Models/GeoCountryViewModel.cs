using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class GeoCountryViewModel
    {
        public int GeoCountryId { get; set; } // GeoCountryID (Primary key)
        public string Iso3166Code { get; set; } // ISO3166Code
        public string CountryName { get; set; } // CountryName
        public long? GeoLocationId { get; set; } // GeoLocationID 
    }

    public class GeoCountryViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<GeoCountry, GeoCountryViewModel>();
        }
    }
}
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class GeoLocationViewModel
    {
        public long GeoLocationId { get; set; } // GeoLocationID (Primary key)
        public string GeoLocationCode { get; set; } // GeoLocationCode
        public int GeoCountryId { get; set; } // GeoCountryID
        public int? GeoRegionId { get; set; } // GeoRegionID
        public int? GeoMetroId { get; set; } // GeoMetroID
        public int? GeoCityId { get; set; } // GeoCityID
    }

    public class GeoLocationViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<GeoLocation, GeoLocationViewModel>();
        }
    }
}
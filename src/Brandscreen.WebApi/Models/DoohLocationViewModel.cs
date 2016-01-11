using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class DoohLocationViewModel
    {
        public int DoohLocationId { get; set; } // DoohLocationID (Primary key)
        public int DoohGeoLocationGroupId { get; set; } // DoohGeoLocationGroupID
        public string Name { get; set; } // Name
        public decimal? Latitude { get; set; } // Latitude
        public decimal? Longitude { get; set; } // Longitude
        public decimal? RadiusInKm { get; set; } // RadiusInKm 
    }

    public class DoohLocationViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<DoohLocation, DoohLocationViewModel>();
        }
    }
}
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class GeoMetroViewModel
    {
        public int GeoMetroId { get; set; } // GeoMetroID (Primary key)
        public int GeoCountryId { get; set; } // GeoCountryID
        public string MetroName { get; set; } // MetroName 
    }

    public class GeoMetroViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<GeoMetro, GeoMetroViewModel>();
        }
    }
}
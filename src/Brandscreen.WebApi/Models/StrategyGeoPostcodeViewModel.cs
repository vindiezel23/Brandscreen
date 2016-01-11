using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyGeoPostcodeViewModel
    {
        public int GeoCountryId { get; set; } // GeoCountryID (Primary key)
        public string Postcode { get; set; } // Postcode (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
    }

    public class StrategyGeoPostcodeViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupGeoPostcode, StrategyGeoPostcodeViewModel>();
        }
    }
}
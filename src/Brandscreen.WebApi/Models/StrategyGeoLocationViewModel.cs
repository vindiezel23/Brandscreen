using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyGeoLocationViewModel
    {
        public long GeoLocationId { get; set; } // GeoLocationID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public string GeoLocationCode { get; set; }
    }

    public class StrategyGeoLocationViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupGeoLocation, StrategyGeoLocationViewModel>()
                .ForMember(dst => dst.GeoLocationCode, opt => opt.MapFrom(src => src.GeoLocation.GeoLocationCode));
        }
    }
}
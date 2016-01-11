using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyMobileCarrierViewModel
    {
        public int GeoCountryId { get; set; } // GeoCountryID (Primary key)
        public int Mcc { get; set; } // MCC (Primary key)
        public int Mnc { get; set; } // MNC (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
    }

    public class StrategyMobileCarrierViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupMobileCarrier, StrategyMobileCarrierViewModel>();
        }
    }
}
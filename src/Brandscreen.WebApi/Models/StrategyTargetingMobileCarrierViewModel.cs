using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services.Strategies;

namespace Brandscreen.WebApi.Models
{
    public class StrategyTargetingMobileCarrierViewModel
    {
        [Required]
        public int? GeoCountryId { get; set; }

        [Required]
        public int? Mcc { get; set; }

        [Required]
        public int? Mnc { get; set; }
    }

    public class StrategyTargetingMobileCarrierViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<StrategyTargetingMobileCarrierViewModel, StrategyTargetingMobileCarrier>();
        }
    }
}
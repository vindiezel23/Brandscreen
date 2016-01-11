using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services.Strategies;

namespace Brandscreen.WebApi.Models
{
    public class StrategyTargetingGeoPostcodeViewModel
    {
        [Required]
        public int? GeoCountryId { get; set; }

        [Required]
        [StringLength(25)]
        public string Postcode { get; set; }
    }

    public class StrategyTargetingGeoPostcodeViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<StrategyTargetingGeoPostcodeViewModel, StrategyTargetingGeoPostcode>();
        }
    }
}
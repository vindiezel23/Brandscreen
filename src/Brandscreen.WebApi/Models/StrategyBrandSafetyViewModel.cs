using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyBrandSafetyViewModel
    {
        public int BrandSafetyTypeId { get; set; } // BrandSafetyTypeID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public int BrandSafetyProviderId { get; set; } // BrandSafetyProviderID (Primary key)
        public string BrandSafetyTypeName { get; set; }
    }

    public class StrategyBrandSafetyViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupBrandSafety, StrategyBrandSafetyViewModel>()
                .ForMember(dst => dst.BrandSafetyTypeName, opt => opt.MapFrom(src => src.BrandSafetyType.BrandSafetyTypeName));
        }
    }
}
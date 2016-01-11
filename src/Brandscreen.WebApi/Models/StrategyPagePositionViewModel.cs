using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyPagePositionViewModel
    {
        public int PagePositionId { get; set; } // PagePositionID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public string PagePositionName { get; set; } // PagePositionName
    }

    public class StrategyPagePositionViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupPagePosition, StrategyPagePositionViewModel>()
                .ForMember(dst => dst.PagePositionName, opt => opt.MapFrom(src => src.PagePosition.PagePositionName));
        }
    }
}
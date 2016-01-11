using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategySegmentViewModel
    {
        public int SegmentId { get; set; } // SegmentID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        public string RtbSegmentId { get; set; }
    }

    public class StrategySegmentViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupSegment, StrategySegmentViewModel>()
                .ForMember(dst => dst.RtbSegmentId, opt => opt.MapFrom(src => src.Segment.RtbSegmentId));
        }
    }
}
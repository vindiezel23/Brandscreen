using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyDayPartViewModel
    {
        public int DayPartId { get; set; } // DayPartID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public string DayPartName { get; set; } // DayPartName
        public string DayOfWeekName { get; set; } // DayOfWeekName
        public string HourOfDayName { get; set; } // HourOfDayName
    }

    public class StrategyDayPartViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupDayPart, StrategyDayPartViewModel>()
                .ForMember(dst => dst.DayPartName, opt => opt.MapFrom(src => src.DayPart.DayPartName))
                .ForMember(dst => dst.DayOfWeekName, opt => opt.MapFrom(src => src.DayPart.DayOfWeekName))
                .ForMember(dst => dst.HourOfDayName, opt => opt.MapFrom(src => src.DayPart.HourOfDayName));
        }
    }
}
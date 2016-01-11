using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class TimeZoneListViewModel
    {
        public int TimeZoneId { get; set; } // TimeZoneID (Primary key)
        public string TimeZoneName { get; set; } // TimeZoneName
        public string TimeZoneCode { get; set; } // TimeZoneCode
        public string GmtOffset { get; set; } // GmtOffset
        public int? DisplayIndex { get; set; } // DisplayIndex
        public int MinutesOffset { get; set; } // MinutesOffset
        public string OlsonName { get; set; } // OlsonName
    }

    public class TimeZoneListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<TimeZone, TimeZoneListViewModel>();
        }
    }
}
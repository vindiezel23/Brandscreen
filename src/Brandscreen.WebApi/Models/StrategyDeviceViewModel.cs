using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyDeviceViewModel
    {
        public int DeviceId { get; set; } // DeviceID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public string DeviceName { get; set; }
    }

    public class StrategyDeviceViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupDevice, StrategyDeviceViewModel>()
                .ForMember(dst => dst.DeviceName, opt => opt.MapFrom(src => src.Device.DeviceName));
        }
    }
}
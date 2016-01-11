using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class DeviceListViewModel
    {
        public int DeviceId { get; set; } // DeviceID (Primary key)
        public string DeviceName { get; set; } // DeviceName 
    }

    public class DeviceListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Device, DeviceListViewModel>();
        }
    }
}
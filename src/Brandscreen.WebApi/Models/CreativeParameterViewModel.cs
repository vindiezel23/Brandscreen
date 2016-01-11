using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class CreativeParameterViewModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class CreativeParameterViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeParameter, CreativeParameterViewModel>()
                .ForMember(dst => dst.Key, opt => opt.MapFrom(src => src.CreativeParameterKey))
                .ForMember(dst => dst.Value, opt => opt.MapFrom(src => src.CreativeParameterValue));
        }
    }
}
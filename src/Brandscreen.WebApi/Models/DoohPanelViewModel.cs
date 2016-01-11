using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class DoohPanelViewModel
    {
        public int DoohPanelId { get; set; } // DoohPanelID (Primary key)
        public int DoohChannelId { get; set; } // DoohChannelID
        public int DoohFormatId { get; set; } // DoohFormatID
        public int CreativeSizeId { get; set; } // CreativeSizeID

        public string ChannelName { get; set; } // ChannelName

        public string FormatName { get; set; } // FormatName

        public string CreativeSizeName { get; set; } // CreativeSizeName
        public int? Height { get; set; } // Height
        public int? Width { get; set; } // Width
        public int MediaTypeId { get; set; } // MediaTypeID
    }

    public class DoohPanelViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<DoohPanel, DoohPanelViewModel>()
                .ForMember(dst => dst.ChannelName, opt => opt.MapFrom(src => src.DoohChannel.ChannelName))
                .ForMember(dst => dst.FormatName, opt => opt.MapFrom(src => src.DoohFormat.FormatName))
                .ForMember(dst => dst.CreativeSizeName, opt => opt.MapFrom(src => src.CreativeSize.CreativeSizeName))
                .ForMember(dst => dst.Height, opt => opt.MapFrom(src => src.CreativeSize.Height))
                .ForMember(dst => dst.Width, opt => opt.MapFrom(src => src.CreativeSize.Width))
                .ForMember(dst => dst.MediaTypeId, opt => opt.MapFrom(src => src.CreativeSize.MediaTypeId));
        }
    }
}
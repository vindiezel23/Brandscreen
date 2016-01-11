using AutoMapper;
using Brandscreen.Core.Services.Partners;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class PartnerViewModel
    {
        public int PartnerId { get; set; } // PartnerID (Primary key)
        public string PartnerName { get; set; } // PartnerName
        public bool IsExchangeTarget { get; set; } // IsExchangeTarget
        public int? TimeZoneId { get; set; } // TimeZoneID

        public string PrivateDealMode { get; set; }
        public string MediaType { get; set; }
    }

    public class PartnerViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Partner, PartnerViewModel>()
                .ForMember(dst => dst.PrivateDealMode, opt => opt.MapFrom(src => (PrivateDealModeEnum) src.PrivateDealMode))
                .ForMember(dst => dst.MediaType, opt => opt.MapFrom(src => (MediaTypeEnum?) src.MediaTypeId));
        }
    }
}
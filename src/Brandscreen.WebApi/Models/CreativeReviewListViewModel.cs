using System;
using AutoMapper;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class CreativeReviewListViewModel
    {
        public int CreativeId { get; set; } // CreativeID (Primary key)
        public int PartnerId { get; set; } // PartnerID (Primary key)
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public string ExchangeErrorString { get; set; } // ExchangeErrorString

        public string Status { get; set; }
    }

    public class CreativeReviewListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeReview, CreativeReviewListViewModel>()
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => (CreativeReviewStatusEnum) src.CreativeReviewStatusId));
        }
    }
}
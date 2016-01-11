using System;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class BrandListViewModel
    {
        public Guid BrandUuid { get; set; }
        public string BrandName { get; set; }
        public string BrandHomepageUrl { get; set; }

        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
    }

    public class BrandListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdvertiserProduct, BrandListViewModel>()
                .ForMember(dst => dst.BrandUuid, opt => opt.MapFrom(src => src.AdvertiserProductUuid))
                .ForMember(dst => dst.BrandName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dst => dst.BrandHomepageUrl, opt => opt.MapFrom(src => src.AdvertiserProductHomepageUrl));
        }
    }
}
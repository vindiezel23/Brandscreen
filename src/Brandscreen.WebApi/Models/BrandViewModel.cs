using System;
using AutoMapper;
using Brandscreen.Core.Services.Brands;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class BrandViewModel
    {
        public Guid BuyerAccountUuid { get; set; }
        public Guid AdvertiserUuid { get; set; }
        public Guid BrandUuid { get; set; }
        public string BrandName { get; set; }
        public string BrandHomepageUrl { get; set; }
        public string SiteListOption { get; set; }
        public string BrandSafetyMode { get; set; }
        public string ProductCategory { get; set; }
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
    }

    public class BrandViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdvertiserProduct, BrandViewModel>()
                .ForMember(dst => dst.BuyerAccountUuid, opt => opt.MapFrom(src => src.BuyerAccount.BuyerAccountUuid))
                .ForMember(dst => dst.AdvertiserUuid, opt => opt.MapFrom(src => src.Advertiser.AdvertiserUuid))
                .ForMember(dst => dst.BrandUuid, opt => opt.MapFrom(src => src.AdvertiserProductUuid))
                .ForMember(dst => dst.BrandName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dst => dst.BrandHomepageUrl, opt => opt.MapFrom(src => src.AdvertiserProductHomepageUrl))
                .ForMember(dst => dst.SiteListOption, opt => opt.MapFrom(src => (SiteListOptionEnum) src.SiteListOption))
                .ForMember(dst => dst.BrandSafetyMode, opt => opt.MapFrom(src => (BrandSafetyModeEnum) src.BrandSafetyModeId))
                .ForMember(dst => dst.ProductCategory, opt => opt.MapFrom(src => src.ProductCategory.ProductCategoryName));
        }
    }
}
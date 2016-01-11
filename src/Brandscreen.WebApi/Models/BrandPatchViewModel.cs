using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services.Brands;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class BrandPatchViewModel
    {
        [StringLength(100)]
        public string BrandName { get; set; }

        [StringLength(200)]
        public string BrandHomepageUrl { get; set; }

        [EnumDataType(typeof (SiteListOptionEnum))]
        public string SiteListOption { get; set; }

        [EnumDataType(typeof (BrandSafetyModeEnum))]
        public string BrandSafetyMode { get; set; }

        public int? ProductCategoryId { get; set; }
    }

    public class BrandPatchViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<BrandPatchViewModel, AdvertiserProduct>()
                .ForMember(dst => dst.ProductName, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.BrandName));
                    opt.MapFrom(src => src.BrandName);
                })
                .ForMember(dst => dst.AdvertiserProductHomepageUrl, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.BrandHomepageUrl));
                    opt.MapFrom(src => src.BrandHomepageUrl);
                })
                .ForMember(dst => dst.SiteListOption, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.SiteListOption));
                    opt.MapFrom(src => Enum.Parse(typeof (SiteListOptionEnum), src.SiteListOption, true));
                })
                .ForMember(dst => dst.BrandSafetyModeId, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.BrandSafetyMode));
                    opt.MapFrom(src => Enum.Parse(typeof (BrandSafetyModeEnum), src.BrandSafetyMode, true));
                })
                .ForMember(dst => dst.BrandSafetyMode, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition(ctx => !ctx.IsSourceValueNull)); // for partial updates
        }
    }
}
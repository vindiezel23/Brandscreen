using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services.Advertisers;
using Brandscreen.Core.Services.Brands;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class BrandCreateViewModel
    {
        [Required]
        public Guid? AdvertiserUuid { get; set; }

        [Required]
        [StringLength(100)]
        public string BrandName { get; set; }

        [StringLength(200)]
        public string BrandHomepageUrl { get; set; }

        /// <summary>
        /// AllSites, BrandscreenBlacklist, BrandscreenWhitelist, or CustomWhitelist
        /// </summary>
        [Required]
        [EnumDataType(typeof (SiteListOptionEnum))]
        public string SiteListOption { get; set; }

        /// <summary>
        /// RunOnAllSites, CortexBlacklist, CortexWhiteList, CustomWhiteList, or PageLevelSafety
        /// </summary>
        [Required]
        [EnumDataType(typeof (BrandSafetyModeEnum))]
        public string BrandSafetyMode { get; set; }

        [Required]
        public int? ProductCategoryId { get; set; }
    }

    public class BrandCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<BrandCreateViewModel, AdvertiserProduct>()
                .ConstructUsing(ctx =>
                {
                    var source = (BrandCreateViewModel) ctx.SourceValue;
                    if (!source.AdvertiserUuid.HasValue) throw new InvalidOperationException("AdvertiserUuid is required."); // shouldn't happen

                    var advertiserService = ctx.Resolve<IAdvertiserService>();
                    var advertiser = advertiserService.GetAdvertiser(source.AdvertiserUuid.Value).WaitAndUnwrapException();

                    var retVal = new AdvertiserProduct
                    {
                        BuyerAccountId = advertiser.BuyerAccountId,
                        AdvertiserId = advertiser.AdvertiserId
                    };
                    return retVal;
                })
                .ForMember(dst => dst.BuyerAccountId, opt => opt.Ignore()) // as mapped in ConstructUsing
                .ForMember(dst => dst.AdvertiserId, opt => opt.Ignore()) // as mapped in ConstructUsing
                .ForMember(dst => dst.ProductName, opt => opt.MapFrom(src => src.BrandName))
                .ForMember(dst => dst.AdvertiserProductHomepageUrl, opt => opt.MapFrom(src => src.BrandHomepageUrl))
                .ForMember(dst => dst.SiteListOption, opt => opt.MapFrom(src => Enum.Parse(typeof (SiteListOptionEnum), src.SiteListOption, true)))
                .ForMember(dst => dst.BrandSafetyModeId, opt => opt.MapFrom(src => Enum.Parse(typeof (BrandSafetyModeEnum), src.BrandSafetyMode, true)))
                .ForMember(dst => dst.BrandSafetyMode, opt => opt.Ignore());
        }
    }
}
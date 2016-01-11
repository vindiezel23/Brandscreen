using System;
using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.Core.Settings;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;

namespace Brandscreen.WebApi.Models
{
    public class CreativeViewModel
    {
        public Guid CreativeUuid { get; set; } // CreativeUuid
        public string CreativeName { get; set; } // CreativeName
        public int CreativeTypeId { get; set; } // CreativeTypeID
        public string AdTag { get; set; } // AdTag
        public int? AdTagTemplateId { get; set; } // AdTagTemplateID
        public string ClickThroughUrl { get; set; } // ClickThroughURL
        public string ClickTrackerUrl { get; set; } // ClickTrackerURL
        public string BeaconUrl { get; set; } // BeaconURL
        public int CreativeStatusId { get; set; } // CreativeStatusID
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public int LanguageId { get; set; } // LanguageID
        public int? CloneFromCreativeId { get; set; } // CloneFromCreativeID
        public string VideoSpecUrl { get; set; } // VideoSpecUrl
        public bool? UrlValidated { get; set; } // UrlValidated
        public int ExpandableDirectionId { get; set; } // ExpandableDirectionID
        public int ThumbnailStatusId { get; set; } // ThumbnailStatusID
        public string FbTitleText { get; set; } // FbTitleText
        public string FbBodyText { get; set; } // FbBodyText
        public string FbImageHash { get; set; } // FbImageHash
        public string FbImageUrl { get; set; } // FbImageUrl
        public int ExpandableActionId { get; set; } // ExpandableActionID
        public string FlexTileLabel { get; set; } // FlexTileLabel
        public bool? IsSsl { get; set; } // IsSsl

        public int? MediaTypeId { get; set; }

        public int BuyerAccountId { get; set; }
        public int AdvertiserId { get; set; }
        public int BrandId { get; set; }
        public int CreativeId { get; set; }

        public string CreativeVersion { get; set; }
        public string CreativeRawUrl { get; set; }

        public CreativeSizeViewModel CreativeSize { get; set; }
        public CreativeFileViewModel CreativeFile { get; set; }
    }

    public class CreativetViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Creative, CreativeViewModel>()
                .ConstructUsing(context =>
                {
                    var creative = (Creative) context.SourceValue;
                    var isGod = context.Resolve<IAuthorizationService>().CanAccessEverything();
                    var retVal = new CreativeViewModel
                    {
                        // security concern: only show short id in god mode
                        BuyerAccountId = isGod ? creative.BuyerAccountId : -1,
                        AdvertiserId = isGod ? creative.AdvertiserProduct.AdvertiserId : -1,
                        BrandId = isGod ? creative.AdvertiserProductId : -1,
                        CreativeId = isGod ? creative.CreativeId : -1
                    };
                    return retVal;
                })
                .ForMember(dst => dst.BuyerAccountId, opt => opt.Ignore()) // as mapped in ConstructUsing
                .ForMember(dst => dst.AdvertiserId, opt => opt.Ignore()) // as mapped in ConstructUsing
                .ForMember(dst => dst.BrandId, opt => opt.Ignore()) // as mapped in ConstructUsing
                .ForMember(dst => dst.CreativeId, opt => opt.Ignore()) // as mapped in ConstructUsing
                .ForMember(dst => dst.MediaTypeId, opt => opt.MapFrom(src => src.AdTagTemplate.MediaTypeId))
                .ForMember(dst => dst.CreativeVersion, opt => opt.MapFrom(src => src.UtcModifiedDateTime.ToUnixTimeSeconds()))
                .ForMember(dst => dst.CreativeRawUrl, opt =>
                {
                    opt.PreCondition(src => src.CreativeFile != null);
                    opt.ResolveUsing(result =>
                    {
                        // note: there is similar logic in creative service
                        var amazonSettings = result.Context.Resolve<IAmazonSettings>();
                        var creative = (Creative) result.Value;
                        var brand = creative.AdvertiserProduct;
                        var path = $"{brand.BuyerAccountId}/{brand.AdvertiserId}/{brand.AdvertiserProductId}/{creative.CreativeFile.FileName}";
                        return (new UriBuilder(amazonSettings.BucketCreativeUrl) {Path = path}).ToString();
                    });
                });
        }
    }
}
using System;
using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;

namespace Brandscreen.WebApi.Models
{
    public class SegmentViewModel
    {
        public int SegmentId { get; set; } // SegmentID (Primary key)
        public string RtbSegmentId { get; set; } // RtbSegmentID
        public string SegmentName { get; set; } // SegmentName
        public string SegmentDescription { get; set; } // SegmentDescription
        public int SegmentTypeId { get; set; } // SegmentTypeID
        public int? ConversionAttributionModelId { get; set; } // ConversionAttributionModelID
        public int? ConversionPostViewLifetime { get; set; } // ConversionPostViewLifetime
        public int? ConversionPostClickLifetime { get; set; } // ConversionPostClickLifetime
        public int? ConversionAttributionCountingModeId { get; set; } // ConversionAttributionCountingModeID
        public int? ConversionAttributionCountingRecency { get; set; } // ConversionAttributionCountingRecency
        public int? RemarketingRecency { get; set; } // RemarketingRecency
        public int? ThirdPartyDataSetId { get; set; } // ThirdPartyDataSetID
        public DateTime? ThirdPartyUtcStartDate { get; set; } // ThirdPartyUtcStartDate
        public DateTime? ThirdPartyUtcEndDate { get; set; } // ThirdPartyUtcEndDate
        public int? ThirdPartyRecency { get; set; } // ThirdPartyRecency
        public decimal? ThirdPartyBudgetAmount { get; set; } // ThirdPartyBudgetAmount
        public decimal? ThirdPartyMaxBidCpm { get; set; } // ThirdPartyMaxBidCpm
        public string ThirdPartyAgencyReference { get; set; } // ThirdPartyAgencyReference
        public string ThirdPartyPartnerReference { get; set; } // ThirdPartyPartnerReference
        public int? ThirdPartyAvailableUniques { get; set; } // ThirdPartyAvailableUniques
        public int SegmentStatusId { get; set; } // SegmentStatusID
        public bool IsDeleted { get; set; } // IsDeleted
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public int? TargetGeographyCountryId { get; set; } // TargetGeographyCountryId
        public int? ThirdPartyPeriodId { get; set; } // ThirdPartyPeriodID
        public int? ThirdPartyParentId { get; set; } // ThirdPartyParentID
        public string ThirdPartyNodePath { get; set; } // ThirdPartyNodePath
        public int? ThirdPartyUniques { get; set; } // ThirdPartyUniques
        public decimal? ThirdPartyCost { get; set; } // ThirdPartyCost
        public bool? ThirdPartySelectable { get; set; } // ThirdPartySelectable
        public bool? ThirdPartyHasChildren { get; set; } // ThirdPartyHasChildren
        public int? SegmentParentId { get; set; } // SegmentParentID
        public bool? ThirdPartyIsDeleted { get; set; } // ThirdPartyIsDeleted
        public int? ThirdPartyCampaignId { get; set; } // ThirdPartyCampaignId
        public int? ConversionPostViewLifetimePeriodId { get; set; } // ConversionPostViewLifetimePeriodID
        public int? ConversionPostClickLifetimePeriodId { get; set; } // ConversionPostClickLifetimePeriodID
        public int? ConversionAttributionCountingRecencyPeriodId { get; set; } // ConversionAttributionCountingRecencyPeriodID
        public int Priority { get; set; } // Priority
        public DateTime? UtcSegmentExpiryDate { get; set; } // UtcSegmentExpiryDate

        public Guid? BuyerAccountUuid { get; set; }
        public Guid? AdvertiserUuid { get; set; }

        public int? BuyerAccountId { get; set; } // BuyerAccountID
        public int? AdvertiserId { get; set; } // AdvertiserID
    }

    public class SegmentViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Segment, SegmentViewModel>()
                .ConstructUsing(context =>
                {
                    var segment = (Segment) context.SourceValue;
                    var isGod = context.Resolve<IAuthorizationService>().CanAccessEverything();
                    var retVal = new SegmentViewModel
                    {
                        // security concern: only show short id in god mode
                        BuyerAccountId = isGod ? segment.BuyerAccountId : -1,
                        AdvertiserId = isGod ? segment.AdvertiserId : -1,
                    };
                    return retVal;
                })
                .ForMember(dst => dst.BuyerAccountUuid, opt => opt.MapFrom(src => src.BuyerAccount.BuyerAccountUuid))
                .ForMember(dst => dst.AdvertiserUuid, opt => opt.MapFrom(src => src.Advertiser.AdvertiserUuid));
        }
    }
}
using System;
using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Campaigns;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;

namespace Brandscreen.WebApi.Models
{
    public class StrategyViewModel
    {
        public Guid StrategyUuid { get; set; }
        public string StrategyName { get; set; }
        public Guid BuyerAccountUuid { get; set; }
        public Guid CampaignUuid { get; set; }
        public string GoalType { get; set; }
        public string FlightType { get; set; }
        public decimal BudgetAmount { get; set; }
        public DateTime? UtcStartDateTime { get; set; }
        public DateTime? UtcEndDateTime { get; set; }
        public string StrategyStatus { get; set; }
        public string MediaType { get; set; }
        public string SpendConstraintPeriod { get; set; }
        public string UniqueConstraintPeriod { get; set; }
        public string PostcodeTargetingMode { get; set; }
        public string MobileCarrierTargetingMode { get; set; }
        public string SupplySource { get; set; }

        public decimal GoalTargetRate { get; set; } // GoalTargetRate
        public int PacingStyleId { get; set; } // PacingStyleID
        public decimal MaxBidCpm { get; set; } // MaxBidCpm
        public bool AutoPause { get; set; } // AutoPause
        public long GoalTargetQuantity { get; set; } // GoalTargetQuantity
        public decimal SpendConstraintAmount { get; set; } // SpendConstraintAmount
        public int UniqueConstraintAmount { get; set; } // UniqueConstraintAmount
        public int AdGroupStatusId { get; set; } // AdGroupStatusID
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public int LanguageTargetingMode { get; set; } // LanguageTargetingMode
        public int CountryTargetingMode { get; set; } // CountryTargetingMode
        public int RegionTargetingMode { get; set; } // RegionTargetingMode
        public int CityTargetingMode { get; set; } // CityTargetingMode
        public int Vertical1TargetingMode { get; set; } // Vertical1TargetingMode
        public int Vertical2TargetingMode { get; set; } // Vertical2TargetingMode
        public int Vertical3TargetingMode { get; set; } // Vertical3TargetingMode
        public int ExchangeTargetingMode { get; set; } // ExchangeTargetingMode
        public int PublisherTargetingMode { get; set; } // PublisherTargetingMode
        public int SiteTargetingMode { get; set; } // SiteTargetingMode
        public int DataTargetTargetingMode { get; set; } // DataTargetTargetingMode
        public int DeviceTargetingMode { get; set; } // DeviceTargetingMode
        public int DayPartTargetingMode { get; set; } // DayPartTargetingMode
        public int PagePositionTargetingMode { get; set; } // PagePositionTargetingMode
        public DateTime? UtcOriginalStartDateTime { get; set; } // UtcOriginalStartDateTime
        public decimal MinBidCpm { get; set; } // MinBidCpm
        public decimal? PacingAmount { get; set; } // PacingAmount
        public bool UseLocalTimeBudgeting { get; set; } // UseLocalTimeBudgeting
        public bool UseLocalCurrencyBudgeting { get; set; } // UseLocalCurrencyBudgeting
        public bool UseBinomialFilter { get; set; } // UseBinomialFilter
        public double MinSloRate { get; set; } // MinSloRate
        public double MaxSloRate { get; set; } // MaxSloRate
        public double PageLevelBrandSafetyLevel { get; set; } // PageLevelBrandSafetyLevel
        public int PacingStyleOptionId { get; set; } // PacingStyleOptionID
        public int? FrequencyGroupId { get; set; } // FrequencyGroupID
        public bool ApplyBrandSafetySetting { get; set; } // ApplyBrandSafetySetting
        public bool? UseSiteListTargeting { get; set; } // UseSiteListTargeting
        public int? ClassificationProviderId { get; set; } // ClassificationProviderID
        public int? BrandSafetyProviderId { get; set; } // BrandSafetyProviderID
        public int? ViewabilityProviderId { get; set; } // ViewabilityProviderID
        public int? QualityProviderId { get; set; } // QualityProviderID
        public int? PacingVersion { get; set; } // PacingVersion
        public int? PricingVersion { get; set; } // PricingVersion
        public bool UseBrandscreenVertical { get; set; } // UseBrandscreenVertical
        public bool UsePacing { get; set; } // UsePacing
        public bool UsePricing { get; set; } // UsePricing
        public int? SuspiciousActivityProviderId { get; set; } // SuspiciousActivityProviderID
        public int? ViewablePercentage { get; set; } // ViewablePercentage
        public bool BypassClassificationHide { get; set; } // BypassClassificationHide

        public int BuyerAccountId { get; set; }
        public int AdvertiserId { get; set; }
        public int BrandId { get; set; }
        public int CampaignId { get; set; }
        public int StrategyId { get; set; }
    }

    public class StrategyViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroup, StrategyViewModel>()
                .ConstructUsing(context =>
                {
                    var strategy = (AdGroup) context.SourceValue;
                    var isGod = context.Resolve<IAuthorizationService>().CanAccessEverything();
                    var retVal = new StrategyViewModel
                    {
                        // security concern: only show short id in god mode
                        BuyerAccountId = isGod ? strategy.BuyerAccountId : -1,
                        AdvertiserId = isGod ? strategy.Campaign.AdvertiserProduct.AdvertiserId : -1,
                        BrandId = isGod ? strategy.Campaign.AdvertiserProductId : -1,
                        CampaignId = isGod ? strategy.CampaignId : -1,
                        StrategyId = isGod ? strategy.AdGroupId : -1
                    };
                    return retVal;
                })
                .ForMember(dst => dst.BuyerAccountId, opt => opt.Ignore()) // as mapped in ConstructUsing
                .ForMember(dst => dst.AdvertiserId, opt => opt.Ignore()) // as mapped in ConstructUsing
                .ForMember(dst => dst.BrandId, opt => opt.Ignore()) // as mapped in ConstructUsing
                .ForMember(dst => dst.CampaignId, opt => opt.Ignore()) // as mapped in ConstructUsing
                .ForMember(dst => dst.StrategyId, opt => opt.Ignore()) // as mapped in ConstructUsing
                .ForMember(dst => dst.StrategyUuid, opt => opt.MapFrom(src => src.AdGroupUuid))
                .ForMember(dst => dst.StrategyName, opt => opt.MapFrom(src => src.AdGroupName))
                .ForMember(dst => dst.BuyerAccountUuid, opt => opt.MapFrom(src => src.BuyerAccount.BuyerAccountUuid))
                .ForMember(dst => dst.CampaignUuid, opt => opt.MapFrom(src => src.Campaign.CampaignUuid))
                .ForMember(dst => dst.GoalType, opt => opt.MapFrom(src => (GoalTypeEnum) src.GoalTypeId))
                .ForMember(dst => dst.FlightType, opt => opt.MapFrom(src => src.BudgetPeriodId == 0 && src.UtcStartDateTime.HasValue && src.UtcEndDateTime.HasValue ? FlightTypeEnum.SingleFlight : (FlightTypeEnum) src.BudgetPeriodId))
                .ForMember(dst => dst.StrategyStatus, opt => opt.MapFrom(src => (CampaignStatusEnum) src.AdGroupStatusId))
                .ForMember(dst => dst.MediaType, opt => opt.MapFrom(src => (MediaTypeEnum) src.MediaTypeId))
                .ForMember(dst => dst.SpendConstraintPeriod, opt => opt.MapFrom(src => (PeriodTypeEnum) src.SpendConstraintPeriodId))
                .ForMember(dst => dst.UniqueConstraintPeriod, opt => opt.MapFrom(src => (PeriodTypeEnum) src.UniqueConstraintPeriodId))
                .ForMember(dst => dst.PostcodeTargetingMode, opt => opt.MapFrom(src => (TargetingActionEnum) src.PostcodeTargetingMode))
                .ForMember(dst => dst.MobileCarrierTargetingMode, opt => opt.MapFrom(src => (TargetingActionEnum) src.MobileCarrierTargetingMode))
                .ForMember(dst => dst.SupplySource, opt => opt.MapFrom(src => (SupplySourceEnum) src.SupplySourceId));
        }
    }
}
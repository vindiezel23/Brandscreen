

// This file was automatically generated.
// Do not make changes directly to this file - edit the template instead.
// 
// The following connection settings were used to generate this file
// 
//     Configuration file:     "src\Brandscreen.Entities\App.config"
//     Connection String Name: "BrandscreenContext"
//     Connection String:      "Data Source=localhost;Initial Catalog=Brandscreen;Integrated Security=True;MultipleActiveResultSets=True"

// Database Edition: Developer Edition (64-bit)
// Database Engine Edition: Enterprise

// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using Repository.Pattern.Ef6;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Entity.ModelConfiguration;
using System.Threading;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace Brandscreen.Entities
{
    // ************************************************************************
    // Unit of work
    public interface IBrandscreenContext : IDisposable
    {
        DbSet<AccountsReceivableRtbView> AccountsReceivableRtbViews { get; set; } // AccountsReceivableRtbView
        DbSet<ActiveAdGroupLookup> ActiveAdGroupLookups { get; set; } // ActiveAdGroupLookup
        DbSet<ActiveAdLookup> ActiveAdLookups { get; set; } // ActiveAdLookup
        DbSet<ActiveCampaignLookup> ActiveCampaignLookups { get; set; } // ActiveCampaignLookup
        DbSet<ActiveSegmentLookup> ActiveSegmentLookups { get; set; } // ActiveSegmentLookup
        DbSet<AdGroup> AdGroups { get; set; } // AdGroup
        DbSet<AdGroupAllDomainList> AdGroupAllDomainLists { get; set; } // AdGroupAllDomainList
        DbSet<AdGroupApplicationParameter> AdGroupApplicationParameters { get; set; } // AdGroupApplicationParameter
        DbSet<AdGroupAttachedDomainList> AdGroupAttachedDomainLists { get; set; } // AdGroupAttachedDomainList
        DbSet<AdGroupBinomialDomainFilterOverride> AdGroupBinomialDomainFilterOverrides { get; set; } // AdGroupBinomialDomainFilterOverride
        DbSet<AdGroupBinomialDomainFilterTargetingView> AdGroupBinomialDomainFilterTargetingViews { get; set; } // AdGroupBinomialDomainFilterTargetingView
        DbSet<AdGroupBinomialFilterOverride> AdGroupBinomialFilterOverrides { get; set; } // AdGroupBinomialFilterOverride
        DbSet<AdGroupBinomialFilterTargetingView> AdGroupBinomialFilterTargetingViews { get; set; } // AdGroupBinomialFilterTargetingView
        DbSet<AdGroupBrandSafety> AdGroupBrandSafeties { get; set; } // AdGroupBrandSafety
        DbSet<AdGroupBrandSafetyBackup> AdGroupBrandSafetyBackups { get; set; } // AdGroupBrandSafety_Backup
        DbSet<AdGroupBrandSafetyView> AdGroupBrandSafetyViews { get; set; } // AdGroupBrandSafetyView
        DbSet<AdGroupContextualFee> AdGroupContextualFees { get; set; } // AdGroupContextualFee
        DbSet<AdGroupDayPart> AdGroupDayParts { get; set; } // AdGroupDayPart
        DbSet<AdGroupDeal> AdGroupDeals { get; set; } // AdGroupDeal
        DbSet<AdGroupDevice> AdGroupDevices { get; set; } // AdGroupDevice
        DbSet<AdGroupDomainList> AdGroupDomainLists { get; set; } // AdGroupDomainList
        DbSet<AdGroupDoohGeoLocationGroup> AdGroupDoohGeoLocationGroups { get; set; } // AdGroupDoohGeoLocationGroup
        DbSet<AdGroupDoohPanelLocation> AdGroupDoohPanelLocations { get; set; } // AdGroupDoohPanelLocation
        DbSet<AdGroupGeoLocation> AdGroupGeoLocations { get; set; } // AdGroupGeoLocation
        DbSet<AdGroupGeoLocationPointRadius> AdGroupGeoLocationPointRadius { get; set; } // AdGroupGeoLocationPointRadius
        DbSet<AdGroupGeoPostcode> AdGroupGeoPostcodes { get; set; } // AdGroupGeoPostcode
        DbSet<AdGroupInheritedDomainList> AdGroupInheritedDomainLists { get; set; } // AdGroupInheritedDomainList
        DbSet<AdGroupInventory> AdGroupInventories { get; set; } // AdGroupInventory
        DbSet<AdGroupLanguage> AdGroupLanguages { get; set; } // AdGroupLanguage
        DbSet<AdGroupMobileCarrier> AdGroupMobileCarriers { get; set; } // AdGroupMobileCarrier
        DbSet<AdGroupNotification> AdGroupNotifications { get; set; } // AdGroupNotification
        DbSet<AdGroupNotificationType> AdGroupNotificationTypes { get; set; } // AdGroupNotificationType
        DbSet<AdGroupPagePosition> AdGroupPagePositions { get; set; } // AdGroupPagePosition
        DbSet<AdGroupPerformance> AdGroupPerformances { get; set; } // AdGroupPerformance
        DbSet<AdGroupPublisher> AdGroupPublishers { get; set; } // AdGroupPublisher
        DbSet<AdGroupSegment> AdGroupSegments { get; set; } // AdGroupSegment
        DbSet<AdGroupSloRateLookup> AdGroupSloRateLookups { get; set; } // AdGroupSloRateLookup
        DbSet<AdGroupSupplySource> AdGroupSupplySources { get; set; } // AdGroupSupplySource
        DbSet<AdGroupTargetingPerformance> AdGroupTargetingPerformances { get; set; } // AdGroupTargetingPerformance
        DbSet<AdGroupTargetingView> AdGroupTargetingViews { get; set; } // AdGroupTargetingView
        DbSet<AdGroupVertical> AdGroupVerticals { get; set; } // AdGroupVertical
        DbSet<AdGroupVerticalBeforeMigration> AdGroupVerticalBeforeMigrations { get; set; } // AdGroupVerticalBeforeMigration
        DbSet<AdGroupVerticalMappingMigrationLog> AdGroupVerticalMappingMigrationLogs { get; set; } // AdGroupVerticalMappingMigrationLog
        DbSet<AdGroupVerticalTargetingMigration> AdGroupVerticalTargetingMigrations { get; set; } // AdGroupVerticalTargetingMigration
        DbSet<AdGroupVerticalTargetingView> AdGroupVerticalTargetingViews { get; set; } // AdGroupVerticalTargetingView
        DbSet<AdGroupWithBrandSafety> AdGroupWithBrandSafeties { get; set; } // AdGroupWithBrandSafety
        DbSet<AdSlot> AdSlots { get; set; } // AdSlot
        DbSet<AdTagServer> AdTagServers { get; set; } // AdTagServer
        DbSet<AdTagTemplate> AdTagTemplates { get; set; } // AdTagTemplate
        DbSet<Advertiser> Advertisers { get; set; } // Advertiser
        DbSet<AdvertiserApplicationParameter> AdvertiserApplicationParameters { get; set; } // AdvertiserApplicationParameter
        DbSet<AdvertiserBlackListChangeLog> AdvertiserBlackListChangeLogs { get; set; } // AdvertiserBlackListChangeLog
        DbSet<AdvertiserBlackListWebsite> AdvertiserBlackListWebsites { get; set; } // AdvertiserBlackListWebsite
        DbSet<AdvertiserBrandSafety> AdvertiserBrandSafeties { get; set; } // AdvertiserBrandSafety
        DbSet<AdvertiserBrandSafetyBackup> AdvertiserBrandSafetyBackups { get; set; } // AdvertiserBrandSafety_Backup
        DbSet<AdvertiserDomainList> AdvertiserDomainLists { get; set; } // AdvertiserDomainList
        DbSet<AdvertiserPerformance> AdvertiserPerformances { get; set; } // AdvertiserPerformance
        DbSet<AdvertiserProduct> AdvertiserProducts { get; set; } // AdvertiserProduct
        DbSet<AdvertiserProductBrandSafety> AdvertiserProductBrandSafeties { get; set; } // AdvertiserProductBrandSafety
        DbSet<AdvertiserProductBrandSafetyBackup> AdvertiserProductBrandSafetyBackups { get; set; } // AdvertiserProductBrandSafety_Backup
        DbSet<AdvertiserProductDomainList> AdvertiserProductDomainLists { get; set; } // AdvertiserProductDomainList
        DbSet<AdvertiserProductPerformance> AdvertiserProductPerformances { get; set; } // AdvertiserProductPerformance
        DbSet<AdvertiserReview> AdvertiserReviews { get; set; } // AdvertiserReview
        DbSet<AttributionCountingMode> AttributionCountingModes { get; set; } // AttributionCountingMode
        DbSet<AttributionModel> AttributionModels { get; set; } // AttributionModel
        DbSet<BaiduSegment> BaiduSegments { get; set; } // BaiduSegments
        DbSet<BaiduSegmentsAlternate> BaiduSegmentsAlternates { get; set; } // BaiduSegmentsAlternate
        DbSet<BillingCycle> BillingCycles { get; set; } // BillingCycle
        DbSet<BillingPeriod> BillingPeriods { get; set; } // BillingPeriod
        DbSet<BillingType> BillingTypes { get; set; } // BillingType
        DbSet<BinomialGlobalBlackList> BinomialGlobalBlackLists { get; set; } // BinomialGlobalBlackList
        DbSet<BinomialGlobalBlackListOverride> BinomialGlobalBlackListOverrides { get; set; } // BinomialGlobalBlackListOverride
        DbSet<BinomialGlobalDomainBlackList> BinomialGlobalDomainBlackLists { get; set; } // BinomialGlobalDomainBlackList
        DbSet<BinomialGlobalDomainBlackListOverride> BinomialGlobalDomainBlackListOverrides { get; set; } // BinomialGlobalDomainBlackListOverride
        DbSet<BinomialGlobalDomainFilter> BinomialGlobalDomainFilters { get; set; } // BinomialGlobalDomainFilter
        DbSet<BinomialGlobalDomainFilterAlternate> BinomialGlobalDomainFilterAlternates { get; set; } // BinomialGlobalDomainFilterAlternate
        DbSet<BinomialGlobalDomainFilterImport> BinomialGlobalDomainFilterImports { get; set; } // BinomialGlobalDomainFilterImport
        DbSet<BinomialGlobalFilter> BinomialGlobalFilters { get; set; } // BinomialGlobalFilter
        DbSet<BinomialGlobalFilterAlternate> BinomialGlobalFilterAlternates { get; set; } // BinomialGlobalFilterAlternate
        DbSet<BinomialGlobalFilterImport> BinomialGlobalFilterImports { get; set; } // BinomialGlobalFilterImport
        DbSet<BinomialLocalBlackList> BinomialLocalBlackLists { get; set; } // BinomialLocalBlackList
        DbSet<BinomialLocalDomainBlackList> BinomialLocalDomainBlackLists { get; set; } // BinomialLocalDomainBlackList
        DbSet<BinomialLocalDomainFilter> BinomialLocalDomainFilters { get; set; } // BinomialLocalDomainFilter
        DbSet<BinomialLocalDomainFilterAlternate> BinomialLocalDomainFilterAlternates { get; set; } // BinomialLocalDomainFilterAlternate
        DbSet<BinomialLocalDomainFilterImport> BinomialLocalDomainFilterImports { get; set; } // BinomialLocalDomainFilterImport
        DbSet<BinomialLocalFilter> BinomialLocalFilters { get; set; } // BinomialLocalFilter
        DbSet<BinomialLocalFilterAlternate> BinomialLocalFilterAlternates { get; set; } // BinomialLocalFilterAlternate
        DbSet<BinomialLocalFilterImport> BinomialLocalFilterImports { get; set; } // BinomialLocalFilterImport
        DbSet<BrandSafety> BrandSafeties { get; set; } // BrandSafety
        DbSet<BrandSafetyChangeLog> BrandSafetyChangeLogs { get; set; } // BrandSafetyChangeLog
        DbSet<BrandSafetyLevel> BrandSafetyLevels { get; set; } // BrandSafetyLevel
        DbSet<BrandSafetyMode> BrandSafetyModes { get; set; } // BrandSafetyMode
        DbSet<BrandSafetyType> BrandSafetyTypes { get; set; } // BrandSafetyType
        DbSet<BuyerAccount> BuyerAccounts { get; set; } // BuyerAccount
        DbSet<BuyerAccountAdTagTemplateFee> BuyerAccountAdTagTemplateFees { get; set; } // BuyerAccountAdTagTemplateFee
        DbSet<BuyerAccountApplication> BuyerAccountApplications { get; set; } // BuyerAccountApplication
        DbSet<BuyerAccountApplicationAdTagServer> BuyerAccountApplicationAdTagServers { get; set; } // BuyerAccountApplicationAdTagServer
        DbSet<BuyerAccountApplicationAdTagTemplate> BuyerAccountApplicationAdTagTemplates { get; set; } // BuyerAccountApplicationAdTagTemplate
        DbSet<BuyerAccountApplicationAudienceDataProvider> BuyerAccountApplicationAudienceDataProviders { get; set; } // BuyerAccountApplicationAudienceDataProvider
        DbSet<BuyerAccountApplicationCreativeSize> BuyerAccountApplicationCreativeSizes { get; set; } // BuyerAccountApplicationCreativeSize
        DbSet<BuyerAccountApplicationDataProvider> BuyerAccountApplicationDataProviders { get; set; } // BuyerAccountApplicationDataProvider
        DbSet<BuyerAccountApplicationGeoCountry> BuyerAccountApplicationGeoCountries { get; set; } // BuyerAccountApplicationGeoCountry
        DbSet<BuyerAccountApplicationLanguage> BuyerAccountApplicationLanguages { get; set; } // BuyerAccountApplicationLanguage
        DbSet<BuyerAccountApplicationParameter> BuyerAccountApplicationParameters { get; set; } // BuyerAccountApplicationParameter
        DbSet<BuyerAccountApplicationPartner> BuyerAccountApplicationPartners { get; set; } // BuyerAccountApplicationPartner
        DbSet<BuyerAccountApplicationPixelTagServer> BuyerAccountApplicationPixelTagServers { get; set; } // BuyerAccountApplicationPixelTagServer
        DbSet<BuyerAccountApplicationTranslation> BuyerAccountApplicationTranslations { get; set; } // BuyerAccountApplicationTranslation
        DbSet<BuyerAccountBlackListChangeLog> BuyerAccountBlackListChangeLogs { get; set; } // BuyerAccountBlackListChangeLog
        DbSet<BuyerAccountBlackListWebsite> BuyerAccountBlackListWebsites { get; set; } // BuyerAccountBlackListWebsite
        DbSet<BuyerAccountBrandSafety> BuyerAccountBrandSafeties { get; set; } // BuyerAccountBrandSafety
        DbSet<BuyerAccountBrandSafetyBackup> BuyerAccountBrandSafetyBackups { get; set; } // BuyerAccountBrandSafety_Backup
        DbSet<BuyerAccountContextualProviderFee> BuyerAccountContextualProviderFees { get; set; } // BuyerAccountContextualProviderFee
        DbSet<BuyerAccountDomainList> BuyerAccountDomainLists { get; set; } // BuyerAccountDomainList
        DbSet<BuyerAccountExcludedInventory> BuyerAccountExcludedInventories { get; set; } // BuyerAccountExcludedInventory
        DbSet<BuyerAccountPartnerSeatView> BuyerAccountPartnerSeatViews { get; set; } // BuyerAccountPartnerSeatView
        DbSet<Campaign> Campaigns { get; set; } // Campaign
        DbSet<CampaignBrandSafety> CampaignBrandSafeties { get; set; } // CampaignBrandSafety
        DbSet<CampaignBrandSafetyBackup> CampaignBrandSafetyBackups { get; set; } // CampaignBrandSafety_Backup
        DbSet<CampaignDomainList> CampaignDomainLists { get; set; } // CampaignDomainList
        DbSet<CampaignMargin> CampaignMargins { get; set; } // CampaignMargin
        DbSet<CampaignPerformance> CampaignPerformances { get; set; } // CampaignPerformance
        DbSet<CampaignPeriod> CampaignPeriods { get; set; } // CampaignPeriod
        DbSet<CampaignStatus> CampaignStatus { get; set; } // CampaignStatus
        DbSet<ChangeLog> ChangeLogs { get; set; } // ChangeLog
        DbSet<ChangeLogComment> ChangeLogComments { get; set; } // ChangeLogComment
        DbSet<CompanyType> CompanyTypes { get; set; } // CompanyType
        DbSet<ConstraintReason> ConstraintReasons { get; set; } // ConstraintReason
        DbSet<ContextualProviderFee> ContextualProviderFees { get; set; } // ContextualProviderFee
        DbSet<Country> Countries { get; set; } // Country
        DbSet<CountryContextualProviderFee> CountryContextualProviderFees { get; set; } // CountryContextualProviderFee
        DbSet<Creative> Creatives { get; set; } // Creative
        DbSet<CreativeAttribute> CreativeAttributes { get; set; } // CreativeAttribute
        DbSet<CreativeAuditStatu> CreativeAuditStatus { get; set; } // CreativeAuditStatus
        DbSet<CreativeConversionSegmentMongoExportView> CreativeConversionSegmentMongoExportViews { get; set; } // CreativeConversionSegmentMongoExportView
        DbSet<CreativeFile> CreativeFiles { get; set; } // CreativeFile
        DbSet<CreativeFileStatu> CreativeFileStatus { get; set; } // CreativeFileStatus
        DbSet<CreativeMongoExportView> CreativeMongoExportViews { get; set; } // CreativeMongoExportView
        DbSet<CreativeParameter> CreativeParameters { get; set; } // CreativeParameter
        DbSet<CreativeReview> CreativeReviews { get; set; } // CreativeReview
        DbSet<CreativeReviewConfiguration> CreativeReviewConfigurations { get; set; } // CreativeReviewConfiguration
        DbSet<CreativeReviewLookup> CreativeReviewLookups { get; set; } // CreativeReviewLookup
        DbSet<CreativeReviewRejection> CreativeReviewRejections { get; set; } // CreativeReviewRejection
        DbSet<CreativeReviewStatus> CreativeReviewStatus { get; set; } // CreativeReviewStatus
        DbSet<CreativeSize> CreativeSizes { get; set; } // CreativeSize
        DbSet<CreativeSourceType> CreativeSourceTypes { get; set; } // CreativeSourceType
        DbSet<CreativeSpecification> CreativeSpecifications { get; set; } // CreativeSpecification
        DbSet<CreativeType> CreativeTypes { get; set; } // CreativeType
        DbSet<Currency> Currencies { get; set; } // Currency
        DbSet<CustomCreativeParameter> CustomCreativeParameters { get; set; } // CustomCreativeParameter
        DbSet<CustomCreativeTechnology> CustomCreativeTechnologies { get; set; } // CustomCreativeTechnology
        DbSet<CustomPublisherList> CustomPublisherLists { get; set; } // CustomPublisherList
        DbSet<CustomWhiteList> CustomWhiteLists { get; set; } // CustomWhiteList
        DbSet<CustomWhiteListChangeLog> CustomWhiteListChangeLogs { get; set; } // CustomWhiteListChangeLog
        DbSet<CustomWhiteListWebsite> CustomWhiteListWebsites { get; set; } // CustomWhiteListWebsite
        DbSet<DataSegmentView> DataSegmentViews { get; set; } // DataSegmentView
        DbSet<DayPart> DayParts { get; set; } // DayPart
        DbSet<Deal> Deals { get; set; } // Deal
        DbSet<DealMode> DealModes { get; set; } // DealMode
        DbSet<DealPerformance> DealPerformances { get; set; } // DealPerformance
        DbSet<DealType> DealTypes { get; set; } // DealType
        DbSet<Device> Devices { get; set; } // Device
        DbSet<Domain> Domains { get; set; } // Domain
        DbSet<DomainList> DomainLists { get; set; } // DomainList
        DbSet<DomainListInvertedIndex> DomainListInvertedIndexes { get; set; } // DomainListInvertedIndexes
        DbSet<DoohChannel> DoohChannels { get; set; } // DoohChannel
        DbSet<DoohFormat> DoohFormats { get; set; } // DoohFormat
        DbSet<DoohGeoLocationGroup> DoohGeoLocationGroups { get; set; } // DoohGeoLocationGroup
        DbSet<DoohLocation> DoohLocations { get; set; } // DoohLocation
        DbSet<DoohPanel> DoohPanels { get; set; } // DoohPanel
        DbSet<DoohPanelLocation> DoohPanelLocations { get; set; } // DoohPanelLocation
        DbSet<EntityLabel> EntityLabels { get; set; } // EntityLabel
        DbSet<EntityUserTag> EntityUserTags { get; set; } // EntityUserTag
        DbSet<ExchangeBuyerIdLookup> ExchangeBuyerIdLookups { get; set; } // ExchangeBuyerIDLookup
        DbSet<ExchangeConfiguration> ExchangeConfigurations { get; set; } // ExchangeConfiguration
        DbSet<ExelateImport> ExelateImports { get; set; } // ExelateImport
        DbSet<ExpandableAction> ExpandableActions { get; set; } // ExpandableAction
        DbSet<ExpandableDirection> ExpandableDirections { get; set; } // ExpandableDirection
        DbSet<EyeotaRateCard> EyeotaRateCards { get; set; } // EyeotaRateCard
        DbSet<EyeotaTaxonomyImport> EyeotaTaxonomyImports { get; set; } // EyeotaTaxonomyImport
        DbSet<FrequencyCap> FrequencyCaps { get; set; } // FrequencyCap
        DbSet<FrequencyGroup> FrequencyGroups { get; set; } // FrequencyGroup
        DbSet<GeoAbsRegion> GeoAbsRegions { get; set; } // GeoABSRegion
        DbSet<GeoCity> GeoCities { get; set; } // GeoCity
        DbSet<GeoCountry> GeoCountries { get; set; } // GeoCountry
        DbSet<GeoLocation> GeoLocations { get; set; } // GeoLocation
        DbSet<GeoMetro> GeoMetroes { get; set; } // GeoMetro
        DbSet<GeoRegion> GeoRegions { get; set; } // GeoRegion
        DbSet<GeoSuburb> GeoSuburbs { get; set; } // GeoSuburb
        DbSet<GoalType> GoalTypes { get; set; } // GoalType
        DbSet<IkonProgrammaticReport> IkonProgrammaticReports { get; set; } // IkonProgrammaticReport
        DbSet<IndustryCategory> IndustryCategories { get; set; } // IndustryCategory
        DbSet<Interval> Intervals { get; set; } // Interval
        DbSet<Inventory> Inventories { get; set; } // Inventory
        DbSet<JobHistory> JobHistories { get; set; } // JobHistory
        DbSet<Label> Labels { get; set; } // Label
        DbSet<Language> Languages { get; set; } // Language
        DbSet<LanguageMapping> LanguageMappings { get; set; } // LanguageMapping
        DbSet<LocalizedGeoCity> LocalizedGeoCities { get; set; } // LocalizedGeoCity
        DbSet<LocalizedGeoCountry> LocalizedGeoCountries { get; set; } // LocalizedGeoCountry
        DbSet<LocalizedGeoRegion> LocalizedGeoRegions { get; set; } // LocalizedGeoRegion
        DbSet<MediaType> MediaTypes { get; set; } // MediaType
        DbSet<MindshareTemplateParameter> MindshareTemplateParameters { get; set; } // MindshareTemplateParameter
        DbSet<MobileCarrier> MobileCarriers { get; set; } // MobileCarrier
        DbSet<MonthlyCredit> MonthlyCredits { get; set; } // MonthlyCredit
        DbSet<NewDayPartMapping> NewDayPartMappings { get; set; } // NewDayPartMappings
        DbSet<OptimizationModel> OptimizationModels { get; set; } // OptimizationModel
        DbSet<Order> Orders { get; set; } // Order
        DbSet<OrderLine> OrderLines { get; set; } // OrderLine
        DbSet<PacingStyle> PacingStyles { get; set; } // PacingStyle
        DbSet<PagePosition> PagePositions { get; set; } // PagePosition
        DbSet<Partner> Partners { get; set; } // Partner
        DbSet<PartnerDefaultBuyer> PartnerDefaultBuyers { get; set; } // PartnerDefaultBuyer
        DbSet<PaymentTerm> PaymentTerms { get; set; } // PaymentTerms
        DbSet<PixelTagServer> PixelTagServers { get; set; } // PixelTagServer
        DbSet<PixelTagTemplate> PixelTagTemplates { get; set; } // PixelTagTemplate
        DbSet<Placement> Placements { get; set; } // Placement
        DbSet<PlacementPerformance> PlacementPerformances { get; set; } // PlacementPerformance
        DbSet<PrivateMarket> PrivateMarkets { get; set; } // PrivateMarket
        DbSet<PrivateMarketMode> PrivateMarketModes { get; set; } // PrivateMarketMode
        DbSet<PrivateMarketPerformance> PrivateMarketPerformances { get; set; } // PrivateMarketPerformance
        DbSet<PrivateMarketSite> PrivateMarketSites { get; set; } // PrivateMarketSite
        DbSet<PrivateMarketSitePerformance> PrivateMarketSitePerformances { get; set; } // PrivateMarketSitePerformance
        DbSet<PrivateMarketSiteStatu> PrivateMarketSiteStatus { get; set; } // PrivateMarketSiteStatus
        DbSet<PrivateMarketStatu> PrivateMarketStatus { get; set; } // PrivateMarketStatus
        DbSet<ProductCategory> ProductCategories { get; set; } // ProductCategory
        DbSet<ProviderBrandSafetyType> ProviderBrandSafetyTypes { get; set; } // ProviderBrandSafetyType
        DbSet<Publisher> Publishers { get; set; } // Publisher
        DbSet<ReportAggregationLevel> ReportAggregationLevels { get; set; } // ReportAggregationLevel
        DbSet<ReportJob> ReportJobs { get; set; } // ReportJob
        DbSet<ReportSchedule> ReportSchedules { get; set; } // ReportSchedule
        DbSet<ReportType> ReportTypes { get; set; } // ReportType
        DbSet<RetryLog> RetryLogs { get; set; } // RetryLog
        DbSet<SalesRegion> SalesRegions { get; set; } // SalesRegion
        DbSet<SchemaMigration> SchemaMigrations { get; set; } // SchemaMigration
        DbSet<Segment> Segments { get; set; } // Segment
        DbSet<SegmentPerformance> SegmentPerformances { get; set; } // SegmentPerformance
        DbSet<SegmentReport> SegmentReports { get; set; } // SegmentReport
        DbSet<SegmentThirdPartyTargeting> SegmentThirdPartyTargetings { get; set; } // SegmentThirdPartyTargeting
        DbSet<SegmentType> SegmentTypes { get; set; } // SegmentType
        DbSet<SensitiveCategory> SensitiveCategories { get; set; } // SensitiveCategory
        DbSet<SharingSegment> SharingSegments { get; set; } // SharingSegments
        DbSet<SiteLevelOptimisationOverride> SiteLevelOptimisationOverrides { get; set; } // SiteLevelOptimisationOverride
        DbSet<SiteListLookup> SiteListLookups { get; set; } // SiteListLookup
        DbSet<SiteListOption> SiteListOptions { get; set; } // SiteListOption
        DbSet<SiteMetaAndDetail> SiteMetaAndDetails { get; set; } // SiteMetaAndDetails
        DbSet<SupplySource> SupplySources { get; set; } // SupplySource
        DbSet<SupportedMobileCarriersView> SupportedMobileCarriersViews { get; set; } // SupportedMobileCarriersView
        DbSet<Sysdiagram> Sysdiagrams { get; set; } // sysdiagrams
        DbSet<SystemBlackListWebsite> SystemBlackListWebsites { get; set; } // SystemBlackListWebsite
        DbSet<SystemFeature> SystemFeatures { get; set; } // SystemFeature
        DbSet<SystemSpendLimit> SystemSpendLimits { get; set; } // SystemSpendLimits
        DbSet<TargetingAction> TargetingActions { get; set; } // TargetingAction
        DbSet<TargetingAttributeType> TargetingAttributeTypes { get; set; } // TargetingAttributeType
        DbSet<Technology> Technologies { get; set; } // Technology
        DbSet<Theme> Themes { get; set; } // Theme
        DbSet<ThirdPartyCampaign> ThirdPartyCampaigns { get; set; } // ThirdPartyCampaigns
        DbSet<ThirdPartyCampaignBuyerAccount> ThirdPartyCampaignBuyerAccounts { get; set; } // ThirdPartyCampaignBuyerAccounts
        DbSet<ThirdPartyDataSet> ThirdPartyDataSets { get; set; } // ThirdPartyDataSet
        DbSet<ThirdPartyRatecardImport> ThirdPartyRatecardImports { get; set; } // ThirdPartyRatecardImport
        DbSet<ThirdPartySegmentImport> ThirdPartySegmentImports { get; set; } // ThirdPartySegmentImport
        DbSet<ThirdPartyTaxonomy> ThirdPartyTaxonomies { get; set; } // ThirdPartyTaxonomy
        DbSet<ThirdPartyTaxonomyRateCard> ThirdPartyTaxonomyRateCards { get; set; } // ThirdPartyTaxonomyRateCard
        DbSet<TimeSpan> TimeSpans { get; set; } // TimeSpan
        DbSet<TimeZone> TimeZones { get; set; } // TimeZone
        DbSet<User> Users { get; set; } // User
        DbSet<UserAdvertiserRole> UserAdvertiserRoles { get; set; } // UserAdvertiserRole
        DbSet<UserBuyerRole> UserBuyerRoles { get; set; } // UserBuyerRole
        DbSet<UserTag> UserTags { get; set; } // UserTag
        DbSet<Vertical> Verticals { get; set; } // Vertical
        DbSet<VerticalMapping> VerticalMappings { get; set; } // VerticalMapping
        DbSet<VerticalMappingMigrationAccessLog> VerticalMappingMigrationAccessLogs { get; set; } // VerticalMappingMigrationAccessLog
        DbSet<VerticalStringReferenceToViDsMapping> VerticalStringReferenceToViDsMappings { get; set; } // VerticalStringReferenceToVIDsMapping
        DbSet<VerticalView> VerticalViews { get; set; } // VerticalView

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
        // Stored Procedures
        int CascadeDelete(int? entityType, Guid? uuid);
        int EnsureAllPrivateMarketSiteAndPerformanceRowsExist();
        int FlipBinomialGlobalDomainFilterTables();
        int FlipBinomialGlobalFilterTables();
        int FlipBinomialLocalDomainFilterTables();
        int FlipBinomialLocalFilterTables();
        List<GetAdGroupLifeTimeReturnModel> GetAdGroupLifeTime(Guid? buyerAccountId, Guid? advertiserId, Guid? productId, Guid? campaignId, Guid? adGroupId, out int procResult);
        List<GetProductCategoryConversionRatesReturnModel> GetProductCategoryConversionRates( out int procResult);
        int ImportBinomialFilterData(string tableName, string jobId, string filePath, string fieldTerminator);
        int MigrateTargetingTopLevel(int? adGroupId);
        int RebuildThirdPartySegments(string segmentPrefix);
        int RollBinomialGlobalDomainFilterData();
        int RollBinomialGlobalFilterData();
        int RollBinomialLocalDomainFilterData();
        int RollBinomialLocalFilterData();
        List<SafetyCheckNoRunnableStrategiesSpendingOverBudgetReturnModel> SafetyCheckNoRunnableStrategiesSpendingOverBudget(decimal? overspendThreshold, out int procResult);
        List<SafetyCheckNoStrategiesEnabledPastEndDateReturnModel> SafetyCheckNoStrategiesEnabledPastEndDate(DateTime? utcNow, out int procResult);
        int UpdateCityTargeting(int? adGroupId, byte? targetAction);
        int UpdatePublisherTargeting(int? adGroupId, byte? targetAction);
        int UpdateRegionTargeting(int? adGroupId, byte? targetAction);
        int UpdateVertical2Targeting(int? adGroupId, byte? targetAction);
        int UpdateVertical3Targeting(int? adGroupId, byte? targetAction);
        int UpdateWebsiteTargeting(int? adGroupId, byte? targetAction);
    }

    // ************************************************************************
    // Database context
    public partial class BrandscreenContext : DataContext, IBrandscreenContext
    {
        public DbSet<AccountsReceivableRtbView> AccountsReceivableRtbViews { get; set; } // AccountsReceivableRtbView
        public DbSet<ActiveAdGroupLookup> ActiveAdGroupLookups { get; set; } // ActiveAdGroupLookup
        public DbSet<ActiveAdLookup> ActiveAdLookups { get; set; } // ActiveAdLookup
        public DbSet<ActiveCampaignLookup> ActiveCampaignLookups { get; set; } // ActiveCampaignLookup
        public DbSet<ActiveSegmentLookup> ActiveSegmentLookups { get; set; } // ActiveSegmentLookup
        public DbSet<AdGroup> AdGroups { get; set; } // AdGroup
        public DbSet<AdGroupAllDomainList> AdGroupAllDomainLists { get; set; } // AdGroupAllDomainList
        public DbSet<AdGroupApplicationParameter> AdGroupApplicationParameters { get; set; } // AdGroupApplicationParameter
        public DbSet<AdGroupAttachedDomainList> AdGroupAttachedDomainLists { get; set; } // AdGroupAttachedDomainList
        public DbSet<AdGroupBinomialDomainFilterOverride> AdGroupBinomialDomainFilterOverrides { get; set; } // AdGroupBinomialDomainFilterOverride
        public DbSet<AdGroupBinomialDomainFilterTargetingView> AdGroupBinomialDomainFilterTargetingViews { get; set; } // AdGroupBinomialDomainFilterTargetingView
        public DbSet<AdGroupBinomialFilterOverride> AdGroupBinomialFilterOverrides { get; set; } // AdGroupBinomialFilterOverride
        public DbSet<AdGroupBinomialFilterTargetingView> AdGroupBinomialFilterTargetingViews { get; set; } // AdGroupBinomialFilterTargetingView
        public DbSet<AdGroupBrandSafety> AdGroupBrandSafeties { get; set; } // AdGroupBrandSafety
        public DbSet<AdGroupBrandSafetyBackup> AdGroupBrandSafetyBackups { get; set; } // AdGroupBrandSafety_Backup
        public DbSet<AdGroupBrandSafetyView> AdGroupBrandSafetyViews { get; set; } // AdGroupBrandSafetyView
        public DbSet<AdGroupContextualFee> AdGroupContextualFees { get; set; } // AdGroupContextualFee
        public DbSet<AdGroupDayPart> AdGroupDayParts { get; set; } // AdGroupDayPart
        public DbSet<AdGroupDeal> AdGroupDeals { get; set; } // AdGroupDeal
        public DbSet<AdGroupDevice> AdGroupDevices { get; set; } // AdGroupDevice
        public DbSet<AdGroupDomainList> AdGroupDomainLists { get; set; } // AdGroupDomainList
        public DbSet<AdGroupDoohGeoLocationGroup> AdGroupDoohGeoLocationGroups { get; set; } // AdGroupDoohGeoLocationGroup
        public DbSet<AdGroupDoohPanelLocation> AdGroupDoohPanelLocations { get; set; } // AdGroupDoohPanelLocation
        public DbSet<AdGroupGeoLocation> AdGroupGeoLocations { get; set; } // AdGroupGeoLocation
        public DbSet<AdGroupGeoLocationPointRadius> AdGroupGeoLocationPointRadius { get; set; } // AdGroupGeoLocationPointRadius
        public DbSet<AdGroupGeoPostcode> AdGroupGeoPostcodes { get; set; } // AdGroupGeoPostcode
        public DbSet<AdGroupInheritedDomainList> AdGroupInheritedDomainLists { get; set; } // AdGroupInheritedDomainList
        public DbSet<AdGroupInventory> AdGroupInventories { get; set; } // AdGroupInventory
        public DbSet<AdGroupLanguage> AdGroupLanguages { get; set; } // AdGroupLanguage
        public DbSet<AdGroupMobileCarrier> AdGroupMobileCarriers { get; set; } // AdGroupMobileCarrier
        public DbSet<AdGroupNotification> AdGroupNotifications { get; set; } // AdGroupNotification
        public DbSet<AdGroupNotificationType> AdGroupNotificationTypes { get; set; } // AdGroupNotificationType
        public DbSet<AdGroupPagePosition> AdGroupPagePositions { get; set; } // AdGroupPagePosition
        public DbSet<AdGroupPerformance> AdGroupPerformances { get; set; } // AdGroupPerformance
        public DbSet<AdGroupPublisher> AdGroupPublishers { get; set; } // AdGroupPublisher
        public DbSet<AdGroupSegment> AdGroupSegments { get; set; } // AdGroupSegment
        public DbSet<AdGroupSloRateLookup> AdGroupSloRateLookups { get; set; } // AdGroupSloRateLookup
        public DbSet<AdGroupSupplySource> AdGroupSupplySources { get; set; } // AdGroupSupplySource
        public DbSet<AdGroupTargetingPerformance> AdGroupTargetingPerformances { get; set; } // AdGroupTargetingPerformance
        public DbSet<AdGroupTargetingView> AdGroupTargetingViews { get; set; } // AdGroupTargetingView
        public DbSet<AdGroupVertical> AdGroupVerticals { get; set; } // AdGroupVertical
        public DbSet<AdGroupVerticalBeforeMigration> AdGroupVerticalBeforeMigrations { get; set; } // AdGroupVerticalBeforeMigration
        public DbSet<AdGroupVerticalMappingMigrationLog> AdGroupVerticalMappingMigrationLogs { get; set; } // AdGroupVerticalMappingMigrationLog
        public DbSet<AdGroupVerticalTargetingMigration> AdGroupVerticalTargetingMigrations { get; set; } // AdGroupVerticalTargetingMigration
        public DbSet<AdGroupVerticalTargetingView> AdGroupVerticalTargetingViews { get; set; } // AdGroupVerticalTargetingView
        public DbSet<AdGroupWithBrandSafety> AdGroupWithBrandSafeties { get; set; } // AdGroupWithBrandSafety
        public DbSet<AdSlot> AdSlots { get; set; } // AdSlot
        public DbSet<AdTagServer> AdTagServers { get; set; } // AdTagServer
        public DbSet<AdTagTemplate> AdTagTemplates { get; set; } // AdTagTemplate
        public DbSet<Advertiser> Advertisers { get; set; } // Advertiser
        public DbSet<AdvertiserApplicationParameter> AdvertiserApplicationParameters { get; set; } // AdvertiserApplicationParameter
        public DbSet<AdvertiserBlackListChangeLog> AdvertiserBlackListChangeLogs { get; set; } // AdvertiserBlackListChangeLog
        public DbSet<AdvertiserBlackListWebsite> AdvertiserBlackListWebsites { get; set; } // AdvertiserBlackListWebsite
        public DbSet<AdvertiserBrandSafety> AdvertiserBrandSafeties { get; set; } // AdvertiserBrandSafety
        public DbSet<AdvertiserBrandSafetyBackup> AdvertiserBrandSafetyBackups { get; set; } // AdvertiserBrandSafety_Backup
        public DbSet<AdvertiserDomainList> AdvertiserDomainLists { get; set; } // AdvertiserDomainList
        public DbSet<AdvertiserPerformance> AdvertiserPerformances { get; set; } // AdvertiserPerformance
        public DbSet<AdvertiserProduct> AdvertiserProducts { get; set; } // AdvertiserProduct
        public DbSet<AdvertiserProductBrandSafety> AdvertiserProductBrandSafeties { get; set; } // AdvertiserProductBrandSafety
        public DbSet<AdvertiserProductBrandSafetyBackup> AdvertiserProductBrandSafetyBackups { get; set; } // AdvertiserProductBrandSafety_Backup
        public DbSet<AdvertiserProductDomainList> AdvertiserProductDomainLists { get; set; } // AdvertiserProductDomainList
        public DbSet<AdvertiserProductPerformance> AdvertiserProductPerformances { get; set; } // AdvertiserProductPerformance
        public DbSet<AdvertiserReview> AdvertiserReviews { get; set; } // AdvertiserReview
        public DbSet<AttributionCountingMode> AttributionCountingModes { get; set; } // AttributionCountingMode
        public DbSet<AttributionModel> AttributionModels { get; set; } // AttributionModel
        public DbSet<BaiduSegment> BaiduSegments { get; set; } // BaiduSegments
        public DbSet<BaiduSegmentsAlternate> BaiduSegmentsAlternates { get; set; } // BaiduSegmentsAlternate
        public DbSet<BillingCycle> BillingCycles { get; set; } // BillingCycle
        public DbSet<BillingPeriod> BillingPeriods { get; set; } // BillingPeriod
        public DbSet<BillingType> BillingTypes { get; set; } // BillingType
        public DbSet<BinomialGlobalBlackList> BinomialGlobalBlackLists { get; set; } // BinomialGlobalBlackList
        public DbSet<BinomialGlobalBlackListOverride> BinomialGlobalBlackListOverrides { get; set; } // BinomialGlobalBlackListOverride
        public DbSet<BinomialGlobalDomainBlackList> BinomialGlobalDomainBlackLists { get; set; } // BinomialGlobalDomainBlackList
        public DbSet<BinomialGlobalDomainBlackListOverride> BinomialGlobalDomainBlackListOverrides { get; set; } // BinomialGlobalDomainBlackListOverride
        public DbSet<BinomialGlobalDomainFilter> BinomialGlobalDomainFilters { get; set; } // BinomialGlobalDomainFilter
        public DbSet<BinomialGlobalDomainFilterAlternate> BinomialGlobalDomainFilterAlternates { get; set; } // BinomialGlobalDomainFilterAlternate
        public DbSet<BinomialGlobalDomainFilterImport> BinomialGlobalDomainFilterImports { get; set; } // BinomialGlobalDomainFilterImport
        public DbSet<BinomialGlobalFilter> BinomialGlobalFilters { get; set; } // BinomialGlobalFilter
        public DbSet<BinomialGlobalFilterAlternate> BinomialGlobalFilterAlternates { get; set; } // BinomialGlobalFilterAlternate
        public DbSet<BinomialGlobalFilterImport> BinomialGlobalFilterImports { get; set; } // BinomialGlobalFilterImport
        public DbSet<BinomialLocalBlackList> BinomialLocalBlackLists { get; set; } // BinomialLocalBlackList
        public DbSet<BinomialLocalDomainBlackList> BinomialLocalDomainBlackLists { get; set; } // BinomialLocalDomainBlackList
        public DbSet<BinomialLocalDomainFilter> BinomialLocalDomainFilters { get; set; } // BinomialLocalDomainFilter
        public DbSet<BinomialLocalDomainFilterAlternate> BinomialLocalDomainFilterAlternates { get; set; } // BinomialLocalDomainFilterAlternate
        public DbSet<BinomialLocalDomainFilterImport> BinomialLocalDomainFilterImports { get; set; } // BinomialLocalDomainFilterImport
        public DbSet<BinomialLocalFilter> BinomialLocalFilters { get; set; } // BinomialLocalFilter
        public DbSet<BinomialLocalFilterAlternate> BinomialLocalFilterAlternates { get; set; } // BinomialLocalFilterAlternate
        public DbSet<BinomialLocalFilterImport> BinomialLocalFilterImports { get; set; } // BinomialLocalFilterImport
        public DbSet<BrandSafety> BrandSafeties { get; set; } // BrandSafety
        public DbSet<BrandSafetyChangeLog> BrandSafetyChangeLogs { get; set; } // BrandSafetyChangeLog
        public DbSet<BrandSafetyLevel> BrandSafetyLevels { get; set; } // BrandSafetyLevel
        public DbSet<BrandSafetyMode> BrandSafetyModes { get; set; } // BrandSafetyMode
        public DbSet<BrandSafetyType> BrandSafetyTypes { get; set; } // BrandSafetyType
        public DbSet<BuyerAccount> BuyerAccounts { get; set; } // BuyerAccount
        public DbSet<BuyerAccountAdTagTemplateFee> BuyerAccountAdTagTemplateFees { get; set; } // BuyerAccountAdTagTemplateFee
        public DbSet<BuyerAccountApplication> BuyerAccountApplications { get; set; } // BuyerAccountApplication
        public DbSet<BuyerAccountApplicationAdTagServer> BuyerAccountApplicationAdTagServers { get; set; } // BuyerAccountApplicationAdTagServer
        public DbSet<BuyerAccountApplicationAdTagTemplate> BuyerAccountApplicationAdTagTemplates { get; set; } // BuyerAccountApplicationAdTagTemplate
        public DbSet<BuyerAccountApplicationAudienceDataProvider> BuyerAccountApplicationAudienceDataProviders { get; set; } // BuyerAccountApplicationAudienceDataProvider
        public DbSet<BuyerAccountApplicationCreativeSize> BuyerAccountApplicationCreativeSizes { get; set; } // BuyerAccountApplicationCreativeSize
        public DbSet<BuyerAccountApplicationDataProvider> BuyerAccountApplicationDataProviders { get; set; } // BuyerAccountApplicationDataProvider
        public DbSet<BuyerAccountApplicationGeoCountry> BuyerAccountApplicationGeoCountries { get; set; } // BuyerAccountApplicationGeoCountry
        public DbSet<BuyerAccountApplicationLanguage> BuyerAccountApplicationLanguages { get; set; } // BuyerAccountApplicationLanguage
        public DbSet<BuyerAccountApplicationParameter> BuyerAccountApplicationParameters { get; set; } // BuyerAccountApplicationParameter
        public DbSet<BuyerAccountApplicationPartner> BuyerAccountApplicationPartners { get; set; } // BuyerAccountApplicationPartner
        public DbSet<BuyerAccountApplicationPixelTagServer> BuyerAccountApplicationPixelTagServers { get; set; } // BuyerAccountApplicationPixelTagServer
        public DbSet<BuyerAccountApplicationTranslation> BuyerAccountApplicationTranslations { get; set; } // BuyerAccountApplicationTranslation
        public DbSet<BuyerAccountBlackListChangeLog> BuyerAccountBlackListChangeLogs { get; set; } // BuyerAccountBlackListChangeLog
        public DbSet<BuyerAccountBlackListWebsite> BuyerAccountBlackListWebsites { get; set; } // BuyerAccountBlackListWebsite
        public DbSet<BuyerAccountBrandSafety> BuyerAccountBrandSafeties { get; set; } // BuyerAccountBrandSafety
        public DbSet<BuyerAccountBrandSafetyBackup> BuyerAccountBrandSafetyBackups { get; set; } // BuyerAccountBrandSafety_Backup
        public DbSet<BuyerAccountContextualProviderFee> BuyerAccountContextualProviderFees { get; set; } // BuyerAccountContextualProviderFee
        public DbSet<BuyerAccountDomainList> BuyerAccountDomainLists { get; set; } // BuyerAccountDomainList
        public DbSet<BuyerAccountExcludedInventory> BuyerAccountExcludedInventories { get; set; } // BuyerAccountExcludedInventory
        public DbSet<BuyerAccountPartnerSeatView> BuyerAccountPartnerSeatViews { get; set; } // BuyerAccountPartnerSeatView
        public DbSet<Campaign> Campaigns { get; set; } // Campaign
        public DbSet<CampaignBrandSafety> CampaignBrandSafeties { get; set; } // CampaignBrandSafety
        public DbSet<CampaignBrandSafetyBackup> CampaignBrandSafetyBackups { get; set; } // CampaignBrandSafety_Backup
        public DbSet<CampaignDomainList> CampaignDomainLists { get; set; } // CampaignDomainList
        public DbSet<CampaignMargin> CampaignMargins { get; set; } // CampaignMargin
        public DbSet<CampaignPerformance> CampaignPerformances { get; set; } // CampaignPerformance
        public DbSet<CampaignPeriod> CampaignPeriods { get; set; } // CampaignPeriod
        public DbSet<CampaignStatus> CampaignStatus { get; set; } // CampaignStatus
        public DbSet<ChangeLog> ChangeLogs { get; set; } // ChangeLog
        public DbSet<ChangeLogComment> ChangeLogComments { get; set; } // ChangeLogComment
        public DbSet<CompanyType> CompanyTypes { get; set; } // CompanyType
        public DbSet<ConstraintReason> ConstraintReasons { get; set; } // ConstraintReason
        public DbSet<ContextualProviderFee> ContextualProviderFees { get; set; } // ContextualProviderFee
        public DbSet<Country> Countries { get; set; } // Country
        public DbSet<CountryContextualProviderFee> CountryContextualProviderFees { get; set; } // CountryContextualProviderFee
        public DbSet<Creative> Creatives { get; set; } // Creative
        public DbSet<CreativeAttribute> CreativeAttributes { get; set; } // CreativeAttribute
        public DbSet<CreativeAuditStatu> CreativeAuditStatus { get; set; } // CreativeAuditStatus
        public DbSet<CreativeConversionSegmentMongoExportView> CreativeConversionSegmentMongoExportViews { get; set; } // CreativeConversionSegmentMongoExportView
        public DbSet<CreativeFile> CreativeFiles { get; set; } // CreativeFile
        public DbSet<CreativeFileStatu> CreativeFileStatus { get; set; } // CreativeFileStatus
        public DbSet<CreativeMongoExportView> CreativeMongoExportViews { get; set; } // CreativeMongoExportView
        public DbSet<CreativeParameter> CreativeParameters { get; set; } // CreativeParameter
        public DbSet<CreativeReview> CreativeReviews { get; set; } // CreativeReview
        public DbSet<CreativeReviewConfiguration> CreativeReviewConfigurations { get; set; } // CreativeReviewConfiguration
        public DbSet<CreativeReviewLookup> CreativeReviewLookups { get; set; } // CreativeReviewLookup
        public DbSet<CreativeReviewRejection> CreativeReviewRejections { get; set; } // CreativeReviewRejection
        public DbSet<CreativeReviewStatus> CreativeReviewStatus { get; set; } // CreativeReviewStatus
        public DbSet<CreativeSize> CreativeSizes { get; set; } // CreativeSize
        public DbSet<CreativeSourceType> CreativeSourceTypes { get; set; } // CreativeSourceType
        public DbSet<CreativeSpecification> CreativeSpecifications { get; set; } // CreativeSpecification
        public DbSet<CreativeType> CreativeTypes { get; set; } // CreativeType
        public DbSet<Currency> Currencies { get; set; } // Currency
        public DbSet<CustomCreativeParameter> CustomCreativeParameters { get; set; } // CustomCreativeParameter
        public DbSet<CustomCreativeTechnology> CustomCreativeTechnologies { get; set; } // CustomCreativeTechnology
        public DbSet<CustomPublisherList> CustomPublisherLists { get; set; } // CustomPublisherList
        public DbSet<CustomWhiteList> CustomWhiteLists { get; set; } // CustomWhiteList
        public DbSet<CustomWhiteListChangeLog> CustomWhiteListChangeLogs { get; set; } // CustomWhiteListChangeLog
        public DbSet<CustomWhiteListWebsite> CustomWhiteListWebsites { get; set; } // CustomWhiteListWebsite
        public DbSet<DataSegmentView> DataSegmentViews { get; set; } // DataSegmentView
        public DbSet<DayPart> DayParts { get; set; } // DayPart
        public DbSet<Deal> Deals { get; set; } // Deal
        public DbSet<DealMode> DealModes { get; set; } // DealMode
        public DbSet<DealPerformance> DealPerformances { get; set; } // DealPerformance
        public DbSet<DealType> DealTypes { get; set; } // DealType
        public DbSet<Device> Devices { get; set; } // Device
        public DbSet<Domain> Domains { get; set; } // Domain
        public DbSet<DomainList> DomainLists { get; set; } // DomainList
        public DbSet<DomainListInvertedIndex> DomainListInvertedIndexes { get; set; } // DomainListInvertedIndexes
        public DbSet<DoohChannel> DoohChannels { get; set; } // DoohChannel
        public DbSet<DoohFormat> DoohFormats { get; set; } // DoohFormat
        public DbSet<DoohGeoLocationGroup> DoohGeoLocationGroups { get; set; } // DoohGeoLocationGroup
        public DbSet<DoohLocation> DoohLocations { get; set; } // DoohLocation
        public DbSet<DoohPanel> DoohPanels { get; set; } // DoohPanel
        public DbSet<DoohPanelLocation> DoohPanelLocations { get; set; } // DoohPanelLocation
        public DbSet<EntityLabel> EntityLabels { get; set; } // EntityLabel
        public DbSet<EntityUserTag> EntityUserTags { get; set; } // EntityUserTag
        public DbSet<ExchangeBuyerIdLookup> ExchangeBuyerIdLookups { get; set; } // ExchangeBuyerIDLookup
        public DbSet<ExchangeConfiguration> ExchangeConfigurations { get; set; } // ExchangeConfiguration
        public DbSet<ExelateImport> ExelateImports { get; set; } // ExelateImport
        public DbSet<ExpandableAction> ExpandableActions { get; set; } // ExpandableAction
        public DbSet<ExpandableDirection> ExpandableDirections { get; set; } // ExpandableDirection
        public DbSet<EyeotaRateCard> EyeotaRateCards { get; set; } // EyeotaRateCard
        public DbSet<EyeotaTaxonomyImport> EyeotaTaxonomyImports { get; set; } // EyeotaTaxonomyImport
        public DbSet<FrequencyCap> FrequencyCaps { get; set; } // FrequencyCap
        public DbSet<FrequencyGroup> FrequencyGroups { get; set; } // FrequencyGroup
        public DbSet<GeoAbsRegion> GeoAbsRegions { get; set; } // GeoABSRegion
        public DbSet<GeoCity> GeoCities { get; set; } // GeoCity
        public DbSet<GeoCountry> GeoCountries { get; set; } // GeoCountry
        public DbSet<GeoLocation> GeoLocations { get; set; } // GeoLocation
        public DbSet<GeoMetro> GeoMetroes { get; set; } // GeoMetro
        public DbSet<GeoRegion> GeoRegions { get; set; } // GeoRegion
        public DbSet<GeoSuburb> GeoSuburbs { get; set; } // GeoSuburb
        public DbSet<GoalType> GoalTypes { get; set; } // GoalType
        public DbSet<IkonProgrammaticReport> IkonProgrammaticReports { get; set; } // IkonProgrammaticReport
        public DbSet<IndustryCategory> IndustryCategories { get; set; } // IndustryCategory
        public DbSet<Interval> Intervals { get; set; } // Interval
        public DbSet<Inventory> Inventories { get; set; } // Inventory
        public DbSet<JobHistory> JobHistories { get; set; } // JobHistory
        public DbSet<Label> Labels { get; set; } // Label
        public DbSet<Language> Languages { get; set; } // Language
        public DbSet<LanguageMapping> LanguageMappings { get; set; } // LanguageMapping
        public DbSet<LocalizedGeoCity> LocalizedGeoCities { get; set; } // LocalizedGeoCity
        public DbSet<LocalizedGeoCountry> LocalizedGeoCountries { get; set; } // LocalizedGeoCountry
        public DbSet<LocalizedGeoRegion> LocalizedGeoRegions { get; set; } // LocalizedGeoRegion
        public DbSet<MediaType> MediaTypes { get; set; } // MediaType
        public DbSet<MindshareTemplateParameter> MindshareTemplateParameters { get; set; } // MindshareTemplateParameter
        public DbSet<MobileCarrier> MobileCarriers { get; set; } // MobileCarrier
        public DbSet<MonthlyCredit> MonthlyCredits { get; set; } // MonthlyCredit
        public DbSet<NewDayPartMapping> NewDayPartMappings { get; set; } // NewDayPartMappings
        public DbSet<OptimizationModel> OptimizationModels { get; set; } // OptimizationModel
        public DbSet<Order> Orders { get; set; } // Order
        public DbSet<OrderLine> OrderLines { get; set; } // OrderLine
        public DbSet<PacingStyle> PacingStyles { get; set; } // PacingStyle
        public DbSet<PagePosition> PagePositions { get; set; } // PagePosition
        public DbSet<Partner> Partners { get; set; } // Partner
        public DbSet<PartnerDefaultBuyer> PartnerDefaultBuyers { get; set; } // PartnerDefaultBuyer
        public DbSet<PaymentTerm> PaymentTerms { get; set; } // PaymentTerms
        public DbSet<PixelTagServer> PixelTagServers { get; set; } // PixelTagServer
        public DbSet<PixelTagTemplate> PixelTagTemplates { get; set; } // PixelTagTemplate
        public DbSet<Placement> Placements { get; set; } // Placement
        public DbSet<PlacementPerformance> PlacementPerformances { get; set; } // PlacementPerformance
        public DbSet<PrivateMarket> PrivateMarkets { get; set; } // PrivateMarket
        public DbSet<PrivateMarketMode> PrivateMarketModes { get; set; } // PrivateMarketMode
        public DbSet<PrivateMarketPerformance> PrivateMarketPerformances { get; set; } // PrivateMarketPerformance
        public DbSet<PrivateMarketSite> PrivateMarketSites { get; set; } // PrivateMarketSite
        public DbSet<PrivateMarketSitePerformance> PrivateMarketSitePerformances { get; set; } // PrivateMarketSitePerformance
        public DbSet<PrivateMarketSiteStatu> PrivateMarketSiteStatus { get; set; } // PrivateMarketSiteStatus
        public DbSet<PrivateMarketStatu> PrivateMarketStatus { get; set; } // PrivateMarketStatus
        public DbSet<ProductCategory> ProductCategories { get; set; } // ProductCategory
        public DbSet<ProviderBrandSafetyType> ProviderBrandSafetyTypes { get; set; } // ProviderBrandSafetyType
        public DbSet<Publisher> Publishers { get; set; } // Publisher
        public DbSet<ReportAggregationLevel> ReportAggregationLevels { get; set; } // ReportAggregationLevel
        public DbSet<ReportJob> ReportJobs { get; set; } // ReportJob
        public DbSet<ReportSchedule> ReportSchedules { get; set; } // ReportSchedule
        public DbSet<ReportType> ReportTypes { get; set; } // ReportType
        public DbSet<RetryLog> RetryLogs { get; set; } // RetryLog
        public DbSet<SalesRegion> SalesRegions { get; set; } // SalesRegion
        public DbSet<SchemaMigration> SchemaMigrations { get; set; } // SchemaMigration
        public DbSet<Segment> Segments { get; set; } // Segment
        public DbSet<SegmentPerformance> SegmentPerformances { get; set; } // SegmentPerformance
        public DbSet<SegmentReport> SegmentReports { get; set; } // SegmentReport
        public DbSet<SegmentThirdPartyTargeting> SegmentThirdPartyTargetings { get; set; } // SegmentThirdPartyTargeting
        public DbSet<SegmentType> SegmentTypes { get; set; } // SegmentType
        public DbSet<SensitiveCategory> SensitiveCategories { get; set; } // SensitiveCategory
        public DbSet<SharingSegment> SharingSegments { get; set; } // SharingSegments
        public DbSet<SiteLevelOptimisationOverride> SiteLevelOptimisationOverrides { get; set; } // SiteLevelOptimisationOverride
        public DbSet<SiteListLookup> SiteListLookups { get; set; } // SiteListLookup
        public DbSet<SiteListOption> SiteListOptions { get; set; } // SiteListOption
        public DbSet<SiteMetaAndDetail> SiteMetaAndDetails { get; set; } // SiteMetaAndDetails
        public DbSet<SupplySource> SupplySources { get; set; } // SupplySource
        public DbSet<SupportedMobileCarriersView> SupportedMobileCarriersViews { get; set; } // SupportedMobileCarriersView
        public DbSet<Sysdiagram> Sysdiagrams { get; set; } // sysdiagrams
        public DbSet<SystemBlackListWebsite> SystemBlackListWebsites { get; set; } // SystemBlackListWebsite
        public DbSet<SystemFeature> SystemFeatures { get; set; } // SystemFeature
        public DbSet<SystemSpendLimit> SystemSpendLimits { get; set; } // SystemSpendLimits
        public DbSet<TargetingAction> TargetingActions { get; set; } // TargetingAction
        public DbSet<TargetingAttributeType> TargetingAttributeTypes { get; set; } // TargetingAttributeType
        public DbSet<Technology> Technologies { get; set; } // Technology
        public DbSet<Theme> Themes { get; set; } // Theme
        public DbSet<ThirdPartyCampaign> ThirdPartyCampaigns { get; set; } // ThirdPartyCampaigns
        public DbSet<ThirdPartyCampaignBuyerAccount> ThirdPartyCampaignBuyerAccounts { get; set; } // ThirdPartyCampaignBuyerAccounts
        public DbSet<ThirdPartyDataSet> ThirdPartyDataSets { get; set; } // ThirdPartyDataSet
        public DbSet<ThirdPartyRatecardImport> ThirdPartyRatecardImports { get; set; } // ThirdPartyRatecardImport
        public DbSet<ThirdPartySegmentImport> ThirdPartySegmentImports { get; set; } // ThirdPartySegmentImport
        public DbSet<ThirdPartyTaxonomy> ThirdPartyTaxonomies { get; set; } // ThirdPartyTaxonomy
        public DbSet<ThirdPartyTaxonomyRateCard> ThirdPartyTaxonomyRateCards { get; set; } // ThirdPartyTaxonomyRateCard
        public DbSet<TimeSpan> TimeSpans { get; set; } // TimeSpan
        public DbSet<TimeZone> TimeZones { get; set; } // TimeZone
        public DbSet<User> Users { get; set; } // User
        public DbSet<UserAdvertiserRole> UserAdvertiserRoles { get; set; } // UserAdvertiserRole
        public DbSet<UserBuyerRole> UserBuyerRoles { get; set; } // UserBuyerRole
        public DbSet<UserTag> UserTags { get; set; } // UserTag
        public DbSet<Vertical> Verticals { get; set; } // Vertical
        public DbSet<VerticalMapping> VerticalMappings { get; set; } // VerticalMapping
        public DbSet<VerticalMappingMigrationAccessLog> VerticalMappingMigrationAccessLogs { get; set; } // VerticalMappingMigrationAccessLog
        public DbSet<VerticalStringReferenceToViDsMapping> VerticalStringReferenceToViDsMappings { get; set; } // VerticalStringReferenceToVIDsMapping
        public DbSet<VerticalView> VerticalViews { get; set; } // VerticalView
        
        static BrandscreenContext()
        {
            System.Data.Entity.Database.SetInitializer<BrandscreenContext>(null);
        }

        public BrandscreenContext()
            : base("Name=BrandscreenContext")
        {
            InitializePartial();
        }

        public BrandscreenContext(string connectionString) : base(connectionString)
        {
            InitializePartial();
        }

        //public BrandscreenContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        //{
            //InitializePartial();
        //}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AccountsReceivableRtbViewMap());
            modelBuilder.Configurations.Add(new ActiveAdGroupLookupMap());
            modelBuilder.Configurations.Add(new ActiveAdLookupMap());
            modelBuilder.Configurations.Add(new ActiveCampaignLookupMap());
            modelBuilder.Configurations.Add(new ActiveSegmentLookupMap());
            modelBuilder.Configurations.Add(new AdGroupMap());
            modelBuilder.Configurations.Add(new AdGroupAllDomainListMap());
            modelBuilder.Configurations.Add(new AdGroupApplicationParameterMap());
            modelBuilder.Configurations.Add(new AdGroupAttachedDomainListMap());
            modelBuilder.Configurations.Add(new AdGroupBinomialDomainFilterOverrideMap());
            modelBuilder.Configurations.Add(new AdGroupBinomialDomainFilterTargetingViewMap());
            modelBuilder.Configurations.Add(new AdGroupBinomialFilterOverrideMap());
            modelBuilder.Configurations.Add(new AdGroupBinomialFilterTargetingViewMap());
            modelBuilder.Configurations.Add(new AdGroupBrandSafetyMap());
            modelBuilder.Configurations.Add(new AdGroupBrandSafetyBackupMap());
            modelBuilder.Configurations.Add(new AdGroupBrandSafetyViewMap());
            modelBuilder.Configurations.Add(new AdGroupContextualFeeMap());
            modelBuilder.Configurations.Add(new AdGroupDayPartMap());
            modelBuilder.Configurations.Add(new AdGroupDealMap());
            modelBuilder.Configurations.Add(new AdGroupDeviceMap());
            modelBuilder.Configurations.Add(new AdGroupDomainListMap());
            modelBuilder.Configurations.Add(new AdGroupDoohGeoLocationGroupMap());
            modelBuilder.Configurations.Add(new AdGroupDoohPanelLocationMap());
            modelBuilder.Configurations.Add(new AdGroupGeoLocationMap());
            modelBuilder.Configurations.Add(new AdGroupGeoLocationPointRadiusMap());
            modelBuilder.Configurations.Add(new AdGroupGeoPostcodeMap());
            modelBuilder.Configurations.Add(new AdGroupInheritedDomainListMap());
            modelBuilder.Configurations.Add(new AdGroupInventoryMap());
            modelBuilder.Configurations.Add(new AdGroupLanguageMap());
            modelBuilder.Configurations.Add(new AdGroupMobileCarrierMap());
            modelBuilder.Configurations.Add(new AdGroupNotificationMap());
            modelBuilder.Configurations.Add(new AdGroupNotificationTypeMap());
            modelBuilder.Configurations.Add(new AdGroupPagePositionMap());
            modelBuilder.Configurations.Add(new AdGroupPerformanceMap());
            modelBuilder.Configurations.Add(new AdGroupPublisherMap());
            modelBuilder.Configurations.Add(new AdGroupSegmentMap());
            modelBuilder.Configurations.Add(new AdGroupSloRateLookupMap());
            modelBuilder.Configurations.Add(new AdGroupSupplySourceMap());
            modelBuilder.Configurations.Add(new AdGroupTargetingPerformanceMap());
            modelBuilder.Configurations.Add(new AdGroupTargetingViewMap());
            modelBuilder.Configurations.Add(new AdGroupVerticalMap());
            modelBuilder.Configurations.Add(new AdGroupVerticalBeforeMigrationMap());
            modelBuilder.Configurations.Add(new AdGroupVerticalMappingMigrationLogMap());
            modelBuilder.Configurations.Add(new AdGroupVerticalTargetingMigrationMap());
            modelBuilder.Configurations.Add(new AdGroupVerticalTargetingViewMap());
            modelBuilder.Configurations.Add(new AdGroupWithBrandSafetyMap());
            modelBuilder.Configurations.Add(new AdSlotMap());
            modelBuilder.Configurations.Add(new AdTagServerMap());
            modelBuilder.Configurations.Add(new AdTagTemplateMap());
            modelBuilder.Configurations.Add(new AdvertiserMap());
            modelBuilder.Configurations.Add(new AdvertiserApplicationParameterMap());
            modelBuilder.Configurations.Add(new AdvertiserBlackListChangeLogMap());
            modelBuilder.Configurations.Add(new AdvertiserBlackListWebsiteMap());
            modelBuilder.Configurations.Add(new AdvertiserBrandSafetyMap());
            modelBuilder.Configurations.Add(new AdvertiserBrandSafetyBackupMap());
            modelBuilder.Configurations.Add(new AdvertiserDomainListMap());
            modelBuilder.Configurations.Add(new AdvertiserPerformanceMap());
            modelBuilder.Configurations.Add(new AdvertiserProductMap());
            modelBuilder.Configurations.Add(new AdvertiserProductBrandSafetyMap());
            modelBuilder.Configurations.Add(new AdvertiserProductBrandSafetyBackupMap());
            modelBuilder.Configurations.Add(new AdvertiserProductDomainListMap());
            modelBuilder.Configurations.Add(new AdvertiserProductPerformanceMap());
            modelBuilder.Configurations.Add(new AdvertiserReviewMap());
            modelBuilder.Configurations.Add(new AttributionCountingModeMap());
            modelBuilder.Configurations.Add(new AttributionModelMap());
            modelBuilder.Configurations.Add(new BaiduSegmentMap());
            modelBuilder.Configurations.Add(new BaiduSegmentsAlternateMap());
            modelBuilder.Configurations.Add(new BillingCycleMap());
            modelBuilder.Configurations.Add(new BillingPeriodMap());
            modelBuilder.Configurations.Add(new BillingTypeMap());
            modelBuilder.Configurations.Add(new BinomialGlobalBlackListMap());
            modelBuilder.Configurations.Add(new BinomialGlobalBlackListOverrideMap());
            modelBuilder.Configurations.Add(new BinomialGlobalDomainBlackListMap());
            modelBuilder.Configurations.Add(new BinomialGlobalDomainBlackListOverrideMap());
            modelBuilder.Configurations.Add(new BinomialGlobalDomainFilterMap());
            modelBuilder.Configurations.Add(new BinomialGlobalDomainFilterAlternateMap());
            modelBuilder.Configurations.Add(new BinomialGlobalDomainFilterImportMap());
            modelBuilder.Configurations.Add(new BinomialGlobalFilterMap());
            modelBuilder.Configurations.Add(new BinomialGlobalFilterAlternateMap());
            modelBuilder.Configurations.Add(new BinomialGlobalFilterImportMap());
            modelBuilder.Configurations.Add(new BinomialLocalBlackListMap());
            modelBuilder.Configurations.Add(new BinomialLocalDomainBlackListMap());
            modelBuilder.Configurations.Add(new BinomialLocalDomainFilterMap());
            modelBuilder.Configurations.Add(new BinomialLocalDomainFilterAlternateMap());
            modelBuilder.Configurations.Add(new BinomialLocalDomainFilterImportMap());
            modelBuilder.Configurations.Add(new BinomialLocalFilterMap());
            modelBuilder.Configurations.Add(new BinomialLocalFilterAlternateMap());
            modelBuilder.Configurations.Add(new BinomialLocalFilterImportMap());
            modelBuilder.Configurations.Add(new BrandSafetyMap());
            modelBuilder.Configurations.Add(new BrandSafetyChangeLogMap());
            modelBuilder.Configurations.Add(new BrandSafetyLevelMap());
            modelBuilder.Configurations.Add(new BrandSafetyModeMap());
            modelBuilder.Configurations.Add(new BrandSafetyTypeMap());
            modelBuilder.Configurations.Add(new BuyerAccountMap());
            modelBuilder.Configurations.Add(new BuyerAccountAdTagTemplateFeeMap());
            modelBuilder.Configurations.Add(new BuyerAccountApplicationMap());
            modelBuilder.Configurations.Add(new BuyerAccountApplicationAdTagServerMap());
            modelBuilder.Configurations.Add(new BuyerAccountApplicationAdTagTemplateMap());
            modelBuilder.Configurations.Add(new BuyerAccountApplicationAudienceDataProviderMap());
            modelBuilder.Configurations.Add(new BuyerAccountApplicationCreativeSizeMap());
            modelBuilder.Configurations.Add(new BuyerAccountApplicationDataProviderMap());
            modelBuilder.Configurations.Add(new BuyerAccountApplicationGeoCountryMap());
            modelBuilder.Configurations.Add(new BuyerAccountApplicationLanguageMap());
            modelBuilder.Configurations.Add(new BuyerAccountApplicationParameterMap());
            modelBuilder.Configurations.Add(new BuyerAccountApplicationPartnerMap());
            modelBuilder.Configurations.Add(new BuyerAccountApplicationPixelTagServerMap());
            modelBuilder.Configurations.Add(new BuyerAccountApplicationTranslationMap());
            modelBuilder.Configurations.Add(new BuyerAccountBlackListChangeLogMap());
            modelBuilder.Configurations.Add(new BuyerAccountBlackListWebsiteMap());
            modelBuilder.Configurations.Add(new BuyerAccountBrandSafetyMap());
            modelBuilder.Configurations.Add(new BuyerAccountBrandSafetyBackupMap());
            modelBuilder.Configurations.Add(new BuyerAccountContextualProviderFeeMap());
            modelBuilder.Configurations.Add(new BuyerAccountDomainListMap());
            modelBuilder.Configurations.Add(new BuyerAccountExcludedInventoryMap());
            modelBuilder.Configurations.Add(new BuyerAccountPartnerSeatViewMap());
            modelBuilder.Configurations.Add(new CampaignMap());
            modelBuilder.Configurations.Add(new CampaignBrandSafetyMap());
            modelBuilder.Configurations.Add(new CampaignBrandSafetyBackupMap());
            modelBuilder.Configurations.Add(new CampaignDomainListMap());
            modelBuilder.Configurations.Add(new CampaignMarginMap());
            modelBuilder.Configurations.Add(new CampaignPerformanceMap());
            modelBuilder.Configurations.Add(new CampaignPeriodMap());
            modelBuilder.Configurations.Add(new CampaignStatusMap());
            modelBuilder.Configurations.Add(new ChangeLogMap());
            modelBuilder.Configurations.Add(new ChangeLogCommentMap());
            modelBuilder.Configurations.Add(new CompanyTypeMap());
            modelBuilder.Configurations.Add(new ConstraintReasonMap());
            modelBuilder.Configurations.Add(new ContextualProviderFeeMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new CountryContextualProviderFeeMap());
            modelBuilder.Configurations.Add(new CreativeMap());
            modelBuilder.Configurations.Add(new CreativeAttributeMap());
            modelBuilder.Configurations.Add(new CreativeAuditStatuMap());
            modelBuilder.Configurations.Add(new CreativeConversionSegmentMongoExportViewMap());
            modelBuilder.Configurations.Add(new CreativeFileMap());
            modelBuilder.Configurations.Add(new CreativeFileStatuMap());
            modelBuilder.Configurations.Add(new CreativeMongoExportViewMap());
            modelBuilder.Configurations.Add(new CreativeParameterMap());
            modelBuilder.Configurations.Add(new CreativeReviewMap());
            modelBuilder.Configurations.Add(new CreativeReviewConfigurationMap());
            modelBuilder.Configurations.Add(new CreativeReviewLookupMap());
            modelBuilder.Configurations.Add(new CreativeReviewRejectionMap());
            modelBuilder.Configurations.Add(new CreativeReviewStatusMap());
            modelBuilder.Configurations.Add(new CreativeSizeMap());
            modelBuilder.Configurations.Add(new CreativeSourceTypeMap());
            modelBuilder.Configurations.Add(new CreativeSpecificationMap());
            modelBuilder.Configurations.Add(new CreativeTypeMap());
            modelBuilder.Configurations.Add(new CurrencyMap());
            modelBuilder.Configurations.Add(new CustomCreativeParameterMap());
            modelBuilder.Configurations.Add(new CustomCreativeTechnologyMap());
            modelBuilder.Configurations.Add(new CustomPublisherListMap());
            modelBuilder.Configurations.Add(new CustomWhiteListMap());
            modelBuilder.Configurations.Add(new CustomWhiteListChangeLogMap());
            modelBuilder.Configurations.Add(new CustomWhiteListWebsiteMap());
            modelBuilder.Configurations.Add(new DataSegmentViewMap());
            modelBuilder.Configurations.Add(new DayPartMap());
            modelBuilder.Configurations.Add(new DealMap());
            modelBuilder.Configurations.Add(new DealModeMap());
            modelBuilder.Configurations.Add(new DealPerformanceMap());
            modelBuilder.Configurations.Add(new DealTypeMap());
            modelBuilder.Configurations.Add(new DeviceMap());
            modelBuilder.Configurations.Add(new DomainMap());
            modelBuilder.Configurations.Add(new DomainListMap());
            modelBuilder.Configurations.Add(new DomainListInvertedIndexMap());
            modelBuilder.Configurations.Add(new DoohChannelMap());
            modelBuilder.Configurations.Add(new DoohFormatMap());
            modelBuilder.Configurations.Add(new DoohGeoLocationGroupMap());
            modelBuilder.Configurations.Add(new DoohLocationMap());
            modelBuilder.Configurations.Add(new DoohPanelMap());
            modelBuilder.Configurations.Add(new DoohPanelLocationMap());
            modelBuilder.Configurations.Add(new EntityLabelMap());
            modelBuilder.Configurations.Add(new EntityUserTagMap());
            modelBuilder.Configurations.Add(new ExchangeBuyerIdLookupMap());
            modelBuilder.Configurations.Add(new ExchangeConfigurationMap());
            modelBuilder.Configurations.Add(new ExelateImportMap());
            modelBuilder.Configurations.Add(new ExpandableActionMap());
            modelBuilder.Configurations.Add(new ExpandableDirectionMap());
            modelBuilder.Configurations.Add(new EyeotaRateCardMap());
            modelBuilder.Configurations.Add(new EyeotaTaxonomyImportMap());
            modelBuilder.Configurations.Add(new FrequencyCapMap());
            modelBuilder.Configurations.Add(new FrequencyGroupMap());
            modelBuilder.Configurations.Add(new GeoAbsRegionMap());
            modelBuilder.Configurations.Add(new GeoCityMap());
            modelBuilder.Configurations.Add(new GeoCountryMap());
            modelBuilder.Configurations.Add(new GeoLocationMap());
            modelBuilder.Configurations.Add(new GeoMetroMap());
            modelBuilder.Configurations.Add(new GeoRegionMap());
            modelBuilder.Configurations.Add(new GeoSuburbMap());
            modelBuilder.Configurations.Add(new GoalTypeMap());
            modelBuilder.Configurations.Add(new IkonProgrammaticReportMap());
            modelBuilder.Configurations.Add(new IndustryCategoryMap());
            modelBuilder.Configurations.Add(new IntervalMap());
            modelBuilder.Configurations.Add(new InventoryMap());
            modelBuilder.Configurations.Add(new JobHistoryMap());
            modelBuilder.Configurations.Add(new LabelMap());
            modelBuilder.Configurations.Add(new LanguageMap());
            modelBuilder.Configurations.Add(new LanguageMappingMap());
            modelBuilder.Configurations.Add(new LocalizedGeoCityMap());
            modelBuilder.Configurations.Add(new LocalizedGeoCountryMap());
            modelBuilder.Configurations.Add(new LocalizedGeoRegionMap());
            modelBuilder.Configurations.Add(new MediaTypeMap());
            modelBuilder.Configurations.Add(new MindshareTemplateParameterMap());
            modelBuilder.Configurations.Add(new MobileCarrierMap());
            modelBuilder.Configurations.Add(new MonthlyCreditMap());
            modelBuilder.Configurations.Add(new NewDayPartMappingMap());
            modelBuilder.Configurations.Add(new OptimizationModelMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderLineMap());
            modelBuilder.Configurations.Add(new PacingStyleMap());
            modelBuilder.Configurations.Add(new PagePositionMap());
            modelBuilder.Configurations.Add(new PartnerMap());
            modelBuilder.Configurations.Add(new PartnerDefaultBuyerMap());
            modelBuilder.Configurations.Add(new PaymentTermMap());
            modelBuilder.Configurations.Add(new PixelTagServerMap());
            modelBuilder.Configurations.Add(new PixelTagTemplateMap());
            modelBuilder.Configurations.Add(new PlacementMap());
            modelBuilder.Configurations.Add(new PlacementPerformanceMap());
            modelBuilder.Configurations.Add(new PrivateMarketMap());
            modelBuilder.Configurations.Add(new PrivateMarketModeMap());
            modelBuilder.Configurations.Add(new PrivateMarketPerformanceMap());
            modelBuilder.Configurations.Add(new PrivateMarketSiteMap());
            modelBuilder.Configurations.Add(new PrivateMarketSitePerformanceMap());
            modelBuilder.Configurations.Add(new PrivateMarketSiteStatuMap());
            modelBuilder.Configurations.Add(new PrivateMarketStatuMap());
            modelBuilder.Configurations.Add(new ProductCategoryMap());
            modelBuilder.Configurations.Add(new ProviderBrandSafetyTypeMap());
            modelBuilder.Configurations.Add(new PublisherMap());
            modelBuilder.Configurations.Add(new ReportAggregationLevelMap());
            modelBuilder.Configurations.Add(new ReportJobMap());
            modelBuilder.Configurations.Add(new ReportScheduleMap());
            modelBuilder.Configurations.Add(new ReportTypeMap());
            modelBuilder.Configurations.Add(new RetryLogMap());
            modelBuilder.Configurations.Add(new SalesRegionMap());
            modelBuilder.Configurations.Add(new SchemaMigrationMap());
            modelBuilder.Configurations.Add(new SegmentMap());
            modelBuilder.Configurations.Add(new SegmentPerformanceMap());
            modelBuilder.Configurations.Add(new SegmentReportMap());
            modelBuilder.Configurations.Add(new SegmentThirdPartyTargetingMap());
            modelBuilder.Configurations.Add(new SegmentTypeMap());
            modelBuilder.Configurations.Add(new SensitiveCategoryMap());
            modelBuilder.Configurations.Add(new SharingSegmentMap());
            modelBuilder.Configurations.Add(new SiteLevelOptimisationOverrideMap());
            modelBuilder.Configurations.Add(new SiteListLookupMap());
            modelBuilder.Configurations.Add(new SiteListOptionMap());
            modelBuilder.Configurations.Add(new SiteMetaAndDetailMap());
            modelBuilder.Configurations.Add(new SupplySourceMap());
            modelBuilder.Configurations.Add(new SupportedMobileCarriersViewMap());
            modelBuilder.Configurations.Add(new SysdiagramMap());
            modelBuilder.Configurations.Add(new SystemBlackListWebsiteMap());
            modelBuilder.Configurations.Add(new SystemFeatureMap());
            modelBuilder.Configurations.Add(new SystemSpendLimitMap());
            modelBuilder.Configurations.Add(new TargetingActionMap());
            modelBuilder.Configurations.Add(new TargetingAttributeTypeMap());
            modelBuilder.Configurations.Add(new TechnologyMap());
            modelBuilder.Configurations.Add(new ThemeMap());
            modelBuilder.Configurations.Add(new ThirdPartyCampaignMap());
            modelBuilder.Configurations.Add(new ThirdPartyCampaignBuyerAccountMap());
            modelBuilder.Configurations.Add(new ThirdPartyDataSetMap());
            modelBuilder.Configurations.Add(new ThirdPartyRatecardImportMap());
            modelBuilder.Configurations.Add(new ThirdPartySegmentImportMap());
            modelBuilder.Configurations.Add(new ThirdPartyTaxonomyMap());
            modelBuilder.Configurations.Add(new ThirdPartyTaxonomyRateCardMap());
            modelBuilder.Configurations.Add(new TimeSpanMap());
            modelBuilder.Configurations.Add(new TimeZoneMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserAdvertiserRoleMap());
            modelBuilder.Configurations.Add(new UserBuyerRoleMap());
            modelBuilder.Configurations.Add(new UserTagMap());
            modelBuilder.Configurations.Add(new VerticalMap());
            modelBuilder.Configurations.Add(new VerticalMappingMap());
            modelBuilder.Configurations.Add(new VerticalMappingMigrationAccessLogMap());
            modelBuilder.Configurations.Add(new VerticalStringReferenceToViDsMappingMap());
            modelBuilder.Configurations.Add(new VerticalViewMap());

            OnModelCreatingPartial(modelBuilder);
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AccountsReceivableRtbViewMap(schema));
            modelBuilder.Configurations.Add(new ActiveAdGroupLookupMap(schema));
            modelBuilder.Configurations.Add(new ActiveAdLookupMap(schema));
            modelBuilder.Configurations.Add(new ActiveCampaignLookupMap(schema));
            modelBuilder.Configurations.Add(new ActiveSegmentLookupMap(schema));
            modelBuilder.Configurations.Add(new AdGroupMap(schema));
            modelBuilder.Configurations.Add(new AdGroupAllDomainListMap(schema));
            modelBuilder.Configurations.Add(new AdGroupApplicationParameterMap(schema));
            modelBuilder.Configurations.Add(new AdGroupAttachedDomainListMap(schema));
            modelBuilder.Configurations.Add(new AdGroupBinomialDomainFilterOverrideMap(schema));
            modelBuilder.Configurations.Add(new AdGroupBinomialDomainFilterTargetingViewMap(schema));
            modelBuilder.Configurations.Add(new AdGroupBinomialFilterOverrideMap(schema));
            modelBuilder.Configurations.Add(new AdGroupBinomialFilterTargetingViewMap(schema));
            modelBuilder.Configurations.Add(new AdGroupBrandSafetyMap(schema));
            modelBuilder.Configurations.Add(new AdGroupBrandSafetyBackupMap(schema));
            modelBuilder.Configurations.Add(new AdGroupBrandSafetyViewMap(schema));
            modelBuilder.Configurations.Add(new AdGroupContextualFeeMap(schema));
            modelBuilder.Configurations.Add(new AdGroupDayPartMap(schema));
            modelBuilder.Configurations.Add(new AdGroupDealMap(schema));
            modelBuilder.Configurations.Add(new AdGroupDeviceMap(schema));
            modelBuilder.Configurations.Add(new AdGroupDomainListMap(schema));
            modelBuilder.Configurations.Add(new AdGroupDoohGeoLocationGroupMap(schema));
            modelBuilder.Configurations.Add(new AdGroupDoohPanelLocationMap(schema));
            modelBuilder.Configurations.Add(new AdGroupGeoLocationMap(schema));
            modelBuilder.Configurations.Add(new AdGroupGeoLocationPointRadiusMap(schema));
            modelBuilder.Configurations.Add(new AdGroupGeoPostcodeMap(schema));
            modelBuilder.Configurations.Add(new AdGroupInheritedDomainListMap(schema));
            modelBuilder.Configurations.Add(new AdGroupInventoryMap(schema));
            modelBuilder.Configurations.Add(new AdGroupLanguageMap(schema));
            modelBuilder.Configurations.Add(new AdGroupMobileCarrierMap(schema));
            modelBuilder.Configurations.Add(new AdGroupNotificationMap(schema));
            modelBuilder.Configurations.Add(new AdGroupNotificationTypeMap(schema));
            modelBuilder.Configurations.Add(new AdGroupPagePositionMap(schema));
            modelBuilder.Configurations.Add(new AdGroupPerformanceMap(schema));
            modelBuilder.Configurations.Add(new AdGroupPublisherMap(schema));
            modelBuilder.Configurations.Add(new AdGroupSegmentMap(schema));
            modelBuilder.Configurations.Add(new AdGroupSloRateLookupMap(schema));
            modelBuilder.Configurations.Add(new AdGroupSupplySourceMap(schema));
            modelBuilder.Configurations.Add(new AdGroupTargetingPerformanceMap(schema));
            modelBuilder.Configurations.Add(new AdGroupTargetingViewMap(schema));
            modelBuilder.Configurations.Add(new AdGroupVerticalMap(schema));
            modelBuilder.Configurations.Add(new AdGroupVerticalBeforeMigrationMap(schema));
            modelBuilder.Configurations.Add(new AdGroupVerticalMappingMigrationLogMap(schema));
            modelBuilder.Configurations.Add(new AdGroupVerticalTargetingMigrationMap(schema));
            modelBuilder.Configurations.Add(new AdGroupVerticalTargetingViewMap(schema));
            modelBuilder.Configurations.Add(new AdGroupWithBrandSafetyMap(schema));
            modelBuilder.Configurations.Add(new AdSlotMap(schema));
            modelBuilder.Configurations.Add(new AdTagServerMap(schema));
            modelBuilder.Configurations.Add(new AdTagTemplateMap(schema));
            modelBuilder.Configurations.Add(new AdvertiserMap(schema));
            modelBuilder.Configurations.Add(new AdvertiserApplicationParameterMap(schema));
            modelBuilder.Configurations.Add(new AdvertiserBlackListChangeLogMap(schema));
            modelBuilder.Configurations.Add(new AdvertiserBlackListWebsiteMap(schema));
            modelBuilder.Configurations.Add(new AdvertiserBrandSafetyMap(schema));
            modelBuilder.Configurations.Add(new AdvertiserBrandSafetyBackupMap(schema));
            modelBuilder.Configurations.Add(new AdvertiserDomainListMap(schema));
            modelBuilder.Configurations.Add(new AdvertiserPerformanceMap(schema));
            modelBuilder.Configurations.Add(new AdvertiserProductMap(schema));
            modelBuilder.Configurations.Add(new AdvertiserProductBrandSafetyMap(schema));
            modelBuilder.Configurations.Add(new AdvertiserProductBrandSafetyBackupMap(schema));
            modelBuilder.Configurations.Add(new AdvertiserProductDomainListMap(schema));
            modelBuilder.Configurations.Add(new AdvertiserProductPerformanceMap(schema));
            modelBuilder.Configurations.Add(new AdvertiserReviewMap(schema));
            modelBuilder.Configurations.Add(new AttributionCountingModeMap(schema));
            modelBuilder.Configurations.Add(new AttributionModelMap(schema));
            modelBuilder.Configurations.Add(new BaiduSegmentMap(schema));
            modelBuilder.Configurations.Add(new BaiduSegmentsAlternateMap(schema));
            modelBuilder.Configurations.Add(new BillingCycleMap(schema));
            modelBuilder.Configurations.Add(new BillingPeriodMap(schema));
            modelBuilder.Configurations.Add(new BillingTypeMap(schema));
            modelBuilder.Configurations.Add(new BinomialGlobalBlackListMap(schema));
            modelBuilder.Configurations.Add(new BinomialGlobalBlackListOverrideMap(schema));
            modelBuilder.Configurations.Add(new BinomialGlobalDomainBlackListMap(schema));
            modelBuilder.Configurations.Add(new BinomialGlobalDomainBlackListOverrideMap(schema));
            modelBuilder.Configurations.Add(new BinomialGlobalDomainFilterMap(schema));
            modelBuilder.Configurations.Add(new BinomialGlobalDomainFilterAlternateMap(schema));
            modelBuilder.Configurations.Add(new BinomialGlobalDomainFilterImportMap(schema));
            modelBuilder.Configurations.Add(new BinomialGlobalFilterMap(schema));
            modelBuilder.Configurations.Add(new BinomialGlobalFilterAlternateMap(schema));
            modelBuilder.Configurations.Add(new BinomialGlobalFilterImportMap(schema));
            modelBuilder.Configurations.Add(new BinomialLocalBlackListMap(schema));
            modelBuilder.Configurations.Add(new BinomialLocalDomainBlackListMap(schema));
            modelBuilder.Configurations.Add(new BinomialLocalDomainFilterMap(schema));
            modelBuilder.Configurations.Add(new BinomialLocalDomainFilterAlternateMap(schema));
            modelBuilder.Configurations.Add(new BinomialLocalDomainFilterImportMap(schema));
            modelBuilder.Configurations.Add(new BinomialLocalFilterMap(schema));
            modelBuilder.Configurations.Add(new BinomialLocalFilterAlternateMap(schema));
            modelBuilder.Configurations.Add(new BinomialLocalFilterImportMap(schema));
            modelBuilder.Configurations.Add(new BrandSafetyMap(schema));
            modelBuilder.Configurations.Add(new BrandSafetyChangeLogMap(schema));
            modelBuilder.Configurations.Add(new BrandSafetyLevelMap(schema));
            modelBuilder.Configurations.Add(new BrandSafetyModeMap(schema));
            modelBuilder.Configurations.Add(new BrandSafetyTypeMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountAdTagTemplateFeeMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountApplicationMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountApplicationAdTagServerMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountApplicationAdTagTemplateMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountApplicationAudienceDataProviderMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountApplicationCreativeSizeMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountApplicationDataProviderMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountApplicationGeoCountryMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountApplicationLanguageMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountApplicationParameterMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountApplicationPartnerMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountApplicationPixelTagServerMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountApplicationTranslationMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountBlackListChangeLogMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountBlackListWebsiteMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountBrandSafetyMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountBrandSafetyBackupMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountContextualProviderFeeMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountDomainListMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountExcludedInventoryMap(schema));
            modelBuilder.Configurations.Add(new BuyerAccountPartnerSeatViewMap(schema));
            modelBuilder.Configurations.Add(new CampaignMap(schema));
            modelBuilder.Configurations.Add(new CampaignBrandSafetyMap(schema));
            modelBuilder.Configurations.Add(new CampaignBrandSafetyBackupMap(schema));
            modelBuilder.Configurations.Add(new CampaignDomainListMap(schema));
            modelBuilder.Configurations.Add(new CampaignMarginMap(schema));
            modelBuilder.Configurations.Add(new CampaignPerformanceMap(schema));
            modelBuilder.Configurations.Add(new CampaignPeriodMap(schema));
            modelBuilder.Configurations.Add(new CampaignStatusMap(schema));
            modelBuilder.Configurations.Add(new ChangeLogMap(schema));
            modelBuilder.Configurations.Add(new ChangeLogCommentMap(schema));
            modelBuilder.Configurations.Add(new CompanyTypeMap(schema));
            modelBuilder.Configurations.Add(new ConstraintReasonMap(schema));
            modelBuilder.Configurations.Add(new ContextualProviderFeeMap(schema));
            modelBuilder.Configurations.Add(new CountryMap(schema));
            modelBuilder.Configurations.Add(new CountryContextualProviderFeeMap(schema));
            modelBuilder.Configurations.Add(new CreativeMap(schema));
            modelBuilder.Configurations.Add(new CreativeAttributeMap(schema));
            modelBuilder.Configurations.Add(new CreativeAuditStatuMap(schema));
            modelBuilder.Configurations.Add(new CreativeConversionSegmentMongoExportViewMap(schema));
            modelBuilder.Configurations.Add(new CreativeFileMap(schema));
            modelBuilder.Configurations.Add(new CreativeFileStatuMap(schema));
            modelBuilder.Configurations.Add(new CreativeMongoExportViewMap(schema));
            modelBuilder.Configurations.Add(new CreativeParameterMap(schema));
            modelBuilder.Configurations.Add(new CreativeReviewMap(schema));
            modelBuilder.Configurations.Add(new CreativeReviewConfigurationMap(schema));
            modelBuilder.Configurations.Add(new CreativeReviewLookupMap(schema));
            modelBuilder.Configurations.Add(new CreativeReviewRejectionMap(schema));
            modelBuilder.Configurations.Add(new CreativeReviewStatusMap(schema));
            modelBuilder.Configurations.Add(new CreativeSizeMap(schema));
            modelBuilder.Configurations.Add(new CreativeSourceTypeMap(schema));
            modelBuilder.Configurations.Add(new CreativeSpecificationMap(schema));
            modelBuilder.Configurations.Add(new CreativeTypeMap(schema));
            modelBuilder.Configurations.Add(new CurrencyMap(schema));
            modelBuilder.Configurations.Add(new CustomCreativeParameterMap(schema));
            modelBuilder.Configurations.Add(new CustomCreativeTechnologyMap(schema));
            modelBuilder.Configurations.Add(new CustomPublisherListMap(schema));
            modelBuilder.Configurations.Add(new CustomWhiteListMap(schema));
            modelBuilder.Configurations.Add(new CustomWhiteListChangeLogMap(schema));
            modelBuilder.Configurations.Add(new CustomWhiteListWebsiteMap(schema));
            modelBuilder.Configurations.Add(new DataSegmentViewMap(schema));
            modelBuilder.Configurations.Add(new DayPartMap(schema));
            modelBuilder.Configurations.Add(new DealMap(schema));
            modelBuilder.Configurations.Add(new DealModeMap(schema));
            modelBuilder.Configurations.Add(new DealPerformanceMap(schema));
            modelBuilder.Configurations.Add(new DealTypeMap(schema));
            modelBuilder.Configurations.Add(new DeviceMap(schema));
            modelBuilder.Configurations.Add(new DomainMap(schema));
            modelBuilder.Configurations.Add(new DomainListMap(schema));
            modelBuilder.Configurations.Add(new DomainListInvertedIndexMap(schema));
            modelBuilder.Configurations.Add(new DoohChannelMap(schema));
            modelBuilder.Configurations.Add(new DoohFormatMap(schema));
            modelBuilder.Configurations.Add(new DoohGeoLocationGroupMap(schema));
            modelBuilder.Configurations.Add(new DoohLocationMap(schema));
            modelBuilder.Configurations.Add(new DoohPanelMap(schema));
            modelBuilder.Configurations.Add(new DoohPanelLocationMap(schema));
            modelBuilder.Configurations.Add(new EntityLabelMap(schema));
            modelBuilder.Configurations.Add(new EntityUserTagMap(schema));
            modelBuilder.Configurations.Add(new ExchangeBuyerIdLookupMap(schema));
            modelBuilder.Configurations.Add(new ExchangeConfigurationMap(schema));
            modelBuilder.Configurations.Add(new ExelateImportMap(schema));
            modelBuilder.Configurations.Add(new ExpandableActionMap(schema));
            modelBuilder.Configurations.Add(new ExpandableDirectionMap(schema));
            modelBuilder.Configurations.Add(new EyeotaRateCardMap(schema));
            modelBuilder.Configurations.Add(new EyeotaTaxonomyImportMap(schema));
            modelBuilder.Configurations.Add(new FrequencyCapMap(schema));
            modelBuilder.Configurations.Add(new FrequencyGroupMap(schema));
            modelBuilder.Configurations.Add(new GeoAbsRegionMap(schema));
            modelBuilder.Configurations.Add(new GeoCityMap(schema));
            modelBuilder.Configurations.Add(new GeoCountryMap(schema));
            modelBuilder.Configurations.Add(new GeoLocationMap(schema));
            modelBuilder.Configurations.Add(new GeoMetroMap(schema));
            modelBuilder.Configurations.Add(new GeoRegionMap(schema));
            modelBuilder.Configurations.Add(new GeoSuburbMap(schema));
            modelBuilder.Configurations.Add(new GoalTypeMap(schema));
            modelBuilder.Configurations.Add(new IkonProgrammaticReportMap(schema));
            modelBuilder.Configurations.Add(new IndustryCategoryMap(schema));
            modelBuilder.Configurations.Add(new IntervalMap(schema));
            modelBuilder.Configurations.Add(new InventoryMap(schema));
            modelBuilder.Configurations.Add(new JobHistoryMap(schema));
            modelBuilder.Configurations.Add(new LabelMap(schema));
            modelBuilder.Configurations.Add(new LanguageMap(schema));
            modelBuilder.Configurations.Add(new LanguageMappingMap(schema));
            modelBuilder.Configurations.Add(new LocalizedGeoCityMap(schema));
            modelBuilder.Configurations.Add(new LocalizedGeoCountryMap(schema));
            modelBuilder.Configurations.Add(new LocalizedGeoRegionMap(schema));
            modelBuilder.Configurations.Add(new MediaTypeMap(schema));
            modelBuilder.Configurations.Add(new MindshareTemplateParameterMap(schema));
            modelBuilder.Configurations.Add(new MobileCarrierMap(schema));
            modelBuilder.Configurations.Add(new MonthlyCreditMap(schema));
            modelBuilder.Configurations.Add(new NewDayPartMappingMap(schema));
            modelBuilder.Configurations.Add(new OptimizationModelMap(schema));
            modelBuilder.Configurations.Add(new OrderMap(schema));
            modelBuilder.Configurations.Add(new OrderLineMap(schema));
            modelBuilder.Configurations.Add(new PacingStyleMap(schema));
            modelBuilder.Configurations.Add(new PagePositionMap(schema));
            modelBuilder.Configurations.Add(new PartnerMap(schema));
            modelBuilder.Configurations.Add(new PartnerDefaultBuyerMap(schema));
            modelBuilder.Configurations.Add(new PaymentTermMap(schema));
            modelBuilder.Configurations.Add(new PixelTagServerMap(schema));
            modelBuilder.Configurations.Add(new PixelTagTemplateMap(schema));
            modelBuilder.Configurations.Add(new PlacementMap(schema));
            modelBuilder.Configurations.Add(new PlacementPerformanceMap(schema));
            modelBuilder.Configurations.Add(new PrivateMarketMap(schema));
            modelBuilder.Configurations.Add(new PrivateMarketModeMap(schema));
            modelBuilder.Configurations.Add(new PrivateMarketPerformanceMap(schema));
            modelBuilder.Configurations.Add(new PrivateMarketSiteMap(schema));
            modelBuilder.Configurations.Add(new PrivateMarketSitePerformanceMap(schema));
            modelBuilder.Configurations.Add(new PrivateMarketSiteStatuMap(schema));
            modelBuilder.Configurations.Add(new PrivateMarketStatuMap(schema));
            modelBuilder.Configurations.Add(new ProductCategoryMap(schema));
            modelBuilder.Configurations.Add(new ProviderBrandSafetyTypeMap(schema));
            modelBuilder.Configurations.Add(new PublisherMap(schema));
            modelBuilder.Configurations.Add(new ReportAggregationLevelMap(schema));
            modelBuilder.Configurations.Add(new ReportJobMap(schema));
            modelBuilder.Configurations.Add(new ReportScheduleMap(schema));
            modelBuilder.Configurations.Add(new ReportTypeMap(schema));
            modelBuilder.Configurations.Add(new RetryLogMap(schema));
            modelBuilder.Configurations.Add(new SalesRegionMap(schema));
            modelBuilder.Configurations.Add(new SchemaMigrationMap(schema));
            modelBuilder.Configurations.Add(new SegmentMap(schema));
            modelBuilder.Configurations.Add(new SegmentPerformanceMap(schema));
            modelBuilder.Configurations.Add(new SegmentReportMap(schema));
            modelBuilder.Configurations.Add(new SegmentThirdPartyTargetingMap(schema));
            modelBuilder.Configurations.Add(new SegmentTypeMap(schema));
            modelBuilder.Configurations.Add(new SensitiveCategoryMap(schema));
            modelBuilder.Configurations.Add(new SharingSegmentMap(schema));
            modelBuilder.Configurations.Add(new SiteLevelOptimisationOverrideMap(schema));
            modelBuilder.Configurations.Add(new SiteListLookupMap(schema));
            modelBuilder.Configurations.Add(new SiteListOptionMap(schema));
            modelBuilder.Configurations.Add(new SiteMetaAndDetailMap(schema));
            modelBuilder.Configurations.Add(new SupplySourceMap(schema));
            modelBuilder.Configurations.Add(new SupportedMobileCarriersViewMap(schema));
            modelBuilder.Configurations.Add(new SysdiagramMap(schema));
            modelBuilder.Configurations.Add(new SystemBlackListWebsiteMap(schema));
            modelBuilder.Configurations.Add(new SystemFeatureMap(schema));
            modelBuilder.Configurations.Add(new SystemSpendLimitMap(schema));
            modelBuilder.Configurations.Add(new TargetingActionMap(schema));
            modelBuilder.Configurations.Add(new TargetingAttributeTypeMap(schema));
            modelBuilder.Configurations.Add(new TechnologyMap(schema));
            modelBuilder.Configurations.Add(new ThemeMap(schema));
            modelBuilder.Configurations.Add(new ThirdPartyCampaignMap(schema));
            modelBuilder.Configurations.Add(new ThirdPartyCampaignBuyerAccountMap(schema));
            modelBuilder.Configurations.Add(new ThirdPartyDataSetMap(schema));
            modelBuilder.Configurations.Add(new ThirdPartyRatecardImportMap(schema));
            modelBuilder.Configurations.Add(new ThirdPartySegmentImportMap(schema));
            modelBuilder.Configurations.Add(new ThirdPartyTaxonomyMap(schema));
            modelBuilder.Configurations.Add(new ThirdPartyTaxonomyRateCardMap(schema));
            modelBuilder.Configurations.Add(new TimeSpanMap(schema));
            modelBuilder.Configurations.Add(new TimeZoneMap(schema));
            modelBuilder.Configurations.Add(new UserMap(schema));
            modelBuilder.Configurations.Add(new UserAdvertiserRoleMap(schema));
            modelBuilder.Configurations.Add(new UserBuyerRoleMap(schema));
            modelBuilder.Configurations.Add(new UserTagMap(schema));
            modelBuilder.Configurations.Add(new VerticalMap(schema));
            modelBuilder.Configurations.Add(new VerticalMappingMap(schema));
            modelBuilder.Configurations.Add(new VerticalMappingMigrationAccessLogMap(schema));
            modelBuilder.Configurations.Add(new VerticalStringReferenceToViDsMappingMap(schema));
            modelBuilder.Configurations.Add(new VerticalViewMap(schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void OnModelCreatingPartial(DbModelBuilder modelBuilder);
        
        // Stored Procedures
        public int CascadeDelete(int? entityType, Guid? uuid)
        {
            var entityTypeParam = new SqlParameter { ParameterName = "@EntityType", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = entityType.GetValueOrDefault() };
            if (!entityType.HasValue)
                entityTypeParam.Value = DBNull.Value;

            var uuidParam = new SqlParameter { ParameterName = "@Uuid", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Input, Value = uuid.GetValueOrDefault() };
            if (!uuid.HasValue)
                uuidParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[CascadeDelete] @EntityType, @Uuid", entityTypeParam, uuidParam, procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int EnsureAllPrivateMarketSiteAndPerformanceRowsExist()
        {
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[EnsureAllPrivateMarketSiteAndPerformanceRowsExist] ", procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int FlipBinomialGlobalDomainFilterTables()
        {
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[FlipBinomialGlobalDomainFilterTables] ", procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int FlipBinomialGlobalFilterTables()
        {
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[FlipBinomialGlobalFilterTables] ", procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int FlipBinomialLocalDomainFilterTables()
        {
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[FlipBinomialLocalDomainFilterTables] ", procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int FlipBinomialLocalFilterTables()
        {
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[FlipBinomialLocalFilterTables] ", procResultParam);
 
            return (int) procResultParam.Value;
        }

        public List<GetAdGroupLifeTimeReturnModel> GetAdGroupLifeTime(Guid? buyerAccountId, Guid? advertiserId, Guid? productId, Guid? campaignId, Guid? adGroupId)
        {
            int procResult;
            return GetAdGroupLifeTime(buyerAccountId, advertiserId, productId, campaignId, adGroupId, out procResult);
        }

        public List<GetAdGroupLifeTimeReturnModel> GetAdGroupLifeTime(Guid? buyerAccountId, Guid? advertiserId, Guid? productId, Guid? campaignId, Guid? adGroupId, out int procResult)
        {
            var buyerAccountIdParam = new SqlParameter { ParameterName = "@buyerAccountId", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Input, Value = buyerAccountId.GetValueOrDefault() };
            if (!buyerAccountId.HasValue)
                buyerAccountIdParam.Value = DBNull.Value;

            var advertiserIdParam = new SqlParameter { ParameterName = "@advertiserId", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Input, Value = advertiserId.GetValueOrDefault() };
            if (!advertiserId.HasValue)
                advertiserIdParam.Value = DBNull.Value;

            var productIdParam = new SqlParameter { ParameterName = "@productId", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Input, Value = productId.GetValueOrDefault() };
            if (!productId.HasValue)
                productIdParam.Value = DBNull.Value;

            var campaignIdParam = new SqlParameter { ParameterName = "@campaignId", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Input, Value = campaignId.GetValueOrDefault() };
            if (!campaignId.HasValue)
                campaignIdParam.Value = DBNull.Value;

            var adGroupIdParam = new SqlParameter { ParameterName = "@adGroupId", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Input, Value = adGroupId.GetValueOrDefault() };
            if (!adGroupId.HasValue)
                adGroupIdParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            var procResultData = Database.SqlQuery<GetAdGroupLifeTimeReturnModel>("EXEC @procResult = [dbo].[GetAdGroupLifeTime] @buyerAccountId, @advertiserId, @productId, @campaignId, @adGroupId", buyerAccountIdParam, advertiserIdParam, productIdParam, campaignIdParam, adGroupIdParam, procResultParam).ToList();
 
            procResult = (int) procResultParam.Value;
            return procResultData;
        }

        public List<GetProductCategoryConversionRatesReturnModel> GetProductCategoryConversionRates()
        {
            int procResult;
            return GetProductCategoryConversionRates(out procResult);
        }

        public List<GetProductCategoryConversionRatesReturnModel> GetProductCategoryConversionRates( out int procResult)
        {
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            var procResultData = Database.SqlQuery<GetProductCategoryConversionRatesReturnModel>("EXEC @procResult = [dbo].[GetProductCategoryConversionRates] ", procResultParam).ToList();
 
            procResult = (int) procResultParam.Value;
            return procResultData;
        }

        public int ImportBinomialFilterData(string tableName, string jobId, string filePath, string fieldTerminator)
        {
            var tableNameParam = new SqlParameter { ParameterName = "@TableName", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = tableName, Size = 100 };
            if (tableNameParam.Value == null)
                tableNameParam.Value = DBNull.Value;

            var jobIdParam = new SqlParameter { ParameterName = "@JobID", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = jobId, Size = 500 };
            if (jobIdParam.Value == null)
                jobIdParam.Value = DBNull.Value;

            var filePathParam = new SqlParameter { ParameterName = "@FilePath", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = filePath, Size = 1024 };
            if (filePathParam.Value == null)
                filePathParam.Value = DBNull.Value;

            var fieldTerminatorParam = new SqlParameter { ParameterName = "@FieldTerminator", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = fieldTerminator, Size = 2 };
            if (fieldTerminatorParam.Value == null)
                fieldTerminatorParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[ImportBinomialFilterData] @TableName, @JobID, @FilePath, @FieldTerminator", tableNameParam, jobIdParam, filePathParam, fieldTerminatorParam, procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int MigrateTargetingTopLevel(int? adGroupId)
        {
            var adGroupIdParam = new SqlParameter { ParameterName = "@AdGroupID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = adGroupId.GetValueOrDefault() };
            if (!adGroupId.HasValue)
                adGroupIdParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[MigrateTargetingTopLevel] @AdGroupID", adGroupIdParam, procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int RebuildThirdPartySegments(string segmentPrefix)
        {
            var segmentPrefixParam = new SqlParameter { ParameterName = "@segmentPrefix", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = segmentPrefix, Size = 10 };
            if (segmentPrefixParam.Value == null)
                segmentPrefixParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[RebuildThirdPartySegments] @segmentPrefix", segmentPrefixParam, procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int RollBinomialGlobalDomainFilterData()
        {
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[RollBinomialGlobalDomainFilterData] ", procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int RollBinomialGlobalFilterData()
        {
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[RollBinomialGlobalFilterData] ", procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int RollBinomialLocalDomainFilterData()
        {
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[RollBinomialLocalDomainFilterData] ", procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int RollBinomialLocalFilterData()
        {
            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[RollBinomialLocalFilterData] ", procResultParam);
 
            return (int) procResultParam.Value;
        }

        public List<SafetyCheckNoRunnableStrategiesSpendingOverBudgetReturnModel> SafetyCheckNoRunnableStrategiesSpendingOverBudget(decimal? overspendThreshold)
        {
            int procResult;
            return SafetyCheckNoRunnableStrategiesSpendingOverBudget(overspendThreshold, out procResult);
        }

        public List<SafetyCheckNoRunnableStrategiesSpendingOverBudgetReturnModel> SafetyCheckNoRunnableStrategiesSpendingOverBudget(decimal? overspendThreshold, out int procResult)
        {
            var overspendThresholdParam = new SqlParameter { ParameterName = "@overspendThreshold", SqlDbType = SqlDbType.Decimal, Direction = ParameterDirection.Input, Value = overspendThreshold.GetValueOrDefault() };
            if (!overspendThreshold.HasValue)
                overspendThresholdParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            var procResultData = Database.SqlQuery<SafetyCheckNoRunnableStrategiesSpendingOverBudgetReturnModel>("EXEC @procResult = [dbo].[SafetyCheck_NoRunnableStrategiesSpendingOverBudget] @overspendThreshold", overspendThresholdParam, procResultParam).ToList();
 
            procResult = (int) procResultParam.Value;
            return procResultData;
        }

        public List<SafetyCheckNoStrategiesEnabledPastEndDateReturnModel> SafetyCheckNoStrategiesEnabledPastEndDate(DateTime? utcNow)
        {
            int procResult;
            return SafetyCheckNoStrategiesEnabledPastEndDate(utcNow, out procResult);
        }

        public List<SafetyCheckNoStrategiesEnabledPastEndDateReturnModel> SafetyCheckNoStrategiesEnabledPastEndDate(DateTime? utcNow, out int procResult)
        {
            var utcNowParam = new SqlParameter { ParameterName = "@utcNow", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = utcNow.GetValueOrDefault() };
            if (!utcNow.HasValue)
                utcNowParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            var procResultData = Database.SqlQuery<SafetyCheckNoStrategiesEnabledPastEndDateReturnModel>("EXEC @procResult = [dbo].[SafetyCheck_NoStrategiesEnabledPastEndDate] @utcNow", utcNowParam, procResultParam).ToList();
 
            procResult = (int) procResultParam.Value;
            return procResultData;
        }

        public int UpdateCityTargeting(int? adGroupId, byte? targetAction)
        {
            var adGroupIdParam = new SqlParameter { ParameterName = "@adGroupId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = adGroupId.GetValueOrDefault() };
            if (!adGroupId.HasValue)
                adGroupIdParam.Value = DBNull.Value;

            var targetActionParam = new SqlParameter { ParameterName = "@targetAction", SqlDbType = SqlDbType.TinyInt, Direction = ParameterDirection.Input, Value = targetAction.GetValueOrDefault() };
            if (!targetAction.HasValue)
                targetActionParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[UpdateCityTargeting] @adGroupId, @targetAction", adGroupIdParam, targetActionParam, procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int UpdatePublisherTargeting(int? adGroupId, byte? targetAction)
        {
            var adGroupIdParam = new SqlParameter { ParameterName = "@adGroupId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = adGroupId.GetValueOrDefault() };
            if (!adGroupId.HasValue)
                adGroupIdParam.Value = DBNull.Value;

            var targetActionParam = new SqlParameter { ParameterName = "@targetAction", SqlDbType = SqlDbType.TinyInt, Direction = ParameterDirection.Input, Value = targetAction.GetValueOrDefault() };
            if (!targetAction.HasValue)
                targetActionParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[UpdatePublisherTargeting] @adGroupId, @targetAction", adGroupIdParam, targetActionParam, procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int UpdateRegionTargeting(int? adGroupId, byte? targetAction)
        {
            var adGroupIdParam = new SqlParameter { ParameterName = "@adGroupId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = adGroupId.GetValueOrDefault() };
            if (!adGroupId.HasValue)
                adGroupIdParam.Value = DBNull.Value;

            var targetActionParam = new SqlParameter { ParameterName = "@targetAction", SqlDbType = SqlDbType.TinyInt, Direction = ParameterDirection.Input, Value = targetAction.GetValueOrDefault() };
            if (!targetAction.HasValue)
                targetActionParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[UpdateRegionTargeting] @adGroupId, @targetAction", adGroupIdParam, targetActionParam, procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int UpdateVertical2Targeting(int? adGroupId, byte? targetAction)
        {
            var adGroupIdParam = new SqlParameter { ParameterName = "@adGroupId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = adGroupId.GetValueOrDefault() };
            if (!adGroupId.HasValue)
                adGroupIdParam.Value = DBNull.Value;

            var targetActionParam = new SqlParameter { ParameterName = "@targetAction", SqlDbType = SqlDbType.TinyInt, Direction = ParameterDirection.Input, Value = targetAction.GetValueOrDefault() };
            if (!targetAction.HasValue)
                targetActionParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[UpdateVertical2Targeting] @adGroupId, @targetAction", adGroupIdParam, targetActionParam, procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int UpdateVertical3Targeting(int? adGroupId, byte? targetAction)
        {
            var adGroupIdParam = new SqlParameter { ParameterName = "@adGroupId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = adGroupId.GetValueOrDefault() };
            if (!adGroupId.HasValue)
                adGroupIdParam.Value = DBNull.Value;

            var targetActionParam = new SqlParameter { ParameterName = "@targetAction", SqlDbType = SqlDbType.TinyInt, Direction = ParameterDirection.Input, Value = targetAction.GetValueOrDefault() };
            if (!targetAction.HasValue)
                targetActionParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[UpdateVertical3Targeting] @adGroupId, @targetAction", adGroupIdParam, targetActionParam, procResultParam);
 
            return (int) procResultParam.Value;
        }

        public int UpdateWebsiteTargeting(int? adGroupId, byte? targetAction)
        {
            var adGroupIdParam = new SqlParameter { ParameterName = "@adGroupId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = adGroupId.GetValueOrDefault() };
            if (!adGroupId.HasValue)
                adGroupIdParam.Value = DBNull.Value;

            var targetActionParam = new SqlParameter { ParameterName = "@targetAction", SqlDbType = SqlDbType.TinyInt, Direction = ParameterDirection.Input, Value = targetAction.GetValueOrDefault() };
            if (!targetAction.HasValue)
                targetActionParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[UpdateWebsiteTargeting] @adGroupId, @targetAction", adGroupIdParam, targetActionParam, procResultParam);
 
            return (int) procResultParam.Value;
        }

    }

    // ************************************************************************
    // Fake Database context
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public class FakeBrandscreenContext : IBrandscreenContext
    {
        public DbSet<AccountsReceivableRtbView> AccountsReceivableRtbViews { get; set; }
        public DbSet<ActiveAdGroupLookup> ActiveAdGroupLookups { get; set; }
        public DbSet<ActiveAdLookup> ActiveAdLookups { get; set; }
        public DbSet<ActiveCampaignLookup> ActiveCampaignLookups { get; set; }
        public DbSet<ActiveSegmentLookup> ActiveSegmentLookups { get; set; }
        public DbSet<AdGroup> AdGroups { get; set; }
        public DbSet<AdGroupAllDomainList> AdGroupAllDomainLists { get; set; }
        public DbSet<AdGroupApplicationParameter> AdGroupApplicationParameters { get; set; }
        public DbSet<AdGroupAttachedDomainList> AdGroupAttachedDomainLists { get; set; }
        public DbSet<AdGroupBinomialDomainFilterOverride> AdGroupBinomialDomainFilterOverrides { get; set; }
        public DbSet<AdGroupBinomialDomainFilterTargetingView> AdGroupBinomialDomainFilterTargetingViews { get; set; }
        public DbSet<AdGroupBinomialFilterOverride> AdGroupBinomialFilterOverrides { get; set; }
        public DbSet<AdGroupBinomialFilterTargetingView> AdGroupBinomialFilterTargetingViews { get; set; }
        public DbSet<AdGroupBrandSafety> AdGroupBrandSafeties { get; set; }
        public DbSet<AdGroupBrandSafetyBackup> AdGroupBrandSafetyBackups { get; set; }
        public DbSet<AdGroupBrandSafetyView> AdGroupBrandSafetyViews { get; set; }
        public DbSet<AdGroupContextualFee> AdGroupContextualFees { get; set; }
        public DbSet<AdGroupDayPart> AdGroupDayParts { get; set; }
        public DbSet<AdGroupDeal> AdGroupDeals { get; set; }
        public DbSet<AdGroupDevice> AdGroupDevices { get; set; }
        public DbSet<AdGroupDomainList> AdGroupDomainLists { get; set; }
        public DbSet<AdGroupDoohGeoLocationGroup> AdGroupDoohGeoLocationGroups { get; set; }
        public DbSet<AdGroupDoohPanelLocation> AdGroupDoohPanelLocations { get; set; }
        public DbSet<AdGroupGeoLocation> AdGroupGeoLocations { get; set; }
        public DbSet<AdGroupGeoLocationPointRadius> AdGroupGeoLocationPointRadius { get; set; }
        public DbSet<AdGroupGeoPostcode> AdGroupGeoPostcodes { get; set; }
        public DbSet<AdGroupInheritedDomainList> AdGroupInheritedDomainLists { get; set; }
        public DbSet<AdGroupInventory> AdGroupInventories { get; set; }
        public DbSet<AdGroupLanguage> AdGroupLanguages { get; set; }
        public DbSet<AdGroupMobileCarrier> AdGroupMobileCarriers { get; set; }
        public DbSet<AdGroupNotification> AdGroupNotifications { get; set; }
        public DbSet<AdGroupNotificationType> AdGroupNotificationTypes { get; set; }
        public DbSet<AdGroupPagePosition> AdGroupPagePositions { get; set; }
        public DbSet<AdGroupPerformance> AdGroupPerformances { get; set; }
        public DbSet<AdGroupPublisher> AdGroupPublishers { get; set; }
        public DbSet<AdGroupSegment> AdGroupSegments { get; set; }
        public DbSet<AdGroupSloRateLookup> AdGroupSloRateLookups { get; set; }
        public DbSet<AdGroupSupplySource> AdGroupSupplySources { get; set; }
        public DbSet<AdGroupTargetingPerformance> AdGroupTargetingPerformances { get; set; }
        public DbSet<AdGroupTargetingView> AdGroupTargetingViews { get; set; }
        public DbSet<AdGroupVertical> AdGroupVerticals { get; set; }
        public DbSet<AdGroupVerticalBeforeMigration> AdGroupVerticalBeforeMigrations { get; set; }
        public DbSet<AdGroupVerticalMappingMigrationLog> AdGroupVerticalMappingMigrationLogs { get; set; }
        public DbSet<AdGroupVerticalTargetingMigration> AdGroupVerticalTargetingMigrations { get; set; }
        public DbSet<AdGroupVerticalTargetingView> AdGroupVerticalTargetingViews { get; set; }
        public DbSet<AdGroupWithBrandSafety> AdGroupWithBrandSafeties { get; set; }
        public DbSet<AdSlot> AdSlots { get; set; }
        public DbSet<AdTagServer> AdTagServers { get; set; }
        public DbSet<AdTagTemplate> AdTagTemplates { get; set; }
        public DbSet<Advertiser> Advertisers { get; set; }
        public DbSet<AdvertiserApplicationParameter> AdvertiserApplicationParameters { get; set; }
        public DbSet<AdvertiserBlackListChangeLog> AdvertiserBlackListChangeLogs { get; set; }
        public DbSet<AdvertiserBlackListWebsite> AdvertiserBlackListWebsites { get; set; }
        public DbSet<AdvertiserBrandSafety> AdvertiserBrandSafeties { get; set; }
        public DbSet<AdvertiserBrandSafetyBackup> AdvertiserBrandSafetyBackups { get; set; }
        public DbSet<AdvertiserDomainList> AdvertiserDomainLists { get; set; }
        public DbSet<AdvertiserPerformance> AdvertiserPerformances { get; set; }
        public DbSet<AdvertiserProduct> AdvertiserProducts { get; set; }
        public DbSet<AdvertiserProductBrandSafety> AdvertiserProductBrandSafeties { get; set; }
        public DbSet<AdvertiserProductBrandSafetyBackup> AdvertiserProductBrandSafetyBackups { get; set; }
        public DbSet<AdvertiserProductDomainList> AdvertiserProductDomainLists { get; set; }
        public DbSet<AdvertiserProductPerformance> AdvertiserProductPerformances { get; set; }
        public DbSet<AdvertiserReview> AdvertiserReviews { get; set; }
        public DbSet<AttributionCountingMode> AttributionCountingModes { get; set; }
        public DbSet<AttributionModel> AttributionModels { get; set; }
        public DbSet<BaiduSegment> BaiduSegments { get; set; }
        public DbSet<BaiduSegmentsAlternate> BaiduSegmentsAlternates { get; set; }
        public DbSet<BillingCycle> BillingCycles { get; set; }
        public DbSet<BillingPeriod> BillingPeriods { get; set; }
        public DbSet<BillingType> BillingTypes { get; set; }
        public DbSet<BinomialGlobalBlackList> BinomialGlobalBlackLists { get; set; }
        public DbSet<BinomialGlobalBlackListOverride> BinomialGlobalBlackListOverrides { get; set; }
        public DbSet<BinomialGlobalDomainBlackList> BinomialGlobalDomainBlackLists { get; set; }
        public DbSet<BinomialGlobalDomainBlackListOverride> BinomialGlobalDomainBlackListOverrides { get; set; }
        public DbSet<BinomialGlobalDomainFilter> BinomialGlobalDomainFilters { get; set; }
        public DbSet<BinomialGlobalDomainFilterAlternate> BinomialGlobalDomainFilterAlternates { get; set; }
        public DbSet<BinomialGlobalDomainFilterImport> BinomialGlobalDomainFilterImports { get; set; }
        public DbSet<BinomialGlobalFilter> BinomialGlobalFilters { get; set; }
        public DbSet<BinomialGlobalFilterAlternate> BinomialGlobalFilterAlternates { get; set; }
        public DbSet<BinomialGlobalFilterImport> BinomialGlobalFilterImports { get; set; }
        public DbSet<BinomialLocalBlackList> BinomialLocalBlackLists { get; set; }
        public DbSet<BinomialLocalDomainBlackList> BinomialLocalDomainBlackLists { get; set; }
        public DbSet<BinomialLocalDomainFilter> BinomialLocalDomainFilters { get; set; }
        public DbSet<BinomialLocalDomainFilterAlternate> BinomialLocalDomainFilterAlternates { get; set; }
        public DbSet<BinomialLocalDomainFilterImport> BinomialLocalDomainFilterImports { get; set; }
        public DbSet<BinomialLocalFilter> BinomialLocalFilters { get; set; }
        public DbSet<BinomialLocalFilterAlternate> BinomialLocalFilterAlternates { get; set; }
        public DbSet<BinomialLocalFilterImport> BinomialLocalFilterImports { get; set; }
        public DbSet<BrandSafety> BrandSafeties { get; set; }
        public DbSet<BrandSafetyChangeLog> BrandSafetyChangeLogs { get; set; }
        public DbSet<BrandSafetyLevel> BrandSafetyLevels { get; set; }
        public DbSet<BrandSafetyMode> BrandSafetyModes { get; set; }
        public DbSet<BrandSafetyType> BrandSafetyTypes { get; set; }
        public DbSet<BuyerAccount> BuyerAccounts { get; set; }
        public DbSet<BuyerAccountAdTagTemplateFee> BuyerAccountAdTagTemplateFees { get; set; }
        public DbSet<BuyerAccountApplication> BuyerAccountApplications { get; set; }
        public DbSet<BuyerAccountApplicationAdTagServer> BuyerAccountApplicationAdTagServers { get; set; }
        public DbSet<BuyerAccountApplicationAdTagTemplate> BuyerAccountApplicationAdTagTemplates { get; set; }
        public DbSet<BuyerAccountApplicationAudienceDataProvider> BuyerAccountApplicationAudienceDataProviders { get; set; }
        public DbSet<BuyerAccountApplicationCreativeSize> BuyerAccountApplicationCreativeSizes { get; set; }
        public DbSet<BuyerAccountApplicationDataProvider> BuyerAccountApplicationDataProviders { get; set; }
        public DbSet<BuyerAccountApplicationGeoCountry> BuyerAccountApplicationGeoCountries { get; set; }
        public DbSet<BuyerAccountApplicationLanguage> BuyerAccountApplicationLanguages { get; set; }
        public DbSet<BuyerAccountApplicationParameter> BuyerAccountApplicationParameters { get; set; }
        public DbSet<BuyerAccountApplicationPartner> BuyerAccountApplicationPartners { get; set; }
        public DbSet<BuyerAccountApplicationPixelTagServer> BuyerAccountApplicationPixelTagServers { get; set; }
        public DbSet<BuyerAccountApplicationTranslation> BuyerAccountApplicationTranslations { get; set; }
        public DbSet<BuyerAccountBlackListChangeLog> BuyerAccountBlackListChangeLogs { get; set; }
        public DbSet<BuyerAccountBlackListWebsite> BuyerAccountBlackListWebsites { get; set; }
        public DbSet<BuyerAccountBrandSafety> BuyerAccountBrandSafeties { get; set; }
        public DbSet<BuyerAccountBrandSafetyBackup> BuyerAccountBrandSafetyBackups { get; set; }
        public DbSet<BuyerAccountContextualProviderFee> BuyerAccountContextualProviderFees { get; set; }
        public DbSet<BuyerAccountDomainList> BuyerAccountDomainLists { get; set; }
        public DbSet<BuyerAccountExcludedInventory> BuyerAccountExcludedInventories { get; set; }
        public DbSet<BuyerAccountPartnerSeatView> BuyerAccountPartnerSeatViews { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignBrandSafety> CampaignBrandSafeties { get; set; }
        public DbSet<CampaignBrandSafetyBackup> CampaignBrandSafetyBackups { get; set; }
        public DbSet<CampaignDomainList> CampaignDomainLists { get; set; }
        public DbSet<CampaignMargin> CampaignMargins { get; set; }
        public DbSet<CampaignPerformance> CampaignPerformances { get; set; }
        public DbSet<CampaignPeriod> CampaignPeriods { get; set; }
        public DbSet<CampaignStatus> CampaignStatus { get; set; }
        public DbSet<ChangeLog> ChangeLogs { get; set; }
        public DbSet<ChangeLogComment> ChangeLogComments { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<ConstraintReason> ConstraintReasons { get; set; }
        public DbSet<ContextualProviderFee> ContextualProviderFees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryContextualProviderFee> CountryContextualProviderFees { get; set; }
        public DbSet<Creative> Creatives { get; set; }
        public DbSet<CreativeAttribute> CreativeAttributes { get; set; }
        public DbSet<CreativeAuditStatu> CreativeAuditStatus { get; set; }
        public DbSet<CreativeConversionSegmentMongoExportView> CreativeConversionSegmentMongoExportViews { get; set; }
        public DbSet<CreativeFile> CreativeFiles { get; set; }
        public DbSet<CreativeFileStatu> CreativeFileStatus { get; set; }
        public DbSet<CreativeMongoExportView> CreativeMongoExportViews { get; set; }
        public DbSet<CreativeParameter> CreativeParameters { get; set; }
        public DbSet<CreativeReview> CreativeReviews { get; set; }
        public DbSet<CreativeReviewConfiguration> CreativeReviewConfigurations { get; set; }
        public DbSet<CreativeReviewLookup> CreativeReviewLookups { get; set; }
        public DbSet<CreativeReviewRejection> CreativeReviewRejections { get; set; }
        public DbSet<CreativeReviewStatus> CreativeReviewStatus { get; set; }
        public DbSet<CreativeSize> CreativeSizes { get; set; }
        public DbSet<CreativeSourceType> CreativeSourceTypes { get; set; }
        public DbSet<CreativeSpecification> CreativeSpecifications { get; set; }
        public DbSet<CreativeType> CreativeTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CustomCreativeParameter> CustomCreativeParameters { get; set; }
        public DbSet<CustomCreativeTechnology> CustomCreativeTechnologies { get; set; }
        public DbSet<CustomPublisherList> CustomPublisherLists { get; set; }
        public DbSet<CustomWhiteList> CustomWhiteLists { get; set; }
        public DbSet<CustomWhiteListChangeLog> CustomWhiteListChangeLogs { get; set; }
        public DbSet<CustomWhiteListWebsite> CustomWhiteListWebsites { get; set; }
        public DbSet<DataSegmentView> DataSegmentViews { get; set; }
        public DbSet<DayPart> DayParts { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealMode> DealModes { get; set; }
        public DbSet<DealPerformance> DealPerformances { get; set; }
        public DbSet<DealType> DealTypes { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<DomainList> DomainLists { get; set; }
        public DbSet<DomainListInvertedIndex> DomainListInvertedIndexes { get; set; }
        public DbSet<DoohChannel> DoohChannels { get; set; }
        public DbSet<DoohFormat> DoohFormats { get; set; }
        public DbSet<DoohGeoLocationGroup> DoohGeoLocationGroups { get; set; }
        public DbSet<DoohLocation> DoohLocations { get; set; }
        public DbSet<DoohPanel> DoohPanels { get; set; }
        public DbSet<DoohPanelLocation> DoohPanelLocations { get; set; }
        public DbSet<EntityLabel> EntityLabels { get; set; }
        public DbSet<EntityUserTag> EntityUserTags { get; set; }
        public DbSet<ExchangeBuyerIdLookup> ExchangeBuyerIdLookups { get; set; }
        public DbSet<ExchangeConfiguration> ExchangeConfigurations { get; set; }
        public DbSet<ExelateImport> ExelateImports { get; set; }
        public DbSet<ExpandableAction> ExpandableActions { get; set; }
        public DbSet<ExpandableDirection> ExpandableDirections { get; set; }
        public DbSet<EyeotaRateCard> EyeotaRateCards { get; set; }
        public DbSet<EyeotaTaxonomyImport> EyeotaTaxonomyImports { get; set; }
        public DbSet<FrequencyCap> FrequencyCaps { get; set; }
        public DbSet<FrequencyGroup> FrequencyGroups { get; set; }
        public DbSet<GeoAbsRegion> GeoAbsRegions { get; set; }
        public DbSet<GeoCity> GeoCities { get; set; }
        public DbSet<GeoCountry> GeoCountries { get; set; }
        public DbSet<GeoLocation> GeoLocations { get; set; }
        public DbSet<GeoMetro> GeoMetroes { get; set; }
        public DbSet<GeoRegion> GeoRegions { get; set; }
        public DbSet<GeoSuburb> GeoSuburbs { get; set; }
        public DbSet<GoalType> GoalTypes { get; set; }
        public DbSet<IkonProgrammaticReport> IkonProgrammaticReports { get; set; }
        public DbSet<IndustryCategory> IndustryCategories { get; set; }
        public DbSet<Interval> Intervals { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageMapping> LanguageMappings { get; set; }
        public DbSet<LocalizedGeoCity> LocalizedGeoCities { get; set; }
        public DbSet<LocalizedGeoCountry> LocalizedGeoCountries { get; set; }
        public DbSet<LocalizedGeoRegion> LocalizedGeoRegions { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<MindshareTemplateParameter> MindshareTemplateParameters { get; set; }
        public DbSet<MobileCarrier> MobileCarriers { get; set; }
        public DbSet<MonthlyCredit> MonthlyCredits { get; set; }
        public DbSet<NewDayPartMapping> NewDayPartMappings { get; set; }
        public DbSet<OptimizationModel> OptimizationModels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<PacingStyle> PacingStyles { get; set; }
        public DbSet<PagePosition> PagePositions { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerDefaultBuyer> PartnerDefaultBuyers { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<PixelTagServer> PixelTagServers { get; set; }
        public DbSet<PixelTagTemplate> PixelTagTemplates { get; set; }
        public DbSet<Placement> Placements { get; set; }
        public DbSet<PlacementPerformance> PlacementPerformances { get; set; }
        public DbSet<PrivateMarket> PrivateMarkets { get; set; }
        public DbSet<PrivateMarketMode> PrivateMarketModes { get; set; }
        public DbSet<PrivateMarketPerformance> PrivateMarketPerformances { get; set; }
        public DbSet<PrivateMarketSite> PrivateMarketSites { get; set; }
        public DbSet<PrivateMarketSitePerformance> PrivateMarketSitePerformances { get; set; }
        public DbSet<PrivateMarketSiteStatu> PrivateMarketSiteStatus { get; set; }
        public DbSet<PrivateMarketStatu> PrivateMarketStatus { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProviderBrandSafetyType> ProviderBrandSafetyTypes { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<ReportAggregationLevel> ReportAggregationLevels { get; set; }
        public DbSet<ReportJob> ReportJobs { get; set; }
        public DbSet<ReportSchedule> ReportSchedules { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<RetryLog> RetryLogs { get; set; }
        public DbSet<SalesRegion> SalesRegions { get; set; }
        public DbSet<SchemaMigration> SchemaMigrations { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<SegmentPerformance> SegmentPerformances { get; set; }
        public DbSet<SegmentReport> SegmentReports { get; set; }
        public DbSet<SegmentThirdPartyTargeting> SegmentThirdPartyTargetings { get; set; }
        public DbSet<SegmentType> SegmentTypes { get; set; }
        public DbSet<SensitiveCategory> SensitiveCategories { get; set; }
        public DbSet<SharingSegment> SharingSegments { get; set; }
        public DbSet<SiteLevelOptimisationOverride> SiteLevelOptimisationOverrides { get; set; }
        public DbSet<SiteListLookup> SiteListLookups { get; set; }
        public DbSet<SiteListOption> SiteListOptions { get; set; }
        public DbSet<SiteMetaAndDetail> SiteMetaAndDetails { get; set; }
        public DbSet<SupplySource> SupplySources { get; set; }
        public DbSet<SupportedMobileCarriersView> SupportedMobileCarriersViews { get; set; }
        public DbSet<Sysdiagram> Sysdiagrams { get; set; }
        public DbSet<SystemBlackListWebsite> SystemBlackListWebsites { get; set; }
        public DbSet<SystemFeature> SystemFeatures { get; set; }
        public DbSet<SystemSpendLimit> SystemSpendLimits { get; set; }
        public DbSet<TargetingAction> TargetingActions { get; set; }
        public DbSet<TargetingAttributeType> TargetingAttributeTypes { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<ThirdPartyCampaign> ThirdPartyCampaigns { get; set; }
        public DbSet<ThirdPartyCampaignBuyerAccount> ThirdPartyCampaignBuyerAccounts { get; set; }
        public DbSet<ThirdPartyDataSet> ThirdPartyDataSets { get; set; }
        public DbSet<ThirdPartyRatecardImport> ThirdPartyRatecardImports { get; set; }
        public DbSet<ThirdPartySegmentImport> ThirdPartySegmentImports { get; set; }
        public DbSet<ThirdPartyTaxonomy> ThirdPartyTaxonomies { get; set; }
        public DbSet<ThirdPartyTaxonomyRateCard> ThirdPartyTaxonomyRateCards { get; set; }
        public DbSet<TimeSpan> TimeSpans { get; set; }
        public DbSet<TimeZone> TimeZones { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAdvertiserRole> UserAdvertiserRoles { get; set; }
        public DbSet<UserBuyerRole> UserBuyerRoles { get; set; }
        public DbSet<UserTag> UserTags { get; set; }
        public DbSet<Vertical> Verticals { get; set; }
        public DbSet<VerticalMapping> VerticalMappings { get; set; }
        public DbSet<VerticalMappingMigrationAccessLog> VerticalMappingMigrationAccessLogs { get; set; }
        public DbSet<VerticalStringReferenceToViDsMapping> VerticalStringReferenceToViDsMappings { get; set; }
        public DbSet<VerticalView> VerticalViews { get; set; }

        public FakeBrandscreenContext()
        {
            AccountsReceivableRtbViews = new FakeDbSet<AccountsReceivableRtbView>();
            ActiveAdGroupLookups = new FakeDbSet<ActiveAdGroupLookup>();
            ActiveAdLookups = new FakeDbSet<ActiveAdLookup>();
            ActiveCampaignLookups = new FakeDbSet<ActiveCampaignLookup>();
            ActiveSegmentLookups = new FakeDbSet<ActiveSegmentLookup>();
            AdGroups = new FakeDbSet<AdGroup>();
            AdGroupAllDomainLists = new FakeDbSet<AdGroupAllDomainList>();
            AdGroupApplicationParameters = new FakeDbSet<AdGroupApplicationParameter>();
            AdGroupAttachedDomainLists = new FakeDbSet<AdGroupAttachedDomainList>();
            AdGroupBinomialDomainFilterOverrides = new FakeDbSet<AdGroupBinomialDomainFilterOverride>();
            AdGroupBinomialDomainFilterTargetingViews = new FakeDbSet<AdGroupBinomialDomainFilterTargetingView>();
            AdGroupBinomialFilterOverrides = new FakeDbSet<AdGroupBinomialFilterOverride>();
            AdGroupBinomialFilterTargetingViews = new FakeDbSet<AdGroupBinomialFilterTargetingView>();
            AdGroupBrandSafeties = new FakeDbSet<AdGroupBrandSafety>();
            AdGroupBrandSafetyBackups = new FakeDbSet<AdGroupBrandSafetyBackup>();
            AdGroupBrandSafetyViews = new FakeDbSet<AdGroupBrandSafetyView>();
            AdGroupContextualFees = new FakeDbSet<AdGroupContextualFee>();
            AdGroupDayParts = new FakeDbSet<AdGroupDayPart>();
            AdGroupDeals = new FakeDbSet<AdGroupDeal>();
            AdGroupDevices = new FakeDbSet<AdGroupDevice>();
            AdGroupDomainLists = new FakeDbSet<AdGroupDomainList>();
            AdGroupDoohGeoLocationGroups = new FakeDbSet<AdGroupDoohGeoLocationGroup>();
            AdGroupDoohPanelLocations = new FakeDbSet<AdGroupDoohPanelLocation>();
            AdGroupGeoLocations = new FakeDbSet<AdGroupGeoLocation>();
            AdGroupGeoLocationPointRadius = new FakeDbSet<AdGroupGeoLocationPointRadius>();
            AdGroupGeoPostcodes = new FakeDbSet<AdGroupGeoPostcode>();
            AdGroupInheritedDomainLists = new FakeDbSet<AdGroupInheritedDomainList>();
            AdGroupInventories = new FakeDbSet<AdGroupInventory>();
            AdGroupLanguages = new FakeDbSet<AdGroupLanguage>();
            AdGroupMobileCarriers = new FakeDbSet<AdGroupMobileCarrier>();
            AdGroupNotifications = new FakeDbSet<AdGroupNotification>();
            AdGroupNotificationTypes = new FakeDbSet<AdGroupNotificationType>();
            AdGroupPagePositions = new FakeDbSet<AdGroupPagePosition>();
            AdGroupPerformances = new FakeDbSet<AdGroupPerformance>();
            AdGroupPublishers = new FakeDbSet<AdGroupPublisher>();
            AdGroupSegments = new FakeDbSet<AdGroupSegment>();
            AdGroupSloRateLookups = new FakeDbSet<AdGroupSloRateLookup>();
            AdGroupSupplySources = new FakeDbSet<AdGroupSupplySource>();
            AdGroupTargetingPerformances = new FakeDbSet<AdGroupTargetingPerformance>();
            AdGroupTargetingViews = new FakeDbSet<AdGroupTargetingView>();
            AdGroupVerticals = new FakeDbSet<AdGroupVertical>();
            AdGroupVerticalBeforeMigrations = new FakeDbSet<AdGroupVerticalBeforeMigration>();
            AdGroupVerticalMappingMigrationLogs = new FakeDbSet<AdGroupVerticalMappingMigrationLog>();
            AdGroupVerticalTargetingMigrations = new FakeDbSet<AdGroupVerticalTargetingMigration>();
            AdGroupVerticalTargetingViews = new FakeDbSet<AdGroupVerticalTargetingView>();
            AdGroupWithBrandSafeties = new FakeDbSet<AdGroupWithBrandSafety>();
            AdSlots = new FakeDbSet<AdSlot>();
            AdTagServers = new FakeDbSet<AdTagServer>();
            AdTagTemplates = new FakeDbSet<AdTagTemplate>();
            Advertisers = new FakeDbSet<Advertiser>();
            AdvertiserApplicationParameters = new FakeDbSet<AdvertiserApplicationParameter>();
            AdvertiserBlackListChangeLogs = new FakeDbSet<AdvertiserBlackListChangeLog>();
            AdvertiserBlackListWebsites = new FakeDbSet<AdvertiserBlackListWebsite>();
            AdvertiserBrandSafeties = new FakeDbSet<AdvertiserBrandSafety>();
            AdvertiserBrandSafetyBackups = new FakeDbSet<AdvertiserBrandSafetyBackup>();
            AdvertiserDomainLists = new FakeDbSet<AdvertiserDomainList>();
            AdvertiserPerformances = new FakeDbSet<AdvertiserPerformance>();
            AdvertiserProducts = new FakeDbSet<AdvertiserProduct>();
            AdvertiserProductBrandSafeties = new FakeDbSet<AdvertiserProductBrandSafety>();
            AdvertiserProductBrandSafetyBackups = new FakeDbSet<AdvertiserProductBrandSafetyBackup>();
            AdvertiserProductDomainLists = new FakeDbSet<AdvertiserProductDomainList>();
            AdvertiserProductPerformances = new FakeDbSet<AdvertiserProductPerformance>();
            AdvertiserReviews = new FakeDbSet<AdvertiserReview>();
            AttributionCountingModes = new FakeDbSet<AttributionCountingMode>();
            AttributionModels = new FakeDbSet<AttributionModel>();
            BaiduSegments = new FakeDbSet<BaiduSegment>();
            BaiduSegmentsAlternates = new FakeDbSet<BaiduSegmentsAlternate>();
            BillingCycles = new FakeDbSet<BillingCycle>();
            BillingPeriods = new FakeDbSet<BillingPeriod>();
            BillingTypes = new FakeDbSet<BillingType>();
            BinomialGlobalBlackLists = new FakeDbSet<BinomialGlobalBlackList>();
            BinomialGlobalBlackListOverrides = new FakeDbSet<BinomialGlobalBlackListOverride>();
            BinomialGlobalDomainBlackLists = new FakeDbSet<BinomialGlobalDomainBlackList>();
            BinomialGlobalDomainBlackListOverrides = new FakeDbSet<BinomialGlobalDomainBlackListOverride>();
            BinomialGlobalDomainFilters = new FakeDbSet<BinomialGlobalDomainFilter>();
            BinomialGlobalDomainFilterAlternates = new FakeDbSet<BinomialGlobalDomainFilterAlternate>();
            BinomialGlobalDomainFilterImports = new FakeDbSet<BinomialGlobalDomainFilterImport>();
            BinomialGlobalFilters = new FakeDbSet<BinomialGlobalFilter>();
            BinomialGlobalFilterAlternates = new FakeDbSet<BinomialGlobalFilterAlternate>();
            BinomialGlobalFilterImports = new FakeDbSet<BinomialGlobalFilterImport>();
            BinomialLocalBlackLists = new FakeDbSet<BinomialLocalBlackList>();
            BinomialLocalDomainBlackLists = new FakeDbSet<BinomialLocalDomainBlackList>();
            BinomialLocalDomainFilters = new FakeDbSet<BinomialLocalDomainFilter>();
            BinomialLocalDomainFilterAlternates = new FakeDbSet<BinomialLocalDomainFilterAlternate>();
            BinomialLocalDomainFilterImports = new FakeDbSet<BinomialLocalDomainFilterImport>();
            BinomialLocalFilters = new FakeDbSet<BinomialLocalFilter>();
            BinomialLocalFilterAlternates = new FakeDbSet<BinomialLocalFilterAlternate>();
            BinomialLocalFilterImports = new FakeDbSet<BinomialLocalFilterImport>();
            BrandSafeties = new FakeDbSet<BrandSafety>();
            BrandSafetyChangeLogs = new FakeDbSet<BrandSafetyChangeLog>();
            BrandSafetyLevels = new FakeDbSet<BrandSafetyLevel>();
            BrandSafetyModes = new FakeDbSet<BrandSafetyMode>();
            BrandSafetyTypes = new FakeDbSet<BrandSafetyType>();
            BuyerAccounts = new FakeDbSet<BuyerAccount>();
            BuyerAccountAdTagTemplateFees = new FakeDbSet<BuyerAccountAdTagTemplateFee>();
            BuyerAccountApplications = new FakeDbSet<BuyerAccountApplication>();
            BuyerAccountApplicationAdTagServers = new FakeDbSet<BuyerAccountApplicationAdTagServer>();
            BuyerAccountApplicationAdTagTemplates = new FakeDbSet<BuyerAccountApplicationAdTagTemplate>();
            BuyerAccountApplicationAudienceDataProviders = new FakeDbSet<BuyerAccountApplicationAudienceDataProvider>();
            BuyerAccountApplicationCreativeSizes = new FakeDbSet<BuyerAccountApplicationCreativeSize>();
            BuyerAccountApplicationDataProviders = new FakeDbSet<BuyerAccountApplicationDataProvider>();
            BuyerAccountApplicationGeoCountries = new FakeDbSet<BuyerAccountApplicationGeoCountry>();
            BuyerAccountApplicationLanguages = new FakeDbSet<BuyerAccountApplicationLanguage>();
            BuyerAccountApplicationParameters = new FakeDbSet<BuyerAccountApplicationParameter>();
            BuyerAccountApplicationPartners = new FakeDbSet<BuyerAccountApplicationPartner>();
            BuyerAccountApplicationPixelTagServers = new FakeDbSet<BuyerAccountApplicationPixelTagServer>();
            BuyerAccountApplicationTranslations = new FakeDbSet<BuyerAccountApplicationTranslation>();
            BuyerAccountBlackListChangeLogs = new FakeDbSet<BuyerAccountBlackListChangeLog>();
            BuyerAccountBlackListWebsites = new FakeDbSet<BuyerAccountBlackListWebsite>();
            BuyerAccountBrandSafeties = new FakeDbSet<BuyerAccountBrandSafety>();
            BuyerAccountBrandSafetyBackups = new FakeDbSet<BuyerAccountBrandSafetyBackup>();
            BuyerAccountContextualProviderFees = new FakeDbSet<BuyerAccountContextualProviderFee>();
            BuyerAccountDomainLists = new FakeDbSet<BuyerAccountDomainList>();
            BuyerAccountExcludedInventories = new FakeDbSet<BuyerAccountExcludedInventory>();
            BuyerAccountPartnerSeatViews = new FakeDbSet<BuyerAccountPartnerSeatView>();
            Campaigns = new FakeDbSet<Campaign>();
            CampaignBrandSafeties = new FakeDbSet<CampaignBrandSafety>();
            CampaignBrandSafetyBackups = new FakeDbSet<CampaignBrandSafetyBackup>();
            CampaignDomainLists = new FakeDbSet<CampaignDomainList>();
            CampaignMargins = new FakeDbSet<CampaignMargin>();
            CampaignPerformances = new FakeDbSet<CampaignPerformance>();
            CampaignPeriods = new FakeDbSet<CampaignPeriod>();
            CampaignStatus = new FakeDbSet<CampaignStatus>();
            ChangeLogs = new FakeDbSet<ChangeLog>();
            ChangeLogComments = new FakeDbSet<ChangeLogComment>();
            CompanyTypes = new FakeDbSet<CompanyType>();
            ConstraintReasons = new FakeDbSet<ConstraintReason>();
            ContextualProviderFees = new FakeDbSet<ContextualProviderFee>();
            Countries = new FakeDbSet<Country>();
            CountryContextualProviderFees = new FakeDbSet<CountryContextualProviderFee>();
            Creatives = new FakeDbSet<Creative>();
            CreativeAttributes = new FakeDbSet<CreativeAttribute>();
            CreativeAuditStatus = new FakeDbSet<CreativeAuditStatu>();
            CreativeConversionSegmentMongoExportViews = new FakeDbSet<CreativeConversionSegmentMongoExportView>();
            CreativeFiles = new FakeDbSet<CreativeFile>();
            CreativeFileStatus = new FakeDbSet<CreativeFileStatu>();
            CreativeMongoExportViews = new FakeDbSet<CreativeMongoExportView>();
            CreativeParameters = new FakeDbSet<CreativeParameter>();
            CreativeReviews = new FakeDbSet<CreativeReview>();
            CreativeReviewConfigurations = new FakeDbSet<CreativeReviewConfiguration>();
            CreativeReviewLookups = new FakeDbSet<CreativeReviewLookup>();
            CreativeReviewRejections = new FakeDbSet<CreativeReviewRejection>();
            CreativeReviewStatus = new FakeDbSet<CreativeReviewStatus>();
            CreativeSizes = new FakeDbSet<CreativeSize>();
            CreativeSourceTypes = new FakeDbSet<CreativeSourceType>();
            CreativeSpecifications = new FakeDbSet<CreativeSpecification>();
            CreativeTypes = new FakeDbSet<CreativeType>();
            Currencies = new FakeDbSet<Currency>();
            CustomCreativeParameters = new FakeDbSet<CustomCreativeParameter>();
            CustomCreativeTechnologies = new FakeDbSet<CustomCreativeTechnology>();
            CustomPublisherLists = new FakeDbSet<CustomPublisherList>();
            CustomWhiteLists = new FakeDbSet<CustomWhiteList>();
            CustomWhiteListChangeLogs = new FakeDbSet<CustomWhiteListChangeLog>();
            CustomWhiteListWebsites = new FakeDbSet<CustomWhiteListWebsite>();
            DataSegmentViews = new FakeDbSet<DataSegmentView>();
            DayParts = new FakeDbSet<DayPart>();
            Deals = new FakeDbSet<Deal>();
            DealModes = new FakeDbSet<DealMode>();
            DealPerformances = new FakeDbSet<DealPerformance>();
            DealTypes = new FakeDbSet<DealType>();
            Devices = new FakeDbSet<Device>();
            Domains = new FakeDbSet<Domain>();
            DomainLists = new FakeDbSet<DomainList>();
            DomainListInvertedIndexes = new FakeDbSet<DomainListInvertedIndex>();
            DoohChannels = new FakeDbSet<DoohChannel>();
            DoohFormats = new FakeDbSet<DoohFormat>();
            DoohGeoLocationGroups = new FakeDbSet<DoohGeoLocationGroup>();
            DoohLocations = new FakeDbSet<DoohLocation>();
            DoohPanels = new FakeDbSet<DoohPanel>();
            DoohPanelLocations = new FakeDbSet<DoohPanelLocation>();
            EntityLabels = new FakeDbSet<EntityLabel>();
            EntityUserTags = new FakeDbSet<EntityUserTag>();
            ExchangeBuyerIdLookups = new FakeDbSet<ExchangeBuyerIdLookup>();
            ExchangeConfigurations = new FakeDbSet<ExchangeConfiguration>();
            ExelateImports = new FakeDbSet<ExelateImport>();
            ExpandableActions = new FakeDbSet<ExpandableAction>();
            ExpandableDirections = new FakeDbSet<ExpandableDirection>();
            EyeotaRateCards = new FakeDbSet<EyeotaRateCard>();
            EyeotaTaxonomyImports = new FakeDbSet<EyeotaTaxonomyImport>();
            FrequencyCaps = new FakeDbSet<FrequencyCap>();
            FrequencyGroups = new FakeDbSet<FrequencyGroup>();
            GeoAbsRegions = new FakeDbSet<GeoAbsRegion>();
            GeoCities = new FakeDbSet<GeoCity>();
            GeoCountries = new FakeDbSet<GeoCountry>();
            GeoLocations = new FakeDbSet<GeoLocation>();
            GeoMetroes = new FakeDbSet<GeoMetro>();
            GeoRegions = new FakeDbSet<GeoRegion>();
            GeoSuburbs = new FakeDbSet<GeoSuburb>();
            GoalTypes = new FakeDbSet<GoalType>();
            IkonProgrammaticReports = new FakeDbSet<IkonProgrammaticReport>();
            IndustryCategories = new FakeDbSet<IndustryCategory>();
            Intervals = new FakeDbSet<Interval>();
            Inventories = new FakeDbSet<Inventory>();
            JobHistories = new FakeDbSet<JobHistory>();
            Labels = new FakeDbSet<Label>();
            Languages = new FakeDbSet<Language>();
            LanguageMappings = new FakeDbSet<LanguageMapping>();
            LocalizedGeoCities = new FakeDbSet<LocalizedGeoCity>();
            LocalizedGeoCountries = new FakeDbSet<LocalizedGeoCountry>();
            LocalizedGeoRegions = new FakeDbSet<LocalizedGeoRegion>();
            MediaTypes = new FakeDbSet<MediaType>();
            MindshareTemplateParameters = new FakeDbSet<MindshareTemplateParameter>();
            MobileCarriers = new FakeDbSet<MobileCarrier>();
            MonthlyCredits = new FakeDbSet<MonthlyCredit>();
            NewDayPartMappings = new FakeDbSet<NewDayPartMapping>();
            OptimizationModels = new FakeDbSet<OptimizationModel>();
            Orders = new FakeDbSet<Order>();
            OrderLines = new FakeDbSet<OrderLine>();
            PacingStyles = new FakeDbSet<PacingStyle>();
            PagePositions = new FakeDbSet<PagePosition>();
            Partners = new FakeDbSet<Partner>();
            PartnerDefaultBuyers = new FakeDbSet<PartnerDefaultBuyer>();
            PaymentTerms = new FakeDbSet<PaymentTerm>();
            PixelTagServers = new FakeDbSet<PixelTagServer>();
            PixelTagTemplates = new FakeDbSet<PixelTagTemplate>();
            Placements = new FakeDbSet<Placement>();
            PlacementPerformances = new FakeDbSet<PlacementPerformance>();
            PrivateMarkets = new FakeDbSet<PrivateMarket>();
            PrivateMarketModes = new FakeDbSet<PrivateMarketMode>();
            PrivateMarketPerformances = new FakeDbSet<PrivateMarketPerformance>();
            PrivateMarketSites = new FakeDbSet<PrivateMarketSite>();
            PrivateMarketSitePerformances = new FakeDbSet<PrivateMarketSitePerformance>();
            PrivateMarketSiteStatus = new FakeDbSet<PrivateMarketSiteStatu>();
            PrivateMarketStatus = new FakeDbSet<PrivateMarketStatu>();
            ProductCategories = new FakeDbSet<ProductCategory>();
            ProviderBrandSafetyTypes = new FakeDbSet<ProviderBrandSafetyType>();
            Publishers = new FakeDbSet<Publisher>();
            ReportAggregationLevels = new FakeDbSet<ReportAggregationLevel>();
            ReportJobs = new FakeDbSet<ReportJob>();
            ReportSchedules = new FakeDbSet<ReportSchedule>();
            ReportTypes = new FakeDbSet<ReportType>();
            RetryLogs = new FakeDbSet<RetryLog>();
            SalesRegions = new FakeDbSet<SalesRegion>();
            SchemaMigrations = new FakeDbSet<SchemaMigration>();
            Segments = new FakeDbSet<Segment>();
            SegmentPerformances = new FakeDbSet<SegmentPerformance>();
            SegmentReports = new FakeDbSet<SegmentReport>();
            SegmentThirdPartyTargetings = new FakeDbSet<SegmentThirdPartyTargeting>();
            SegmentTypes = new FakeDbSet<SegmentType>();
            SensitiveCategories = new FakeDbSet<SensitiveCategory>();
            SharingSegments = new FakeDbSet<SharingSegment>();
            SiteLevelOptimisationOverrides = new FakeDbSet<SiteLevelOptimisationOverride>();
            SiteListLookups = new FakeDbSet<SiteListLookup>();
            SiteListOptions = new FakeDbSet<SiteListOption>();
            SiteMetaAndDetails = new FakeDbSet<SiteMetaAndDetail>();
            SupplySources = new FakeDbSet<SupplySource>();
            SupportedMobileCarriersViews = new FakeDbSet<SupportedMobileCarriersView>();
            Sysdiagrams = new FakeDbSet<Sysdiagram>();
            SystemBlackListWebsites = new FakeDbSet<SystemBlackListWebsite>();
            SystemFeatures = new FakeDbSet<SystemFeature>();
            SystemSpendLimits = new FakeDbSet<SystemSpendLimit>();
            TargetingActions = new FakeDbSet<TargetingAction>();
            TargetingAttributeTypes = new FakeDbSet<TargetingAttributeType>();
            Technologies = new FakeDbSet<Technology>();
            Themes = new FakeDbSet<Theme>();
            ThirdPartyCampaigns = new FakeDbSet<ThirdPartyCampaign>();
            ThirdPartyCampaignBuyerAccounts = new FakeDbSet<ThirdPartyCampaignBuyerAccount>();
            ThirdPartyDataSets = new FakeDbSet<ThirdPartyDataSet>();
            ThirdPartyRatecardImports = new FakeDbSet<ThirdPartyRatecardImport>();
            ThirdPartySegmentImports = new FakeDbSet<ThirdPartySegmentImport>();
            ThirdPartyTaxonomies = new FakeDbSet<ThirdPartyTaxonomy>();
            ThirdPartyTaxonomyRateCards = new FakeDbSet<ThirdPartyTaxonomyRateCard>();
            TimeSpans = new FakeDbSet<TimeSpan>();
            TimeZones = new FakeDbSet<TimeZone>();
            Users = new FakeDbSet<User>();
            UserAdvertiserRoles = new FakeDbSet<UserAdvertiserRole>();
            UserBuyerRoles = new FakeDbSet<UserBuyerRole>();
            UserTags = new FakeDbSet<UserTag>();
            Verticals = new FakeDbSet<Vertical>();
            VerticalMappings = new FakeDbSet<VerticalMapping>();
            VerticalMappingMigrationAccessLogs = new FakeDbSet<VerticalMappingMigrationAccessLog>();
            VerticalStringReferenceToViDsMappings = new FakeDbSet<VerticalStringReferenceToViDsMapping>();
            VerticalViews = new FakeDbSet<VerticalView>();
        }
        
        public int SaveChangesCount { get; private set; } 
        public int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
        }
        
        public void Dispose()
        {
            Dispose(true);
        }
        
        // Stored Procedures
        public int CascadeDelete(int? entityType, Guid? uuid)
        {
 
            return 0;
        }

        public int EnsureAllPrivateMarketSiteAndPerformanceRowsExist()
        {
 
            return 0;
        }

        public int FlipBinomialGlobalDomainFilterTables()
        {
 
            return 0;
        }

        public int FlipBinomialGlobalFilterTables()
        {
 
            return 0;
        }

        public int FlipBinomialLocalDomainFilterTables()
        {
 
            return 0;
        }

        public int FlipBinomialLocalFilterTables()
        {
 
            return 0;
        }

        public List<GetAdGroupLifeTimeReturnModel> GetAdGroupLifeTime(Guid? buyerAccountId, Guid? advertiserId, Guid? productId, Guid? campaignId, Guid? adGroupId)
        {
            int procResult;
            return GetAdGroupLifeTime(buyerAccountId, advertiserId, productId, campaignId, adGroupId, out procResult);
        }

        public List<GetAdGroupLifeTimeReturnModel> GetAdGroupLifeTime(Guid? buyerAccountId, Guid? advertiserId, Guid? productId, Guid? campaignId, Guid? adGroupId, out int procResult)
        {
 
            procResult = 0;
            return new List<GetAdGroupLifeTimeReturnModel>();
        }

        public List<GetProductCategoryConversionRatesReturnModel> GetProductCategoryConversionRates()
        {
            int procResult;
            return GetProductCategoryConversionRates(out procResult);
        }

        public List<GetProductCategoryConversionRatesReturnModel> GetProductCategoryConversionRates( out int procResult)
        {
 
            procResult = 0;
            return new List<GetProductCategoryConversionRatesReturnModel>();
        }

        public int ImportBinomialFilterData(string tableName, string jobId, string filePath, string fieldTerminator)
        {
 
            return 0;
        }

        public int MigrateTargetingTopLevel(int? adGroupId)
        {
 
            return 0;
        }

        public int RebuildThirdPartySegments(string segmentPrefix)
        {
 
            return 0;
        }

        public int RollBinomialGlobalDomainFilterData()
        {
 
            return 0;
        }

        public int RollBinomialGlobalFilterData()
        {
 
            return 0;
        }

        public int RollBinomialLocalDomainFilterData()
        {
 
            return 0;
        }

        public int RollBinomialLocalFilterData()
        {
 
            return 0;
        }

        public List<SafetyCheckNoRunnableStrategiesSpendingOverBudgetReturnModel> SafetyCheckNoRunnableStrategiesSpendingOverBudget(decimal? overspendThreshold)
        {
            int procResult;
            return SafetyCheckNoRunnableStrategiesSpendingOverBudget(overspendThreshold, out procResult);
        }

        public List<SafetyCheckNoRunnableStrategiesSpendingOverBudgetReturnModel> SafetyCheckNoRunnableStrategiesSpendingOverBudget(decimal? overspendThreshold, out int procResult)
        {
 
            procResult = 0;
            return new List<SafetyCheckNoRunnableStrategiesSpendingOverBudgetReturnModel>();
        }

        public List<SafetyCheckNoStrategiesEnabledPastEndDateReturnModel> SafetyCheckNoStrategiesEnabledPastEndDate(DateTime? utcNow)
        {
            int procResult;
            return SafetyCheckNoStrategiesEnabledPastEndDate(utcNow, out procResult);
        }

        public List<SafetyCheckNoStrategiesEnabledPastEndDateReturnModel> SafetyCheckNoStrategiesEnabledPastEndDate(DateTime? utcNow, out int procResult)
        {
 
            procResult = 0;
            return new List<SafetyCheckNoStrategiesEnabledPastEndDateReturnModel>();
        }

        public int UpdateCityTargeting(int? adGroupId, byte? targetAction)
        {
 
            return 0;
        }

        public int UpdatePublisherTargeting(int? adGroupId, byte? targetAction)
        {
 
            return 0;
        }

        public int UpdateRegionTargeting(int? adGroupId, byte? targetAction)
        {
 
            return 0;
        }

        public int UpdateVertical2Targeting(int? adGroupId, byte? targetAction)
        {
 
            return 0;
        }

        public int UpdateVertical3Targeting(int? adGroupId, byte? targetAction)
        {
 
            return 0;
        }

        public int UpdateWebsiteTargeting(int? adGroupId, byte? targetAction)
        {
 
            return 0;
        }

    }

    // ************************************************************************
    // Fake DbSet
    // Implementing Find:
    //      The Find method is difficult to implement in a generic fashion. If
    //      you need to test code that makes use of the Find method it is
    //      easiest to create a test DbSet for each of the entity types that
    //      need to support find. You can then write logic to find that
    //      particular type of entity, as shown below:
    //      public class FakeBlogDbSet : FakeDbSet<Blog>
    //      {
    //          public override Blog Find(params object[] keyValues)
    //          {
    //              var id = (int) keyValues.Single();
    //              return this.SingleOrDefault(b => b.BlogId == id);
    //          }
    //      }
    //      Read more about it here: https://msdn.microsoft.com/en-us/data/dn314431.aspx
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public class FakeDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>, IDbAsyncEnumerable<TEntity> 
        where TEntity : class 
    { 
        private readonly ObservableCollection<TEntity> _data;
        private readonly IQueryable _query;
 
        public FakeDbSet() 
        { 
            _data = new ObservableCollection<TEntity>(); 
            _query = _data.AsQueryable(); 
        }

        public override IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            var items = entities.ToList();
            foreach (var entity in items)
            {
                _data.Add(entity);
            }
            return items;
        }
        
        public override TEntity Add(TEntity item) 
        {
            if (item == null) throw new ArgumentNullException("item");
            _data.Add(item); 
            return item; 
        } 
 
        public override TEntity Remove(TEntity item) 
        {
            if (item == null) throw new ArgumentNullException("item");
            _data.Remove(item); 
            return item; 
        } 
 
        public override TEntity Attach(TEntity item) 
        {
            if (item == null) throw new ArgumentNullException("item");
            _data.Add(item); 
            return item; 
        } 
 
        public override TEntity Create() 
        { 
            return Activator.CreateInstance<TEntity>(); 
        } 
 
        public override TDerivedEntity Create<TDerivedEntity>() 
        { 
            return Activator.CreateInstance<TDerivedEntity>(); 
        } 
 
        public override ObservableCollection<TEntity> Local 
        { 
            get { return _data; } 
        } 
 
        Type IQueryable.ElementType 
        { 
            get { return _query.ElementType; } 
        } 
 
        Expression IQueryable.Expression 
        { 
            get { return _query.Expression; } 
        } 
 
        IQueryProvider IQueryable.Provider 
        { 
            get { return new FakeDbAsyncQueryProvider<TEntity>(_query.Provider); } 
        } 
 
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() 
        { 
            return _data.GetEnumerator(); 
        } 
 
        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator() 
        { 
            return _data.GetEnumerator(); 
        } 
 
        IDbAsyncEnumerator<TEntity> IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator() 
        { 
            return new FakeDbAsyncEnumerator<TEntity>(_data.GetEnumerator()); 
        }
    } 
 
    internal class FakeDbAsyncQueryProvider<TEntity> : IDbAsyncQueryProvider 
    { 
        private readonly IQueryProvider _inner; 
 
        internal FakeDbAsyncQueryProvider(IQueryProvider inner) 
        { 
            _inner = inner; 
        } 
 
        public IQueryable CreateQuery(Expression expression) 
        { 
            return new FakeDbAsyncEnumerable<TEntity>(expression); 
        } 
 
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) 
        { 
            return new FakeDbAsyncEnumerable<TElement>(expression); 
        } 
 
        public object Execute(Expression expression) 
        { 
            return _inner.Execute(expression); 
        } 
 
        public TResult Execute<TResult>(Expression expression) 
        { 
            return _inner.Execute<TResult>(expression); 
        } 
 
        public System.Threading.Tasks.Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken) 
        { 
            return System.Threading.Tasks.Task.FromResult(Execute(expression)); 
        } 
 
        public System.Threading.Tasks.Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken) 
        { 
            return System.Threading.Tasks.Task.FromResult(Execute<TResult>(expression)); 
        } 
    } 
 
    internal class FakeDbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T> 
    { 
        public FakeDbAsyncEnumerable(IEnumerable<T> enumerable) 
            : base(enumerable) 
        { } 
 
        public FakeDbAsyncEnumerable(Expression expression) 
            : base(expression) 
        { } 
 
        public IDbAsyncEnumerator<T> GetAsyncEnumerator() 
        { 
            return new FakeDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator()); 
        } 
 
        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator() 
        { 
            return GetAsyncEnumerator(); 
        } 
 
        IQueryProvider IQueryable.Provider 
        { 
            get { return new FakeDbAsyncQueryProvider<T>(this); } 
        } 
    } 
 
    internal class FakeDbAsyncEnumerator<T> : IDbAsyncEnumerator<T> 
    { 
        private readonly IEnumerator<T> _inner; 
 
        public FakeDbAsyncEnumerator(IEnumerator<T> inner) 
        { 
            _inner = inner; 
        } 
 
        public void Dispose() 
        { 
            _inner.Dispose(); 
        } 
 
        public System.Threading.Tasks.Task<bool> MoveNextAsync(CancellationToken cancellationToken) 
        { 
            return System.Threading.Tasks.Task.FromResult(_inner.MoveNext()); 
        } 
 
        public T Current 
        { 
            get { return _inner.Current; } 
        } 
 
        object IDbAsyncEnumerator.Current 
        { 
            get { return Current; } 
        } 
    }

    // ************************************************************************
    // POCO classes

    // AccountsReceivableRtbView
    public partial class AccountsReceivableRtbView : Entity
    {
        public string ContactName { get; set; } // ContactName
        public string EmailAddress { get; set; } // EmailAddress
        public string PoAddressLine1 { get; set; } // POAddressLine1
        public string PoAddressLine2 { get; set; } // POAddressLine2
        public string PoAddressLine3 { get; set; } // POAddressLine3
        public string PoAddresLine4 { get; set; } // POAddresLine4
        public string PoCity { get; set; } // POCity
        public string PoRegion { get; set; } // PORegion
        public string PoPostalCode { get; set; } // POPostalCode
        public string PoCountry { get; set; } // POCountry
        public string InvoiceNumber { get; set; } // InvoiceNumber
        public string Reference { get; set; } // Reference
        public DateTime InvoiceDate { get; set; } // InvoiceDate
        public DateTime DueDate { get; set; } // DueDate
        public string SubTotal { get; set; } // SubTotal
        public string TotalTax { get; set; } // TotalTax
        public string Total { get; set; } // Total
        public string AdvertiserName { get; set; } // AdvertiserName
        public string Description { get; set; } // Description
        public int Quantity { get; set; } // Quantity
        public decimal? UnitAmount { get; set; } // UnitAmount
        public string AccountCode { get; set; } // AccountCode
        public string CurrencyName { get; set; } // CurrencyName
        public string Iso4217Code { get; set; } // ISO4217Code
        public string TaxType { get; set; } // TaxType
        public string TaxAmount { get; set; } // TaxAmount
        public string TrackingName1 { get; set; } // TrackingName1
        public string TrackingOption1 { get; set; } // TrackingOption1
        public string TrackingName2 { get; set; } // TrackingName2
        public string TrackingOption2 { get; set; } // TrackingOption2
        
        public AccountsReceivableRtbView()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ActiveAdGroupLookup
    public partial class ActiveAdGroupLookup : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID
        public string RtbAdGroupId { get; set; } // RtbAdGroupID
        public string AdGroupName { get; set; } // AdGroupName
        public decimal BudgetAmount { get; set; } // BudgetAmount
        public decimal MaxBidCpm { get; set; } // MaxBidCpm
        public int GoalTypeId { get; set; } // GoalTypeID
        public decimal GoalTargetRate { get; set; } // GoalTargetRate
        public bool AutoPause { get; set; } // AutoPause
        public int AdGroupStatusId { get; set; } // AdGroupStatusID
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public string RtbCampaignId { get; set; } // RtbCampaignID
        public int SpendConstraintPeriodId { get; set; } // SpendConstraintPeriodID
        public decimal SpendConstraintAmount { get; set; } // SpendConstraintAmount
        public int UniqueConstraintPeriodId { get; set; } // UniqueConstraintPeriodID
        public int UniqueConstraintAmount { get; set; } // UniqueConstraintAmount
        public string AdGroupSegmentConversions { get; set; } // AdGroupSegmentConversions
        public string AdGroupTargeting { get; set; } // AdGroupTargeting
        
        public ActiveAdGroupLookup()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ActiveAdLookup
    public partial class ActiveAdLookup : Entity
    {
        public int PlacementId { get; set; } // PlacementID
        public string RtbAdId { get; set; } // RtbAdID
        public string AdName { get; set; } // AdName
        public string DestinationUrl { get; set; } // DestinationUrl
        public string ClickTrackerUrl { get; set; } // ClickTrackerUrl
        public int CreativeStatusId { get; set; } // CreativeStatusID
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public string CreativeParameters { get; set; } // CreativeParameters
        public int? Width { get; set; } // Width
        public int? Height { get; set; } // Height
        public string TemplatePath { get; set; } // TemplatePath
        public int CreativeVendorId { get; set; } // CreativeVendorID
        public int AdGroupId { get; set; } // AdGroupID
        public string RtbAdGroupId { get; set; } // RtbAdGroupID
        
        public ActiveAdLookup()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ActiveCampaignLookup
    public partial class ActiveCampaignLookup : Entity
    {
        public int CampaignId { get; set; } // CampaignID
        public string RtbCampaignId { get; set; } // RtbCampaignID
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public string CampaignName { get; set; } // CampaignName
        public int AdvertiserProductId { get; set; } // AdvertiserProductID
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        
        public ActiveCampaignLookup()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ActiveSegmentLookup
    public partial class ActiveSegmentLookup : Entity
    {
        public int SegmentId { get; set; } // SegmentID
        public string RtbSegmentId { get; set; } // RtbSegmentId
        public int? BuyerAccountId { get; set; } // BuyerAccountID
        public int? AdvertiserId { get; set; } // AdvertiserID
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
        
        public ActiveSegmentLookup()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroup
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class AdGroup : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public Guid AdGroupUuid { get; set; } // AdGroupUuid
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public int CampaignId { get; set; } // CampaignID
        public string AdGroupName { get; set; } // AdGroupName
        public int GoalTypeId { get; set; } // GoalTypeID
        public decimal GoalTargetRate { get; set; } // GoalTargetRate
        public int BudgetPeriodId { get; set; } // BudgetPeriodID
        public int PacingStyleId { get; set; } // PacingStyleID
        public decimal BudgetAmount { get; set; } // BudgetAmount
        public DateTime? UtcStartDateTime { get; set; } // UtcStartDateTime
        public DateTime? UtcEndDateTime { get; set; } // UtcEndDateTime
        public decimal MaxBidCpm { get; set; } // MaxBidCpm
        public bool AutoPause { get; set; } // AutoPause
        public long GoalTargetQuantity { get; set; } // GoalTargetQuantity
        public int SpendConstraintPeriodId { get; set; } // SpendConstraintPeriodID
        public decimal SpendConstraintAmount { get; set; } // SpendConstraintAmount
        public int UniqueConstraintPeriodId { get; set; } // UniqueConstraintPeriodID
        public int UniqueConstraintAmount { get; set; } // UniqueConstraintAmount
        public int AdGroupStatusId { get; set; } // AdGroupStatusID
        public bool IsDeleted { get; set; } // IsDeleted
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
        public int? CloneFromAdGroupId { get; set; } // CloneFromAdGroupID
        public decimal? PacingAmount { get; set; } // PacingAmount
        public bool IsDebug { get; set; } // IsDebug
        public int MediaTypeId { get; set; } // MediaTypeID
        public int SupplySourceId { get; set; } // SupplySourceID
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
        public int PostcodeTargetingMode { get; set; } // PostcodeTargetingMode
        public int MobileCarrierTargetingMode { get; set; } // MobileCarrierTargetingMode
        public bool AutoSpend { get; set; } // AutoSpend
        public int DoohGeoLocationGroupTargetingMode { get; set; } // DoohGeoLocationGroupTargetingMode

        // Reverse navigation
        public virtual ICollection<AdGroupBrandSafety> AdGroupBrandSafeties { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupBrandSafetyBackup> AdGroupBrandSafetyBackups { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupDayPart> AdGroupDayParts { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupDeal> AdGroupDeals { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupDevice> AdGroupDevices { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupDomainList> AdGroupDomainLists { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupDoohGeoLocationGroup> AdGroupDoohGeoLocationGroups { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupDoohPanelLocation> AdGroupDoohPanelLocations { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupGeoLocation> AdGroupGeoLocations { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupGeoLocationPointRadius> AdGroupGeoLocationPointRadius { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupGeoPostcode> AdGroupGeoPostcodes { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupInventory> AdGroupInventories { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupLanguage> AdGroupLanguages { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupMobileCarrier> AdGroupMobileCarriers { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupPagePosition> AdGroupPagePositions { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupPerformance> AdGroupPerformances { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupPublisher> AdGroupPublishers { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupSegment> AdGroupSegments { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupSupplySource> AdGroupSupplySources { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupTargetingPerformance> AdGroupTargetingPerformances { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupVertical> AdGroupVerticals { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupVerticalBeforeMigration> AdGroupVerticalBeforeMigrations { get; set; } // Many to many mapping
        public virtual ICollection<Placement> Placements { get; set; } // Placement.FK_Placement_AdGroup
        public virtual ICollection<Segment> Segments { get; set; } // Many to many mapping

        // Foreign keys
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_AdGroup_BuyerAccount
        public virtual Campaign Campaign { get; set; } // FK_AdGroup_Campaign
        public virtual CampaignPeriod CampaignPeriod_BudgetPeriodId { get; set; } // FK_AdGroup_BudgetPeriod
        public virtual CampaignPeriod CampaignPeriod_SpendConstraintPeriodId { get; set; } // FK_AdGroup_SpendCampaignPeriod
        public virtual CampaignPeriod CampaignPeriod_UniqueConstraintPeriodId { get; set; } // FK_AdGroup_UniqueCampaignPeriod
        public virtual CampaignPeriod CampaignPeriod1 { get; set; } // FK_AdGroup_CampaignPeriod
        public virtual CampaignStatus CampaignStatus { get; set; } // FK_AdGroup_AdGroupStatus
        public virtual FrequencyGroup FrequencyGroup { get; set; } // FK_AdGroup_FrequencyGroup
        public virtual GoalType GoalType { get; set; } // FK_AdGroup_GoalType
        public virtual MediaType MediaType { get; set; } // FK_AdGroup_MediaType
        public virtual PacingStyle PacingStyle { get; set; } // FK_AdGroup_PacingStyle
        public virtual SupplySource SupplySource { get; set; } // FK_AdGroup_SupplySource
        
        public AdGroup()
        {
            GoalTypeId = 0;
            GoalTargetRate = 0m;
            BudgetPeriodId = 0;
            PacingStyleId = 1;
            BudgetAmount = 0m;
            MaxBidCpm = 0m;
            AutoPause = false;
            SpendConstraintPeriodId = 4;
            SpendConstraintAmount = 0m;
            UniqueConstraintPeriodId = 4;
            UniqueConstraintAmount = 0;
            AdGroupStatusId = 4;
            IsDeleted = false;
            UtcCreatedDateTime = System.DateTime.Now;
            UtcModifiedDateTime = System.DateTime.Now;
            LanguageTargetingMode = 2;
            CountryTargetingMode = 2;
            RegionTargetingMode = 2;
            CityTargetingMode = 2;
            Vertical1TargetingMode = 2;
            Vertical2TargetingMode = 2;
            Vertical3TargetingMode = 2;
            ExchangeTargetingMode = 2;
            PublisherTargetingMode = 2;
            SiteTargetingMode = 2;
            DataTargetTargetingMode = 2;
            DeviceTargetingMode = 2;
            DayPartTargetingMode = 2;
            PagePositionTargetingMode = 2;
            MinBidCpm = 0m;
            IsDebug = false;
            MediaTypeId = 0;
            UseBinomialFilter = false;
            MinSloRate = 0;
            MaxSloRate = 0;
            PageLevelBrandSafetyLevel = 0;
            PacingStyleOptionId = 2;
            ApplyBrandSafetySetting = true;
            UseBrandscreenVertical = true;
            UsePacing = false;
            UsePricing = false;
            BypassClassificationHide = false;
            PostcodeTargetingMode = 2;
            DoohGeoLocationGroupTargetingMode = 0;
            AdGroupBrandSafeties = new List<AdGroupBrandSafety>();
            AdGroupBrandSafetyBackups = new List<AdGroupBrandSafetyBackup>();
            AdGroupDayParts = new List<AdGroupDayPart>();
            AdGroupDeals = new List<AdGroupDeal>();
            AdGroupDevices = new List<AdGroupDevice>();
            AdGroupDomainLists = new List<AdGroupDomainList>();
            AdGroupDoohGeoLocationGroups = new List<AdGroupDoohGeoLocationGroup>();
            AdGroupDoohPanelLocations = new List<AdGroupDoohPanelLocation>();
            AdGroupGeoLocations = new List<AdGroupGeoLocation>();
            AdGroupGeoLocationPointRadius = new List<AdGroupGeoLocationPointRadius>();
            AdGroupGeoPostcodes = new List<AdGroupGeoPostcode>();
            AdGroupInventories = new List<AdGroupInventory>();
            AdGroupLanguages = new List<AdGroupLanguage>();
            AdGroupMobileCarriers = new List<AdGroupMobileCarrier>();
            AdGroupPagePositions = new List<AdGroupPagePosition>();
            AdGroupPerformances = new List<AdGroupPerformance>();
            AdGroupPublishers = new List<AdGroupPublisher>();
            AdGroupSegments = new List<AdGroupSegment>();
            AdGroupSupplySources = new List<AdGroupSupplySource>();
            AdGroupTargetingPerformances = new List<AdGroupTargetingPerformance>();
            AdGroupVerticals = new List<AdGroupVertical>();
            AdGroupVerticalBeforeMigrations = new List<AdGroupVerticalBeforeMigration>();
            Placements = new List<Placement>();
            Segments = new List<Segment>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupAllDomainList
    public partial class AdGroupAllDomainList : Entity
    {
        public int DomainListId { get; set; } // DomainListID
        public int TargetingActionId { get; set; } // TargetingActionID
        public int? AdGroupId { get; set; } // AdGroupID
        public Guid AdGroupUuid { get; set; } // AdGroupUuid
        public int Level { get; set; } // Level
        
        public AdGroupAllDomainList()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupApplicationParameter
    public partial class AdGroupApplicationParameter : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public string PackageKey { get; set; } // PackageKey (Primary key)
        public string Key { get; set; } // Key (Primary key)
        public string Value { get; set; } // Value

        // Foreign keys
        
        public AdGroupApplicationParameter()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupAttachedDomainList
    public partial class AdGroupAttachedDomainList : Entity
    {
        public int DomainListId { get; set; } // DomainListID
        public int TargetingActionId { get; set; } // TargetingActionID
        public int AdGroupId { get; set; } // AdGroupID
        public Guid AdGroupUuid { get; set; } // AdGroupUuid
        public int Level { get; set; } // Level
        
        public AdGroupAttachedDomainList()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupBinomialDomainFilterOverride
    public partial class AdGroupBinomialDomainFilterOverride : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int GoalTypeId { get; set; } // GoalTypeID (Primary key)
        public string DomainName { get; set; } // DomainName (Primary key)
        
        public AdGroupBinomialDomainFilterOverride()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupBinomialDomainFilterTargetingView
    public partial class AdGroupBinomialDomainFilterTargetingView : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int AdGroupId { get; set; } // AdGroupID
        public string DomainName { get; set; } // DomainName
        
        public AdGroupBinomialDomainFilterTargetingView()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupBinomialFilterOverride
    public partial class AdGroupBinomialFilterOverride : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int GoalTypeId { get; set; } // GoalTypeID (Primary key)
        public long InventoryId { get; set; } // InventoryID (Primary key)
        
        public AdGroupBinomialFilterOverride()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupBinomialFilterTargetingView
    public partial class AdGroupBinomialFilterTargetingView : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int AdGroupId { get; set; } // AdGroupID
        public int PartnerId { get; set; } // PartnerID
        public int PublisherId { get; set; } // PublisherID
        public int WebsiteId { get; set; } // WebsiteID
        public long InventoryId { get; set; } // InventoryID
        
        public AdGroupBinomialFilterTargetingView()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupBrandSafety
    public partial class AdGroupBrandSafety : Entity
    {
        public int BrandSafetyTypeId { get; set; } // BrandSafetyTypeID (Primary key)
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public int BrandSafetyProviderId { get; set; } // BrandSafetyProviderID (Primary key)

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupBrandSafety_New_AdGroup
        public virtual BrandSafetyType BrandSafetyType { get; set; } // FK_AdGroupBrandSafety_New_BrandSafety
        
        public AdGroupBrandSafety()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupBrandSafety_Backup
    public partial class AdGroupBrandSafetyBackup : Entity
    {
        public int BrandSafetyTypeId { get; set; } // BrandSafetyTypeID (Primary key)
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public int? BrandSafetyProviderId { get; set; } // BrandSafetyProviderID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupBrandSafety_AdGroup
        public virtual BrandSafetyType BrandSafetyType { get; set; } // FK_AdGroupBrandSafety_BrandSafety
        
        public AdGroupBrandSafetyBackup()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupBrandSafetyView
    public partial class AdGroupBrandSafetyView : Entity
    {
        public int BrandSafetyTypeId { get; set; } // BrandSafetyTypeID
        public int AdGroupId { get; set; } // AdGroupID
        public Guid AdGroupUuid { get; set; } // AdGroupUuid
        public int Level { get; set; } // Level
        public int BrandSafetyProviderId { get; set; } // BrandSafetyProviderID
        
        public AdGroupBrandSafetyView()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupContextualFee
    public partial class AdGroupContextualFee : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID
        public int? ClassificationProviderId { get; set; } // ClassificationProviderID
        public int? ClassificationUseFlatFee { get; set; } // ClassificationUseFlatFee
        public decimal? ClassificationFlatFee { get; set; } // ClassificationFlatFee
        public decimal? ClassificationPercentageFee { get; set; } // ClassificationPercentageFee
        public int? BrandSafetyProviderId { get; set; } // BrandSafetyProviderID
        public int? BrandSafetyUseFlatFee { get; set; } // BrandSafetyUseFlatFee
        public decimal? BrandSafetyFlatFee { get; set; } // BrandSafetyFlatFee
        public decimal? BrandSafetyPercentageFee { get; set; } // BrandSafetyPercentageFee
        public int? ViewabilityProviderId { get; set; } // ViewabilityProviderID
        public int? ViewabilityUseFlatFee { get; set; } // ViewabilityUseFlatFee
        public decimal? ViewabilityFlatFee { get; set; } // ViewabilityFlatFee
        public decimal? ViewabilityPercentageFee { get; set; } // ViewabilityPercentageFee
        public int? QualityProviderId { get; set; } // QualityProviderID
        public int? QualityUseFlatFee { get; set; } // QualityUseFlatFee
        public decimal? QualityFlatFee { get; set; } // QualityFlatFee
        public decimal? QualityPercentageFee { get; set; } // QualityPercentageFee
        public int? SuspiciousActivityProviderId { get; set; } // SuspiciousActivityProviderID
        public int? SuspiciousActivityUseFlatFee { get; set; } // SuspiciousActivityUseFlatFee
        public decimal? SuspiciousActivityFlatFee { get; set; } // SuspiciousActivityFlatFee
        public decimal? SuspiciousActivityPercentageFee { get; set; } // SuspiciousActivityPercentageFee
        public int? ClassificationBrandSafetyProviderId { get; set; } // ClassificationBrandSafetyProviderID
        public int? ClassificationBrandSafetyUseFlatFee { get; set; } // ClassificationBrandSafetyUseFlatFee
        public decimal? ClassificationBrandSafetyFlatFee { get; set; } // ClassificationBrandSafetyFlatFee
        public decimal? ClassificationBrandSafetyPercentageFee { get; set; } // ClassificationBrandSafetyPercentageFee
        
        public AdGroupContextualFee()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupDayPart
    public partial class AdGroupDayPart : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int DayPartId { get; set; } // DayPartID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupDayPart_AdGroup
        public virtual DayPart DayPart { get; set; } // FK_AdGroupDayPart_DayPart
        public virtual TargetingAction TargetingAction { get; set; } // FK_AdGroupDayPart_TargetingAction
        
        public AdGroupDayPart()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupDeal
    public partial class AdGroupDeal : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int DealId { get; set; } // DealID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupDeal_AdGroup
        public virtual Deal Deal { get; set; } // FK_AdGroupDeal_Deal
        public virtual TargetingAction TargetingAction { get; set; } // FK_AdGroupDeal_TargetingAction
        
        public AdGroupDeal()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupDevice
    public partial class AdGroupDevice : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int DeviceId { get; set; } // DeviceID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupDevice_AdGroup
        public virtual Device Device { get; set; } // FK_AdGroupDevice_Device
        public virtual TargetingAction TargetingAction { get; set; } // FK_AdGroupDevice_TargetingAction
        
        public AdGroupDevice()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupDomainList
    public partial class AdGroupDomainList : Entity
    {
        public int DomainListId { get; set; } // DomainListID (Primary key)
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupDomainList_AdGroup
        public virtual DomainList DomainList { get; set; } // FK_AdGroupDomainList_DomainList
        public virtual TargetingAction TargetingAction { get; set; } // FK_AdGroupDomainList_TargetingAction
        
        public AdGroupDomainList()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupDoohGeoLocationGroup
    public partial class AdGroupDoohGeoLocationGroup : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int DoohGeoLocationGroupId { get; set; } // DoohGeoLocationGroupID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupDoohGeoLocationGroup_AdGroup
        public virtual DoohGeoLocationGroup DoohGeoLocationGroup { get; set; } // FK_AdGroupDoohGeoLocationGroup_DoohGeoLocationGroup
        public virtual TargetingAction TargetingAction { get; set; } // FK_AdGroupDoohGeoLocationGroup_TargetingAction
        
        public AdGroupDoohGeoLocationGroup()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupDoohPanelLocation
    public partial class AdGroupDoohPanelLocation : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int DoohPanelLocationId { get; set; } // DoohPanelLocationID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupDoohPanelLocation_AdGroup
        public virtual DoohPanelLocation DoohPanelLocation { get; set; } // FK_AdGroupDoohPanelLocation_DoohPanelLocation
        public virtual TargetingAction TargetingAction { get; set; } // FK_AdGroupDoohPanelLocation_TargetingAction
        
        public AdGroupDoohPanelLocation()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupGeoLocation
    public partial class AdGroupGeoLocation : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public long GeoLocationId { get; set; } // GeoLocationID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupGeoLocation_AdGroup
        public virtual GeoLocation GeoLocation { get; set; } // FK_AdGroupGeoLocation_GeoLocation
        public virtual TargetingAction TargetingAction { get; set; } // FK_AdGroupGeoLocation_TargetingAction
        
        public AdGroupGeoLocation()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupGeoLocationPointRadius
    public partial class AdGroupGeoLocationPointRadius : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public decimal Latitude { get; set; } // Latitude (Primary key)
        public decimal Longitude { get; set; } // Longitude (Primary key)
        public decimal RadiusInKm { get; set; } // RadiusInKm
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupGeoLocationPointRadius_AdGroup
        
        public AdGroupGeoLocationPointRadius()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupGeoPostcode
    public partial class AdGroupGeoPostcode : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int GeoCountryId { get; set; } // GeoCountryID (Primary key)
        public string Postcode { get; set; } // Postcode (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupGeoPostcode_AdGroup
        public virtual GeoCountry GeoCountry { get; set; } // FK_AdGroupGeoPostcode_GeoCountry
        
        public AdGroupGeoPostcode()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupInheritedDomainList
    public partial class AdGroupInheritedDomainList : Entity
    {
        public int DomainListId { get; set; } // DomainListID
        public int TargetingActionId { get; set; } // TargetingActionID
        public int AdGroupId { get; set; } // AdGroupID
        public Guid AdGroupUuid { get; set; } // AdGroupUuid
        public int Level { get; set; } // Level
        
        public AdGroupInheritedDomainList()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupInventory
    public partial class AdGroupInventory : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public long InventoryId { get; set; } // InventoryID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public bool IsUploaded { get; set; } // IsUploaded

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupInventory_AdGroup
        
        public AdGroupInventory()
        {
            IsUploaded = false;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupLanguage
    public partial class AdGroupLanguage : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int LanguageId { get; set; } // LanguageID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupLanguage_AdGroup
        public virtual Language Language { get; set; } // FK_AdGroupLanguage_Language
        public virtual TargetingAction TargetingAction { get; set; } // FK_AdGroupLanguage_TargetingAction
        
        public AdGroupLanguage()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupMobileCarrier
    public partial class AdGroupMobileCarrier : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int GeoCountryId { get; set; } // GeoCountryID (Primary key)
        public int Mcc { get; set; } // MCC (Primary key)
        public int Mnc { get; set; } // MNC (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupMobileCarrier_AdGroup
        public virtual GeoCountry GeoCountry { get; set; } // FK_AdGroupMobileCarrier_GeoCountry
        
        public AdGroupMobileCarrier()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupNotification
    public partial class AdGroupNotification : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int AdGroupNotificationTypeId { get; set; } // AdGroupNotificationTypeID (Primary key)
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime (Primary key)
        public DateTime? UtcDeletedDateTime { get; set; } // UtcDeletedDateTime
        public string Details { get; set; } // Details

        // Foreign keys
        public virtual AdGroupNotificationType AdGroupNotificationType { get; set; } // FK_AdGroupNotification_AdGroupNotificationTypeID
        
        public AdGroupNotification()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupNotificationType
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class AdGroupNotificationType : Entity
    {
        public int AdGroupNotificationTypeId { get; set; } // AdGroupNotificationTypeID (Primary key)
        public string AdGroupNotificationTypeName { get; set; } // AdGroupNotificationTypeName

        // Reverse navigation
        public virtual ICollection<AdGroupNotification> AdGroupNotifications { get; set; } // Many to many mapping
        
        public AdGroupNotificationType()
        {
            AdGroupNotifications = new List<AdGroupNotification>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupPagePosition
    public partial class AdGroupPagePosition : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int PagePositionId { get; set; } // PagePositionID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupPagePosition_AdGroup
        public virtual PagePosition PagePosition { get; set; } // FK_AdGroupPagePosition_PagePosition
        public virtual TargetingAction TargetingAction { get; set; } // FK_AdGroupPagePosition_TargetingAction
        
        public AdGroupPagePosition()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupPerformance
    public partial class AdGroupPerformance : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int IntervalId { get; set; } // IntervalID (Primary key)
        public int IntervalValue { get; set; } // IntervalValue (Primary key)
        public long Bids { get; set; } // Bids
        public long Impressions { get; set; } // Impressions
        public long Clicks { get; set; } // Clicks
        public long Conversions { get; set; } // Conversions
        public long PostViewConversions { get; set; } // PostViewConversions
        public long PostClickConversions { get; set; } // PostClickConversions
        public DateTime? LastActivityTimestamp { get; set; } // LastActivityTimestamp
        public double? Ctr { get; set; } // CTR
        public long MediaCostLocalMicros { get; set; } // MediaCostLocalMicros
        public long DataCostLocalMicros { get; set; } // DataCostLocalMicros
        public long? SpendLocalMicros { get; set; } // SpendLocalMicros
        public long MediaClientCostLocalMicros { get; set; } // MediaClientCostLocalMicros
        public long DataClientCostLocalMicros { get; set; } // DataClientCostLocalMicros
        public long? ClientCostLocalMicros { get; set; } // ClientCostLocalMicros
        public decimal? Cpm { get; set; } // CPM
        public decimal? Cpc { get; set; } // CPC
        public decimal? Cpa { get; set; } // CPA
        public decimal? ClientCostCpm { get; set; } // ClientCostCPM
        public decimal? ClientCostCpc { get; set; } // ClientCostCPC
        public decimal? ClientCostCpa { get; set; } // ClientCostCPA
        public int PricingHealth { get; set; } // PricingHealth
        public int PacingHealth { get; set; } // PacingHealth
        public decimal? Cvr { get; set; } // Cvr
        public decimal? BidWin { get; set; } // BidWin
        public long FeesLocalSuperMicros { get; set; } // FeesLocalSuperMicros
        public long AdSlotDurationInSeconds { get; set; } // AdSlotDurationInSeconds
        public long RawViews { get; set; } // RawViews
        public long IabViews { get; set; } // IabViews
        public long ViewDurationInSeconds { get; set; } // ViewDurationInSeconds
        public decimal? CpMs { get; set; } // CPMs
        public decimal? ClientCostCpMs { get; set; } // ClientCostCPMs
        public decimal? Cps { get; set; } // CPS
        public decimal? ClientCostCps { get; set; } // ClientCostCPS
        public decimal? ViewableRatio { get; set; } // ViewableRatio

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupPerformance_AdGroup
        public virtual Interval Interval { get; set; } // FK_AdGroupPerformance_Interval
        
        public AdGroupPerformance()
        {
            MediaCostLocalMicros = 0;
            DataCostLocalMicros = 0;
            MediaClientCostLocalMicros = 0;
            DataClientCostLocalMicros = 0;
            PricingHealth = 1;
            PacingHealth = 1;
            AdSlotDurationInSeconds = 0;
            RawViews = 0;
            IabViews = 0;
            ViewDurationInSeconds = 0;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupPublisher
    public partial class AdGroupPublisher : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int PublisherId { get; set; } // PublisherID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupPublisher_AdGroup
        public virtual Publisher Publisher { get; set; } // FK_AdGroupPublisher_Publisher
        public virtual TargetingAction TargetingAction { get; set; } // FK_AdGroupPublisher_TargetingAction
        
        public AdGroupPublisher()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupSegment
    public partial class AdGroupSegment : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int SegmentId { get; set; } // SegmentID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupSegment_AdGroup
        public virtual Segment Segment { get; set; } // FK_AdGroupSegment_Segment
        public virtual TargetingAction TargetingAction { get; set; } // FK_AdGroupSegment_TargetingAction
        
        public AdGroupSegment()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupSloRateLookup
    public partial class AdGroupSloRateLookup : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID
        public int CampaignId { get; set; } // CampaignID
        public double? MinSloRate { get; set; } // MinSloRate
        public double? MaxSloRate { get; set; } // MaxSloRate
        
        public AdGroupSloRateLookup()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupSupplySource
    public partial class AdGroupSupplySource : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public int PartnerId { get; set; } // PartnerID (Primary key)
        public int PublisherId { get; set; } // PublisherID (Primary key)

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupSupplySource_AdGroup
        
        public AdGroupSupplySource()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupTargetingPerformance
    public partial class AdGroupTargetingPerformance : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int TargetingAttributeTypeId { get; set; } // TargetingAttributeTypeID (Primary key)
        public long Bids { get; set; } // Bids
        public long Impressions { get; set; } // Impressions
        public long Clicks { get; set; } // Clicks
        public long Conversions { get; set; } // Conversions
        public long PostViewConversions { get; set; } // PostViewConversions
        public long PostClickConversions { get; set; } // PostClickConversions
        public long Spend { get; set; } // Spend
        public double? Ctr { get; set; } // CTR
        public decimal? Cpm { get; set; } // CPM
        public decimal? Cpc { get; set; } // CPC
        public decimal? Cpa { get; set; } // CPA
        public int TimeSpanId { get; set; } // TimeSpanID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupTargetingPerformance_AdGroup
        public virtual TargetingAttributeType TargetingAttributeType { get; set; } // FK_AdGroupTargetingPerformance_TargetingAttributeType
        public virtual TimeSpan TimeSpan { get; set; } // FK_AdGroupTargetingPerformance_TimeSpan
        
        public AdGroupTargetingPerformance()
        {
            TimeSpanId = 9;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupTargetingView
    public partial class AdGroupTargetingView : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID
        public int TargetingAttributeTypeId { get; set; } // TargetingAttributeTypeID
        public long? TargetingValue { get; set; } // TargetingValue
        public string TargetingString { get; set; } // TargetingString
        public int TargetingActionId { get; set; } // TargetingActionID
        
        public AdGroupTargetingView()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupVertical
    public partial class AdGroupVertical : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int VerticalId { get; set; } // VerticalID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupVertical_AdGroup
        public virtual TargetingAction TargetingAction { get; set; } // FK_AdGroupVertical_TargetingAction
        public virtual Vertical Vertical { get; set; } // FK_AdGroupVertical_Vertical
        
        public AdGroupVertical()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupVerticalBeforeMigration
    public partial class AdGroupVerticalBeforeMigration : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public int VerticalId { get; set; } // VerticalID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_AdGroupVerticalBeforeMigration_AdGroup
        public virtual TargetingAction TargetingAction { get; set; } // FK_AdGroupVerticalBeforeMigration_TargetingAction
        public virtual Vertical Vertical { get; set; } // FK_AdGroupVerticalBeforeMigration_Vertical
        
        public AdGroupVerticalBeforeMigration()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupVerticalMappingMigrationLog
    public partial class AdGroupVerticalMappingMigrationLog : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID (Primary key)
        public Guid UserId { get; set; } // UserID
        public DateTime MigratedDateTime { get; set; } // MigratedDateTime
        
        public AdGroupVerticalMappingMigrationLog()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupVerticalTargetingMigration
    public partial class AdGroupVerticalTargetingMigration : Entity
    {
        public int CampaignId { get; set; } // CampaignID
        public string CampaignName { get; set; } // CampaignName
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public int AdGroupId { get; set; } // AdGroupID
        public string AdGroupName { get; set; } // AdGroupName
        public int? FromVerticalId { get; set; } // FromVerticalID
        public string FromVerticalName { get; set; } // FromVerticalName
        public string FromVerticalPath { get; set; } // FromVerticalPath
        public int? ToVerticalId { get; set; } // ToVerticalID
        public string ToVerticalName { get; set; } // ToVerticalName
        public string ToVerticalPath { get; set; } // ToVerticalPath
        public int HasMappedVertical { get; set; } // HasMappedVertical
        
        public AdGroupVerticalTargetingMigration()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupVerticalTargetingView
    public partial class AdGroupVerticalTargetingView : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID
        public int TargetingAttributeTypeId { get; set; } // TargetingAttributeTypeID
        public long? TargetingValue { get; set; } // TargetingValue
        public string TargetingString { get; set; } // TargetingString
        public int TargetingActionId { get; set; } // TargetingActionID
        
        public AdGroupVerticalTargetingView()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdGroupWithBrandSafety
    public partial class AdGroupWithBrandSafety : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID
        
        public AdGroupWithBrandSafety()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdSlot
    public partial class AdSlot : Entity
    {
        public int AdSlotId { get; set; } // AdSlotID (Primary key)
        public string AdSlotName { get; set; } // AdSlotName
        public long? EstimatedDailyImpressions { get; set; } // EstimatedDailyImpressions
        public int CreativeSizeId { get; set; } // CreativeSizeID
        public int PagePositionId { get; set; } // PagePositionID
        public int ExpandableDirectionId { get; set; } // ExpandableDirectionID
        public string DefaultAdTag { get; set; } // DefaultAdTag
        public int DealId { get; set; } // DealID
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys
        public virtual CreativeSize CreativeSize { get; set; } // FK_AdSlot_CreativeSize
        public virtual Deal Deal { get; set; } // FK_AdSlot_Deal
        public virtual ExpandableDirection ExpandableDirection { get; set; } // FK_AdSlot_ExpandableDirection
        public virtual PagePosition PagePosition { get; set; } // FK_AdSlot_PagePosition
        
        public AdSlot()
        {
            IsDeleted = false;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdTagServer
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class AdTagServer : Entity
    {
        public int AdTagServerId { get; set; } // AdTagServerID (Primary key)
        public string AdTagServerName { get; set; } // AdTagServerName
        public int? Position { get; set; } // Position
        public bool IsActive { get; set; } // IsActive
        public bool SupportsUpload { get; set; } // SupportsUpload

        // Reverse navigation
        public virtual ICollection<AdTagTemplate> AdTagTemplates { get; set; } // AdTagTemplate.FK_AdTagTemplate_AdTagServer
        public virtual ICollection<Advertiser> Advertisers { get; set; } // Advertiser.FK_Advertiser_AdTagServer
        
        public AdTagServer()
        {
            IsActive = false;
            SupportsUpload = false;
            AdTagTemplates = new List<AdTagTemplate>();
            Advertisers = new List<Advertiser>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdTagTemplate
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class AdTagTemplate : Entity
    {
        public int AdTagTemplateId { get; set; } // AdTagTemplateID (Primary key)
        public string AdTagTemplateName { get; set; } // AdTagTemplateName
        public int? Position { get; set; } // Position
        public bool IsActive { get; set; } // IsActive
        public int CreativeVendorId { get; set; } // CreativeVendorID
        public string TemplatePath { get; set; } // TemplatePath
        public string ParseRegEx { get; set; } // ParseRegEx
        public int AdTagServerId { get; set; } // AdTagServerID
        public int CreativeTypeId { get; set; } // CreativeTypeID
        public bool IsPublic { get; set; } // IsPublic
        public bool SupportSsl { get; set; } // SupportSsl
        public int MediaTypeId { get; set; } // MediaTypeID
        public bool IsExpandable { get; set; } // IsExpandable

        // Reverse navigation
        public virtual ICollection<BuyerAccount> BuyerAccounts { get; set; } // Many to many mapping
        public virtual ICollection<BuyerAccountAdTagTemplateFee> BuyerAccountAdTagTemplateFees { get; set; } // Many to many mapping
        public virtual ICollection<BuyerAccountApplicationAdTagTemplate> BuyerAccountApplicationAdTagTemplates { get; set; } // Many to many mapping
        public virtual ICollection<Creative> Creatives { get; set; } // Creative.FK_Creative_AdTagTemplate

        // Foreign keys
        public virtual AdTagServer AdTagServer { get; set; } // FK_AdTagTemplate_AdTagServer
        public virtual CreativeType CreativeType { get; set; } // FK_AdTagTemplate_CreativeTypeID
        public virtual MediaType MediaType { get; set; } // FK_AdTagTemplate_MediaType
        
        public AdTagTemplate()
        {
            IsActive = false;
            CreativeTypeId = 1;
            IsPublic = false;
            SupportSsl = true;
            BuyerAccountAdTagTemplateFees = new List<BuyerAccountAdTagTemplateFee>();
            BuyerAccountApplicationAdTagTemplates = new List<BuyerAccountApplicationAdTagTemplate>();
            Creatives = new List<Creative>();
            BuyerAccounts = new List<BuyerAccount>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Advertiser
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Advertiser : Entity
    {
        public int AdvertiserId { get; set; } // AdvertiserID (Primary key)
        public Guid AdvertiserUuid { get; set; } // AdvertiserUuid
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public string AdvertiserName { get; set; } // AdvertiserName
        public string AdvertiserHomepageUrl { get; set; } // AdvertiserHomepageUrl
        public int IndustryCategoryId { get; set; } // IndustryCategoryID
        public int AdTagServerId { get; set; } // AdTagServerID
        public int PixelTagServerId { get; set; } // PixelTagServerID
        public bool IsDeleted { get; set; } // IsDeleted
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime

        // Reverse navigation
        public virtual ICollection<AdvertiserBrandSafety> AdvertiserBrandSafeties { get; set; } // Many to many mapping
        public virtual ICollection<AdvertiserBrandSafetyBackup> AdvertiserBrandSafetyBackups { get; set; } // Many to many mapping
        public virtual ICollection<AdvertiserDomainList> AdvertiserDomainLists { get; set; } // Many to many mapping
        public virtual ICollection<AdvertiserPerformance> AdvertiserPerformances { get; set; } // Many to many mapping
        public virtual ICollection<AdvertiserProduct> AdvertiserProducts { get; set; } // AdvertiserProduct.FK_AdvertiserProduct_Advertiser
        public virtual ICollection<ReportSchedule> ReportSchedules { get; set; } // ReportSchedule.FK_ReportSchedule_Advertiser
        public virtual ICollection<Segment> Segments { get; set; } // Segment.FK_Segment_Advertiser
        public virtual ICollection<UserAdvertiserRole> UserAdvertiserRoles { get; set; } // Many to many mapping

        // Foreign keys
        public virtual AdTagServer AdTagServer { get; set; } // FK_Advertiser_AdTagServer
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_Advertiser_BuyerAccount
        public virtual IndustryCategory IndustryCategory { get; set; } // FK_Advertiser_IndustryCategory
        public virtual PixelTagServer PixelTagServer { get; set; } // FK_Advertiser_PixelTagServer
        
        public Advertiser()
        {
            AdvertiserUuid = System.Guid.NewGuid();
            AdTagServerId = 0;
            PixelTagServerId = 0;
            IsDeleted = false;
            UtcCreatedDateTime = System.DateTime.Now;
            UtcModifiedDateTime = System.DateTime.Now;
            AdvertiserBrandSafeties = new List<AdvertiserBrandSafety>();
            AdvertiserBrandSafetyBackups = new List<AdvertiserBrandSafetyBackup>();
            AdvertiserDomainLists = new List<AdvertiserDomainList>();
            AdvertiserPerformances = new List<AdvertiserPerformance>();
            AdvertiserProducts = new List<AdvertiserProduct>();
            ReportSchedules = new List<ReportSchedule>();
            Segments = new List<Segment>();
            UserAdvertiserRoles = new List<UserAdvertiserRole>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdvertiserApplicationParameter
    public partial class AdvertiserApplicationParameter : Entity
    {
        public int AdvertiserId { get; set; } // AdvertiserID (Primary key)
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public string PackageKey { get; set; } // PackageKey (Primary key)
        public string Key { get; set; } // Key (Primary key)
        public string Value { get; set; } // Value

        // Foreign keys
        
        public AdvertiserApplicationParameter()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdvertiserBlackListChangeLog
    public partial class AdvertiserBlackListChangeLog : Entity
    {
        public long Id { get; set; } // ID (Primary key)
        public int AdvertiserId { get; set; } // AdvertiserID
        public long WebsiteId { get; set; } // WebsiteID
        public string WebsiteUrl { get; set; } // WebsiteUrl
        public string Operation { get; set; } // Operation
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public Guid UserId { get; set; } // UserID
        public Guid? ActualUserId { get; set; } // ActualUserID
        
        public AdvertiserBlackListChangeLog()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdvertiserBlackListWebsite
    public partial class AdvertiserBlackListWebsite : Entity
    {
        public int AdvertiserId { get; set; } // AdvertiserID (Primary key)
        public long WebsiteId { get; set; } // WebsiteID (Primary key)
        public string WebsiteUrl { get; set; } // WebsiteUrl
        
        public AdvertiserBlackListWebsite()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdvertiserBrandSafety
    public partial class AdvertiserBrandSafety : Entity
    {
        public int BrandSafetyTypeId { get; set; } // BrandSafetyTypeID (Primary key)
        public int AdvertiserId { get; set; } // AdvertiserID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public int BrandSafetyProviderId { get; set; } // BrandSafetyProviderID (Primary key)

        // Foreign keys
        public virtual Advertiser Advertiser { get; set; } // FK_AdvertiserBrandSafety_New_Advertiser
        public virtual BrandSafetyType BrandSafetyType { get; set; } // FK_AdvertiserBrandSafety_New_BrandSafety
        
        public AdvertiserBrandSafety()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdvertiserBrandSafety_Backup
    public partial class AdvertiserBrandSafetyBackup : Entity
    {
        public int BrandSafetyTypeId { get; set; } // BrandSafetyTypeID (Primary key)
        public int AdvertiserId { get; set; } // AdvertiserID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public int? BrandSafetyProviderId { get; set; } // BrandSafetyProviderID

        // Foreign keys
        public virtual Advertiser Advertiser { get; set; } // FK_AdvertiserBrandSafety_Advertiser
        public virtual BrandSafetyType BrandSafetyType { get; set; } // FK_AdvertiserBrandSafety_BrandSafety
        
        public AdvertiserBrandSafetyBackup()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdvertiserDomainList
    public partial class AdvertiserDomainList : Entity
    {
        public int DomainListId { get; set; } // DomainListID (Primary key)
        public int AdvertiserId { get; set; } // AdvertiserID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual Advertiser Advertiser { get; set; } // FK_AdvertiserDomainList_Advertiser
        public virtual DomainList DomainList { get; set; } // FK_AdvertiserDomainList_DomainList
        public virtual TargetingAction TargetingAction { get; set; } // FK_AdvertiserDomainList_TargetingAction
        
        public AdvertiserDomainList()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdvertiserPerformance
    public partial class AdvertiserPerformance : Entity
    {
        public int AdvertiserId { get; set; } // AdvertiserID (Primary key)
        public int IntervalId { get; set; } // IntervalID (Primary key)
        public int IntervalValue { get; set; } // IntervalValue (Primary key)
        public long Bids { get; set; } // Bids
        public long Impressions { get; set; } // Impressions
        public long Clicks { get; set; } // Clicks
        public long Conversions { get; set; } // Conversions
        public long PostViewConversions { get; set; } // PostViewConversions
        public long PostClickConversions { get; set; } // PostClickConversions
        public DateTime? LastActivityTimestamp { get; set; } // LastActivityTimestamp
        public double? Ctr { get; set; } // CTR
        public long MediaCostLocalMicros { get; set; } // MediaCostLocalMicros
        public long DataCostLocalMicros { get; set; } // DataCostLocalMicros
        public long? SpendLocalMicros { get; set; } // SpendLocalMicros
        public long MediaClientCostLocalMicros { get; set; } // MediaClientCostLocalMicros
        public long DataClientCostLocalMicros { get; set; } // DataClientCostLocalMicros
        public long? ClientCostLocalMicros { get; set; } // ClientCostLocalMicros
        public decimal? Cpm { get; set; } // CPM
        public decimal? Cpc { get; set; } // CPC
        public decimal? Cpa { get; set; } // CPA
        public decimal? ClientCostCpm { get; set; } // ClientCostCPM
        public decimal? ClientCostCpc { get; set; } // ClientCostCPC
        public decimal? ClientCostCpa { get; set; } // ClientCostCPA
        public decimal? Spend { get; set; } // Spend
        public decimal? Cvr { get; set; } // Cvr
        public decimal? BidWin { get; set; } // BidWin
        public long AdSlotDurationInSeconds { get; set; } // AdSlotDurationInSeconds
        public long RawViews { get; set; } // RawViews
        public long IabViews { get; set; } // IabViews
        public long ViewDurationInSeconds { get; set; } // ViewDurationInSeconds
        public decimal? CpMs { get; set; } // CPMs
        public decimal? ClientCostCpMs { get; set; } // ClientCostCPMs
        public decimal? Cps { get; set; } // CPS
        public decimal? ClientCostCps { get; set; } // ClientCostCPS
        public decimal? ViewableRatio { get; set; } // ViewableRatio

        // Foreign keys
        public virtual Advertiser Advertiser { get; set; } // FK_AdvertiserPerformance_Advertiser
        public virtual Interval Interval { get; set; } // FK_AdvertiserPerformance_Interval
        
        public AdvertiserPerformance()
        {
            MediaCostLocalMicros = 0;
            DataCostLocalMicros = 0;
            MediaClientCostLocalMicros = 0;
            DataClientCostLocalMicros = 0;
            AdSlotDurationInSeconds = 0;
            RawViews = 0;
            IabViews = 0;
            ViewDurationInSeconds = 0;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdvertiserProduct
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class AdvertiserProduct : Entity
    {
        public int AdvertiserProductId { get; set; } // AdvertiserProductID (Primary key)
        public Guid AdvertiserProductUuid { get; set; } // AdvertiserProductUuid
        public int AdvertiserId { get; set; } // AdvertiserID
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public string ProductName { get; set; } // ProductName
        public int? ProductCategoryId { get; set; } // ProductCategoryID
        public string AdvertiserProductHomepageUrl { get; set; } // AdvertiserProductHomepageUrl
        public bool IsDeleted { get; set; } // IsDeleted
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public int SiteListOption { get; set; } // SiteListOption
        public int BrandSafetyModeId { get; set; } // BrandSafetyModeID

        // Reverse navigation
        public virtual ICollection<AdvertiserProductBrandSafety> AdvertiserProductBrandSafeties { get; set; } // Many to many mapping
        public virtual ICollection<AdvertiserProductBrandSafetyBackup> AdvertiserProductBrandSafetyBackups { get; set; } // Many to many mapping
        public virtual ICollection<AdvertiserProductDomainList> AdvertiserProductDomainLists { get; set; } // Many to many mapping
        public virtual ICollection<AdvertiserProductPerformance> AdvertiserProductPerformances { get; set; } // Many to many mapping
        public virtual ICollection<BrandSafety> BrandSafeties { get; set; } // Many to many mapping
        public virtual ICollection<Campaign> Campaigns { get; set; } // Campaign.FK_Campaign_AdvertiserProduct
        public virtual ICollection<Creative> Creatives { get; set; } // Creative.FK_Creative_AdvertiserProduct
        public virtual ICollection<CustomWhiteList> CustomWhiteLists { get; set; } // Many to many mapping

        // Foreign keys
        public virtual Advertiser Advertiser { get; set; } // FK_AdvertiserProduct_Advertiser
        public virtual BrandSafetyMode BrandSafetyMode { get; set; } // FK_AdvertiserProduct_BrandSafetyModeID
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_AdvertiserProduct_BuyerAccount
        public virtual ProductCategory ProductCategory { get; set; } // FK_AdvertiserProduct_ProductCategory
        
        public AdvertiserProduct()
        {
            AdvertiserProductUuid = System.Guid.NewGuid();
            IsDeleted = false;
            UtcCreatedDateTime = System.DateTime.Now;
            UtcModifiedDateTime = System.DateTime.Now;
            BrandSafetyModeId = 0;
            AdvertiserProductBrandSafeties = new List<AdvertiserProductBrandSafety>();
            AdvertiserProductBrandSafetyBackups = new List<AdvertiserProductBrandSafetyBackup>();
            AdvertiserProductDomainLists = new List<AdvertiserProductDomainList>();
            AdvertiserProductPerformances = new List<AdvertiserProductPerformance>();
            BrandSafeties = new List<BrandSafety>();
            Campaigns = new List<Campaign>();
            Creatives = new List<Creative>();
            CustomWhiteLists = new List<CustomWhiteList>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdvertiserProductBrandSafety
    public partial class AdvertiserProductBrandSafety : Entity
    {
        public int BrandSafetyTypeId { get; set; } // BrandSafetyTypeID (Primary key)
        public int AdvertiserProductId { get; set; } // AdvertiserProductID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public int BrandSafetyProviderId { get; set; } // BrandSafetyProviderID (Primary key)

        // Foreign keys
        public virtual AdvertiserProduct AdvertiserProduct { get; set; } // FK_AdvertiserProductBrandSafety_New_AdvertiserProduct
        public virtual BrandSafetyType BrandSafetyType { get; set; } // FK_AdvertiserProductBrandSafety_New_BrandSafety
        
        public AdvertiserProductBrandSafety()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdvertiserProductBrandSafety_Backup
    public partial class AdvertiserProductBrandSafetyBackup : Entity
    {
        public int BrandSafetyTypeId { get; set; } // BrandSafetyTypeID (Primary key)
        public int AdvertiserProductId { get; set; } // AdvertiserProductID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public int? BrandSafetyProviderId { get; set; } // BrandSafetyProviderID

        // Foreign keys
        public virtual AdvertiserProduct AdvertiserProduct { get; set; } // FK_AdvertiserProductBrandSafety_AdvertiserProduct
        public virtual BrandSafetyType BrandSafetyType { get; set; } // FK_AdvertiserProductBrandSafety_BrandSafety
        
        public AdvertiserProductBrandSafetyBackup()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdvertiserProductDomainList
    public partial class AdvertiserProductDomainList : Entity
    {
        public int DomainListId { get; set; } // DomainListID (Primary key)
        public int AdvertiserProductId { get; set; } // AdvertiserProductID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual AdvertiserProduct AdvertiserProduct { get; set; } // FK_AdvertiserProductDomainList_AdvertiserProduct
        public virtual DomainList DomainList { get; set; } // FK_AdvertiserProductDomainList_DomainList
        public virtual TargetingAction TargetingAction { get; set; } // FK_AdvertiserProductDomainList_TargetingAction
        
        public AdvertiserProductDomainList()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdvertiserProductPerformance
    public partial class AdvertiserProductPerformance : Entity
    {
        public int AdvertiserProductId { get; set; } // AdvertiserProductID (Primary key)
        public int IntervalId { get; set; } // IntervalID (Primary key)
        public int IntervalValue { get; set; } // IntervalValue (Primary key)
        public long Bids { get; set; } // Bids
        public long Impressions { get; set; } // Impressions
        public long Clicks { get; set; } // Clicks
        public long Conversions { get; set; } // Conversions
        public long PostViewConversions { get; set; } // PostViewConversions
        public long PostClickConversions { get; set; } // PostClickConversions
        public DateTime? LastActivityTimestamp { get; set; } // LastActivityTimestamp
        public double? Ctr { get; set; } // CTR
        public long MediaCostLocalMicros { get; set; } // MediaCostLocalMicros
        public long DataCostLocalMicros { get; set; } // DataCostLocalMicros
        public long? SpendLocalMicros { get; set; } // SpendLocalMicros
        public long MediaClientCostLocalMicros { get; set; } // MediaClientCostLocalMicros
        public long DataClientCostLocalMicros { get; set; } // DataClientCostLocalMicros
        public long? ClientCostLocalMicros { get; set; } // ClientCostLocalMicros
        public decimal? Cpm { get; set; } // CPM
        public decimal? Cpc { get; set; } // CPC
        public decimal? Cpa { get; set; } // CPA
        public decimal? ClientCostCpm { get; set; } // ClientCostCPM
        public decimal? ClientCostCpc { get; set; } // ClientCostCPC
        public decimal? ClientCostCpa { get; set; } // ClientCostCPA
        public decimal? Spend { get; set; } // Spend
        public decimal? Cvr { get; set; } // Cvr
        public decimal? BidWin { get; set; } // BidWin
        public long AdSlotDurationInSeconds { get; set; } // AdSlotDurationInSeconds
        public long RawViews { get; set; } // RawViews
        public long IabViews { get; set; } // IabViews
        public long ViewDurationInSeconds { get; set; } // ViewDurationInSeconds
        public decimal? CpMs { get; set; } // CPMs
        public decimal? ClientCostCpMs { get; set; } // ClientCostCPMs
        public decimal? Cps { get; set; } // CPS
        public decimal? ClientCostCps { get; set; } // ClientCostCPS
        public decimal? ViewableRatio { get; set; } // ViewableRatio

        // Foreign keys
        public virtual AdvertiserProduct AdvertiserProduct { get; set; } // FK_AdvertiserProductPerformance_AdvertiserProduct
        public virtual Interval Interval { get; set; } // FK_AdvertiserProductPerformance_Interval
        
        public AdvertiserProductPerformance()
        {
            MediaCostLocalMicros = 0;
            DataCostLocalMicros = 0;
            MediaClientCostLocalMicros = 0;
            DataClientCostLocalMicros = 0;
            AdSlotDurationInSeconds = 0;
            RawViews = 0;
            IabViews = 0;
            ViewDurationInSeconds = 0;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AdvertiserReview
    public partial class AdvertiserReview : Entity
    {
        public int AdvertiserId { get; set; } // AdvertiserID (Primary key)
        public int PartnerId { get; set; } // PartnerID (Primary key)
        public int AdvertiserReviewStatusId { get; set; } // AdvertiserReviewStatusID
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime

        // Foreign keys
        public virtual CreativeReviewStatus CreativeReviewStatus { get; set; } // FK_AdvertiserReview_CreativeReviewStatus
        public virtual Partner Partner { get; set; } // FK_AdvertiserReview_Partner
        
        public AdvertiserReview()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AttributionCountingMode
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class AttributionCountingMode : Entity
    {
        public int AttributionCountingModeId { get; set; } // AttributionCountingModeID (Primary key)
        public string AttributionCountingModeName { get; set; } // AttributionCountingModeName
        public int AttributionWindowInMinutes { get; set; } // AttributionWindowInMinutes

        // Reverse navigation
        public virtual ICollection<Segment> Segments { get; set; } // Segment.FK_Segment_AttributionCountingMode
        
        public AttributionCountingMode()
        {
            AttributionWindowInMinutes = 0;
            Segments = new List<Segment>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // AttributionModel
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class AttributionModel : Entity
    {
        public int AttributionModelId { get; set; } // AttributionModelID (Primary key)
        public string AttributionModelName { get; set; } // AttributionModelName

        // Reverse navigation
        public virtual ICollection<Segment> Segments { get; set; } // Segment.FK_Segment_AttributionModel
        
        public AttributionModel()
        {
            Segments = new List<Segment>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BaiduSegments
    public partial class BaiduSegment : Entity
    {
        public string RtbSegmentId { get; set; } // RtbSegmentID (Primary key)
        public long Bids { get; set; } // Bids
        
        public BaiduSegment()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BaiduSegmentsAlternate
    public partial class BaiduSegmentsAlternate : Entity
    {
        public string RtbSegmentId { get; set; } // RtbSegmentID (Primary key)
        public long Bids { get; set; } // Bids
        
        public BaiduSegmentsAlternate()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BillingCycle
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class BillingCycle : Entity
    {
        public int BillingCycleId { get; set; } // BillingCycleID (Primary key)
        public string BillingCycleName { get; set; } // BillingCycleName

        // Reverse navigation
        public virtual ICollection<BillingPeriod> BillingPeriods { get; set; } // BillingPeriod.FK_BillingPeriod_BillingCycle
        public virtual ICollection<BuyerAccount> BuyerAccounts { get; set; } // BuyerAccount.FK_BuyerAccount_BillingCycle
        
        public BillingCycle()
        {
            BillingPeriods = new List<BillingPeriod>();
            BuyerAccounts = new List<BuyerAccount>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BillingPeriod
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class BillingPeriod : Entity
    {
        public int BillingPeriodId { get; set; } // BillingPeriodID (Primary key)
        public int BillingCycleId { get; set; } // BillingCycleID
        public int TimeZoneId { get; set; } // TimeZoneID
        public DateTime FromDate { get; set; } // FromDate
        public DateTime ToDate { get; set; } // ToDate
        public bool IsClosed { get; set; } // IsClosed

        // Reverse navigation
        public virtual ICollection<Order> Orders { get; set; } // Order.FK_Order_BillingPeriod

        // Foreign keys
        public virtual BillingCycle BillingCycle { get; set; } // FK_BillingPeriod_BillingCycle
        public virtual TimeZone TimeZone { get; set; } // FK_BillingPeriod_TimeZone
        
        public BillingPeriod()
        {
            IsClosed = false;
            Orders = new List<Order>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BillingType
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class BillingType : Entity
    {
        public int BillingTypeId { get; set; } // BillingTypeID (Primary key)
        public string BillingTypeName { get; set; } // BillingTypeName

        // Reverse navigation
        public virtual ICollection<BuyerAccount> BuyerAccounts { get; set; } // BuyerAccount.FK_BuyerAccount_BillingType
        
        public BillingType()
        {
            BuyerAccounts = new List<BuyerAccount>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialGlobalBlackList
    public partial class BinomialGlobalBlackList : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int BuyerId { get; set; } // BuyerID
        public int PartnerId { get; set; } // PartnerID
        public int PublisherId { get; set; } // PublisherID
        public int WebsiteId { get; set; } // WebsiteID
        public long InventoryId { get; set; } // InventoryID
        
        public BinomialGlobalBlackList()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialGlobalBlackListOverride
    public partial class BinomialGlobalBlackListOverride : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID
        public int PartnerId { get; set; } // PartnerID
        public int PublisherId { get; set; } // PublisherID
        public long WebsiteId { get; set; } // WebsiteID
        
        public BinomialGlobalBlackListOverride()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialGlobalDomainBlackList
    public partial class BinomialGlobalDomainBlackList : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int BuyerId { get; set; } // BuyerID
        public string DomainName { get; set; } // DomainName
        
        public BinomialGlobalDomainBlackList()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialGlobalDomainBlackListOverride
    public partial class BinomialGlobalDomainBlackListOverride : Entity
    {
        public int AdGroupId { get; set; } // AdGroupID
        public string DomainName { get; set; } // DomainName
        
        public BinomialGlobalDomainBlackListOverride()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialGlobalDomainFilter
    public partial class BinomialGlobalDomainFilter : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int BuyerId { get; set; } // BuyerID
        public string DomainName { get; set; } // DomainName
        public long Impressions { get; set; } // Impressions
        public long Actions { get; set; } // Actions
        public double BetaBinomialCdf { get; set; } // BetaBinomialCDF
        public int BinomialGlobalDomainFilterId { get; set; } // BinomialGlobalDomainFilterID (Primary key)
        
        public BinomialGlobalDomainFilter()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialGlobalDomainFilterAlternate
    public partial class BinomialGlobalDomainFilterAlternate : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int BuyerId { get; set; } // BuyerID
        public string DomainName { get; set; } // DomainName
        public long Impressions { get; set; } // Impressions
        public long Actions { get; set; } // Actions
        public double BetaBinomialCdf { get; set; } // BetaBinomialCDF
        public int BinomialGlobalDomainFilterAlternateId { get; set; } // BinomialGlobalDomainFilterAlternateID (Primary key)
        
        public BinomialGlobalDomainFilterAlternate()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialGlobalDomainFilterImport
    public partial class BinomialGlobalDomainFilterImport : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int BuyerId { get; set; } // BuyerID
        public string DomainName { get; set; } // DomainName
        public long Impressions { get; set; } // Impressions
        public long Actions { get; set; } // Actions
        public double BetaBinomialCdf { get; set; } // BetaBinomialCDF
        public int BinomialGlobalDomainFilterImportId { get; set; } // BinomialGlobalDomainFilterImportID (Primary key)
        
        public BinomialGlobalDomainFilterImport()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialGlobalFilter
    public partial class BinomialGlobalFilter : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int BuyerId { get; set; } // BuyerID
        public int PartnerId { get; set; } // PartnerID
        public int PublisherId { get; set; } // PublisherID
        public int WebsiteId { get; set; } // WebsiteID
        public long InventoryId { get; set; } // InventoryID
        public long Impressions { get; set; } // Impressions
        public long Actions { get; set; } // Actions
        public double BetaBinomialCdf { get; set; } // BetaBinomialCDF
        public int BinomialGlobalFilterId { get; set; } // BinomialGlobalFilterID (Primary key)
        
        public BinomialGlobalFilter()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialGlobalFilterAlternate
    public partial class BinomialGlobalFilterAlternate : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int BuyerId { get; set; } // BuyerID
        public int PartnerId { get; set; } // PartnerID
        public int PublisherId { get; set; } // PublisherID
        public int WebsiteId { get; set; } // WebsiteID
        public long InventoryId { get; set; } // InventoryID
        public long Impressions { get; set; } // Impressions
        public long Actions { get; set; } // Actions
        public double BetaBinomialCdf { get; set; } // BetaBinomialCDF
        public int BinomialGlobalFilterAlternateId { get; set; } // BinomialGlobalFilterAlternateID (Primary key)
        
        public BinomialGlobalFilterAlternate()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialGlobalFilterImport
    public partial class BinomialGlobalFilterImport : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int BuyerId { get; set; } // BuyerID
        public int PartnerId { get; set; } // PartnerID
        public int PublisherId { get; set; } // PublisherID
        public int WebsiteId { get; set; } // WebsiteID
        public long InventoryId { get; set; } // InventoryID
        public long Impressions { get; set; } // Impressions
        public long Actions { get; set; } // Actions
        public double BetaBinomialCdf { get; set; } // BetaBinomialCDF
        public int BinomialGlobalFilterImportId { get; set; } // BinomialGlobalFilterImportID (Primary key)
        
        public BinomialGlobalFilterImport()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialLocalBlackList
    public partial class BinomialLocalBlackList : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int AdGroupId { get; set; } // AdGroupID
        public int PartnerId { get; set; } // PartnerID
        public int PublisherId { get; set; } // PublisherID
        public int WebsiteId { get; set; } // WebsiteID
        public long InventoryId { get; set; } // InventoryID
        
        public BinomialLocalBlackList()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialLocalDomainBlackList
    public partial class BinomialLocalDomainBlackList : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int AdGroupId { get; set; } // AdGroupID
        public string DomainName { get; set; } // DomainName
        
        public BinomialLocalDomainBlackList()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialLocalDomainFilter
    public partial class BinomialLocalDomainFilter : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int AdGroupId { get; set; } // AdGroupID
        public int CampaignId { get; set; } // CampaignID
        public string DomainName { get; set; } // DomainName
        public long Impressions { get; set; } // Impressions
        public long Actions { get; set; } // Actions
        public double BetaBinomialCdf { get; set; } // BetaBinomialCDF
        public int BinomialLocalDomainFilterId { get; set; } // BinomialLocalDomainFilterID (Primary key)
        
        public BinomialLocalDomainFilter()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialLocalDomainFilterAlternate
    public partial class BinomialLocalDomainFilterAlternate : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int AdGroupId { get; set; } // AdGroupID
        public int CampaignId { get; set; } // CampaignID
        public string DomainName { get; set; } // DomainName
        public long Impressions { get; set; } // Impressions
        public long Actions { get; set; } // Actions
        public double BetaBinomialCdf { get; set; } // BetaBinomialCDF
        public int BinomialLocalDomainFilterAlternateId { get; set; } // BinomialLocalDomainFilterAlternateID (Primary key)
        
        public BinomialLocalDomainFilterAlternate()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialLocalDomainFilterImport
    public partial class BinomialLocalDomainFilterImport : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int AdGroupId { get; set; } // AdGroupID
        public int CampaignId { get; set; } // CampaignID
        public string DomainName { get; set; } // DomainName
        public long Impressions { get; set; } // Impressions
        public long Actions { get; set; } // Actions
        public double BetaBinomialCdf { get; set; } // BetaBinomialCDF
        public int BinomialLocalDomainFilterImportId { get; set; } // BinomialLocalDomainFilterImportID (Primary key)
        
        public BinomialLocalDomainFilterImport()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialLocalFilter
    public partial class BinomialLocalFilter : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int AdGroupId { get; set; } // AdGroupID
        public int CampaignId { get; set; } // CampaignID
        public int PartnerId { get; set; } // PartnerID
        public int PublisherId { get; set; } // PublisherID
        public int WebsiteId { get; set; } // WebsiteID
        public long InventoryId { get; set; } // InventoryID
        public long Impressions { get; set; } // Impressions
        public long Actions { get; set; } // Actions
        public double BetaBinomialCdf { get; set; } // BetaBinomialCDF
        public int BinomialLocalFilterId { get; set; } // BinomialLocalFilterID (Primary key)
        
        public BinomialLocalFilter()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialLocalFilterAlternate
    public partial class BinomialLocalFilterAlternate : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int AdGroupId { get; set; } // AdGroupID
        public int CampaignId { get; set; } // CampaignID
        public int PartnerId { get; set; } // PartnerID
        public int PublisherId { get; set; } // PublisherID
        public int WebsiteId { get; set; } // WebsiteID
        public long InventoryId { get; set; } // InventoryID
        public long Impressions { get; set; } // Impressions
        public long Actions { get; set; } // Actions
        public double BetaBinomialCdf { get; set; } // BetaBinomialCDF
        public int BinomialLocalFilterAlternateId { get; set; } // BinomialLocalFilterAlternateID (Primary key)
        
        public BinomialLocalFilterAlternate()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BinomialLocalFilterImport
    public partial class BinomialLocalFilterImport : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID
        public int AdGroupId { get; set; } // AdGroupID
        public int CampaignId { get; set; } // CampaignID
        public int PartnerId { get; set; } // PartnerID
        public int PublisherId { get; set; } // PublisherID
        public int WebsiteId { get; set; } // WebsiteID
        public long InventoryId { get; set; } // InventoryID
        public long Impressions { get; set; } // Impressions
        public long Actions { get; set; } // Actions
        public double BetaBinomialCdf { get; set; } // BetaBinomialCDF
        public int BinomialLocalFilterImportId { get; set; } // BinomialLocalFilterImportID (Primary key)
        
        public BinomialLocalFilterImport()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BrandSafety
    public partial class BrandSafety : Entity
    {
        public int AdvertiserProductId { get; set; } // AdvertiserProductID (Primary key)
        public int BrandSafetyTypeId { get; set; } // BrandSafetyTypeID (Primary key)
        public int BrandSafetyLevelId { get; set; } // BrandSafetyLevelID

        // Foreign keys
        public virtual AdvertiserProduct AdvertiserProduct { get; set; } // FK_BrandSafety_AdvertiserProduct
        public virtual BrandSafetyLevel BrandSafetyLevel { get; set; } // FK_BrandSafety_BrandSafetyLevel
        public virtual BrandSafetyType BrandSafetyType { get; set; } // FK_BrandSafety_BrandSafetyType
        
        public BrandSafety()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BrandSafetyChangeLog
    public partial class BrandSafetyChangeLog : Entity
    {
        public long Id { get; set; } // ID (Primary key)
        public int AdvertiserProductId { get; set; } // AdvertiserProductID
        public string Operation { get; set; } // Operation
        public int? BrandSafetyType { get; set; } // BrandSafetyType
        public int? BrandSafetylevel { get; set; } // BrandSafetylevel
        public bool? BrandSafetyEnabled { get; set; } // BrandSafetyEnabled
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public Guid UserId { get; set; } // UserID
        public Guid? ActualUserId { get; set; } // ActualUserID
        
        public BrandSafetyChangeLog()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BrandSafetyLevel
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class BrandSafetyLevel : Entity
    {
        public int BrandSafetyLevelId { get; set; } // BrandSafetyLevelID (Primary key)
        public string BrandSafetyLevelName { get; set; } // BrandSafetyLevelName

        // Reverse navigation
        public virtual ICollection<BrandSafety> BrandSafeties { get; set; } // BrandSafety.FK_BrandSafety_BrandSafetyLevel
        
        public BrandSafetyLevel()
        {
            BrandSafeties = new List<BrandSafety>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BrandSafetyMode
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class BrandSafetyMode : Entity
    {
        public int BrandSafetyModeId { get; set; } // BrandSafetyModeID (Primary key)
        public string BrandSafetyModeName { get; set; } // BrandSafetyModeName

        // Reverse navigation
        public virtual ICollection<AdvertiserProduct> AdvertiserProducts { get; set; } // AdvertiserProduct.FK_AdvertiserProduct_BrandSafetyModeID
        
        public BrandSafetyMode()
        {
            AdvertiserProducts = new List<AdvertiserProduct>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BrandSafetyType
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class BrandSafetyType : Entity
    {
        public int BrandSafetyTypeId { get; set; } // BrandSafetyTypeID (Primary key)
        public string BrandSafetyTypeName { get; set; } // BrandSafetyTypeName

        // Reverse navigation
        public virtual ICollection<AdGroupBrandSafety> AdGroupBrandSafeties { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupBrandSafetyBackup> AdGroupBrandSafetyBackups { get; set; } // Many to many mapping
        public virtual ICollection<AdvertiserBrandSafety> AdvertiserBrandSafeties { get; set; } // Many to many mapping
        public virtual ICollection<AdvertiserBrandSafetyBackup> AdvertiserBrandSafetyBackups { get; set; } // Many to many mapping
        public virtual ICollection<AdvertiserProductBrandSafety> AdvertiserProductBrandSafeties { get; set; } // Many to many mapping
        public virtual ICollection<AdvertiserProductBrandSafetyBackup> AdvertiserProductBrandSafetyBackups { get; set; } // Many to many mapping
        public virtual ICollection<BrandSafety> BrandSafeties { get; set; } // Many to many mapping
        public virtual ICollection<BuyerAccountBrandSafety> BuyerAccountBrandSafeties { get; set; } // Many to many mapping
        public virtual ICollection<BuyerAccountBrandSafetyBackup> BuyerAccountBrandSafetyBackups { get; set; } // Many to many mapping
        public virtual ICollection<CampaignBrandSafety> CampaignBrandSafeties { get; set; } // Many to many mapping
        public virtual ICollection<CampaignBrandSafetyBackup> CampaignBrandSafetyBackups { get; set; } // Many to many mapping
        
        public BrandSafetyType()
        {
            AdGroupBrandSafeties = new List<AdGroupBrandSafety>();
            AdGroupBrandSafetyBackups = new List<AdGroupBrandSafetyBackup>();
            AdvertiserBrandSafeties = new List<AdvertiserBrandSafety>();
            AdvertiserBrandSafetyBackups = new List<AdvertiserBrandSafetyBackup>();
            AdvertiserProductBrandSafeties = new List<AdvertiserProductBrandSafety>();
            AdvertiserProductBrandSafetyBackups = new List<AdvertiserProductBrandSafetyBackup>();
            BrandSafeties = new List<BrandSafety>();
            BuyerAccountBrandSafeties = new List<BuyerAccountBrandSafety>();
            BuyerAccountBrandSafetyBackups = new List<BuyerAccountBrandSafetyBackup>();
            CampaignBrandSafeties = new List<CampaignBrandSafety>();
            CampaignBrandSafetyBackups = new List<CampaignBrandSafetyBackup>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccount
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class BuyerAccount : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public Guid BuyerAccountUuid { get; set; } // BuyerAccountUuid
        public string CompanyName { get; set; } // CompanyName
        public string BuyingGroupName { get; set; } // BuyingGroupName
        public string AddressLine1 { get; set; } // AddressLine1
        public string AddressLine2 { get; set; } // AddressLine2
        public string City { get; set; } // City
        public string StateProvince { get; set; } // StateProvince
        public string PostalCode { get; set; } // PostalCode
        public int? CountryId { get; set; } // CountryID
        public int? CurrencyId { get; set; } // CurrencyID
        public DateTime? TermsConditionsAgreedDate { get; set; } // TermsConditionsAgreedDate
        public bool IsAgent { get; set; } // IsAgent
        public decimal CreditLimit { get; set; } // CreditLimit
        public DateTime? TrialEndDate { get; set; } // TrialEndDate
        public int? BillingTypeId { get; set; } // BillingTypeID
        public int? TimeZoneId { get; set; } // TimeZoneID
        public Guid? CommercialContactUserId { get; set; } // CommercialContactUserID
        public int? PaymentTermsId { get; set; } // PaymentTermsID
        public int? BillingCycleId { get; set; } // BillingCycleID
        public decimal Brokerage { get; set; } // Brokerage
        public int LanguageId { get; set; } // LanguageID
        public bool IsActive { get; set; } // IsActive
        public bool IsDeleted { get; set; } // IsDeleted
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public int CompanyTypeId { get; set; } // CompanyTypeID
        public bool IsApproved { get; set; } // IsApproved
        public decimal BrandSafetyFee { get; set; } // BrandSafetyFee
        public decimal ServiceFee { get; set; } // ServiceFee
        public long? ThemeId { get; set; } // ThemeID
        public string Website { get; set; } // Website
        public int? MonthlyCreditId { get; set; } // MonthlyCreditID
        public string BillingContactEmail { get; set; } // BillingContactEmail
        public int ClickFilteringModeId { get; set; } // ClickFilteringModeID
        public decimal DefaultImpressionFee { get; set; } // DefaultImpressionFee
        public decimal MarkupMultiplier { get; set; } // MarkupMultiplier
        public int? BrandSafetyProviderId { get; set; } // BrandSafetyProviderID
        public DateTime? UtcStatusChangedDateTime { get; set; } // UtcStatusChangedDateTime

        // Reverse navigation
        public virtual ICollection<AdGroup> AdGroups { get; set; } // AdGroup.FK_AdGroup_BuyerAccount
        public virtual ICollection<AdTagTemplate> AdTagTemplates { get; set; } // Many to many mapping
        public virtual ICollection<Advertiser> Advertisers { get; set; } // Advertiser.FK_Advertiser_BuyerAccount
        public virtual ICollection<AdvertiserProduct> AdvertiserProducts { get; set; } // AdvertiserProduct.FK_AdvertiserProduct_BuyerAccount
        public virtual ICollection<BuyerAccountAdTagTemplateFee> BuyerAccountAdTagTemplateFees { get; set; } // Many to many mapping
        public virtual ICollection<BuyerAccountApplication> BuyerAccountApplications { get; set; } // Many to many mapping
        public virtual ICollection<BuyerAccountBrandSafety> BuyerAccountBrandSafeties { get; set; } // Many to many mapping
        public virtual ICollection<BuyerAccountBrandSafetyBackup> BuyerAccountBrandSafetyBackups { get; set; } // Many to many mapping
        public virtual ICollection<BuyerAccountDomainList> BuyerAccountDomainLists { get; set; } // Many to many mapping
        public virtual ICollection<BuyerAccountExcludedInventory> BuyerAccountExcludedInventories { get; set; } // Many to many mapping
        public virtual ICollection<Campaign> Campaigns { get; set; } // Campaign.FK_Campaign_BuyerAccount
        public virtual ICollection<Creative> Creatives { get; set; } // Creative.FK_Creative_BuyerAccount
        public virtual ICollection<CreativeFile> CreativeFiles { get; set; } // CreativeFile.FK_CreativeFile_BuyerAccountID
        public virtual ICollection<CustomCreativeParameter> CustomCreativeParameters { get; set; } // CustomCreativeParameter.FK_BuyerAccountID
        public virtual ICollection<CustomPublisherList> CustomPublisherLists_BuyerAccountId { get; set; } // CustomPublisherList.FK_CustomPublisherList_BuyerAccountID
        public virtual ICollection<CustomPublisherList> CustomPublisherLists_CustomPublisherListId { get; set; } // Many to many mapping
        public virtual ICollection<CustomWhiteList> CustomWhiteLists { get; set; } // CustomWhiteList.FK_CustomWhiteList_BuyerAccount
        public virtual ICollection<Deal> Deals { get; set; } // Deal.FK_Deal_BuyerAccount
        public virtual ICollection<DomainList> DomainLists { get; set; } // DomainList.FK_DomainList_BuyerAccount
        public virtual ICollection<FrequencyGroup> FrequencyGroups { get; set; } // FrequencyGroup.FK_FrequencyGroup_BuyerAccount
        public virtual ICollection<Label> Labels { get; set; } // Label.FK_Label_BuyerAccount
        public virtual ICollection<Order> Orders { get; set; } // Order.FK_Order_BuyerAccount
        public virtual ICollection<Placement> Placements { get; set; } // Placement.FK_Placement_BuyerAccount
        public virtual ICollection<ReportSchedule> ReportSchedules { get; set; } // ReportSchedule.FK_ReportSchedule_BuyerAccount
        public virtual ICollection<Segment> Segments { get; set; } // Segment.FK_Segment_BuyerAccount
        public virtual ICollection<SharingSegment> SharingSegments { get; set; } // Many to many mapping
        public virtual ICollection<SystemFeature> SystemFeatures { get; set; } // Many to many mapping
        public virtual ICollection<Theme> Themes { get; set; } // Theme.FK_Theme_BuyerAccount
        public virtual ICollection<UserBuyerRole> UserBuyerRoles { get; set; } // Many to many mapping

        // Foreign keys
        public virtual BillingCycle BillingCycle { get; set; } // FK_BuyerAccount_BillingCycle
        public virtual BillingType BillingType { get; set; } // FK_BuyerAccount_BillingType
        public virtual CompanyType CompanyType { get; set; } // FK_BuyerAccount_CompanyType
        public virtual Country Country { get; set; } // FK_BuyerAccount_Country
        public virtual Currency Currency { get; set; } // FK_BuyerAccount_Currency
        public virtual Language Language { get; set; } // FK_BuyerAccount_Language
        public virtual MonthlyCredit MonthlyCredit { get; set; } // FK_BuyerAccount_MonthlyCredit
        public virtual PaymentTerm PaymentTerm { get; set; } // FK_BuyerAccount_PaymentTerms
        public virtual Theme Theme { get; set; } // FK_BuyerAccount_Theme
        public virtual TimeZone TimeZone { get; set; } // FK_BuyerAccount_TimeZone
        public virtual User User { get; set; } // FK_BuyerAccount_CommercialContactUser
        
        public BuyerAccount()
        {
            BuyerAccountUuid = System.Guid.NewGuid();
            IsAgent = false;
            CreditLimit = 1000000.00m;
            Brokerage = 0.15m;
            IsActive = true;
            IsDeleted = false;
            UtcCreatedDateTime = System.DateTime.Now;
            UtcModifiedDateTime = System.DateTime.Now;
            CompanyTypeId = 1;
            BrandSafetyFee = 0m;
            ServiceFee = 0m;
            ClickFilteringModeId = 0;
            DefaultImpressionFee = 0m;
            MarkupMultiplier = 1m;
            AdGroups = new List<AdGroup>();
            Advertisers = new List<Advertiser>();
            AdvertiserProducts = new List<AdvertiserProduct>();
            BuyerAccountAdTagTemplateFees = new List<BuyerAccountAdTagTemplateFee>();
            BuyerAccountApplications = new List<BuyerAccountApplication>();
            BuyerAccountBrandSafeties = new List<BuyerAccountBrandSafety>();
            BuyerAccountBrandSafetyBackups = new List<BuyerAccountBrandSafetyBackup>();
            BuyerAccountDomainLists = new List<BuyerAccountDomainList>();
            BuyerAccountExcludedInventories = new List<BuyerAccountExcludedInventory>();
            Campaigns = new List<Campaign>();
            Creatives = new List<Creative>();
            CreativeFiles = new List<CreativeFile>();
            CustomCreativeParameters = new List<CustomCreativeParameter>();
            CustomPublisherLists_BuyerAccountId = new List<CustomPublisherList>();
            CustomWhiteLists = new List<CustomWhiteList>();
            Deals = new List<Deal>();
            DomainLists = new List<DomainList>();
            FrequencyGroups = new List<FrequencyGroup>();
            Labels = new List<Label>();
            Orders = new List<Order>();
            Placements = new List<Placement>();
            ReportSchedules = new List<ReportSchedule>();
            Segments = new List<Segment>();
            SharingSegments = new List<SharingSegment>();
            Themes = new List<Theme>();
            UserBuyerRoles = new List<UserBuyerRole>();
            CustomPublisherLists_CustomPublisherListId = new List<CustomPublisherList>();
            SystemFeatures = new List<SystemFeature>();
            AdTagTemplates = new List<AdTagTemplate>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountAdTagTemplateFee
    public partial class BuyerAccountAdTagTemplateFee : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public int AdTagTemplateId { get; set; } // AdTagTemplateID (Primary key)
        public long FeeLocalMicros { get; set; } // FeeLocalMicros

        // Foreign keys
        public virtual AdTagTemplate AdTagTemplate { get; set; } // FK_BuyerAccountAdTagTemplateFee_AdTagTemplate
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_BuyerAccountAdTagTemplateFee_BuyerAccount
        
        public BuyerAccountAdTagTemplateFee()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountApplication
    public partial class BuyerAccountApplication : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public string PackageKey { get; set; } // PackageKey (Primary key)
        public string Version { get; set; } // Version
        public bool Installed { get; set; } // Installed
        public bool Enabled { get; set; } // Enabled
        public bool Available { get; set; } // Available
        public bool Authorised { get; set; } // Authorised

        // Foreign keys
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_BuyerAccountApplication_BuyerAccount
        
        public BuyerAccountApplication()
        {
            Version = "";
            Installed = false;
            Enabled = false;
            Available = false;
            Authorised = false;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountApplicationAdTagServer
    public partial class BuyerAccountApplicationAdTagServer : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public string PackageKey { get; set; } // PackageKey (Primary key)
        public int AdTagServerId { get; set; } // AdTagServerID (Primary key)
        
        public BuyerAccountApplicationAdTagServer()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountApplicationAdTagTemplate
    public partial class BuyerAccountApplicationAdTagTemplate : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public string PackageKey { get; set; } // PackageKey (Primary key)
        public int AdTagTemplateId { get; set; } // AdTagTemplateID (Primary key)

        // Foreign keys
        public virtual AdTagTemplate AdTagTemplate { get; set; } // FK_BuyerAccountApplicationAdTagTemplate_AdTagTemplate
        
        public BuyerAccountApplicationAdTagTemplate()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountApplicationAudienceDataProvider
    public partial class BuyerAccountApplicationAudienceDataProvider : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public string PackageKey { get; set; } // PackageKey (Primary key)
        public int ThirdPartyCampaignId { get; set; } // ThirdPartyCampaignID (Primary key)

        // Foreign keys
        
        public BuyerAccountApplicationAudienceDataProvider()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountApplicationCreativeSize
    public partial class BuyerAccountApplicationCreativeSize : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public string PackageKey { get; set; } // PackageKey (Primary key)
        public int CreativeSizeId { get; set; } // CreativeSizeID (Primary key)

        // Foreign keys
        public virtual CreativeSize CreativeSize { get; set; } // FK_BuyerAccountApplicationCreativeSize_CreativeSize
        
        public BuyerAccountApplicationCreativeSize()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountApplicationDataProvider
    public partial class BuyerAccountApplicationDataProvider : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public string PackageKey { get; set; } // PackageKey (Primary key)
        public int DataProviderId { get; set; } // DataProviderID (Primary key)

        // Foreign keys
        
        public BuyerAccountApplicationDataProvider()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountApplicationGeoCountry
    public partial class BuyerAccountApplicationGeoCountry : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public string PackageKey { get; set; } // PackageKey (Primary key)
        public int GeoCountryId { get; set; } // GeoCountryID (Primary key)

        // Foreign keys
        public virtual GeoCountry GeoCountry { get; set; } // FK_BuyerAccountApplicationGeoCountry_GeoCountry
        
        public BuyerAccountApplicationGeoCountry()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountApplicationLanguage
    public partial class BuyerAccountApplicationLanguage : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public string PackageKey { get; set; } // PackageKey (Primary key)
        public int LanguageId { get; set; } // LanguageID (Primary key)

        // Foreign keys
        public virtual Language Language { get; set; } // FK_BuyerAccountApplicationLanguage_Language
        
        public BuyerAccountApplicationLanguage()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountApplicationParameter
    public partial class BuyerAccountApplicationParameter : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public string PackageKey { get; set; } // PackageKey (Primary key)
        public string Key { get; set; } // Key (Primary key)
        public string Value { get; set; } // Value

        // Foreign keys
        
        public BuyerAccountApplicationParameter()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountApplicationPartner
    public partial class BuyerAccountApplicationPartner : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public string PackageKey { get; set; } // PackageKey (Primary key)
        public int PartnerId { get; set; } // PartnerID (Primary key)

        // Foreign keys
        public virtual Partner Partner { get; set; } // FK_BuyerAccountApplicationPartner_Partner
        
        public BuyerAccountApplicationPartner()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountApplicationPixelTagServer
    public partial class BuyerAccountApplicationPixelTagServer : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public string PackageKey { get; set; } // PackageKey (Primary key)
        public int PixelTagServerId { get; set; } // PixelTagServerID (Primary key)

        // Foreign keys
        public virtual PixelTagServer PixelTagServer { get; set; } // FK_BuyerAccountApplicationPixelTagServer_PixelTagServer
        
        public BuyerAccountApplicationPixelTagServer()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountApplicationTranslation
    public partial class BuyerAccountApplicationTranslation : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public string PackageKey { get; set; } // PackageKey (Primary key)
        public int TranslationId { get; set; } // TranslationID (Primary key)

        // Foreign keys
        
        public BuyerAccountApplicationTranslation()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountBlackListChangeLog
    public partial class BuyerAccountBlackListChangeLog : Entity
    {
        public long Id { get; set; } // ID (Primary key)
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public long WebsiteId { get; set; } // WebsiteID
        public string WebsiteUrl { get; set; } // WebsiteUrl
        public string Operation { get; set; } // Operation
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public Guid UserId { get; set; } // UserID
        public Guid? ActualUserId { get; set; } // ActualUserID
        
        public BuyerAccountBlackListChangeLog()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountBlackListWebsite
    public partial class BuyerAccountBlackListWebsite : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public long WebsiteId { get; set; } // WebsiteID (Primary key)
        public string WebsiteUrl { get; set; } // WebsiteUrl
        
        public BuyerAccountBlackListWebsite()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountBrandSafety
    public partial class BuyerAccountBrandSafety : Entity
    {
        public int BrandSafetyTypeId { get; set; } // BrandSafetyTypeID (Primary key)
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public int BrandSafetyProviderId { get; set; } // BrandSafetyProviderID (Primary key)

        // Foreign keys
        public virtual BrandSafetyType BrandSafetyType { get; set; } // FK_BuyerAccountBrandSafety_New_BrandSafety
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_BuyerAccountBrandSafety_New_BuyerAccount
        
        public BuyerAccountBrandSafety()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountBrandSafety_Backup
    public partial class BuyerAccountBrandSafetyBackup : Entity
    {
        public int BrandSafetyTypeId { get; set; } // BrandSafetyTypeID (Primary key)
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public int? BrandSafetyProviderId { get; set; } // BrandSafetyProviderID

        // Foreign keys
        public virtual BrandSafetyType BrandSafetyType { get; set; } // FK_BuyerAccountBrandSafety_BrandSafety
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_BuyerAccountBrandSafety_BuyerAccount
        
        public BuyerAccountBrandSafetyBackup()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountContextualProviderFee
    public partial class BuyerAccountContextualProviderFee : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public int ContextualProviderId { get; set; } // ContextualProviderID (Primary key)
        public int ContextualFeeTypeId { get; set; } // ContextualFeeTypeID (Primary key)
        public bool UseFlatFee { get; set; } // UseFlatFee
        public decimal ContextualFlatFee { get; set; } // ContextualFlatFee
        public decimal ContextualPercentageFee { get; set; } // ContextualPercentageFee
        public int? GroupId { get; set; } // GroupID
        
        public BuyerAccountContextualProviderFee()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountDomainList
    public partial class BuyerAccountDomainList : Entity
    {
        public int DomainListId { get; set; } // DomainListID (Primary key)
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_BuyerAccountDomainList_BuyerAccount
        public virtual DomainList DomainList { get; set; } // FK_BuyerAccountDomainList_DomainList
        public virtual TargetingAction TargetingAction { get; set; } // FK_BuyerAccountDomainList_TargetingAction
        
        public BuyerAccountDomainList()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountExcludedInventory
    public partial class BuyerAccountExcludedInventory : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public long InventoryId { get; set; } // InventoryID (Primary key)

        // Foreign keys
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_BuyerAccountExcludedInventory_BuyerAccount
        
        public BuyerAccountExcludedInventory()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BuyerAccountPartnerSeatView
    public partial class BuyerAccountPartnerSeatView : Entity
    {
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public int PartnerId { get; set; } // PartnerID
        public string BuyerId { get; set; } // BuyerID
        
        public BuyerAccountPartnerSeatView()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Campaign
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Campaign : Entity
    {
        public int CampaignId { get; set; } // CampaignID (Primary key)
        public Guid CampaignUuid { get; set; } // CampaignUuid
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public int AdvertiserProductId { get; set; } // AdvertiserProductID
        public string CampaignName { get; set; } // CampaignName
        public string AgencyReference { get; set; } // AgencyReference
        public bool IsDeleted { get; set; } // IsDeleted
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public int? CloneFromCampaignId { get; set; } // CloneFromCampaignID
        public decimal Margin { get; set; } // Margin
        public decimal BudgetAmount { get; set; } // BudgetAmount

        // Reverse navigation
        public virtual ICollection<AdGroup> AdGroups { get; set; } // AdGroup.FK_AdGroup_Campaign
        public virtual ICollection<CampaignBrandSafety> CampaignBrandSafeties { get; set; } // Many to many mapping
        public virtual ICollection<CampaignBrandSafetyBackup> CampaignBrandSafetyBackups { get; set; } // Many to many mapping
        public virtual ICollection<CampaignDomainList> CampaignDomainLists { get; set; } // Many to many mapping
        public virtual ICollection<CampaignPerformance> CampaignPerformances { get; set; } // Many to many mapping
        public virtual ICollection<FrequencyGroup> FrequencyGroups { get; set; } // FrequencyGroup.FK_FrequencyGroup_Campaign
        public virtual ICollection<OrderLine> OrderLines { get; set; } // OrderLine.FK_OrderLine_Campaign
        public virtual ICollection<User> Users { get; set; } // Many to many mapping

        // Foreign keys
        public virtual AdvertiserProduct AdvertiserProduct { get; set; } // FK_Campaign_AdvertiserProduct
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_Campaign_BuyerAccount
        
        public Campaign()
        {
            IsDeleted = false;
            UtcCreatedDateTime = System.DateTime.Now;
            UtcModifiedDateTime = System.DateTime.Now;
            Margin = 0m;
            AdGroups = new List<AdGroup>();
            CampaignBrandSafeties = new List<CampaignBrandSafety>();
            CampaignBrandSafetyBackups = new List<CampaignBrandSafetyBackup>();
            CampaignDomainLists = new List<CampaignDomainList>();
            CampaignPerformances = new List<CampaignPerformance>();
            FrequencyGroups = new List<FrequencyGroup>();
            OrderLines = new List<OrderLine>();
            Users = new List<User>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CampaignBrandSafety
    public partial class CampaignBrandSafety : Entity
    {
        public int BrandSafetyTypeId { get; set; } // BrandSafetyTypeID (Primary key)
        public int CampaignId { get; set; } // CampaignID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public int BrandSafetyProviderId { get; set; } // BrandSafetyProviderID (Primary key)

        // Foreign keys
        public virtual BrandSafetyType BrandSafetyType { get; set; } // FK_CampaignBrandSafety_New_BrandSafety
        public virtual Campaign Campaign { get; set; } // FK_CampaignBrandSafety_New_Campaign
        
        public CampaignBrandSafety()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CampaignBrandSafety_Backup
    public partial class CampaignBrandSafetyBackup : Entity
    {
        public int BrandSafetyTypeId { get; set; } // BrandSafetyTypeID (Primary key)
        public int CampaignId { get; set; } // CampaignID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public int? BrandSafetyProviderId { get; set; } // BrandSafetyProviderID

        // Foreign keys
        public virtual BrandSafetyType BrandSafetyType { get; set; } // FK_CampaignBrandSafety_BrandSafety
        public virtual Campaign Campaign { get; set; } // FK_CampaignBrandSafety_Campaign
        
        public CampaignBrandSafetyBackup()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CampaignDomainList
    public partial class CampaignDomainList : Entity
    {
        public int DomainListId { get; set; } // DomainListID (Primary key)
        public int CampaignId { get; set; } // CampaignID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID

        // Foreign keys
        public virtual Campaign Campaign { get; set; } // FK_CampaignDomainList_Campaign
        public virtual DomainList DomainList { get; set; } // FK_CampaignDomainList_DomainList
        public virtual TargetingAction TargetingAction { get; set; } // FK_CampaignDomainList_TargetingAction
        
        public CampaignDomainList()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CampaignMargin
    public partial class CampaignMargin : Entity
    {
        public int CampaignMarginId { get; set; } // CampaignMarginID (Primary key)
        public int CampaignId { get; set; } // CampaignID
        public DateTime LocalStartDateInclusive { get; set; } // LocalStartDateInclusive
        public DateTime? LocalEndDateInclusive { get; set; } // LocalEndDateInclusive
        public decimal? Margin { get; set; } // Margin
        
        public CampaignMargin()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CampaignPerformance
    public partial class CampaignPerformance : Entity
    {
        public int CampaignId { get; set; } // CampaignID (Primary key)
        public int IntervalId { get; set; } // IntervalID (Primary key)
        public int IntervalValue { get; set; } // IntervalValue (Primary key)
        public long Bids { get; set; } // Bids
        public long Impressions { get; set; } // Impressions
        public long Clicks { get; set; } // Clicks
        public long Conversions { get; set; } // Conversions
        public long PostViewConversions { get; set; } // PostViewConversions
        public long PostClickConversions { get; set; } // PostClickConversions
        public DateTime? LastActivityTimestamp { get; set; } // LastActivityTimestamp
        public double? Ctr { get; set; } // CTR
        public long MediaCostLocalMicros { get; set; } // MediaCostLocalMicros
        public long DataCostLocalMicros { get; set; } // DataCostLocalMicros
        public long? SpendLocalMicros { get; set; } // SpendLocalMicros
        public long MediaClientCostLocalMicros { get; set; } // MediaClientCostLocalMicros
        public long DataClientCostLocalMicros { get; set; } // DataClientCostLocalMicros
        public long? ClientCostLocalMicros { get; set; } // ClientCostLocalMicros
        public decimal? Cpm { get; set; } // CPM
        public decimal? Cpc { get; set; } // CPC
        public decimal? Cpa { get; set; } // CPA
        public decimal? ClientCostCpm { get; set; } // ClientCostCPM
        public decimal? ClientCostCpc { get; set; } // ClientCostCPC
        public decimal? ClientCostCpa { get; set; } // ClientCostCPA
        public decimal? Spend { get; set; } // Spend
        public decimal? Cvr { get; set; } // Cvr
        public decimal? BidWin { get; set; } // BidWin
        public long AdSlotDurationInSeconds { get; set; } // AdSlotDurationInSeconds
        public long RawViews { get; set; } // RawViews
        public long IabViews { get; set; } // IabViews
        public long ViewDurationInSeconds { get; set; } // ViewDurationInSeconds
        public decimal? CpMs { get; set; } // CPMs
        public decimal? ClientCostCpMs { get; set; } // ClientCostCPMs
        public decimal? Cps { get; set; } // CPS
        public decimal? ClientCostCps { get; set; } // ClientCostCPS
        public decimal? ViewableRatio { get; set; } // ViewableRatio

        // Foreign keys
        public virtual Campaign Campaign { get; set; } // FK_CampaignPerformance_Campaign
        public virtual Interval Interval { get; set; } // FK_CampaignPerformance_Interval
        
        public CampaignPerformance()
        {
            MediaCostLocalMicros = 0;
            DataCostLocalMicros = 0;
            MediaClientCostLocalMicros = 0;
            DataClientCostLocalMicros = 0;
            AdSlotDurationInSeconds = 0;
            RawViews = 0;
            IabViews = 0;
            ViewDurationInSeconds = 0;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CampaignPeriod
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class CampaignPeriod : Entity
    {
        public int CampaignPeriodId { get; set; } // CampaignPeriodID (Primary key)
        public string PeriodName { get; set; } // PeriodName
        public bool IsActive { get; set; } // IsActive

        // Reverse navigation
        public virtual ICollection<AdGroup> AdGroups_BudgetPeriodId { get; set; } // AdGroup.FK_AdGroup_BudgetPeriod
        public virtual ICollection<AdGroup> AdGroups_SpendConstraintPeriodId { get; set; } // AdGroup.FK_AdGroup_SpendCampaignPeriod
        public virtual ICollection<AdGroup> AdGroups_UniqueConstraintPeriodId { get; set; } // AdGroup.FK_AdGroup_UniqueCampaignPeriod
        public virtual ICollection<AdGroup> AdGroups1 { get; set; } // AdGroup.FK_AdGroup_CampaignPeriod
        public virtual ICollection<FrequencyCap> FrequencyCaps { get; set; } // FrequencyCap.FK_FrequencyCap_CampaignPeriod
        public virtual ICollection<ReportSchedule> ReportSchedules { get; set; } // ReportSchedule.FK_ReportSchedule_CampaignPeriod
        public virtual ICollection<Segment> Segments { get; set; } // Segment.FK_Segment_ThirdPartyPeriodID
        
        public CampaignPeriod()
        {
            IsActive = true;
            AdGroups_BudgetPeriodId = new List<AdGroup>();
            AdGroups1 = new List<AdGroup>();
            AdGroups_SpendConstraintPeriodId = new List<AdGroup>();
            AdGroups_UniqueConstraintPeriodId = new List<AdGroup>();
            FrequencyCaps = new List<FrequencyCap>();
            ReportSchedules = new List<ReportSchedule>();
            Segments = new List<Segment>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CampaignStatus
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class CampaignStatus : Entity
    {
        public int CampaignStatusId { get; set; } // CampaignStatusID (Primary key)
        public string CampaignStatusName { get; set; } // CampaignStatusName

        // Reverse navigation
        public virtual ICollection<AdGroup> AdGroups { get; set; } // AdGroup.FK_AdGroup_AdGroupStatus
        public virtual ICollection<Creative> Creatives { get; set; } // Creative.FK_Creative_CampaignStatus
        public virtual ICollection<Deal> Deals { get; set; } // Deal.FK_Deal_CampaignStatus
        public virtual ICollection<Placement> Placements { get; set; } // Placement.FK_Placement_Status
        public virtual ICollection<ReportSchedule> ReportSchedules { get; set; } // ReportSchedule.FK_ReportSchedule_CampaignStatus
        public virtual ICollection<Segment> Segments { get; set; } // Segment.FK_Segment_CampaignStatus
        
        public CampaignStatus()
        {
            AdGroups = new List<AdGroup>();
            Creatives = new List<Creative>();
            Deals = new List<Deal>();
            Placements = new List<Placement>();
            ReportSchedules = new List<ReportSchedule>();
            Segments = new List<Segment>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ChangeLog
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class ChangeLog : Entity
    {
        public long ChangeLogId { get; set; } // ChangeLogID (Primary key)
        public DateTime UtcDateTime { get; set; } // UtcDateTime
        public Guid UserId { get; set; } // UserID
        public Guid? ActualUserId { get; set; } // ActualUserID
        public string NameSpace { get; set; } // NameSpace
        public string MethodName { get; set; } // MethodName
        public string Json { get; set; } // Json
        public string DataKey { get; set; } // DataKey
        public string LinkTable { get; set; } // LinkTable
        public int MilliSecondsTaken { get; set; } // MilliSecondsTaken
        public byte SecurityLevel { get; set; } // SecurityLevel
        public string Exception { get; set; } // Exception
        public bool NoChange { get; set; } // NoChange

        // Reverse navigation
        public virtual ICollection<ChangeLogComment> ChangeLogComments { get; set; } // ChangeLogComment.FK_ChangeLogComment_ChangeLog
        
        public ChangeLog()
        {
            ChangeLogComments = new List<ChangeLogComment>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ChangeLogComment
    public partial class ChangeLogComment : Entity
    {
        public int ChangeLogCommentId { get; set; } // ChangeLogCommentId (Primary key)
        public string Comment { get; set; } // Comment
        public DateTime UtcDateTime { get; set; } // UtcDateTime
        public long ChangeLogId { get; set; } // ChangeLogId
        public Guid ActualUserId { get; set; } // ActualUserId

        // Foreign keys
        public virtual ChangeLog ChangeLog { get; set; } // FK_ChangeLogComment_ChangeLog
        public virtual User User { get; set; } // FK_ChangeLogComment_User
        
        public ChangeLogComment()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CompanyType
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class CompanyType : Entity
    {
        public int CompanyTypeId { get; set; } // CompanyTypeID (Primary key)
        public string CompanyTypeName { get; set; } // CompanyTypeName
        public int SortOrder { get; set; } // SortOrder

        // Reverse navigation
        public virtual ICollection<BuyerAccount> BuyerAccounts { get; set; } // BuyerAccount.FK_BuyerAccount_CompanyType
        
        public CompanyType()
        {
            BuyerAccounts = new List<BuyerAccount>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ConstraintReason
    public partial class ConstraintReason : Entity
    {
        public int ConstraintReasonId { get; set; } // ConstraintReasonID (Primary key)
        public string ConstraintReasonName { get; set; } // ConstraintReasonName
        
        public ConstraintReason()
        {
            ConstraintReasonId = 0;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ContextualProviderFee
    public partial class ContextualProviderFee : Entity
    {
        public int ContextualProviderId { get; set; } // ContextualProviderID (Primary key)
        public int ContextualFeeTypeId { get; set; } // ContextualFeeTypeID (Primary key)
        public decimal ContextualFlatFee { get; set; } // ContextualFlatFee
        public decimal ContextualPercentageFee { get; set; } // ContextualPercentageFee
        
        public ContextualProviderFee()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Country
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Country : Entity
    {
        public int CountryId { get; set; } // CountryID (Primary key)
        public string CountryName { get; set; } // CountryName
        public string Iso3166Code { get; set; } // ISO3166Code
        public int? Position { get; set; } // Position
        public int? CurrencyId { get; set; } // CurrencyID
        public bool IsActive { get; set; } // IsActive
        public decimal TaxRate { get; set; } // TaxRate
        public int? DefaultTimeZoneId { get; set; } // DefaultTimeZoneID
        public bool IsGeoTarget { get; set; } // IsGeoTarget
        public int? DefaultLanguageId { get; set; } // DefaultLanguageID
        public bool IsSupported { get; set; } // IsSupported

        // Reverse navigation
        public virtual ICollection<BuyerAccount> BuyerAccounts { get; set; } // BuyerAccount.FK_BuyerAccount_Country
        public virtual ICollection<Segment> Segments { get; set; } // Segment.FK_Segment_TargetGeographyCountryId

        // Foreign keys
        public virtual Currency Currency { get; set; } // FK_Country_Currency
        public virtual TimeZone TimeZone { get; set; } // FK__Country__Default__54B68676
        
        public Country()
        {
            TaxRate = 0m;
            IsGeoTarget = false;
            IsSupported = false;
            BuyerAccounts = new List<BuyerAccount>();
            Segments = new List<Segment>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CountryContextualProviderFee
    public partial class CountryContextualProviderFee : Entity
    {
        public int CountryId { get; set; } // CountryID (Primary key)
        public int ContextualProviderId { get; set; } // ContextualProviderID (Primary key)
        public int ContextualFeeTypeId { get; set; } // ContextualFeeTypeID (Primary key)
        public decimal ContextualFlatFee { get; set; } // ContextualFlatFee
        
        public CountryContextualProviderFee()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Creative
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Creative : Entity
    {
        public int CreativeId { get; set; } // CreativeID (Primary key)
        public Guid CreativeUuid { get; set; } // CreativeUuid
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public string CreativeName { get; set; } // CreativeName
        public int CreativeTypeId { get; set; } // CreativeTypeID
        public int CreativeSizeId { get; set; } // CreativeSizeID
        public string AdTag { get; set; } // AdTag
        public int? CreativeFileId { get; set; } // CreativeFileID
        public int? AdTagTemplateId { get; set; } // AdTagTemplateID
        public string ClickThroughUrl { get; set; } // ClickThroughURL
        public string ClickTrackerUrl { get; set; } // ClickTrackerURL
        public string BeaconUrl { get; set; } // BeaconURL
        public int CreativeStatusId { get; set; } // CreativeStatusID
        public bool IsDeleted { get; set; } // IsDeleted
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public int LanguageId { get; set; } // LanguageID
        public int? CloneFromCreativeId { get; set; } // CloneFromCreativeID
        public string VideoSpecUrl { get; set; } // VideoSpecUrl
        public bool? UrlValidated { get; set; } // UrlValidated
        public int ExpandableDirectionId { get; set; } // ExpandableDirectionID
        public int AdvertiserProductId { get; set; } // AdvertiserProductID
        public int ThumbnailStatusId { get; set; } // ThumbnailStatusID
        public string FbTitleText { get; set; } // FbTitleText
        public string FbBodyText { get; set; } // FbBodyText
        public string FbImageHash { get; set; } // FbImageHash
        public string FbImageUrl { get; set; } // FbImageUrl
        public int ExpandableActionId { get; set; } // ExpandableActionID
        public string FlexTileLabel { get; set; } // FlexTileLabel
        public bool? IsSsl { get; set; } // IsSsl
        public decimal? CreativeHostingFee { get; set; } // CreativeHostingFee

        // Reverse navigation
        public virtual ICollection<CreativeAttribute> CreativeAttributes { get; set; } // Many to many mapping
        public virtual ICollection<CreativeParameter> CreativeParameters { get; set; } // Many to many mapping
        public virtual ICollection<CreativeReview> CreativeReviews { get; set; } // Many to many mapping
        public virtual ICollection<Placement> Placements { get; set; } // Placement.FK_Placement_Creative
        public virtual ICollection<SensitiveCategory> SensitiveCategories { get; set; } // Many to many mapping
        public virtual ICollection<Technology> Technologies { get; set; } // Many to many mapping
        public virtual ICollection<User> Users { get; set; } // Many to many mapping

        // Foreign keys
        public virtual AdTagTemplate AdTagTemplate { get; set; } // FK_Creative_AdTagTemplate
        public virtual AdvertiserProduct AdvertiserProduct { get; set; } // FK_Creative_AdvertiserProduct
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_Creative_BuyerAccount
        public virtual CampaignStatus CampaignStatus { get; set; } // FK_Creative_CampaignStatus
        public virtual CreativeFile CreativeFile { get; set; } // FK_Creative_CreativeFile
        public virtual CreativeSize CreativeSize { get; set; } // FK_Creative_CreativeSize
        public virtual CreativeType CreativeType { get; set; } // FK_Creative_CreativeType
        public virtual ExpandableAction ExpandableAction { get; set; } // FK_Creative_ExpandableAction
        public virtual ExpandableDirection ExpandableDirection { get; set; } // FK_Creative_ExpandableDirection
        public virtual Language Language { get; set; } // FK_Creative_LanguageID
        
        public Creative()
        {
            CreativeStatusId = 4;
            IsDeleted = false;
            UtcCreatedDateTime = System.DateTime.Now;
            UtcModifiedDateTime = System.DateTime.Now;
            LanguageId = 255;
            ExpandableDirectionId = 0;
            ThumbnailStatusId = 0;
            ExpandableActionId = 0;
            CreativeParameters = new List<CreativeParameter>();
            CreativeReviews = new List<CreativeReview>();
            Placements = new List<Placement>();
            SensitiveCategories = new List<SensitiveCategory>();
            Technologies = new List<Technology>();
            CreativeAttributes = new List<CreativeAttribute>();
            Users = new List<User>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeAttribute
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class CreativeAttribute : Entity
    {
        public int CreativeAttributeId { get; set; } // CreativeAttributeID (Primary key)
        public string CreativeAttributeName { get; set; } // CreativeAttributeName

        // Reverse navigation
        public virtual ICollection<Creative> Creatives { get; set; } // Many to many mapping
        
        public CreativeAttribute()
        {
            Creatives = new List<Creative>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeAuditStatus
    public partial class CreativeAuditStatu : Entity
    {
        public int CreativeAuditStatusId { get; set; } // CreativeAuditStatusID (Primary key)
        public string CreativeAuditStatusName { get; set; } // CreativeAuditStatusName
        
        public CreativeAuditStatu()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeConversionSegmentMongoExportView
    public partial class CreativeConversionSegmentMongoExportView : Entity
    {
        public Guid PlacementUuid { get; set; } // PlacementUuid
        public string RtbSegmentId { get; set; } // RtbSegmentID
        
        public CreativeConversionSegmentMongoExportView()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeFile
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class CreativeFile : Entity
    {
        public int CreativeFileId { get; set; } // CreativeFileID (Primary key)
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public string FileName { get; set; } // FileName
        public string BrandscreenFileName { get; set; } // BrandscreenFileName
        public int FileSize { get; set; } // FileSize
        public string FileExtension { get; set; } // FileExtension
        public int? Width { get; set; } // Width
        public int? Height { get; set; } // Height
        public string RelativePath { get; set; } // RelativePath
        public string Tags { get; set; } // Tags
        public string Description { get; set; } // Description
        public DateTime CreatedDateTime { get; set; } // CreatedDateTime
        public DateTime? LastUsed { get; set; } // LastUsed
        public bool IsDeleted { get; set; } // IsDeleted
        public string ErrorMessage { get; set; } // ErrorMessage
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime

        // Reverse navigation
        public virtual ICollection<Creative> Creatives { get; set; } // Creative.FK_Creative_CreativeFile

        // Foreign keys
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_CreativeFile_BuyerAccountID
        
        public CreativeFile()
        {
            UtcCreatedDateTime = System.DateTime.Now;
            UtcModifiedDateTime = System.DateTime.Now;
            Creatives = new List<Creative>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeFileStatus
    public partial class CreativeFileStatu : Entity
    {
        public int CreativeFileStatusId { get; set; } // CreativeFileStatusID (Primary key)
        public string CreativeFileStatusName { get; set; } // CreativeFileStatusName
        public string CreativeFileStatusDescription { get; set; } // CreativeFileStatusDescription
        
        public CreativeFileStatu()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeMongoExportView
    public partial class CreativeMongoExportView : Entity
    {
        public Guid PlacementUuid { get; set; } // PlacementUuid
        public int PlacementId { get; set; } // PlacementID
        public Guid CreativeUuid { get; set; } // CreativeUuid
        public int CreativeId { get; set; } // CreativeID
        public int AdGroupId { get; set; } // AdGroupId
        public Guid AdGroupUuid { get; set; } // AdGroupUuid
        public string CreativeName { get; set; } // CreativeName
        public string ClickThroughUrl { get; set; } // ClickThroughUrl
        public string ClickTrackerUrl { get; set; } // ClickTrackerUrl
        public int PlacementStatusId { get; set; } // PlacementStatusID
        public string CurrencyCodeIso4217 { get; set; } // CurrencyCodeIso4217
        public string TimeZoneCode { get; set; } // TimeZoneCode
        public int BuyerAccountId { get; set; } // BuyerAccountId
        public decimal Brokerage { get; set; } // Brokerage
        public decimal MarkupMultiplier { get; set; } // MarkupMultiplier
        public int? ServiceFeePctMicros { get; set; } // ServiceFeePctMicros
        public int CampaignId { get; set; } // CampaignID
        public Guid CampaignUuid { get; set; } // CampaignUuid
        public int AdvertiserId { get; set; } // AdvertiserId
        public int AdvertiserProductId { get; set; } // AdvertiserProductId
        public int? ProductCategoryId { get; set; } // ProductCategoryId
        public DateTime CreativeUtcCreatedDateTime { get; set; } // Creative_UtcCreatedDateTime
        public DateTime CreativeUtcModifiedDateTime { get; set; } // Creative_UtcModifiedDateTime
        public DateTime PlacementUtcCreatedDateTime { get; set; } // Placement_UtcCreatedDateTime
        public DateTime PlacementUtcModifiedDateTime { get; set; } // Placement_UtcModifiedDateTime
        public int? FrequencyGroupId { get; set; } // FrequencyGroupID
        public string OlsonTimezoneName { get; set; } // OlsonTimezoneName
        
        public CreativeMongoExportView()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeParameter
    public partial class CreativeParameter : Entity
    {
        public int CreativeId { get; set; } // CreativeID (Primary key)
        public string CreativeParameterKey { get; set; } // CreativeParameterKey (Primary key)
        public string CreativeParameterValue { get; set; } // CreativeParameterValue

        // Foreign keys
        public virtual Creative Creative { get; set; } // FK_CreativeParameter_Creative
        
        public CreativeParameter()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeReview
    public partial class CreativeReview : Entity
    {
        public int CreativeId { get; set; } // CreativeID (Primary key)
        public int PartnerId { get; set; } // PartnerID (Primary key)
        public int CreativeReviewStatusId { get; set; } // CreativeReviewStatusID
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public string ExchangeErrorString { get; set; } // ExchangeErrorString

        // Foreign keys
        public virtual Creative Creative { get; set; } // FK_CreativeReview_Creative
        public virtual CreativeReviewStatus CreativeReviewStatus { get; set; } // FK_CreativeReview_CreativeReviewStatus
        public virtual Partner Partner { get; set; } // PK_CreativeReview_Partner
        
        public CreativeReview()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeReviewConfiguration
    public partial class CreativeReviewConfiguration : Entity
    {
        public string Key { get; set; } // Key (Primary key)
        public string Value { get; set; } // Value
        
        public CreativeReviewConfiguration()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeReviewLookup
    public partial class CreativeReviewLookup : Entity
    {
        public string CreativeName { get; set; } // CreativeName
        public string RtbCreativeId { get; set; } // RtbCreativeID
        public int CreativeId { get; set; } // CreativeID
        public int AdvertiserProductId { get; set; } // AdvertiserProductID
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public int AdGroupId { get; set; } // AdGroupID
        public int CampaignId { get; set; } // CampaignID
        public int AdvertiserId { get; set; } // AdvertiserID
        public int? Width { get; set; } // Width
        public int? Height { get; set; } // Height
        public string CompanyName { get; set; } // CompanyName
        public string AdvertiserName { get; set; } // AdvertiserName
        public string CampaignName { get; set; } // CampaignName
        public string AdGroupName { get; set; } // AdGroupName
        public long? PartnerId { get; set; } // PartnerID
        public int? CreativeReviewStatusId { get; set; } // CreativeReviewStatusID
        
        public CreativeReviewLookup()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeReviewRejection
    public partial class CreativeReviewRejection : Entity
    {
        public int CreativeId { get; set; } // CreativeID (Primary key)
        public int PartnerId { get; set; } // PartnerID (Primary key)
        public int RejectionReasonId { get; set; } // RejectionReasonId (Primary key)

        // Foreign keys
        
        public CreativeReviewRejection()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeReviewStatus
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class CreativeReviewStatus : Entity
    {
        public int CreativeReviewStatusId { get; set; } // CreativeReviewStatusID (Primary key)
        public string CreativeReviewStatus_ { get; set; } // CreativeReviewStatus

        // Reverse navigation
        public virtual ICollection<AdvertiserReview> AdvertiserReviews { get; set; } // AdvertiserReview.FK_AdvertiserReview_CreativeReviewStatus
        public virtual ICollection<CreativeReview> CreativeReviews { get; set; } // CreativeReview.FK_CreativeReview_CreativeReviewStatus
        
        public CreativeReviewStatus()
        {
            AdvertiserReviews = new List<AdvertiserReview>();
            CreativeReviews = new List<CreativeReview>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeSize
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class CreativeSize : Entity
    {
        public int CreativeSizeId { get; set; } // CreativeSizeID (Primary key)
        public string CreativeSizeName { get; set; } // CreativeSizeName
        public int? Height { get; set; } // Height
        public int? Width { get; set; } // Width
        public decimal? Score { get; set; } // Score
        public bool? IsActive { get; set; } // IsActive
        public bool? IsUniversalAdPackage { get; set; } // IsUniversalAdPackage
        public int MediaTypeId { get; set; } // MediaTypeID

        // Reverse navigation
        public virtual ICollection<AdSlot> AdSlots { get; set; } // AdSlot.FK_AdSlot_CreativeSize
        public virtual ICollection<BuyerAccountApplicationCreativeSize> BuyerAccountApplicationCreativeSizes { get; set; } // Many to many mapping
        public virtual ICollection<Creative> Creatives { get; set; } // Creative.FK_Creative_CreativeSize
        public virtual ICollection<CreativeSpecification> CreativeSpecifications { get; set; } // CreativeSpecification.FK_CreativeSpecification_CreativeSize
        public virtual ICollection<DoohPanel> DoohPanels { get; set; } // DoohPanel.FK_DoohPanel_CreativeSize
        
        public CreativeSize()
        {
            IsActive = true;
            MediaTypeId = 1;
            AdSlots = new List<AdSlot>();
            BuyerAccountApplicationCreativeSizes = new List<BuyerAccountApplicationCreativeSize>();
            Creatives = new List<Creative>();
            CreativeSpecifications = new List<CreativeSpecification>();
            DoohPanels = new List<DoohPanel>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeSourceType
    public partial class CreativeSourceType : Entity
    {
        public int CreativeSourceTypeId { get; set; } // CreativeSourceTypeID (Primary key)
        public string SourceType { get; set; } // SourceType
        public int? Position { get; set; } // Position
        public bool IsActive { get; set; } // IsActive
        
        public CreativeSourceType()
        {
            IsActive = false;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeSpecification
    public partial class CreativeSpecification : Entity
    {
        public int CreativeSpecificationId { get; set; } // CreativeSpecificationID (Primary key)
        public int CreativeTypeId { get; set; } // CreativeTypeID
        public int CreativeSizeId { get; set; } // CreativeSizeID
        public int MaxFileSizeKb { get; set; } // MaxFileSizeKB

        // Foreign keys
        public virtual CreativeSize CreativeSize { get; set; } // FK_CreativeSpecification_CreativeSize
        public virtual CreativeType CreativeType { get; set; } // FK_CreativeSpecification_CreativeType
        
        public CreativeSpecification()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CreativeType
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class CreativeType : Entity
    {
        public int CreativeTypeId { get; set; } // CreativeTypeID (Primary key)
        public string CreativeTypeName { get; set; } // CreativeTypeName
        public string AllowedFileExtensions { get; set; } // AllowedFileExtensions
        public bool IsActive { get; set; } // IsActive

        // Reverse navigation
        public virtual ICollection<AdTagTemplate> AdTagTemplates { get; set; } // AdTagTemplate.FK_AdTagTemplate_CreativeTypeID
        public virtual ICollection<Creative> Creatives { get; set; } // Creative.FK_Creative_CreativeType
        public virtual ICollection<CreativeSpecification> CreativeSpecifications { get; set; } // CreativeSpecification.FK_CreativeSpecification_CreativeType
        
        public CreativeType()
        {
            IsActive = true;
            AdTagTemplates = new List<AdTagTemplate>();
            Creatives = new List<Creative>();
            CreativeSpecifications = new List<CreativeSpecification>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Currency
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Currency : Entity
    {
        public int CurrencyId { get; set; } // CurrencyID (Primary key)
        public string CurrencyName { get; set; } // CurrencyName
        public string Iso4217Code { get; set; } // ISO4217Code
        public string FormatSpecification { get; set; } // FormatSpecification
        public decimal? LocalToUsdRate { get; set; } // LocalToUSDRate
        public bool? IsActive { get; set; } // IsActive
        public int? CountryId { get; set; } // CountryID
        public decimal MinBudget { get; set; } // MinBudget
        public decimal MinTargetRateCpm { get; set; } // MinTargetRateCpm
        public decimal MinTargetRateCpc { get; set; } // MinTargetRateCpc
        public decimal MinTargetRateCpa { get; set; } // MinTargetRateCpa
        public decimal MinBid { get; set; } // MinBid
        public decimal MinSpendLimit { get; set; } // MinSpendLimit
        public string Iso4646Code { get; set; } // ISO4646Code

        // Reverse navigation
        public virtual ICollection<BuyerAccount> BuyerAccounts { get; set; } // BuyerAccount.FK_BuyerAccount_Currency
        public virtual ICollection<Country> Countries { get; set; } // Country.FK_Country_Currency
        public virtual ICollection<Deal> Deals { get; set; } // Deal.FK_Deal_Currency
        
        public Currency()
        {
            MinBudget = 1m;
            MinTargetRateCpm = 0.1m;
            MinTargetRateCpc = 0.1m;
            MinTargetRateCpa = 0.1m;
            MinBid = 0.1m;
            MinSpendLimit = 1m;
            BuyerAccounts = new List<BuyerAccount>();
            Countries = new List<Country>();
            Deals = new List<Deal>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CustomCreativeParameter
    public partial class CustomCreativeParameter : Entity
    {
        public int CustomCreativeParameterId { get; set; } // CustomCreativeParameterID (Primary key)
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public string MatchPredicate { get; set; } // MatchPredicate
        public string CreativeParameterKey { get; set; } // CreativeParameterKey
        public string CreativeParameterValue { get; set; } // CreativeParameterValue

        // Foreign keys
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_BuyerAccountID
        
        public CustomCreativeParameter()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CustomCreativeTechnology
    public partial class CustomCreativeTechnology : Entity
    {
        public int CustomCreativeTechnologyId { get; set; } // CustomCreativeTechnologyID (Primary key)
        public string MatchPredicate { get; set; } // MatchPredicate
        public int TechnologyId { get; set; } // TechnologyID

        // Foreign keys
        public virtual Technology Technology { get; set; } // FK_CustomCreativeTechnology_Technology
        
        public CustomCreativeTechnology()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CustomPublisherList
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class CustomPublisherList : Entity
    {
        public int CustomPublisherListId { get; set; } // CustomPublisherListID (Primary key)
        public string ListName { get; set; } // ListName
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public int? CloneFromCustomPublisherListId { get; set; } // CloneFromCustomPublisherListID

        // Reverse navigation
        public virtual ICollection<BuyerAccount> BuyerAccounts { get; set; } // Many to many mapping
        public virtual ICollection<Publisher> Publishers { get; set; } // Many to many mapping

        // Foreign keys
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_CustomPublisherList_BuyerAccountID
        
        public CustomPublisherList()
        {
            Publishers = new List<Publisher>();
            BuyerAccounts = new List<BuyerAccount>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CustomWhiteList
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class CustomWhiteList : Entity
    {
        public int Id { get; set; } // ID (Primary key)
        public string ListName { get; set; } // ListName
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public int? CloneFromCustomWhiteListId { get; set; } // CloneFromCustomWhiteListID

        // Reverse navigation
        public virtual ICollection<AdvertiserProduct> AdvertiserProducts { get; set; } // Many to many mapping

        // Foreign keys
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_CustomWhiteList_BuyerAccount
        
        public CustomWhiteList()
        {
            AdvertiserProducts = new List<AdvertiserProduct>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CustomWhiteListChangeLog
    public partial class CustomWhiteListChangeLog : Entity
    {
        public long Id { get; set; } // ID (Primary key)
        public int CustomWhiteListId { get; set; } // CustomWhiteListID
        public string WebsiteUrl { get; set; } // WebsiteUrl
        public string Operation { get; set; } // Operation
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public Guid UserId { get; set; } // UserID
        public Guid? ActualUserId { get; set; } // ActualUserID
        
        public CustomWhiteListChangeLog()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // CustomWhiteListWebsite
    public partial class CustomWhiteListWebsite : Entity
    {
        public int CustomWhiteListId { get; set; } // CustomWhiteListID (Primary key)
        public long WebsiteId { get; set; } // WebsiteID (Primary key)
        public string WebsiteUrl { get; set; } // WebsiteUrl
        
        public CustomWhiteListWebsite()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // DataSegmentView
    public partial class DataSegmentView : Entity
    {
        public int? BuyerAccountId { get; set; } // BuyerAccountID
        public int AdvertiserId { get; set; } // AdvertiserID
        public string AdvertiserName { get; set; } // AdvertiserName
        public int SegmentId { get; set; } // SegmentID
        public string SegmentName { get; set; } // SegmentName
        public int SegmentTypeId { get; set; } // SegmentTypeID
        public int? DeliveredUniques { get; set; } // DeliveredUniques
        public int? RecencyInDays { get; set; } // RecencyInDays
        public int CampaignStatusId { get; set; } // CampaignStatusID
        public bool IsDeleted { get; set; } // IsDeleted
        public string RtbSegmentId { get; set; } // RtbSegmentId
        public Guid AdvertiserUuId { get; set; } // AdvertiserUuID
        
        public DataSegmentView()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // DayPart
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class DayPart : Entity
    {
        public int DayPartId { get; set; } // DayPartID (Primary key)
        public string DayPartName { get; set; } // DayPartName
        public string DayOfWeekName { get; set; } // DayOfWeekName
        public string HourOfDayName { get; set; } // HourOfDayName
        public bool IsEnabled { get; set; } // IsEnabled

        // Reverse navigation
        public virtual ICollection<AdGroupDayPart> AdGroupDayParts { get; set; } // Many to many mapping
        
        public DayPart()
        {
            AdGroupDayParts = new List<AdGroupDayPart>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Deal
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Deal : Entity
    {
        public int DealId { get; set; } // DealID (Primary key)
        public string DealKey { get; set; } // DealKey
        public string DealName { get; set; } // DealName
        public int PublisherId { get; set; } // PublisherID
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public int DealTypeId { get; set; } // DealTypeID
        public int FloorPriceCents { get; set; } // FloorPriceCents
        public int CeilingPriceCents { get; set; } // CeilingPriceCents
        public DateTime UtcStartDateTime { get; set; } // UtcStartDateTime
        public DateTime UtcEndDateTime { get; set; } // UtcEndDateTime
        public int DealStatusId { get; set; } // DealStatusID
        public Guid DealUuid { get; set; } // DealUuid
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime? UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public int CurrencyId { get; set; } // CurrencyID
        public string PublishersName { get; set; } // PublishersName
        public int DealModeId { get; set; } // DealModeID
        public string OverrideDisplayUrl { get; set; } // OverrideDisplayUrl
        public int? VerticalId { get; set; } // VerticalID
        public string DealReference { get; set; } // DealReference

        // Reverse navigation
        public virtual ICollection<AdGroupDeal> AdGroupDeals { get; set; } // Many to many mapping
        public virtual ICollection<AdSlot> AdSlots { get; set; } // AdSlot.FK_AdSlot_Deal
        public virtual ICollection<DealPerformance> DealPerformances { get; set; } // Many to many mapping

        // Foreign keys
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_Deal_BuyerAccount
        public virtual CampaignStatus CampaignStatus { get; set; } // FK_Deal_CampaignStatus
        public virtual Currency Currency { get; set; } // FK_Deal_Currency
        public virtual DealMode DealMode { get; set; } // FK_Deal_DealMode
        public virtual DealType DealType { get; set; } // FK_Deal_DealType
        public virtual Publisher Publisher { get; set; } // FK_Deal_Publisher
        public virtual Vertical Vertical { get; set; } // FK_Deal_Vertical
        
        public Deal()
        {
            CurrencyId = 0;
            DealModeId = 1;
            AdGroupDeals = new List<AdGroupDeal>();
            AdSlots = new List<AdSlot>();
            DealPerformances = new List<DealPerformance>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // DealMode
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class DealMode : Entity
    {
        public int DealModeId { get; set; } // DealModeID (Primary key)
        public string DealModeName { get; set; } // DealModeName

        // Reverse navigation
        public virtual ICollection<Deal> Deals { get; set; } // Deal.FK_Deal_DealMode
        
        public DealMode()
        {
            Deals = new List<Deal>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // DealPerformance
    public partial class DealPerformance : Entity
    {
        public int DealId { get; set; } // DealID (Primary key)
        public int IntervalId { get; set; } // IntervalID (Primary key)
        public int IntervalValue { get; set; } // IntervalValue (Primary key)
        public long Bids { get; set; } // Bids
        public long Impressions { get; set; } // Impressions
        public long Clicks { get; set; } // Clicks
        public long Conversions { get; set; } // Conversions
        public long PostViewConversions { get; set; } // PostViewConversions
        public long PostClickConversions { get; set; } // PostClickConversions
        public DateTime? LastActivityTimestamp { get; set; } // LastActivityTimestamp
        public double? Ctr { get; set; } // CTR
        public long MediaCostLocalMicros { get; set; } // MediaCostLocalMicros
        public long DataCostLocalMicros { get; set; } // DataCostLocalMicros
        public long? SpendLocalMicros { get; set; } // SpendLocalMicros
        public long MediaClientCostLocalMicros { get; set; } // MediaClientCostLocalMicros
        public long DataClientCostLocalMicros { get; set; } // DataClientCostLocalMicros
        public long? ClientCostLocalMicros { get; set; } // ClientCostLocalMicros
        public decimal? Cpm { get; set; } // CPM
        public decimal? Cpc { get; set; } // CPC
        public decimal? Cpa { get; set; } // CPA
        public decimal? ClientCostCpm { get; set; } // ClientCostCPM
        public decimal? ClientCostCpc { get; set; } // ClientCostCPC
        public decimal? ClientCostCpa { get; set; } // ClientCostCPA
        public int PricingHealth { get; set; } // PricingHealth
        public int PacingHealth { get; set; } // PacingHealth
        public decimal? Cvr { get; set; } // Cvr
        public decimal? BidWin { get; set; } // BidWin
        public long AdSlotDurationInSeconds { get; set; } // AdSlotDurationInSeconds
        public long RawViews { get; set; } // RawViews
        public long IabViews { get; set; } // IabViews
        public long ViewDurationInSeconds { get; set; } // ViewDurationInSeconds
        public decimal? CpMs { get; set; } // CPMs
        public decimal? ClientCostCpMs { get; set; } // ClientCostCPMs
        public decimal? Cps { get; set; } // CPS
        public decimal? ClientCostCps { get; set; } // ClientCostCPS
        public decimal? ViewableRatio { get; set; } // ViewableRatio

        // Foreign keys
        public virtual Deal Deal { get; set; } // FK_DealPerformance_Deal
        public virtual Interval Interval { get; set; } // FK_DealPerformance_Interval
        
        public DealPerformance()
        {
            MediaCostLocalMicros = 0;
            DataCostLocalMicros = 0;
            MediaClientCostLocalMicros = 0;
            DataClientCostLocalMicros = 0;
            PricingHealth = 1;
            PacingHealth = 1;
            AdSlotDurationInSeconds = 0;
            RawViews = 0;
            IabViews = 0;
            ViewDurationInSeconds = 0;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // DealType
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class DealType : Entity
    {
        public int DealTypeId { get; set; } // DealTypeID (Primary key)
        public string DealTypeName { get; set; } // DealTypeName

        // Reverse navigation
        public virtual ICollection<Deal> Deals { get; set; } // Deal.FK_Deal_DealType
        
        public DealType()
        {
            Deals = new List<Deal>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Device
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Device : Entity
    {
        public int DeviceId { get; set; } // DeviceID (Primary key)
        public string DeviceName { get; set; } // DeviceName

        // Reverse navigation
        public virtual ICollection<AdGroupDevice> AdGroupDevices { get; set; } // Many to many mapping
        
        public Device()
        {
            AdGroupDevices = new List<AdGroupDevice>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Domain
    public partial class Domain : Entity
    {
        public int DomainListId { get; set; } // DomainListID (Primary key)
        public string DomainName { get; set; } // DomainName (Primary key)
        public string Comment { get; set; } // Comment

        // Foreign keys
        public virtual DomainList DomainList { get; set; } // FK_Domain_DomainList
        
        public Domain()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // DomainList
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class DomainList : Entity
    {
        public int DomainListId { get; set; } // DomainListID (Primary key)
        public string DomainListName { get; set; } // DomainListName
        public int? BuyerAccountId { get; set; } // BuyerAccountID
        public int? CloneFromDomainListId { get; set; } // CloneFromDomainListID
        public int? AdGroupId { get; set; } // AdGroupID
        public int DomainListType { get; set; } // DomainListType
        public string Description { get; set; } // Description
        public string Owner { get; set; } // Owner
        public int? SiteCount { get; set; } // SiteCount

        // Reverse navigation
        public virtual ICollection<AdGroupDomainList> AdGroupDomainLists { get; set; } // Many to many mapping
        public virtual ICollection<AdvertiserDomainList> AdvertiserDomainLists { get; set; } // Many to many mapping
        public virtual ICollection<AdvertiserProductDomainList> AdvertiserProductDomainLists { get; set; } // Many to many mapping
        public virtual ICollection<BuyerAccountDomainList> BuyerAccountDomainLists { get; set; } // Many to many mapping
        public virtual ICollection<CampaignDomainList> CampaignDomainLists { get; set; } // Many to many mapping
        public virtual ICollection<Domain> Domains { get; set; } // Many to many mapping

        // Foreign keys
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_DomainList_BuyerAccount
        
        public DomainList()
        {
            AdGroupDomainLists = new List<AdGroupDomainList>();
            AdvertiserDomainLists = new List<AdvertiserDomainList>();
            AdvertiserProductDomainLists = new List<AdvertiserProductDomainList>();
            BuyerAccountDomainLists = new List<BuyerAccountDomainList>();
            CampaignDomainLists = new List<CampaignDomainList>();
            Domains = new List<Domain>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // DomainListInvertedIndexes
    public partial class DomainListInvertedIndex : Entity
    {
        public string DomainName { get; set; } // DomainName
        public string DomainListIDs { get; set; } // DomainListIDs
        
        public DomainListInvertedIndex()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // DoohChannel
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class DoohChannel : Entity
    {
        public int DoohChannelId { get; set; } // DoohChannelID (Primary key)
        public string ChannelName { get; set; } // ChannelName

        // Reverse navigation
        public virtual ICollection<DoohPanel> DoohPanels { get; set; } // DoohPanel.FK_DoohPanel_DoohChannel
        
        public DoohChannel()
        {
            DoohPanels = new List<DoohPanel>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // DoohFormat
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class DoohFormat : Entity
    {
        public int DoohFormatId { get; set; } // DoohFormatID (Primary key)
        public string FormatName { get; set; } // FormatName

        // Reverse navigation
        public virtual ICollection<DoohPanel> DoohPanels { get; set; } // DoohPanel.FK_DoohPanel_DoohFormat
        
        public DoohFormat()
        {
            DoohPanels = new List<DoohPanel>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // DoohGeoLocationGroup
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class DoohGeoLocationGroup : Entity
    {
        public int DoohGeoLocationGroupId { get; set; } // DoohGeoLocationGroupID (Primary key)
        public int GeoCountryId { get; set; } // GeoCountryID
        public int? GeoRegionId { get; set; } // GeoRegionID
        public int? GeoCityId { get; set; } // GeoCityID
        public string LocationGroupName { get; set; } // LocationGroupName
        public int GeoLocationId { get; set; } // GeoLocationID
        public decimal? Latitude { get; set; } // Latitude
        public decimal? Longitude { get; set; } // Longitude
        public decimal? RadiusInKm { get; set; } // RadiusInKm

        // Reverse navigation
        public virtual ICollection<AdGroupDoohGeoLocationGroup> AdGroupDoohGeoLocationGroups { get; set; } // Many to many mapping
        public virtual ICollection<DoohLocation> DoohLocations { get; set; } // DoohLocation.FK_DoohLocation_DoohGeoLocationGroup

        // Foreign keys
        public virtual GeoCity GeoCity { get; set; } // FK_DoohGeoLocationGroup_GeoCity
        public virtual GeoCountry GeoCountry { get; set; } // FK_DoohGeoLocationGroup_GeoCountry
        public virtual GeoRegion GeoRegion { get; set; } // FK_DoohGeoLocationGroup_GeoRegion
        
        public DoohGeoLocationGroup()
        {
            AdGroupDoohGeoLocationGroups = new List<AdGroupDoohGeoLocationGroup>();
            DoohLocations = new List<DoohLocation>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // DoohLocation
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class DoohLocation : Entity
    {
        public int DoohLocationId { get; set; } // DoohLocationID (Primary key)
        public int DoohGeoLocationGroupId { get; set; } // DoohGeoLocationGroupID
        public string Name { get; set; } // Name
        public decimal? Latitude { get; set; } // Latitude
        public decimal? Longitude { get; set; } // Longitude
        public decimal? RadiusInKm { get; set; } // RadiusInKm

        // Reverse navigation
        public virtual ICollection<DoohPanelLocation> DoohPanelLocations { get; set; } // DoohPanelLocation.FK_DoohPanelLocation_DoohLocation

        // Foreign keys
        public virtual DoohGeoLocationGroup DoohGeoLocationGroup { get; set; } // FK_DoohLocation_DoohGeoLocationGroup
        
        public DoohLocation()
        {
            DoohPanelLocations = new List<DoohPanelLocation>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // DoohPanel
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class DoohPanel : Entity
    {
        public int DoohPanelId { get; set; } // DoohPanelID (Primary key)
        public int DoohChannelId { get; set; } // DoohChannelID
        public int DoohFormatId { get; set; } // DoohFormatID
        public int CreativeSizeId { get; set; } // CreativeSizeID

        // Reverse navigation
        public virtual ICollection<DoohPanelLocation> DoohPanelLocations { get; set; } // DoohPanelLocation.FK_DoohPanelLocation_DoohPanel

        // Foreign keys
        public virtual CreativeSize CreativeSize { get; set; } // FK_DoohPanel_CreativeSize
        public virtual DoohChannel DoohChannel { get; set; } // FK_DoohPanel_DoohChannel
        public virtual DoohFormat DoohFormat { get; set; } // FK_DoohPanel_DoohFormat
        
        public DoohPanel()
        {
            DoohPanelLocations = new List<DoohPanelLocation>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // DoohPanelLocation
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class DoohPanelLocation : Entity
    {
        public int DoohPanelLocationId { get; set; } // DOOHPanelLocationID (Primary key)
        public int DoohPanelId { get; set; } // DoohPanelID
        public int DoohLocationId { get; set; } // DoohLocationID
        public string PanelUrl { get; set; } // PanelUrl
        public string PanelId { get; set; } // PanelID
        public string PanelLocationName { get; set; } // PanelLocationName
        public long? AudienceSize { get; set; } // AudienceSize
        public int PartnerId { get; set; } // PartnerID

        // Reverse navigation
        public virtual ICollection<AdGroupDoohPanelLocation> AdGroupDoohPanelLocations { get; set; } // Many to many mapping

        // Foreign keys
        public virtual DoohLocation DoohLocation { get; set; } // FK_DoohPanelLocation_DoohLocation
        public virtual DoohPanel DoohPanel { get; set; } // FK_DoohPanelLocation_DoohPanel
        public virtual Partner Partner { get; set; } // FK_DoohPanelLocation_Partner
        
        public DoohPanelLocation()
        {
            AdGroupDoohPanelLocations = new List<AdGroupDoohPanelLocation>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // EntityLabel
    public partial class EntityLabel : Entity
    {
        public int EntityId { get; set; } // EntityId (Primary key)
        public int LabelId { get; set; } // LabelId (Primary key)
        public byte EntityType { get; set; } // EntityType (Primary key)

        // Foreign keys
        public virtual Label Label { get; set; } // FK_EntityLabel_Label
        
        public EntityLabel()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // EntityUserTag
    public partial class EntityUserTag : Entity
    {
        public int EntityId { get; set; } // EntityId (Primary key)
        public int UserTagId { get; set; } // UserTagId (Primary key)
        public byte EntityType { get; set; } // EntityType (Primary key)

        // Foreign keys
        public virtual UserTag UserTag { get; set; } // FK_EntityUserTag_UserTag
        
        public EntityUserTag()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ExchangeBuyerIDLookup
    public partial class ExchangeBuyerIdLookup : Entity
    {
        public string PackageKey { get; set; } // PackageKey
        public string Value { get; set; } // Value
        public int BuyerAccountId { get; set; } // BuyerAccountID
        
        public ExchangeBuyerIdLookup()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ExchangeConfiguration
    public partial class ExchangeConfiguration : Entity
    {
        public int PartnerId { get; set; } // PartnerID (Primary key)
        public bool NoContentOnNoBid { get; set; } // NoContentOnNoBid
        public string CurrencyCode { get; set; } // CurrencyCode
        public string EncryptionKey { get; set; } // EncryptionKey
        public string IntegrityKey { get; set; } // IntegrityKey
        public bool IsLive { get; set; } // IsLive
        public int BidRatio { get; set; } // BidRatio
        public string ClickUrlMacro { get; set; } // ClickUrlMacro
        public string AuctionPriceMacro { get; set; } // AuctionPriceMacro
        public int PriceEncryptionMethod { get; set; } // PriceEncryptionMethod

        // Foreign keys
        public virtual Partner Partner { get; set; } // FK_ExchangeConfiguration_Partner
        
        public ExchangeConfiguration()
        {
            NoContentOnNoBid = true;
            IsLive = false;
            BidRatio = 0;
            PriceEncryptionMethod = 1;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ExelateImport
    public partial class ExelateImport : Entity
    {
        public string RtbSegmentId { get; set; } // RtbSegmentID (Primary key)
        public int ExelateSegmentId { get; set; } // ExelateSegmentID
        public string SegmentName { get; set; } // SegmentName
        public string ParentRtbSegmentId { get; set; } // ParentRtbSegmentID
        public bool HasChildren { get; set; } // HasChildren
        public bool IsSelectable { get; set; } // IsSelectable
        public decimal Cost { get; set; } // Cost
        public int CampaignId { get; set; } // CampaignID
        
        public ExelateImport()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ExpandableAction
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class ExpandableAction : Entity
    {
        public int ExpandableActionId { get; set; } // ExpandableActionID (Primary key)
        public string ActionName { get; set; } // ActionName

        // Reverse navigation
        public virtual ICollection<Creative> Creatives { get; set; } // Creative.FK_Creative_ExpandableAction
        
        public ExpandableAction()
        {
            Creatives = new List<Creative>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ExpandableDirection
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class ExpandableDirection : Entity
    {
        public int ExpandableDirectionId { get; set; } // ExpandableDirectionID (Primary key)
        public string DirectionName { get; set; } // DirectionName

        // Reverse navigation
        public virtual ICollection<AdSlot> AdSlots { get; set; } // AdSlot.FK_AdSlot_ExpandableDirection
        public virtual ICollection<Creative> Creatives { get; set; } // Creative.FK_Creative_ExpandableDirection
        
        public ExpandableDirection()
        {
            AdSlots = new List<AdSlot>();
            Creatives = new List<Creative>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // EyeotaRateCard
    public partial class EyeotaRateCard : Entity
    {
        public string SegmentId { get; set; } // SegmentID (Primary key)
        public decimal Price { get; set; } // Price
        
        public EyeotaRateCard()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // EyeotaTaxonomyImport
    public partial class EyeotaTaxonomyImport : Entity
    {
        public string SegmentId { get; set; } // SegmentID (Primary key)
        public string ParentSegmentId { get; set; } // ParentSegmentID
        public string SegmentName { get; set; } // SegmentName
        
        public EyeotaTaxonomyImport()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // FrequencyCap
    public partial class FrequencyCap : Entity
    {
        public int FrequencyCapId { get; set; } // FrequencyCapID (Primary key)
        public int FrequencyGroupId { get; set; } // FrequencyGroupID
        public int Amount { get; set; } // Amount
        public int Duration { get; set; } // Duration
        public int PeriodId { get; set; } // PeriodID
        public int Mode { get; set; } // Mode

        // Foreign keys
        public virtual CampaignPeriod CampaignPeriod { get; set; } // FK_FrequencyCap_CampaignPeriod
        
        public FrequencyCap()
        {
            Mode = 0;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // FrequencyGroup
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class FrequencyGroup : Entity
    {
        public int FrequencyGroupId { get; set; } // FrequencyGroupID (Primary key)
        public string FrequencyGroupName { get; set; } // FrequencyGroupName
        public int CampaignId { get; set; } // CampaignID
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public bool IsDeleted { get; set; } // IsDeleted

        // Reverse navigation
        public virtual ICollection<AdGroup> AdGroups { get; set; } // AdGroup.FK_AdGroup_FrequencyGroup

        // Foreign keys
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_FrequencyGroup_BuyerAccount
        public virtual Campaign Campaign { get; set; } // FK_FrequencyGroup_Campaign
        
        public FrequencyGroup()
        {
            AdGroups = new List<AdGroup>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // GeoABSRegion
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class GeoAbsRegion : Entity
    {
        public int GeoAbsRegionId { get; set; } // GeoABSRegionID (Primary key)
        public string Sa4Name { get; set; } // SA4Name
        public string StateCode { get; set; } // StateCode
        public string StateName { get; set; } // StateName

        // Reverse navigation
        public virtual ICollection<GeoLocation> GeoLocations { get; set; } // Many to many mapping
        public virtual ICollection<GeoSuburb> GeoSuburbs { get; set; } // GeoSuburb.FK_GeoSuburb_GeoABSRegion
        
        public GeoAbsRegion()
        {
            GeoSuburbs = new List<GeoSuburb>();
            GeoLocations = new List<GeoLocation>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // GeoCity
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class GeoCity : Entity
    {
        public int GeoCityId { get; set; } // GeoCityID (Primary key)
        public int GeoCountryId { get; set; } // GeoCountryID
        public int? GeoRegionId { get; set; } // GeoRegionID
        public int? GeoMetroId { get; set; } // GeoMetroID
        public string CityName { get; set; } // CityName
        public double Latitude { get; set; } // Latitude
        public double Longitude { get; set; } // Longitude
        public long? GeoLocationId { get; set; } // GeoLocationID

        // Reverse navigation
        public virtual ICollection<DoohGeoLocationGroup> DoohGeoLocationGroups { get; set; } // DoohGeoLocationGroup.FK_DoohGeoLocationGroup_GeoCity
        public virtual ICollection<GeoLocation> GeoLocations { get; set; } // GeoLocation.FK_GeoLocation_GeoCity

        // Foreign keys
        public virtual GeoCountry GeoCountry { get; set; } // FK_GeoCity_GeoCountry
        public virtual GeoLocation GeoLocation { get; set; } // FK_GeoCity_GeoLocation
        public virtual GeoMetro GeoMetro { get; set; } // FK_GeoCity_GeoMetro
        public virtual GeoRegion GeoRegion { get; set; } // FK_GeoCity_GeoRegion
        
        public GeoCity()
        {
            DoohGeoLocationGroups = new List<DoohGeoLocationGroup>();
            GeoLocations = new List<GeoLocation>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // GeoCountry
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class GeoCountry : Entity
    {
        public int GeoCountryId { get; set; } // GeoCountryID (Primary key)
        public string Iso3166Code { get; set; } // ISO3166Code
        public string CountryName { get; set; } // CountryName
        public long? GeoLocationId { get; set; } // GeoLocationID

        // Reverse navigation
        public virtual ICollection<AdGroupGeoPostcode> AdGroupGeoPostcodes { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupMobileCarrier> AdGroupMobileCarriers { get; set; } // Many to many mapping
        public virtual ICollection<BuyerAccountApplicationGeoCountry> BuyerAccountApplicationGeoCountries { get; set; } // Many to many mapping
        public virtual ICollection<DoohGeoLocationGroup> DoohGeoLocationGroups { get; set; } // DoohGeoLocationGroup.FK_DoohGeoLocationGroup_GeoCountry
        public virtual ICollection<GeoCity> GeoCities { get; set; } // GeoCity.FK_GeoCity_GeoCountry
        public virtual ICollection<GeoLocation> GeoLocations { get; set; } // GeoLocation.FK_GeoLocation_GeoCountry
        public virtual ICollection<GeoMetro> GeoMetroes { get; set; } // GeoMetro.FK_GeoMetro_GeoCountry
        public virtual ICollection<GeoRegion> GeoRegions { get; set; } // GeoRegion.FK_GeoRegion_GeoCountry
        public virtual ICollection<SalesRegion> SalesRegions { get; set; } // Many to many mapping

        // Foreign keys
        public virtual GeoLocation GeoLocation { get; set; } // FK_GeoCountry_GeoLocation
        
        public GeoCountry()
        {
            AdGroupGeoPostcodes = new List<AdGroupGeoPostcode>();
            AdGroupMobileCarriers = new List<AdGroupMobileCarrier>();
            BuyerAccountApplicationGeoCountries = new List<BuyerAccountApplicationGeoCountry>();
            DoohGeoLocationGroups = new List<DoohGeoLocationGroup>();
            GeoCities = new List<GeoCity>();
            GeoLocations = new List<GeoLocation>();
            GeoMetroes = new List<GeoMetro>();
            GeoRegions = new List<GeoRegion>();
            SalesRegions = new List<SalesRegion>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // GeoLocation
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class GeoLocation : Entity
    {
        public long GeoLocationId { get; set; } // GeoLocationID (Primary key)
        public string GeoLocationCode { get; set; } // GeoLocationCode
        public int GeoCountryId { get; set; } // GeoCountryID
        public int? GeoRegionId { get; set; } // GeoRegionID
        public int? GeoMetroId { get; set; } // GeoMetroID
        public int? GeoCityId { get; set; } // GeoCityID

        // Reverse navigation
        public virtual ICollection<AdGroupGeoLocation> AdGroupGeoLocations { get; set; } // Many to many mapping
        public virtual ICollection<GeoAbsRegion> GeoAbsRegions { get; set; } // Many to many mapping
        public virtual ICollection<GeoCity> GeoCities { get; set; } // GeoCity.FK_GeoCity_GeoLocation
        public virtual ICollection<GeoCountry> GeoCountries { get; set; } // GeoCountry.FK_GeoCountry_GeoLocation
        public virtual ICollection<GeoRegion> GeoRegions { get; set; } // GeoRegion.FK_GeoRegion_GeoLocation
        public virtual ICollection<GeoSuburb> GeoSuburbs { get; set; } // GeoSuburb.FK_GeoSuburb_GeoLocation

        // Foreign keys
        public virtual GeoCity GeoCity { get; set; } // FK_GeoLocation_GeoCity
        public virtual GeoCountry GeoCountry { get; set; } // FK_GeoLocation_GeoCountry
        public virtual GeoMetro GeoMetro { get; set; } // FK_GeoLocation_GeoMetro
        public virtual GeoRegion GeoRegion { get; set; } // FK_GeoLocation_GeoRegion
        
        public GeoLocation()
        {
            AdGroupGeoLocations = new List<AdGroupGeoLocation>();
            GeoCities = new List<GeoCity>();
            GeoCountries = new List<GeoCountry>();
            GeoRegions = new List<GeoRegion>();
            GeoSuburbs = new List<GeoSuburb>();
            GeoAbsRegions = new List<GeoAbsRegion>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // GeoMetro
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class GeoMetro : Entity
    {
        public int GeoMetroId { get; set; } // GeoMetroID (Primary key)
        public int GeoCountryId { get; set; } // GeoCountryID
        public string MetroName { get; set; } // MetroName

        // Reverse navigation
        public virtual ICollection<GeoCity> GeoCities { get; set; } // GeoCity.FK_GeoCity_GeoMetro
        public virtual ICollection<GeoLocation> GeoLocations { get; set; } // GeoLocation.FK_GeoLocation_GeoMetro
        public virtual ICollection<GeoRegion> GeoRegions { get; set; } // Many to many mapping

        // Foreign keys
        public virtual GeoCountry GeoCountry { get; set; } // FK_GeoMetro_GeoCountry
        
        public GeoMetro()
        {
            GeoCities = new List<GeoCity>();
            GeoLocations = new List<GeoLocation>();
            GeoRegions = new List<GeoRegion>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // GeoRegion
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class GeoRegion : Entity
    {
        public int GeoRegionId { get; set; } // GeoRegionID (Primary key)
        public int GeoCountryId { get; set; } // GeoCountryID
        public string RegionCode { get; set; } // RegionCode
        public string RegionName { get; set; } // RegionName
        public string RegionShortName { get; set; } // RegionShortName
        public long? GeoLocationId { get; set; } // GeoLocationID

        // Reverse navigation
        public virtual ICollection<DoohGeoLocationGroup> DoohGeoLocationGroups { get; set; } // DoohGeoLocationGroup.FK_DoohGeoLocationGroup_GeoRegion
        public virtual ICollection<GeoCity> GeoCities { get; set; } // GeoCity.FK_GeoCity_GeoRegion
        public virtual ICollection<GeoLocation> GeoLocations { get; set; } // GeoLocation.FK_GeoLocation_GeoRegion
        public virtual ICollection<GeoMetro> GeoMetroes { get; set; } // Many to many mapping

        // Foreign keys
        public virtual GeoCountry GeoCountry { get; set; } // FK_GeoRegion_GeoCountry
        public virtual GeoLocation GeoLocation { get; set; } // FK_GeoRegion_GeoLocation
        
        public GeoRegion()
        {
            DoohGeoLocationGroups = new List<DoohGeoLocationGroup>();
            GeoCities = new List<GeoCity>();
            GeoLocations = new List<GeoLocation>();
            GeoMetroes = new List<GeoMetro>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // GeoSuburb
    public partial class GeoSuburb : Entity
    {
        public int GeoSuburbId { get; set; } // GeoSuburbID (Primary key)
        public int? GeoAbsRegionId { get; set; } // GeoABSRegionID
        public string SuburbName { get; set; } // SuburbName
        public double Latitude { get; set; } // Latitude
        public double Longitude { get; set; } // Longitude
        public long? GeoLocationId { get; set; } // GeoLocationID

        // Foreign keys
        public virtual GeoAbsRegion GeoAbsRegion { get; set; } // FK_GeoSuburb_GeoABSRegion
        public virtual GeoLocation GeoLocation { get; set; } // FK_GeoSuburb_GeoLocation
        
        public GeoSuburb()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // GoalType
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class GoalType : Entity
    {
        public int GoalTypeId { get; set; } // GoalTypeID (Primary key)
        public string GoalTypeName { get; set; } // GoalTypeName

        // Reverse navigation
        public virtual ICollection<AdGroup> AdGroups { get; set; } // AdGroup.FK_AdGroup_GoalType
        
        public GoalType()
        {
            AdGroups = new List<AdGroup>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // IkonProgrammaticReport
    public partial class IkonProgrammaticReport : Entity
    {
        public int BuyeraccountId { get; set; } // BuyeraccountId
        public int IntervalValue { get; set; } // IntervalValue
        public string AdvertiserName { get; set; } // AdvertiserName
        public int AdGroupId { get; set; } // AdGroupID
        public string AdGroupName { get; set; } // AdGroupName
        public string CampaignName { get; set; } // CampaignName
        public DateTime? UtcStartDateTime { get; set; } // UtcStartDateTime
        public DateTime? UtcEndDateTime { get; set; } // UtcEndDateTime
        public long Impressions { get; set; } // Impressions
        public long Clicks { get; set; } // Clicks
        public long PostViewConversions { get; set; } // PostViewConversions
        public long PostClickConversions { get; set; } // PostClickConversions
        public long Conversions { get; set; } // Conversions
        public long? SpendLocalMicros { get; set; } // SpendLocalMicros
        public long? ClientCostLocalMicros { get; set; } // ClientCostLocalMicros
        
        public IkonProgrammaticReport()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // IndustryCategory
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class IndustryCategory : Entity
    {
        public int IndustryCategoryId { get; set; } // IndustryCategoryID (Primary key)
        public string IndustryCategoryName { get; set; } // IndustryCategoryName
        public bool IsActive { get; set; } // IsActive

        // Reverse navigation
        public virtual ICollection<Advertiser> Advertisers { get; set; } // Advertiser.FK_Advertiser_IndustryCategory
        public virtual ICollection<ProductCategory> ProductCategories { get; set; } // ProductCategory.FK_ProductCategory_IndustryCategory
        
        public IndustryCategory()
        {
            IsActive = false;
            Advertisers = new List<Advertiser>();
            ProductCategories = new List<ProductCategory>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Interval
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Interval : Entity
    {
        public int IntervalId { get; set; } // IntervalID (Primary key)
        public string IntervalName { get; set; } // IntervalName

        // Reverse navigation
        public virtual ICollection<AdGroupPerformance> AdGroupPerformances { get; set; } // Many to many mapping
        public virtual ICollection<AdvertiserPerformance> AdvertiserPerformances { get; set; } // Many to many mapping
        public virtual ICollection<AdvertiserProductPerformance> AdvertiserProductPerformances { get; set; } // Many to many mapping
        public virtual ICollection<CampaignPerformance> CampaignPerformances { get; set; } // Many to many mapping
        public virtual ICollection<DealPerformance> DealPerformances { get; set; } // Many to many mapping
        public virtual ICollection<PlacementPerformance> PlacementPerformances { get; set; } // Many to many mapping
        public virtual ICollection<PrivateMarketPerformance> PrivateMarketPerformances { get; set; } // Many to many mapping
        public virtual ICollection<PrivateMarketSitePerformance> PrivateMarketSitePerformances { get; set; } // Many to many mapping
        public virtual ICollection<SegmentPerformance> SegmentPerformances { get; set; } // Many to many mapping
        
        public Interval()
        {
            AdGroupPerformances = new List<AdGroupPerformance>();
            AdvertiserPerformances = new List<AdvertiserPerformance>();
            AdvertiserProductPerformances = new List<AdvertiserProductPerformance>();
            CampaignPerformances = new List<CampaignPerformance>();
            DealPerformances = new List<DealPerformance>();
            PlacementPerformances = new List<PlacementPerformance>();
            PrivateMarketPerformances = new List<PrivateMarketPerformance>();
            PrivateMarketSitePerformances = new List<PrivateMarketSitePerformance>();
            SegmentPerformances = new List<SegmentPerformance>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Inventory
    public partial class Inventory : Entity
    {
        public long InventoryId { get; set; } // InventoryID (Primary key)
        public int PartnerId { get; set; } // PartnerID
        public int PublisherId { get; set; } // PublisherID
        public long WebsiteId { get; set; } // WebsiteID
        public string WebsiteUrl { get; set; } // WebsiteUrl
        
        public Inventory()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // JobHistory
    public partial class JobHistory : Entity
    {
        public string JobId { get; set; } // JobID
        public DateTime UtcDateTime { get; set; } // UtcDateTime
        public int JobHistoryId { get; set; } // JobHistoryID (Primary key)
        
        public JobHistory()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Label
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Label : Entity
    {
        public int LabelId { get; set; } // LabelId (Primary key)
        public string LabelName { get; set; } // LabelName
        public int BuyerAccountId { get; set; } // BuyerAccountId

        // Reverse navigation
        public virtual ICollection<EntityLabel> EntityLabels { get; set; } // Many to many mapping

        // Foreign keys
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_Label_BuyerAccount
        
        public Label()
        {
            EntityLabels = new List<EntityLabel>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Language
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Language : Entity
    {
        public int LanguageId { get; set; } // LanguageID (Primary key)
        public string Iso4646Code { get; set; } // ISO4646Code
        public string LanguageName { get; set; } // LanguageName
        public int? Position { get; set; } // Position
        public bool IsLangTarget { get; set; } // IsLangTarget
        public bool IsActive { get; set; } // IsActive
        public string LocalizedLanguageName { get; set; } // LocalizedLanguageName

        // Reverse navigation
        public virtual ICollection<AdGroupLanguage> AdGroupLanguages { get; set; } // Many to many mapping
        public virtual ICollection<BuyerAccount> BuyerAccounts { get; set; } // BuyerAccount.FK_BuyerAccount_Language
        public virtual ICollection<BuyerAccountApplicationLanguage> BuyerAccountApplicationLanguages { get; set; } // Many to many mapping
        public virtual ICollection<Creative> Creatives { get; set; } // Creative.FK_Creative_LanguageID
        public virtual ICollection<User> Users { get; set; } // User.FK_User_Language
        
        public Language()
        {
            IsLangTarget = false;
            IsActive = false;
            AdGroupLanguages = new List<AdGroupLanguage>();
            BuyerAccounts = new List<BuyerAccount>();
            BuyerAccountApplicationLanguages = new List<BuyerAccountApplicationLanguage>();
            Creatives = new List<Creative>();
            Users = new List<User>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // LanguageMapping
    public partial class LanguageMapping : Entity
    {
        public string Iso4646Code { get; set; } // ISO4646Code
        public string MappedIso4646Code { get; set; } // MappedISO4646Code
        public int LanguageMappingId { get; set; } // LanguageMappingID (Primary key)
        
        public LanguageMapping()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // LocalizedGeoCity
    public partial class LocalizedGeoCity : Entity
    {
        public int GeoCityId { get; set; } // GeoCityID (Primary key)
        public int LanguageId { get; set; } // LanguageID (Primary key)
        public string LocalizedName { get; set; } // LocalizedName
        
        public LocalizedGeoCity()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // LocalizedGeoCountry
    public partial class LocalizedGeoCountry : Entity
    {
        public int GeoCountryId { get; set; } // GeoCountryID (Primary key)
        public int LanguageId { get; set; } // LanguageID (Primary key)
        public string LocalizedName { get; set; } // LocalizedName
        
        public LocalizedGeoCountry()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // LocalizedGeoRegion
    public partial class LocalizedGeoRegion : Entity
    {
        public int GeoRegionId { get; set; } // GeoRegionID (Primary key)
        public int LanguageId { get; set; } // LanguageID (Primary key)
        public string LocalizedName { get; set; } // LocalizedName
        
        public LocalizedGeoRegion()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // MediaType
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class MediaType : Entity
    {
        public int MediaTypeId { get; set; } // MediaTypeID (Primary key)
        public string MediaTypeName { get; set; } // MediaTypeName

        // Reverse navigation
        public virtual ICollection<AdGroup> AdGroups { get; set; } // AdGroup.FK_AdGroup_MediaType
        public virtual ICollection<AdTagTemplate> AdTagTemplates { get; set; } // AdTagTemplate.FK_AdTagTemplate_MediaType
        public virtual ICollection<Technology> Technologies { get; set; } // Technology.FK_Technology_MediaType
        
        public MediaType()
        {
            AdGroups = new List<AdGroup>();
            AdTagTemplates = new List<AdTagTemplate>();
            Technologies = new List<Technology>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // MindshareTemplateParameter
    public partial class MindshareTemplateParameter : Entity
    {
        public int CampaignId { get; set; } // CampaignID
        public int CreativeSizeId { get; set; } // CreativeSizeID
        public string CreativeParameterKey { get; set; } // CreativeParameterKey
        public string CreativeParameterValue { get; set; } // CreativeParameterValue
        public int MindshareTemplateParameterId { get; set; } // MindshareTemplateParameterID (Primary key)
        
        public MindshareTemplateParameter()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // MobileCarrier
    public partial class MobileCarrier : Entity
    {
        public int GeoCountryId { get; set; } // GeoCountryID (Primary key)
        public int Mcc { get; set; } // MCC (Primary key)
        public int Mnc { get; set; } // MNC (Primary key)
        public string MobileCarrierName { get; set; } // MobileCarrierName
        
        public MobileCarrier()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // MonthlyCredit
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class MonthlyCredit : Entity
    {
        public int MonthlyCreditId { get; set; } // MonthlyCreditID (Primary key)
        public string MonthlyCreditName { get; set; } // MonthlyCreditName

        // Reverse navigation
        public virtual ICollection<BuyerAccount> BuyerAccounts { get; set; } // BuyerAccount.FK_BuyerAccount_MonthlyCredit
        public virtual MonthlyCredit MonthlyCredit2 { get; set; } // MonthlyCredit.FK_MonthlyCredit_MonthlyCredit

        // Foreign keys
        public virtual MonthlyCredit MonthlyCredit1 { get; set; } // FK_MonthlyCredit_MonthlyCredit
        
        public MonthlyCredit()
        {
            BuyerAccounts = new List<BuyerAccount>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // NewDayPartMappings
    public partial class NewDayPartMapping : Entity
    {
        public int OldDayPartId { get; set; } // OldDayPartID (Primary key)
        public int NewDayPartId { get; set; } // NewDayPartID (Primary key)
        
        public NewDayPartMapping()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // OptimizationModel
    public partial class OptimizationModel : Entity
    {
        public int OptimizationModelId { get; set; } // OptimizationModelID (Primary key)
        public string OptimizationModelName { get; set; } // OptimizationModelName
        
        public OptimizationModel()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Order
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Order : Entity
    {
        public int OrderId { get; set; } // OrderID (Primary key)
        public int BillingPeriodId { get; set; } // BillingPeriodID
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public string ContactName { get; set; } // ContactName
        public string ContactEmailAddress { get; set; } // ContactEmailAddress
        public string PoAddressLine1 { get; set; } // POAddressLine1
        public string PoAddressLine2 { get; set; } // POAddressLine2
        public string PoAddressLine3 { get; set; } // POAddressLine3
        public string PoAddressLine4 { get; set; } // POAddressLine4
        public string PoCity { get; set; } // POCity
        public string PoRegion { get; set; } // PORegion
        public string PoPostalCode { get; set; } // POPostalCode
        public string PoCountry { get; set; } // POCountry
        public string InvoiceNumber { get; set; } // InvoiceNumber
        public string OrderReference { get; set; } // OrderReference
        public DateTime InvoiceDate { get; set; } // InvoiceDate
        public DateTime DueDate { get; set; } // DueDate

        // Reverse navigation
        public virtual ICollection<OrderLine> OrderLines { get; set; } // OrderLine.FK_OrderLine_Order

        // Foreign keys
        public virtual BillingPeriod BillingPeriod { get; set; } // FK_Order_BillingPeriod
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_Order_BuyerAccount
        
        public Order()
        {
            OrderLines = new List<OrderLine>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // OrderLine
    public partial class OrderLine : Entity
    {
        public int OrderLineId { get; set; } // OrderLineID (Primary key)
        public int OrderId { get; set; } // OrderID
        public int? CampaignId { get; set; } // CampaignID
        public int? SegmentId { get; set; } // SegmentID
        public string OrderLineReference { get; set; } // OrderLineReference
        public string OrderLineDescription { get; set; } // OrderLineDescription
        public decimal SubTotal { get; set; } // SubTotal
        public decimal BrokerageAmount { get; set; } // BrokerageAmount

        // Foreign keys
        public virtual Campaign Campaign { get; set; } // FK_OrderLine_Campaign
        public virtual Order Order { get; set; } // FK_OrderLine_Order
        public virtual Segment Segment { get; set; } // FK_OrderLine_Segment
        
        public OrderLine()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // PacingStyle
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class PacingStyle : Entity
    {
        public int PacingStyleId { get; set; } // PacingStyleID (Primary key)
        public string PacingStyleName { get; set; } // PacingStyleName

        // Reverse navigation
        public virtual ICollection<AdGroup> AdGroups { get; set; } // AdGroup.FK_AdGroup_PacingStyle
        
        public PacingStyle()
        {
            AdGroups = new List<AdGroup>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // PagePosition
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class PagePosition : Entity
    {
        public int PagePositionId { get; set; } // PagePositionID (Primary key)
        public string PagePositionName { get; set; } // PagePositionName

        // Reverse navigation
        public virtual ICollection<AdGroupPagePosition> AdGroupPagePositions { get; set; } // Many to many mapping
        public virtual ICollection<AdSlot> AdSlots { get; set; } // AdSlot.FK_AdSlot_PagePosition
        
        public PagePosition()
        {
            AdGroupPagePositions = new List<AdGroupPagePosition>();
            AdSlots = new List<AdSlot>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Partner
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Partner : Entity
    {
        public int PartnerId { get; set; } // PartnerID (Primary key)
        public string PartnerName { get; set; } // PartnerName
        public bool IsExchangeTarget { get; set; } // IsExchangeTarget
        public int? TimeZoneId { get; set; } // TimeZoneID
        public int PrivateDealMode { get; set; } // PrivateDealMode
        public int? MediaTypeId { get; set; } // MediaTypeID

        // Reverse navigation
        public virtual ExchangeConfiguration ExchangeConfiguration { get; set; } // ExchangeConfiguration.FK_ExchangeConfiguration_Partner
        public virtual ICollection<AdvertiserReview> AdvertiserReviews { get; set; } // Many to many mapping
        public virtual ICollection<BuyerAccountApplicationPartner> BuyerAccountApplicationPartners { get; set; } // Many to many mapping
        public virtual ICollection<CreativeReview> CreativeReviews { get; set; } // Many to many mapping
        public virtual ICollection<DoohPanelLocation> DoohPanelLocations { get; set; } // DoohPanelLocation.FK_DoohPanelLocation_Partner
        public virtual ICollection<Publisher> Publishers { get; set; } // Publisher.FK_Publisher_Partner
        public virtual ICollection<ThirdPartyDataSet> ThirdPartyDataSets { get; set; } // ThirdPartyDataSet.FK_PartnerDataSet_Partner
        public virtual ICollection<ThirdPartyTaxonomy> ThirdPartyTaxonomies { get; set; } // ThirdPartyTaxonomy.FK_ThirdPartyTaxonomy_Partner
        
        public Partner()
        {
            IsExchangeTarget = false;
            PrivateDealMode = 0;
            AdvertiserReviews = new List<AdvertiserReview>();
            BuyerAccountApplicationPartners = new List<BuyerAccountApplicationPartner>();
            CreativeReviews = new List<CreativeReview>();
            DoohPanelLocations = new List<DoohPanelLocation>();
            Publishers = new List<Publisher>();
            ThirdPartyDataSets = new List<ThirdPartyDataSet>();
            ThirdPartyTaxonomies = new List<ThirdPartyTaxonomy>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // PartnerDefaultBuyer
    public partial class PartnerDefaultBuyer : Entity
    {
        public int PartnerId { get; set; } // PartnerID
        public string BuyerId { get; set; } // BuyerID
        public int PartnerDefaultBuyerId { get; set; } // PartnerDefaultBuyerID (Primary key)
        
        public PartnerDefaultBuyer()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // PaymentTerms
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class PaymentTerm : Entity
    {
        public int PaymentTermsId { get; set; } // PaymentTermsID (Primary key)
        public string PaymentTermsName { get; set; } // PaymentTermsName
        public int PeriodInDays { get; set; } // PeriodInDays

        // Reverse navigation
        public virtual ICollection<BuyerAccount> BuyerAccounts { get; set; } // BuyerAccount.FK_BuyerAccount_PaymentTerms
        
        public PaymentTerm()
        {
            BuyerAccounts = new List<BuyerAccount>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // PixelTagServer
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class PixelTagServer : Entity
    {
        public int PixelTagServerId { get; set; } // PixelTagServerID (Primary key)
        public string PixelTagServerName { get; set; } // PixelTagServerName
        public int? Position { get; set; } // Position
        public bool IsActive { get; set; } // IsActive

        // Reverse navigation
        public virtual ICollection<Advertiser> Advertisers { get; set; } // Advertiser.FK_Advertiser_PixelTagServer
        public virtual ICollection<BuyerAccountApplicationPixelTagServer> BuyerAccountApplicationPixelTagServers { get; set; } // Many to many mapping
        public virtual ICollection<PixelTagTemplate> PixelTagTemplates { get; set; } // PixelTagTemplate.FK_PixelTagTemplate_PixelTagServer
        
        public PixelTagServer()
        {
            IsActive = false;
            Advertisers = new List<Advertiser>();
            BuyerAccountApplicationPixelTagServers = new List<BuyerAccountApplicationPixelTagServer>();
            PixelTagTemplates = new List<PixelTagTemplate>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // PixelTagTemplate
    public partial class PixelTagTemplate : Entity
    {
        public int PixelTagTemplateId { get; set; } // PixelTagTemplateID (Primary key)
        public string PixelTagTemplateName { get; set; } // PixelTagTemplateName
        public string AddPixelTag { get; set; } // AddPixelTag
        public string RemovePixelTag { get; set; } // RemovePixelTag
        public string ConvertPixelTag { get; set; } // ConvertPixelTag
        public string RemarketHelpText { get; set; } // RemarketHelpText
        public string ConvertHelpText { get; set; } // ConvertHelpText
        public int? Position { get; set; } // Position
        public bool IsActive { get; set; } // IsActive
        public int PixelTagServerId { get; set; } // PixelTagServerID

        // Foreign keys
        public virtual PixelTagServer PixelTagServer { get; set; } // FK_PixelTagTemplate_PixelTagServer
        
        public PixelTagTemplate()
        {
            IsActive = false;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Placement
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Placement : Entity
    {
        public int PlacementId { get; set; } // PlacementID (Primary key)
        public int AdGroupId { get; set; } // AdGroupID
        public int CreativeId { get; set; } // CreativeID
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public int PlacementStatusId { get; set; } // PlacementStatusID
        public bool IsDeleted { get; set; } // IsDeleted
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public Guid PlacementUuid { get; set; } // PlacementUuid
        public int? CloneFromPlacementId { get; set; } // CloneFromPlacementID

        // Reverse navigation
        public virtual ICollection<PlacementPerformance> PlacementPerformances { get; set; } // Many to many mapping

        // Foreign keys
        public virtual AdGroup AdGroup { get; set; } // FK_Placement_AdGroup
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_Placement_BuyerAccount
        public virtual CampaignStatus CampaignStatus { get; set; } // FK_Placement_Status
        public virtual Creative Creative { get; set; } // FK_Placement_Creative
        
        public Placement()
        {
            PlacementUuid = System.Guid.NewGuid();
            PlacementPerformances = new List<PlacementPerformance>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // PlacementPerformance
    public partial class PlacementPerformance : Entity
    {
        public int PlacementId { get; set; } // PlacementID (Primary key)
        public int IntervalId { get; set; } // IntervalID (Primary key)
        public int IntervalValue { get; set; } // IntervalValue (Primary key)
        public long Bids { get; set; } // Bids
        public long Impressions { get; set; } // Impressions
        public long Clicks { get; set; } // Clicks
        public long Conversions { get; set; } // Conversions
        public long PostViewConversions { get; set; } // PostViewConversions
        public long PostClickConversions { get; set; } // PostClickConversions
        public DateTime? LastActivityTimestamp { get; set; } // LastActivityTimestamp
        public double? Ctr { get; set; } // CTR
        public long MediaCostLocalMicros { get; set; } // MediaCostLocalMicros
        public long DataCostLocalMicros { get; set; } // DataCostLocalMicros
        public long? SpendLocalMicros { get; set; } // SpendLocalMicros
        public long MediaClientCostLocalMicros { get; set; } // MediaClientCostLocalMicros
        public long DataClientCostLocalMicros { get; set; } // DataClientCostLocalMicros
        public long? ClientCostLocalMicros { get; set; } // ClientCostLocalMicros
        public decimal? Cpm { get; set; } // CPM
        public decimal? Cpc { get; set; } // CPC
        public decimal? Cpa { get; set; } // CPA
        public decimal? ClientCostCpm { get; set; } // ClientCostCPM
        public decimal? ClientCostCpc { get; set; } // ClientCostCPC
        public decimal? ClientCostCpa { get; set; } // ClientCostCPA
        public decimal? Spend { get; set; } // Spend
        public decimal? Cvr { get; set; } // Cvr
        public decimal? BidWin { get; set; } // BidWin
        public long FeesLocalSuperMicros { get; set; } // FeesLocalSuperMicros
        public long AdSlotDurationInSeconds { get; set; } // AdSlotDurationInSeconds
        public long RawViews { get; set; } // RawViews
        public long IabViews { get; set; } // IabViews
        public long ViewDurationInSeconds { get; set; } // ViewDurationInSeconds
        public decimal? CpMs { get; set; } // CPMs
        public decimal? ClientCostCpMs { get; set; } // ClientCostCPMs
        public decimal? Cps { get; set; } // CPS
        public decimal? ClientCostCps { get; set; } // ClientCostCPS
        public decimal? ViewableRatio { get; set; } // ViewableRatio

        // Foreign keys
        public virtual Interval Interval { get; set; } // FK_PlacementPerformance_Interval
        public virtual Placement Placement { get; set; } // FK_PlacementPerformance_Placement
        
        public PlacementPerformance()
        {
            MediaCostLocalMicros = 0;
            DataCostLocalMicros = 0;
            MediaClientCostLocalMicros = 0;
            DataClientCostLocalMicros = 0;
            AdSlotDurationInSeconds = 0;
            RawViews = 0;
            IabViews = 0;
            ViewDurationInSeconds = 0;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // PrivateMarket
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class PrivateMarket : Entity
    {
        public int PrivateMarketId { get; set; } // PrivateMarketID (Primary key)
        public Guid PrivateMarketUuid { get; set; } // PrivateMarketUuid
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public int PublisherId { get; set; } // PublisherID
        public int BuyerMarketStatusId { get; set; } // BuyerMarketStatusID
        public int PublisherMarketStatusId { get; set; } // PublisherMarketStatusID
        public bool IsDeleted { get; set; } // IsDeleted
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public int? PrivateMarketStatusId { get; set; } // PrivateMarketStatusID

        // Reverse navigation
        public virtual ICollection<PrivateMarketPerformance> PrivateMarketPerformances { get; set; } // Many to many mapping
        public virtual ICollection<PrivateMarketSite> PrivateMarketSites { get; set; } // PrivateMarketSite.FK_PrivateMarketSite_PrivateMarket

        // Foreign keys
        public virtual PrivateMarketStatu PrivateMarketStatu_BuyerMarketStatusId { get; set; } // FK_PrivateMarket_BuyerMarketStatus
        public virtual PrivateMarketStatu PrivateMarketStatu_PublisherMarketStatusId { get; set; } // FK_PrivateMarket_PublisherMarketStatus
        public virtual Publisher Publisher { get; set; } // FK_PrivateMarket_Publisher
        
        public PrivateMarket()
        {
            IsDeleted = false;
            UtcCreatedDateTime = System.DateTime.Now;
            UtcModifiedDateTime = System.DateTime.Now;
            PrivateMarketPerformances = new List<PrivateMarketPerformance>();
            PrivateMarketSites = new List<PrivateMarketSite>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // PrivateMarketMode
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class PrivateMarketMode : Entity
    {
        public int PrivateMarketModeId { get; set; } // PrivateMarketModeID (Primary key)
        public string PrivateMarketModeName { get; set; } // PrivateMarketModeName

        // Reverse navigation
        public virtual ICollection<Publisher> Publishers { get; set; } // Publisher.FK_Publisher_PrivateMarketMode
        
        public PrivateMarketMode()
        {
            Publishers = new List<Publisher>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // PrivateMarketPerformance
    public partial class PrivateMarketPerformance : Entity
    {
        public int PrivateMarketId { get; set; } // PrivateMarketID (Primary key)
        public int IntervalId { get; set; } // IntervalID (Primary key)
        public int IntervalValue { get; set; } // IntervalValue (Primary key)
        public long Bids { get; set; } // Bids
        public long Impressions { get; set; } // Impressions
        public long Clicks { get; set; } // Clicks
        public long Conversions { get; set; } // Conversions
        public long PostViewConversions { get; set; } // PostViewConversions
        public long PostClickConversions { get; set; } // PostClickConversions
        public DateTime? LastActivityTimestamp { get; set; } // LastActivityTimestamp
        public double? Ctr { get; set; } // CTR
        public long MediaCostLocalMicros { get; set; } // MediaCostLocalMicros
        public long DataCostLocalMicros { get; set; } // DataCostLocalMicros
        public long? SpendLocalMicros { get; set; } // SpendLocalMicros
        public long MediaClientCostLocalMicros { get; set; } // MediaClientCostLocalMicros
        public long DataClientCostLocalMicros { get; set; } // DataClientCostLocalMicros
        public long? ClientCostLocalMicros { get; set; } // ClientCostLocalMicros
        public decimal? Cpm { get; set; } // CPM
        public decimal? Cpc { get; set; } // CPC
        public decimal? Cpa { get; set; } // CPA
        public decimal? ClientCostCpm { get; set; } // ClientCostCPM
        public decimal? ClientCostCpc { get; set; } // ClientCostCPC
        public decimal? ClientCostCpa { get; set; } // ClientCostCPA
        public decimal? Cvr { get; set; } // Cvr
        public decimal? BidWin { get; set; } // BidWin
        public int? SiteCount { get; set; } // SiteCount
        public long AdSlotDurationInSeconds { get; set; } // AdSlotDurationInSeconds
        public long RawViews { get; set; } // RawViews
        public long IabViews { get; set; } // IabViews
        public long ViewDurationInSeconds { get; set; } // ViewDurationInSeconds
        public decimal? CpMs { get; set; } // CPMs
        public decimal? ClientCostCpMs { get; set; } // ClientCostCPMs
        public decimal? Cps { get; set; } // CPS
        public decimal? ClientCostCps { get; set; } // ClientCostCPS
        public decimal? ViewableRatio { get; set; } // ViewableRatio

        // Foreign keys
        public virtual Interval Interval { get; set; } // FK_PrivateMarketPerformance_Interval
        public virtual PrivateMarket PrivateMarket { get; set; } // FK_PrivateMarketPerformance_PrivateMarket
        
        public PrivateMarketPerformance()
        {
            MediaCostLocalMicros = 0;
            DataCostLocalMicros = 0;
            MediaClientCostLocalMicros = 0;
            DataClientCostLocalMicros = 0;
            AdSlotDurationInSeconds = 0;
            RawViews = 0;
            IabViews = 0;
            ViewDurationInSeconds = 0;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // PrivateMarketSite
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class PrivateMarketSite : Entity
    {
        public int PrivateMarketSiteId { get; set; } // PrivateMarketSiteID (Primary key)
        public Guid PrivateMarketSiteUuid { get; set; } // PrivateMarketSiteUuid
        public int PrivateMarketId { get; set; } // PrivateMarketID
        public long InventoryId { get; set; } // InventoryID
        public decimal? PriceFloor { get; set; } // PriceFloor
        public int PrivateMarketSiteStatusId { get; set; } // PrivateMarketSiteStatusID

        // Reverse navigation
        public virtual ICollection<PrivateMarketSitePerformance> PrivateMarketSitePerformances { get; set; } // Many to many mapping

        // Foreign keys
        public virtual PrivateMarket PrivateMarket { get; set; } // FK_PrivateMarketSite_PrivateMarket
        public virtual PrivateMarketSiteStatu PrivateMarketSiteStatu { get; set; } // FK_PrivateMarketSite_PrivateMarketSiteStatus
        
        public PrivateMarketSite()
        {
            PrivateMarketSitePerformances = new List<PrivateMarketSitePerformance>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // PrivateMarketSitePerformance
    public partial class PrivateMarketSitePerformance : Entity
    {
        public int PrivateMarketSiteId { get; set; } // PrivateMarketSiteID (Primary key)
        public int IntervalId { get; set; } // IntervalID (Primary key)
        public int IntervalValue { get; set; } // IntervalValue (Primary key)
        public long Bids { get; set; } // Bids
        public long Impressions { get; set; } // Impressions
        public long Clicks { get; set; } // Clicks
        public long Conversions { get; set; } // Conversions
        public long PostViewConversions { get; set; } // PostViewConversions
        public long PostClickConversions { get; set; } // PostClickConversions
        public DateTime? LastActivityTimestamp { get; set; } // LastActivityTimestamp
        public double? Ctr { get; set; } // CTR
        public long MediaCostLocalMicros { get; set; } // MediaCostLocalMicros
        public long DataCostLocalMicros { get; set; } // DataCostLocalMicros
        public long? SpendLocalMicros { get; set; } // SpendLocalMicros
        public long MediaClientCostLocalMicros { get; set; } // MediaClientCostLocalMicros
        public long DataClientCostLocalMicros { get; set; } // DataClientCostLocalMicros
        public long? ClientCostLocalMicros { get; set; } // ClientCostLocalMicros
        public decimal? Cpm { get; set; } // CPM
        public decimal? Cpc { get; set; } // CPC
        public decimal? Cpa { get; set; } // CPA
        public decimal? ClientCostCpm { get; set; } // ClientCostCPM
        public decimal? ClientCostCpc { get; set; } // ClientCostCPC
        public decimal? ClientCostCpa { get; set; } // ClientCostCPA
        public decimal? Cvr { get; set; } // Cvr
        public decimal? BidWin { get; set; } // BidWin
        public long AdSlotDurationInSeconds { get; set; } // AdSlotDurationInSeconds
        public long RawViews { get; set; } // RawViews
        public long IabViews { get; set; } // IabViews
        public long ViewDurationInSeconds { get; set; } // ViewDurationInSeconds
        public decimal? CpMs { get; set; } // CPMs
        public decimal? ClientCostCpMs { get; set; } // ClientCostCPMs
        public decimal? Cps { get; set; } // CPS
        public decimal? ClientCostCps { get; set; } // ClientCostCPS
        public decimal? ViewableRatio { get; set; } // ViewableRatio

        // Foreign keys
        public virtual Interval Interval { get; set; } // FK_PrivateMarketSitePerformance_Interval
        public virtual PrivateMarketSite PrivateMarketSite { get; set; } // FK_PrivateMarketSitePerformance_PrivateMarket
        
        public PrivateMarketSitePerformance()
        {
            MediaCostLocalMicros = 0;
            DataCostLocalMicros = 0;
            MediaClientCostLocalMicros = 0;
            DataClientCostLocalMicros = 0;
            AdSlotDurationInSeconds = 0;
            RawViews = 0;
            IabViews = 0;
            ViewDurationInSeconds = 0;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // PrivateMarketSiteStatus
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class PrivateMarketSiteStatu : Entity
    {
        public int PrivateMarketSiteStatusId { get; set; } // PrivateMarketSiteStatusID (Primary key)
        public string PrivateMarketSiteStatusName { get; set; } // PrivateMarketSiteStatusName

        // Reverse navigation
        public virtual ICollection<PrivateMarketSite> PrivateMarketSites { get; set; } // PrivateMarketSite.FK_PrivateMarketSite_PrivateMarketSiteStatus
        
        public PrivateMarketSiteStatu()
        {
            PrivateMarketSites = new List<PrivateMarketSite>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // PrivateMarketStatus
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class PrivateMarketStatu : Entity
    {
        public int PrivateMarketStatusId { get; set; } // PrivateMarketStatusID (Primary key)
        public string PrivateMarketStatusName { get; set; } // PrivateMarketStatusName

        // Reverse navigation
        public virtual ICollection<PrivateMarket> PrivateMarkets_BuyerMarketStatusId { get; set; } // PrivateMarket.FK_PrivateMarket_BuyerMarketStatus
        public virtual ICollection<PrivateMarket> PrivateMarkets_PublisherMarketStatusId { get; set; } // PrivateMarket.FK_PrivateMarket_PublisherMarketStatus
        
        public PrivateMarketStatu()
        {
            PrivateMarkets_BuyerMarketStatusId = new List<PrivateMarket>();
            PrivateMarkets_PublisherMarketStatusId = new List<PrivateMarket>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ProductCategory
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class ProductCategory : Entity
    {
        public int ProductCategoryId { get; set; } // ProductCategoryID (Primary key)
        public int IndustryCategoryId { get; set; } // IndustryCategoryID
        public string ProductCategoryName { get; set; } // ProductCategoryName
        public bool IsActive { get; set; } // IsActive

        // Reverse navigation
        public virtual ICollection<AdvertiserProduct> AdvertiserProducts { get; set; } // AdvertiserProduct.FK_AdvertiserProduct_ProductCategory

        // Foreign keys
        public virtual IndustryCategory IndustryCategory { get; set; } // FK_ProductCategory_IndustryCategory
        
        public ProductCategory()
        {
            IsActive = false;
            AdvertiserProducts = new List<AdvertiserProduct>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ProviderBrandSafetyType
    public partial class ProviderBrandSafetyType : Entity
    {
        public int ProviderId { get; set; } // ProviderID (Primary key)
        public int BrandSafetyTypeId { get; set; } // BrandSafetyTypeID (Primary key)
        
        public ProviderBrandSafetyType()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Publisher
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Publisher : Entity
    {
        public int PublisherId { get; set; } // PublisherID (Primary key)
        public Guid PublisherUuid { get; set; } // PublisherUuid
        public string PublisherName { get; set; } // PublisherName
        public int PartnerId { get; set; } // PartnerID
        public string PartnerKey { get; set; } // PartnerKey
        public int PrivateMarketModeId { get; set; } // PrivateMarketModeID
        public bool IsActive { get; set; } // IsActive

        // Reverse navigation
        public virtual ICollection<AdGroupPublisher> AdGroupPublishers { get; set; } // Many to many mapping
        public virtual ICollection<CustomPublisherList> CustomPublisherLists { get; set; } // Many to many mapping
        public virtual ICollection<Deal> Deals { get; set; } // Deal.FK_Deal_Publisher
        public virtual ICollection<PrivateMarket> PrivateMarkets { get; set; } // PrivateMarket.FK_PrivateMarket_Publisher

        // Foreign keys
        public virtual Partner Partner { get; set; } // FK_Publisher_Partner
        public virtual PrivateMarketMode PrivateMarketMode { get; set; } // FK_Publisher_PrivateMarketMode
        
        public Publisher()
        {
            IsActive = false;
            AdGroupPublishers = new List<AdGroupPublisher>();
            Deals = new List<Deal>();
            PrivateMarkets = new List<PrivateMarket>();
            CustomPublisherLists = new List<CustomPublisherList>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ReportAggregationLevel
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class ReportAggregationLevel : Entity
    {
        public int ReportAggregationLevelId { get; set; } // ReportAggregationLevelID (Primary key)
        public string ReportAggregationLeveName { get; set; } // ReportAggregationLeveName
        public int? Position { get; set; } // Position

        // Reverse navigation
        public virtual ICollection<ReportSchedule> ReportSchedules { get; set; } // ReportSchedule.FK_ReportSchedule_ReportAggregationLevel
        
        public ReportAggregationLevel()
        {
            ReportSchedules = new List<ReportSchedule>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ReportJob
    public partial class ReportJob : Entity
    {
        public int ReportJobId { get; set; } // ReportJobID (Primary key)
        public int ReportScheduleId { get; set; } // ReportScheduleID
        public DateTime UtcQueueDateTime { get; set; } // UtcQueueDateTime
        public DateTime? UtcStartDateTime { get; set; } // UtcStartDateTime
        public DateTime? UtcEndDateTime { get; set; } // UtcEndDateTime
        public DateTime LocalFromDateTime { get; set; } // LocalFromDateTime
        public DateTime LocalToDateTime { get; set; } // LocalToDateTime
        public string ErrorMessage { get; set; } // ErrorMessage

        // Foreign keys
        public virtual ReportSchedule ReportSchedule { get; set; } // FK_ReportJob_ReportSchedule
        
        public ReportJob()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ReportSchedule
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class ReportSchedule : Entity
    {
        public int ReportScheduleId { get; set; } // ReportScheduleID (Primary key)
        public Guid ReportScheduleUuid { get; set; } // ReportScheduleUuid
        public Guid UserId { get; set; } // UserID
        public int ReportPeriodId { get; set; } // ReportPeriodID
        public int? RecurrenceDays { get; set; } // RecurrenceDays
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public int? AdvertiserId { get; set; } // AdvertiserID
        public int? CampaignId { get; set; } // CampaignID
        public int ReportTypeId { get; set; } // ReportTypeID
        public int ReportAggregationLevelId { get; set; } // ReportAggregationLevelID
        public int CampaignPeriodId { get; set; } // CampaignPeriodID
        public DateTime? UtcStartDateTime { get; set; } // UtcStartDateTime
        public DateTime? UtcEndDateTime { get; set; } // UtcEndDateTime
        public DateTime? LastRunDateTime { get; set; } // LastRunDateTime
        public DateTime? NextRunDateTime { get; set; } // NextRunDateTime
        public int CampaignStatusId { get; set; } // CampaignStatusID
        public bool IsDeleted { get; set; } // IsDeleted
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public Guid? ModifiedUserId { get; set; } // ModifiedUserID
        public Guid? ModifiedActualUserId { get; set; } // ModifiedActualUserID
        public string ReportScheduleName { get; set; } // ReportScheduleName
        public string SendReportTo { get; set; } // SendReportTo
        public int? CostView { get; set; } // CostView
        public string RtbSegmentId { get; set; } // RtbSegmentID

        // Reverse navigation
        public virtual ICollection<ReportJob> ReportJobs { get; set; } // ReportJob.FK_ReportJob_ReportSchedule

        // Foreign keys
        public virtual Advertiser Advertiser { get; set; } // FK_ReportSchedule_Advertiser
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_ReportSchedule_BuyerAccount
        public virtual CampaignPeriod CampaignPeriod { get; set; } // FK_ReportSchedule_CampaignPeriod
        public virtual CampaignStatus CampaignStatus { get; set; } // FK_ReportSchedule_CampaignStatus
        public virtual ReportAggregationLevel ReportAggregationLevel { get; set; } // FK_ReportSchedule_ReportAggregationLevel
        public virtual ReportType ReportType { get; set; } // FK_ReportSchedule_ReportType
        public virtual User User_ModifiedActualUserId { get; set; } // FK_ReportSchedule_ActualUser
        public virtual User User_ModifiedUserId { get; set; } // FK_ReportSchedule_User
        
        public ReportSchedule()
        {
            CampaignStatusId = 4;
            IsDeleted = false;
            UtcCreatedDateTime = System.DateTime.Now;
            UtcModifiedDateTime = System.DateTime.Now;
            ReportScheduleName = "";
            ReportJobs = new List<ReportJob>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ReportType
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class ReportType : Entity
    {
        public int ReportTypeId { get; set; } // ReportTypeID (Primary key)
        public string ReportTypeName { get; set; } // ReportTypeName
        public int? Position { get; set; } // Position

        // Reverse navigation
        public virtual ICollection<ReportSchedule> ReportSchedules { get; set; } // ReportSchedule.FK_ReportSchedule_ReportType
        
        public ReportType()
        {
            ReportSchedules = new List<ReportSchedule>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // RetryLog
    public partial class RetryLog : Entity
    {
        public long RetryLogId { get; set; } // RetryLogId (Primary key)
        public string Message { get; set; } // Message
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public int Attempt { get; set; } // Attempt
        
        public RetryLog()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SalesRegion
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class SalesRegion : Entity
    {
        public int SalesRegionId { get; set; } // SalesRegionID (Primary key)
        public string SalesRegionName { get; set; } // SalesRegionName

        // Reverse navigation
        public virtual ICollection<GeoCountry> GeoCountries { get; set; } // Many to many mapping
        
        public SalesRegion()
        {
            GeoCountries = new List<GeoCountry>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SchemaMigration
    public partial class SchemaMigration : Entity
    {
        public int SchemaVersion { get; set; } // SchemaVersion (Primary key)
        public DateTime? DateApplied { get; set; } // DateApplied
        
        public SchemaMigration()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Segment
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Segment : Entity
    {
        public int SegmentId { get; set; } // SegmentID (Primary key)
        public string RtbSegmentId { get; set; } // RtbSegmentID
        public int? BuyerAccountId { get; set; } // BuyerAccountID
        public int? AdvertiserId { get; set; } // AdvertiserID
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

        // Reverse navigation
        public virtual ICollection<AdGroup> AdGroups { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupSegment> AdGroupSegments { get; set; } // Many to many mapping
        public virtual ICollection<OrderLine> OrderLines { get; set; } // OrderLine.FK_OrderLine_Segment
        public virtual ICollection<SegmentPerformance> SegmentPerformances { get; set; } // Many to many mapping
        public virtual ICollection<SegmentReport> SegmentReports { get; set; } // Many to many mapping
        public virtual ICollection<SegmentThirdPartyTargeting> SegmentThirdPartyTargetings { get; set; } // SegmentThirdPartyTargeting.FK_SegmentThirdPartyTargeting_ThirdPartyTaxonomyID
        public virtual ICollection<ThirdPartyTaxonomy> ThirdPartyTaxonomies { get; set; } // Many to many mapping

        // Foreign keys
        public virtual Advertiser Advertiser { get; set; } // FK_Segment_Advertiser
        public virtual AttributionCountingMode AttributionCountingMode { get; set; } // FK_Segment_AttributionCountingMode
        public virtual AttributionModel AttributionModel { get; set; } // FK_Segment_AttributionModel
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_Segment_BuyerAccount
        public virtual CampaignPeriod CampaignPeriod { get; set; } // FK_Segment_ThirdPartyPeriodID
        public virtual CampaignStatus CampaignStatus { get; set; } // FK_Segment_CampaignStatus
        public virtual Country Country { get; set; } // FK_Segment_TargetGeographyCountryId
        public virtual SegmentType SegmentType { get; set; } // FK_Segment_SegmentType
        public virtual ThirdPartyDataSet ThirdPartyDataSet { get; set; } // FK_Segment_ThirdPartyDataSet
        
        public Segment()
        {
            IsDeleted = false;
            UtcCreatedDateTime = System.DateTime.Now;
            UtcModifiedDateTime = System.DateTime.Now;
            TargetGeographyCountryId = 14;
            Priority = 0;
            AdGroupSegments = new List<AdGroupSegment>();
            OrderLines = new List<OrderLine>();
            SegmentPerformances = new List<SegmentPerformance>();
            SegmentReports = new List<SegmentReport>();
            SegmentThirdPartyTargetings = new List<SegmentThirdPartyTargeting>();
            ThirdPartyTaxonomies = new List<ThirdPartyTaxonomy>();
            AdGroups = new List<AdGroup>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SegmentPerformance
    public partial class SegmentPerformance : Entity
    {
        public int SegmentId { get; set; } // SegmentID (Primary key)
        public int IntervalId { get; set; } // IntervalID (Primary key)
        public int IntervalValue { get; set; } // IntervalValue (Primary key)
        public int Uniques { get; set; } // Uniques
        public int MemberCount { get; set; } // MemberCount

        // Foreign keys
        public virtual Interval Interval { get; set; } // FK_SegmentPerformance_Interval
        public virtual Segment Segment { get; set; } // FK_SegmentPerformance_Segment_SegmentID
        
        public SegmentPerformance()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SegmentReport
    public partial class SegmentReport : Entity
    {
        public int SegmentId { get; set; } // SegmentID (Primary key)
        public DateTime Period { get; set; } // Period (Primary key)
        public int Uniques { get; set; } // Uniques
        public decimal UsdSpend { get; set; } // UsdSpend
        public decimal LocalSpend { get; set; } // LocalSpend
        public decimal LocalBrokerage { get; set; } // LocalBrokerage
        public bool IsBilled { get; set; } // IsBilled

        // Foreign keys
        public virtual Segment Segment { get; set; } // FK_SegmentReport_Segment
        
        public SegmentReport()
        {
            UsdSpend = 0m;
            LocalBrokerage = 0m;
            IsBilled = false;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SegmentThirdPartyTargeting
    public partial class SegmentThirdPartyTargeting : Entity
    {
        public int SegmentThirdPartyTargetingId { get; set; } // SegmentThirdPartyTargetingID (Primary key)
        public int SegmentId { get; set; } // SegmentID
        public int ThirdPartyTaxonomyId { get; set; } // ThirdPartyTaxonomyID

        // Foreign keys
        public virtual Segment Segment { get; set; } // FK_SegmentThirdPartyTargeting_ThirdPartyTaxonomyID
        
        public SegmentThirdPartyTargeting()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SegmentType
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class SegmentType : Entity
    {
        public int SegmentTypeId { get; set; } // SegmentTypeID (Primary key)
        public string SegmentTypeName { get; set; } // SegmentTypeName

        // Reverse navigation
        public virtual ICollection<Segment> Segments { get; set; } // Segment.FK_Segment_SegmentType
        
        public SegmentType()
        {
            Segments = new List<Segment>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SensitiveCategory
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class SensitiveCategory : Entity
    {
        public int SensitiveCategoryId { get; set; } // SensitiveCategoryId (Primary key)
        public string SensitiveCategoryName { get; set; } // SensitiveCategoryName

        // Reverse navigation
        public virtual ICollection<Creative> Creatives { get; set; } // Many to many mapping
        
        public SensitiveCategory()
        {
            Creatives = new List<Creative>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SharingSegments
    public partial class SharingSegment : Entity
    {
        public int SharingSegmentId { get; set; } // SharingSegmentID (Primary key)
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)

        // Foreign keys
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_SharingSegments_BuyerAccount
        
        public SharingSegment()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SiteLevelOptimisationOverride
    public partial class SiteLevelOptimisationOverride : Entity
    {
        public long WebsiteId { get; set; } // WebsiteID (Primary key)
        public string WebsiteUrl { get; set; } // WebsiteUrl
        
        public SiteLevelOptimisationOverride()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SiteListLookup
    public partial class SiteListLookup : Entity
    {
        public long WebsiteId { get; set; } // WebsiteID
        public int? SiteListId { get; set; } // SiteListID
        
        public SiteListLookup()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SiteListOption
    public partial class SiteListOption : Entity
    {
        public int SiteListOptionId { get; set; } // SiteListOptionID (Primary key)
        public string SiteListOptionName { get; set; } // SiteListOptionName
        
        public SiteListOption()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SiteMetaAndDetails
    public partial class SiteMetaAndDetail : Entity
    {
        public long WebsiteId { get; set; } // WebsiteId (Primary key)
        public string SiteMeta { get; set; } // SiteMeta
        public string SiteDetails { get; set; } // SiteDetails
        
        public SiteMetaAndDetail()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SupplySource
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class SupplySource : Entity
    {
        public int SupplySourceId { get; set; } // SupplySourceID (Primary key)
        public string SupplySourceName { get; set; } // SupplySourceName

        // Reverse navigation
        public virtual ICollection<AdGroup> AdGroups { get; set; } // AdGroup.FK_AdGroup_SupplySource
        
        public SupplySource()
        {
            AdGroups = new List<AdGroup>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SupportedMobileCarriersView
    public partial class SupportedMobileCarriersView : Entity
    {
        public int GeoCountryId { get; set; } // GeoCountryID
        public int Mcc { get; set; } // MCC
        public int Mnc { get; set; } // MNC
        public string MobileCarrierName { get; set; } // MobileCarrierName
        public string CountryName { get; set; } // CountryName
        
        public SupportedMobileCarriersView()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // sysdiagrams
    public partial class Sysdiagram : Entity
    {
        public string Name { get; set; } // name
        public int PrincipalId { get; set; } // principal_id
        public int DiagramId { get; set; } // diagram_id (Primary key)
        public int? Version { get; set; } // version
        public byte[] Definition { get; set; } // definition
        
        public Sysdiagram()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SystemBlackListWebsite
    public partial class SystemBlackListWebsite : Entity
    {
        public long WebsiteId { get; set; } // WebsiteID (Primary key)
        public string WebsiteUrl { get; set; } // WebsiteUrl
        
        public SystemBlackListWebsite()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SystemFeature
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class SystemFeature : Entity
    {
        public string SystemFeatureCode { get; set; } // SystemFeatureCode (Primary key)
        public string SystemFeatureName { get; set; } // SystemFeatureName

        // Reverse navigation
        public virtual ICollection<BuyerAccount> BuyerAccounts { get; set; } // Many to many mapping
        
        public SystemFeature()
        {
            BuyerAccounts = new List<BuyerAccount>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // SystemSpendLimits
    public partial class SystemSpendLimit : Entity
    {
        public int CurrentHour { get; set; } // CurrentHour (Primary key)
        public long MaxSpendLimitUsdMicros { get; set; } // MaxSpendLimitUsdMicros
        public long MinSpendLimitUsdMicros { get; set; } // MinSpendLimitUsdMicros
        
        public SystemSpendLimit()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // TargetingAction
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class TargetingAction : Entity
    {
        public int TargetingActionId { get; set; } // TargetingActionID (Primary key)
        public string TargetingActionName { get; set; } // TargetingActionName

        // Reverse navigation
        public virtual ICollection<AdGroupDayPart> AdGroupDayParts { get; set; } // AdGroupDayPart.FK_AdGroupDayPart_TargetingAction
        public virtual ICollection<AdGroupDeal> AdGroupDeals { get; set; } // AdGroupDeal.FK_AdGroupDeal_TargetingAction
        public virtual ICollection<AdGroupDevice> AdGroupDevices { get; set; } // AdGroupDevice.FK_AdGroupDevice_TargetingAction
        public virtual ICollection<AdGroupDomainList> AdGroupDomainLists { get; set; } // AdGroupDomainList.FK_AdGroupDomainList_TargetingAction
        public virtual ICollection<AdGroupDoohGeoLocationGroup> AdGroupDoohGeoLocationGroups { get; set; } // AdGroupDoohGeoLocationGroup.FK_AdGroupDoohGeoLocationGroup_TargetingAction
        public virtual ICollection<AdGroupDoohPanelLocation> AdGroupDoohPanelLocations { get; set; } // AdGroupDoohPanelLocation.FK_AdGroupDoohPanelLocation_TargetingAction
        public virtual ICollection<AdGroupGeoLocation> AdGroupGeoLocations { get; set; } // AdGroupGeoLocation.FK_AdGroupGeoLocation_TargetingAction
        public virtual ICollection<AdGroupLanguage> AdGroupLanguages { get; set; } // AdGroupLanguage.FK_AdGroupLanguage_TargetingAction
        public virtual ICollection<AdGroupPagePosition> AdGroupPagePositions { get; set; } // AdGroupPagePosition.FK_AdGroupPagePosition_TargetingAction
        public virtual ICollection<AdGroupPublisher> AdGroupPublishers { get; set; } // AdGroupPublisher.FK_AdGroupPublisher_TargetingAction
        public virtual ICollection<AdGroupSegment> AdGroupSegments { get; set; } // AdGroupSegment.FK_AdGroupSegment_TargetingAction
        public virtual ICollection<AdGroupVertical> AdGroupVerticals { get; set; } // AdGroupVertical.FK_AdGroupVertical_TargetingAction
        public virtual ICollection<AdGroupVerticalBeforeMigration> AdGroupVerticalBeforeMigrations { get; set; } // AdGroupVerticalBeforeMigration.FK_AdGroupVerticalBeforeMigration_TargetingAction
        public virtual ICollection<AdvertiserDomainList> AdvertiserDomainLists { get; set; } // AdvertiserDomainList.FK_AdvertiserDomainList_TargetingAction
        public virtual ICollection<AdvertiserProductDomainList> AdvertiserProductDomainLists { get; set; } // AdvertiserProductDomainList.FK_AdvertiserProductDomainList_TargetingAction
        public virtual ICollection<BuyerAccountDomainList> BuyerAccountDomainLists { get; set; } // BuyerAccountDomainList.FK_BuyerAccountDomainList_TargetingAction
        public virtual ICollection<CampaignDomainList> CampaignDomainLists { get; set; } // CampaignDomainList.FK_CampaignDomainList_TargetingAction
        
        public TargetingAction()
        {
            AdGroupDayParts = new List<AdGroupDayPart>();
            AdGroupDeals = new List<AdGroupDeal>();
            AdGroupDevices = new List<AdGroupDevice>();
            AdGroupDomainLists = new List<AdGroupDomainList>();
            AdGroupDoohGeoLocationGroups = new List<AdGroupDoohGeoLocationGroup>();
            AdGroupDoohPanelLocations = new List<AdGroupDoohPanelLocation>();
            AdGroupGeoLocations = new List<AdGroupGeoLocation>();
            AdGroupLanguages = new List<AdGroupLanguage>();
            AdGroupPagePositions = new List<AdGroupPagePosition>();
            AdGroupPublishers = new List<AdGroupPublisher>();
            AdGroupSegments = new List<AdGroupSegment>();
            AdGroupVerticals = new List<AdGroupVertical>();
            AdGroupVerticalBeforeMigrations = new List<AdGroupVerticalBeforeMigration>();
            AdvertiserDomainLists = new List<AdvertiserDomainList>();
            AdvertiserProductDomainLists = new List<AdvertiserProductDomainList>();
            BuyerAccountDomainLists = new List<BuyerAccountDomainList>();
            CampaignDomainLists = new List<CampaignDomainList>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // TargetingAttributeType
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class TargetingAttributeType : Entity
    {
        public int TargetingAttributeTypeId { get; set; } // TargetingAttributeTypeID (Primary key)
        public string TargetingAttributeTypeName { get; set; } // TargetingAttributeTypeName

        // Reverse navigation
        public virtual ICollection<AdGroupTargetingPerformance> AdGroupTargetingPerformances { get; set; } // Many to many mapping
        
        public TargetingAttributeType()
        {
            AdGroupTargetingPerformances = new List<AdGroupTargetingPerformance>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Technology
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Technology : Entity
    {
        public int TechnologyId { get; set; } // TechnologyID (Primary key)
        public string TechnologyName { get; set; } // TechnologyName
        public int? MediaTypeId { get; set; } // MediaTypeID

        // Reverse navigation
        public virtual ICollection<Creative> Creatives { get; set; } // Many to many mapping
        public virtual ICollection<CustomCreativeTechnology> CustomCreativeTechnologies { get; set; } // CustomCreativeTechnology.FK_CustomCreativeTechnology_Technology

        // Foreign keys
        public virtual MediaType MediaType { get; set; } // FK_Technology_MediaType
        
        public Technology()
        {
            CustomCreativeTechnologies = new List<CustomCreativeTechnology>();
            Creatives = new List<Creative>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Theme
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Theme : Entity
    {
        public long ThemeId { get; set; } // ThemeID (Primary key)
        public Guid ThemeUuid { get; set; } // ThemeUuid
        public string ThemeName { get; set; } // ThemeName
        public string Description { get; set; } // Description
        public string LogoImageUrl { get; set; } // LogoImageUrl
        public string ThemeCssUrl { get; set; } // ThemeCssUrl
        public string JavaScriptUrl { get; set; } // JavaScriptUrl
        public bool IsDeleted { get; set; } // IsDeleted
        public string PlatformName { get; set; } // PlatformName
        public string DefaultDomain { get; set; } // DefaultDomain
        public string ThemeCss { get; set; } // ThemeCss
        public string CustomJavascript { get; set; } // CustomJavascript
        public int? BuyerAccountId { get; set; } // BuyerAccountID

        // Reverse navigation
        public virtual ICollection<BuyerAccount> BuyerAccounts { get; set; } // BuyerAccount.FK_BuyerAccount_Theme

        // Foreign keys
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_Theme_BuyerAccount
        
        public Theme()
        {
            BuyerAccounts = new List<BuyerAccount>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ThirdPartyCampaigns
    public partial class ThirdPartyCampaign : Entity
    {
        public int ThirdPartyCampaignId { get; set; } // ThirdPartyCampaignId (Primary key)
        public string CampaignName { get; set; } // CampaignName
        public string InputFileName { get; set; } // InputFileName
        public bool IsPublic { get; set; } // IsPublic
        
        public ThirdPartyCampaign()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ThirdPartyCampaignBuyerAccounts
    public partial class ThirdPartyCampaignBuyerAccount : Entity
    {
        public int ThirdPartyCampaignThirdPartyCampaignId { get; set; } // ThirdPartyCampaign_ThirdPartyCampaignId (Primary key)
        public int BuyerAccountBuyerAccountId { get; set; } // BuyerAccount_BuyerAccountID (Primary key)
        
        public ThirdPartyCampaignBuyerAccount()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ThirdPartyDataSet
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class ThirdPartyDataSet : Entity
    {
        public int ThirdPartyDataSetId { get; set; } // ThirdPartyDataSetID (Primary key)
        public int PartnerId { get; set; } // PartnerID
        public string DataSetName { get; set; } // DataSetName

        // Reverse navigation
        public virtual ICollection<Segment> Segments { get; set; } // Segment.FK_Segment_ThirdPartyDataSet
        public virtual ICollection<ThirdPartyTaxonomyRateCard> ThirdPartyTaxonomyRateCards { get; set; } // Many to many mapping

        // Foreign keys
        public virtual Partner Partner { get; set; } // FK_PartnerDataSet_Partner
        
        public ThirdPartyDataSet()
        {
            Segments = new List<Segment>();
            ThirdPartyTaxonomyRateCards = new List<ThirdPartyTaxonomyRateCard>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ThirdPartyRatecardImport
    public partial class ThirdPartyRatecardImport : Entity
    {
        public string NodePath { get; set; } // NodePath
        public decimal? Cpm { get; set; } // Cpm
        public int ThirdPartyRatecardImportId { get; set; } // ThirdPartyRatecardImportID (Primary key)
        
        public ThirdPartyRatecardImport()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ThirdPartySegmentImport
    public partial class ThirdPartySegmentImport : Entity
    {
        public string RtbSegmentId { get; set; } // RtbSegmentId
        public int SegmentId { get; set; } // SegmentId
        public int? ParentId { get; set; } // ParentId
        public bool HasChildren { get; set; } // HasChildren
        public bool IsSelectable { get; set; } // IsSelectable
        public string SegmentName { get; set; } // SegmentName
        public string NodePath { get; set; } // NodePath
        public string SegmentDescription { get; set; } // SegmentDescription
        public int ThirdPartyCampaignId { get; set; } // ThirdPartyCampaignId
        public int ThirdPartySegmentImportId { get; set; } // ThirdPartySegmentImportID (Primary key)
        
        public ThirdPartySegmentImport()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ThirdPartyTaxonomy
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class ThirdPartyTaxonomy : Entity
    {
        public int ThirdPartyTaxonomyId { get; set; } // ThirdPartyTaxonomyID (Primary key)
        public int? ParentId { get; set; } // ParentID
        public int PartnerId { get; set; } // PartnerID
        public string PartnerRef { get; set; } // PartnerRef
        public string NodeName { get; set; } // NodeName
        public string NodePath { get; set; } // NodePath

        // Reverse navigation
        public virtual ICollection<Segment> Segments { get; set; } // Many to many mapping
        public virtual ICollection<ThirdPartyTaxonomyRateCard> ThirdPartyTaxonomyRateCards { get; set; } // Many to many mapping

        // Foreign keys
        public virtual Partner Partner { get; set; } // FK_ThirdPartyTaxonomy_Partner
        
        public ThirdPartyTaxonomy()
        {
            ThirdPartyTaxonomyRateCards = new List<ThirdPartyTaxonomyRateCard>();
            Segments = new List<Segment>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ThirdPartyTaxonomyRateCard
    public partial class ThirdPartyTaxonomyRateCard : Entity
    {
        public int ThirdPartyTaxonomyId { get; set; } // ThirdPartyTaxonomyID (Primary key)
        public int ThirdPartyDataSetId { get; set; } // ThirdPartyDataSetID (Primary key)
        public int Reach { get; set; } // Reach
        public decimal PriceFloor { get; set; } // PriceFloor
        public int ChildCount { get; set; } // ChildCount
        public int ChildReach { get; set; } // ChildReach

        // Foreign keys
        public virtual ThirdPartyDataSet ThirdPartyDataSet { get; set; } // FK_ThirdPartyTaxonomyRateCard_ThirdPartyDataSet
        public virtual ThirdPartyTaxonomy ThirdPartyTaxonomy { get; set; } // FK_ThirdPartyTaxonomyRateCard_ThirdPartyTaxonomy
        
        public ThirdPartyTaxonomyRateCard()
        {
            ChildCount = 0;
            ChildReach = 0;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // TimeSpan
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class TimeSpan : Entity
    {
        public int TimeSpanId { get; set; } // TimeSpanID (Primary key)
        public string Description { get; set; } // Description

        // Reverse navigation
        public virtual ICollection<AdGroupTargetingPerformance> AdGroupTargetingPerformances { get; set; } // AdGroupTargetingPerformance.FK_AdGroupTargetingPerformance_TimeSpan
        public virtual ICollection<User> Users { get; set; } // User.FK_User_TimeSpan
        
        public TimeSpan()
        {
            AdGroupTargetingPerformances = new List<AdGroupTargetingPerformance>();
            Users = new List<User>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // TimeZone
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class TimeZone : Entity
    {
        public int TimeZoneId { get; set; } // TimeZoneID (Primary key)
        public string TimeZoneName { get; set; } // TimeZoneName
        public string TimeZoneCode { get; set; } // TimeZoneCode
        public string GmtOffset { get; set; } // GmtOffset
        public int? DisplayIndex { get; set; } // DisplayIndex
        public int MinutesOffset { get; set; } // MinutesOffset
        public string OlsonName { get; set; } // OlsonName

        // Reverse navigation
        public virtual ICollection<BillingPeriod> BillingPeriods { get; set; } // BillingPeriod.FK_BillingPeriod_TimeZone
        public virtual ICollection<BuyerAccount> BuyerAccounts { get; set; } // BuyerAccount.FK_BuyerAccount_TimeZone
        public virtual ICollection<Country> Countries { get; set; } // Country.FK__Country__Default__54B68676
        
        public TimeZone()
        {
            GmtOffset = "0.00";
            MinutesOffset = 0;
            BillingPeriods = new List<BillingPeriod>();
            BuyerAccounts = new List<BuyerAccount>();
            Countries = new List<Country>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // User
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class User : Entity
    {
        public Guid UserId { get; set; } // UserID (Primary key)
        public string UserName { get; set; } // UserName
        public string FirstName { get; set; } // FirstName
        public string LastName { get; set; } // LastName
        public string Mobile { get; set; } // Mobile
        public string Email { get; set; } // Email
        public int? LanguageId { get; set; } // LanguageID
        public bool IsSystemAdministrator { get; set; } // IsSystemAdministrator
        public bool IsSuperAdministrator { get; set; } // IsSuperAdministrator
        public DateTime? TermsAndConditionsAgreedDate { get; set; } // TermsAndConditionsAgreedDate
        public int TimeSpanId { get; set; } // TimeSpanID
        public int Mentioned { get; set; } // Mentioned
        public string Position { get; set; } // Position

        // Reverse navigation
        public virtual ICollection<BuyerAccount> BuyerAccounts { get; set; } // BuyerAccount.FK_BuyerAccount_CommercialContactUser
        public virtual ICollection<Campaign> Campaigns { get; set; } // Many to many mapping
        public virtual ICollection<ChangeLogComment> ChangeLogComments { get; set; } // ChangeLogComment.FK_ChangeLogComment_User
        public virtual ICollection<Creative> Creatives { get; set; } // Many to many mapping
        public virtual ICollection<ReportSchedule> ReportSchedules_ModifiedActualUserId { get; set; } // ReportSchedule.FK_ReportSchedule_ActualUser
        public virtual ICollection<ReportSchedule> ReportSchedules_ModifiedUserId { get; set; } // ReportSchedule.FK_ReportSchedule_User
        public virtual ICollection<UserAdvertiserRole> UserAdvertiserRoles { get; set; } // Many to many mapping
        public virtual ICollection<UserBuyerRole> UserBuyerRoles { get; set; } // Many to many mapping
        public virtual ICollection<UserTag> UserTags { get; set; } // UserTag.FK_UserTag_User

        // Foreign keys
        public virtual Language Language { get; set; } // FK_User_Language
        public virtual TimeSpan TimeSpan { get; set; } // FK_User_TimeSpan
        
        public User()
        {
            IsSystemAdministrator = false;
            TimeSpanId = 9;
            BuyerAccounts = new List<BuyerAccount>();
            ChangeLogComments = new List<ChangeLogComment>();
            ReportSchedules_ModifiedActualUserId = new List<ReportSchedule>();
            ReportSchedules_ModifiedUserId = new List<ReportSchedule>();
            UserAdvertiserRoles = new List<UserAdvertiserRole>();
            UserBuyerRoles = new List<UserBuyerRole>();
            UserTags = new List<UserTag>();
            Campaigns = new List<Campaign>();
            Creatives = new List<Creative>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // UserAdvertiserRole
    public partial class UserAdvertiserRole : Entity
    {
        public Guid UserId { get; set; } // UserId (Primary key)
        public int AdvertiserId { get; set; } // AdvertiserID (Primary key)
        public string RoleName { get; set; } // RoleName

        // Foreign keys
        public virtual Advertiser Advertiser { get; set; } // FK_UserAdvertiserRole_Advertiser
        public virtual User User { get; set; } // FK_UserAdvertiserRole_User
        
        public UserAdvertiserRole()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // UserBuyerRole
    public partial class UserBuyerRole : Entity
    {
        public Guid UserId { get; set; } // UserId (Primary key)
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public string RoleName { get; set; } // RoleName
        public bool IsAccepted { get; set; } // IsAccepted
        public int CostView { get; set; } // CostView

        // Foreign keys
        public virtual BuyerAccount BuyerAccount { get; set; } // FK_UserBuyerRole_BuyerAccount
        public virtual User User { get; set; } // FK_UserBuyerRole_User
        
        public UserBuyerRole()
        {
            IsAccepted = false;
            CostView = 0;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // UserTag
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class UserTag : Entity
    {
        public int UserTagId { get; set; } // UserTagId (Primary key)
        public Guid UserId { get; set; } // UserId
        public string TagName { get; set; } // TagName

        // Reverse navigation
        public virtual ICollection<EntityUserTag> EntityUserTags { get; set; } // Many to many mapping

        // Foreign keys
        public virtual User User { get; set; } // FK_UserTag_User
        
        public UserTag()
        {
            EntityUserTags = new List<EntityUserTag>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Vertical
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Vertical : Entity
    {
        public int VerticalId { get; set; } // VerticalID (Primary key)
        public int? ParentVerticalId { get; set; } // ParentVerticalID
        public string VerticalName { get; set; } // VerticalName
        public string VerticalPath { get; set; } // VerticalPath
        public string IabReference { get; set; } // IABReference

        // Reverse navigation
        public virtual ICollection<AdGroupVertical> AdGroupVerticals { get; set; } // Many to many mapping
        public virtual ICollection<AdGroupVerticalBeforeMigration> AdGroupVerticalBeforeMigrations { get; set; } // Many to many mapping
        public virtual ICollection<Deal> Deals { get; set; } // Deal.FK_Deal_Vertical
        public virtual ICollection<Vertical> Verticals { get; set; } // Vertical.FK_Vertical_ParentVertical

        // Foreign keys
        public virtual Vertical Vertical_ParentVerticalId { get; set; } // FK_Vertical_ParentVertical
        
        public Vertical()
        {
            AdGroupVerticals = new List<AdGroupVertical>();
            AdGroupVerticalBeforeMigrations = new List<AdGroupVerticalBeforeMigration>();
            Deals = new List<Deal>();
            Verticals = new List<Vertical>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // VerticalMapping
    public partial class VerticalMapping : Entity
    {
        public int FromVerticalId { get; set; } // FromVerticalID (Primary key)
        public int ToVerticalId { get; set; } // ToVerticalID (Primary key)
        public int VerticalMappingTypeId { get; set; } // VerticalMappingTypeID (Primary key)
        
        public VerticalMapping()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // VerticalMappingMigrationAccessLog
    public partial class VerticalMappingMigrationAccessLog : Entity
    {
        public Guid UserId { get; set; } // UserID (Primary key)
        public int BuyerAccountId { get; set; } // BuyerAccountID (Primary key)
        public DateTime? LastDeferDateTime { get; set; } // LastDeferDateTime
        public DateTime? LastMigrationDateTime { get; set; } // LastMigrationDateTime
        
        public VerticalMappingMigrationAccessLog()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // VerticalStringReferenceToVIDsMapping
    public partial class VerticalStringReferenceToViDsMapping : Entity
    {
        public string Reference { get; set; } // Reference
        public int? V1 { get; set; } // v1
        public int? V2 { get; set; } // v2
        public int? V3 { get; set; } // v3
        public int VerticalStringReferenceToViDsMappingId { get; set; } // VerticalStringReferenceToVIDsMappingID (Primary key)
        
        public VerticalStringReferenceToViDsMapping()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // VerticalView
    public partial class VerticalView : Entity
    {
        public int VerticalId { get; set; } // VerticalID
        public int Vertical1Id { get; set; } // Vertical1ID
        public int? Vertical2Id { get; set; } // Vertical2ID
        public int? Vertical3Id { get; set; } // Vertical3ID
        public string Vertical1Name { get; set; } // Vertical1Name
        public string Vertical2Name { get; set; } // Vertical2Name
        public string Vertical3Name { get; set; } // Vertical3Name
        
        public VerticalView()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }


    // ************************************************************************
    // POCO Configuration

    // AccountsReceivableRtbView
    internal partial class AccountsReceivableRtbViewMap : EntityTypeConfiguration<AccountsReceivableRtbView>
    {
        public AccountsReceivableRtbViewMap()
            : this("dbo")
        {
        }
 
        public AccountsReceivableRtbViewMap(string schema)
        {
            ToTable(schema + ".AccountsReceivableRtbView");
            HasKey(x => new { x.ContactName, x.EmailAddress, x.PoAddressLine1, x.PoCity, x.PoRegion, x.PoCountry, x.Reference, x.InvoiceDate, x.DueDate, x.SubTotal, x.TotalTax, x.Total, x.AdvertiserName, x.Description, x.Quantity, x.AccountCode, x.CurrencyName, x.TaxType, x.TaxAmount, x.TrackingName1, x.TrackingOption1, x.TrackingName2, x.TrackingOption2 });

            Property(x => x.ContactName).HasColumnName("ContactName").IsRequired().HasColumnType("nvarchar").HasMaxLength(102);
            Property(x => x.EmailAddress).HasColumnName("EmailAddress").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.PoAddressLine1).HasColumnName("POAddressLine1").IsRequired().HasColumnType("nvarchar").HasMaxLength(102);
            Property(x => x.PoAddressLine2).HasColumnName("POAddressLine2").IsOptional().HasColumnType("nvarchar").HasMaxLength(102);
            Property(x => x.PoAddressLine3).HasColumnName("POAddressLine3").IsOptional().HasColumnType("nvarchar").HasMaxLength(102);
            Property(x => x.PoAddresLine4).HasColumnName("POAddresLine4").IsOptional().HasColumnType("nvarchar").HasMaxLength(102);
            Property(x => x.PoCity).HasColumnName("POCity").IsRequired().HasColumnType("nvarchar").HasMaxLength(102);
            Property(x => x.PoRegion).HasColumnName("PORegion").IsRequired().HasColumnType("nvarchar").HasMaxLength(102);
            Property(x => x.PoPostalCode).HasColumnName("POPostalCode").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.PoCountry).HasColumnName("POCountry").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.InvoiceNumber).HasColumnName("InvoiceNumber").IsOptional().HasColumnType("nvarchar").HasMaxLength(56);
            Property(x => x.Reference).HasColumnName("Reference").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.InvoiceDate).HasColumnName("InvoiceDate").IsRequired().HasColumnType("date");
            Property(x => x.DueDate).HasColumnName("DueDate").IsRequired().HasColumnType("date");
            Property(x => x.SubTotal).HasColumnName("SubTotal").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.TotalTax).HasColumnName("TotalTax").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.Total).HasColumnName("Total").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.AdvertiserName).HasColumnName("AdvertiserName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.Description).HasColumnName("Description").IsRequired().HasColumnType("nvarchar").HasMaxLength(1002);
            Property(x => x.Quantity).HasColumnName("Quantity").IsRequired().HasColumnType("int");
            Property(x => x.UnitAmount).HasColumnName("UnitAmount").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.AccountCode).HasColumnName("AccountCode").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(3);
            Property(x => x.CurrencyName).HasColumnName("CurrencyName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Iso4217Code).HasColumnName("ISO4217Code").IsOptional().IsFixedLength().IsUnicode(false).HasColumnType("char").HasMaxLength(3);
            Property(x => x.TaxType).HasColumnName("TaxType").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(13);
            Property(x => x.TaxAmount).HasColumnName("TaxAmount").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.TrackingName1).HasColumnName("TrackingName1").IsRequired().HasColumnType("nvarchar").HasMaxLength(52);
            Property(x => x.TrackingOption1).HasColumnName("TrackingOption1").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.TrackingName2).HasColumnName("TrackingName2").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.TrackingOption2).HasColumnName("TrackingOption2").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ActiveAdGroupLookup
    internal partial class ActiveAdGroupLookupMap : EntityTypeConfiguration<ActiveAdGroupLookup>
    {
        public ActiveAdGroupLookupMap()
            : this("dbo")
        {
        }
 
        public ActiveAdGroupLookupMap(string schema)
        {
            ToTable(schema + ".ActiveAdGroupLookup");
            HasKey(x => new { x.AdGroupId, x.BudgetAmount, x.MaxBidCpm, x.GoalTypeId, x.GoalTargetRate, x.AutoPause, x.AdGroupStatusId, x.UtcCreatedDateTime, x.UtcModifiedDateTime, x.SpendConstraintPeriodId, x.SpendConstraintAmount, x.UniqueConstraintPeriodId, x.UniqueConstraintAmount });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.RtbAdGroupId).HasColumnName("RtbAdGroupID").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(24);
            Property(x => x.AdGroupName).HasColumnName("AdGroupName").IsOptional().HasColumnType("nvarchar").HasMaxLength(4000);
            Property(x => x.BudgetAmount).HasColumnName("BudgetAmount").IsRequired().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.MaxBidCpm).HasColumnName("MaxBidCpm").IsRequired().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.GoalTargetRate).HasColumnName("GoalTargetRate").IsRequired().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.AutoPause).HasColumnName("AutoPause").IsRequired().HasColumnType("bit");
            Property(x => x.AdGroupStatusId).HasColumnName("AdGroupStatusID").IsRequired().HasColumnType("int");
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.RtbCampaignId).HasColumnName("RtbCampaignID").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(24);
            Property(x => x.SpendConstraintPeriodId).HasColumnName("SpendConstraintPeriodID").IsRequired().HasColumnType("int");
            Property(x => x.SpendConstraintAmount).HasColumnName("SpendConstraintAmount").IsRequired().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.UniqueConstraintPeriodId).HasColumnName("UniqueConstraintPeriodID").IsRequired().HasColumnType("int");
            Property(x => x.UniqueConstraintAmount).HasColumnName("UniqueConstraintAmount").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupSegmentConversions).HasColumnName("AdGroupSegmentConversions").IsOptional().HasColumnType("nvarchar");
            Property(x => x.AdGroupTargeting).HasColumnName("AdGroupTargeting").IsOptional().HasColumnType("nvarchar");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ActiveAdLookup
    internal partial class ActiveAdLookupMap : EntityTypeConfiguration<ActiveAdLookup>
    {
        public ActiveAdLookupMap()
            : this("dbo")
        {
        }
 
        public ActiveAdLookupMap(string schema)
        {
            ToTable(schema + ".ActiveAdLookup");
            HasKey(x => new { x.PlacementId, x.CreativeStatusId, x.UtcCreatedDateTime, x.UtcModifiedDateTime, x.TemplatePath, x.CreativeVendorId, x.AdGroupId });

            Property(x => x.PlacementId).HasColumnName("PlacementID").IsRequired().HasColumnType("int");
            Property(x => x.RtbAdId).HasColumnName("RtbAdID").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(24);
            Property(x => x.AdName).HasColumnName("AdName").IsOptional().HasColumnType("nvarchar").HasMaxLength(4000);
            Property(x => x.DestinationUrl).HasColumnName("DestinationUrl").IsOptional().HasColumnType("nvarchar").HasMaxLength(4000);
            Property(x => x.ClickTrackerUrl).HasColumnName("ClickTrackerUrl").IsOptional().HasColumnType("nvarchar").HasMaxLength(4000);
            Property(x => x.CreativeStatusId).HasColumnName("CreativeStatusID").IsRequired().HasColumnType("int");
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.CreativeParameters).HasColumnName("CreativeParameters").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Width).HasColumnName("Width").IsOptional().HasColumnType("int");
            Property(x => x.Height).HasColumnName("Height").IsOptional().HasColumnType("int");
            Property(x => x.TemplatePath).HasColumnName("TemplatePath").IsRequired().HasColumnType("nvarchar").HasMaxLength(1000);
            Property(x => x.CreativeVendorId).HasColumnName("CreativeVendorID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.RtbAdGroupId).HasColumnName("RtbAdGroupID").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(24);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ActiveCampaignLookup
    internal partial class ActiveCampaignLookupMap : EntityTypeConfiguration<ActiveCampaignLookup>
    {
        public ActiveCampaignLookupMap()
            : this("dbo")
        {
        }
 
        public ActiveCampaignLookupMap(string schema)
        {
            ToTable(schema + ".ActiveCampaignLookup");
            HasKey(x => new { x.CampaignId, x.BuyerAccountId, x.CampaignName, x.AdvertiserProductId, x.UtcCreatedDateTime, x.UtcModifiedDateTime });

            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.RtbCampaignId).HasColumnName("RtbCampaignID").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(24);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.CampaignName).HasColumnName("CampaignName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.AdvertiserProductId).HasColumnName("AdvertiserProductID").IsRequired().HasColumnType("int");
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ActiveSegmentLookup
    internal partial class ActiveSegmentLookupMap : EntityTypeConfiguration<ActiveSegmentLookup>
    {
        public ActiveSegmentLookupMap()
            : this("dbo")
        {
        }
 
        public ActiveSegmentLookupMap(string schema)
        {
            ToTable(schema + ".ActiveSegmentLookup");
            HasKey(x => new { x.SegmentId, x.RtbSegmentId, x.SegmentTypeId, x.SegmentStatusId, x.IsDeleted, x.UtcCreatedDateTime, x.UtcModifiedDateTime });

            Property(x => x.SegmentId).HasColumnName("SegmentID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.RtbSegmentId).HasColumnName("RtbSegmentId").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsOptional().HasColumnType("int");
            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsOptional().HasColumnType("int");
            Property(x => x.SegmentName).HasColumnName("SegmentName").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.SegmentDescription).HasColumnName("SegmentDescription").IsOptional().HasColumnType("nvarchar").HasMaxLength(2000);
            Property(x => x.SegmentTypeId).HasColumnName("SegmentTypeID").IsRequired().HasColumnType("int");
            Property(x => x.ConversionAttributionModelId).HasColumnName("ConversionAttributionModelID").IsOptional().HasColumnType("int");
            Property(x => x.ConversionPostViewLifetime).HasColumnName("ConversionPostViewLifetime").IsOptional().HasColumnType("int");
            Property(x => x.ConversionPostClickLifetime).HasColumnName("ConversionPostClickLifetime").IsOptional().HasColumnType("int");
            Property(x => x.ConversionAttributionCountingModeId).HasColumnName("ConversionAttributionCountingModeID").IsOptional().HasColumnType("int");
            Property(x => x.ConversionAttributionCountingRecency).HasColumnName("ConversionAttributionCountingRecency").IsOptional().HasColumnType("int");
            Property(x => x.RemarketingRecency).HasColumnName("RemarketingRecency").IsOptional().HasColumnType("int");
            Property(x => x.ThirdPartyDataSetId).HasColumnName("ThirdPartyDataSetID").IsOptional().HasColumnType("int");
            Property(x => x.ThirdPartyUtcStartDate).HasColumnName("ThirdPartyUtcStartDate").IsOptional().HasColumnType("datetime");
            Property(x => x.ThirdPartyUtcEndDate).HasColumnName("ThirdPartyUtcEndDate").IsOptional().HasColumnType("datetime");
            Property(x => x.ThirdPartyRecency).HasColumnName("ThirdPartyRecency").IsOptional().HasColumnType("int");
            Property(x => x.ThirdPartyBudgetAmount).HasColumnName("ThirdPartyBudgetAmount").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.ThirdPartyMaxBidCpm).HasColumnName("ThirdPartyMaxBidCpm").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.ThirdPartyAgencyReference).HasColumnName("ThirdPartyAgencyReference").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.ThirdPartyPartnerReference).HasColumnName("ThirdPartyPartnerReference").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.ThirdPartyAvailableUniques).HasColumnName("ThirdPartyAvailableUniques").IsOptional().HasColumnType("int");
            Property(x => x.SegmentStatusId).HasColumnName("SegmentStatusID").IsRequired().HasColumnType("int");
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroup
    internal partial class AdGroupMap : EntityTypeConfiguration<AdGroup>
    {
        public AdGroupMap()
            : this("dbo")
        {
        }
 
        public AdGroupMap(string schema)
        {
            ToTable(schema + ".AdGroup");
            HasKey(x => x.AdGroupId);

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.AdGroupUuid).HasColumnName("AdGroupUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupName).HasColumnName("AdGroupName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.GoalTargetRate).HasColumnName("GoalTargetRate").IsRequired().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.BudgetPeriodId).HasColumnName("BudgetPeriodID").IsRequired().HasColumnType("int");
            Property(x => x.PacingStyleId).HasColumnName("PacingStyleID").IsRequired().HasColumnType("int");
            Property(x => x.BudgetAmount).HasColumnName("BudgetAmount").IsRequired().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.UtcStartDateTime).HasColumnName("UtcStartDateTime").IsOptional().HasColumnType("datetime");
            Property(x => x.UtcEndDateTime).HasColumnName("UtcEndDateTime").IsOptional().HasColumnType("datetime");
            Property(x => x.MaxBidCpm).HasColumnName("MaxBidCpm").IsRequired().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.AutoPause).HasColumnName("AutoPause").IsRequired().HasColumnType("bit");
            Property(x => x.GoalTargetQuantity).HasColumnName("GoalTargetQuantity").IsRequired().HasColumnType("bigint");
            Property(x => x.SpendConstraintPeriodId).HasColumnName("SpendConstraintPeriodID").IsRequired().HasColumnType("int");
            Property(x => x.SpendConstraintAmount).HasColumnName("SpendConstraintAmount").IsRequired().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.UniqueConstraintPeriodId).HasColumnName("UniqueConstraintPeriodID").IsRequired().HasColumnType("int");
            Property(x => x.UniqueConstraintAmount).HasColumnName("UniqueConstraintAmount").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupStatusId).HasColumnName("AdGroupStatusID").IsRequired().HasColumnType("int");
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.LanguageTargetingMode).HasColumnName("LanguageTargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.CountryTargetingMode).HasColumnName("CountryTargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.RegionTargetingMode).HasColumnName("RegionTargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.CityTargetingMode).HasColumnName("CityTargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.Vertical1TargetingMode).HasColumnName("Vertical1TargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.Vertical2TargetingMode).HasColumnName("Vertical2TargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.Vertical3TargetingMode).HasColumnName("Vertical3TargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.ExchangeTargetingMode).HasColumnName("ExchangeTargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.PublisherTargetingMode).HasColumnName("PublisherTargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.SiteTargetingMode).HasColumnName("SiteTargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.DataTargetTargetingMode).HasColumnName("DataTargetTargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.DeviceTargetingMode).HasColumnName("DeviceTargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.DayPartTargetingMode).HasColumnName("DayPartTargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.PagePositionTargetingMode).HasColumnName("PagePositionTargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.UtcOriginalStartDateTime).HasColumnName("UtcOriginalStartDateTime").IsOptional().HasColumnType("datetime");
            Property(x => x.MinBidCpm).HasColumnName("MinBidCpm").IsRequired().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.CloneFromAdGroupId).HasColumnName("CloneFromAdGroupID").IsOptional().HasColumnType("int");
            Property(x => x.PacingAmount).HasColumnName("PacingAmount").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.IsDebug).HasColumnName("IsDebug").IsRequired().HasColumnType("bit");
            Property(x => x.MediaTypeId).HasColumnName("MediaTypeID").IsRequired().HasColumnType("int");
            Property(x => x.SupplySourceId).HasColumnName("SupplySourceID").IsRequired().HasColumnType("int");
            Property(x => x.UseLocalTimeBudgeting).HasColumnName("UseLocalTimeBudgeting").IsRequired().HasColumnType("bit");
            Property(x => x.UseLocalCurrencyBudgeting).HasColumnName("UseLocalCurrencyBudgeting").IsRequired().HasColumnType("bit");
            Property(x => x.UseBinomialFilter).HasColumnName("UseBinomialFilter").IsRequired().HasColumnType("bit");
            Property(x => x.MinSloRate).HasColumnName("MinSloRate").IsRequired().HasColumnType("float");
            Property(x => x.MaxSloRate).HasColumnName("MaxSloRate").IsRequired().HasColumnType("float");
            Property(x => x.PageLevelBrandSafetyLevel).HasColumnName("PageLevelBrandSafetyLevel").IsRequired().HasColumnType("float");
            Property(x => x.PacingStyleOptionId).HasColumnName("PacingStyleOptionID").IsRequired().HasColumnType("int");
            Property(x => x.FrequencyGroupId).HasColumnName("FrequencyGroupID").IsOptional().HasColumnType("int");
            Property(x => x.ApplyBrandSafetySetting).HasColumnName("ApplyBrandSafetySetting").IsRequired().HasColumnType("bit");
            Property(x => x.UseSiteListTargeting).HasColumnName("UseSiteListTargeting").IsOptional().HasColumnType("bit");
            Property(x => x.ClassificationProviderId).HasColumnName("ClassificationProviderID").IsOptional().HasColumnType("int");
            Property(x => x.BrandSafetyProviderId).HasColumnName("BrandSafetyProviderID").IsOptional().HasColumnType("int");
            Property(x => x.ViewabilityProviderId).HasColumnName("ViewabilityProviderID").IsOptional().HasColumnType("int");
            Property(x => x.QualityProviderId).HasColumnName("QualityProviderID").IsOptional().HasColumnType("int");
            Property(x => x.PacingVersion).HasColumnName("PacingVersion").IsOptional().HasColumnType("int");
            Property(x => x.PricingVersion).HasColumnName("PricingVersion").IsOptional().HasColumnType("int");
            Property(x => x.UseBrandscreenVertical).HasColumnName("UseBrandscreenVertical").IsRequired().HasColumnType("bit");
            Property(x => x.UsePacing).HasColumnName("UsePacing").IsRequired().HasColumnType("bit");
            Property(x => x.UsePricing).HasColumnName("UsePricing").IsRequired().HasColumnType("bit");
            Property(x => x.SuspiciousActivityProviderId).HasColumnName("SuspiciousActivityProviderID").IsOptional().HasColumnType("int");
            Property(x => x.ViewablePercentage).HasColumnName("ViewablePercentage").IsOptional().HasColumnType("int");
            Property(x => x.BypassClassificationHide).HasColumnName("BypassClassificationHide").IsRequired().HasColumnType("bit");
            Property(x => x.PostcodeTargetingMode).HasColumnName("PostcodeTargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.MobileCarrierTargetingMode).HasColumnName("MobileCarrierTargetingMode").IsRequired().HasColumnType("int");
            Property(x => x.AutoSpend).HasColumnName("AutoSpend").IsRequired().HasColumnType("bit");
            Property(x => x.DoohGeoLocationGroupTargetingMode).HasColumnName("DoohGeoLocationGroupTargetingMode").IsRequired().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.FrequencyGroup).WithMany(b => b.AdGroups).HasForeignKey(c => c.FrequencyGroupId); // FK_AdGroup_FrequencyGroup
            HasRequired(a => a.BuyerAccount).WithMany(b => b.AdGroups).HasForeignKey(c => c.BuyerAccountId); // FK_AdGroup_BuyerAccount
            HasRequired(a => a.Campaign).WithMany(b => b.AdGroups).HasForeignKey(c => c.CampaignId); // FK_AdGroup_Campaign
            HasRequired(a => a.CampaignPeriod_BudgetPeriodId).WithMany(b => b.AdGroups_BudgetPeriodId).HasForeignKey(c => c.BudgetPeriodId); // FK_AdGroup_BudgetPeriod
            HasRequired(a => a.CampaignPeriod_SpendConstraintPeriodId).WithMany(b => b.AdGroups_SpendConstraintPeriodId).HasForeignKey(c => c.SpendConstraintPeriodId); // FK_AdGroup_SpendCampaignPeriod
            HasRequired(a => a.CampaignPeriod_UniqueConstraintPeriodId).WithMany(b => b.AdGroups_UniqueConstraintPeriodId).HasForeignKey(c => c.UniqueConstraintPeriodId); // FK_AdGroup_UniqueCampaignPeriod
            HasRequired(a => a.CampaignPeriod1).WithMany(b => b.AdGroups1).HasForeignKey(c => c.BudgetPeriodId); // FK_AdGroup_CampaignPeriod
            HasRequired(a => a.CampaignStatus).WithMany(b => b.AdGroups).HasForeignKey(c => c.AdGroupStatusId); // FK_AdGroup_AdGroupStatus
            HasRequired(a => a.GoalType).WithMany(b => b.AdGroups).HasForeignKey(c => c.GoalTypeId); // FK_AdGroup_GoalType
            HasRequired(a => a.MediaType).WithMany(b => b.AdGroups).HasForeignKey(c => c.MediaTypeId); // FK_AdGroup_MediaType
            HasRequired(a => a.PacingStyle).WithMany(b => b.AdGroups).HasForeignKey(c => c.PacingStyleId); // FK_AdGroup_PacingStyle
            HasRequired(a => a.SupplySource).WithMany(b => b.AdGroups).HasForeignKey(c => c.SupplySourceId); // FK_AdGroup_SupplySource
            HasMany(t => t.Segments).WithMany(t => t.AdGroups).Map(m => 
            {
                m.ToTable("AdGroupConversionSegment", "dbo");
                m.MapLeftKey("AdGroupID");
                m.MapRightKey("SegmentID");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupAllDomainList
    internal partial class AdGroupAllDomainListMap : EntityTypeConfiguration<AdGroupAllDomainList>
    {
        public AdGroupAllDomainListMap()
            : this("dbo")
        {
        }
 
        public AdGroupAllDomainListMap(string schema)
        {
            ToTable(schema + ".AdGroupAllDomainList");
            HasKey(x => new { x.DomainListId, x.TargetingActionId, x.AdGroupUuid, x.Level });

            Property(x => x.DomainListId).HasColumnName("DomainListID").IsRequired().HasColumnType("int");
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsOptional().HasColumnType("int");
            Property(x => x.AdGroupUuid).HasColumnName("AdGroupUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.Level).HasColumnName("Level").IsRequired().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupApplicationParameter
    internal partial class AdGroupApplicationParameterMap : EntityTypeConfiguration<AdGroupApplicationParameter>
    {
        public AdGroupApplicationParameterMap()
            : this("dbo")
        {
        }
 
        public AdGroupApplicationParameterMap(string schema)
        {
            ToTable(schema + ".AdGroupApplicationParameter");
            HasKey(x => new { x.AdGroupId, x.PackageKey, x.Key });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.PackageKey).HasColumnName("PackageKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Key).HasColumnName("Key").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Value).HasColumnName("Value").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);

            // Foreign keys
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupAttachedDomainList
    internal partial class AdGroupAttachedDomainListMap : EntityTypeConfiguration<AdGroupAttachedDomainList>
    {
        public AdGroupAttachedDomainListMap()
            : this("dbo")
        {
        }
 
        public AdGroupAttachedDomainListMap(string schema)
        {
            ToTable(schema + ".AdGroupAttachedDomainList");
            HasKey(x => new { x.DomainListId, x.TargetingActionId, x.AdGroupId, x.AdGroupUuid, x.Level });

            Property(x => x.DomainListId).HasColumnName("DomainListID").IsRequired().HasColumnType("int");
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupUuid).HasColumnName("AdGroupUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.Level).HasColumnName("Level").IsRequired().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupBinomialDomainFilterOverride
    internal partial class AdGroupBinomialDomainFilterOverrideMap : EntityTypeConfiguration<AdGroupBinomialDomainFilterOverride>
    {
        public AdGroupBinomialDomainFilterOverrideMap()
            : this("dbo")
        {
        }
 
        public AdGroupBinomialDomainFilterOverrideMap(string schema)
        {
            ToTable(schema + ".AdGroupBinomialDomainFilterOverride");
            HasKey(x => new { x.AdGroupId, x.GoalTypeId, x.DomainName });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DomainName).HasColumnName("DomainName").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(64).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupBinomialDomainFilterTargetingView
    internal partial class AdGroupBinomialDomainFilterTargetingViewMap : EntityTypeConfiguration<AdGroupBinomialDomainFilterTargetingView>
    {
        public AdGroupBinomialDomainFilterTargetingViewMap()
            : this("dbo")
        {
        }
 
        public AdGroupBinomialDomainFilterTargetingViewMap(string schema)
        {
            ToTable(schema + ".AdGroupBinomialDomainFilterTargetingView");
            HasKey(x => new { x.GoalTypeId, x.AdGroupId, x.DomainName });

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.DomainName).HasColumnName("DomainName").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(64);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupBinomialFilterOverride
    internal partial class AdGroupBinomialFilterOverrideMap : EntityTypeConfiguration<AdGroupBinomialFilterOverride>
    {
        public AdGroupBinomialFilterOverrideMap()
            : this("dbo")
        {
        }
 
        public AdGroupBinomialFilterOverrideMap(string schema)
        {
            ToTable(schema + ".AdGroupBinomialFilterOverride");
            HasKey(x => new { x.AdGroupId, x.GoalTypeId, x.InventoryId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.InventoryId).HasColumnName("InventoryID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupBinomialFilterTargetingView
    internal partial class AdGroupBinomialFilterTargetingViewMap : EntityTypeConfiguration<AdGroupBinomialFilterTargetingView>
    {
        public AdGroupBinomialFilterTargetingViewMap()
            : this("dbo")
        {
        }
 
        public AdGroupBinomialFilterTargetingViewMap(string schema)
        {
            ToTable(schema + ".AdGroupBinomialFilterTargetingView");
            HasKey(x => new { x.GoalTypeId, x.AdGroupId, x.PartnerId, x.PublisherId, x.WebsiteId, x.InventoryId });

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int");
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("int");
            Property(x => x.InventoryId).HasColumnName("InventoryID").IsRequired().HasColumnType("bigint");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupBrandSafety
    internal partial class AdGroupBrandSafetyMap : EntityTypeConfiguration<AdGroupBrandSafety>
    {
        public AdGroupBrandSafetyMap()
            : this("dbo")
        {
        }
 
        public AdGroupBrandSafetyMap(string schema)
        {
            ToTable(schema + ".AdGroupBrandSafety");
            HasKey(x => new { x.BrandSafetyTypeId, x.AdGroupId, x.BrandSafetyProviderId });

            Property(x => x.BrandSafetyTypeId).HasColumnName("BrandSafetyTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            Property(x => x.BrandSafetyProviderId).HasColumnName("BrandSafetyProviderID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupBrandSafeties).HasForeignKey(c => c.AdGroupId); // FK_AdGroupBrandSafety_New_AdGroup
            HasRequired(a => a.BrandSafetyType).WithMany(b => b.AdGroupBrandSafeties).HasForeignKey(c => c.BrandSafetyTypeId); // FK_AdGroupBrandSafety_New_BrandSafety
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupBrandSafety_Backup
    internal partial class AdGroupBrandSafetyBackupMap : EntityTypeConfiguration<AdGroupBrandSafetyBackup>
    {
        public AdGroupBrandSafetyBackupMap()
            : this("dbo")
        {
        }
 
        public AdGroupBrandSafetyBackupMap(string schema)
        {
            ToTable(schema + ".AdGroupBrandSafety_Backup");
            HasKey(x => new { x.BrandSafetyTypeId, x.AdGroupId });

            Property(x => x.BrandSafetyTypeId).HasColumnName("BrandSafetyTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            Property(x => x.BrandSafetyProviderId).HasColumnName("BrandSafetyProviderID").IsOptional().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupBrandSafetyBackups).HasForeignKey(c => c.AdGroupId); // FK_AdGroupBrandSafety_AdGroup
            HasRequired(a => a.BrandSafetyType).WithMany(b => b.AdGroupBrandSafetyBackups).HasForeignKey(c => c.BrandSafetyTypeId); // FK_AdGroupBrandSafety_BrandSafety
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupBrandSafetyView
    internal partial class AdGroupBrandSafetyViewMap : EntityTypeConfiguration<AdGroupBrandSafetyView>
    {
        public AdGroupBrandSafetyViewMap()
            : this("dbo")
        {
        }
 
        public AdGroupBrandSafetyViewMap(string schema)
        {
            ToTable(schema + ".AdGroupBrandSafetyView");
            HasKey(x => new { x.BrandSafetyTypeId, x.AdGroupId, x.AdGroupUuid, x.Level, x.BrandSafetyProviderId });

            Property(x => x.BrandSafetyTypeId).HasColumnName("BrandSafetyTypeID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupUuid).HasColumnName("AdGroupUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.Level).HasColumnName("Level").IsRequired().HasColumnType("int");
            Property(x => x.BrandSafetyProviderId).HasColumnName("BrandSafetyProviderID").IsRequired().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupContextualFee
    internal partial class AdGroupContextualFeeMap : EntityTypeConfiguration<AdGroupContextualFee>
    {
        public AdGroupContextualFeeMap()
            : this("dbo")
        {
        }
 
        public AdGroupContextualFeeMap(string schema)
        {
            ToTable(schema + ".AdGroupContextualFee");
            HasKey(x => x.AdGroupId);

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.ClassificationProviderId).HasColumnName("ClassificationProviderID").IsOptional().HasColumnType("int");
            Property(x => x.ClassificationUseFlatFee).HasColumnName("ClassificationUseFlatFee").IsOptional().HasColumnType("int");
            Property(x => x.ClassificationFlatFee).HasColumnName("ClassificationFlatFee").IsOptional().HasColumnType("numeric").HasPrecision(18,3);
            Property(x => x.ClassificationPercentageFee).HasColumnName("ClassificationPercentageFee").IsOptional().HasColumnType("decimal").HasPrecision(18,3);
            Property(x => x.BrandSafetyProviderId).HasColumnName("BrandSafetyProviderID").IsOptional().HasColumnType("int");
            Property(x => x.BrandSafetyUseFlatFee).HasColumnName("BrandSafetyUseFlatFee").IsOptional().HasColumnType("int");
            Property(x => x.BrandSafetyFlatFee).HasColumnName("BrandSafetyFlatFee").IsOptional().HasColumnType("numeric").HasPrecision(18,3);
            Property(x => x.BrandSafetyPercentageFee).HasColumnName("BrandSafetyPercentageFee").IsOptional().HasColumnType("decimal").HasPrecision(18,3);
            Property(x => x.ViewabilityProviderId).HasColumnName("ViewabilityProviderID").IsOptional().HasColumnType("int");
            Property(x => x.ViewabilityUseFlatFee).HasColumnName("ViewabilityUseFlatFee").IsOptional().HasColumnType("int");
            Property(x => x.ViewabilityFlatFee).HasColumnName("ViewabilityFlatFee").IsOptional().HasColumnType("numeric").HasPrecision(18,3);
            Property(x => x.ViewabilityPercentageFee).HasColumnName("ViewabilityPercentageFee").IsOptional().HasColumnType("decimal").HasPrecision(18,3);
            Property(x => x.QualityProviderId).HasColumnName("QualityProviderID").IsOptional().HasColumnType("int");
            Property(x => x.QualityUseFlatFee).HasColumnName("QualityUseFlatFee").IsOptional().HasColumnType("int");
            Property(x => x.QualityFlatFee).HasColumnName("QualityFlatFee").IsOptional().HasColumnType("decimal").HasPrecision(18,3);
            Property(x => x.QualityPercentageFee).HasColumnName("QualityPercentageFee").IsOptional().HasColumnType("decimal").HasPrecision(18,3);
            Property(x => x.SuspiciousActivityProviderId).HasColumnName("SuspiciousActivityProviderID").IsOptional().HasColumnType("int");
            Property(x => x.SuspiciousActivityUseFlatFee).HasColumnName("SuspiciousActivityUseFlatFee").IsOptional().HasColumnType("int");
            Property(x => x.SuspiciousActivityFlatFee).HasColumnName("SuspiciousActivityFlatFee").IsOptional().HasColumnType("numeric").HasPrecision(18,3);
            Property(x => x.SuspiciousActivityPercentageFee).HasColumnName("SuspiciousActivityPercentageFee").IsOptional().HasColumnType("decimal").HasPrecision(18,3);
            Property(x => x.ClassificationBrandSafetyProviderId).HasColumnName("ClassificationBrandSafetyProviderID").IsOptional().HasColumnType("int");
            Property(x => x.ClassificationBrandSafetyUseFlatFee).HasColumnName("ClassificationBrandSafetyUseFlatFee").IsOptional().HasColumnType("int");
            Property(x => x.ClassificationBrandSafetyFlatFee).HasColumnName("ClassificationBrandSafetyFlatFee").IsOptional().HasColumnType("decimal").HasPrecision(18,3);
            Property(x => x.ClassificationBrandSafetyPercentageFee).HasColumnName("ClassificationBrandSafetyPercentageFee").IsOptional().HasColumnType("decimal").HasPrecision(18,3);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupDayPart
    internal partial class AdGroupDayPartMap : EntityTypeConfiguration<AdGroupDayPart>
    {
        public AdGroupDayPartMap()
            : this("dbo")
        {
        }
 
        public AdGroupDayPartMap(string schema)
        {
            ToTable(schema + ".AdGroupDayPart");
            HasKey(x => new { x.AdGroupId, x.DayPartId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DayPartId).HasColumnName("DayPartID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupDayParts).HasForeignKey(c => c.AdGroupId); // FK_AdGroupDayPart_AdGroup
            HasRequired(a => a.DayPart).WithMany(b => b.AdGroupDayParts).HasForeignKey(c => c.DayPartId); // FK_AdGroupDayPart_DayPart
            HasRequired(a => a.TargetingAction).WithMany(b => b.AdGroupDayParts).HasForeignKey(c => c.TargetingActionId); // FK_AdGroupDayPart_TargetingAction
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupDeal
    internal partial class AdGroupDealMap : EntityTypeConfiguration<AdGroupDeal>
    {
        public AdGroupDealMap()
            : this("dbo")
        {
        }
 
        public AdGroupDealMap(string schema)
        {
            ToTable(schema + ".AdGroupDeal");
            HasKey(x => new { x.AdGroupId, x.DealId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DealId).HasColumnName("DealID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupDeals).HasForeignKey(c => c.AdGroupId); // FK_AdGroupDeal_AdGroup
            HasRequired(a => a.Deal).WithMany(b => b.AdGroupDeals).HasForeignKey(c => c.DealId); // FK_AdGroupDeal_Deal
            HasRequired(a => a.TargetingAction).WithMany(b => b.AdGroupDeals).HasForeignKey(c => c.TargetingActionId); // FK_AdGroupDeal_TargetingAction
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupDevice
    internal partial class AdGroupDeviceMap : EntityTypeConfiguration<AdGroupDevice>
    {
        public AdGroupDeviceMap()
            : this("dbo")
        {
        }
 
        public AdGroupDeviceMap(string schema)
        {
            ToTable(schema + ".AdGroupDevice");
            HasKey(x => new { x.AdGroupId, x.DeviceId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DeviceId).HasColumnName("DeviceID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupDevices).HasForeignKey(c => c.AdGroupId); // FK_AdGroupDevice_AdGroup
            HasRequired(a => a.Device).WithMany(b => b.AdGroupDevices).HasForeignKey(c => c.DeviceId); // FK_AdGroupDevice_Device
            HasRequired(a => a.TargetingAction).WithMany(b => b.AdGroupDevices).HasForeignKey(c => c.TargetingActionId); // FK_AdGroupDevice_TargetingAction
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupDomainList
    internal partial class AdGroupDomainListMap : EntityTypeConfiguration<AdGroupDomainList>
    {
        public AdGroupDomainListMap()
            : this("dbo")
        {
        }
 
        public AdGroupDomainListMap(string schema)
        {
            ToTable(schema + ".AdGroupDomainList");
            HasKey(x => new { x.DomainListId, x.AdGroupId });

            Property(x => x.DomainListId).HasColumnName("DomainListID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupDomainLists).HasForeignKey(c => c.AdGroupId); // FK_AdGroupDomainList_AdGroup
            HasRequired(a => a.DomainList).WithMany(b => b.AdGroupDomainLists).HasForeignKey(c => c.DomainListId); // FK_AdGroupDomainList_DomainList
            HasRequired(a => a.TargetingAction).WithMany(b => b.AdGroupDomainLists).HasForeignKey(c => c.TargetingActionId); // FK_AdGroupDomainList_TargetingAction
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupDoohGeoLocationGroup
    internal partial class AdGroupDoohGeoLocationGroupMap : EntityTypeConfiguration<AdGroupDoohGeoLocationGroup>
    {
        public AdGroupDoohGeoLocationGroupMap()
            : this("dbo")
        {
        }
 
        public AdGroupDoohGeoLocationGroupMap(string schema)
        {
            ToTable(schema + ".AdGroupDoohGeoLocationGroup");
            HasKey(x => new { x.AdGroupId, x.DoohGeoLocationGroupId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DoohGeoLocationGroupId).HasColumnName("DoohGeoLocationGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupDoohGeoLocationGroups).HasForeignKey(c => c.AdGroupId); // FK_AdGroupDoohGeoLocationGroup_AdGroup
            HasRequired(a => a.DoohGeoLocationGroup).WithMany(b => b.AdGroupDoohGeoLocationGroups).HasForeignKey(c => c.DoohGeoLocationGroupId); // FK_AdGroupDoohGeoLocationGroup_DoohGeoLocationGroup
            HasRequired(a => a.TargetingAction).WithMany(b => b.AdGroupDoohGeoLocationGroups).HasForeignKey(c => c.TargetingActionId); // FK_AdGroupDoohGeoLocationGroup_TargetingAction
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupDoohPanelLocation
    internal partial class AdGroupDoohPanelLocationMap : EntityTypeConfiguration<AdGroupDoohPanelLocation>
    {
        public AdGroupDoohPanelLocationMap()
            : this("dbo")
        {
        }
 
        public AdGroupDoohPanelLocationMap(string schema)
        {
            ToTable(schema + ".AdGroupDoohPanelLocation");
            HasKey(x => new { x.AdGroupId, x.DoohPanelLocationId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DoohPanelLocationId).HasColumnName("DoohPanelLocationID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupDoohPanelLocations).HasForeignKey(c => c.AdGroupId); // FK_AdGroupDoohPanelLocation_AdGroup
            HasRequired(a => a.DoohPanelLocation).WithMany(b => b.AdGroupDoohPanelLocations).HasForeignKey(c => c.DoohPanelLocationId); // FK_AdGroupDoohPanelLocation_DoohPanelLocation
            HasRequired(a => a.TargetingAction).WithMany(b => b.AdGroupDoohPanelLocations).HasForeignKey(c => c.TargetingActionId); // FK_AdGroupDoohPanelLocation_TargetingAction
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupGeoLocation
    internal partial class AdGroupGeoLocationMap : EntityTypeConfiguration<AdGroupGeoLocation>
    {
        public AdGroupGeoLocationMap()
            : this("dbo")
        {
        }
 
        public AdGroupGeoLocationMap(string schema)
        {
            ToTable(schema + ".AdGroupGeoLocation");
            HasKey(x => new { x.AdGroupId, x.GeoLocationId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.GeoLocationId).HasColumnName("GeoLocationID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupGeoLocations).HasForeignKey(c => c.AdGroupId); // FK_AdGroupGeoLocation_AdGroup
            HasRequired(a => a.GeoLocation).WithMany(b => b.AdGroupGeoLocations).HasForeignKey(c => c.GeoLocationId); // FK_AdGroupGeoLocation_GeoLocation
            HasRequired(a => a.TargetingAction).WithMany(b => b.AdGroupGeoLocations).HasForeignKey(c => c.TargetingActionId); // FK_AdGroupGeoLocation_TargetingAction
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupGeoLocationPointRadius
    internal partial class AdGroupGeoLocationPointRadiusMap : EntityTypeConfiguration<AdGroupGeoLocationPointRadius>
    {
        public AdGroupGeoLocationPointRadiusMap()
            : this("dbo")
        {
        }
 
        public AdGroupGeoLocationPointRadiusMap(string schema)
        {
            ToTable(schema + ".AdGroupGeoLocationPointRadius");
            HasKey(x => new { x.AdGroupId, x.Latitude, x.Longitude });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Latitude).HasColumnName("Latitude").IsRequired().HasColumnType("decimal").HasPrecision(11,7).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Longitude).HasColumnName("Longitude").IsRequired().HasColumnType("decimal").HasPrecision(11,7).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.RadiusInKm).HasColumnName("RadiusInKm").IsRequired().HasColumnType("decimal").HasPrecision(6,2);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupGeoLocationPointRadius).HasForeignKey(c => c.AdGroupId); // FK_AdGroupGeoLocationPointRadius_AdGroup
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupGeoPostcode
    internal partial class AdGroupGeoPostcodeMap : EntityTypeConfiguration<AdGroupGeoPostcode>
    {
        public AdGroupGeoPostcodeMap()
            : this("dbo")
        {
        }
 
        public AdGroupGeoPostcodeMap(string schema)
        {
            ToTable(schema + ".AdGroupGeoPostcode");
            HasKey(x => new { x.AdGroupId, x.GeoCountryId, x.Postcode });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.GeoCountryId).HasColumnName("GeoCountryID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Postcode).HasColumnName("Postcode").IsRequired().HasColumnType("nvarchar").HasMaxLength(25).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupGeoPostcodes).HasForeignKey(c => c.AdGroupId); // FK_AdGroupGeoPostcode_AdGroup
            HasRequired(a => a.GeoCountry).WithMany(b => b.AdGroupGeoPostcodes).HasForeignKey(c => c.GeoCountryId); // FK_AdGroupGeoPostcode_GeoCountry
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupInheritedDomainList
    internal partial class AdGroupInheritedDomainListMap : EntityTypeConfiguration<AdGroupInheritedDomainList>
    {
        public AdGroupInheritedDomainListMap()
            : this("dbo")
        {
        }
 
        public AdGroupInheritedDomainListMap(string schema)
        {
            ToTable(schema + ".AdGroupInheritedDomainList");
            HasKey(x => new { x.DomainListId, x.TargetingActionId, x.AdGroupId, x.AdGroupUuid, x.Level });

            Property(x => x.DomainListId).HasColumnName("DomainListID").IsRequired().HasColumnType("int");
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupUuid).HasColumnName("AdGroupUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.Level).HasColumnName("Level").IsRequired().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupInventory
    internal partial class AdGroupInventoryMap : EntityTypeConfiguration<AdGroupInventory>
    {
        public AdGroupInventoryMap()
            : this("dbo")
        {
        }
 
        public AdGroupInventoryMap(string schema)
        {
            ToTable(schema + ".AdGroupInventory");
            HasKey(x => new { x.AdGroupId, x.InventoryId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.InventoryId).HasColumnName("InventoryID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            Property(x => x.IsUploaded).HasColumnName("IsUploaded").IsRequired().HasColumnType("bit");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupInventories).HasForeignKey(c => c.AdGroupId); // FK_AdGroupInventory_AdGroup
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupLanguage
    internal partial class AdGroupLanguageMap : EntityTypeConfiguration<AdGroupLanguage>
    {
        public AdGroupLanguageMap()
            : this("dbo")
        {
        }
 
        public AdGroupLanguageMap(string schema)
        {
            ToTable(schema + ".AdGroupLanguage");
            HasKey(x => new { x.AdGroupId, x.LanguageId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.LanguageId).HasColumnName("LanguageID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupLanguages).HasForeignKey(c => c.AdGroupId); // FK_AdGroupLanguage_AdGroup
            HasRequired(a => a.Language).WithMany(b => b.AdGroupLanguages).HasForeignKey(c => c.LanguageId); // FK_AdGroupLanguage_Language
            HasRequired(a => a.TargetingAction).WithMany(b => b.AdGroupLanguages).HasForeignKey(c => c.TargetingActionId); // FK_AdGroupLanguage_TargetingAction
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupMobileCarrier
    internal partial class AdGroupMobileCarrierMap : EntityTypeConfiguration<AdGroupMobileCarrier>
    {
        public AdGroupMobileCarrierMap()
            : this("dbo")
        {
        }
 
        public AdGroupMobileCarrierMap(string schema)
        {
            ToTable(schema + ".AdGroupMobileCarrier");
            HasKey(x => new { x.AdGroupId, x.GeoCountryId, x.Mcc, x.Mnc });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.GeoCountryId).HasColumnName("GeoCountryID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Mcc).HasColumnName("MCC").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Mnc).HasColumnName("MNC").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupMobileCarriers).HasForeignKey(c => c.AdGroupId); // FK_AdGroupMobileCarrier_AdGroup
            HasRequired(a => a.GeoCountry).WithMany(b => b.AdGroupMobileCarriers).HasForeignKey(c => c.GeoCountryId); // FK_AdGroupMobileCarrier_GeoCountry
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupNotification
    internal partial class AdGroupNotificationMap : EntityTypeConfiguration<AdGroupNotification>
    {
        public AdGroupNotificationMap()
            : this("dbo")
        {
        }
 
        public AdGroupNotificationMap(string schema)
        {
            ToTable(schema + ".AdGroupNotification");
            HasKey(x => new { x.AdGroupId, x.AdGroupNotificationTypeId, x.UtcCreatedDateTime });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdGroupNotificationTypeId).HasColumnName("AdGroupNotificationTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.UtcDeletedDateTime).HasColumnName("UtcDeletedDateTime").IsOptional().HasColumnType("datetime");
            Property(x => x.Details).HasColumnName("Details").IsOptional().HasColumnType("nvarchar").HasMaxLength(1000);

            // Foreign keys
            HasRequired(a => a.AdGroupNotificationType).WithMany(b => b.AdGroupNotifications).HasForeignKey(c => c.AdGroupNotificationTypeId); // FK_AdGroupNotification_AdGroupNotificationTypeID
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupNotificationType
    internal partial class AdGroupNotificationTypeMap : EntityTypeConfiguration<AdGroupNotificationType>
    {
        public AdGroupNotificationTypeMap()
            : this("dbo")
        {
        }
 
        public AdGroupNotificationTypeMap(string schema)
        {
            ToTable(schema + ".AdGroupNotificationType");
            HasKey(x => x.AdGroupNotificationTypeId);

            Property(x => x.AdGroupNotificationTypeId).HasColumnName("AdGroupNotificationTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdGroupNotificationTypeName).HasColumnName("AdGroupNotificationTypeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupPagePosition
    internal partial class AdGroupPagePositionMap : EntityTypeConfiguration<AdGroupPagePosition>
    {
        public AdGroupPagePositionMap()
            : this("dbo")
        {
        }
 
        public AdGroupPagePositionMap(string schema)
        {
            ToTable(schema + ".AdGroupPagePosition");
            HasKey(x => new { x.AdGroupId, x.PagePositionId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PagePositionId).HasColumnName("PagePositionID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupPagePositions).HasForeignKey(c => c.AdGroupId); // FK_AdGroupPagePosition_AdGroup
            HasRequired(a => a.PagePosition).WithMany(b => b.AdGroupPagePositions).HasForeignKey(c => c.PagePositionId); // FK_AdGroupPagePosition_PagePosition
            HasRequired(a => a.TargetingAction).WithMany(b => b.AdGroupPagePositions).HasForeignKey(c => c.TargetingActionId); // FK_AdGroupPagePosition_TargetingAction
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupPerformance
    internal partial class AdGroupPerformanceMap : EntityTypeConfiguration<AdGroupPerformance>
    {
        public AdGroupPerformanceMap()
            : this("dbo")
        {
        }
 
        public AdGroupPerformanceMap(string schema)
        {
            ToTable(schema + ".AdGroupPerformance");
            HasKey(x => new { x.AdGroupId, x.IntervalId, x.IntervalValue });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalId).HasColumnName("IntervalID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalValue).HasColumnName("IntervalValue").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Bids).HasColumnName("Bids").IsRequired().HasColumnType("bigint");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Clicks).HasColumnName("Clicks").IsRequired().HasColumnType("bigint");
            Property(x => x.Conversions).HasColumnName("Conversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostViewConversions).HasColumnName("PostViewConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostClickConversions).HasColumnName("PostClickConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.LastActivityTimestamp).HasColumnName("LastActivityTimestamp").IsOptional().HasColumnType("datetime");
            Property(x => x.Ctr).HasColumnName("CTR").IsOptional().HasColumnType("float").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaCostLocalMicros).HasColumnName("MediaCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataCostLocalMicros).HasColumnName("DataCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.SpendLocalMicros).HasColumnName("SpendLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaClientCostLocalMicros).HasColumnName("MediaClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataClientCostLocalMicros).HasColumnName("DataClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.ClientCostLocalMicros).HasColumnName("ClientCostLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpm).HasColumnName("CPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpc).HasColumnName("CPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpa).HasColumnName("CPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpm).HasColumnName("ClientCostCPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpc).HasColumnName("ClientCostCPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpa).HasColumnName("ClientCostCPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.PricingHealth).HasColumnName("PricingHealth").IsRequired().HasColumnType("int");
            Property(x => x.PacingHealth).HasColumnName("PacingHealth").IsRequired().HasColumnType("int");
            Property(x => x.Cvr).HasColumnName("Cvr").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.BidWin).HasColumnName("BidWin").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.FeesLocalSuperMicros).HasColumnName("FeesLocalSuperMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.AdSlotDurationInSeconds).HasColumnName("AdSlotDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.RawViews).HasColumnName("RawViews").IsRequired().HasColumnType("bigint");
            Property(x => x.IabViews).HasColumnName("IabViews").IsRequired().HasColumnType("bigint");
            Property(x => x.ViewDurationInSeconds).HasColumnName("ViewDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.CpMs).HasColumnName("CPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpMs).HasColumnName("ClientCostCPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cps).HasColumnName("CPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCps).HasColumnName("ClientCostCPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ViewableRatio).HasColumnName("ViewableRatio").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupPerformances).HasForeignKey(c => c.AdGroupId); // FK_AdGroupPerformance_AdGroup
            HasRequired(a => a.Interval).WithMany(b => b.AdGroupPerformances).HasForeignKey(c => c.IntervalId); // FK_AdGroupPerformance_Interval
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupPublisher
    internal partial class AdGroupPublisherMap : EntityTypeConfiguration<AdGroupPublisher>
    {
        public AdGroupPublisherMap()
            : this("dbo")
        {
        }
 
        public AdGroupPublisherMap(string schema)
        {
            ToTable(schema + ".AdGroupPublisher");
            HasKey(x => new { x.AdGroupId, x.PublisherId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupPublishers).HasForeignKey(c => c.AdGroupId); // FK_AdGroupPublisher_AdGroup
            HasRequired(a => a.Publisher).WithMany(b => b.AdGroupPublishers).HasForeignKey(c => c.PublisherId); // FK_AdGroupPublisher_Publisher
            HasRequired(a => a.TargetingAction).WithMany(b => b.AdGroupPublishers).HasForeignKey(c => c.TargetingActionId); // FK_AdGroupPublisher_TargetingAction
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupSegment
    internal partial class AdGroupSegmentMap : EntityTypeConfiguration<AdGroupSegment>
    {
        public AdGroupSegmentMap()
            : this("dbo")
        {
        }
 
        public AdGroupSegmentMap(string schema)
        {
            ToTable(schema + ".AdGroupSegment");
            HasKey(x => new { x.AdGroupId, x.SegmentId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.SegmentId).HasColumnName("SegmentID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupSegments).HasForeignKey(c => c.AdGroupId); // FK_AdGroupSegment_AdGroup
            HasRequired(a => a.Segment).WithMany(b => b.AdGroupSegments).HasForeignKey(c => c.SegmentId); // FK_AdGroupSegment_Segment
            HasRequired(a => a.TargetingAction).WithMany(b => b.AdGroupSegments).HasForeignKey(c => c.TargetingActionId); // FK_AdGroupSegment_TargetingAction
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupSloRateLookup
    internal partial class AdGroupSloRateLookupMap : EntityTypeConfiguration<AdGroupSloRateLookup>
    {
        public AdGroupSloRateLookupMap()
            : this("dbo")
        {
        }
 
        public AdGroupSloRateLookupMap(string schema)
        {
            ToTable(schema + ".AdGroupSloRateLookup");
            HasKey(x => new { x.AdGroupId, x.CampaignId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int");
            Property(x => x.MinSloRate).HasColumnName("MinSloRate").IsOptional().HasColumnType("float");
            Property(x => x.MaxSloRate).HasColumnName("MaxSloRate").IsOptional().HasColumnType("float");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupSupplySource
    internal partial class AdGroupSupplySourceMap : EntityTypeConfiguration<AdGroupSupplySource>
    {
        public AdGroupSupplySourceMap()
            : this("dbo")
        {
        }
 
        public AdGroupSupplySourceMap(string schema)
        {
            ToTable(schema + ".AdGroupSupplySource");
            HasKey(x => new { x.AdGroupId, x.PartnerId, x.PublisherId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupSupplySources).HasForeignKey(c => c.AdGroupId); // FK_AdGroupSupplySource_AdGroup
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupTargetingPerformance
    internal partial class AdGroupTargetingPerformanceMap : EntityTypeConfiguration<AdGroupTargetingPerformance>
    {
        public AdGroupTargetingPerformanceMap()
            : this("dbo")
        {
        }
 
        public AdGroupTargetingPerformanceMap(string schema)
        {
            ToTable(schema + ".AdGroupTargetingPerformance");
            HasKey(x => new { x.AdGroupId, x.TargetingAttributeTypeId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingAttributeTypeId).HasColumnName("TargetingAttributeTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Bids).HasColumnName("Bids").IsRequired().HasColumnType("bigint");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Clicks).HasColumnName("Clicks").IsRequired().HasColumnType("bigint");
            Property(x => x.Conversions).HasColumnName("Conversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostViewConversions).HasColumnName("PostViewConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostClickConversions).HasColumnName("PostClickConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.Spend).HasColumnName("Spend").IsRequired().HasColumnType("bigint");
            Property(x => x.Ctr).HasColumnName("CTR").IsOptional().HasColumnType("float").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpm).HasColumnName("CPM").IsOptional().HasColumnType("money").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpc).HasColumnName("CPC").IsOptional().HasColumnType("money").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpa).HasColumnName("CPA").IsOptional().HasColumnType("money").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.TimeSpanId).HasColumnName("TimeSpanID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupTargetingPerformances).HasForeignKey(c => c.AdGroupId); // FK_AdGroupTargetingPerformance_AdGroup
            HasRequired(a => a.TargetingAttributeType).WithMany(b => b.AdGroupTargetingPerformances).HasForeignKey(c => c.TargetingAttributeTypeId); // FK_AdGroupTargetingPerformance_TargetingAttributeType
            HasRequired(a => a.TimeSpan).WithMany(b => b.AdGroupTargetingPerformances).HasForeignKey(c => c.TimeSpanId); // FK_AdGroupTargetingPerformance_TimeSpan
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupTargetingView
    internal partial class AdGroupTargetingViewMap : EntityTypeConfiguration<AdGroupTargetingView>
    {
        public AdGroupTargetingViewMap()
            : this("dbo")
        {
        }
 
        public AdGroupTargetingViewMap(string schema)
        {
            ToTable(schema + ".AdGroupTargetingView");
            HasKey(x => new { x.AdGroupId, x.TargetingAttributeTypeId, x.TargetingActionId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.TargetingAttributeTypeId).HasColumnName("TargetingAttributeTypeID").IsRequired().HasColumnType("int");
            Property(x => x.TargetingValue).HasColumnName("TargetingValue").IsOptional().HasColumnType("bigint");
            Property(x => x.TargetingString).HasColumnName("TargetingString").IsOptional().HasColumnType("nvarchar").HasMaxLength(255);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupVertical
    internal partial class AdGroupVerticalMap : EntityTypeConfiguration<AdGroupVertical>
    {
        public AdGroupVerticalMap()
            : this("dbo")
        {
        }
 
        public AdGroupVerticalMap(string schema)
        {
            ToTable(schema + ".AdGroupVertical");
            HasKey(x => new { x.AdGroupId, x.VerticalId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.VerticalId).HasColumnName("VerticalID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupVerticals).HasForeignKey(c => c.AdGroupId); // FK_AdGroupVertical_AdGroup
            HasRequired(a => a.TargetingAction).WithMany(b => b.AdGroupVerticals).HasForeignKey(c => c.TargetingActionId); // FK_AdGroupVertical_TargetingAction
            HasRequired(a => a.Vertical).WithMany(b => b.AdGroupVerticals).HasForeignKey(c => c.VerticalId); // FK_AdGroupVertical_Vertical
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupVerticalBeforeMigration
    internal partial class AdGroupVerticalBeforeMigrationMap : EntityTypeConfiguration<AdGroupVerticalBeforeMigration>
    {
        public AdGroupVerticalBeforeMigrationMap()
            : this("dbo")
        {
        }
 
        public AdGroupVerticalBeforeMigrationMap(string schema)
        {
            ToTable(schema + ".AdGroupVerticalBeforeMigration");
            HasKey(x => new { x.AdGroupId, x.VerticalId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.VerticalId).HasColumnName("VerticalID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.AdGroupVerticalBeforeMigrations).HasForeignKey(c => c.AdGroupId); // FK_AdGroupVerticalBeforeMigration_AdGroup
            HasRequired(a => a.TargetingAction).WithMany(b => b.AdGroupVerticalBeforeMigrations).HasForeignKey(c => c.TargetingActionId); // FK_AdGroupVerticalBeforeMigration_TargetingAction
            HasRequired(a => a.Vertical).WithMany(b => b.AdGroupVerticalBeforeMigrations).HasForeignKey(c => c.VerticalId); // FK_AdGroupVerticalBeforeMigration_Vertical
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupVerticalMappingMigrationLog
    internal partial class AdGroupVerticalMappingMigrationLogMap : EntityTypeConfiguration<AdGroupVerticalMappingMigrationLog>
    {
        public AdGroupVerticalMappingMigrationLogMap()
            : this("dbo")
        {
        }
 
        public AdGroupVerticalMappingMigrationLogMap(string schema)
        {
            ToTable(schema + ".AdGroupVerticalMappingMigrationLog");
            HasKey(x => x.AdGroupId);

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.UserId).HasColumnName("UserID").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.MigratedDateTime).HasColumnName("MigratedDateTime").IsRequired().HasColumnType("datetime");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupVerticalTargetingMigration
    internal partial class AdGroupVerticalTargetingMigrationMap : EntityTypeConfiguration<AdGroupVerticalTargetingMigration>
    {
        public AdGroupVerticalTargetingMigrationMap()
            : this("dbo")
        {
        }
 
        public AdGroupVerticalTargetingMigrationMap(string schema)
        {
            ToTable(schema + ".AdGroupVerticalTargetingMigration");
            HasKey(x => new { x.CampaignId, x.CampaignName, x.BuyerAccountId, x.AdGroupId, x.AdGroupName, x.HasMappedVertical });

            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int");
            Property(x => x.CampaignName).HasColumnName("CampaignName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupName).HasColumnName("AdGroupName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.FromVerticalId).HasColumnName("FromVerticalID").IsOptional().HasColumnType("int");
            Property(x => x.FromVerticalName).HasColumnName("FromVerticalName").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.FromVerticalPath).HasColumnName("FromVerticalPath").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.ToVerticalId).HasColumnName("ToVerticalID").IsOptional().HasColumnType("int");
            Property(x => x.ToVerticalName).HasColumnName("ToVerticalName").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.ToVerticalPath).HasColumnName("ToVerticalPath").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.HasMappedVertical).HasColumnName("HasMappedVertical").IsRequired().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupVerticalTargetingView
    internal partial class AdGroupVerticalTargetingViewMap : EntityTypeConfiguration<AdGroupVerticalTargetingView>
    {
        public AdGroupVerticalTargetingViewMap()
            : this("dbo")
        {
        }
 
        public AdGroupVerticalTargetingViewMap(string schema)
        {
            ToTable(schema + ".AdGroupVerticalTargetingView");
            HasKey(x => new { x.AdGroupId, x.TargetingAttributeTypeId, x.TargetingActionId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.TargetingAttributeTypeId).HasColumnName("TargetingAttributeTypeID").IsRequired().HasColumnType("int");
            Property(x => x.TargetingValue).HasColumnName("TargetingValue").IsOptional().HasColumnType("bigint");
            Property(x => x.TargetingString).HasColumnName("TargetingString").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdGroupWithBrandSafety
    internal partial class AdGroupWithBrandSafetyMap : EntityTypeConfiguration<AdGroupWithBrandSafety>
    {
        public AdGroupWithBrandSafetyMap()
            : this("dbo")
        {
        }
 
        public AdGroupWithBrandSafetyMap(string schema)
        {
            ToTable(schema + ".AdGroupWithBrandSafety");
            HasKey(x => x.AdGroupId);

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdSlot
    internal partial class AdSlotMap : EntityTypeConfiguration<AdSlot>
    {
        public AdSlotMap()
            : this("dbo")
        {
        }
 
        public AdSlotMap(string schema)
        {
            ToTable(schema + ".AdSlot");
            HasKey(x => x.AdSlotId);

            Property(x => x.AdSlotId).HasColumnName("AdSlotID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.AdSlotName).HasColumnName("AdSlotName").IsRequired().HasColumnType("nvarchar").HasMaxLength(255);
            Property(x => x.EstimatedDailyImpressions).HasColumnName("EstimatedDailyImpressions").IsOptional().HasColumnType("bigint");
            Property(x => x.CreativeSizeId).HasColumnName("CreativeSizeID").IsRequired().HasColumnType("int");
            Property(x => x.PagePositionId).HasColumnName("PagePositionID").IsRequired().HasColumnType("int");
            Property(x => x.ExpandableDirectionId).HasColumnName("ExpandableDirectionID").IsRequired().HasColumnType("int");
            Property(x => x.DefaultAdTag).HasColumnName("DefaultAdTag").IsOptional().HasColumnType("nvarchar");
            Property(x => x.DealId).HasColumnName("DealID").IsRequired().HasColumnType("int");
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");

            // Foreign keys
            HasRequired(a => a.CreativeSize).WithMany(b => b.AdSlots).HasForeignKey(c => c.CreativeSizeId); // FK_AdSlot_CreativeSize
            HasRequired(a => a.Deal).WithMany(b => b.AdSlots).HasForeignKey(c => c.DealId); // FK_AdSlot_Deal
            HasRequired(a => a.ExpandableDirection).WithMany(b => b.AdSlots).HasForeignKey(c => c.ExpandableDirectionId); // FK_AdSlot_ExpandableDirection
            HasRequired(a => a.PagePosition).WithMany(b => b.AdSlots).HasForeignKey(c => c.PagePositionId); // FK_AdSlot_PagePosition
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdTagServer
    internal partial class AdTagServerMap : EntityTypeConfiguration<AdTagServer>
    {
        public AdTagServerMap()
            : this("dbo")
        {
        }
 
        public AdTagServerMap(string schema)
        {
            ToTable(schema + ".AdTagServer");
            HasKey(x => x.AdTagServerId);

            Property(x => x.AdTagServerId).HasColumnName("AdTagServerID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdTagServerName).HasColumnName("AdTagServerName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.Position).HasColumnName("Position").IsOptional().HasColumnType("int");
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType("bit");
            Property(x => x.SupportsUpload).HasColumnName("SupportsUpload").IsRequired().HasColumnType("bit");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdTagTemplate
    internal partial class AdTagTemplateMap : EntityTypeConfiguration<AdTagTemplate>
    {
        public AdTagTemplateMap()
            : this("dbo")
        {
        }
 
        public AdTagTemplateMap(string schema)
        {
            ToTable(schema + ".AdTagTemplate");
            HasKey(x => x.AdTagTemplateId);

            Property(x => x.AdTagTemplateId).HasColumnName("AdTagTemplateID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdTagTemplateName).HasColumnName("AdTagTemplateName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.Position).HasColumnName("Position").IsOptional().HasColumnType("int");
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType("bit");
            Property(x => x.CreativeVendorId).HasColumnName("CreativeVendorID").IsRequired().HasColumnType("int");
            Property(x => x.TemplatePath).HasColumnName("TemplatePath").IsRequired().HasColumnType("nvarchar").HasMaxLength(1000);
            Property(x => x.ParseRegEx).HasColumnName("ParseRegEx").IsRequired().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.AdTagServerId).HasColumnName("AdTagServerID").IsRequired().HasColumnType("int");
            Property(x => x.CreativeTypeId).HasColumnName("CreativeTypeID").IsRequired().HasColumnType("int");
            Property(x => x.IsPublic).HasColumnName("IsPublic").IsRequired().HasColumnType("bit");
            Property(x => x.SupportSsl).HasColumnName("SupportSsl").IsRequired().HasColumnType("bit");
            Property(x => x.MediaTypeId).HasColumnName("MediaTypeID").IsRequired().HasColumnType("int");
            Property(x => x.IsExpandable).HasColumnName("IsExpandable").IsRequired().HasColumnType("bit");

            // Foreign keys
            HasRequired(a => a.AdTagServer).WithMany(b => b.AdTagTemplates).HasForeignKey(c => c.AdTagServerId); // FK_AdTagTemplate_AdTagServer
            HasRequired(a => a.CreativeType).WithMany(b => b.AdTagTemplates).HasForeignKey(c => c.CreativeTypeId); // FK_AdTagTemplate_CreativeTypeID
            HasRequired(a => a.MediaType).WithMany(b => b.AdTagTemplates).HasForeignKey(c => c.MediaTypeId); // FK_AdTagTemplate_MediaType
            HasMany(t => t.BuyerAccounts).WithMany(t => t.AdTagTemplates).Map(m => 
            {
                m.ToTable("BuyerAccountAdTagTemplate", "dbo");
                m.MapLeftKey("AdTagTemplateID");
                m.MapRightKey("BuyerAccountID");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Advertiser
    internal partial class AdvertiserMap : EntityTypeConfiguration<Advertiser>
    {
        public AdvertiserMap()
            : this("dbo")
        {
        }
 
        public AdvertiserMap(string schema)
        {
            ToTable(schema + ".Advertiser");
            HasKey(x => x.AdvertiserId);

            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.AdvertiserUuid).HasColumnName("AdvertiserUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.AdvertiserName).HasColumnName("AdvertiserName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.AdvertiserHomepageUrl).HasColumnName("AdvertiserHomepageUrl").IsOptional().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.IndustryCategoryId).HasColumnName("IndustryCategoryID").IsRequired().HasColumnType("int");
            Property(x => x.AdTagServerId).HasColumnName("AdTagServerID").IsRequired().HasColumnType("int");
            Property(x => x.PixelTagServerId).HasColumnName("PixelTagServerID").IsRequired().HasColumnType("int");
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");

            // Foreign keys
            HasRequired(a => a.AdTagServer).WithMany(b => b.Advertisers).HasForeignKey(c => c.AdTagServerId); // FK_Advertiser_AdTagServer
            HasRequired(a => a.BuyerAccount).WithMany(b => b.Advertisers).HasForeignKey(c => c.BuyerAccountId); // FK_Advertiser_BuyerAccount
            HasRequired(a => a.IndustryCategory).WithMany(b => b.Advertisers).HasForeignKey(c => c.IndustryCategoryId); // FK_Advertiser_IndustryCategory
            HasRequired(a => a.PixelTagServer).WithMany(b => b.Advertisers).HasForeignKey(c => c.PixelTagServerId); // FK_Advertiser_PixelTagServer
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdvertiserApplicationParameter
    internal partial class AdvertiserApplicationParameterMap : EntityTypeConfiguration<AdvertiserApplicationParameter>
    {
        public AdvertiserApplicationParameterMap()
            : this("dbo")
        {
        }
 
        public AdvertiserApplicationParameterMap(string schema)
        {
            ToTable(schema + ".AdvertiserApplicationParameter");
            HasKey(x => new { x.AdvertiserId, x.PackageKey, x.Key });

            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.PackageKey).HasColumnName("PackageKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Key).HasColumnName("Key").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Value).HasColumnName("Value").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);

            // Foreign keys
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdvertiserBlackListChangeLog
    internal partial class AdvertiserBlackListChangeLogMap : EntityTypeConfiguration<AdvertiserBlackListChangeLog>
    {
        public AdvertiserBlackListChangeLogMap()
            : this("dbo")
        {
        }
 
        public AdvertiserBlackListChangeLogMap(string schema)
        {
            ToTable(schema + ".AdvertiserBlackListChangeLog");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("ID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsRequired().HasColumnType("int");
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("bigint");
            Property(x => x.WebsiteUrl).HasColumnName("WebsiteUrl").IsRequired().HasColumnType("nvarchar").HasMaxLength(450);
            Property(x => x.Operation).HasColumnName("Operation").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UserId).HasColumnName("UserID").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.ActualUserId).HasColumnName("ActualUserID").IsOptional().HasColumnType("uniqueidentifier");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdvertiserBlackListWebsite
    internal partial class AdvertiserBlackListWebsiteMap : EntityTypeConfiguration<AdvertiserBlackListWebsite>
    {
        public AdvertiserBlackListWebsiteMap()
            : this("dbo")
        {
        }
 
        public AdvertiserBlackListWebsiteMap(string schema)
        {
            ToTable(schema + ".AdvertiserBlackListWebsite");
            HasKey(x => new { x.AdvertiserId, x.WebsiteId });

            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.WebsiteUrl).HasColumnName("WebsiteUrl").IsRequired().HasColumnType("nvarchar").HasMaxLength(450);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdvertiserBrandSafety
    internal partial class AdvertiserBrandSafetyMap : EntityTypeConfiguration<AdvertiserBrandSafety>
    {
        public AdvertiserBrandSafetyMap()
            : this("dbo")
        {
        }
 
        public AdvertiserBrandSafetyMap(string schema)
        {
            ToTable(schema + ".AdvertiserBrandSafety");
            HasKey(x => new { x.BrandSafetyTypeId, x.AdvertiserId, x.BrandSafetyProviderId });

            Property(x => x.BrandSafetyTypeId).HasColumnName("BrandSafetyTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            Property(x => x.BrandSafetyProviderId).HasColumnName("BrandSafetyProviderID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.Advertiser).WithMany(b => b.AdvertiserBrandSafeties).HasForeignKey(c => c.AdvertiserId); // FK_AdvertiserBrandSafety_New_Advertiser
            HasRequired(a => a.BrandSafetyType).WithMany(b => b.AdvertiserBrandSafeties).HasForeignKey(c => c.BrandSafetyTypeId); // FK_AdvertiserBrandSafety_New_BrandSafety
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdvertiserBrandSafety_Backup
    internal partial class AdvertiserBrandSafetyBackupMap : EntityTypeConfiguration<AdvertiserBrandSafetyBackup>
    {
        public AdvertiserBrandSafetyBackupMap()
            : this("dbo")
        {
        }
 
        public AdvertiserBrandSafetyBackupMap(string schema)
        {
            ToTable(schema + ".AdvertiserBrandSafety_Backup");
            HasKey(x => new { x.BrandSafetyTypeId, x.AdvertiserId });

            Property(x => x.BrandSafetyTypeId).HasColumnName("BrandSafetyTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            Property(x => x.BrandSafetyProviderId).HasColumnName("BrandSafetyProviderID").IsOptional().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.Advertiser).WithMany(b => b.AdvertiserBrandSafetyBackups).HasForeignKey(c => c.AdvertiserId); // FK_AdvertiserBrandSafety_Advertiser
            HasRequired(a => a.BrandSafetyType).WithMany(b => b.AdvertiserBrandSafetyBackups).HasForeignKey(c => c.BrandSafetyTypeId); // FK_AdvertiserBrandSafety_BrandSafety
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdvertiserDomainList
    internal partial class AdvertiserDomainListMap : EntityTypeConfiguration<AdvertiserDomainList>
    {
        public AdvertiserDomainListMap()
            : this("dbo")
        {
        }
 
        public AdvertiserDomainListMap(string schema)
        {
            ToTable(schema + ".AdvertiserDomainList");
            HasKey(x => new { x.DomainListId, x.AdvertiserId });

            Property(x => x.DomainListId).HasColumnName("DomainListID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.Advertiser).WithMany(b => b.AdvertiserDomainLists).HasForeignKey(c => c.AdvertiserId); // FK_AdvertiserDomainList_Advertiser
            HasRequired(a => a.DomainList).WithMany(b => b.AdvertiserDomainLists).HasForeignKey(c => c.DomainListId); // FK_AdvertiserDomainList_DomainList
            HasRequired(a => a.TargetingAction).WithMany(b => b.AdvertiserDomainLists).HasForeignKey(c => c.TargetingActionId); // FK_AdvertiserDomainList_TargetingAction
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdvertiserPerformance
    internal partial class AdvertiserPerformanceMap : EntityTypeConfiguration<AdvertiserPerformance>
    {
        public AdvertiserPerformanceMap()
            : this("dbo")
        {
        }
 
        public AdvertiserPerformanceMap(string schema)
        {
            ToTable(schema + ".AdvertiserPerformance");
            HasKey(x => new { x.AdvertiserId, x.IntervalId, x.IntervalValue });

            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalId).HasColumnName("IntervalID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalValue).HasColumnName("IntervalValue").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Bids).HasColumnName("Bids").IsRequired().HasColumnType("bigint");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Clicks).HasColumnName("Clicks").IsRequired().HasColumnType("bigint");
            Property(x => x.Conversions).HasColumnName("Conversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostViewConversions).HasColumnName("PostViewConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostClickConversions).HasColumnName("PostClickConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.LastActivityTimestamp).HasColumnName("LastActivityTimestamp").IsOptional().HasColumnType("datetime");
            Property(x => x.Ctr).HasColumnName("CTR").IsOptional().HasColumnType("float").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaCostLocalMicros).HasColumnName("MediaCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataCostLocalMicros).HasColumnName("DataCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.SpendLocalMicros).HasColumnName("SpendLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaClientCostLocalMicros).HasColumnName("MediaClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataClientCostLocalMicros).HasColumnName("DataClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.ClientCostLocalMicros).HasColumnName("ClientCostLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpm).HasColumnName("CPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpc).HasColumnName("CPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpa).HasColumnName("CPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpm).HasColumnName("ClientCostCPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpc).HasColumnName("ClientCostCPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpa).HasColumnName("ClientCostCPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Spend).HasColumnName("Spend").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cvr).HasColumnName("Cvr").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.BidWin).HasColumnName("BidWin").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.AdSlotDurationInSeconds).HasColumnName("AdSlotDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.RawViews).HasColumnName("RawViews").IsRequired().HasColumnType("bigint");
            Property(x => x.IabViews).HasColumnName("IabViews").IsRequired().HasColumnType("bigint");
            Property(x => x.ViewDurationInSeconds).HasColumnName("ViewDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.CpMs).HasColumnName("CPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpMs).HasColumnName("ClientCostCPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cps).HasColumnName("CPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCps).HasColumnName("ClientCostCPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ViewableRatio).HasColumnName("ViewableRatio").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            // Foreign keys
            HasRequired(a => a.Advertiser).WithMany(b => b.AdvertiserPerformances).HasForeignKey(c => c.AdvertiserId); // FK_AdvertiserPerformance_Advertiser
            HasRequired(a => a.Interval).WithMany(b => b.AdvertiserPerformances).HasForeignKey(c => c.IntervalId); // FK_AdvertiserPerformance_Interval
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdvertiserProduct
    internal partial class AdvertiserProductMap : EntityTypeConfiguration<AdvertiserProduct>
    {
        public AdvertiserProductMap()
            : this("dbo")
        {
        }
 
        public AdvertiserProductMap(string schema)
        {
            ToTable(schema + ".AdvertiserProduct");
            HasKey(x => x.AdvertiserProductId);

            Property(x => x.AdvertiserProductId).HasColumnName("AdvertiserProductID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.AdvertiserProductUuid).HasColumnName("AdvertiserProductUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.ProductName).HasColumnName("ProductName").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.ProductCategoryId).HasColumnName("ProductCategoryID").IsOptional().HasColumnType("int");
            Property(x => x.AdvertiserProductHomepageUrl).HasColumnName("AdvertiserProductHomepageUrl").IsOptional().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.SiteListOption).HasColumnName("SiteListOption").IsRequired().HasColumnType("int");
            Property(x => x.BrandSafetyModeId).HasColumnName("BrandSafetyModeID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.ProductCategory).WithMany(b => b.AdvertiserProducts).HasForeignKey(c => c.ProductCategoryId); // FK_AdvertiserProduct_ProductCategory
            HasRequired(a => a.Advertiser).WithMany(b => b.AdvertiserProducts).HasForeignKey(c => c.AdvertiserId); // FK_AdvertiserProduct_Advertiser
            HasRequired(a => a.BrandSafetyMode).WithMany(b => b.AdvertiserProducts).HasForeignKey(c => c.BrandSafetyModeId); // FK_AdvertiserProduct_BrandSafetyModeID
            HasRequired(a => a.BuyerAccount).WithMany(b => b.AdvertiserProducts).HasForeignKey(c => c.BuyerAccountId); // FK_AdvertiserProduct_BuyerAccount
            HasMany(t => t.CustomWhiteLists).WithMany(t => t.AdvertiserProducts).Map(m => 
            {
                m.ToTable("AdvertiserProductCustomWhiteList", "dbo");
                m.MapLeftKey("AdvertiserProductID");
                m.MapRightKey("ListID");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdvertiserProductBrandSafety
    internal partial class AdvertiserProductBrandSafetyMap : EntityTypeConfiguration<AdvertiserProductBrandSafety>
    {
        public AdvertiserProductBrandSafetyMap()
            : this("dbo")
        {
        }
 
        public AdvertiserProductBrandSafetyMap(string schema)
        {
            ToTable(schema + ".AdvertiserProductBrandSafety");
            HasKey(x => new { x.BrandSafetyTypeId, x.AdvertiserProductId, x.BrandSafetyProviderId });

            Property(x => x.BrandSafetyTypeId).HasColumnName("BrandSafetyTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdvertiserProductId).HasColumnName("AdvertiserProductID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            Property(x => x.BrandSafetyProviderId).HasColumnName("BrandSafetyProviderID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.AdvertiserProduct).WithMany(b => b.AdvertiserProductBrandSafeties).HasForeignKey(c => c.AdvertiserProductId); // FK_AdvertiserProductBrandSafety_New_AdvertiserProduct
            HasRequired(a => a.BrandSafetyType).WithMany(b => b.AdvertiserProductBrandSafeties).HasForeignKey(c => c.BrandSafetyTypeId); // FK_AdvertiserProductBrandSafety_New_BrandSafety
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdvertiserProductBrandSafety_Backup
    internal partial class AdvertiserProductBrandSafetyBackupMap : EntityTypeConfiguration<AdvertiserProductBrandSafetyBackup>
    {
        public AdvertiserProductBrandSafetyBackupMap()
            : this("dbo")
        {
        }
 
        public AdvertiserProductBrandSafetyBackupMap(string schema)
        {
            ToTable(schema + ".AdvertiserProductBrandSafety_Backup");
            HasKey(x => new { x.BrandSafetyTypeId, x.AdvertiserProductId });

            Property(x => x.BrandSafetyTypeId).HasColumnName("BrandSafetyTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdvertiserProductId).HasColumnName("AdvertiserProductID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            Property(x => x.BrandSafetyProviderId).HasColumnName("BrandSafetyProviderID").IsOptional().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdvertiserProduct).WithMany(b => b.AdvertiserProductBrandSafetyBackups).HasForeignKey(c => c.AdvertiserProductId); // FK_AdvertiserProductBrandSafety_AdvertiserProduct
            HasRequired(a => a.BrandSafetyType).WithMany(b => b.AdvertiserProductBrandSafetyBackups).HasForeignKey(c => c.BrandSafetyTypeId); // FK_AdvertiserProductBrandSafety_BrandSafety
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdvertiserProductDomainList
    internal partial class AdvertiserProductDomainListMap : EntityTypeConfiguration<AdvertiserProductDomainList>
    {
        public AdvertiserProductDomainListMap()
            : this("dbo")
        {
        }
 
        public AdvertiserProductDomainListMap(string schema)
        {
            ToTable(schema + ".AdvertiserProductDomainList");
            HasKey(x => new { x.DomainListId, x.AdvertiserProductId });

            Property(x => x.DomainListId).HasColumnName("DomainListID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdvertiserProductId).HasColumnName("AdvertiserProductID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdvertiserProduct).WithMany(b => b.AdvertiserProductDomainLists).HasForeignKey(c => c.AdvertiserProductId); // FK_AdvertiserProductDomainList_AdvertiserProduct
            HasRequired(a => a.DomainList).WithMany(b => b.AdvertiserProductDomainLists).HasForeignKey(c => c.DomainListId); // FK_AdvertiserProductDomainList_DomainList
            HasRequired(a => a.TargetingAction).WithMany(b => b.AdvertiserProductDomainLists).HasForeignKey(c => c.TargetingActionId); // FK_AdvertiserProductDomainList_TargetingAction
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdvertiserProductPerformance
    internal partial class AdvertiserProductPerformanceMap : EntityTypeConfiguration<AdvertiserProductPerformance>
    {
        public AdvertiserProductPerformanceMap()
            : this("dbo")
        {
        }
 
        public AdvertiserProductPerformanceMap(string schema)
        {
            ToTable(schema + ".AdvertiserProductPerformance");
            HasKey(x => new { x.AdvertiserProductId, x.IntervalId, x.IntervalValue });

            Property(x => x.AdvertiserProductId).HasColumnName("AdvertiserProductID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalId).HasColumnName("IntervalID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalValue).HasColumnName("IntervalValue").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Bids).HasColumnName("Bids").IsRequired().HasColumnType("bigint");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Clicks).HasColumnName("Clicks").IsRequired().HasColumnType("bigint");
            Property(x => x.Conversions).HasColumnName("Conversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostViewConversions).HasColumnName("PostViewConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostClickConversions).HasColumnName("PostClickConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.LastActivityTimestamp).HasColumnName("LastActivityTimestamp").IsOptional().HasColumnType("datetime");
            Property(x => x.Ctr).HasColumnName("CTR").IsOptional().HasColumnType("float").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaCostLocalMicros).HasColumnName("MediaCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataCostLocalMicros).HasColumnName("DataCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.SpendLocalMicros).HasColumnName("SpendLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaClientCostLocalMicros).HasColumnName("MediaClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataClientCostLocalMicros).HasColumnName("DataClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.ClientCostLocalMicros).HasColumnName("ClientCostLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpm).HasColumnName("CPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpc).HasColumnName("CPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpa).HasColumnName("CPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpm).HasColumnName("ClientCostCPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpc).HasColumnName("ClientCostCPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpa).HasColumnName("ClientCostCPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Spend).HasColumnName("Spend").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cvr).HasColumnName("Cvr").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.BidWin).HasColumnName("BidWin").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.AdSlotDurationInSeconds).HasColumnName("AdSlotDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.RawViews).HasColumnName("RawViews").IsRequired().HasColumnType("bigint");
            Property(x => x.IabViews).HasColumnName("IabViews").IsRequired().HasColumnType("bigint");
            Property(x => x.ViewDurationInSeconds).HasColumnName("ViewDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.CpMs).HasColumnName("CPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpMs).HasColumnName("ClientCostCPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cps).HasColumnName("CPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCps).HasColumnName("ClientCostCPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ViewableRatio).HasColumnName("ViewableRatio").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            // Foreign keys
            HasRequired(a => a.AdvertiserProduct).WithMany(b => b.AdvertiserProductPerformances).HasForeignKey(c => c.AdvertiserProductId); // FK_AdvertiserProductPerformance_AdvertiserProduct
            HasRequired(a => a.Interval).WithMany(b => b.AdvertiserProductPerformances).HasForeignKey(c => c.IntervalId); // FK_AdvertiserProductPerformance_Interval
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AdvertiserReview
    internal partial class AdvertiserReviewMap : EntityTypeConfiguration<AdvertiserReview>
    {
        public AdvertiserReviewMap()
            : this("dbo")
        {
        }
 
        public AdvertiserReviewMap(string schema)
        {
            ToTable(schema + ".AdvertiserReview");
            HasKey(x => new { x.AdvertiserId, x.PartnerId });

            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdvertiserReviewStatusId).HasColumnName("AdvertiserReviewStatusID").IsRequired().HasColumnType("int");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");

            // Foreign keys
            HasRequired(a => a.CreativeReviewStatus).WithMany(b => b.AdvertiserReviews).HasForeignKey(c => c.AdvertiserReviewStatusId); // FK_AdvertiserReview_CreativeReviewStatus
            HasRequired(a => a.Partner).WithMany(b => b.AdvertiserReviews).HasForeignKey(c => c.PartnerId); // FK_AdvertiserReview_Partner
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AttributionCountingMode
    internal partial class AttributionCountingModeMap : EntityTypeConfiguration<AttributionCountingMode>
    {
        public AttributionCountingModeMap()
            : this("dbo")
        {
        }
 
        public AttributionCountingModeMap(string schema)
        {
            ToTable(schema + ".AttributionCountingMode");
            HasKey(x => x.AttributionCountingModeId);

            Property(x => x.AttributionCountingModeId).HasColumnName("AttributionCountingModeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AttributionCountingModeName).HasColumnName("AttributionCountingModeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.AttributionWindowInMinutes).HasColumnName("AttributionWindowInMinutes").IsRequired().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // AttributionModel
    internal partial class AttributionModelMap : EntityTypeConfiguration<AttributionModel>
    {
        public AttributionModelMap()
            : this("dbo")
        {
        }
 
        public AttributionModelMap(string schema)
        {
            ToTable(schema + ".AttributionModel");
            HasKey(x => x.AttributionModelId);

            Property(x => x.AttributionModelId).HasColumnName("AttributionModelID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AttributionModelName).HasColumnName("AttributionModelName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BaiduSegments
    internal partial class BaiduSegmentMap : EntityTypeConfiguration<BaiduSegment>
    {
        public BaiduSegmentMap()
            : this("dbo")
        {
        }
 
        public BaiduSegmentMap(string schema)
        {
            ToTable(schema + ".BaiduSegments");
            HasKey(x => x.RtbSegmentId);

            Property(x => x.RtbSegmentId).HasColumnName("RtbSegmentID").IsRequired().HasColumnType("nvarchar").HasMaxLength(40).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Bids).HasColumnName("Bids").IsRequired().HasColumnType("bigint");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BaiduSegmentsAlternate
    internal partial class BaiduSegmentsAlternateMap : EntityTypeConfiguration<BaiduSegmentsAlternate>
    {
        public BaiduSegmentsAlternateMap()
            : this("dbo")
        {
        }
 
        public BaiduSegmentsAlternateMap(string schema)
        {
            ToTable(schema + ".BaiduSegmentsAlternate");
            HasKey(x => x.RtbSegmentId);

            Property(x => x.RtbSegmentId).HasColumnName("RtbSegmentID").IsRequired().HasColumnType("nvarchar").HasMaxLength(40).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Bids).HasColumnName("Bids").IsRequired().HasColumnType("bigint");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BillingCycle
    internal partial class BillingCycleMap : EntityTypeConfiguration<BillingCycle>
    {
        public BillingCycleMap()
            : this("dbo")
        {
        }
 
        public BillingCycleMap(string schema)
        {
            ToTable(schema + ".BillingCycle");
            HasKey(x => x.BillingCycleId);

            Property(x => x.BillingCycleId).HasColumnName("BillingCycleID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BillingCycleName).HasColumnName("BillingCycleName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BillingPeriod
    internal partial class BillingPeriodMap : EntityTypeConfiguration<BillingPeriod>
    {
        public BillingPeriodMap()
            : this("dbo")
        {
        }
 
        public BillingPeriodMap(string schema)
        {
            ToTable(schema + ".BillingPeriod");
            HasKey(x => x.BillingPeriodId);

            Property(x => x.BillingPeriodId).HasColumnName("BillingPeriodID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BillingCycleId).HasColumnName("BillingCycleID").IsRequired().HasColumnType("int");
            Property(x => x.TimeZoneId).HasColumnName("TimeZoneID").IsRequired().HasColumnType("int");
            Property(x => x.FromDate).HasColumnName("FromDate").IsRequired().HasColumnType("date");
            Property(x => x.ToDate).HasColumnName("ToDate").IsRequired().HasColumnType("date");
            Property(x => x.IsClosed).HasColumnName("IsClosed").IsRequired().HasColumnType("bit");

            // Foreign keys
            HasRequired(a => a.BillingCycle).WithMany(b => b.BillingPeriods).HasForeignKey(c => c.BillingCycleId); // FK_BillingPeriod_BillingCycle
            HasRequired(a => a.TimeZone).WithMany(b => b.BillingPeriods).HasForeignKey(c => c.TimeZoneId); // FK_BillingPeriod_TimeZone
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BillingType
    internal partial class BillingTypeMap : EntityTypeConfiguration<BillingType>
    {
        public BillingTypeMap()
            : this("dbo")
        {
        }
 
        public BillingTypeMap(string schema)
        {
            ToTable(schema + ".BillingType");
            HasKey(x => x.BillingTypeId);

            Property(x => x.BillingTypeId).HasColumnName("BillingTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BillingTypeName).HasColumnName("BillingTypeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialGlobalBlackList
    internal partial class BinomialGlobalBlackListMap : EntityTypeConfiguration<BinomialGlobalBlackList>
    {
        public BinomialGlobalBlackListMap()
            : this("dbo")
        {
        }
 
        public BinomialGlobalBlackListMap(string schema)
        {
            ToTable(schema + ".BinomialGlobalBlackList");
            HasKey(x => new { x.GoalTypeId, x.BuyerId, x.PartnerId, x.PublisherId, x.WebsiteId, x.InventoryId });

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerId).HasColumnName("BuyerID").IsRequired().HasColumnType("int");
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int");
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("int");
            Property(x => x.InventoryId).HasColumnName("InventoryID").IsRequired().HasColumnType("bigint");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialGlobalBlackListOverride
    internal partial class BinomialGlobalBlackListOverrideMap : EntityTypeConfiguration<BinomialGlobalBlackListOverride>
    {
        public BinomialGlobalBlackListOverrideMap()
            : this("dbo")
        {
        }
 
        public BinomialGlobalBlackListOverrideMap(string schema)
        {
            ToTable(schema + ".BinomialGlobalBlackListOverride");
            HasKey(x => new { x.AdGroupId, x.PartnerId, x.PublisherId, x.WebsiteId });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int");
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("bigint");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialGlobalDomainBlackList
    internal partial class BinomialGlobalDomainBlackListMap : EntityTypeConfiguration<BinomialGlobalDomainBlackList>
    {
        public BinomialGlobalDomainBlackListMap()
            : this("dbo")
        {
        }
 
        public BinomialGlobalDomainBlackListMap(string schema)
        {
            ToTable(schema + ".BinomialGlobalDomainBlackList");
            HasKey(x => new { x.GoalTypeId, x.BuyerId, x.DomainName });

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerId).HasColumnName("BuyerID").IsRequired().HasColumnType("int");
            Property(x => x.DomainName).HasColumnName("DomainName").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(64);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialGlobalDomainBlackListOverride
    internal partial class BinomialGlobalDomainBlackListOverrideMap : EntityTypeConfiguration<BinomialGlobalDomainBlackListOverride>
    {
        public BinomialGlobalDomainBlackListOverrideMap()
            : this("dbo")
        {
        }
 
        public BinomialGlobalDomainBlackListOverrideMap(string schema)
        {
            ToTable(schema + ".BinomialGlobalDomainBlackListOverride");
            HasKey(x => new { x.AdGroupId, x.DomainName });

            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.DomainName).HasColumnName("DomainName").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(64);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialGlobalDomainFilter
    internal partial class BinomialGlobalDomainFilterMap : EntityTypeConfiguration<BinomialGlobalDomainFilter>
    {
        public BinomialGlobalDomainFilterMap()
            : this("dbo")
        {
        }
 
        public BinomialGlobalDomainFilterMap(string schema)
        {
            ToTable(schema + ".BinomialGlobalDomainFilter");
            HasKey(x => x.BinomialGlobalDomainFilterId);

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerId).HasColumnName("BuyerID").IsRequired().HasColumnType("int");
            Property(x => x.DomainName).HasColumnName("DomainName").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(64);
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Actions).HasColumnName("Actions").IsRequired().HasColumnType("bigint");
            Property(x => x.BetaBinomialCdf).HasColumnName("BetaBinomialCDF").IsRequired().HasColumnType("float");
            Property(x => x.BinomialGlobalDomainFilterId).HasColumnName("BinomialGlobalDomainFilterID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialGlobalDomainFilterAlternate
    internal partial class BinomialGlobalDomainFilterAlternateMap : EntityTypeConfiguration<BinomialGlobalDomainFilterAlternate>
    {
        public BinomialGlobalDomainFilterAlternateMap()
            : this("dbo")
        {
        }
 
        public BinomialGlobalDomainFilterAlternateMap(string schema)
        {
            ToTable(schema + ".BinomialGlobalDomainFilterAlternate");
            HasKey(x => x.BinomialGlobalDomainFilterAlternateId);

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerId).HasColumnName("BuyerID").IsRequired().HasColumnType("int");
            Property(x => x.DomainName).HasColumnName("DomainName").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(64);
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Actions).HasColumnName("Actions").IsRequired().HasColumnType("bigint");
            Property(x => x.BetaBinomialCdf).HasColumnName("BetaBinomialCDF").IsRequired().HasColumnType("float");
            Property(x => x.BinomialGlobalDomainFilterAlternateId).HasColumnName("BinomialGlobalDomainFilterAlternateID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialGlobalDomainFilterImport
    internal partial class BinomialGlobalDomainFilterImportMap : EntityTypeConfiguration<BinomialGlobalDomainFilterImport>
    {
        public BinomialGlobalDomainFilterImportMap()
            : this("dbo")
        {
        }
 
        public BinomialGlobalDomainFilterImportMap(string schema)
        {
            ToTable(schema + ".BinomialGlobalDomainFilterImport");
            HasKey(x => x.BinomialGlobalDomainFilterImportId);

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerId).HasColumnName("BuyerID").IsRequired().HasColumnType("int");
            Property(x => x.DomainName).HasColumnName("DomainName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Actions).HasColumnName("Actions").IsRequired().HasColumnType("bigint");
            Property(x => x.BetaBinomialCdf).HasColumnName("BetaBinomialCDF").IsRequired().HasColumnType("float");
            Property(x => x.BinomialGlobalDomainFilterImportId).HasColumnName("BinomialGlobalDomainFilterImportID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialGlobalFilter
    internal partial class BinomialGlobalFilterMap : EntityTypeConfiguration<BinomialGlobalFilter>
    {
        public BinomialGlobalFilterMap()
            : this("dbo")
        {
        }
 
        public BinomialGlobalFilterMap(string schema)
        {
            ToTable(schema + ".BinomialGlobalFilter");
            HasKey(x => x.BinomialGlobalFilterId);

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerId).HasColumnName("BuyerID").IsRequired().HasColumnType("int");
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int");
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("int");
            Property(x => x.InventoryId).HasColumnName("InventoryID").IsRequired().HasColumnType("bigint");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Actions).HasColumnName("Actions").IsRequired().HasColumnType("bigint");
            Property(x => x.BetaBinomialCdf).HasColumnName("BetaBinomialCDF").IsRequired().HasColumnType("float");
            Property(x => x.BinomialGlobalFilterId).HasColumnName("BinomialGlobalFilterID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialGlobalFilterAlternate
    internal partial class BinomialGlobalFilterAlternateMap : EntityTypeConfiguration<BinomialGlobalFilterAlternate>
    {
        public BinomialGlobalFilterAlternateMap()
            : this("dbo")
        {
        }
 
        public BinomialGlobalFilterAlternateMap(string schema)
        {
            ToTable(schema + ".BinomialGlobalFilterAlternate");
            HasKey(x => x.BinomialGlobalFilterAlternateId);

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerId).HasColumnName("BuyerID").IsRequired().HasColumnType("int");
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int");
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("int");
            Property(x => x.InventoryId).HasColumnName("InventoryID").IsRequired().HasColumnType("bigint");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Actions).HasColumnName("Actions").IsRequired().HasColumnType("bigint");
            Property(x => x.BetaBinomialCdf).HasColumnName("BetaBinomialCDF").IsRequired().HasColumnType("float");
            Property(x => x.BinomialGlobalFilterAlternateId).HasColumnName("BinomialGlobalFilterAlternateID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialGlobalFilterImport
    internal partial class BinomialGlobalFilterImportMap : EntityTypeConfiguration<BinomialGlobalFilterImport>
    {
        public BinomialGlobalFilterImportMap()
            : this("dbo")
        {
        }
 
        public BinomialGlobalFilterImportMap(string schema)
        {
            ToTable(schema + ".BinomialGlobalFilterImport");
            HasKey(x => x.BinomialGlobalFilterImportId);

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerId).HasColumnName("BuyerID").IsRequired().HasColumnType("int");
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int");
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("int");
            Property(x => x.InventoryId).HasColumnName("InventoryID").IsRequired().HasColumnType("bigint");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Actions).HasColumnName("Actions").IsRequired().HasColumnType("bigint");
            Property(x => x.BetaBinomialCdf).HasColumnName("BetaBinomialCDF").IsRequired().HasColumnType("float");
            Property(x => x.BinomialGlobalFilterImportId).HasColumnName("BinomialGlobalFilterImportID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialLocalBlackList
    internal partial class BinomialLocalBlackListMap : EntityTypeConfiguration<BinomialLocalBlackList>
    {
        public BinomialLocalBlackListMap()
            : this("dbo")
        {
        }
 
        public BinomialLocalBlackListMap(string schema)
        {
            ToTable(schema + ".BinomialLocalBlackList");
            HasKey(x => new { x.GoalTypeId, x.AdGroupId, x.PartnerId, x.PublisherId, x.WebsiteId, x.InventoryId });

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int");
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("int");
            Property(x => x.InventoryId).HasColumnName("InventoryID").IsRequired().HasColumnType("bigint");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialLocalDomainBlackList
    internal partial class BinomialLocalDomainBlackListMap : EntityTypeConfiguration<BinomialLocalDomainBlackList>
    {
        public BinomialLocalDomainBlackListMap()
            : this("dbo")
        {
        }
 
        public BinomialLocalDomainBlackListMap(string schema)
        {
            ToTable(schema + ".BinomialLocalDomainBlackList");
            HasKey(x => new { x.GoalTypeId, x.AdGroupId, x.DomainName });

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.DomainName).HasColumnName("DomainName").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(64);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialLocalDomainFilter
    internal partial class BinomialLocalDomainFilterMap : EntityTypeConfiguration<BinomialLocalDomainFilter>
    {
        public BinomialLocalDomainFilterMap()
            : this("dbo")
        {
        }
 
        public BinomialLocalDomainFilterMap(string schema)
        {
            ToTable(schema + ".BinomialLocalDomainFilter");
            HasKey(x => x.BinomialLocalDomainFilterId);

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int");
            Property(x => x.DomainName).HasColumnName("DomainName").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(64);
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Actions).HasColumnName("Actions").IsRequired().HasColumnType("bigint");
            Property(x => x.BetaBinomialCdf).HasColumnName("BetaBinomialCDF").IsRequired().HasColumnType("float");
            Property(x => x.BinomialLocalDomainFilterId).HasColumnName("BinomialLocalDomainFilterID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialLocalDomainFilterAlternate
    internal partial class BinomialLocalDomainFilterAlternateMap : EntityTypeConfiguration<BinomialLocalDomainFilterAlternate>
    {
        public BinomialLocalDomainFilterAlternateMap()
            : this("dbo")
        {
        }
 
        public BinomialLocalDomainFilterAlternateMap(string schema)
        {
            ToTable(schema + ".BinomialLocalDomainFilterAlternate");
            HasKey(x => x.BinomialLocalDomainFilterAlternateId);

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int");
            Property(x => x.DomainName).HasColumnName("DomainName").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(64);
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Actions).HasColumnName("Actions").IsRequired().HasColumnType("bigint");
            Property(x => x.BetaBinomialCdf).HasColumnName("BetaBinomialCDF").IsRequired().HasColumnType("float");
            Property(x => x.BinomialLocalDomainFilterAlternateId).HasColumnName("BinomialLocalDomainFilterAlternateID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialLocalDomainFilterImport
    internal partial class BinomialLocalDomainFilterImportMap : EntityTypeConfiguration<BinomialLocalDomainFilterImport>
    {
        public BinomialLocalDomainFilterImportMap()
            : this("dbo")
        {
        }
 
        public BinomialLocalDomainFilterImportMap(string schema)
        {
            ToTable(schema + ".BinomialLocalDomainFilterImport");
            HasKey(x => x.BinomialLocalDomainFilterImportId);

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int");
            Property(x => x.DomainName).HasColumnName("DomainName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Actions).HasColumnName("Actions").IsRequired().HasColumnType("bigint");
            Property(x => x.BetaBinomialCdf).HasColumnName("BetaBinomialCDF").IsRequired().HasColumnType("float");
            Property(x => x.BinomialLocalDomainFilterImportId).HasColumnName("BinomialLocalDomainFilterImportID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialLocalFilter
    internal partial class BinomialLocalFilterMap : EntityTypeConfiguration<BinomialLocalFilter>
    {
        public BinomialLocalFilterMap()
            : this("dbo")
        {
        }
 
        public BinomialLocalFilterMap(string schema)
        {
            ToTable(schema + ".BinomialLocalFilter");
            HasKey(x => x.BinomialLocalFilterId);

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int");
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int");
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("int");
            Property(x => x.InventoryId).HasColumnName("InventoryID").IsRequired().HasColumnType("bigint");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Actions).HasColumnName("Actions").IsRequired().HasColumnType("bigint");
            Property(x => x.BetaBinomialCdf).HasColumnName("BetaBinomialCDF").IsRequired().HasColumnType("float");
            Property(x => x.BinomialLocalFilterId).HasColumnName("BinomialLocalFilterID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialLocalFilterAlternate
    internal partial class BinomialLocalFilterAlternateMap : EntityTypeConfiguration<BinomialLocalFilterAlternate>
    {
        public BinomialLocalFilterAlternateMap()
            : this("dbo")
        {
        }
 
        public BinomialLocalFilterAlternateMap(string schema)
        {
            ToTable(schema + ".BinomialLocalFilterAlternate");
            HasKey(x => x.BinomialLocalFilterAlternateId);

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int");
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int");
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("int");
            Property(x => x.InventoryId).HasColumnName("InventoryID").IsRequired().HasColumnType("bigint");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Actions).HasColumnName("Actions").IsRequired().HasColumnType("bigint");
            Property(x => x.BetaBinomialCdf).HasColumnName("BetaBinomialCDF").IsRequired().HasColumnType("float");
            Property(x => x.BinomialLocalFilterAlternateId).HasColumnName("BinomialLocalFilterAlternateID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BinomialLocalFilterImport
    internal partial class BinomialLocalFilterImportMap : EntityTypeConfiguration<BinomialLocalFilterImport>
    {
        public BinomialLocalFilterImportMap()
            : this("dbo")
        {
        }
 
        public BinomialLocalFilterImportMap(string schema)
        {
            ToTable(schema + ".BinomialLocalFilterImport");
            HasKey(x => x.BinomialLocalFilterImportId);

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int");
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int");
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("int");
            Property(x => x.InventoryId).HasColumnName("InventoryID").IsRequired().HasColumnType("bigint");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Actions).HasColumnName("Actions").IsRequired().HasColumnType("bigint");
            Property(x => x.BetaBinomialCdf).HasColumnName("BetaBinomialCDF").IsRequired().HasColumnType("float");
            Property(x => x.BinomialLocalFilterImportId).HasColumnName("BinomialLocalFilterImportID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BrandSafety
    internal partial class BrandSafetyMap : EntityTypeConfiguration<BrandSafety>
    {
        public BrandSafetyMap()
            : this("dbo")
        {
        }
 
        public BrandSafetyMap(string schema)
        {
            ToTable(schema + ".BrandSafety");
            HasKey(x => new { x.AdvertiserProductId, x.BrandSafetyTypeId });

            Property(x => x.AdvertiserProductId).HasColumnName("AdvertiserProductID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BrandSafetyTypeId).HasColumnName("BrandSafetyTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BrandSafetyLevelId).HasColumnName("BrandSafetyLevelID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdvertiserProduct).WithMany(b => b.BrandSafeties).HasForeignKey(c => c.AdvertiserProductId); // FK_BrandSafety_AdvertiserProduct
            HasRequired(a => a.BrandSafetyLevel).WithMany(b => b.BrandSafeties).HasForeignKey(c => c.BrandSafetyLevelId); // FK_BrandSafety_BrandSafetyLevel
            HasRequired(a => a.BrandSafetyType).WithMany(b => b.BrandSafeties).HasForeignKey(c => c.BrandSafetyTypeId); // FK_BrandSafety_BrandSafetyType
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BrandSafetyChangeLog
    internal partial class BrandSafetyChangeLogMap : EntityTypeConfiguration<BrandSafetyChangeLog>
    {
        public BrandSafetyChangeLogMap()
            : this("dbo")
        {
        }
 
        public BrandSafetyChangeLogMap(string schema)
        {
            ToTable(schema + ".BrandSafetyChangeLog");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("ID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.AdvertiserProductId).HasColumnName("AdvertiserProductID").IsRequired().HasColumnType("int");
            Property(x => x.Operation).HasColumnName("Operation").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.BrandSafetyType).HasColumnName("BrandSafetyType").IsOptional().HasColumnType("int");
            Property(x => x.BrandSafetylevel).HasColumnName("BrandSafetylevel").IsOptional().HasColumnType("int");
            Property(x => x.BrandSafetyEnabled).HasColumnName("BrandSafetyEnabled").IsOptional().HasColumnType("bit");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UserId).HasColumnName("UserID").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.ActualUserId).HasColumnName("ActualUserID").IsOptional().HasColumnType("uniqueidentifier");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BrandSafetyLevel
    internal partial class BrandSafetyLevelMap : EntityTypeConfiguration<BrandSafetyLevel>
    {
        public BrandSafetyLevelMap()
            : this("dbo")
        {
        }
 
        public BrandSafetyLevelMap(string schema)
        {
            ToTable(schema + ".BrandSafetyLevel");
            HasKey(x => x.BrandSafetyLevelId);

            Property(x => x.BrandSafetyLevelId).HasColumnName("BrandSafetyLevelID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BrandSafetyLevelName).HasColumnName("BrandSafetyLevelName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BrandSafetyMode
    internal partial class BrandSafetyModeMap : EntityTypeConfiguration<BrandSafetyMode>
    {
        public BrandSafetyModeMap()
            : this("dbo")
        {
        }
 
        public BrandSafetyModeMap(string schema)
        {
            ToTable(schema + ".BrandSafetyMode");
            HasKey(x => x.BrandSafetyModeId);

            Property(x => x.BrandSafetyModeId).HasColumnName("BrandSafetyModeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BrandSafetyModeName).HasColumnName("BrandSafetyModeName").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BrandSafetyType
    internal partial class BrandSafetyTypeMap : EntityTypeConfiguration<BrandSafetyType>
    {
        public BrandSafetyTypeMap()
            : this("dbo")
        {
        }
 
        public BrandSafetyTypeMap(string schema)
        {
            ToTable(schema + ".BrandSafetyType");
            HasKey(x => x.BrandSafetyTypeId);

            Property(x => x.BrandSafetyTypeId).HasColumnName("BrandSafetyTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BrandSafetyTypeName).HasColumnName("BrandSafetyTypeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccount
    internal partial class BuyerAccountMap : EntityTypeConfiguration<BuyerAccount>
    {
        public BuyerAccountMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountMap(string schema)
        {
            ToTable(schema + ".BuyerAccount");
            HasKey(x => x.BuyerAccountId);

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BuyerAccountUuid).HasColumnName("BuyerAccountUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.CompanyName).HasColumnName("CompanyName").IsOptional().HasColumnType("nvarchar").HasMaxLength(255);
            Property(x => x.BuyingGroupName).HasColumnName("BuyingGroupName").IsOptional().HasColumnType("nvarchar").HasMaxLength(255);
            Property(x => x.AddressLine1).HasColumnName("AddressLine1").IsOptional().HasColumnType("nvarchar").HasMaxLength(300);
            Property(x => x.AddressLine2).HasColumnName("AddressLine2").IsOptional().HasColumnType("nvarchar").HasMaxLength(300);
            Property(x => x.City).HasColumnName("City").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.StateProvince).HasColumnName("StateProvince").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.PostalCode).HasColumnName("PostalCode").IsOptional().HasColumnType("nvarchar").HasMaxLength(20);
            Property(x => x.CountryId).HasColumnName("CountryID").IsOptional().HasColumnType("int");
            Property(x => x.CurrencyId).HasColumnName("CurrencyID").IsOptional().HasColumnType("int");
            Property(x => x.TermsConditionsAgreedDate).HasColumnName("TermsConditionsAgreedDate").IsOptional().HasColumnType("datetime");
            Property(x => x.IsAgent).HasColumnName("IsAgent").IsRequired().HasColumnType("bit");
            Property(x => x.CreditLimit).HasColumnName("CreditLimit").IsRequired().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.TrialEndDate).HasColumnName("TrialEndDate").IsOptional().HasColumnType("datetime");
            Property(x => x.BillingTypeId).HasColumnName("BillingTypeID").IsOptional().HasColumnType("int");
            Property(x => x.TimeZoneId).HasColumnName("TimeZoneID").IsOptional().HasColumnType("int");
            Property(x => x.CommercialContactUserId).HasColumnName("CommercialContactUserID").IsOptional().HasColumnType("uniqueidentifier");
            Property(x => x.PaymentTermsId).HasColumnName("PaymentTermsID").IsOptional().HasColumnType("int");
            Property(x => x.BillingCycleId).HasColumnName("BillingCycleID").IsOptional().HasColumnType("int");
            Property(x => x.Brokerage).HasColumnName("Brokerage").IsRequired().HasColumnType("decimal").HasPrecision(7,4);
            Property(x => x.LanguageId).HasColumnName("LanguageID").IsRequired().HasColumnType("int");
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType("bit");
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.CompanyTypeId).HasColumnName("CompanyTypeID").IsRequired().HasColumnType("int");
            Property(x => x.IsApproved).HasColumnName("IsApproved").IsRequired().HasColumnType("bit");
            Property(x => x.BrandSafetyFee).HasColumnName("BrandSafetyFee").IsRequired().HasColumnType("decimal").HasPrecision(7,4);
            Property(x => x.ServiceFee).HasColumnName("ServiceFee").IsRequired().HasColumnType("decimal").HasPrecision(7,4);
            Property(x => x.ThemeId).HasColumnName("ThemeID").IsOptional().HasColumnType("bigint");
            Property(x => x.Website).HasColumnName("Website").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.MonthlyCreditId).HasColumnName("MonthlyCreditID").IsOptional().HasColumnType("int");
            Property(x => x.BillingContactEmail).HasColumnName("BillingContactEmail").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.ClickFilteringModeId).HasColumnName("ClickFilteringModeID").IsRequired().HasColumnType("int");
            Property(x => x.DefaultImpressionFee).HasColumnName("DefaultImpressionFee").IsRequired().HasColumnType("decimal").HasPrecision(7,4);
            Property(x => x.MarkupMultiplier).HasColumnName("MarkupMultiplier").IsRequired().HasColumnType("decimal").HasPrecision(7,4);
            Property(x => x.BrandSafetyProviderId).HasColumnName("BrandSafetyProviderID").IsOptional().HasColumnType("int");
            Property(x => x.UtcStatusChangedDateTime).HasColumnName("UtcStatusChangedDateTime").IsOptional().HasColumnType("datetime");

            // Foreign keys
            HasOptional(a => a.BillingCycle).WithMany(b => b.BuyerAccounts).HasForeignKey(c => c.BillingCycleId); // FK_BuyerAccount_BillingCycle
            HasOptional(a => a.BillingType).WithMany(b => b.BuyerAccounts).HasForeignKey(c => c.BillingTypeId); // FK_BuyerAccount_BillingType
            HasOptional(a => a.Country).WithMany(b => b.BuyerAccounts).HasForeignKey(c => c.CountryId); // FK_BuyerAccount_Country
            HasOptional(a => a.Currency).WithMany(b => b.BuyerAccounts).HasForeignKey(c => c.CurrencyId); // FK_BuyerAccount_Currency
            HasOptional(a => a.MonthlyCredit).WithMany(b => b.BuyerAccounts).HasForeignKey(c => c.MonthlyCreditId); // FK_BuyerAccount_MonthlyCredit
            HasOptional(a => a.PaymentTerm).WithMany(b => b.BuyerAccounts).HasForeignKey(c => c.PaymentTermsId); // FK_BuyerAccount_PaymentTerms
            HasOptional(a => a.Theme).WithMany(b => b.BuyerAccounts).HasForeignKey(c => c.ThemeId); // FK_BuyerAccount_Theme
            HasOptional(a => a.TimeZone).WithMany(b => b.BuyerAccounts).HasForeignKey(c => c.TimeZoneId); // FK_BuyerAccount_TimeZone
            HasOptional(a => a.User).WithMany(b => b.BuyerAccounts).HasForeignKey(c => c.CommercialContactUserId); // FK_BuyerAccount_CommercialContactUser
            HasRequired(a => a.CompanyType).WithMany(b => b.BuyerAccounts).HasForeignKey(c => c.CompanyTypeId); // FK_BuyerAccount_CompanyType
            HasRequired(a => a.Language).WithMany(b => b.BuyerAccounts).HasForeignKey(c => c.LanguageId); // FK_BuyerAccount_Language
            HasMany(t => t.CustomPublisherLists_CustomPublisherListId).WithMany(t => t.BuyerAccounts).Map(m => 
            {
                m.ToTable("BuyerAccountCustomPublisherList", "dbo");
                m.MapLeftKey("BuyerAccountID");
                m.MapRightKey("CustomPublisherListID");
            });
            HasMany(t => t.SystemFeatures).WithMany(t => t.BuyerAccounts).Map(m => 
            {
                m.ToTable("BuyerAccountFeature", "dbo");
                m.MapLeftKey("BuyerAccountID");
                m.MapRightKey("SystemFeatureCode");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountAdTagTemplateFee
    internal partial class BuyerAccountAdTagTemplateFeeMap : EntityTypeConfiguration<BuyerAccountAdTagTemplateFee>
    {
        public BuyerAccountAdTagTemplateFeeMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountAdTagTemplateFeeMap(string schema)
        {
            ToTable(schema + ".BuyerAccountAdTagTemplateFee");
            HasKey(x => new { x.BuyerAccountId, x.AdTagTemplateId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdTagTemplateId).HasColumnName("AdTagTemplateID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.FeeLocalMicros).HasColumnName("FeeLocalMicros").IsRequired().HasColumnType("bigint");

            // Foreign keys
            HasRequired(a => a.AdTagTemplate).WithMany(b => b.BuyerAccountAdTagTemplateFees).HasForeignKey(c => c.AdTagTemplateId); // FK_BuyerAccountAdTagTemplateFee_AdTagTemplate
            HasRequired(a => a.BuyerAccount).WithMany(b => b.BuyerAccountAdTagTemplateFees).HasForeignKey(c => c.BuyerAccountId); // FK_BuyerAccountAdTagTemplateFee_BuyerAccount
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountApplication
    internal partial class BuyerAccountApplicationMap : EntityTypeConfiguration<BuyerAccountApplication>
    {
        public BuyerAccountApplicationMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountApplicationMap(string schema)
        {
            ToTable(schema + ".BuyerAccountApplication");
            HasKey(x => new { x.BuyerAccountId, x.PackageKey });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PackageKey).HasColumnName("PackageKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Version).HasColumnName("Version").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Installed).HasColumnName("Installed").IsRequired().HasColumnType("bit");
            Property(x => x.Enabled).HasColumnName("Enabled").IsRequired().HasColumnType("bit");
            Property(x => x.Available).HasColumnName("Available").IsRequired().HasColumnType("bit");
            Property(x => x.Authorised).HasColumnName("Authorised").IsRequired().HasColumnType("bit");

            // Foreign keys
            HasRequired(a => a.BuyerAccount).WithMany(b => b.BuyerAccountApplications).HasForeignKey(c => c.BuyerAccountId); // FK_BuyerAccountApplication_BuyerAccount
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountApplicationAdTagServer
    internal partial class BuyerAccountApplicationAdTagServerMap : EntityTypeConfiguration<BuyerAccountApplicationAdTagServer>
    {
        public BuyerAccountApplicationAdTagServerMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountApplicationAdTagServerMap(string schema)
        {
            ToTable(schema + ".BuyerAccountApplicationAdTagServer");
            HasKey(x => new { x.BuyerAccountId, x.PackageKey, x.AdTagServerId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PackageKey).HasColumnName("PackageKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdTagServerId).HasColumnName("AdTagServerID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountApplicationAdTagTemplate
    internal partial class BuyerAccountApplicationAdTagTemplateMap : EntityTypeConfiguration<BuyerAccountApplicationAdTagTemplate>
    {
        public BuyerAccountApplicationAdTagTemplateMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountApplicationAdTagTemplateMap(string schema)
        {
            ToTable(schema + ".BuyerAccountApplicationAdTagTemplate");
            HasKey(x => new { x.BuyerAccountId, x.PackageKey, x.AdTagTemplateId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PackageKey).HasColumnName("PackageKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdTagTemplateId).HasColumnName("AdTagTemplateID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.AdTagTemplate).WithMany(b => b.BuyerAccountApplicationAdTagTemplates).HasForeignKey(c => c.AdTagTemplateId); // FK_BuyerAccountApplicationAdTagTemplate_AdTagTemplate
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountApplicationAudienceDataProvider
    internal partial class BuyerAccountApplicationAudienceDataProviderMap : EntityTypeConfiguration<BuyerAccountApplicationAudienceDataProvider>
    {
        public BuyerAccountApplicationAudienceDataProviderMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountApplicationAudienceDataProviderMap(string schema)
        {
            ToTable(schema + ".BuyerAccountApplicationAudienceDataProvider");
            HasKey(x => new { x.BuyerAccountId, x.PackageKey, x.ThirdPartyCampaignId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PackageKey).HasColumnName("PackageKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ThirdPartyCampaignId).HasColumnName("ThirdPartyCampaignID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountApplicationCreativeSize
    internal partial class BuyerAccountApplicationCreativeSizeMap : EntityTypeConfiguration<BuyerAccountApplicationCreativeSize>
    {
        public BuyerAccountApplicationCreativeSizeMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountApplicationCreativeSizeMap(string schema)
        {
            ToTable(schema + ".BuyerAccountApplicationCreativeSize");
            HasKey(x => new { x.BuyerAccountId, x.PackageKey, x.CreativeSizeId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PackageKey).HasColumnName("PackageKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CreativeSizeId).HasColumnName("CreativeSizeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.CreativeSize).WithMany(b => b.BuyerAccountApplicationCreativeSizes).HasForeignKey(c => c.CreativeSizeId); // FK_BuyerAccountApplicationCreativeSize_CreativeSize
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountApplicationDataProvider
    internal partial class BuyerAccountApplicationDataProviderMap : EntityTypeConfiguration<BuyerAccountApplicationDataProvider>
    {
        public BuyerAccountApplicationDataProviderMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountApplicationDataProviderMap(string schema)
        {
            ToTable(schema + ".BuyerAccountApplicationDataProvider");
            HasKey(x => new { x.BuyerAccountId, x.PackageKey, x.DataProviderId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PackageKey).HasColumnName("PackageKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DataProviderId).HasColumnName("DataProviderID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountApplicationGeoCountry
    internal partial class BuyerAccountApplicationGeoCountryMap : EntityTypeConfiguration<BuyerAccountApplicationGeoCountry>
    {
        public BuyerAccountApplicationGeoCountryMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountApplicationGeoCountryMap(string schema)
        {
            ToTable(schema + ".BuyerAccountApplicationGeoCountry");
            HasKey(x => new { x.BuyerAccountId, x.PackageKey, x.GeoCountryId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PackageKey).HasColumnName("PackageKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.GeoCountryId).HasColumnName("GeoCountryID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.GeoCountry).WithMany(b => b.BuyerAccountApplicationGeoCountries).HasForeignKey(c => c.GeoCountryId); // FK_BuyerAccountApplicationGeoCountry_GeoCountry
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountApplicationLanguage
    internal partial class BuyerAccountApplicationLanguageMap : EntityTypeConfiguration<BuyerAccountApplicationLanguage>
    {
        public BuyerAccountApplicationLanguageMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountApplicationLanguageMap(string schema)
        {
            ToTable(schema + ".BuyerAccountApplicationLanguage");
            HasKey(x => new { x.BuyerAccountId, x.PackageKey, x.LanguageId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PackageKey).HasColumnName("PackageKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.LanguageId).HasColumnName("LanguageID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.Language).WithMany(b => b.BuyerAccountApplicationLanguages).HasForeignKey(c => c.LanguageId); // FK_BuyerAccountApplicationLanguage_Language
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountApplicationParameter
    internal partial class BuyerAccountApplicationParameterMap : EntityTypeConfiguration<BuyerAccountApplicationParameter>
    {
        public BuyerAccountApplicationParameterMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountApplicationParameterMap(string schema)
        {
            ToTable(schema + ".BuyerAccountApplicationParameter");
            HasKey(x => new { x.BuyerAccountId, x.PackageKey, x.Key });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PackageKey).HasColumnName("PackageKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Key).HasColumnName("Key").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Value).HasColumnName("Value").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);

            // Foreign keys
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountApplicationPartner
    internal partial class BuyerAccountApplicationPartnerMap : EntityTypeConfiguration<BuyerAccountApplicationPartner>
    {
        public BuyerAccountApplicationPartnerMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountApplicationPartnerMap(string schema)
        {
            ToTable(schema + ".BuyerAccountApplicationPartner");
            HasKey(x => new { x.BuyerAccountId, x.PackageKey, x.PartnerId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PackageKey).HasColumnName("PackageKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.Partner).WithMany(b => b.BuyerAccountApplicationPartners).HasForeignKey(c => c.PartnerId); // FK_BuyerAccountApplicationPartner_Partner
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountApplicationPixelTagServer
    internal partial class BuyerAccountApplicationPixelTagServerMap : EntityTypeConfiguration<BuyerAccountApplicationPixelTagServer>
    {
        public BuyerAccountApplicationPixelTagServerMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountApplicationPixelTagServerMap(string schema)
        {
            ToTable(schema + ".BuyerAccountApplicationPixelTagServer");
            HasKey(x => new { x.BuyerAccountId, x.PackageKey, x.PixelTagServerId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PackageKey).HasColumnName("PackageKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PixelTagServerId).HasColumnName("PixelTagServerID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.PixelTagServer).WithMany(b => b.BuyerAccountApplicationPixelTagServers).HasForeignKey(c => c.PixelTagServerId); // FK_BuyerAccountApplicationPixelTagServer_PixelTagServer
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountApplicationTranslation
    internal partial class BuyerAccountApplicationTranslationMap : EntityTypeConfiguration<BuyerAccountApplicationTranslation>
    {
        public BuyerAccountApplicationTranslationMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountApplicationTranslationMap(string schema)
        {
            ToTable(schema + ".BuyerAccountApplicationTranslation");
            HasKey(x => new { x.BuyerAccountId, x.PackageKey, x.TranslationId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PackageKey).HasColumnName("PackageKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TranslationId).HasColumnName("TranslationID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountBlackListChangeLog
    internal partial class BuyerAccountBlackListChangeLogMap : EntityTypeConfiguration<BuyerAccountBlackListChangeLog>
    {
        public BuyerAccountBlackListChangeLogMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountBlackListChangeLogMap(string schema)
        {
            ToTable(schema + ".BuyerAccountBlackListChangeLog");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("ID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("bigint");
            Property(x => x.WebsiteUrl).HasColumnName("WebsiteUrl").IsRequired().HasColumnType("nvarchar").HasMaxLength(450);
            Property(x => x.Operation).HasColumnName("Operation").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UserId).HasColumnName("UserID").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.ActualUserId).HasColumnName("ActualUserID").IsOptional().HasColumnType("uniqueidentifier");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountBlackListWebsite
    internal partial class BuyerAccountBlackListWebsiteMap : EntityTypeConfiguration<BuyerAccountBlackListWebsite>
    {
        public BuyerAccountBlackListWebsiteMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountBlackListWebsiteMap(string schema)
        {
            ToTable(schema + ".BuyerAccountBlackListWebsite");
            HasKey(x => new { x.BuyerAccountId, x.WebsiteId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.WebsiteUrl).HasColumnName("WebsiteUrl").IsRequired().HasColumnType("nvarchar").HasMaxLength(450);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountBrandSafety
    internal partial class BuyerAccountBrandSafetyMap : EntityTypeConfiguration<BuyerAccountBrandSafety>
    {
        public BuyerAccountBrandSafetyMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountBrandSafetyMap(string schema)
        {
            ToTable(schema + ".BuyerAccountBrandSafety");
            HasKey(x => new { x.BrandSafetyTypeId, x.BuyerAccountId, x.BrandSafetyProviderId });

            Property(x => x.BrandSafetyTypeId).HasColumnName("BrandSafetyTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            Property(x => x.BrandSafetyProviderId).HasColumnName("BrandSafetyProviderID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.BrandSafetyType).WithMany(b => b.BuyerAccountBrandSafeties).HasForeignKey(c => c.BrandSafetyTypeId); // FK_BuyerAccountBrandSafety_New_BrandSafety
            HasRequired(a => a.BuyerAccount).WithMany(b => b.BuyerAccountBrandSafeties).HasForeignKey(c => c.BuyerAccountId); // FK_BuyerAccountBrandSafety_New_BuyerAccount
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountBrandSafety_Backup
    internal partial class BuyerAccountBrandSafetyBackupMap : EntityTypeConfiguration<BuyerAccountBrandSafetyBackup>
    {
        public BuyerAccountBrandSafetyBackupMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountBrandSafetyBackupMap(string schema)
        {
            ToTable(schema + ".BuyerAccountBrandSafety_Backup");
            HasKey(x => new { x.BrandSafetyTypeId, x.BuyerAccountId });

            Property(x => x.BrandSafetyTypeId).HasColumnName("BrandSafetyTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            Property(x => x.BrandSafetyProviderId).HasColumnName("BrandSafetyProviderID").IsOptional().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.BrandSafetyType).WithMany(b => b.BuyerAccountBrandSafetyBackups).HasForeignKey(c => c.BrandSafetyTypeId); // FK_BuyerAccountBrandSafety_BrandSafety
            HasRequired(a => a.BuyerAccount).WithMany(b => b.BuyerAccountBrandSafetyBackups).HasForeignKey(c => c.BuyerAccountId); // FK_BuyerAccountBrandSafety_BuyerAccount
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountContextualProviderFee
    internal partial class BuyerAccountContextualProviderFeeMap : EntityTypeConfiguration<BuyerAccountContextualProviderFee>
    {
        public BuyerAccountContextualProviderFeeMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountContextualProviderFeeMap(string schema)
        {
            ToTable(schema + ".BuyerAccountContextualProviderFee");
            HasKey(x => new { x.BuyerAccountId, x.ContextualProviderId, x.ContextualFeeTypeId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ContextualProviderId).HasColumnName("ContextualProviderID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ContextualFeeTypeId).HasColumnName("ContextualFeeTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.UseFlatFee).HasColumnName("UseFlatFee").IsRequired().HasColumnType("bit");
            Property(x => x.ContextualFlatFee).HasColumnName("ContextualFlatFee").IsRequired().HasColumnType("decimal").HasPrecision(18,3);
            Property(x => x.ContextualPercentageFee).HasColumnName("ContextualPercentageFee").IsRequired().HasColumnType("decimal").HasPrecision(18,3);
            Property(x => x.GroupId).HasColumnName("GroupID").IsOptional().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountDomainList
    internal partial class BuyerAccountDomainListMap : EntityTypeConfiguration<BuyerAccountDomainList>
    {
        public BuyerAccountDomainListMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountDomainListMap(string schema)
        {
            ToTable(schema + ".BuyerAccountDomainList");
            HasKey(x => new { x.DomainListId, x.BuyerAccountId });

            Property(x => x.DomainListId).HasColumnName("DomainListID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.BuyerAccount).WithMany(b => b.BuyerAccountDomainLists).HasForeignKey(c => c.BuyerAccountId); // FK_BuyerAccountDomainList_BuyerAccount
            HasRequired(a => a.DomainList).WithMany(b => b.BuyerAccountDomainLists).HasForeignKey(c => c.DomainListId); // FK_BuyerAccountDomainList_DomainList
            HasRequired(a => a.TargetingAction).WithMany(b => b.BuyerAccountDomainLists).HasForeignKey(c => c.TargetingActionId); // FK_BuyerAccountDomainList_TargetingAction
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountExcludedInventory
    internal partial class BuyerAccountExcludedInventoryMap : EntityTypeConfiguration<BuyerAccountExcludedInventory>
    {
        public BuyerAccountExcludedInventoryMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountExcludedInventoryMap(string schema)
        {
            ToTable(schema + ".BuyerAccountExcludedInventory");
            HasKey(x => new { x.BuyerAccountId, x.InventoryId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.InventoryId).HasColumnName("InventoryID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.BuyerAccount).WithMany(b => b.BuyerAccountExcludedInventories).HasForeignKey(c => c.BuyerAccountId); // FK_BuyerAccountExcludedInventory_BuyerAccount
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // BuyerAccountPartnerSeatView
    internal partial class BuyerAccountPartnerSeatViewMap : EntityTypeConfiguration<BuyerAccountPartnerSeatView>
    {
        public BuyerAccountPartnerSeatViewMap()
            : this("dbo")
        {
        }
 
        public BuyerAccountPartnerSeatViewMap(string schema)
        {
            ToTable(schema + ".BuyerAccountPartnerSeatView");
            HasKey(x => new { x.BuyerAccountId, x.PartnerId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerId).HasColumnName("BuyerID").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(83);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Campaign
    internal partial class CampaignMap : EntityTypeConfiguration<Campaign>
    {
        public CampaignMap()
            : this("dbo")
        {
        }
 
        public CampaignMap(string schema)
        {
            ToTable(schema + ".Campaign");
            HasKey(x => x.CampaignId);

            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CampaignUuid).HasColumnName("CampaignUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.AdvertiserProductId).HasColumnName("AdvertiserProductID").IsRequired().HasColumnType("int");
            Property(x => x.CampaignName).HasColumnName("CampaignName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.AgencyReference).HasColumnName("AgencyReference").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.CloneFromCampaignId).HasColumnName("CloneFromCampaignID").IsOptional().HasColumnType("int");
            Property(x => x.Margin).HasColumnName("Margin").IsRequired().HasColumnType("decimal").HasPrecision(7,4);
            Property(x => x.BudgetAmount).HasColumnName("BudgetAmount").IsRequired().HasColumnType("money").HasPrecision(19,4);

            // Foreign keys
            HasRequired(a => a.AdvertiserProduct).WithMany(b => b.Campaigns).HasForeignKey(c => c.AdvertiserProductId); // FK_Campaign_AdvertiserProduct
            HasRequired(a => a.BuyerAccount).WithMany(b => b.Campaigns).HasForeignKey(c => c.BuyerAccountId); // FK_Campaign_BuyerAccount
            HasMany(t => t.Users).WithMany(t => t.Campaigns).Map(m => 
            {
                m.ToTable("CampaignFollow", "dbo");
                m.MapLeftKey("CampaignID");
                m.MapRightKey("UserID");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CampaignBrandSafety
    internal partial class CampaignBrandSafetyMap : EntityTypeConfiguration<CampaignBrandSafety>
    {
        public CampaignBrandSafetyMap()
            : this("dbo")
        {
        }
 
        public CampaignBrandSafetyMap(string schema)
        {
            ToTable(schema + ".CampaignBrandSafety");
            HasKey(x => new { x.BrandSafetyTypeId, x.CampaignId, x.BrandSafetyProviderId });

            Property(x => x.BrandSafetyTypeId).HasColumnName("BrandSafetyTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            Property(x => x.BrandSafetyProviderId).HasColumnName("BrandSafetyProviderID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.BrandSafetyType).WithMany(b => b.CampaignBrandSafeties).HasForeignKey(c => c.BrandSafetyTypeId); // FK_CampaignBrandSafety_New_BrandSafety
            HasRequired(a => a.Campaign).WithMany(b => b.CampaignBrandSafeties).HasForeignKey(c => c.CampaignId); // FK_CampaignBrandSafety_New_Campaign
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CampaignBrandSafety_Backup
    internal partial class CampaignBrandSafetyBackupMap : EntityTypeConfiguration<CampaignBrandSafetyBackup>
    {
        public CampaignBrandSafetyBackupMap()
            : this("dbo")
        {
        }
 
        public CampaignBrandSafetyBackupMap(string schema)
        {
            ToTable(schema + ".CampaignBrandSafety_Backup");
            HasKey(x => new { x.BrandSafetyTypeId, x.CampaignId });

            Property(x => x.BrandSafetyTypeId).HasColumnName("BrandSafetyTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");
            Property(x => x.BrandSafetyProviderId).HasColumnName("BrandSafetyProviderID").IsOptional().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.BrandSafetyType).WithMany(b => b.CampaignBrandSafetyBackups).HasForeignKey(c => c.BrandSafetyTypeId); // FK_CampaignBrandSafety_BrandSafety
            HasRequired(a => a.Campaign).WithMany(b => b.CampaignBrandSafetyBackups).HasForeignKey(c => c.CampaignId); // FK_CampaignBrandSafety_Campaign
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CampaignDomainList
    internal partial class CampaignDomainListMap : EntityTypeConfiguration<CampaignDomainList>
    {
        public CampaignDomainListMap()
            : this("dbo")
        {
        }
 
        public CampaignDomainListMap(string schema)
        {
            ToTable(schema + ".CampaignDomainList");
            HasKey(x => new { x.DomainListId, x.CampaignId });

            Property(x => x.DomainListId).HasColumnName("DomainListID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.Campaign).WithMany(b => b.CampaignDomainLists).HasForeignKey(c => c.CampaignId); // FK_CampaignDomainList_Campaign
            HasRequired(a => a.DomainList).WithMany(b => b.CampaignDomainLists).HasForeignKey(c => c.DomainListId); // FK_CampaignDomainList_DomainList
            HasRequired(a => a.TargetingAction).WithMany(b => b.CampaignDomainLists).HasForeignKey(c => c.TargetingActionId); // FK_CampaignDomainList_TargetingAction
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CampaignMargin
    internal partial class CampaignMarginMap : EntityTypeConfiguration<CampaignMargin>
    {
        public CampaignMarginMap()
            : this("dbo")
        {
        }
 
        public CampaignMarginMap(string schema)
        {
            ToTable(schema + ".CampaignMargin");
            HasKey(x => x.CampaignMarginId);

            Property(x => x.CampaignMarginId).HasColumnName("CampaignMarginID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int");
            Property(x => x.LocalStartDateInclusive).HasColumnName("LocalStartDateInclusive").IsRequired().HasColumnType("datetime");
            Property(x => x.LocalEndDateInclusive).HasColumnName("LocalEndDateInclusive").IsOptional().HasColumnType("datetime");
            Property(x => x.Margin).HasColumnName("Margin").IsOptional().HasColumnType("decimal").HasPrecision(18,3);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CampaignPerformance
    internal partial class CampaignPerformanceMap : EntityTypeConfiguration<CampaignPerformance>
    {
        public CampaignPerformanceMap()
            : this("dbo")
        {
        }
 
        public CampaignPerformanceMap(string schema)
        {
            ToTable(schema + ".CampaignPerformance");
            HasKey(x => new { x.CampaignId, x.IntervalId, x.IntervalValue });

            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalId).HasColumnName("IntervalID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalValue).HasColumnName("IntervalValue").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Bids).HasColumnName("Bids").IsRequired().HasColumnType("bigint");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Clicks).HasColumnName("Clicks").IsRequired().HasColumnType("bigint");
            Property(x => x.Conversions).HasColumnName("Conversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostViewConversions).HasColumnName("PostViewConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostClickConversions).HasColumnName("PostClickConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.LastActivityTimestamp).HasColumnName("LastActivityTimestamp").IsOptional().HasColumnType("datetime");
            Property(x => x.Ctr).HasColumnName("CTR").IsOptional().HasColumnType("float").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaCostLocalMicros).HasColumnName("MediaCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataCostLocalMicros).HasColumnName("DataCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.SpendLocalMicros).HasColumnName("SpendLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaClientCostLocalMicros).HasColumnName("MediaClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataClientCostLocalMicros).HasColumnName("DataClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.ClientCostLocalMicros).HasColumnName("ClientCostLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpm).HasColumnName("CPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpc).HasColumnName("CPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpa).HasColumnName("CPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpm).HasColumnName("ClientCostCPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpc).HasColumnName("ClientCostCPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpa).HasColumnName("ClientCostCPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Spend).HasColumnName("Spend").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cvr).HasColumnName("Cvr").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.BidWin).HasColumnName("BidWin").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.AdSlotDurationInSeconds).HasColumnName("AdSlotDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.RawViews).HasColumnName("RawViews").IsRequired().HasColumnType("bigint");
            Property(x => x.IabViews).HasColumnName("IabViews").IsRequired().HasColumnType("bigint");
            Property(x => x.ViewDurationInSeconds).HasColumnName("ViewDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.CpMs).HasColumnName("CPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpMs).HasColumnName("ClientCostCPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cps).HasColumnName("CPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCps).HasColumnName("ClientCostCPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ViewableRatio).HasColumnName("ViewableRatio").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            // Foreign keys
            HasRequired(a => a.Campaign).WithMany(b => b.CampaignPerformances).HasForeignKey(c => c.CampaignId); // FK_CampaignPerformance_Campaign
            HasRequired(a => a.Interval).WithMany(b => b.CampaignPerformances).HasForeignKey(c => c.IntervalId); // FK_CampaignPerformance_Interval
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CampaignPeriod
    internal partial class CampaignPeriodMap : EntityTypeConfiguration<CampaignPeriod>
    {
        public CampaignPeriodMap()
            : this("dbo")
        {
        }
 
        public CampaignPeriodMap(string schema)
        {
            ToTable(schema + ".CampaignPeriod");
            HasKey(x => x.CampaignPeriodId);

            Property(x => x.CampaignPeriodId).HasColumnName("CampaignPeriodID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PeriodName).HasColumnName("PeriodName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType("bit");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CampaignStatus
    internal partial class CampaignStatusMap : EntityTypeConfiguration<CampaignStatus>
    {
        public CampaignStatusMap()
            : this("dbo")
        {
        }
 
        public CampaignStatusMap(string schema)
        {
            ToTable(schema + ".CampaignStatus");
            HasKey(x => x.CampaignStatusId);

            Property(x => x.CampaignStatusId).HasColumnName("CampaignStatusID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CampaignStatusName).HasColumnName("CampaignStatusName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ChangeLog
    internal partial class ChangeLogMap : EntityTypeConfiguration<ChangeLog>
    {
        public ChangeLogMap()
            : this("dbo")
        {
        }
 
        public ChangeLogMap(string schema)
        {
            ToTable(schema + ".ChangeLog");
            HasKey(x => x.ChangeLogId);

            Property(x => x.ChangeLogId).HasColumnName("ChangeLogID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UtcDateTime).HasColumnName("UtcDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UserId).HasColumnName("UserID").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.ActualUserId).HasColumnName("ActualUserID").IsOptional().HasColumnType("uniqueidentifier");
            Property(x => x.NameSpace).HasColumnName("NameSpace").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MethodName).HasColumnName("MethodName").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Json).HasColumnName("Json").IsOptional().HasColumnType("nvarchar");
            Property(x => x.DataKey).HasColumnName("DataKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LinkTable).HasColumnName("LinkTable").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MilliSecondsTaken).HasColumnName("MilliSecondsTaken").IsRequired().HasColumnType("int");
            Property(x => x.SecurityLevel).HasColumnName("SecurityLevel").IsRequired().HasColumnType("tinyint");
            Property(x => x.Exception).HasColumnName("Exception").IsOptional().HasColumnType("nvarchar").HasMaxLength(512);
            Property(x => x.NoChange).HasColumnName("NoChange").IsRequired().HasColumnType("bit");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ChangeLogComment
    internal partial class ChangeLogCommentMap : EntityTypeConfiguration<ChangeLogComment>
    {
        public ChangeLogCommentMap()
            : this("dbo")
        {
        }
 
        public ChangeLogCommentMap(string schema)
        {
            ToTable(schema + ".ChangeLogComment");
            HasKey(x => x.ChangeLogCommentId);

            Property(x => x.ChangeLogCommentId).HasColumnName("ChangeLogCommentId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Comment).HasColumnName("Comment").IsRequired().HasColumnType("nvarchar");
            Property(x => x.UtcDateTime).HasColumnName("UtcDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.ChangeLogId).HasColumnName("ChangeLogId").IsRequired().HasColumnType("bigint");
            Property(x => x.ActualUserId).HasColumnName("ActualUserId").IsRequired().HasColumnType("uniqueidentifier");

            // Foreign keys
            HasRequired(a => a.ChangeLog).WithMany(b => b.ChangeLogComments).HasForeignKey(c => c.ChangeLogId); // FK_ChangeLogComment_ChangeLog
            HasRequired(a => a.User).WithMany(b => b.ChangeLogComments).HasForeignKey(c => c.ActualUserId); // FK_ChangeLogComment_User
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CompanyType
    internal partial class CompanyTypeMap : EntityTypeConfiguration<CompanyType>
    {
        public CompanyTypeMap()
            : this("dbo")
        {
        }
 
        public CompanyTypeMap(string schema)
        {
            ToTable(schema + ".CompanyType");
            HasKey(x => x.CompanyTypeId);

            Property(x => x.CompanyTypeId).HasColumnName("CompanyTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CompanyTypeName).HasColumnName("CompanyTypeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.SortOrder).HasColumnName("SortOrder").IsRequired().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ConstraintReason
    internal partial class ConstraintReasonMap : EntityTypeConfiguration<ConstraintReason>
    {
        public ConstraintReasonMap()
            : this("dbo")
        {
        }
 
        public ConstraintReasonMap(string schema)
        {
            ToTable(schema + ".ConstraintReason");
            HasKey(x => x.ConstraintReasonId);

            Property(x => x.ConstraintReasonId).HasColumnName("ConstraintReasonID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ConstraintReasonName).HasColumnName("ConstraintReasonName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ContextualProviderFee
    internal partial class ContextualProviderFeeMap : EntityTypeConfiguration<ContextualProviderFee>
    {
        public ContextualProviderFeeMap()
            : this("dbo")
        {
        }
 
        public ContextualProviderFeeMap(string schema)
        {
            ToTable(schema + ".ContextualProviderFee");
            HasKey(x => new { x.ContextualProviderId, x.ContextualFeeTypeId });

            Property(x => x.ContextualProviderId).HasColumnName("ContextualProviderID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ContextualFeeTypeId).HasColumnName("ContextualFeeTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ContextualFlatFee).HasColumnName("ContextualFlatFee").IsRequired().HasColumnType("decimal").HasPrecision(18,3);
            Property(x => x.ContextualPercentageFee).HasColumnName("ContextualPercentageFee").IsRequired().HasColumnType("decimal").HasPrecision(18,3);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Country
    internal partial class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
            : this("dbo")
        {
        }
 
        public CountryMap(string schema)
        {
            ToTable(schema + ".Country");
            HasKey(x => x.CountryId);

            Property(x => x.CountryId).HasColumnName("CountryID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CountryName).HasColumnName("CountryName").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Iso3166Code).HasColumnName("ISO3166Code").IsRequired().IsFixedLength().IsUnicode(false).HasColumnType("char").HasMaxLength(3);
            Property(x => x.Position).HasColumnName("Position").IsOptional().HasColumnType("int");
            Property(x => x.CurrencyId).HasColumnName("CurrencyID").IsOptional().HasColumnType("int");
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType("bit");
            Property(x => x.TaxRate).HasColumnName("TaxRate").IsRequired().HasColumnType("decimal").HasPrecision(5,3);
            Property(x => x.DefaultTimeZoneId).HasColumnName("DefaultTimeZoneID").IsOptional().HasColumnType("int");
            Property(x => x.IsGeoTarget).HasColumnName("IsGeoTarget").IsRequired().HasColumnType("bit");
            Property(x => x.DefaultLanguageId).HasColumnName("DefaultLanguageID").IsOptional().HasColumnType("int");
            Property(x => x.IsSupported).HasColumnName("IsSupported").IsRequired().HasColumnType("bit");

            // Foreign keys
            HasOptional(a => a.Currency).WithMany(b => b.Countries).HasForeignKey(c => c.CurrencyId); // FK_Country_Currency
            HasOptional(a => a.TimeZone).WithMany(b => b.Countries).HasForeignKey(c => c.DefaultTimeZoneId); // FK__Country__Default__54B68676
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CountryContextualProviderFee
    internal partial class CountryContextualProviderFeeMap : EntityTypeConfiguration<CountryContextualProviderFee>
    {
        public CountryContextualProviderFeeMap()
            : this("dbo")
        {
        }
 
        public CountryContextualProviderFeeMap(string schema)
        {
            ToTable(schema + ".CountryContextualProviderFee");
            HasKey(x => new { x.CountryId, x.ContextualProviderId, x.ContextualFeeTypeId });

            Property(x => x.CountryId).HasColumnName("CountryID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ContextualProviderId).HasColumnName("ContextualProviderID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ContextualFeeTypeId).HasColumnName("ContextualFeeTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ContextualFlatFee).HasColumnName("ContextualFlatFee").IsRequired().HasColumnType("decimal").HasPrecision(18,3);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Creative
    internal partial class CreativeMap : EntityTypeConfiguration<Creative>
    {
        public CreativeMap()
            : this("dbo")
        {
        }
 
        public CreativeMap(string schema)
        {
            ToTable(schema + ".Creative");
            HasKey(x => x.CreativeId);

            Property(x => x.CreativeId).HasColumnName("CreativeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CreativeUuid).HasColumnName("CreativeUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.CreativeName).HasColumnName("CreativeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.CreativeTypeId).HasColumnName("CreativeTypeID").IsRequired().HasColumnType("int");
            Property(x => x.CreativeSizeId).HasColumnName("CreativeSizeID").IsRequired().HasColumnType("int");
            Property(x => x.AdTag).HasColumnName("AdTag").IsOptional().HasColumnType("nvarchar");
            Property(x => x.CreativeFileId).HasColumnName("CreativeFileID").IsOptional().HasColumnType("int");
            Property(x => x.AdTagTemplateId).HasColumnName("AdTagTemplateID").IsOptional().HasColumnType("int");
            Property(x => x.ClickThroughUrl).HasColumnName("ClickThroughURL").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.ClickTrackerUrl).HasColumnName("ClickTrackerURL").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.BeaconUrl).HasColumnName("BeaconURL").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.CreativeStatusId).HasColumnName("CreativeStatusID").IsRequired().HasColumnType("int");
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.LanguageId).HasColumnName("LanguageID").IsRequired().HasColumnType("int");
            Property(x => x.CloneFromCreativeId).HasColumnName("CloneFromCreativeID").IsOptional().HasColumnType("int");
            Property(x => x.VideoSpecUrl).HasColumnName("VideoSpecUrl").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.UrlValidated).HasColumnName("UrlValidated").IsOptional().HasColumnType("bit");
            Property(x => x.ExpandableDirectionId).HasColumnName("ExpandableDirectionID").IsRequired().HasColumnType("int");
            Property(x => x.AdvertiserProductId).HasColumnName("AdvertiserProductID").IsRequired().HasColumnType("int");
            Property(x => x.ThumbnailStatusId).HasColumnName("ThumbnailStatusID").IsRequired().HasColumnType("int");
            Property(x => x.FbTitleText).HasColumnName("FbTitleText").IsOptional().HasColumnType("nvarchar").HasMaxLength(25);
            Property(x => x.FbBodyText).HasColumnName("FbBodyText").IsOptional().HasColumnType("nvarchar").HasMaxLength(90);
            Property(x => x.FbImageHash).HasColumnName("FbImageHash").IsOptional().HasColumnType("nvarchar").HasMaxLength(255);
            Property(x => x.FbImageUrl).HasColumnName("FbImageUrl").IsOptional().HasColumnType("nvarchar").HasMaxLength(255);
            Property(x => x.ExpandableActionId).HasColumnName("ExpandableActionID").IsRequired().HasColumnType("int");
            Property(x => x.FlexTileLabel).HasColumnName("FlexTileLabel").IsOptional().HasColumnType("nvarchar").HasMaxLength(20);
            Property(x => x.IsSsl).HasColumnName("IsSsl").IsOptional().HasColumnType("bit");
            Property(x => x.CreativeHostingFee).HasColumnName("CreativeHostingFee").IsOptional().HasColumnType("decimal").HasPrecision(7,4);

            // Foreign keys
            HasOptional(a => a.AdTagTemplate).WithMany(b => b.Creatives).HasForeignKey(c => c.AdTagTemplateId); // FK_Creative_AdTagTemplate
            HasOptional(a => a.CreativeFile).WithMany(b => b.Creatives).HasForeignKey(c => c.CreativeFileId); // FK_Creative_CreativeFile
            HasRequired(a => a.AdvertiserProduct).WithMany(b => b.Creatives).HasForeignKey(c => c.AdvertiserProductId); // FK_Creative_AdvertiserProduct
            HasRequired(a => a.BuyerAccount).WithMany(b => b.Creatives).HasForeignKey(c => c.BuyerAccountId); // FK_Creative_BuyerAccount
            HasRequired(a => a.CampaignStatus).WithMany(b => b.Creatives).HasForeignKey(c => c.CreativeStatusId); // FK_Creative_CampaignStatus
            HasRequired(a => a.CreativeSize).WithMany(b => b.Creatives).HasForeignKey(c => c.CreativeSizeId); // FK_Creative_CreativeSize
            HasRequired(a => a.CreativeType).WithMany(b => b.Creatives).HasForeignKey(c => c.CreativeTypeId); // FK_Creative_CreativeType
            HasRequired(a => a.ExpandableAction).WithMany(b => b.Creatives).HasForeignKey(c => c.ExpandableActionId); // FK_Creative_ExpandableAction
            HasRequired(a => a.ExpandableDirection).WithMany(b => b.Creatives).HasForeignKey(c => c.ExpandableDirectionId); // FK_Creative_ExpandableDirection
            HasRequired(a => a.Language).WithMany(b => b.Creatives).HasForeignKey(c => c.LanguageId); // FK_Creative_LanguageID
            HasMany(t => t.SensitiveCategories).WithMany(t => t.Creatives).Map(m => 
            {
                m.ToTable("CreativeSensitiveCategory", "dbo");
                m.MapLeftKey("CreativeId");
                m.MapRightKey("SensitiveCategoryId");
            });
            HasMany(t => t.Technologies).WithMany(t => t.Creatives).Map(m => 
            {
                m.ToTable("CreativeTechnology", "dbo");
                m.MapLeftKey("CreativeID");
                m.MapRightKey("TechnologyID");
            });
            HasMany(t => t.Users).WithMany(t => t.Creatives).Map(m => 
            {
                m.ToTable("CreativeFollow", "dbo");
                m.MapLeftKey("CreativeID");
                m.MapRightKey("UserID");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeAttribute
    internal partial class CreativeAttributeMap : EntityTypeConfiguration<CreativeAttribute>
    {
        public CreativeAttributeMap()
            : this("dbo")
        {
        }
 
        public CreativeAttributeMap(string schema)
        {
            ToTable(schema + ".CreativeAttribute");
            HasKey(x => x.CreativeAttributeId);

            Property(x => x.CreativeAttributeId).HasColumnName("CreativeAttributeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CreativeAttributeName).HasColumnName("CreativeAttributeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            HasMany(t => t.Creatives).WithMany(t => t.CreativeAttributes).Map(m => 
            {
                m.ToTable("CreativeCreativeAttribute", "dbo");
                m.MapLeftKey("CreativeAttributeID");
                m.MapRightKey("CreativeID");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeAuditStatus
    internal partial class CreativeAuditStatuMap : EntityTypeConfiguration<CreativeAuditStatu>
    {
        public CreativeAuditStatuMap()
            : this("dbo")
        {
        }
 
        public CreativeAuditStatuMap(string schema)
        {
            ToTable(schema + ".CreativeAuditStatus");
            HasKey(x => x.CreativeAuditStatusId);

            Property(x => x.CreativeAuditStatusId).HasColumnName("CreativeAuditStatusID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CreativeAuditStatusName).HasColumnName("CreativeAuditStatusName").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeConversionSegmentMongoExportView
    internal partial class CreativeConversionSegmentMongoExportViewMap : EntityTypeConfiguration<CreativeConversionSegmentMongoExportView>
    {
        public CreativeConversionSegmentMongoExportViewMap()
            : this("dbo")
        {
        }
 
        public CreativeConversionSegmentMongoExportViewMap(string schema)
        {
            ToTable(schema + ".CreativeConversionSegmentMongoExportView");
            HasKey(x => new { x.PlacementUuid, x.RtbSegmentId });

            Property(x => x.PlacementUuid).HasColumnName("PlacementUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.RtbSegmentId).HasColumnName("RtbSegmentID").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeFile
    internal partial class CreativeFileMap : EntityTypeConfiguration<CreativeFile>
    {
        public CreativeFileMap()
            : this("dbo")
        {
        }
 
        public CreativeFileMap(string schema)
        {
            ToTable(schema + ".CreativeFile");
            HasKey(x => x.CreativeFileId);

            Property(x => x.CreativeFileId).HasColumnName("CreativeFileID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.FileName).HasColumnName("FileName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.BrandscreenFileName).HasColumnName("BrandscreenFileName").IsOptional().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.FileSize).HasColumnName("FileSize").IsRequired().HasColumnType("int");
            Property(x => x.FileExtension).HasColumnName("FileExtension").IsOptional().HasColumnType("nvarchar").HasMaxLength(20);
            Property(x => x.Width).HasColumnName("Width").IsOptional().HasColumnType("int");
            Property(x => x.Height).HasColumnName("Height").IsOptional().HasColumnType("int");
            Property(x => x.RelativePath).HasColumnName("RelativePath").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.Tags).HasColumnName("Tags").IsOptional().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.Description).HasColumnName("Description").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.CreatedDateTime).HasColumnName("CreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.LastUsed).HasColumnName("LastUsed").IsOptional().HasColumnType("datetime");
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");
            Property(x => x.ErrorMessage).HasColumnName("ErrorMessage").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");

            // Foreign keys
            HasRequired(a => a.BuyerAccount).WithMany(b => b.CreativeFiles).HasForeignKey(c => c.BuyerAccountId); // FK_CreativeFile_BuyerAccountID
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeFileStatus
    internal partial class CreativeFileStatuMap : EntityTypeConfiguration<CreativeFileStatu>
    {
        public CreativeFileStatuMap()
            : this("dbo")
        {
        }
 
        public CreativeFileStatuMap(string schema)
        {
            ToTable(schema + ".CreativeFileStatus");
            HasKey(x => x.CreativeFileStatusId);

            Property(x => x.CreativeFileStatusId).HasColumnName("CreativeFileStatusID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CreativeFileStatusName).HasColumnName("CreativeFileStatusName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.CreativeFileStatusDescription).HasColumnName("CreativeFileStatusDescription").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeMongoExportView
    internal partial class CreativeMongoExportViewMap : EntityTypeConfiguration<CreativeMongoExportView>
    {
        public CreativeMongoExportViewMap()
            : this("dbo")
        {
        }
 
        public CreativeMongoExportViewMap(string schema)
        {
            ToTable(schema + ".CreativeMongoExportView");
            HasKey(x => new { x.PlacementUuid, x.PlacementId, x.CreativeUuid, x.CreativeId, x.AdGroupId, x.AdGroupUuid, x.CreativeName, x.PlacementStatusId, x.BuyerAccountId, x.Brokerage, x.MarkupMultiplier, x.CampaignId, x.CampaignUuid, x.AdvertiserId, x.AdvertiserProductId, x.CreativeUtcCreatedDateTime, x.CreativeUtcModifiedDateTime, x.PlacementUtcCreatedDateTime, x.PlacementUtcModifiedDateTime });

            Property(x => x.PlacementUuid).HasColumnName("PlacementUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.PlacementId).HasColumnName("PlacementID").IsRequired().HasColumnType("int");
            Property(x => x.CreativeUuid).HasColumnName("CreativeUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.CreativeId).HasColumnName("CreativeID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupId").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupUuid).HasColumnName("AdGroupUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.CreativeName).HasColumnName("CreativeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.ClickThroughUrl).HasColumnName("ClickThroughUrl").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.ClickTrackerUrl).HasColumnName("ClickTrackerUrl").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.PlacementStatusId).HasColumnName("PlacementStatusID").IsRequired().HasColumnType("int");
            Property(x => x.CurrencyCodeIso4217).HasColumnName("CurrencyCodeIso4217").IsOptional().IsFixedLength().IsUnicode(false).HasColumnType("char").HasMaxLength(3);
            Property(x => x.TimeZoneCode).HasColumnName("TimeZoneCode").IsOptional().HasColumnType("nvarchar").HasMaxLength(150);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountId").IsRequired().HasColumnType("int");
            Property(x => x.Brokerage).HasColumnName("Brokerage").IsRequired().HasColumnType("decimal").HasPrecision(7,4);
            Property(x => x.MarkupMultiplier).HasColumnName("MarkupMultiplier").IsRequired().HasColumnType("decimal").HasPrecision(7,4);
            Property(x => x.ServiceFeePctMicros).HasColumnName("ServiceFeePctMicros").IsOptional().HasColumnType("int");
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int");
            Property(x => x.CampaignUuid).HasColumnName("CampaignUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.AdvertiserId).HasColumnName("AdvertiserId").IsRequired().HasColumnType("int");
            Property(x => x.AdvertiserProductId).HasColumnName("AdvertiserProductId").IsRequired().HasColumnType("int");
            Property(x => x.ProductCategoryId).HasColumnName("ProductCategoryId").IsOptional().HasColumnType("int");
            Property(x => x.CreativeUtcCreatedDateTime).HasColumnName("Creative_UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.CreativeUtcModifiedDateTime).HasColumnName("Creative_UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.PlacementUtcCreatedDateTime).HasColumnName("Placement_UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.PlacementUtcModifiedDateTime).HasColumnName("Placement_UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.FrequencyGroupId).HasColumnName("FrequencyGroupID").IsOptional().HasColumnType("int");
            Property(x => x.OlsonTimezoneName).HasColumnName("OlsonTimezoneName").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeParameter
    internal partial class CreativeParameterMap : EntityTypeConfiguration<CreativeParameter>
    {
        public CreativeParameterMap()
            : this("dbo")
        {
        }
 
        public CreativeParameterMap(string schema)
        {
            ToTable(schema + ".CreativeParameter");
            HasKey(x => new { x.CreativeId, x.CreativeParameterKey });

            Property(x => x.CreativeId).HasColumnName("CreativeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CreativeParameterKey).HasColumnName("CreativeParameterKey").IsRequired().HasColumnType("nvarchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CreativeParameterValue).HasColumnName("CreativeParameterValue").IsRequired().HasColumnType("nvarchar").HasMaxLength(2000);

            // Foreign keys
            HasRequired(a => a.Creative).WithMany(b => b.CreativeParameters).HasForeignKey(c => c.CreativeId); // FK_CreativeParameter_Creative
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeReview
    internal partial class CreativeReviewMap : EntityTypeConfiguration<CreativeReview>
    {
        public CreativeReviewMap()
            : this("dbo")
        {
        }
 
        public CreativeReviewMap(string schema)
        {
            ToTable(schema + ".CreativeReview");
            HasKey(x => new { x.CreativeId, x.PartnerId });

            Property(x => x.CreativeId).HasColumnName("CreativeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CreativeReviewStatusId).HasColumnName("CreativeReviewStatusID").IsRequired().HasColumnType("int");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.ExchangeErrorString).HasColumnName("ExchangeErrorString").IsOptional().HasColumnType("nvarchar").HasMaxLength(4000);

            // Foreign keys
            HasRequired(a => a.Creative).WithMany(b => b.CreativeReviews).HasForeignKey(c => c.CreativeId); // FK_CreativeReview_Creative
            HasRequired(a => a.CreativeReviewStatus).WithMany(b => b.CreativeReviews).HasForeignKey(c => c.CreativeReviewStatusId); // FK_CreativeReview_CreativeReviewStatus
            HasRequired(a => a.Partner).WithMany(b => b.CreativeReviews).HasForeignKey(c => c.PartnerId); // PK_CreativeReview_Partner
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeReviewConfiguration
    internal partial class CreativeReviewConfigurationMap : EntityTypeConfiguration<CreativeReviewConfiguration>
    {
        public CreativeReviewConfigurationMap()
            : this("dbo")
        {
        }
 
        public CreativeReviewConfigurationMap(string schema)
        {
            ToTable(schema + ".CreativeReviewConfiguration");
            HasKey(x => x.Key);

            Property(x => x.Key).HasColumnName("Key").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Value).HasColumnName("Value").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeReviewLookup
    internal partial class CreativeReviewLookupMap : EntityTypeConfiguration<CreativeReviewLookup>
    {
        public CreativeReviewLookupMap()
            : this("dbo")
        {
        }
 
        public CreativeReviewLookupMap(string schema)
        {
            ToTable(schema + ".CreativeReviewLookup");
            HasKey(x => new { x.CreativeName, x.CreativeId, x.AdvertiserProductId, x.BuyerAccountId, x.AdGroupId, x.CampaignId, x.AdvertiserId, x.AdvertiserName, x.CampaignName, x.AdGroupName });

            Property(x => x.CreativeName).HasColumnName("CreativeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.RtbCreativeId).HasColumnName("RtbCreativeID").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(24);
            Property(x => x.CreativeId).HasColumnName("CreativeID").IsRequired().HasColumnType("int");
            Property(x => x.AdvertiserProductId).HasColumnName("AdvertiserProductID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int");
            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsRequired().HasColumnType("int");
            Property(x => x.Width).HasColumnName("Width").IsOptional().HasColumnType("int");
            Property(x => x.Height).HasColumnName("Height").IsOptional().HasColumnType("int");
            Property(x => x.CompanyName).HasColumnName("CompanyName").IsOptional().HasColumnType("nvarchar").HasMaxLength(255);
            Property(x => x.AdvertiserName).HasColumnName("AdvertiserName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.CampaignName).HasColumnName("CampaignName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.AdGroupName).HasColumnName("AdGroupName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsOptional().HasColumnType("bigint");
            Property(x => x.CreativeReviewStatusId).HasColumnName("CreativeReviewStatusID").IsOptional().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeReviewRejection
    internal partial class CreativeReviewRejectionMap : EntityTypeConfiguration<CreativeReviewRejection>
    {
        public CreativeReviewRejectionMap()
            : this("dbo")
        {
        }
 
        public CreativeReviewRejectionMap(string schema)
        {
            ToTable(schema + ".CreativeReviewRejection");
            HasKey(x => new { x.CreativeId, x.PartnerId, x.RejectionReasonId });

            Property(x => x.CreativeId).HasColumnName("CreativeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.RejectionReasonId).HasColumnName("RejectionReasonId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeReviewStatus
    internal partial class CreativeReviewStatusMap : EntityTypeConfiguration<CreativeReviewStatus>
    {
        public CreativeReviewStatusMap()
            : this("dbo")
        {
        }
 
        public CreativeReviewStatusMap(string schema)
        {
            ToTable(schema + ".CreativeReviewStatus");
            HasKey(x => x.CreativeReviewStatusId);

            Property(x => x.CreativeReviewStatusId).HasColumnName("CreativeReviewStatusID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CreativeReviewStatus_).HasColumnName("CreativeReviewStatus").IsRequired().HasColumnType("nvarchar").HasMaxLength(30);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeSize
    internal partial class CreativeSizeMap : EntityTypeConfiguration<CreativeSize>
    {
        public CreativeSizeMap()
            : this("dbo")
        {
        }
 
        public CreativeSizeMap(string schema)
        {
            ToTable(schema + ".CreativeSize");
            HasKey(x => x.CreativeSizeId);

            Property(x => x.CreativeSizeId).HasColumnName("CreativeSizeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CreativeSizeName).HasColumnName("CreativeSizeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.Height).HasColumnName("Height").IsOptional().HasColumnType("int");
            Property(x => x.Width).HasColumnName("Width").IsOptional().HasColumnType("int");
            Property(x => x.Score).HasColumnName("Score").IsOptional().HasColumnType("decimal").HasPrecision(18,3);
            Property(x => x.IsActive).HasColumnName("IsActive").IsOptional().HasColumnType("bit");
            Property(x => x.IsUniversalAdPackage).HasColumnName("IsUniversalAdPackage").IsOptional().HasColumnType("bit");
            Property(x => x.MediaTypeId).HasColumnName("MediaTypeID").IsRequired().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeSourceType
    internal partial class CreativeSourceTypeMap : EntityTypeConfiguration<CreativeSourceType>
    {
        public CreativeSourceTypeMap()
            : this("dbo")
        {
        }
 
        public CreativeSourceTypeMap(string schema)
        {
            ToTable(schema + ".CreativeSourceType");
            HasKey(x => x.CreativeSourceTypeId);

            Property(x => x.CreativeSourceTypeId).HasColumnName("CreativeSourceTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.SourceType).HasColumnName("SourceType").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Position).HasColumnName("Position").IsOptional().HasColumnType("int");
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType("bit");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeSpecification
    internal partial class CreativeSpecificationMap : EntityTypeConfiguration<CreativeSpecification>
    {
        public CreativeSpecificationMap()
            : this("dbo")
        {
        }
 
        public CreativeSpecificationMap(string schema)
        {
            ToTable(schema + ".CreativeSpecification");
            HasKey(x => x.CreativeSpecificationId);

            Property(x => x.CreativeSpecificationId).HasColumnName("CreativeSpecificationID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CreativeTypeId).HasColumnName("CreativeTypeID").IsRequired().HasColumnType("int");
            Property(x => x.CreativeSizeId).HasColumnName("CreativeSizeID").IsRequired().HasColumnType("int");
            Property(x => x.MaxFileSizeKb).HasColumnName("MaxFileSizeKB").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.CreativeSize).WithMany(b => b.CreativeSpecifications).HasForeignKey(c => c.CreativeSizeId); // FK_CreativeSpecification_CreativeSize
            HasRequired(a => a.CreativeType).WithMany(b => b.CreativeSpecifications).HasForeignKey(c => c.CreativeTypeId); // FK_CreativeSpecification_CreativeType
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CreativeType
    internal partial class CreativeTypeMap : EntityTypeConfiguration<CreativeType>
    {
        public CreativeTypeMap()
            : this("dbo")
        {
        }
 
        public CreativeTypeMap(string schema)
        {
            ToTable(schema + ".CreativeType");
            HasKey(x => x.CreativeTypeId);

            Property(x => x.CreativeTypeId).HasColumnName("CreativeTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CreativeTypeName).HasColumnName("CreativeTypeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.AllowedFileExtensions).HasColumnName("AllowedFileExtensions").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType("bit");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Currency
    internal partial class CurrencyMap : EntityTypeConfiguration<Currency>
    {
        public CurrencyMap()
            : this("dbo")
        {
        }
 
        public CurrencyMap(string schema)
        {
            ToTable(schema + ".Currency");
            HasKey(x => x.CurrencyId);

            Property(x => x.CurrencyId).HasColumnName("CurrencyID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CurrencyName).HasColumnName("CurrencyName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Iso4217Code).HasColumnName("ISO4217Code").IsOptional().IsFixedLength().IsUnicode(false).HasColumnType("char").HasMaxLength(3);
            Property(x => x.FormatSpecification).HasColumnName("FormatSpecification").IsOptional().HasColumnType("nvarchar").HasMaxLength(3);
            Property(x => x.LocalToUsdRate).HasColumnName("LocalToUSDRate").IsOptional().HasColumnType("decimal").HasPrecision(18,6);
            Property(x => x.IsActive).HasColumnName("IsActive").IsOptional().HasColumnType("bit");
            Property(x => x.CountryId).HasColumnName("CountryID").IsOptional().HasColumnType("int");
            Property(x => x.MinBudget).HasColumnName("MinBudget").IsRequired().HasColumnType("decimal").HasPrecision(18,6);
            Property(x => x.MinTargetRateCpm).HasColumnName("MinTargetRateCpm").IsRequired().HasColumnType("decimal").HasPrecision(18,6);
            Property(x => x.MinTargetRateCpc).HasColumnName("MinTargetRateCpc").IsRequired().HasColumnType("decimal").HasPrecision(18,6);
            Property(x => x.MinTargetRateCpa).HasColumnName("MinTargetRateCpa").IsRequired().HasColumnType("decimal").HasPrecision(18,6);
            Property(x => x.MinBid).HasColumnName("MinBid").IsRequired().HasColumnType("decimal").HasPrecision(18,6);
            Property(x => x.MinSpendLimit).HasColumnName("MinSpendLimit").IsRequired().HasColumnType("decimal").HasPrecision(18,6);
            Property(x => x.Iso4646Code).HasColumnName("ISO4646Code").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CustomCreativeParameter
    internal partial class CustomCreativeParameterMap : EntityTypeConfiguration<CustomCreativeParameter>
    {
        public CustomCreativeParameterMap()
            : this("dbo")
        {
        }
 
        public CustomCreativeParameterMap(string schema)
        {
            ToTable(schema + ".CustomCreativeParameter");
            HasKey(x => x.CustomCreativeParameterId);

            Property(x => x.CustomCreativeParameterId).HasColumnName("CustomCreativeParameterID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.MatchPredicate).HasColumnName("MatchPredicate").IsRequired().HasColumnType("nvarchar").HasMaxLength(2000);
            Property(x => x.CreativeParameterKey).HasColumnName("CreativeParameterKey").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.CreativeParameterValue).HasColumnName("CreativeParameterValue").IsRequired().HasColumnType("nvarchar").HasMaxLength(2000);

            // Foreign keys
            HasRequired(a => a.BuyerAccount).WithMany(b => b.CustomCreativeParameters).HasForeignKey(c => c.BuyerAccountId); // FK_BuyerAccountID
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CustomCreativeTechnology
    internal partial class CustomCreativeTechnologyMap : EntityTypeConfiguration<CustomCreativeTechnology>
    {
        public CustomCreativeTechnologyMap()
            : this("dbo")
        {
        }
 
        public CustomCreativeTechnologyMap(string schema)
        {
            ToTable(schema + ".CustomCreativeTechnology");
            HasKey(x => x.CustomCreativeTechnologyId);

            Property(x => x.CustomCreativeTechnologyId).HasColumnName("CustomCreativeTechnologyID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.MatchPredicate).HasColumnName("MatchPredicate").IsRequired().HasColumnType("nvarchar").HasMaxLength(2000);
            Property(x => x.TechnologyId).HasColumnName("TechnologyID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.Technology).WithMany(b => b.CustomCreativeTechnologies).HasForeignKey(c => c.TechnologyId); // FK_CustomCreativeTechnology_Technology
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CustomPublisherList
    internal partial class CustomPublisherListMap : EntityTypeConfiguration<CustomPublisherList>
    {
        public CustomPublisherListMap()
            : this("dbo")
        {
        }
 
        public CustomPublisherListMap(string schema)
        {
            ToTable(schema + ".CustomPublisherList");
            HasKey(x => x.CustomPublisherListId);

            Property(x => x.CustomPublisherListId).HasColumnName("CustomPublisherListID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ListName).HasColumnName("ListName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.CloneFromCustomPublisherListId).HasColumnName("CloneFromCustomPublisherListID").IsOptional().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.BuyerAccount).WithMany(b => b.CustomPublisherLists_BuyerAccountId).HasForeignKey(c => c.BuyerAccountId); // FK_CustomPublisherList_BuyerAccountID
            HasMany(t => t.Publishers).WithMany(t => t.CustomPublisherLists).Map(m => 
            {
                m.ToTable("CustomPublisherListPublisher", "dbo");
                m.MapLeftKey("CustomPublisherListID");
                m.MapRightKey("PublisherID");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CustomWhiteList
    internal partial class CustomWhiteListMap : EntityTypeConfiguration<CustomWhiteList>
    {
        public CustomWhiteListMap()
            : this("dbo")
        {
        }
 
        public CustomWhiteListMap(string schema)
        {
            ToTable(schema + ".CustomWhiteList");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ListName).HasColumnName("ListName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.CloneFromCustomWhiteListId).HasColumnName("CloneFromCustomWhiteListID").IsOptional().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.BuyerAccount).WithMany(b => b.CustomWhiteLists).HasForeignKey(c => c.BuyerAccountId); // FK_CustomWhiteList_BuyerAccount
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CustomWhiteListChangeLog
    internal partial class CustomWhiteListChangeLogMap : EntityTypeConfiguration<CustomWhiteListChangeLog>
    {
        public CustomWhiteListChangeLogMap()
            : this("dbo")
        {
        }
 
        public CustomWhiteListChangeLogMap(string schema)
        {
            ToTable(schema + ".CustomWhiteListChangeLog");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("ID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CustomWhiteListId).HasColumnName("CustomWhiteListID").IsRequired().HasColumnType("int");
            Property(x => x.WebsiteUrl).HasColumnName("WebsiteUrl").IsRequired().HasColumnType("nvarchar").HasMaxLength(450);
            Property(x => x.Operation).HasColumnName("Operation").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UserId).HasColumnName("UserID").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.ActualUserId).HasColumnName("ActualUserID").IsOptional().HasColumnType("uniqueidentifier");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // CustomWhiteListWebsite
    internal partial class CustomWhiteListWebsiteMap : EntityTypeConfiguration<CustomWhiteListWebsite>
    {
        public CustomWhiteListWebsiteMap()
            : this("dbo")
        {
        }
 
        public CustomWhiteListWebsiteMap(string schema)
        {
            ToTable(schema + ".CustomWhiteListWebsite");
            HasKey(x => new { x.CustomWhiteListId, x.WebsiteId });

            Property(x => x.CustomWhiteListId).HasColumnName("CustomWhiteListID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.WebsiteUrl).HasColumnName("WebsiteUrl").IsRequired().HasColumnType("nvarchar").HasMaxLength(450);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // DataSegmentView
    internal partial class DataSegmentViewMap : EntityTypeConfiguration<DataSegmentView>
    {
        public DataSegmentViewMap()
            : this("dbo")
        {
        }
 
        public DataSegmentViewMap(string schema)
        {
            ToTable(schema + ".DataSegmentView");
            HasKey(x => new { x.AdvertiserId, x.AdvertiserName, x.SegmentId, x.SegmentTypeId, x.CampaignStatusId, x.IsDeleted, x.RtbSegmentId, x.AdvertiserUuId });

            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsOptional().HasColumnType("int");
            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsRequired().HasColumnType("int");
            Property(x => x.AdvertiserName).HasColumnName("AdvertiserName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.SegmentId).HasColumnName("SegmentID").IsRequired().HasColumnType("int");
            Property(x => x.SegmentName).HasColumnName("SegmentName").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.SegmentTypeId).HasColumnName("SegmentTypeID").IsRequired().HasColumnType("int");
            Property(x => x.DeliveredUniques).HasColumnName("DeliveredUniques").IsOptional().HasColumnType("int");
            Property(x => x.RecencyInDays).HasColumnName("RecencyInDays").IsOptional().HasColumnType("int");
            Property(x => x.CampaignStatusId).HasColumnName("CampaignStatusID").IsRequired().HasColumnType("int");
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");
            Property(x => x.RtbSegmentId).HasColumnName("RtbSegmentId").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            Property(x => x.AdvertiserUuId).HasColumnName("AdvertiserUuID").IsRequired().HasColumnType("uniqueidentifier");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // DayPart
    internal partial class DayPartMap : EntityTypeConfiguration<DayPart>
    {
        public DayPartMap()
            : this("dbo")
        {
        }
 
        public DayPartMap(string schema)
        {
            ToTable(schema + ".DayPart");
            HasKey(x => x.DayPartId);

            Property(x => x.DayPartId).HasColumnName("DayPartID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DayPartName).HasColumnName("DayPartName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.DayOfWeekName).HasColumnName("DayOfWeekName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.HourOfDayName).HasColumnName("HourOfDayName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.IsEnabled).HasColumnName("IsEnabled").IsRequired().HasColumnType("bit");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Deal
    internal partial class DealMap : EntityTypeConfiguration<Deal>
    {
        public DealMap()
            : this("dbo")
        {
        }
 
        public DealMap(string schema)
        {
            ToTable(schema + ".Deal");
            HasKey(x => x.DealId);

            Property(x => x.DealId).HasColumnName("DealID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DealKey).HasColumnName("DealKey").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.DealName).HasColumnName("DealName").IsRequired().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.DealTypeId).HasColumnName("DealTypeID").IsRequired().HasColumnType("int");
            Property(x => x.FloorPriceCents).HasColumnName("FloorPriceCents").IsRequired().HasColumnType("int");
            Property(x => x.CeilingPriceCents).HasColumnName("CeilingPriceCents").IsRequired().HasColumnType("int");
            Property(x => x.UtcStartDateTime).HasColumnName("UtcStartDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcEndDateTime).HasColumnName("UtcEndDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.DealStatusId).HasColumnName("DealStatusID").IsRequired().HasColumnType("int");
            Property(x => x.DealUuid).HasColumnName("DealUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsOptional().HasColumnType("datetime");
            Property(x => x.CurrencyId).HasColumnName("CurrencyID").IsRequired().HasColumnType("int");
            Property(x => x.PublishersName).HasColumnName("PublishersName").IsOptional().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.DealModeId).HasColumnName("DealModeID").IsRequired().HasColumnType("int");
            Property(x => x.OverrideDisplayUrl).HasColumnName("OverrideDisplayUrl").IsOptional().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.VerticalId).HasColumnName("VerticalID").IsOptional().HasColumnType("int");
            Property(x => x.DealReference).HasColumnName("DealReference").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);

            // Foreign keys
            HasOptional(a => a.Vertical).WithMany(b => b.Deals).HasForeignKey(c => c.VerticalId); // FK_Deal_Vertical
            HasRequired(a => a.BuyerAccount).WithMany(b => b.Deals).HasForeignKey(c => c.BuyerAccountId); // FK_Deal_BuyerAccount
            HasRequired(a => a.CampaignStatus).WithMany(b => b.Deals).HasForeignKey(c => c.DealStatusId); // FK_Deal_CampaignStatus
            HasRequired(a => a.Currency).WithMany(b => b.Deals).HasForeignKey(c => c.CurrencyId); // FK_Deal_Currency
            HasRequired(a => a.DealMode).WithMany(b => b.Deals).HasForeignKey(c => c.DealModeId); // FK_Deal_DealMode
            HasRequired(a => a.DealType).WithMany(b => b.Deals).HasForeignKey(c => c.DealTypeId); // FK_Deal_DealType
            HasRequired(a => a.Publisher).WithMany(b => b.Deals).HasForeignKey(c => c.PublisherId); // FK_Deal_Publisher
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // DealMode
    internal partial class DealModeMap : EntityTypeConfiguration<DealMode>
    {
        public DealModeMap()
            : this("dbo")
        {
        }
 
        public DealModeMap(string schema)
        {
            ToTable(schema + ".DealMode");
            HasKey(x => x.DealModeId);

            Property(x => x.DealModeId).HasColumnName("DealModeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DealModeName).HasColumnName("DealModeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(255);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // DealPerformance
    internal partial class DealPerformanceMap : EntityTypeConfiguration<DealPerformance>
    {
        public DealPerformanceMap()
            : this("dbo")
        {
        }
 
        public DealPerformanceMap(string schema)
        {
            ToTable(schema + ".DealPerformance");
            HasKey(x => new { x.DealId, x.IntervalId, x.IntervalValue });

            Property(x => x.DealId).HasColumnName("DealID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalId).HasColumnName("IntervalID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalValue).HasColumnName("IntervalValue").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Bids).HasColumnName("Bids").IsRequired().HasColumnType("bigint");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Clicks).HasColumnName("Clicks").IsRequired().HasColumnType("bigint");
            Property(x => x.Conversions).HasColumnName("Conversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostViewConversions).HasColumnName("PostViewConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostClickConversions).HasColumnName("PostClickConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.LastActivityTimestamp).HasColumnName("LastActivityTimestamp").IsOptional().HasColumnType("datetime");
            Property(x => x.Ctr).HasColumnName("CTR").IsOptional().HasColumnType("float").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaCostLocalMicros).HasColumnName("MediaCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataCostLocalMicros).HasColumnName("DataCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.SpendLocalMicros).HasColumnName("SpendLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaClientCostLocalMicros).HasColumnName("MediaClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataClientCostLocalMicros).HasColumnName("DataClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.ClientCostLocalMicros).HasColumnName("ClientCostLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpm).HasColumnName("CPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpc).HasColumnName("CPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpa).HasColumnName("CPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpm).HasColumnName("ClientCostCPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpc).HasColumnName("ClientCostCPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpa).HasColumnName("ClientCostCPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.PricingHealth).HasColumnName("PricingHealth").IsRequired().HasColumnType("int");
            Property(x => x.PacingHealth).HasColumnName("PacingHealth").IsRequired().HasColumnType("int");
            Property(x => x.Cvr).HasColumnName("Cvr").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.BidWin).HasColumnName("BidWin").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.AdSlotDurationInSeconds).HasColumnName("AdSlotDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.RawViews).HasColumnName("RawViews").IsRequired().HasColumnType("bigint");
            Property(x => x.IabViews).HasColumnName("IabViews").IsRequired().HasColumnType("bigint");
            Property(x => x.ViewDurationInSeconds).HasColumnName("ViewDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.CpMs).HasColumnName("CPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpMs).HasColumnName("ClientCostCPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cps).HasColumnName("CPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCps).HasColumnName("ClientCostCPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ViewableRatio).HasColumnName("ViewableRatio").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            // Foreign keys
            HasRequired(a => a.Deal).WithMany(b => b.DealPerformances).HasForeignKey(c => c.DealId); // FK_DealPerformance_Deal
            HasRequired(a => a.Interval).WithMany(b => b.DealPerformances).HasForeignKey(c => c.IntervalId); // FK_DealPerformance_Interval
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // DealType
    internal partial class DealTypeMap : EntityTypeConfiguration<DealType>
    {
        public DealTypeMap()
            : this("dbo")
        {
        }
 
        public DealTypeMap(string schema)
        {
            ToTable(schema + ".DealType");
            HasKey(x => x.DealTypeId);

            Property(x => x.DealTypeId).HasColumnName("DealTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DealTypeName).HasColumnName("DealTypeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(255);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Device
    internal partial class DeviceMap : EntityTypeConfiguration<Device>
    {
        public DeviceMap()
            : this("dbo")
        {
        }
 
        public DeviceMap(string schema)
        {
            ToTable(schema + ".Device");
            HasKey(x => x.DeviceId);

            Property(x => x.DeviceId).HasColumnName("DeviceID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DeviceName).HasColumnName("DeviceName").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Domain
    internal partial class DomainMap : EntityTypeConfiguration<Domain>
    {
        public DomainMap()
            : this("dbo")
        {
        }
 
        public DomainMap(string schema)
        {
            ToTable(schema + ".Domain");
            HasKey(x => new { x.DomainListId, x.DomainName });

            Property(x => x.DomainListId).HasColumnName("DomainListID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DomainName).HasColumnName("DomainName").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(64).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Comment).HasColumnName("Comment").IsOptional().HasColumnType("nvarchar").HasMaxLength(255);

            // Foreign keys
            HasRequired(a => a.DomainList).WithMany(b => b.Domains).HasForeignKey(c => c.DomainListId); // FK_Domain_DomainList
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // DomainList
    internal partial class DomainListMap : EntityTypeConfiguration<DomainList>
    {
        public DomainListMap()
            : this("dbo")
        {
        }
 
        public DomainListMap(string schema)
        {
            ToTable(schema + ".DomainList");
            HasKey(x => x.DomainListId);

            Property(x => x.DomainListId).HasColumnName("DomainListID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DomainListName).HasColumnName("DomainListName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsOptional().HasColumnType("int");
            Property(x => x.CloneFromDomainListId).HasColumnName("CloneFromDomainListID").IsOptional().HasColumnType("int");
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsOptional().HasColumnType("int");
            Property(x => x.DomainListType).HasColumnName("DomainListType").IsRequired().HasColumnType("int");
            Property(x => x.Description).HasColumnName("Description").IsOptional().HasColumnType("nvarchar").HasMaxLength(255);
            Property(x => x.Owner).HasColumnName("Owner").IsOptional().HasColumnType("nvarchar").HasMaxLength(255);
            Property(x => x.SiteCount).HasColumnName("SiteCount").IsOptional().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.BuyerAccount).WithMany(b => b.DomainLists).HasForeignKey(c => c.BuyerAccountId); // FK_DomainList_BuyerAccount
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // DomainListInvertedIndexes
    internal partial class DomainListInvertedIndexMap : EntityTypeConfiguration<DomainListInvertedIndex>
    {
        public DomainListInvertedIndexMap()
            : this("dbo")
        {
        }
 
        public DomainListInvertedIndexMap(string schema)
        {
            ToTable(schema + ".DomainListInvertedIndexes");
            HasKey(x => x.DomainName);

            Property(x => x.DomainName).HasColumnName("DomainName").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(64);
            Property(x => x.DomainListIDs).HasColumnName("DomainListIDs").IsOptional().HasColumnType("nvarchar");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // DoohChannel
    internal partial class DoohChannelMap : EntityTypeConfiguration<DoohChannel>
    {
        public DoohChannelMap()
            : this("dbo")
        {
        }
 
        public DoohChannelMap(string schema)
        {
            ToTable(schema + ".DoohChannel");
            HasKey(x => x.DoohChannelId);

            Property(x => x.DoohChannelId).HasColumnName("DoohChannelID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ChannelName).HasColumnName("ChannelName").IsRequired().HasColumnType("nvarchar").HasMaxLength(250);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // DoohFormat
    internal partial class DoohFormatMap : EntityTypeConfiguration<DoohFormat>
    {
        public DoohFormatMap()
            : this("dbo")
        {
        }
 
        public DoohFormatMap(string schema)
        {
            ToTable(schema + ".DoohFormat");
            HasKey(x => x.DoohFormatId);

            Property(x => x.DoohFormatId).HasColumnName("DoohFormatID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FormatName).HasColumnName("FormatName").IsOptional().HasColumnType("nvarchar").HasMaxLength(250);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // DoohGeoLocationGroup
    internal partial class DoohGeoLocationGroupMap : EntityTypeConfiguration<DoohGeoLocationGroup>
    {
        public DoohGeoLocationGroupMap()
            : this("dbo")
        {
        }
 
        public DoohGeoLocationGroupMap(string schema)
        {
            ToTable(schema + ".DoohGeoLocationGroup");
            HasKey(x => x.DoohGeoLocationGroupId);

            Property(x => x.DoohGeoLocationGroupId).HasColumnName("DoohGeoLocationGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.GeoCountryId).HasColumnName("GeoCountryID").IsRequired().HasColumnType("int");
            Property(x => x.GeoRegionId).HasColumnName("GeoRegionID").IsOptional().HasColumnType("int");
            Property(x => x.GeoCityId).HasColumnName("GeoCityID").IsOptional().HasColumnType("int");
            Property(x => x.LocationGroupName).HasColumnName("LocationGroupName").IsRequired().HasColumnType("nvarchar").HasMaxLength(250);
            Property(x => x.GeoLocationId).HasColumnName("GeoLocationID").IsRequired().HasColumnType("int");
            Property(x => x.Latitude).HasColumnName("Latitude").IsOptional().HasColumnType("decimal").HasPrecision(11,7);
            Property(x => x.Longitude).HasColumnName("Longitude").IsOptional().HasColumnType("decimal").HasPrecision(11,7);
            Property(x => x.RadiusInKm).HasColumnName("RadiusInKm").IsOptional().HasColumnType("decimal").HasPrecision(6,2);

            // Foreign keys
            HasOptional(a => a.GeoCity).WithMany(b => b.DoohGeoLocationGroups).HasForeignKey(c => c.GeoCityId); // FK_DoohGeoLocationGroup_GeoCity
            HasOptional(a => a.GeoRegion).WithMany(b => b.DoohGeoLocationGroups).HasForeignKey(c => c.GeoRegionId); // FK_DoohGeoLocationGroup_GeoRegion
            HasRequired(a => a.GeoCountry).WithMany(b => b.DoohGeoLocationGroups).HasForeignKey(c => c.GeoCountryId); // FK_DoohGeoLocationGroup_GeoCountry
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // DoohLocation
    internal partial class DoohLocationMap : EntityTypeConfiguration<DoohLocation>
    {
        public DoohLocationMap()
            : this("dbo")
        {
        }
 
        public DoohLocationMap(string schema)
        {
            ToTable(schema + ".DoohLocation");
            HasKey(x => x.DoohLocationId);

            Property(x => x.DoohLocationId).HasColumnName("DoohLocationID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DoohGeoLocationGroupId).HasColumnName("DoohGeoLocationGroupID").IsRequired().HasColumnType("int");
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasColumnType("nvarchar").HasMaxLength(250);
            Property(x => x.Latitude).HasColumnName("Latitude").IsOptional().HasColumnType("decimal").HasPrecision(11,7);
            Property(x => x.Longitude).HasColumnName("Longitude").IsOptional().HasColumnType("decimal").HasPrecision(11,7);
            Property(x => x.RadiusInKm).HasColumnName("RadiusInKm").IsOptional().HasColumnType("decimal").HasPrecision(6,2);

            // Foreign keys
            HasRequired(a => a.DoohGeoLocationGroup).WithMany(b => b.DoohLocations).HasForeignKey(c => c.DoohGeoLocationGroupId); // FK_DoohLocation_DoohGeoLocationGroup
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // DoohPanel
    internal partial class DoohPanelMap : EntityTypeConfiguration<DoohPanel>
    {
        public DoohPanelMap()
            : this("dbo")
        {
        }
 
        public DoohPanelMap(string schema)
        {
            ToTable(schema + ".DoohPanel");
            HasKey(x => x.DoohPanelId);

            Property(x => x.DoohPanelId).HasColumnName("DoohPanelID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DoohChannelId).HasColumnName("DoohChannelID").IsRequired().HasColumnType("int");
            Property(x => x.DoohFormatId).HasColumnName("DoohFormatID").IsRequired().HasColumnType("int");
            Property(x => x.CreativeSizeId).HasColumnName("CreativeSizeID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.CreativeSize).WithMany(b => b.DoohPanels).HasForeignKey(c => c.CreativeSizeId); // FK_DoohPanel_CreativeSize
            HasRequired(a => a.DoohChannel).WithMany(b => b.DoohPanels).HasForeignKey(c => c.DoohChannelId); // FK_DoohPanel_DoohChannel
            HasRequired(a => a.DoohFormat).WithMany(b => b.DoohPanels).HasForeignKey(c => c.DoohFormatId); // FK_DoohPanel_DoohFormat
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // DoohPanelLocation
    internal partial class DoohPanelLocationMap : EntityTypeConfiguration<DoohPanelLocation>
    {
        public DoohPanelLocationMap()
            : this("dbo")
        {
        }
 
        public DoohPanelLocationMap(string schema)
        {
            ToTable(schema + ".DoohPanelLocation");
            HasKey(x => x.DoohPanelLocationId);

            Property(x => x.DoohPanelLocationId).HasColumnName("DOOHPanelLocationID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DoohPanelId).HasColumnName("DoohPanelID").IsRequired().HasColumnType("int");
            Property(x => x.DoohLocationId).HasColumnName("DoohLocationID").IsRequired().HasColumnType("int");
            Property(x => x.PanelUrl).HasColumnName("PanelUrl").IsRequired().HasColumnType("nvarchar").HasMaxLength(128);
            Property(x => x.PanelId).HasColumnName("PanelID").IsOptional().HasColumnType("nvarchar").HasMaxLength(32);
            Property(x => x.PanelLocationName).HasColumnName("PanelLocationName").IsOptional().HasColumnType("nvarchar").HasMaxLength(255);
            Property(x => x.AudienceSize).HasColumnName("AudienceSize").IsOptional().HasColumnType("bigint");
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.DoohLocation).WithMany(b => b.DoohPanelLocations).HasForeignKey(c => c.DoohLocationId); // FK_DoohPanelLocation_DoohLocation
            HasRequired(a => a.DoohPanel).WithMany(b => b.DoohPanelLocations).HasForeignKey(c => c.DoohPanelId); // FK_DoohPanelLocation_DoohPanel
            HasRequired(a => a.Partner).WithMany(b => b.DoohPanelLocations).HasForeignKey(c => c.PartnerId); // FK_DoohPanelLocation_Partner
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // EntityLabel
    internal partial class EntityLabelMap : EntityTypeConfiguration<EntityLabel>
    {
        public EntityLabelMap()
            : this("dbo")
        {
        }
 
        public EntityLabelMap(string schema)
        {
            ToTable(schema + ".EntityLabel");
            HasKey(x => new { x.EntityId, x.LabelId, x.EntityType });

            Property(x => x.EntityId).HasColumnName("EntityId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.LabelId).HasColumnName("LabelId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.EntityType).HasColumnName("EntityType").IsRequired().HasColumnType("tinyint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.Label).WithMany(b => b.EntityLabels).HasForeignKey(c => c.LabelId); // FK_EntityLabel_Label
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // EntityUserTag
    internal partial class EntityUserTagMap : EntityTypeConfiguration<EntityUserTag>
    {
        public EntityUserTagMap()
            : this("dbo")
        {
        }
 
        public EntityUserTagMap(string schema)
        {
            ToTable(schema + ".EntityUserTag");
            HasKey(x => new { x.EntityId, x.UserTagId, x.EntityType });

            Property(x => x.EntityId).HasColumnName("EntityId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.UserTagId).HasColumnName("UserTagId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.EntityType).HasColumnName("EntityType").IsRequired().HasColumnType("tinyint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.UserTag).WithMany(b => b.EntityUserTags).HasForeignKey(c => c.UserTagId); // FK_EntityUserTag_UserTag
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ExchangeBuyerIDLookup
    internal partial class ExchangeBuyerIdLookupMap : EntityTypeConfiguration<ExchangeBuyerIdLookup>
    {
        public ExchangeBuyerIdLookupMap()
            : this("dbo")
        {
        }
 
        public ExchangeBuyerIdLookupMap(string schema)
        {
            ToTable(schema + ".ExchangeBuyerIDLookup");
            HasKey(x => new { x.PackageKey, x.Value, x.BuyerAccountId });

            Property(x => x.PackageKey).HasColumnName("PackageKey").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Value).HasColumnName("Value").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ExchangeConfiguration
    internal partial class ExchangeConfigurationMap : EntityTypeConfiguration<ExchangeConfiguration>
    {
        public ExchangeConfigurationMap()
            : this("dbo")
        {
        }
 
        public ExchangeConfigurationMap(string schema)
        {
            ToTable(schema + ".ExchangeConfiguration");
            HasKey(x => x.PartnerId);

            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.NoContentOnNoBid).HasColumnName("NoContentOnNoBid").IsRequired().HasColumnType("bit");
            Property(x => x.CurrencyCode).HasColumnName("CurrencyCode").IsRequired().IsFixedLength().IsUnicode(false).HasColumnType("char").HasMaxLength(3);
            Property(x => x.EncryptionKey).HasColumnName("EncryptionKey").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.IntegrityKey).HasColumnName("IntegrityKey").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.IsLive).HasColumnName("IsLive").IsRequired().HasColumnType("bit");
            Property(x => x.BidRatio).HasColumnName("BidRatio").IsRequired().HasColumnType("int");
            Property(x => x.ClickUrlMacro).HasColumnName("ClickUrlMacro").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.AuctionPriceMacro).HasColumnName("AuctionPriceMacro").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.PriceEncryptionMethod).HasColumnName("PriceEncryptionMethod").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.Partner).WithOptional(b => b.ExchangeConfiguration); // FK_ExchangeConfiguration_Partner
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ExelateImport
    internal partial class ExelateImportMap : EntityTypeConfiguration<ExelateImport>
    {
        public ExelateImportMap()
            : this("dbo")
        {
        }
 
        public ExelateImportMap(string schema)
        {
            ToTable(schema + ".ExelateImport");
            HasKey(x => x.RtbSegmentId);

            Property(x => x.RtbSegmentId).HasColumnName("RtbSegmentID").IsRequired().HasColumnType("nvarchar").HasMaxLength(80).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ExelateSegmentId).HasColumnName("ExelateSegmentID").IsRequired().HasColumnType("int");
            Property(x => x.SegmentName).HasColumnName("SegmentName").IsRequired().HasColumnType("nvarchar").HasMaxLength(1000);
            Property(x => x.ParentRtbSegmentId).HasColumnName("ParentRtbSegmentID").IsOptional().HasColumnType("nvarchar").HasMaxLength(80);
            Property(x => x.HasChildren).HasColumnName("HasChildren").IsRequired().HasColumnType("bit");
            Property(x => x.IsSelectable).HasColumnName("IsSelectable").IsRequired().HasColumnType("bit");
            Property(x => x.Cost).HasColumnName("Cost").IsRequired().HasColumnType("decimal").HasPrecision(19,2);
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ExpandableAction
    internal partial class ExpandableActionMap : EntityTypeConfiguration<ExpandableAction>
    {
        public ExpandableActionMap()
            : this("dbo")
        {
        }
 
        public ExpandableActionMap(string schema)
        {
            ToTable(schema + ".ExpandableAction");
            HasKey(x => x.ExpandableActionId);

            Property(x => x.ExpandableActionId).HasColumnName("ExpandableActionID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ActionName).HasColumnName("ActionName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ExpandableDirection
    internal partial class ExpandableDirectionMap : EntityTypeConfiguration<ExpandableDirection>
    {
        public ExpandableDirectionMap()
            : this("dbo")
        {
        }
 
        public ExpandableDirectionMap(string schema)
        {
            ToTable(schema + ".ExpandableDirection");
            HasKey(x => x.ExpandableDirectionId);

            Property(x => x.ExpandableDirectionId).HasColumnName("ExpandableDirectionID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DirectionName).HasColumnName("DirectionName").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // EyeotaRateCard
    internal partial class EyeotaRateCardMap : EntityTypeConfiguration<EyeotaRateCard>
    {
        public EyeotaRateCardMap()
            : this("dbo")
        {
        }
 
        public EyeotaRateCardMap(string schema)
        {
            ToTable(schema + ".EyeotaRateCard");
            HasKey(x => x.SegmentId);

            Property(x => x.SegmentId).HasColumnName("SegmentID").IsRequired().HasColumnType("nvarchar").HasMaxLength(80).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Price).HasColumnName("Price").IsRequired().HasColumnType("decimal").HasPrecision(19,4);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // EyeotaTaxonomyImport
    internal partial class EyeotaTaxonomyImportMap : EntityTypeConfiguration<EyeotaTaxonomyImport>
    {
        public EyeotaTaxonomyImportMap()
            : this("dbo")
        {
        }
 
        public EyeotaTaxonomyImportMap(string schema)
        {
            ToTable(schema + ".EyeotaTaxonomyImport");
            HasKey(x => x.SegmentId);

            Property(x => x.SegmentId).HasColumnName("SegmentID").IsRequired().HasColumnType("nvarchar").HasMaxLength(80).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ParentSegmentId).HasColumnName("ParentSegmentID").IsRequired().HasColumnType("nvarchar").HasMaxLength(80);
            Property(x => x.SegmentName).HasColumnName("SegmentName").IsRequired().HasColumnType("nvarchar").HasMaxLength(1000);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // FrequencyCap
    internal partial class FrequencyCapMap : EntityTypeConfiguration<FrequencyCap>
    {
        public FrequencyCapMap()
            : this("dbo")
        {
        }
 
        public FrequencyCapMap(string schema)
        {
            ToTable(schema + ".FrequencyCap");
            HasKey(x => x.FrequencyCapId);

            Property(x => x.FrequencyCapId).HasColumnName("FrequencyCapID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FrequencyGroupId).HasColumnName("FrequencyGroupID").IsRequired().HasColumnType("int");
            Property(x => x.Amount).HasColumnName("Amount").IsRequired().HasColumnType("int");
            Property(x => x.Duration).HasColumnName("Duration").IsRequired().HasColumnType("int");
            Property(x => x.PeriodId).HasColumnName("PeriodID").IsRequired().HasColumnType("int");
            Property(x => x.Mode).HasColumnName("Mode").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.CampaignPeriod).WithMany(b => b.FrequencyCaps).HasForeignKey(c => c.PeriodId); // FK_FrequencyCap_CampaignPeriod
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // FrequencyGroup
    internal partial class FrequencyGroupMap : EntityTypeConfiguration<FrequencyGroup>
    {
        public FrequencyGroupMap()
            : this("dbo")
        {
        }
 
        public FrequencyGroupMap(string schema)
        {
            ToTable(schema + ".FrequencyGroup");
            HasKey(x => x.FrequencyGroupId);

            Property(x => x.FrequencyGroupId).HasColumnName("FrequencyGroupID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FrequencyGroupName).HasColumnName("FrequencyGroupName").IsRequired().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");

            // Foreign keys
            HasRequired(a => a.BuyerAccount).WithMany(b => b.FrequencyGroups).HasForeignKey(c => c.BuyerAccountId); // FK_FrequencyGroup_BuyerAccount
            HasRequired(a => a.Campaign).WithMany(b => b.FrequencyGroups).HasForeignKey(c => c.CampaignId); // FK_FrequencyGroup_Campaign
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // GeoABSRegion
    internal partial class GeoAbsRegionMap : EntityTypeConfiguration<GeoAbsRegion>
    {
        public GeoAbsRegionMap()
            : this("dbo")
        {
        }
 
        public GeoAbsRegionMap(string schema)
        {
            ToTable(schema + ".GeoABSRegion");
            HasKey(x => x.GeoAbsRegionId);

            Property(x => x.GeoAbsRegionId).HasColumnName("GeoABSRegionID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Sa4Name).HasColumnName("SA4Name").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.StateCode).HasColumnName("StateCode").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.StateName).HasColumnName("StateName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            HasMany(t => t.GeoLocations).WithMany(t => t.GeoAbsRegions).Map(m => 
            {
                m.ToTable("GeoABSRegionGeoLocationMapping", "dbo");
                m.MapLeftKey("GeoABSRegionID");
                m.MapRightKey("GeoLocationID");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // GeoCity
    internal partial class GeoCityMap : EntityTypeConfiguration<GeoCity>
    {
        public GeoCityMap()
            : this("dbo")
        {
        }
 
        public GeoCityMap(string schema)
        {
            ToTable(schema + ".GeoCity");
            HasKey(x => x.GeoCityId);

            Property(x => x.GeoCityId).HasColumnName("GeoCityID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.GeoCountryId).HasColumnName("GeoCountryID").IsRequired().HasColumnType("int");
            Property(x => x.GeoRegionId).HasColumnName("GeoRegionID").IsOptional().HasColumnType("int");
            Property(x => x.GeoMetroId).HasColumnName("GeoMetroID").IsOptional().HasColumnType("int");
            Property(x => x.CityName).HasColumnName("CityName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Latitude).HasColumnName("Latitude").IsRequired().HasColumnType("float");
            Property(x => x.Longitude).HasColumnName("Longitude").IsRequired().HasColumnType("float");
            Property(x => x.GeoLocationId).HasColumnName("GeoLocationID").IsOptional().HasColumnType("bigint");

            // Foreign keys
            HasOptional(a => a.GeoLocation).WithMany(b => b.GeoCities).HasForeignKey(c => c.GeoLocationId); // FK_GeoCity_GeoLocation
            HasOptional(a => a.GeoMetro).WithMany(b => b.GeoCities).HasForeignKey(c => c.GeoMetroId); // FK_GeoCity_GeoMetro
            HasOptional(a => a.GeoRegion).WithMany(b => b.GeoCities).HasForeignKey(c => c.GeoRegionId); // FK_GeoCity_GeoRegion
            HasRequired(a => a.GeoCountry).WithMany(b => b.GeoCities).HasForeignKey(c => c.GeoCountryId); // FK_GeoCity_GeoCountry
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // GeoCountry
    internal partial class GeoCountryMap : EntityTypeConfiguration<GeoCountry>
    {
        public GeoCountryMap()
            : this("dbo")
        {
        }
 
        public GeoCountryMap(string schema)
        {
            ToTable(schema + ".GeoCountry");
            HasKey(x => x.GeoCountryId);

            Property(x => x.GeoCountryId).HasColumnName("GeoCountryID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Iso3166Code).HasColumnName("ISO3166Code").IsRequired().IsFixedLength().IsUnicode(false).HasColumnType("char").HasMaxLength(3);
            Property(x => x.CountryName).HasColumnName("CountryName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.GeoLocationId).HasColumnName("GeoLocationID").IsOptional().HasColumnType("bigint");

            // Foreign keys
            HasOptional(a => a.GeoLocation).WithMany(b => b.GeoCountries).HasForeignKey(c => c.GeoLocationId); // FK_GeoCountry_GeoLocation
            HasMany(t => t.SalesRegions).WithMany(t => t.GeoCountries).Map(m => 
            {
                m.ToTable("CountrySalesRegion", "dbo");
                m.MapLeftKey("GeoCountryID");
                m.MapRightKey("SalesRegionID");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // GeoLocation
    internal partial class GeoLocationMap : EntityTypeConfiguration<GeoLocation>
    {
        public GeoLocationMap()
            : this("dbo")
        {
        }
 
        public GeoLocationMap(string schema)
        {
            ToTable(schema + ".GeoLocation");
            HasKey(x => x.GeoLocationId);

            Property(x => x.GeoLocationId).HasColumnName("GeoLocationID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.GeoLocationCode).HasColumnName("GeoLocationCode").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.GeoCountryId).HasColumnName("GeoCountryID").IsRequired().HasColumnType("int");
            Property(x => x.GeoRegionId).HasColumnName("GeoRegionID").IsOptional().HasColumnType("int");
            Property(x => x.GeoMetroId).HasColumnName("GeoMetroID").IsOptional().HasColumnType("int");
            Property(x => x.GeoCityId).HasColumnName("GeoCityID").IsOptional().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.GeoCity).WithMany(b => b.GeoLocations).HasForeignKey(c => c.GeoCityId); // FK_GeoLocation_GeoCity
            HasOptional(a => a.GeoMetro).WithMany(b => b.GeoLocations).HasForeignKey(c => c.GeoMetroId); // FK_GeoLocation_GeoMetro
            HasOptional(a => a.GeoRegion).WithMany(b => b.GeoLocations).HasForeignKey(c => c.GeoRegionId); // FK_GeoLocation_GeoRegion
            HasRequired(a => a.GeoCountry).WithMany(b => b.GeoLocations).HasForeignKey(c => c.GeoCountryId); // FK_GeoLocation_GeoCountry
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // GeoMetro
    internal partial class GeoMetroMap : EntityTypeConfiguration<GeoMetro>
    {
        public GeoMetroMap()
            : this("dbo")
        {
        }
 
        public GeoMetroMap(string schema)
        {
            ToTable(schema + ".GeoMetro");
            HasKey(x => x.GeoMetroId);

            Property(x => x.GeoMetroId).HasColumnName("GeoMetroID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.GeoCountryId).HasColumnName("GeoCountryID").IsRequired().HasColumnType("int");
            Property(x => x.MetroName).HasColumnName("MetroName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);

            // Foreign keys
            HasRequired(a => a.GeoCountry).WithMany(b => b.GeoMetroes).HasForeignKey(c => c.GeoCountryId); // FK_GeoMetro_GeoCountry
            HasMany(t => t.GeoRegions).WithMany(t => t.GeoMetroes).Map(m => 
            {
                m.ToTable("GeoRegionMetro", "dbo");
                m.MapLeftKey("GeoMetroID");
                m.MapRightKey("GeoRegionID");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // GeoRegion
    internal partial class GeoRegionMap : EntityTypeConfiguration<GeoRegion>
    {
        public GeoRegionMap()
            : this("dbo")
        {
        }
 
        public GeoRegionMap(string schema)
        {
            ToTable(schema + ".GeoRegion");
            HasKey(x => x.GeoRegionId);

            Property(x => x.GeoRegionId).HasColumnName("GeoRegionID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.GeoCountryId).HasColumnName("GeoCountryID").IsRequired().HasColumnType("int");
            Property(x => x.RegionCode).HasColumnName("RegionCode").IsRequired().HasColumnType("nvarchar").HasMaxLength(10);
            Property(x => x.RegionName).HasColumnName("RegionName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.RegionShortName).HasColumnName("RegionShortName").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.GeoLocationId).HasColumnName("GeoLocationID").IsOptional().HasColumnType("bigint");

            // Foreign keys
            HasOptional(a => a.GeoLocation).WithMany(b => b.GeoRegions).HasForeignKey(c => c.GeoLocationId); // FK_GeoRegion_GeoLocation
            HasRequired(a => a.GeoCountry).WithMany(b => b.GeoRegions).HasForeignKey(c => c.GeoCountryId); // FK_GeoRegion_GeoCountry
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // GeoSuburb
    internal partial class GeoSuburbMap : EntityTypeConfiguration<GeoSuburb>
    {
        public GeoSuburbMap()
            : this("dbo")
        {
        }
 
        public GeoSuburbMap(string schema)
        {
            ToTable(schema + ".GeoSuburb");
            HasKey(x => x.GeoSuburbId);

            Property(x => x.GeoSuburbId).HasColumnName("GeoSuburbID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.GeoAbsRegionId).HasColumnName("GeoABSRegionID").IsOptional().HasColumnType("int");
            Property(x => x.SuburbName).HasColumnName("SuburbName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Latitude).HasColumnName("Latitude").IsRequired().HasColumnType("float");
            Property(x => x.Longitude).HasColumnName("Longitude").IsRequired().HasColumnType("float");
            Property(x => x.GeoLocationId).HasColumnName("GeoLocationID").IsOptional().HasColumnType("bigint");

            // Foreign keys
            HasOptional(a => a.GeoAbsRegion).WithMany(b => b.GeoSuburbs).HasForeignKey(c => c.GeoAbsRegionId); // FK_GeoSuburb_GeoABSRegion
            HasOptional(a => a.GeoLocation).WithMany(b => b.GeoSuburbs).HasForeignKey(c => c.GeoLocationId); // FK_GeoSuburb_GeoLocation
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // GoalType
    internal partial class GoalTypeMap : EntityTypeConfiguration<GoalType>
    {
        public GoalTypeMap()
            : this("dbo")
        {
        }
 
        public GoalTypeMap(string schema)
        {
            ToTable(schema + ".GoalType");
            HasKey(x => x.GoalTypeId);

            Property(x => x.GoalTypeId).HasColumnName("GoalTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.GoalTypeName).HasColumnName("GoalTypeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // IkonProgrammaticReport
    internal partial class IkonProgrammaticReportMap : EntityTypeConfiguration<IkonProgrammaticReport>
    {
        public IkonProgrammaticReportMap()
            : this("dbo")
        {
        }
 
        public IkonProgrammaticReportMap(string schema)
        {
            ToTable(schema + ".IkonProgrammaticReport");
            HasKey(x => new { x.BuyeraccountId, x.IntervalValue, x.AdvertiserName, x.AdGroupId, x.AdGroupName, x.CampaignName, x.Impressions, x.Clicks, x.PostViewConversions, x.PostClickConversions, x.Conversions });

            Property(x => x.BuyeraccountId).HasColumnName("BuyeraccountId").IsRequired().HasColumnType("int");
            Property(x => x.IntervalValue).HasColumnName("IntervalValue").IsRequired().HasColumnType("int");
            Property(x => x.AdvertiserName).HasColumnName("AdvertiserName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.AdGroupName).HasColumnName("AdGroupName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.CampaignName).HasColumnName("CampaignName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.UtcStartDateTime).HasColumnName("UtcStartDateTime").IsOptional().HasColumnType("datetime");
            Property(x => x.UtcEndDateTime).HasColumnName("UtcEndDateTime").IsOptional().HasColumnType("datetime");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Clicks).HasColumnName("Clicks").IsRequired().HasColumnType("bigint");
            Property(x => x.PostViewConversions).HasColumnName("PostViewConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostClickConversions).HasColumnName("PostClickConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.Conversions).HasColumnName("Conversions").IsRequired().HasColumnType("bigint");
            Property(x => x.SpendLocalMicros).HasColumnName("SpendLocalMicros").IsOptional().HasColumnType("bigint");
            Property(x => x.ClientCostLocalMicros).HasColumnName("ClientCostLocalMicros").IsOptional().HasColumnType("bigint");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // IndustryCategory
    internal partial class IndustryCategoryMap : EntityTypeConfiguration<IndustryCategory>
    {
        public IndustryCategoryMap()
            : this("dbo")
        {
        }
 
        public IndustryCategoryMap(string schema)
        {
            ToTable(schema + ".IndustryCategory");
            HasKey(x => x.IndustryCategoryId);

            Property(x => x.IndustryCategoryId).HasColumnName("IndustryCategoryID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IndustryCategoryName).HasColumnName("IndustryCategoryName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType("bit");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Interval
    internal partial class IntervalMap : EntityTypeConfiguration<Interval>
    {
        public IntervalMap()
            : this("dbo")
        {
        }
 
        public IntervalMap(string schema)
        {
            ToTable(schema + ".Interval");
            HasKey(x => x.IntervalId);

            Property(x => x.IntervalId).HasColumnName("IntervalID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalName).HasColumnName("IntervalName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Inventory
    internal partial class InventoryMap : EntityTypeConfiguration<Inventory>
    {
        public InventoryMap()
            : this("dbo")
        {
        }
 
        public InventoryMap(string schema)
        {
            ToTable(schema + ".Inventory");
            HasKey(x => x.InventoryId);

            Property(x => x.InventoryId).HasColumnName("InventoryID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int");
            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("bigint");
            Property(x => x.WebsiteUrl).HasColumnName("WebsiteUrl").IsOptional().HasColumnType("nvarchar").HasMaxLength(450);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // JobHistory
    internal partial class JobHistoryMap : EntityTypeConfiguration<JobHistory>
    {
        public JobHistoryMap()
            : this("dbo")
        {
        }
 
        public JobHistoryMap(string schema)
        {
            ToTable(schema + ".JobHistory");
            HasKey(x => x.JobHistoryId);

            Property(x => x.JobId).HasColumnName("JobID").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.UtcDateTime).HasColumnName("UtcDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.JobHistoryId).HasColumnName("JobHistoryID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Label
    internal partial class LabelMap : EntityTypeConfiguration<Label>
    {
        public LabelMap()
            : this("dbo")
        {
        }
 
        public LabelMap(string schema)
        {
            ToTable(schema + ".Label");
            HasKey(x => x.LabelId);

            Property(x => x.LabelId).HasColumnName("LabelId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.LabelName).HasColumnName("LabelName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountId").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.BuyerAccount).WithMany(b => b.Labels).HasForeignKey(c => c.BuyerAccountId); // FK_Label_BuyerAccount
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Language
    internal partial class LanguageMap : EntityTypeConfiguration<Language>
    {
        public LanguageMap()
            : this("dbo")
        {
        }
 
        public LanguageMap(string schema)
        {
            ToTable(schema + ".Language");
            HasKey(x => x.LanguageId);

            Property(x => x.LanguageId).HasColumnName("LanguageID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Iso4646Code).HasColumnName("ISO4646Code").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.LanguageName).HasColumnName("LanguageName").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Position).HasColumnName("Position").IsOptional().HasColumnType("int");
            Property(x => x.IsLangTarget).HasColumnName("IsLangTarget").IsRequired().HasColumnType("bit");
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType("bit");
            Property(x => x.LocalizedLanguageName).HasColumnName("LocalizedLanguageName").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // LanguageMapping
    internal partial class LanguageMappingMap : EntityTypeConfiguration<LanguageMapping>
    {
        public LanguageMappingMap()
            : this("dbo")
        {
        }
 
        public LanguageMappingMap(string schema)
        {
            ToTable(schema + ".LanguageMapping");
            HasKey(x => x.LanguageMappingId);

            Property(x => x.Iso4646Code).HasColumnName("ISO4646Code").IsRequired().HasColumnType("nvarchar").HasMaxLength(10);
            Property(x => x.MappedIso4646Code).HasColumnName("MappedISO4646Code").IsRequired().HasColumnType("nvarchar").HasMaxLength(10);
            Property(x => x.LanguageMappingId).HasColumnName("LanguageMappingID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // LocalizedGeoCity
    internal partial class LocalizedGeoCityMap : EntityTypeConfiguration<LocalizedGeoCity>
    {
        public LocalizedGeoCityMap()
            : this("dbo")
        {
        }
 
        public LocalizedGeoCityMap(string schema)
        {
            ToTable(schema + ".LocalizedGeoCity");
            HasKey(x => new { x.GeoCityId, x.LanguageId });

            Property(x => x.GeoCityId).HasColumnName("GeoCityID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.LanguageId).HasColumnName("LanguageID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.LocalizedName).HasColumnName("LocalizedName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // LocalizedGeoCountry
    internal partial class LocalizedGeoCountryMap : EntityTypeConfiguration<LocalizedGeoCountry>
    {
        public LocalizedGeoCountryMap()
            : this("dbo")
        {
        }
 
        public LocalizedGeoCountryMap(string schema)
        {
            ToTable(schema + ".LocalizedGeoCountry");
            HasKey(x => new { x.GeoCountryId, x.LanguageId });

            Property(x => x.GeoCountryId).HasColumnName("GeoCountryID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.LanguageId).HasColumnName("LanguageID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.LocalizedName).HasColumnName("LocalizedName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // LocalizedGeoRegion
    internal partial class LocalizedGeoRegionMap : EntityTypeConfiguration<LocalizedGeoRegion>
    {
        public LocalizedGeoRegionMap()
            : this("dbo")
        {
        }
 
        public LocalizedGeoRegionMap(string schema)
        {
            ToTable(schema + ".LocalizedGeoRegion");
            HasKey(x => new { x.GeoRegionId, x.LanguageId });

            Property(x => x.GeoRegionId).HasColumnName("GeoRegionID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.LanguageId).HasColumnName("LanguageID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.LocalizedName).HasColumnName("LocalizedName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // MediaType
    internal partial class MediaTypeMap : EntityTypeConfiguration<MediaType>
    {
        public MediaTypeMap()
            : this("dbo")
        {
        }
 
        public MediaTypeMap(string schema)
        {
            ToTable(schema + ".MediaType");
            HasKey(x => x.MediaTypeId);

            Property(x => x.MediaTypeId).HasColumnName("MediaTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.MediaTypeName).HasColumnName("MediaTypeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // MindshareTemplateParameter
    internal partial class MindshareTemplateParameterMap : EntityTypeConfiguration<MindshareTemplateParameter>
    {
        public MindshareTemplateParameterMap()
            : this("dbo")
        {
        }
 
        public MindshareTemplateParameterMap(string schema)
        {
            ToTable(schema + ".MindshareTemplateParameter");
            HasKey(x => x.MindshareTemplateParameterId);

            Property(x => x.CampaignId).HasColumnName("CampaignID").IsRequired().HasColumnType("int");
            Property(x => x.CreativeSizeId).HasColumnName("CreativeSizeID").IsRequired().HasColumnType("int");
            Property(x => x.CreativeParameterKey).HasColumnName("CreativeParameterKey").IsRequired().HasColumnType("nvarchar").HasMaxLength(20);
            Property(x => x.CreativeParameterValue).HasColumnName("CreativeParameterValue").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.MindshareTemplateParameterId).HasColumnName("MindshareTemplateParameterID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // MobileCarrier
    internal partial class MobileCarrierMap : EntityTypeConfiguration<MobileCarrier>
    {
        public MobileCarrierMap()
            : this("dbo")
        {
        }
 
        public MobileCarrierMap(string schema)
        {
            ToTable(schema + ".MobileCarrier");
            HasKey(x => new { x.GeoCountryId, x.Mcc, x.Mnc });

            Property(x => x.GeoCountryId).HasColumnName("GeoCountryID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Mcc).HasColumnName("MCC").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Mnc).HasColumnName("MNC").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.MobileCarrierName).HasColumnName("MobileCarrierName").IsOptional().HasColumnType("nvarchar").HasMaxLength(250);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // MonthlyCredit
    internal partial class MonthlyCreditMap : EntityTypeConfiguration<MonthlyCredit>
    {
        public MonthlyCreditMap()
            : this("dbo")
        {
        }
 
        public MonthlyCreditMap(string schema)
        {
            ToTable(schema + ".MonthlyCredit");
            HasKey(x => x.MonthlyCreditId);

            Property(x => x.MonthlyCreditId).HasColumnName("MonthlyCreditID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.MonthlyCreditName).HasColumnName("MonthlyCreditName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);

            // Foreign keys
            HasRequired(a => a.MonthlyCredit1).WithOptional(b => b.MonthlyCredit2); // FK_MonthlyCredit_MonthlyCredit
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // NewDayPartMappings
    internal partial class NewDayPartMappingMap : EntityTypeConfiguration<NewDayPartMapping>
    {
        public NewDayPartMappingMap()
            : this("dbo")
        {
        }
 
        public NewDayPartMappingMap(string schema)
        {
            ToTable(schema + ".NewDayPartMappings");
            HasKey(x => new { x.OldDayPartId, x.NewDayPartId });

            Property(x => x.OldDayPartId).HasColumnName("OldDayPartID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.NewDayPartId).HasColumnName("NewDayPartID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // OptimizationModel
    internal partial class OptimizationModelMap : EntityTypeConfiguration<OptimizationModel>
    {
        public OptimizationModelMap()
            : this("dbo")
        {
        }
 
        public OptimizationModelMap(string schema)
        {
            ToTable(schema + ".OptimizationModel");
            HasKey(x => x.OptimizationModelId);

            Property(x => x.OptimizationModelId).HasColumnName("OptimizationModelID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.OptimizationModelName).HasColumnName("OptimizationModelName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Order
    internal partial class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
            : this("dbo")
        {
        }
 
        public OrderMap(string schema)
        {
            ToTable(schema + ".Order");
            HasKey(x => x.OrderId);

            Property(x => x.OrderId).HasColumnName("OrderID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BillingPeriodId).HasColumnName("BillingPeriodID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.ContactName).HasColumnName("ContactName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.ContactEmailAddress).HasColumnName("ContactEmailAddress").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.PoAddressLine1).HasColumnName("POAddressLine1").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.PoAddressLine2).HasColumnName("POAddressLine2").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.PoAddressLine3).HasColumnName("POAddressLine3").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.PoAddressLine4).HasColumnName("POAddressLine4").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.PoCity).HasColumnName("POCity").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.PoRegion).HasColumnName("PORegion").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.PoPostalCode).HasColumnName("POPostalCode").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.PoCountry).HasColumnName("POCountry").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.InvoiceNumber).HasColumnName("InvoiceNumber").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.OrderReference).HasColumnName("OrderReference").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.InvoiceDate).HasColumnName("InvoiceDate").IsRequired().HasColumnType("date");
            Property(x => x.DueDate).HasColumnName("DueDate").IsRequired().HasColumnType("date");

            // Foreign keys
            HasRequired(a => a.BillingPeriod).WithMany(b => b.Orders).HasForeignKey(c => c.BillingPeriodId); // FK_Order_BillingPeriod
            HasRequired(a => a.BuyerAccount).WithMany(b => b.Orders).HasForeignKey(c => c.BuyerAccountId); // FK_Order_BuyerAccount
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // OrderLine
    internal partial class OrderLineMap : EntityTypeConfiguration<OrderLine>
    {
        public OrderLineMap()
            : this("dbo")
        {
        }
 
        public OrderLineMap(string schema)
        {
            ToTable(schema + ".OrderLine");
            HasKey(x => x.OrderLineId);

            Property(x => x.OrderLineId).HasColumnName("OrderLineID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrderId).HasColumnName("OrderID").IsRequired().HasColumnType("int");
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsOptional().HasColumnType("int");
            Property(x => x.SegmentId).HasColumnName("SegmentID").IsOptional().HasColumnType("int");
            Property(x => x.OrderLineReference).HasColumnName("OrderLineReference").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.OrderLineDescription).HasColumnName("OrderLineDescription").IsRequired().HasColumnType("nvarchar").HasMaxLength(1000);
            Property(x => x.SubTotal).HasColumnName("SubTotal").IsRequired().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.BrokerageAmount).HasColumnName("BrokerageAmount").IsRequired().HasColumnType("money").HasPrecision(19,4);

            // Foreign keys
            HasOptional(a => a.Campaign).WithMany(b => b.OrderLines).HasForeignKey(c => c.CampaignId); // FK_OrderLine_Campaign
            HasOptional(a => a.Segment).WithMany(b => b.OrderLines).HasForeignKey(c => c.SegmentId); // FK_OrderLine_Segment
            HasRequired(a => a.Order).WithMany(b => b.OrderLines).HasForeignKey(c => c.OrderId); // FK_OrderLine_Order
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // PacingStyle
    internal partial class PacingStyleMap : EntityTypeConfiguration<PacingStyle>
    {
        public PacingStyleMap()
            : this("dbo")
        {
        }
 
        public PacingStyleMap(string schema)
        {
            ToTable(schema + ".PacingStyle");
            HasKey(x => x.PacingStyleId);

            Property(x => x.PacingStyleId).HasColumnName("PacingStyleID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PacingStyleName).HasColumnName("PacingStyleName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // PagePosition
    internal partial class PagePositionMap : EntityTypeConfiguration<PagePosition>
    {
        public PagePositionMap()
            : this("dbo")
        {
        }
 
        public PagePositionMap(string schema)
        {
            ToTable(schema + ".PagePosition");
            HasKey(x => x.PagePositionId);

            Property(x => x.PagePositionId).HasColumnName("PagePositionID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PagePositionName).HasColumnName("PagePositionName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Partner
    internal partial class PartnerMap : EntityTypeConfiguration<Partner>
    {
        public PartnerMap()
            : this("dbo")
        {
        }
 
        public PartnerMap(string schema)
        {
            ToTable(schema + ".Partner");
            HasKey(x => x.PartnerId);

            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PartnerName).HasColumnName("PartnerName").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.IsExchangeTarget).HasColumnName("IsExchangeTarget").IsRequired().HasColumnType("bit");
            Property(x => x.TimeZoneId).HasColumnName("TimeZoneID").IsOptional().HasColumnType("int");
            Property(x => x.PrivateDealMode).HasColumnName("PrivateDealMode").IsRequired().HasColumnType("int");
            Property(x => x.MediaTypeId).HasColumnName("MediaTypeID").IsOptional().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // PartnerDefaultBuyer
    internal partial class PartnerDefaultBuyerMap : EntityTypeConfiguration<PartnerDefaultBuyer>
    {
        public PartnerDefaultBuyerMap()
            : this("dbo")
        {
        }
 
        public PartnerDefaultBuyerMap(string schema)
        {
            ToTable(schema + ".PartnerDefaultBuyer");
            HasKey(x => x.PartnerDefaultBuyerId);

            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerId).HasColumnName("BuyerID").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.PartnerDefaultBuyerId).HasColumnName("PartnerDefaultBuyerID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // PaymentTerms
    internal partial class PaymentTermMap : EntityTypeConfiguration<PaymentTerm>
    {
        public PaymentTermMap()
            : this("dbo")
        {
        }
 
        public PaymentTermMap(string schema)
        {
            ToTable(schema + ".PaymentTerms");
            HasKey(x => x.PaymentTermsId);

            Property(x => x.PaymentTermsId).HasColumnName("PaymentTermsID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PaymentTermsName).HasColumnName("PaymentTermsName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.PeriodInDays).HasColumnName("PeriodInDays").IsRequired().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // PixelTagServer
    internal partial class PixelTagServerMap : EntityTypeConfiguration<PixelTagServer>
    {
        public PixelTagServerMap()
            : this("dbo")
        {
        }
 
        public PixelTagServerMap(string schema)
        {
            ToTable(schema + ".PixelTagServer");
            HasKey(x => x.PixelTagServerId);

            Property(x => x.PixelTagServerId).HasColumnName("PixelTagServerID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PixelTagServerName).HasColumnName("PixelTagServerName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.Position).HasColumnName("Position").IsOptional().HasColumnType("int");
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType("bit");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // PixelTagTemplate
    internal partial class PixelTagTemplateMap : EntityTypeConfiguration<PixelTagTemplate>
    {
        public PixelTagTemplateMap()
            : this("dbo")
        {
        }
 
        public PixelTagTemplateMap(string schema)
        {
            ToTable(schema + ".PixelTagTemplate");
            HasKey(x => x.PixelTagTemplateId);

            Property(x => x.PixelTagTemplateId).HasColumnName("PixelTagTemplateID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PixelTagTemplateName).HasColumnName("PixelTagTemplateName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.AddPixelTag).HasColumnName("AddPixelTag").IsOptional().HasColumnType("nvarchar").HasMaxLength(1000);
            Property(x => x.RemovePixelTag).HasColumnName("RemovePixelTag").IsOptional().HasColumnType("nvarchar").HasMaxLength(1000);
            Property(x => x.ConvertPixelTag).HasColumnName("ConvertPixelTag").IsOptional().HasColumnType("nvarchar").HasMaxLength(1000);
            Property(x => x.RemarketHelpText).HasColumnName("RemarketHelpText").IsOptional().HasColumnType("nvarchar").HasMaxLength(1000);
            Property(x => x.ConvertHelpText).HasColumnName("ConvertHelpText").IsOptional().HasColumnType("nvarchar").HasMaxLength(1000);
            Property(x => x.Position).HasColumnName("Position").IsOptional().HasColumnType("int");
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType("bit");
            Property(x => x.PixelTagServerId).HasColumnName("PixelTagServerID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.PixelTagServer).WithMany(b => b.PixelTagTemplates).HasForeignKey(c => c.PixelTagServerId); // FK_PixelTagTemplate_PixelTagServer
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Placement
    internal partial class PlacementMap : EntityTypeConfiguration<Placement>
    {
        public PlacementMap()
            : this("dbo")
        {
        }
 
        public PlacementMap(string schema)
        {
            ToTable(schema + ".Placement");
            HasKey(x => x.PlacementId);

            Property(x => x.PlacementId).HasColumnName("PlacementID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.AdGroupId).HasColumnName("AdGroupID").IsRequired().HasColumnType("int");
            Property(x => x.CreativeId).HasColumnName("CreativeID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.PlacementStatusId).HasColumnName("PlacementStatusID").IsRequired().HasColumnType("int");
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.PlacementUuid).HasColumnName("PlacementUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.CloneFromPlacementId).HasColumnName("CloneFromPlacementID").IsOptional().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.AdGroup).WithMany(b => b.Placements).HasForeignKey(c => c.AdGroupId); // FK_Placement_AdGroup
            HasRequired(a => a.BuyerAccount).WithMany(b => b.Placements).HasForeignKey(c => c.BuyerAccountId); // FK_Placement_BuyerAccount
            HasRequired(a => a.CampaignStatus).WithMany(b => b.Placements).HasForeignKey(c => c.PlacementStatusId); // FK_Placement_Status
            HasRequired(a => a.Creative).WithMany(b => b.Placements).HasForeignKey(c => c.CreativeId); // FK_Placement_Creative
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // PlacementPerformance
    internal partial class PlacementPerformanceMap : EntityTypeConfiguration<PlacementPerformance>
    {
        public PlacementPerformanceMap()
            : this("dbo")
        {
        }
 
        public PlacementPerformanceMap(string schema)
        {
            ToTable(schema + ".PlacementPerformance");
            HasKey(x => new { x.PlacementId, x.IntervalId, x.IntervalValue });

            Property(x => x.PlacementId).HasColumnName("PlacementID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalId).HasColumnName("IntervalID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalValue).HasColumnName("IntervalValue").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Bids).HasColumnName("Bids").IsRequired().HasColumnType("bigint");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Clicks).HasColumnName("Clicks").IsRequired().HasColumnType("bigint");
            Property(x => x.Conversions).HasColumnName("Conversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostViewConversions).HasColumnName("PostViewConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostClickConversions).HasColumnName("PostClickConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.LastActivityTimestamp).HasColumnName("LastActivityTimestamp").IsOptional().HasColumnType("datetime");
            Property(x => x.Ctr).HasColumnName("CTR").IsOptional().HasColumnType("float").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaCostLocalMicros).HasColumnName("MediaCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataCostLocalMicros).HasColumnName("DataCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.SpendLocalMicros).HasColumnName("SpendLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaClientCostLocalMicros).HasColumnName("MediaClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataClientCostLocalMicros).HasColumnName("DataClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.ClientCostLocalMicros).HasColumnName("ClientCostLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpm).HasColumnName("CPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpc).HasColumnName("CPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpa).HasColumnName("CPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpm).HasColumnName("ClientCostCPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpc).HasColumnName("ClientCostCPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpa).HasColumnName("ClientCostCPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Spend).HasColumnName("Spend").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cvr).HasColumnName("Cvr").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.BidWin).HasColumnName("BidWin").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.FeesLocalSuperMicros).HasColumnName("FeesLocalSuperMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.AdSlotDurationInSeconds).HasColumnName("AdSlotDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.RawViews).HasColumnName("RawViews").IsRequired().HasColumnType("bigint");
            Property(x => x.IabViews).HasColumnName("IabViews").IsRequired().HasColumnType("bigint");
            Property(x => x.ViewDurationInSeconds).HasColumnName("ViewDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.CpMs).HasColumnName("CPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpMs).HasColumnName("ClientCostCPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cps).HasColumnName("CPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCps).HasColumnName("ClientCostCPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ViewableRatio).HasColumnName("ViewableRatio").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            // Foreign keys
            HasRequired(a => a.Interval).WithMany(b => b.PlacementPerformances).HasForeignKey(c => c.IntervalId); // FK_PlacementPerformance_Interval
            HasRequired(a => a.Placement).WithMany(b => b.PlacementPerformances).HasForeignKey(c => c.PlacementId); // FK_PlacementPerformance_Placement
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // PrivateMarket
    internal partial class PrivateMarketMap : EntityTypeConfiguration<PrivateMarket>
    {
        public PrivateMarketMap()
            : this("dbo")
        {
        }
 
        public PrivateMarketMap(string schema)
        {
            ToTable(schema + ".PrivateMarket");
            HasKey(x => x.PrivateMarketId);

            Property(x => x.PrivateMarketId).HasColumnName("PrivateMarketID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PrivateMarketUuid).HasColumnName("PrivateMarketUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int");
            Property(x => x.BuyerMarketStatusId).HasColumnName("BuyerMarketStatusID").IsRequired().HasColumnType("int");
            Property(x => x.PublisherMarketStatusId).HasColumnName("PublisherMarketStatusID").IsRequired().HasColumnType("int");
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.PrivateMarketStatusId).HasColumnName("PrivateMarketStatusID").IsOptional().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            // Foreign keys
            HasRequired(a => a.PrivateMarketStatu_BuyerMarketStatusId).WithMany(b => b.PrivateMarkets_BuyerMarketStatusId).HasForeignKey(c => c.BuyerMarketStatusId); // FK_PrivateMarket_BuyerMarketStatus
            HasRequired(a => a.PrivateMarketStatu_PublisherMarketStatusId).WithMany(b => b.PrivateMarkets_PublisherMarketStatusId).HasForeignKey(c => c.PublisherMarketStatusId); // FK_PrivateMarket_PublisherMarketStatus
            HasRequired(a => a.Publisher).WithMany(b => b.PrivateMarkets).HasForeignKey(c => c.PublisherId); // FK_PrivateMarket_Publisher
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // PrivateMarketMode
    internal partial class PrivateMarketModeMap : EntityTypeConfiguration<PrivateMarketMode>
    {
        public PrivateMarketModeMap()
            : this("dbo")
        {
        }
 
        public PrivateMarketModeMap(string schema)
        {
            ToTable(schema + ".PrivateMarketMode");
            HasKey(x => x.PrivateMarketModeId);

            Property(x => x.PrivateMarketModeId).HasColumnName("PrivateMarketModeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PrivateMarketModeName).HasColumnName("PrivateMarketModeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // PrivateMarketPerformance
    internal partial class PrivateMarketPerformanceMap : EntityTypeConfiguration<PrivateMarketPerformance>
    {
        public PrivateMarketPerformanceMap()
            : this("dbo")
        {
        }
 
        public PrivateMarketPerformanceMap(string schema)
        {
            ToTable(schema + ".PrivateMarketPerformance");
            HasKey(x => new { x.PrivateMarketId, x.IntervalId, x.IntervalValue });

            Property(x => x.PrivateMarketId).HasColumnName("PrivateMarketID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalId).HasColumnName("IntervalID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalValue).HasColumnName("IntervalValue").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Bids).HasColumnName("Bids").IsRequired().HasColumnType("bigint");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Clicks).HasColumnName("Clicks").IsRequired().HasColumnType("bigint");
            Property(x => x.Conversions).HasColumnName("Conversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostViewConversions).HasColumnName("PostViewConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostClickConversions).HasColumnName("PostClickConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.LastActivityTimestamp).HasColumnName("LastActivityTimestamp").IsOptional().HasColumnType("datetime");
            Property(x => x.Ctr).HasColumnName("CTR").IsOptional().HasColumnType("float").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaCostLocalMicros).HasColumnName("MediaCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataCostLocalMicros).HasColumnName("DataCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.SpendLocalMicros).HasColumnName("SpendLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaClientCostLocalMicros).HasColumnName("MediaClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataClientCostLocalMicros).HasColumnName("DataClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.ClientCostLocalMicros).HasColumnName("ClientCostLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpm).HasColumnName("CPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpc).HasColumnName("CPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpa).HasColumnName("CPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpm).HasColumnName("ClientCostCPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpc).HasColumnName("ClientCostCPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpa).HasColumnName("ClientCostCPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cvr).HasColumnName("Cvr").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.BidWin).HasColumnName("BidWin").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.SiteCount).HasColumnName("SiteCount").IsOptional().HasColumnType("int");
            Property(x => x.AdSlotDurationInSeconds).HasColumnName("AdSlotDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.RawViews).HasColumnName("RawViews").IsRequired().HasColumnType("bigint");
            Property(x => x.IabViews).HasColumnName("IabViews").IsRequired().HasColumnType("bigint");
            Property(x => x.ViewDurationInSeconds).HasColumnName("ViewDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.CpMs).HasColumnName("CPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpMs).HasColumnName("ClientCostCPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cps).HasColumnName("CPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCps).HasColumnName("ClientCostCPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ViewableRatio).HasColumnName("ViewableRatio").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            // Foreign keys
            HasRequired(a => a.Interval).WithMany(b => b.PrivateMarketPerformances).HasForeignKey(c => c.IntervalId); // FK_PrivateMarketPerformance_Interval
            HasRequired(a => a.PrivateMarket).WithMany(b => b.PrivateMarketPerformances).HasForeignKey(c => c.PrivateMarketId); // FK_PrivateMarketPerformance_PrivateMarket
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // PrivateMarketSite
    internal partial class PrivateMarketSiteMap : EntityTypeConfiguration<PrivateMarketSite>
    {
        public PrivateMarketSiteMap()
            : this("dbo")
        {
        }
 
        public PrivateMarketSiteMap(string schema)
        {
            ToTable(schema + ".PrivateMarketSite");
            HasKey(x => x.PrivateMarketSiteId);

            Property(x => x.PrivateMarketSiteId).HasColumnName("PrivateMarketSiteID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PrivateMarketSiteUuid).HasColumnName("PrivateMarketSiteUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.PrivateMarketId).HasColumnName("PrivateMarketID").IsRequired().HasColumnType("int");
            Property(x => x.InventoryId).HasColumnName("InventoryID").IsRequired().HasColumnType("bigint");
            Property(x => x.PriceFloor).HasColumnName("PriceFloor").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.PrivateMarketSiteStatusId).HasColumnName("PrivateMarketSiteStatusID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.PrivateMarket).WithMany(b => b.PrivateMarketSites).HasForeignKey(c => c.PrivateMarketId); // FK_PrivateMarketSite_PrivateMarket
            HasRequired(a => a.PrivateMarketSiteStatu).WithMany(b => b.PrivateMarketSites).HasForeignKey(c => c.PrivateMarketSiteStatusId); // FK_PrivateMarketSite_PrivateMarketSiteStatus
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // PrivateMarketSitePerformance
    internal partial class PrivateMarketSitePerformanceMap : EntityTypeConfiguration<PrivateMarketSitePerformance>
    {
        public PrivateMarketSitePerformanceMap()
            : this("dbo")
        {
        }
 
        public PrivateMarketSitePerformanceMap(string schema)
        {
            ToTable(schema + ".PrivateMarketSitePerformance");
            HasKey(x => new { x.PrivateMarketSiteId, x.IntervalId, x.IntervalValue });

            Property(x => x.PrivateMarketSiteId).HasColumnName("PrivateMarketSiteID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalId).HasColumnName("IntervalID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalValue).HasColumnName("IntervalValue").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Bids).HasColumnName("Bids").IsRequired().HasColumnType("bigint");
            Property(x => x.Impressions).HasColumnName("Impressions").IsRequired().HasColumnType("bigint");
            Property(x => x.Clicks).HasColumnName("Clicks").IsRequired().HasColumnType("bigint");
            Property(x => x.Conversions).HasColumnName("Conversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostViewConversions).HasColumnName("PostViewConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.PostClickConversions).HasColumnName("PostClickConversions").IsRequired().HasColumnType("bigint");
            Property(x => x.LastActivityTimestamp).HasColumnName("LastActivityTimestamp").IsOptional().HasColumnType("datetime");
            Property(x => x.Ctr).HasColumnName("CTR").IsOptional().HasColumnType("float").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaCostLocalMicros).HasColumnName("MediaCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataCostLocalMicros).HasColumnName("DataCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.SpendLocalMicros).HasColumnName("SpendLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MediaClientCostLocalMicros).HasColumnName("MediaClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.DataClientCostLocalMicros).HasColumnName("DataClientCostLocalMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.ClientCostLocalMicros).HasColumnName("ClientCostLocalMicros").IsOptional().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpm).HasColumnName("CPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpc).HasColumnName("CPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cpa).HasColumnName("CPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpm).HasColumnName("ClientCostCPM").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpc).HasColumnName("ClientCostCPC").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpa).HasColumnName("ClientCostCPA").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cvr).HasColumnName("Cvr").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.BidWin).HasColumnName("BidWin").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.AdSlotDurationInSeconds).HasColumnName("AdSlotDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.RawViews).HasColumnName("RawViews").IsRequired().HasColumnType("bigint");
            Property(x => x.IabViews).HasColumnName("IabViews").IsRequired().HasColumnType("bigint");
            Property(x => x.ViewDurationInSeconds).HasColumnName("ViewDurationInSeconds").IsRequired().HasColumnType("bigint");
            Property(x => x.CpMs).HasColumnName("CPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCpMs).HasColumnName("ClientCostCPMs").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Cps).HasColumnName("CPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ClientCostCps).HasColumnName("ClientCostCPS").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.ViewableRatio).HasColumnName("ViewableRatio").IsOptional().HasColumnType("decimal").HasPrecision(19,4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            // Foreign keys
            HasRequired(a => a.Interval).WithMany(b => b.PrivateMarketSitePerformances).HasForeignKey(c => c.IntervalId); // FK_PrivateMarketSitePerformance_Interval
            HasRequired(a => a.PrivateMarketSite).WithMany(b => b.PrivateMarketSitePerformances).HasForeignKey(c => c.PrivateMarketSiteId); // FK_PrivateMarketSitePerformance_PrivateMarket
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // PrivateMarketSiteStatus
    internal partial class PrivateMarketSiteStatuMap : EntityTypeConfiguration<PrivateMarketSiteStatu>
    {
        public PrivateMarketSiteStatuMap()
            : this("dbo")
        {
        }
 
        public PrivateMarketSiteStatuMap(string schema)
        {
            ToTable(schema + ".PrivateMarketSiteStatus");
            HasKey(x => x.PrivateMarketSiteStatusId);

            Property(x => x.PrivateMarketSiteStatusId).HasColumnName("PrivateMarketSiteStatusID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PrivateMarketSiteStatusName).HasColumnName("PrivateMarketSiteStatusName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // PrivateMarketStatus
    internal partial class PrivateMarketStatuMap : EntityTypeConfiguration<PrivateMarketStatu>
    {
        public PrivateMarketStatuMap()
            : this("dbo")
        {
        }
 
        public PrivateMarketStatuMap(string schema)
        {
            ToTable(schema + ".PrivateMarketStatus");
            HasKey(x => x.PrivateMarketStatusId);

            Property(x => x.PrivateMarketStatusId).HasColumnName("PrivateMarketStatusID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PrivateMarketStatusName).HasColumnName("PrivateMarketStatusName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ProductCategory
    internal partial class ProductCategoryMap : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryMap()
            : this("dbo")
        {
        }
 
        public ProductCategoryMap(string schema)
        {
            ToTable(schema + ".ProductCategory");
            HasKey(x => x.ProductCategoryId);

            Property(x => x.ProductCategoryId).HasColumnName("ProductCategoryID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IndustryCategoryId).HasColumnName("IndustryCategoryID").IsRequired().HasColumnType("int");
            Property(x => x.ProductCategoryName).HasColumnName("ProductCategoryName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType("bit");

            // Foreign keys
            HasRequired(a => a.IndustryCategory).WithMany(b => b.ProductCategories).HasForeignKey(c => c.IndustryCategoryId); // FK_ProductCategory_IndustryCategory
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ProviderBrandSafetyType
    internal partial class ProviderBrandSafetyTypeMap : EntityTypeConfiguration<ProviderBrandSafetyType>
    {
        public ProviderBrandSafetyTypeMap()
            : this("dbo")
        {
        }
 
        public ProviderBrandSafetyTypeMap(string schema)
        {
            ToTable(schema + ".ProviderBrandSafetyType");
            HasKey(x => new { x.ProviderId, x.BrandSafetyTypeId });

            Property(x => x.ProviderId).HasColumnName("ProviderID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BrandSafetyTypeId).HasColumnName("BrandSafetyTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Publisher
    internal partial class PublisherMap : EntityTypeConfiguration<Publisher>
    {
        public PublisherMap()
            : this("dbo")
        {
        }
 
        public PublisherMap(string schema)
        {
            ToTable(schema + ".Publisher");
            HasKey(x => x.PublisherId);

            Property(x => x.PublisherId).HasColumnName("PublisherID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PublisherUuid).HasColumnName("PublisherUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.PublisherName).HasColumnName("PublisherName").IsRequired().HasColumnType("nvarchar").HasMaxLength(255);
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.PartnerKey).HasColumnName("PartnerKey").IsRequired().HasColumnType("nvarchar").HasMaxLength(255);
            Property(x => x.PrivateMarketModeId).HasColumnName("PrivateMarketModeID").IsRequired().HasColumnType("int");
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired().HasColumnType("bit");

            // Foreign keys
            HasRequired(a => a.Partner).WithMany(b => b.Publishers).HasForeignKey(c => c.PartnerId); // FK_Publisher_Partner
            HasRequired(a => a.PrivateMarketMode).WithMany(b => b.Publishers).HasForeignKey(c => c.PrivateMarketModeId); // FK_Publisher_PrivateMarketMode
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ReportAggregationLevel
    internal partial class ReportAggregationLevelMap : EntityTypeConfiguration<ReportAggregationLevel>
    {
        public ReportAggregationLevelMap()
            : this("dbo")
        {
        }
 
        public ReportAggregationLevelMap(string schema)
        {
            ToTable(schema + ".ReportAggregationLevel");
            HasKey(x => x.ReportAggregationLevelId);

            Property(x => x.ReportAggregationLevelId).HasColumnName("ReportAggregationLevelID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ReportAggregationLeveName).HasColumnName("ReportAggregationLeveName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Position).HasColumnName("Position").IsOptional().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ReportJob
    internal partial class ReportJobMap : EntityTypeConfiguration<ReportJob>
    {
        public ReportJobMap()
            : this("dbo")
        {
        }
 
        public ReportJobMap(string schema)
        {
            ToTable(schema + ".ReportJob");
            HasKey(x => x.ReportJobId);

            Property(x => x.ReportJobId).HasColumnName("ReportJobID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReportScheduleId).HasColumnName("ReportScheduleID").IsRequired().HasColumnType("int");
            Property(x => x.UtcQueueDateTime).HasColumnName("UtcQueueDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcStartDateTime).HasColumnName("UtcStartDateTime").IsOptional().HasColumnType("datetime");
            Property(x => x.UtcEndDateTime).HasColumnName("UtcEndDateTime").IsOptional().HasColumnType("datetime");
            Property(x => x.LocalFromDateTime).HasColumnName("LocalFromDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.LocalToDateTime).HasColumnName("LocalToDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.ErrorMessage).HasColumnName("ErrorMessage").IsOptional().HasColumnType("nvarchar").HasMaxLength(2000);

            // Foreign keys
            HasRequired(a => a.ReportSchedule).WithMany(b => b.ReportJobs).HasForeignKey(c => c.ReportScheduleId); // FK_ReportJob_ReportSchedule
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ReportSchedule
    internal partial class ReportScheduleMap : EntityTypeConfiguration<ReportSchedule>
    {
        public ReportScheduleMap()
            : this("dbo")
        {
        }
 
        public ReportScheduleMap(string schema)
        {
            ToTable(schema + ".ReportSchedule");
            HasKey(x => x.ReportScheduleId);

            Property(x => x.ReportScheduleId).HasColumnName("ReportScheduleID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReportScheduleUuid).HasColumnName("ReportScheduleUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.UserId).HasColumnName("UserID").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.ReportPeriodId).HasColumnName("ReportPeriodID").IsRequired().HasColumnType("int");
            Property(x => x.RecurrenceDays).HasColumnName("RecurrenceDays").IsOptional().HasColumnType("int");
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int");
            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsOptional().HasColumnType("int");
            Property(x => x.CampaignId).HasColumnName("CampaignID").IsOptional().HasColumnType("int");
            Property(x => x.ReportTypeId).HasColumnName("ReportTypeID").IsRequired().HasColumnType("int");
            Property(x => x.ReportAggregationLevelId).HasColumnName("ReportAggregationLevelID").IsRequired().HasColumnType("int");
            Property(x => x.CampaignPeriodId).HasColumnName("CampaignPeriodID").IsRequired().HasColumnType("int");
            Property(x => x.UtcStartDateTime).HasColumnName("UtcStartDateTime").IsOptional().HasColumnType("datetime");
            Property(x => x.UtcEndDateTime).HasColumnName("UtcEndDateTime").IsOptional().HasColumnType("datetime");
            Property(x => x.LastRunDateTime).HasColumnName("LastRunDateTime").IsOptional().HasColumnType("datetime");
            Property(x => x.NextRunDateTime).HasColumnName("NextRunDateTime").IsOptional().HasColumnType("datetime");
            Property(x => x.CampaignStatusId).HasColumnName("CampaignStatusID").IsRequired().HasColumnType("int");
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.ModifiedUserId).HasColumnName("ModifiedUserID").IsOptional().HasColumnType("uniqueidentifier");
            Property(x => x.ModifiedActualUserId).HasColumnName("ModifiedActualUserID").IsOptional().HasColumnType("uniqueidentifier");
            Property(x => x.ReportScheduleName).HasColumnName("ReportScheduleName").IsRequired().HasColumnType("nvarchar").HasMaxLength(150);
            Property(x => x.SendReportTo).HasColumnName("SendReportTo").IsRequired().HasColumnType("nvarchar").HasMaxLength(900);
            Property(x => x.CostView).HasColumnName("CostView").IsOptional().HasColumnType("int");
            Property(x => x.RtbSegmentId).HasColumnName("RtbSegmentID").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);

            // Foreign keys
            HasOptional(a => a.Advertiser).WithMany(b => b.ReportSchedules).HasForeignKey(c => c.AdvertiserId); // FK_ReportSchedule_Advertiser
            HasOptional(a => a.User_ModifiedActualUserId).WithMany(b => b.ReportSchedules_ModifiedActualUserId).HasForeignKey(c => c.ModifiedActualUserId); // FK_ReportSchedule_ActualUser
            HasOptional(a => a.User_ModifiedUserId).WithMany(b => b.ReportSchedules_ModifiedUserId).HasForeignKey(c => c.ModifiedUserId); // FK_ReportSchedule_User
            HasRequired(a => a.BuyerAccount).WithMany(b => b.ReportSchedules).HasForeignKey(c => c.BuyerAccountId); // FK_ReportSchedule_BuyerAccount
            HasRequired(a => a.CampaignPeriod).WithMany(b => b.ReportSchedules).HasForeignKey(c => c.CampaignPeriodId); // FK_ReportSchedule_CampaignPeriod
            HasRequired(a => a.CampaignStatus).WithMany(b => b.ReportSchedules).HasForeignKey(c => c.CampaignStatusId); // FK_ReportSchedule_CampaignStatus
            HasRequired(a => a.ReportAggregationLevel).WithMany(b => b.ReportSchedules).HasForeignKey(c => c.ReportAggregationLevelId); // FK_ReportSchedule_ReportAggregationLevel
            HasRequired(a => a.ReportType).WithMany(b => b.ReportSchedules).HasForeignKey(c => c.ReportTypeId); // FK_ReportSchedule_ReportType
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ReportType
    internal partial class ReportTypeMap : EntityTypeConfiguration<ReportType>
    {
        public ReportTypeMap()
            : this("dbo")
        {
        }
 
        public ReportTypeMap(string schema)
        {
            ToTable(schema + ".ReportType");
            HasKey(x => x.ReportTypeId);

            Property(x => x.ReportTypeId).HasColumnName("ReportTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ReportTypeName).HasColumnName("ReportTypeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Position).HasColumnName("Position").IsOptional().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // RetryLog
    internal partial class RetryLogMap : EntityTypeConfiguration<RetryLog>
    {
        public RetryLogMap()
            : this("dbo")
        {
        }
 
        public RetryLogMap(string schema)
        {
            ToTable(schema + ".RetryLog");
            HasKey(x => x.RetryLogId);

            Property(x => x.RetryLogId).HasColumnName("RetryLogId").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Message).HasColumnName("Message").IsRequired().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.Attempt).HasColumnName("Attempt").IsRequired().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SalesRegion
    internal partial class SalesRegionMap : EntityTypeConfiguration<SalesRegion>
    {
        public SalesRegionMap()
            : this("dbo")
        {
        }
 
        public SalesRegionMap(string schema)
        {
            ToTable(schema + ".SalesRegion");
            HasKey(x => x.SalesRegionId);

            Property(x => x.SalesRegionId).HasColumnName("SalesRegionID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.SalesRegionName).HasColumnName("SalesRegionName").IsRequired().HasColumnType("nvarchar").HasMaxLength(500);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SchemaMigration
    internal partial class SchemaMigrationMap : EntityTypeConfiguration<SchemaMigration>
    {
        public SchemaMigrationMap()
            : this("dbo")
        {
        }
 
        public SchemaMigrationMap(string schema)
        {
            ToTable(schema + ".SchemaMigration");
            HasKey(x => x.SchemaVersion);

            Property(x => x.SchemaVersion).HasColumnName("SchemaVersion").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DateApplied).HasColumnName("DateApplied").IsOptional().HasColumnType("datetime");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Segment
    internal partial class SegmentMap : EntityTypeConfiguration<Segment>
    {
        public SegmentMap()
            : this("dbo")
        {
        }
 
        public SegmentMap(string schema)
        {
            ToTable(schema + ".Segment");
            HasKey(x => x.SegmentId);

            Property(x => x.SegmentId).HasColumnName("SegmentID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.RtbSegmentId).HasColumnName("RtbSegmentID").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsOptional().HasColumnType("int");
            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsOptional().HasColumnType("int");
            Property(x => x.SegmentName).HasColumnName("SegmentName").IsOptional().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.SegmentDescription).HasColumnName("SegmentDescription").IsOptional().HasColumnType("nvarchar").HasMaxLength(2000);
            Property(x => x.SegmentTypeId).HasColumnName("SegmentTypeID").IsRequired().HasColumnType("int");
            Property(x => x.ConversionAttributionModelId).HasColumnName("ConversionAttributionModelID").IsOptional().HasColumnType("int");
            Property(x => x.ConversionPostViewLifetime).HasColumnName("ConversionPostViewLifetime").IsOptional().HasColumnType("int");
            Property(x => x.ConversionPostClickLifetime).HasColumnName("ConversionPostClickLifetime").IsOptional().HasColumnType("int");
            Property(x => x.ConversionAttributionCountingModeId).HasColumnName("ConversionAttributionCountingModeID").IsOptional().HasColumnType("int");
            Property(x => x.ConversionAttributionCountingRecency).HasColumnName("ConversionAttributionCountingRecency").IsOptional().HasColumnType("int");
            Property(x => x.RemarketingRecency).HasColumnName("RemarketingRecency").IsOptional().HasColumnType("int");
            Property(x => x.ThirdPartyDataSetId).HasColumnName("ThirdPartyDataSetID").IsOptional().HasColumnType("int");
            Property(x => x.ThirdPartyUtcStartDate).HasColumnName("ThirdPartyUtcStartDate").IsOptional().HasColumnType("datetime");
            Property(x => x.ThirdPartyUtcEndDate).HasColumnName("ThirdPartyUtcEndDate").IsOptional().HasColumnType("datetime");
            Property(x => x.ThirdPartyRecency).HasColumnName("ThirdPartyRecency").IsOptional().HasColumnType("int");
            Property(x => x.ThirdPartyBudgetAmount).HasColumnName("ThirdPartyBudgetAmount").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.ThirdPartyMaxBidCpm).HasColumnName("ThirdPartyMaxBidCpm").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.ThirdPartyAgencyReference).HasColumnName("ThirdPartyAgencyReference").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.ThirdPartyPartnerReference).HasColumnName("ThirdPartyPartnerReference").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.ThirdPartyAvailableUniques).HasColumnName("ThirdPartyAvailableUniques").IsOptional().HasColumnType("int");
            Property(x => x.SegmentStatusId).HasColumnName("SegmentStatusID").IsRequired().HasColumnType("int");
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");
            Property(x => x.UtcCreatedDateTime).HasColumnName("UtcCreatedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.UtcModifiedDateTime).HasColumnName("UtcModifiedDateTime").IsRequired().HasColumnType("datetime");
            Property(x => x.TargetGeographyCountryId).HasColumnName("TargetGeographyCountryId").IsOptional().HasColumnType("int");
            Property(x => x.ThirdPartyPeriodId).HasColumnName("ThirdPartyPeriodID").IsOptional().HasColumnType("int");
            Property(x => x.ThirdPartyParentId).HasColumnName("ThirdPartyParentID").IsOptional().HasColumnType("int");
            Property(x => x.ThirdPartyNodePath).HasColumnName("ThirdPartyNodePath").IsOptional().HasColumnType("nvarchar").HasMaxLength(1000);
            Property(x => x.ThirdPartyUniques).HasColumnName("ThirdPartyUniques").IsOptional().HasColumnType("int");
            Property(x => x.ThirdPartyCost).HasColumnName("ThirdPartyCost").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.ThirdPartySelectable).HasColumnName("ThirdPartySelectable").IsOptional().HasColumnType("bit");
            Property(x => x.ThirdPartyHasChildren).HasColumnName("ThirdPartyHasChildren").IsOptional().HasColumnType("bit");
            Property(x => x.SegmentParentId).HasColumnName("SegmentParentID").IsOptional().HasColumnType("int");
            Property(x => x.ThirdPartyIsDeleted).HasColumnName("ThirdPartyIsDeleted").IsOptional().HasColumnType("bit");
            Property(x => x.ThirdPartyCampaignId).HasColumnName("ThirdPartyCampaignId").IsOptional().HasColumnType("int");
            Property(x => x.ConversionPostViewLifetimePeriodId).HasColumnName("ConversionPostViewLifetimePeriodID").IsOptional().HasColumnType("int");
            Property(x => x.ConversionPostClickLifetimePeriodId).HasColumnName("ConversionPostClickLifetimePeriodID").IsOptional().HasColumnType("int");
            Property(x => x.ConversionAttributionCountingRecencyPeriodId).HasColumnName("ConversionAttributionCountingRecencyPeriodID").IsOptional().HasColumnType("int");
            Property(x => x.Priority).HasColumnName("Priority").IsRequired().HasColumnType("int");
            Property(x => x.UtcSegmentExpiryDate).HasColumnName("UtcSegmentExpiryDate").IsOptional().HasColumnType("datetime");

            // Foreign keys
            HasOptional(a => a.Advertiser).WithMany(b => b.Segments).HasForeignKey(c => c.AdvertiserId); // FK_Segment_Advertiser
            HasOptional(a => a.AttributionCountingMode).WithMany(b => b.Segments).HasForeignKey(c => c.ConversionAttributionCountingModeId); // FK_Segment_AttributionCountingMode
            HasOptional(a => a.AttributionModel).WithMany(b => b.Segments).HasForeignKey(c => c.ConversionAttributionModelId); // FK_Segment_AttributionModel
            HasOptional(a => a.BuyerAccount).WithMany(b => b.Segments).HasForeignKey(c => c.BuyerAccountId); // FK_Segment_BuyerAccount
            HasOptional(a => a.CampaignPeriod).WithMany(b => b.Segments).HasForeignKey(c => c.ThirdPartyPeriodId); // FK_Segment_ThirdPartyPeriodID
            HasOptional(a => a.Country).WithMany(b => b.Segments).HasForeignKey(c => c.TargetGeographyCountryId); // FK_Segment_TargetGeographyCountryId
            HasOptional(a => a.ThirdPartyDataSet).WithMany(b => b.Segments).HasForeignKey(c => c.ThirdPartyDataSetId); // FK_Segment_ThirdPartyDataSet
            HasRequired(a => a.CampaignStatus).WithMany(b => b.Segments).HasForeignKey(c => c.SegmentStatusId); // FK_Segment_CampaignStatus
            HasRequired(a => a.SegmentType).WithMany(b => b.Segments).HasForeignKey(c => c.SegmentTypeId); // FK_Segment_SegmentType
            HasMany(t => t.ThirdPartyTaxonomies).WithMany(t => t.Segments).Map(m => 
            {
                m.ToTable("SegmentThirdPartyTaxonomy", "dbo");
                m.MapLeftKey("SegmentID");
                m.MapRightKey("ThirdPartyTaxonomyID");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SegmentPerformance
    internal partial class SegmentPerformanceMap : EntityTypeConfiguration<SegmentPerformance>
    {
        public SegmentPerformanceMap()
            : this("dbo")
        {
        }
 
        public SegmentPerformanceMap(string schema)
        {
            ToTable(schema + ".SegmentPerformance");
            HasKey(x => new { x.SegmentId, x.IntervalId, x.IntervalValue });

            Property(x => x.SegmentId).HasColumnName("SegmentID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalId).HasColumnName("IntervalID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IntervalValue).HasColumnName("IntervalValue").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Uniques).HasColumnName("Uniques").IsRequired().HasColumnType("int");
            Property(x => x.MemberCount).HasColumnName("MemberCount").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.Interval).WithMany(b => b.SegmentPerformances).HasForeignKey(c => c.IntervalId); // FK_SegmentPerformance_Interval
            HasRequired(a => a.Segment).WithMany(b => b.SegmentPerformances).HasForeignKey(c => c.SegmentId); // FK_SegmentPerformance_Segment_SegmentID
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SegmentReport
    internal partial class SegmentReportMap : EntityTypeConfiguration<SegmentReport>
    {
        public SegmentReportMap()
            : this("dbo")
        {
        }
 
        public SegmentReportMap(string schema)
        {
            ToTable(schema + ".SegmentReport");
            HasKey(x => new { x.SegmentId, x.Period });

            Property(x => x.SegmentId).HasColumnName("SegmentID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Period).HasColumnName("Period").IsRequired().HasColumnType("datetime").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Uniques).HasColumnName("Uniques").IsRequired().HasColumnType("int");
            Property(x => x.UsdSpend).HasColumnName("UsdSpend").IsRequired().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.LocalSpend).HasColumnName("LocalSpend").IsRequired().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.LocalBrokerage).HasColumnName("LocalBrokerage").IsRequired().HasColumnType("decimal").HasPrecision(18,10);
            Property(x => x.IsBilled).HasColumnName("IsBilled").IsRequired().HasColumnType("bit");

            // Foreign keys
            HasRequired(a => a.Segment).WithMany(b => b.SegmentReports).HasForeignKey(c => c.SegmentId); // FK_SegmentReport_Segment
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SegmentThirdPartyTargeting
    internal partial class SegmentThirdPartyTargetingMap : EntityTypeConfiguration<SegmentThirdPartyTargeting>
    {
        public SegmentThirdPartyTargetingMap()
            : this("dbo")
        {
        }
 
        public SegmentThirdPartyTargetingMap(string schema)
        {
            ToTable(schema + ".SegmentThirdPartyTargeting");
            HasKey(x => x.SegmentThirdPartyTargetingId);

            Property(x => x.SegmentThirdPartyTargetingId).HasColumnName("SegmentThirdPartyTargetingID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.SegmentId).HasColumnName("SegmentID").IsRequired().HasColumnType("int");
            Property(x => x.ThirdPartyTaxonomyId).HasColumnName("ThirdPartyTaxonomyID").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.Segment).WithMany(b => b.SegmentThirdPartyTargetings).HasForeignKey(c => c.SegmentId); // FK_SegmentThirdPartyTargeting_ThirdPartyTaxonomyID
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SegmentType
    internal partial class SegmentTypeMap : EntityTypeConfiguration<SegmentType>
    {
        public SegmentTypeMap()
            : this("dbo")
        {
        }
 
        public SegmentTypeMap(string schema)
        {
            ToTable(schema + ".SegmentType");
            HasKey(x => x.SegmentTypeId);

            Property(x => x.SegmentTypeId).HasColumnName("SegmentTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.SegmentTypeName).HasColumnName("SegmentTypeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SensitiveCategory
    internal partial class SensitiveCategoryMap : EntityTypeConfiguration<SensitiveCategory>
    {
        public SensitiveCategoryMap()
            : this("dbo")
        {
        }
 
        public SensitiveCategoryMap(string schema)
        {
            ToTable(schema + ".SensitiveCategory");
            HasKey(x => x.SensitiveCategoryId);

            Property(x => x.SensitiveCategoryId).HasColumnName("SensitiveCategoryId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.SensitiveCategoryName).HasColumnName("SensitiveCategoryName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SharingSegments
    internal partial class SharingSegmentMap : EntityTypeConfiguration<SharingSegment>
    {
        public SharingSegmentMap()
            : this("dbo")
        {
        }
 
        public SharingSegmentMap(string schema)
        {
            ToTable(schema + ".SharingSegments");
            HasKey(x => new { x.SharingSegmentId, x.BuyerAccountId });

            Property(x => x.SharingSegmentId).HasColumnName("SharingSegmentID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.BuyerAccount).WithMany(b => b.SharingSegments).HasForeignKey(c => c.BuyerAccountId); // FK_SharingSegments_BuyerAccount
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SiteLevelOptimisationOverride
    internal partial class SiteLevelOptimisationOverrideMap : EntityTypeConfiguration<SiteLevelOptimisationOverride>
    {
        public SiteLevelOptimisationOverrideMap()
            : this("dbo")
        {
        }
 
        public SiteLevelOptimisationOverrideMap(string schema)
        {
            ToTable(schema + ".SiteLevelOptimisationOverride");
            HasKey(x => x.WebsiteId);

            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.WebsiteUrl).HasColumnName("WebsiteUrl").IsOptional().HasColumnType("nvarchar").HasMaxLength(450);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SiteListLookup
    internal partial class SiteListLookupMap : EntityTypeConfiguration<SiteListLookup>
    {
        public SiteListLookupMap()
            : this("dbo")
        {
        }
 
        public SiteListLookupMap(string schema)
        {
            ToTable(schema + ".SiteListLookup");
            HasKey(x => x.WebsiteId);

            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("bigint");
            Property(x => x.SiteListId).HasColumnName("SiteListID").IsOptional().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SiteListOption
    internal partial class SiteListOptionMap : EntityTypeConfiguration<SiteListOption>
    {
        public SiteListOptionMap()
            : this("dbo")
        {
        }
 
        public SiteListOptionMap(string schema)
        {
            ToTable(schema + ".SiteListOption");
            HasKey(x => x.SiteListOptionId);

            Property(x => x.SiteListOptionId).HasColumnName("SiteListOptionID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.SiteListOptionName).HasColumnName("SiteListOptionName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SiteMetaAndDetails
    internal partial class SiteMetaAndDetailMap : EntityTypeConfiguration<SiteMetaAndDetail>
    {
        public SiteMetaAndDetailMap()
            : this("dbo")
        {
        }
 
        public SiteMetaAndDetailMap(string schema)
        {
            ToTable(schema + ".SiteMetaAndDetails");
            HasKey(x => x.WebsiteId);

            Property(x => x.WebsiteId).HasColumnName("WebsiteId").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.SiteMeta).HasColumnName("SiteMeta").IsOptional().HasColumnType("xml");
            Property(x => x.SiteDetails).HasColumnName("SiteDetails").IsOptional().HasColumnType("xml");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SupplySource
    internal partial class SupplySourceMap : EntityTypeConfiguration<SupplySource>
    {
        public SupplySourceMap()
            : this("dbo")
        {
        }
 
        public SupplySourceMap(string schema)
        {
            ToTable(schema + ".SupplySource");
            HasKey(x => x.SupplySourceId);

            Property(x => x.SupplySourceId).HasColumnName("SupplySourceID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.SupplySourceName).HasColumnName("SupplySourceName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SupportedMobileCarriersView
    internal partial class SupportedMobileCarriersViewMap : EntityTypeConfiguration<SupportedMobileCarriersView>
    {
        public SupportedMobileCarriersViewMap()
            : this("dbo")
        {
        }
 
        public SupportedMobileCarriersViewMap(string schema)
        {
            ToTable(schema + ".SupportedMobileCarriersView");
            HasKey(x => new { x.GeoCountryId, x.Mcc, x.Mnc, x.CountryName });

            Property(x => x.GeoCountryId).HasColumnName("GeoCountryID").IsRequired().HasColumnType("int");
            Property(x => x.Mcc).HasColumnName("MCC").IsRequired().HasColumnType("int");
            Property(x => x.Mnc).HasColumnName("MNC").IsRequired().HasColumnType("int");
            Property(x => x.MobileCarrierName).HasColumnName("MobileCarrierName").IsOptional().HasColumnType("nvarchar").HasMaxLength(250);
            Property(x => x.CountryName).HasColumnName("CountryName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // sysdiagrams
    internal partial class SysdiagramMap : EntityTypeConfiguration<Sysdiagram>
    {
        public SysdiagramMap()
            : this("dbo")
        {
        }
 
        public SysdiagramMap(string schema)
        {
            ToTable(schema + ".sysdiagrams");
            HasKey(x => x.DiagramId);

            Property(x => x.Name).HasColumnName("name").IsRequired().HasColumnType("nvarchar").HasMaxLength(128);
            Property(x => x.PrincipalId).HasColumnName("principal_id").IsRequired().HasColumnType("int");
            Property(x => x.DiagramId).HasColumnName("diagram_id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Version).HasColumnName("version").IsOptional().HasColumnType("int");
            Property(x => x.Definition).HasColumnName("definition").IsOptional().HasColumnType("varbinary");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SystemBlackListWebsite
    internal partial class SystemBlackListWebsiteMap : EntityTypeConfiguration<SystemBlackListWebsite>
    {
        public SystemBlackListWebsiteMap()
            : this("dbo")
        {
        }
 
        public SystemBlackListWebsiteMap(string schema)
        {
            ToTable(schema + ".SystemBlackListWebsite");
            HasKey(x => x.WebsiteId);

            Property(x => x.WebsiteId).HasColumnName("WebsiteID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.WebsiteUrl).HasColumnName("WebsiteUrl").IsRequired().HasColumnType("nvarchar").HasMaxLength(450);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SystemFeature
    internal partial class SystemFeatureMap : EntityTypeConfiguration<SystemFeature>
    {
        public SystemFeatureMap()
            : this("dbo")
        {
        }
 
        public SystemFeatureMap(string schema)
        {
            ToTable(schema + ".SystemFeature");
            HasKey(x => x.SystemFeatureCode);

            Property(x => x.SystemFeatureCode).HasColumnName("SystemFeatureCode").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.SystemFeatureName).HasColumnName("SystemFeatureName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SystemSpendLimits
    internal partial class SystemSpendLimitMap : EntityTypeConfiguration<SystemSpendLimit>
    {
        public SystemSpendLimitMap()
            : this("dbo")
        {
        }
 
        public SystemSpendLimitMap(string schema)
        {
            ToTable(schema + ".SystemSpendLimits");
            HasKey(x => x.CurrentHour);

            Property(x => x.CurrentHour).HasColumnName("CurrentHour").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.MaxSpendLimitUsdMicros).HasColumnName("MaxSpendLimitUsdMicros").IsRequired().HasColumnType("bigint");
            Property(x => x.MinSpendLimitUsdMicros).HasColumnName("MinSpendLimitUsdMicros").IsRequired().HasColumnType("bigint");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // TargetingAction
    internal partial class TargetingActionMap : EntityTypeConfiguration<TargetingAction>
    {
        public TargetingActionMap()
            : this("dbo")
        {
        }
 
        public TargetingActionMap(string schema)
        {
            ToTable(schema + ".TargetingAction");
            HasKey(x => x.TargetingActionId);

            Property(x => x.TargetingActionId).HasColumnName("TargetingActionID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingActionName).HasColumnName("TargetingActionName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // TargetingAttributeType
    internal partial class TargetingAttributeTypeMap : EntityTypeConfiguration<TargetingAttributeType>
    {
        public TargetingAttributeTypeMap()
            : this("dbo")
        {
        }
 
        public TargetingAttributeTypeMap(string schema)
        {
            ToTable(schema + ".TargetingAttributeType");
            HasKey(x => x.TargetingAttributeTypeId);

            Property(x => x.TargetingAttributeTypeId).HasColumnName("TargetingAttributeTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TargetingAttributeTypeName).HasColumnName("TargetingAttributeTypeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Technology
    internal partial class TechnologyMap : EntityTypeConfiguration<Technology>
    {
        public TechnologyMap()
            : this("dbo")
        {
        }
 
        public TechnologyMap(string schema)
        {
            ToTable(schema + ".Technology");
            HasKey(x => x.TechnologyId);

            Property(x => x.TechnologyId).HasColumnName("TechnologyID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TechnologyName).HasColumnName("TechnologyName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.MediaTypeId).HasColumnName("MediaTypeID").IsOptional().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.MediaType).WithMany(b => b.Technologies).HasForeignKey(c => c.MediaTypeId); // FK_Technology_MediaType
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Theme
    internal partial class ThemeMap : EntityTypeConfiguration<Theme>
    {
        public ThemeMap()
            : this("dbo")
        {
        }
 
        public ThemeMap(string schema)
        {
            ToTable(schema + ".Theme");
            HasKey(x => x.ThemeId);

            Property(x => x.ThemeId).HasColumnName("ThemeID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ThemeUuid).HasColumnName("ThemeUuid").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.ThemeName).HasColumnName("ThemeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.Description).HasColumnName("Description").IsOptional().HasColumnType("nvarchar").HasMaxLength(1024);
            Property(x => x.LogoImageUrl).HasColumnName("LogoImageUrl").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.ThemeCssUrl).HasColumnName("ThemeCssUrl").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.JavaScriptUrl).HasColumnName("JavaScriptUrl").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired().HasColumnType("bit");
            Property(x => x.PlatformName).HasColumnName("PlatformName").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.DefaultDomain).HasColumnName("DefaultDomain").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.ThemeCss).HasColumnName("ThemeCss").IsOptional().HasColumnType("nvarchar");
            Property(x => x.CustomJavascript).HasColumnName("CustomJavascript").IsOptional().HasColumnType("nvarchar");
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsOptional().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.BuyerAccount).WithMany(b => b.Themes).HasForeignKey(c => c.BuyerAccountId); // FK_Theme_BuyerAccount
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ThirdPartyCampaigns
    internal partial class ThirdPartyCampaignMap : EntityTypeConfiguration<ThirdPartyCampaign>
    {
        public ThirdPartyCampaignMap()
            : this("dbo")
        {
        }
 
        public ThirdPartyCampaignMap(string schema)
        {
            ToTable(schema + ".ThirdPartyCampaigns");
            HasKey(x => x.ThirdPartyCampaignId);

            Property(x => x.ThirdPartyCampaignId).HasColumnName("ThirdPartyCampaignId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CampaignName).HasColumnName("CampaignName").IsRequired().HasColumnType("nvarchar").HasMaxLength(1024);
            Property(x => x.InputFileName).HasColumnName("InputFileName").IsRequired().HasColumnType("nvarchar").HasMaxLength(1024);
            Property(x => x.IsPublic).HasColumnName("IsPublic").IsRequired().HasColumnType("bit");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ThirdPartyCampaignBuyerAccounts
    internal partial class ThirdPartyCampaignBuyerAccountMap : EntityTypeConfiguration<ThirdPartyCampaignBuyerAccount>
    {
        public ThirdPartyCampaignBuyerAccountMap()
            : this("dbo")
        {
        }
 
        public ThirdPartyCampaignBuyerAccountMap(string schema)
        {
            ToTable(schema + ".ThirdPartyCampaignBuyerAccounts");
            HasKey(x => new { x.ThirdPartyCampaignThirdPartyCampaignId, x.BuyerAccountBuyerAccountId });

            Property(x => x.ThirdPartyCampaignThirdPartyCampaignId).HasColumnName("ThirdPartyCampaign_ThirdPartyCampaignId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BuyerAccountBuyerAccountId).HasColumnName("BuyerAccount_BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ThirdPartyDataSet
    internal partial class ThirdPartyDataSetMap : EntityTypeConfiguration<ThirdPartyDataSet>
    {
        public ThirdPartyDataSetMap()
            : this("dbo")
        {
        }
 
        public ThirdPartyDataSetMap(string schema)
        {
            ToTable(schema + ".ThirdPartyDataSet");
            HasKey(x => x.ThirdPartyDataSetId);

            Property(x => x.ThirdPartyDataSetId).HasColumnName("ThirdPartyDataSetID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.DataSetName).HasColumnName("DataSetName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);

            // Foreign keys
            HasRequired(a => a.Partner).WithMany(b => b.ThirdPartyDataSets).HasForeignKey(c => c.PartnerId); // FK_PartnerDataSet_Partner
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ThirdPartyRatecardImport
    internal partial class ThirdPartyRatecardImportMap : EntityTypeConfiguration<ThirdPartyRatecardImport>
    {
        public ThirdPartyRatecardImportMap()
            : this("dbo")
        {
        }
 
        public ThirdPartyRatecardImportMap(string schema)
        {
            ToTable(schema + ".ThirdPartyRatecardImport");
            HasKey(x => x.ThirdPartyRatecardImportId);

            Property(x => x.NodePath).HasColumnName("NodePath").IsRequired().HasColumnType("nvarchar").HasMaxLength(4000);
            Property(x => x.Cpm).HasColumnName("Cpm").IsOptional().HasColumnType("decimal").HasPrecision(19,4);
            Property(x => x.ThirdPartyRatecardImportId).HasColumnName("ThirdPartyRatecardImportID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ThirdPartySegmentImport
    internal partial class ThirdPartySegmentImportMap : EntityTypeConfiguration<ThirdPartySegmentImport>
    {
        public ThirdPartySegmentImportMap()
            : this("dbo")
        {
        }
 
        public ThirdPartySegmentImportMap(string schema)
        {
            ToTable(schema + ".ThirdPartySegmentImport");
            HasKey(x => x.ThirdPartySegmentImportId);

            Property(x => x.RtbSegmentId).HasColumnName("RtbSegmentId").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            Property(x => x.SegmentId).HasColumnName("SegmentId").IsRequired().HasColumnType("int");
            Property(x => x.ParentId).HasColumnName("ParentId").IsOptional().HasColumnType("int");
            Property(x => x.HasChildren).HasColumnName("HasChildren").IsRequired().HasColumnType("bit");
            Property(x => x.IsSelectable).HasColumnName("IsSelectable").IsRequired().HasColumnType("bit");
            Property(x => x.SegmentName).HasColumnName("SegmentName").IsRequired().HasColumnType("nvarchar").HasMaxLength(1024);
            Property(x => x.NodePath).HasColumnName("NodePath").IsRequired().HasColumnType("nvarchar").HasMaxLength(4000);
            Property(x => x.SegmentDescription).HasColumnName("SegmentDescription").IsRequired().HasColumnType("nvarchar").HasMaxLength(4000);
            Property(x => x.ThirdPartyCampaignId).HasColumnName("ThirdPartyCampaignId").IsRequired().HasColumnType("int");
            Property(x => x.ThirdPartySegmentImportId).HasColumnName("ThirdPartySegmentImportID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ThirdPartyTaxonomy
    internal partial class ThirdPartyTaxonomyMap : EntityTypeConfiguration<ThirdPartyTaxonomy>
    {
        public ThirdPartyTaxonomyMap()
            : this("dbo")
        {
        }
 
        public ThirdPartyTaxonomyMap(string schema)
        {
            ToTable(schema + ".ThirdPartyTaxonomy");
            HasKey(x => x.ThirdPartyTaxonomyId);

            Property(x => x.ThirdPartyTaxonomyId).HasColumnName("ThirdPartyTaxonomyID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ParentId).HasColumnName("ParentID").IsOptional().HasColumnType("int");
            Property(x => x.PartnerId).HasColumnName("PartnerID").IsRequired().HasColumnType("int");
            Property(x => x.PartnerRef).HasColumnName("PartnerRef").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.NodeName).HasColumnName("NodeName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.NodePath).HasColumnName("NodePath").IsRequired().HasColumnType("nvarchar").HasMaxLength(1000);

            // Foreign keys
            HasRequired(a => a.Partner).WithMany(b => b.ThirdPartyTaxonomies).HasForeignKey(c => c.PartnerId); // FK_ThirdPartyTaxonomy_Partner
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ThirdPartyTaxonomyRateCard
    internal partial class ThirdPartyTaxonomyRateCardMap : EntityTypeConfiguration<ThirdPartyTaxonomyRateCard>
    {
        public ThirdPartyTaxonomyRateCardMap()
            : this("dbo")
        {
        }
 
        public ThirdPartyTaxonomyRateCardMap(string schema)
        {
            ToTable(schema + ".ThirdPartyTaxonomyRateCard");
            HasKey(x => new { x.ThirdPartyTaxonomyId, x.ThirdPartyDataSetId });

            Property(x => x.ThirdPartyTaxonomyId).HasColumnName("ThirdPartyTaxonomyID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ThirdPartyDataSetId).HasColumnName("ThirdPartyDataSetID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Reach).HasColumnName("Reach").IsRequired().HasColumnType("int");
            Property(x => x.PriceFloor).HasColumnName("PriceFloor").IsRequired().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.ChildCount).HasColumnName("ChildCount").IsRequired().HasColumnType("int");
            Property(x => x.ChildReach).HasColumnName("ChildReach").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.ThirdPartyDataSet).WithMany(b => b.ThirdPartyTaxonomyRateCards).HasForeignKey(c => c.ThirdPartyDataSetId); // FK_ThirdPartyTaxonomyRateCard_ThirdPartyDataSet
            HasRequired(a => a.ThirdPartyTaxonomy).WithMany(b => b.ThirdPartyTaxonomyRateCards).HasForeignKey(c => c.ThirdPartyTaxonomyId); // FK_ThirdPartyTaxonomyRateCard_ThirdPartyTaxonomy
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // TimeSpan
    internal partial class TimeSpanMap : EntityTypeConfiguration<TimeSpan>
    {
        public TimeSpanMap()
            : this("dbo")
        {
        }
 
        public TimeSpanMap(string schema)
        {
            ToTable(schema + ".TimeSpan");
            HasKey(x => x.TimeSpanId);

            Property(x => x.TimeSpanId).HasColumnName("TimeSpanID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description).HasColumnName("Description").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // TimeZone
    internal partial class TimeZoneMap : EntityTypeConfiguration<TimeZone>
    {
        public TimeZoneMap()
            : this("dbo")
        {
        }
 
        public TimeZoneMap(string schema)
        {
            ToTable(schema + ".TimeZone");
            HasKey(x => x.TimeZoneId);

            Property(x => x.TimeZoneId).HasColumnName("TimeZoneID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TimeZoneName).HasColumnName("TimeZoneName").IsOptional().HasColumnType("nvarchar").HasMaxLength(150);
            Property(x => x.TimeZoneCode).HasColumnName("TimeZoneCode").IsOptional().HasColumnType("nvarchar").HasMaxLength(150);
            Property(x => x.GmtOffset).HasColumnName("GmtOffset").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.DisplayIndex).HasColumnName("DisplayIndex").IsOptional().HasColumnType("int");
            Property(x => x.MinutesOffset).HasColumnName("MinutesOffset").IsRequired().HasColumnType("int");
            Property(x => x.OlsonName).HasColumnName("OlsonName").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // User
    internal partial class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
            : this("dbo")
        {
        }
 
        public UserMap(string schema)
        {
            ToTable(schema + ".User");
            HasKey(x => x.UserId);

            Property(x => x.UserId).HasColumnName("UserID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.UserName).HasColumnName("UserName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.FirstName).HasColumnName("FirstName").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.LastName).HasColumnName("LastName").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Mobile).HasColumnName("Mobile").IsOptional().HasColumnType("nvarchar").HasMaxLength(30);
            Property(x => x.Email).HasColumnName("Email").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.LanguageId).HasColumnName("LanguageID").IsOptional().HasColumnType("int");
            Property(x => x.IsSystemAdministrator).HasColumnName("IsSystemAdministrator").IsRequired().HasColumnType("bit");
            Property(x => x.IsSuperAdministrator).HasColumnName("IsSuperAdministrator").IsRequired().HasColumnType("bit");
            Property(x => x.TermsAndConditionsAgreedDate).HasColumnName("TermsAndConditionsAgreedDate").IsOptional().HasColumnType("datetime");
            Property(x => x.TimeSpanId).HasColumnName("TimeSpanID").IsRequired().HasColumnType("int");
            Property(x => x.Mentioned).HasColumnName("Mentioned").IsRequired().HasColumnType("int");
            Property(x => x.Position).HasColumnName("Position").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);

            // Foreign keys
            HasOptional(a => a.Language).WithMany(b => b.Users).HasForeignKey(c => c.LanguageId); // FK_User_Language
            HasRequired(a => a.TimeSpan).WithMany(b => b.Users).HasForeignKey(c => c.TimeSpanId); // FK_User_TimeSpan
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // UserAdvertiserRole
    internal partial class UserAdvertiserRoleMap : EntityTypeConfiguration<UserAdvertiserRole>
    {
        public UserAdvertiserRoleMap()
            : this("dbo")
        {
        }
 
        public UserAdvertiserRoleMap(string schema)
        {
            ToTable(schema + ".UserAdvertiserRole");
            HasKey(x => new { x.UserId, x.AdvertiserId });

            Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.AdvertiserId).HasColumnName("AdvertiserID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.RoleName).HasColumnName("RoleName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);

            // Foreign keys
            HasRequired(a => a.Advertiser).WithMany(b => b.UserAdvertiserRoles).HasForeignKey(c => c.AdvertiserId); // FK_UserAdvertiserRole_Advertiser
            HasRequired(a => a.User).WithMany(b => b.UserAdvertiserRoles).HasForeignKey(c => c.UserId); // FK_UserAdvertiserRole_User
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // UserBuyerRole
    internal partial class UserBuyerRoleMap : EntityTypeConfiguration<UserBuyerRole>
    {
        public UserBuyerRoleMap()
            : this("dbo")
        {
        }
 
        public UserBuyerRoleMap(string schema)
        {
            ToTable(schema + ".UserBuyerRole");
            HasKey(x => new { x.UserId, x.BuyerAccountId });

            Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.RoleName).HasColumnName("RoleName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.IsAccepted).HasColumnName("IsAccepted").IsRequired().HasColumnType("bit");
            Property(x => x.CostView).HasColumnName("CostView").IsRequired().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.BuyerAccount).WithMany(b => b.UserBuyerRoles).HasForeignKey(c => c.BuyerAccountId); // FK_UserBuyerRole_BuyerAccount
            HasRequired(a => a.User).WithMany(b => b.UserBuyerRoles).HasForeignKey(c => c.UserId); // FK_UserBuyerRole_User
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // UserTag
    internal partial class UserTagMap : EntityTypeConfiguration<UserTag>
    {
        public UserTagMap()
            : this("dbo")
        {
        }
 
        public UserTagMap(string schema)
        {
            ToTable(schema + ".UserTag");
            HasKey(x => x.UserTagId);

            Property(x => x.UserTagId).HasColumnName("UserTagId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.TagName).HasColumnName("TagName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);

            // Foreign keys
            HasRequired(a => a.User).WithMany(b => b.UserTags).HasForeignKey(c => c.UserId); // FK_UserTag_User
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Vertical
    internal partial class VerticalMap : EntityTypeConfiguration<Vertical>
    {
        public VerticalMap()
            : this("dbo")
        {
        }
 
        public VerticalMap(string schema)
        {
            ToTable(schema + ".Vertical");
            HasKey(x => x.VerticalId);

            Property(x => x.VerticalId).HasColumnName("VerticalID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ParentVerticalId).HasColumnName("ParentVerticalID").IsOptional().HasColumnType("int");
            Property(x => x.VerticalName).HasColumnName("VerticalName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.VerticalPath).HasColumnName("VerticalPath").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.IabReference).HasColumnName("IABReference").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);

            // Foreign keys
            HasOptional(a => a.Vertical_ParentVerticalId).WithMany(b => b.Verticals).HasForeignKey(c => c.ParentVerticalId); // FK_Vertical_ParentVertical
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // VerticalMapping
    internal partial class VerticalMappingMap : EntityTypeConfiguration<VerticalMapping>
    {
        public VerticalMappingMap()
            : this("dbo")
        {
        }
 
        public VerticalMappingMap(string schema)
        {
            ToTable(schema + ".VerticalMapping");
            HasKey(x => new { x.FromVerticalId, x.ToVerticalId, x.VerticalMappingTypeId });

            Property(x => x.FromVerticalId).HasColumnName("FromVerticalID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ToVerticalId).HasColumnName("ToVerticalID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.VerticalMappingTypeId).HasColumnName("VerticalMappingTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // VerticalMappingMigrationAccessLog
    internal partial class VerticalMappingMigrationAccessLogMap : EntityTypeConfiguration<VerticalMappingMigrationAccessLog>
    {
        public VerticalMappingMigrationAccessLogMap()
            : this("dbo")
        {
        }
 
        public VerticalMappingMigrationAccessLogMap(string schema)
        {
            ToTable(schema + ".VerticalMappingMigrationAccessLog");
            HasKey(x => new { x.UserId, x.BuyerAccountId });

            Property(x => x.UserId).HasColumnName("UserID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BuyerAccountId).HasColumnName("BuyerAccountID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.LastDeferDateTime).HasColumnName("LastDeferDateTime").IsOptional().HasColumnType("datetime");
            Property(x => x.LastMigrationDateTime).HasColumnName("LastMigrationDateTime").IsOptional().HasColumnType("datetime");
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // VerticalStringReferenceToVIDsMapping
    internal partial class VerticalStringReferenceToViDsMappingMap : EntityTypeConfiguration<VerticalStringReferenceToViDsMapping>
    {
        public VerticalStringReferenceToViDsMappingMap()
            : this("dbo")
        {
        }
 
        public VerticalStringReferenceToViDsMappingMap(string schema)
        {
            ToTable(schema + ".VerticalStringReferenceToVIDsMapping");
            HasKey(x => x.VerticalStringReferenceToViDsMappingId);

            Property(x => x.Reference).HasColumnName("Reference").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.V1).HasColumnName("v1").IsOptional().HasColumnType("int");
            Property(x => x.V2).HasColumnName("v2").IsOptional().HasColumnType("int");
            Property(x => x.V3).HasColumnName("v3").IsOptional().HasColumnType("int");
            Property(x => x.VerticalStringReferenceToViDsMappingId).HasColumnName("VerticalStringReferenceToVIDsMappingID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // VerticalView
    internal partial class VerticalViewMap : EntityTypeConfiguration<VerticalView>
    {
        public VerticalViewMap()
            : this("dbo")
        {
        }
 
        public VerticalViewMap(string schema)
        {
            ToTable(schema + ".VerticalView");
            HasKey(x => new { x.VerticalId, x.Vertical1Id, x.Vertical1Name });

            Property(x => x.VerticalId).HasColumnName("VerticalID").IsRequired().HasColumnType("int");
            Property(x => x.Vertical1Id).HasColumnName("Vertical1ID").IsRequired().HasColumnType("int");
            Property(x => x.Vertical2Id).HasColumnName("Vertical2ID").IsOptional().HasColumnType("int");
            Property(x => x.Vertical3Id).HasColumnName("Vertical3ID").IsOptional().HasColumnType("int");
            Property(x => x.Vertical1Name).HasColumnName("Vertical1Name").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.Vertical2Name).HasColumnName("Vertical2Name").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.Vertical3Name).HasColumnName("Vertical3Name").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);
            InitializePartial();
        }
        partial void InitializePartial();
    }


    // ************************************************************************
    // Stored procedure return models

    public partial class GetAdGroupLifeTimeReturnModel
    {
        public DateTime? UtcStartDateTime { get; set; }
        public DateTime? UtcEndDateTime { get; set; }
    }

    public partial class GetProductCategoryConversionRatesReturnModel
    {
        public Int32 BuyerAccountID { get; set; }
        public Int32? ProductCategoryID { get; set; }
        public Double? ConversionRate { get; set; }
    }

    public partial class SafetyCheckNoRunnableStrategiesSpendingOverBudgetReturnModel
    {
        public String Message { get; set; }
        public Int32 AdGroupID { get; set; }
        public String AdGroupName { get; set; }
        public String RtbAdGroupID { get; set; }
        public Decimal? Spend { get; set; }
        public Decimal BudgetAmount { get; set; }
        public Decimal? BudgetThreshold { get; set; }
        public DateTime? UtcStartDateTime { get; set; }
        public DateTime? UtcEndDateTime { get; set; }
        public String Status { get; set; }
    }

    public partial class SafetyCheckNoStrategiesEnabledPastEndDateReturnModel
    {
        public String Message { get; set; }
        public Int32 AdGroupId { get; set; }
        public String AdGroupName { get; set; }
        public String RtbAdGroupID { get; set; }
        public DateTime? UtcStartDateTime { get; set; }
        public DateTime? UtcEndDateTime { get; set; }
        public Decimal BudgetAmount { get; set; }
        public Decimal? Spend { get; set; }
    }

}


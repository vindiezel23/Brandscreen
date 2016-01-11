namespace Brandscreen.Core.Services.Reports
{
    public enum ReportTypeEnum
    {
        Advertiser,
        Brand,
        Campaign,
        Creatives,
        DataSegment,
        DayPart,
        Exchange,
        GeographyCity,
        GeographyRegion,
        GeographyCountry,
        Language,
        PagePosition,
        Publisher,
        Strategy,
        Vertical,
        Domain,
        VideoCreatives,
        Device,
        Conversion,
        ConversionTag,
        Deal,
        DirectBuy,
        WeeklySiteSummary,
        MobileCarrier,
    }

    public enum ReportLevelEnum
    {
        Summary,
        Daily
    }

    public enum ReportScopeEnum
    {
        Buyer,
        Advertiser,
        Brand,
        Campaign,
        Strategy
    }
}
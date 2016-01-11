namespace Brandscreen.Analytics.Entities
{
    public interface IPerformanceData
    {
        long Bids { get; set; }
        long Impressions { get; set; }
        long Clicks { get; set; }
        long UnfilteredClicks { get; set; }
        long Conversions { get; set; }
        long PostViewConversions { get; set; }
        long PostClickConversions { get; set; }
        long? SpendLocalMicros { get; set; }
        long? ClientCostLocalMicros { get; set; }

        long MediaCostLocalMicros { get; set; }
        long DataCostLocalMicros { get; set; }
        long? MediaClientCostLocalMicros { get; set; }
        long? DataClientCostLocalMicros { get; set; }

        long? AdSlotDurationInSeconds { get; set; }

        double? Ctr { get; set; }
        decimal? Cpm { get; set; }
        decimal? Cpc { get; set; }
        decimal? Cpa { get; set; }
        decimal? Cpms { get; set; }
        decimal? ClientCostCpm { get; set; }
        decimal? ClientCostCpc { get; set; }
        decimal? ClientCostCpa { get; set; }
        decimal? ClientCostCpms { get; set; }
    }

    public partial class AdAnalyticsReportId : IPerformanceData
    {
    }
}
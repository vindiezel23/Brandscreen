using Brandscreen.Analytics.Entities;

namespace Brandscreen.Core.Services.Reports
{
    public abstract class PerformanceData : IPerformanceData
    {
        public long Bids { get; set; }
        public long Impressions { get; set; }
        public long Clicks { get; set; }
        public long UnfilteredClicks { get; set; }
        public long Conversions { get; set; }
        public long PostViewConversions { get; set; }
        public long PostClickConversions { get; set; }
        public long? SpendLocalMicros { get; set; }
        public long? ClientCostLocalMicros { get; set; }
        public long MediaCostLocalMicros { get; set; }
        public long DataCostLocalMicros { get; set; }
        public long? MediaClientCostLocalMicros { get; set; }
        public long? DataClientCostLocalMicros { get; set; }
        public long? AdSlotDurationInSeconds { get; set; }
        public double? Ctr { get; set; }
        public decimal? Cpm { get; set; }
        public decimal? Cpc { get; set; }
        public decimal? Cpa { get; set; }
        public decimal? Cpms { get; set; }
        public decimal? ClientCostCpm { get; set; }
        public decimal? ClientCostCpc { get; set; }
        public decimal? ClientCostCpa { get; set; }
        public decimal? ClientCostCpms { get; set; }
    }

    public class PerformanceData<T> : PerformanceData
    {
        public T KeyData { get; set; }
    }
}
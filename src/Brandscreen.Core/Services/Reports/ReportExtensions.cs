using System;
using System.Collections.Generic;
using System.Linq;
using Brandscreen.Analytics.Entities;

namespace Brandscreen.Core.Services.Reports
{
    public static class ReportExtensions
    {
        public static IEnumerable<PerformanceData<TKey>> AggregateReport<TKey, TPerformanceBase>(this IEnumerable<IGrouping<TKey, TPerformanceBase>> source)
            where TPerformanceBase : IPerformanceData
        {
            var tmp = source.Select(g => new
            {
                KeyData = g.Key,
                Perf = new
                {
                    Bids = g.Sum(v => v.Bids),
                    Impressions = g.Sum(v => v.Impressions),
                    Clicks = g.Sum(v => v.Clicks),
                    UnfilteredClicks = g.Sum(v => v.UnfilteredClicks),
                    Conversions = g.Sum(v => v.Conversions),
                    PostViewConversions = g.Sum(v => v.PostViewConversions),
                    PostClickConversions = g.Sum(v => v.PostClickConversions),
                    Spend = ((decimal) g.Sum(v => v.SpendLocalMicros.GetValueOrDefault(0)))/100/10000,
                    SpendMicros = g.Sum(v => v.SpendLocalMicros),
                    ClientCostDollars = ((decimal) g.Sum(v => v.ClientCostLocalMicros.GetValueOrDefault(0)))/100/10000,
                    ClientCostMicros = g.Sum(v => v.ClientCostLocalMicros),
                    MediaCostLocalMicros = g.Sum(v => v.MediaCostLocalMicros),
                    MediaClientCostLocalMicros = g.Sum(v => v.MediaClientCostLocalMicros),
                    DataCostLocalMicros = g.Sum(v => v.DataCostLocalMicros),
                    DataClientCostLocalMicros = g.Sum(v => v.DataClientCostLocalMicros),
                    AdSlotDurationInSeconds = g.Sum(v => v.AdSlotDurationInSeconds)
                }
            });

            const int reportDecimals = 1000000;

            var result = tmp.Select(g =>
            {
                var row = new PerformanceData<TKey>
                {
                    KeyData = g.KeyData,
                    Bids = g.Perf.Bids,
                    Impressions = g.Perf.Impressions,
                    Clicks = g.Perf.Clicks,
                    UnfilteredClicks = g.Perf.UnfilteredClicks,
                    Conversions = g.Perf.Conversions,
                    PostViewConversions = g.Perf.PostViewConversions,
                    PostClickConversions = g.Perf.PostClickConversions,
                    AdSlotDurationInSeconds = g.Perf.AdSlotDurationInSeconds,
                    SpendLocalMicros = g.Perf.SpendMicros,
                    ClientCostLocalMicros = g.Perf.ClientCostMicros,
                    MediaCostLocalMicros = g.Perf.MediaCostLocalMicros/reportDecimals,
                    MediaClientCostLocalMicros = g.Perf.MediaClientCostLocalMicros,
                    DataCostLocalMicros = g.Perf.DataCostLocalMicros/reportDecimals,
                    DataClientCostLocalMicros = g.Perf.DataClientCostLocalMicros
                };

                row.Ctr = (row.Impressions == 0) ? 0 : (row.Clicks/(double) row.Impressions)/10000d;

                row.Cpm = (row.Impressions == 0) ? 0 : row.SpendLocalMicros.GetValueOrDefault(0)/(row.Impressions/1000m)/reportDecimals;
                row.ClientCostCpm = (row.Impressions == 0) ? 0 : row.ClientCostLocalMicros.MicrosToDollars()/(row.Impressions/1000m);

                row.Cpc = (row.Clicks == 0) ? 0 : row.SpendLocalMicros.GetValueOrDefault(0)/(decimal) row.Clicks/reportDecimals;
                row.ClientCostCpc = (row.Clicks == 0) ? 0 : row.ClientCostLocalMicros.MicrosToDollars()/row.Clicks;

                row.Cpa = (row.Conversions == 0) ? 0 : row.SpendLocalMicros.GetValueOrDefault(0)/(decimal) row.Conversions/reportDecimals;
                row.ClientCostCpa = (row.Conversions == 0) ? 0 : row.ClientCostLocalMicros.MicrosToDollars()/row.Conversions;

                var adSlotDurationInSeconds = (decimal) row.AdSlotDurationInSeconds.GetValueOrDefault(0);
                row.Cpms = (adSlotDurationInSeconds == 0) ? 0 : row.SpendLocalMicros.GetValueOrDefault(0)/(adSlotDurationInSeconds/1000m)/reportDecimals;
                row.ClientCostCpms = (adSlotDurationInSeconds == 0) ? 0 : row.ClientCostLocalMicros.MicrosToDollars()/(adSlotDurationInSeconds/1000m);

                return row;
            });

            return result;
        }

        public static decimal MicrosToDollars(this long? micros)
        {
            if (!micros.HasValue || micros.Value == 0) return 0;
            return Math.Round(micros.Value/100m/10000m, 3, MidpointRounding.AwayFromZero);
        }

        public static IQueryable<T> FilterBy<T>(this IQueryable<T> source, ReportCriteria reportCriteria) where T : class, IAdGroupAnalyticsData
        {
            // entity filter
            source = reportCriteria.BuyerAccounts.Aggregate(source, (current, buyerAccount) => current.Where(x => x.BuyerAccountId == buyerAccount.BuyerAccountId));
            if (reportCriteria.Advertiser != null)
            {
                source = source.Where(x => x.AdvertiserId == reportCriteria.Advertiser.AdvertiserId);
            }
            if (reportCriteria.AdvertiserProduct != null)
            {
                source = source.Where(x => x.AdvertiserProductId == reportCriteria.AdvertiserProduct.AdvertiserProductId);
            }
            if (reportCriteria.Campaign != null)
            {
                source = source.Where(x => x.CampaignId == reportCriteria.Campaign.CampaignId);
            }
            if (reportCriteria.AdGroup != null)
            {
                source = source.Where(x => x.AdGroupId == reportCriteria.AdGroup.AdGroupId);
            }

            // time range filter
            if (reportCriteria.LocalFromDateTime.HasValue)
            {
                source = source.Where(s => s.LocalDate >= reportCriteria.LocalFromDateTime);
            }
            if (reportCriteria.LocalToDateTime.HasValue)
            {
                source = source.Where(s => s.LocalDate < reportCriteria.LocalToDateTime);
            }

            return source;
        }

        public static Report<T> ToReport<T>(this IEnumerable<PerformanceData<T>> source, ReportCriteria reportCriteria)
        {
            var report = new Report<T>(source)
            {
                ReportType = reportCriteria.Type.ToString(),
                ReportLevel = reportCriteria.Level.ToString()
            };
            return report;
        }
    }
}
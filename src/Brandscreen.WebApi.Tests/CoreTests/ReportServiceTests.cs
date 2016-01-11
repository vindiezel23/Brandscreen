using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brandscreen.Analytics.Entities;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services.Reports;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests.CoreTests
{
    [TestFixture]
    public class ReportServiceTests : MockingTests
    {
        [Test]
        public async Task GetAdvertiserReport_ShouldReturnSummaryReport()
        {
            // Arrange
            var reportCriteria = new ReportCriteria
            {
                Type = ReportTypeEnum.Advertiser,
                Level = ReportLevelEnum.Summary
            };
            var adAnalyticsReportIds = new[]
            {
                new AdAnalyticsReportId
                {
                    AdvertiserId = 1,
                    AdvertiserName = "Advertiser 1",
                    Bids = 1
                },
                new AdAnalyticsReportId
                {
                    AdvertiserId = 1,
                    AdvertiserName = "Advertiser 1",
                    Bids = 1
                },
                new AdAnalyticsReportId
                {
                    AdvertiserId = 2,
                    AdvertiserName = "Advertiser 2",
                    Bids = 1
                },
            };
            MockUnitOfWorkRepository<AdAnalyticsReportId>().Setup(x => x.Queryable())
                .Returns(adAnalyticsReportIds.ToAsyncEnumerable());

            // Act
            var result = await Mock.Create<ReportService>().GetAdvertiserReport(reportCriteria);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ReportType, Is.EqualTo(reportCriteria.Type.ToString()));
            Assert.That(result.ReportLevel, Is.EqualTo(reportCriteria.Level.ToString()));
            Assert.That(result.Data, Is.Not.Null);
            var data = result.Data.CastToAnonymousPerformanceData(new {AdvertiserId = default(int), AdvertiserName = default(string)}).ToList();
            Assert.That(data.Count(), Is.EqualTo(2));

            Assert.That(data[0].KeyData.AdvertiserId, Is.EqualTo(1));
            Assert.That(data[0].KeyData.AdvertiserName, Is.EqualTo("Advertiser 1"));
            Assert.That(data[0].Bids, Is.EqualTo(2));

            Assert.That(data[1].KeyData.AdvertiserId, Is.EqualTo(2));
            Assert.That(data[1].KeyData.AdvertiserName, Is.EqualTo("Advertiser 2"));
            Assert.That(data[1].Bids, Is.EqualTo(1));
        }

        [Test]
        public async Task GetAdvertiserReport_ShouldReturnDailyReport()
        {
            // Arrange
            var reportCriteria = new ReportCriteria
            {
                Type = ReportTypeEnum.Advertiser,
                Level = ReportLevelEnum.Daily
            };
            var date1 = DateTime.Now.AddDays(-2);
            var date2 = DateTime.Now.AddDays(-1);
            var date3 = DateTime.Now;
            var adAnalyticsReportIds = new[]
            {
                new AdAnalyticsReportId
                {
                    LocalDate = date1,
                    AdvertiserId = 1,
                    AdvertiserName = "Advertiser 1",
                    Bids = 1
                },
                new AdAnalyticsReportId
                {
                    LocalDate = date2,
                    AdvertiserId = 1,
                    AdvertiserName = "Advertiser 1",
                    Bids = 1
                },
                new AdAnalyticsReportId
                {
                    LocalDate = date3,
                    AdvertiserId = 2,
                    AdvertiserName = "Advertiser 2",
                    Bids = 1
                },
            };
            MockUnitOfWorkRepository<AdAnalyticsReportId>().Setup(x => x.Queryable())
                .Returns(adAnalyticsReportIds.ToAsyncEnumerable());

            // Act
            var result = await Mock.Create<ReportService>().GetAdvertiserReport(reportCriteria);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ReportType, Is.EqualTo(reportCriteria.Type.ToString()));
            Assert.That(result.ReportLevel, Is.EqualTo(reportCriteria.Level.ToString()));
            Assert.That(result.Data, Is.Not.Null);
            var data = result.Data.CastToAnonymousPerformanceData(new {Date = default(DateTime), AdvertiserId = default(int), AdvertiserName = default(string)}).ToList();
            Assert.That(data.Count(), Is.EqualTo(3));

            Assert.That(data[0].KeyData.Date, Is.EqualTo(date1));
            Assert.That(data[0].KeyData.AdvertiserId, Is.EqualTo(1));
            Assert.That(data[0].KeyData.AdvertiserName, Is.EqualTo("Advertiser 1"));
            Assert.That(data[0].Bids, Is.EqualTo(1));

            Assert.That(data[1].KeyData.Date, Is.EqualTo(date2));
            Assert.That(data[1].KeyData.AdvertiserId, Is.EqualTo(1));
            Assert.That(data[1].KeyData.AdvertiserName, Is.EqualTo("Advertiser 1"));
            Assert.That(data[1].Bids, Is.EqualTo(1));

            Assert.That(data[2].KeyData.Date, Is.EqualTo(date3));
            Assert.That(data[2].KeyData.AdvertiserId, Is.EqualTo(2));
            Assert.That(data[2].KeyData.AdvertiserName, Is.EqualTo("Advertiser 2"));
            Assert.That(data[2].Bids, Is.EqualTo(1));
        }
    }

    public static class Extensions
    {
        /// <summary>
        /// Helps to convert to anonymous performance data using JsonConvert
        /// </summary>
        internal static IEnumerable<PerformanceData<T>> CastToAnonymousPerformanceData<T>(this IEnumerable enumerable, T anonymousTypeObject)
        {
            // Note: It is impossible to convert to anonymous type directly since the original anonymouse type is defined in Brandscreen.Core assembly which is 
            // different from the current one, please refer to: http://stackoverflow.com/questions/7024959/unable-to-cast-one-anonymous-type-to-another
            // "Anonymous types are bound to the assembly (technically, the module) that they are declared in."
            var json = JsonConvert.SerializeObject(enumerable);
            return JsonConvert.DeserializeAnonymousType(json, Enumerable.Empty<PerformanceData<T>>());
        }
    }
}
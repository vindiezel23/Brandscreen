using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Brandscreen.Analytics.Entities;
using Brandscreen.Entities;
using Flurl;
using Flurl.Http;
using NUnit.Framework;
using Repository.Pattern.Repositories;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class ReportsControllerTests : IocSupportedTests
    {
        private void PrepareDatabaseData()
        {
            Container.LoadDbData<AdPartner>();
            SaveDbChanges();
        }

        private void PreparePageTestData()
        {
            Container.LoadDbData<AdPartner>("page");
            SaveDbChanges();
        }

        [Test]
        public async Task GetStrategyReport_ShouldReturnSummaryReport()
        {
            // Arrange
            var url = HostServer.Url + "api/reports/strategies";

            // Act
            var response = await url
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.ReportType, Is.EqualTo("Strategy"));
            Assert.That(response.ReportLevel, Is.EqualTo("Summary"));
        }

        [Test]
        public async Task GetStrategyReport_ShouldReturnDailyReport()
        {
            // Arrange
            var url = HostServer.Url + "api/reports/strategies/Daily";

            // Act
            var response = await url
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.ReportType, Is.EqualTo("Strategy"));
            Assert.That(response.ReportLevel, Is.EqualTo("Daily"));
        }


        [Test]
        public async Task GetStrategyReport_ShouldReturnRequestedPage()
        {
            // Arrange
            var url = HostServer.Url + "api/reports/strategies/Daily";
            PreparePageTestData();
            var pagination = new
            {
                PageNumber = 2,
            };

            // Act
            var response = await url
                .SetQueryParams(pagination)
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.ReportType, Is.EqualTo("Strategy"));
            Assert.That(response.ReportLevel, Is.EqualTo("Daily"));
            Assert.That(response.PageNumber, Is.EqualTo(pagination.PageNumber));
        }

        [Test]
        public async Task GetStrategyReport_ShouldReturnSummaryReport_WhenScopeAdvertiser()
        {
            // Arrange
            var url = HostServer.Url + "api/reports/strategies/Summary/Advertiser";
            PrepareDatabaseData();
            var analyticRecord = Container.Resolve<IRepositoryAsync<AdAnalyticsReportId>>().Queryable().First();
            var record = Container.Resolve<IRepositoryAsync<Advertiser>>().Queryable().First(x => x.AdvertiserId == analyticRecord.AdvertiserId);

            // Act
            var response = await url.AppendPathSegment(record.AdvertiserUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.ReportType, Is.EqualTo("Strategy"));
            Assert.That(response.ReportLevel, Is.EqualTo("Summary"));
            Assert.That(response.Data.Count, Is.GreaterThan(0));
            foreach (var rdata in response.Data)
            {
                Assert.That(rdata.KeyData.AdvertiserId, Is.EqualTo(analyticRecord.AdvertiserId));
            }
        }

        [Test]
        public async Task GetStrategyReport_ShouldReturnSummaryReport_WhenScopeAdvertiserWithTimeSpan()
        {
            // Arrange
            var url = HostServer.Url + "api/reports/strategies/Summary/Advertiser";
            PrepareDatabaseData();
            var analyticRecord = Container.Resolve<IRepositoryAsync<AdAnalyticsReportId>>().Queryable().First();
            var record = Container.Resolve<IRepositoryAsync<Advertiser>>().Queryable().First(x => x.AdvertiserId == analyticRecord.AdvertiserId);
            var data = new
            {
                StartDate = "2011-09-01T00:00:00",
                EndDate = "2011-09-03T00:00:00"
            };

            // Act
            var response = await url.AppendPathSegment(record.AdvertiserUuid.ToString())
                .SetQueryParams(data)
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.ReportType, Is.EqualTo("Strategy"));
            Assert.That(response.ReportLevel, Is.EqualTo("Summary"));
            foreach (var rdata in response.Data)
            {
                Assert.That(rdata.KeyData.AdvertiserId, Is.EqualTo(analyticRecord.AdvertiserId));
            }
        }

        [Test]
        public async Task GetAdvertiserReport_ShouldReturnSummaryReport()
        {
            // Arrange
            var url = HostServer.Url + "api/reports/advertisers";

            // Act
            var response = await url
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.ReportType, Is.EqualTo("Advertiser"));
            Assert.That(response.ReportLevel, Is.EqualTo("Summary"));
        }

        [Test]
        public async Task GetAdvertiserReport_ShouldReturnDailyReport()
        {
            // Arrange
            var url = HostServer.Url + "api/reports/advertisers/Daily";

            // Act
            var response = await url
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.ReportType, Is.EqualTo("Advertiser"));
            Assert.That(response.ReportLevel, Is.EqualTo("Daily"));
        }

        [Test]
        public async Task GetAdvertiserReport_ShouldReturnDailyReport_WhenScopeCampaignWithTimeSpan()
        {
            // Arrange
            var url = HostServer.Url + "api/reports/advertisers/Daily/Campaign";
            PrepareDatabaseData();
            // Get Analytics Record for existing advertiseId
            var analyticRecord = Container.Resolve<IRepositoryAsync<AdAnalyticsReportId>>().Queryable().First();
            var record = Container.Resolve<IRepositoryAsync<Campaign>>().Queryable().First(x => x.CampaignId == analyticRecord.CampaignId);
            var data = new
            {
                StartDate = "2011-09-01T00:00:00",
                EndDate = "2011-09-03T00:00:00"
            };

            // Act
            var response = await url.AppendPathSegment(record.CampaignUuid.ToString())
                .SetQueryParams(data)
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.ReportType, Is.EqualTo("Advertiser"));
            Assert.That(response.ReportLevel, Is.EqualTo("Daily"));
            foreach (var rdata in response.Data)
            {
                Assert.That(rdata.KeyData.AdvertiserId, Is.EqualTo(analyticRecord.AdvertiserId));
                Assert.That(Convert.ToDateTime(rdata.KeyData.Date), Is.GreaterThanOrEqualTo(Convert.ToDateTime(data.StartDate)));
                Assert.That(Convert.ToDateTime(rdata.KeyData.Date), Is.LessThan(Convert.ToDateTime(data.EndDate)));
            }
        }

        [Test]
        public async Task GetCampaignsReport_ShouldReturnSummaryReport()
        {
            // Arrange
            var url = HostServer.Url + "api/reports/campaigns";

            // Act
            var response = await url
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.ReportType, Is.EqualTo("Campaign"));
            Assert.That(response.ReportLevel, Is.EqualTo("Summary"));
        }

        [Test]
        public async Task GetCampaignsReport_ShouldReturnDailyReport_WhenScopeAdvertiser()
        {
            // Arrange
            var url = HostServer.Url + "api/reports/campaigns/Daily/Advertiser";
            PrepareDatabaseData();
            var analyticRecord = Container.Resolve<IRepositoryAsync<AdAnalyticsReportId>>().Queryable().First();
            var record = Container.Resolve<IRepositoryAsync<Advertiser>>().Queryable().First(x => x.AdvertiserId == analyticRecord.AdvertiserId);

            // Act
            var response = await url.AppendPathSegment(record.AdvertiserUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.ReportType, Is.EqualTo("Campaign"));
            Assert.That(response.ReportLevel, Is.EqualTo("Daily"));
            foreach (var rdata in response.Data)
            {
                Assert.That(rdata.KeyData.AdvertiserId, Is.EqualTo(analyticRecord.AdvertiserId));
            }
        }

        [Test]
        public async Task GetCampaignsReport_ShouldReturnSummaryReport_WhenScopeAdvertiserWithTimeSpan()
        {
            // Arrange
            var url = HostServer.Url + "api/reports/campaigns/Summary/Advertiser";
            PrepareDatabaseData();
            var analyticRecord = Container.Resolve<IRepositoryAsync<AdAnalyticsReportId>>().Queryable().First();
            var record = Container.Resolve<IRepositoryAsync<Advertiser>>().Queryable().First(x => x.AdvertiserId == analyticRecord.AdvertiserId);
            var data = new
            {
                StartDate = "2011-09-01T00:00:00",
                EndDate = "2011-09-03T00:00:00"
            };

            // Act
            var response = await url.AppendPathSegment(record.AdvertiserUuid.ToString())
                .SetQueryParams(data)
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.ReportType, Is.EqualTo("Campaign"));
            Assert.That(response.ReportLevel, Is.EqualTo("Summary"));
            foreach (var rdata in response.Data)
            {
                Assert.That(rdata.KeyData.AdvertiserId, Is.EqualTo(analyticRecord.AdvertiserId));
            }
        }

        [Test]
        public async Task GetProductsReport_ShouldReturnSummaryReport()
        {
            // Arrange
            var url = HostServer.Url + "api/reports/brands";

            // Act
            var response = await url
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.ReportType, Is.EqualTo("Brand"));
            Assert.That(response.ReportLevel, Is.EqualTo("Summary"));
        }

        [Test]
        public async Task GetProductsReport_ShouldReturnSummaryReport_WhenScopeAdvertiser()
        {
            // Arrange
            var url = HostServer.Url + "api/reports/brands/Summary/Advertiser";
            PrepareDatabaseData();
            var analyticRecord = Container.Resolve<IRepositoryAsync<AdAnalyticsReportId>>().Queryable().First();
            var record = Container.Resolve<IRepositoryAsync<Advertiser>>().Queryable().First(x => x.AdvertiserId == analyticRecord.AdvertiserId);

            // Act
            var response = await url.AppendPathSegment(record.AdvertiserUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.ReportType, Is.EqualTo("Brand"));
            Assert.That(response.ReportLevel, Is.EqualTo("Summary"));
            foreach (var rdata in response.Data)
            {
                Assert.That(rdata.KeyData.AdvertiserId, Is.EqualTo(analyticRecord.AdvertiserId));
            }
        }

        [Test]
        public async Task GetProductsReport_ShouldReturnDailyReport_WhenScopeAdvertiserWithTimeSpan()
        {
            // Arrange
            var url = HostServer.Url + "api/reports/brands/Daily/Advertiser";
            PrepareDatabaseData();
            var analyticRecord = Container.Resolve<IRepositoryAsync<AdAnalyticsReportId>>().Queryable().First();
            var record = Container.Resolve<IRepositoryAsync<Advertiser>>().Queryable().First(x => x.AdvertiserId == analyticRecord.AdvertiserId);
            var data = new
            {
                StartDate = "2011-09-01T00:00:00",
                EndDate = "2011-09-03T00:00:00"
            };

            // Act
            var response = await url.AppendPathSegment(record.AdvertiserUuid.ToString())
                .SetQueryParams(data)
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.ReportType, Is.EqualTo("Brand"));
            Assert.That(response.ReportLevel, Is.EqualTo("Daily"));
            foreach (var rdata in response.Data)
            {
                Assert.That(rdata.KeyData.AdvertiserId, Is.EqualTo(analyticRecord.AdvertiserId));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brandscreen.Core.Services.Reports;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Moq;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class ReportsControllerTests : ApiControllerMockingTests<ReportsController>
    {
        [Test]
        public async Task GetAdvertiserReport_ShouldReturnReport()
        {
            // Arrange
            var scopeId = Guid.NewGuid();
            var advertiser = new Advertiser {AdvertiserUuid = scopeId};
            var model = new ReportCriteriaViewModel
            {
                ReportLevel = ReportLevelEnum.Daily,
                ReportScope = ReportScopeEnum.Advertiser,
                ReportScopeId = scopeId,
                StartDate = DateTime.Now
            };
            var report = new Report<object>(new List<PerformanceData<object>>
            {
                new PerformanceData<object>(),
                new PerformanceData<object>()
            });

            MockUnitOfWorkRepository<Advertiser>().Setup(x => x.Queryable())
                .Returns(new[] {advertiser}.AsQueryable());
            Mock.Mock<IReportService>().Setup(x => x.GetAdvertiserReport(It.Is((ReportCriteria criteria) =>
                criteria.Level == model.ReportLevel &&
                criteria.Advertiser == advertiser &&
                criteria.LocalFromDateTime == model.StartDate &&
                !criteria.LocalToDateTime.HasValue)))
                .Returns(Task.FromResult((IReport) report));

            // Act
            var result = await Controller.GetAdvertiserReport(model);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.TotalItemCount, Is.EqualTo(2));
            var resultData = result.Data.ToList();
            var expectedData = report.Data.ToList();
            Assert.That(resultData[0], Is.EqualTo(expectedData[0]));
            Assert.That(resultData[1], Is.EqualTo(expectedData[1]));
        }

        [Test]
        public async Task GetBrandReport_ShouldReturnReport()
        {
            // Arrange
            var scopeId = Guid.NewGuid();
            var advertiser = new Advertiser {AdvertiserUuid = scopeId};
            var model = new ReportCriteriaViewModel
            {
                ReportLevel = ReportLevelEnum.Daily,
                ReportScope = ReportScopeEnum.Advertiser,
                ReportScopeId = scopeId
            };
            var report = new Report<object>(new List<PerformanceData<object>>
            {
                new PerformanceData<object>()
            });

            MockUnitOfWorkRepository<Advertiser>().Setup(x => x.Queryable())
                .Returns(new[] {advertiser}.AsQueryable());
            Mock.Mock<IReportService>().Setup(x => x.GetBrandReport(It.Is((ReportCriteria criteria) => criteria.Level == model.ReportLevel && criteria.Advertiser == advertiser)))
                .Returns(Task.FromResult((IReport) report));

            // Act
            var result = await Controller.GetBrandReport(model);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.TotalItemCount, Is.EqualTo(1));
            Assert.That(result.Data.First(), Is.EqualTo(report.Data.First()));
        }

        [Test]
        public async Task GetCampaignReport_ShouldReturnReport()
        {
            // Arrange
            var scopeId = Guid.NewGuid();
            var advertiser = new Advertiser {AdvertiserUuid = scopeId};
            var model = new ReportCriteriaViewModel
            {
                ReportLevel = ReportLevelEnum.Daily,
                ReportScope = ReportScopeEnum.Advertiser,
                ReportScopeId = scopeId
            };
            var report = new Report<object>(new List<PerformanceData<object>>
            {
                new PerformanceData<object>()
            });

            MockUnitOfWorkRepository<Advertiser>().Setup(x => x.Queryable())
                .Returns(new[] {advertiser}.AsQueryable());
            Mock.Mock<IReportService>().Setup(x => x.GetCampaignReport(It.Is((ReportCriteria criteria) => criteria.Level == model.ReportLevel && criteria.Advertiser == advertiser)))
                .Returns(Task.FromResult((IReport) report));

            // Act
            var result = await Controller.GetCampaignReport(model);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.TotalItemCount, Is.EqualTo(1));
            Assert.That(result.Data.First(), Is.EqualTo(report.Data.First()));
        }

        [Test]
        public async Task GetStrategyReport_ShouldReturnReport()
        {
            // Arrange
            var scopeId = Guid.NewGuid();
            var advertiser = new Advertiser {AdvertiserUuid = scopeId};
            var model = new ReportCriteriaViewModel
            {
                ReportLevel = ReportLevelEnum.Daily,
                ReportScope = ReportScopeEnum.Advertiser,
                ReportScopeId = scopeId
            };
            var report = new Report<object>(new List<PerformanceData<object>>
            {
                new PerformanceData<object>()
            });

            MockUnitOfWorkRepository<Advertiser>().Setup(x => x.Queryable())
                .Returns(new[] {advertiser}.AsQueryable());
            Mock.Mock<IReportService>().Setup(x => x.GetStrategyReport(It.Is((ReportCriteria criteria) => criteria.Level == model.ReportLevel && criteria.Advertiser == advertiser)))
                .Returns(Task.FromResult((IReport) report));

            // Act
            var result = await Controller.GetStrategyReport(model);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.TotalItemCount, Is.EqualTo(1));
            Assert.That(result.Data.First(), Is.EqualTo(report.Data.First()));
        }
    }
}
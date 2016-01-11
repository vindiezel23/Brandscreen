using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services.Campaigns;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;
using Moq;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class StrategiesControllerTests : ApiControllerMockingTests<StrategiesController>
    {
        [Test]
        public async Task Get_ShouldReturnStrategyList()
        {
            // Arrange
            var model = new StrategyQueryViewModel();
            var adGroup = new AdGroup {AdGroupName = "My Strategy 1"};
            var adGroup2 = new AdGroup {AdGroupName = "My Strategy 2"};
            var adGroups = new List<AdGroup> {adGroup, adGroup2};
            Mock.Mock<IStrategyService>().Setup(x => x.GetStrategies(It.IsAny<StrategyQueryOptions>())).Returns(adGroups.ToAsyncEnumerable());

            // Act
            var results = await Controller.Get(model);

            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results, Is.TypeOf<OkNegotiatedContentResult<PagedListViewModel<StrategyListViewModel>>>());
            var content = ((OkNegotiatedContentResult<PagedListViewModel<StrategyListViewModel>>) results).Content;
            Assert.That(content.Data, Is.Not.Null);
            Assert.That(content.Data.Count(), Is.EqualTo(2));
            Assert.That(content.Data.First().StrategyName, Is.EqualTo(adGroup.AdGroupName));
        }

        [Test]
        public async Task Get_ShouldReturnStrategy_WhenCorrectId()
        {
            // Arrange
            var adGroup = new AdGroup {AdGroupUuid = Guid.NewGuid(), AdGroupName = "My Strategy 1"};
            Mock.Mock<IStrategyService>().Setup(x => x.GetStrategy(It.IsAny<Guid>())).Returns(Task.FromResult(adGroup));

            // Act
            var retVal = await Controller.Get(adGroup.AdGroupUuid);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<StrategyViewModel>>());
            var content = ((OkNegotiatedContentResult<StrategyViewModel>) retVal).Content;
            Assert.That(content.StrategyName, Is.EqualTo(adGroup.AdGroupName));
        }

        [Test]
        public async Task Post_ShouldReturnOk()
        {
            // Arrange
            var model = new StrategyCreateViewModel
            {
                CampaignUuid = Guid.NewGuid(),
                StrategyName = "WJsHome",
                SupplySource = "PublicMarket",
                MediaType = "Display",
            };
            var adGroup = new AdGroup {AdGroupUuid = Guid.NewGuid(), AdGroupName = "My Strategy 1"};
            Mock.Mock<IStrategyService>().Setup(x => x.GetStrategy(It.IsAny<Guid>())).Returns(Task.FromResult(adGroup));
            Mock.Mock<ICampaignService>().Setup(x => x.GetCampaign(model.CampaignUuid.Value)).Returns(Task.FromResult(new Campaign()));

            // Act
            var retVal = await Controller.Post(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<StrategyViewModel>>());
            Mock.Mock<IStrategyService>().Verify(x => x.CreateStrategy(It.IsAny<AdGroup>()), Times.Once);
        }

        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange
            var adGroupUuid = Guid.NewGuid();
            var model = new StrategyPatchViewModel
            {
                StrategyName = "WJsHome"
            };
            var adGroup = new AdGroup {AdGroupUuid = adGroupUuid, AdGroupName = "My Strategy 1"};
            Mock.Mock<IStrategyService>().Setup(x => x.GetStrategy(It.IsAny<Guid>())).Returns(Task.FromResult(adGroup));

            // Act
            var retVal = await Controller.Patch(adGroupUuid, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<IStrategyService>().Verify(x => x.UpdateStrategy(It.IsAny<StrategyUpdateOptions>()), Times.Once);
        }

        [Test]
        public async Task GetTargetings_ShouldReturnStrategyTargettings()
        {
            // Arrange
            var adGroup = new AdGroup {AdGroupUuid = Guid.NewGuid(), AdGroupName = "My Strategy 1"};
            Mock.Mock<IStrategyService>().Setup(x => x.GetStrategy(It.IsAny<Guid>())).Returns(Task.FromResult(adGroup));

            // Act
            var retVal = await Controller.GetTargetings(adGroup.AdGroupUuid);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<Dictionary<string, object>>>());
            var content = ((OkNegotiatedContentResult<Dictionary<string, object>>) retVal).Content;
            Assert.That(content.ContainsKey("StrategyUuid"), Is.True);
            Assert.That(content["StrategyUuid"], Is.EqualTo(adGroup.AdGroupUuid));
        }
    }
}
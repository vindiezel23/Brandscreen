using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Core.Services.Placements;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Moq;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class PlacementsControllerTests : ApiControllerMockingTests<PlacementsController>
    {
        [Test]
        public async Task Get_ShouldReturnCampaignLists()
        {
            // Arrange
            var placement = new Placement {PlacementUuid = Guid.NewGuid()};
            var placement2 = new Placement {PlacementUuid = Guid.NewGuid()};
            var placements = new List<Placement> {placement, placement2};
            Mock.Mock<IPlacementService>().Setup(x => x.GetPlacements(It.IsAny<PlacementQueryOptions>())).Returns(placements.ToAsyncEnumerable());

            // Act
            var results = await Controller.Get(null);

            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results.Data, Is.Not.Null);
            Assert.That(results.Data.Count(), Is.EqualTo(2));
            Assert.That(results.Data.First().PlacementUuid, Is.EqualTo(placements[0].PlacementUuid));
        }

        [Test]
        public async Task Get_ShouldReturnCampaign_WhenCorrectId()
        {
            // Arrange
            var placement = new Placement {PlacementUuid = Guid.NewGuid()};
            Mock.Mock<IPlacementService>().Setup(x => x.GetPlacement(It.IsAny<Guid>())).Returns(Task.FromResult(placement));

            // Act
            var retVal = await Controller.Get(placement.PlacementUuid);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<PlacementViewModel>>());
            var content = ((OkNegotiatedContentResult<PlacementViewModel>) retVal).Content;
            Assert.That(content.PlacementUuid, Is.EqualTo(placement.PlacementUuid));
        }

        [Test]
        public async Task Put_ShouldReturnOk()
        {
            // Arrange
            var model = new PlacementPutViewModel
            {
                StrategyUuid = Guid.NewGuid(),
                CreativeUuid = Guid.NewGuid()
            };
            Mock.Mock<IStrategyService>().Setup(x => x.GetStrategy(model.StrategyUuid.Value))
                .Returns(Task.FromResult(new AdGroup()));
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreative(model.CreativeUuid.Value))
                .Returns(Task.FromResult(new Creative {AdTagTemplate = new AdTagTemplate()}));

            // Act
            var retVal = await Controller.Put(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<IPlacementService>().Verify(x => x.ModifyPlacement(It.Is<PlacementModifyOptions>(options => options.StrategyUuid == model.StrategyUuid.Value && options.CreativeUuid == model.CreativeUuid.Value)), Times.Once);
        }
    }
}
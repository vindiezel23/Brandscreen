using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services.Dooh;
using Brandscreen.Core.Services.Partners;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Moq;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class DoohControllerTests : ApiControllerMockingTests<DoohController>
    {
        [Test]
        public async Task GetDoohGeoLocationGroups_ShouldReturnListOfDoohGeoLocationGroups()
        {
            // Arrange
            var doohGeoLocationGroup = new DoohGeoLocationGroup {LocationGroupName = "Belrose"};
            var doohGeoLocationGroups = new List<DoohGeoLocationGroup> {doohGeoLocationGroup};

            Mock.Mock<IDoohService>().Setup(x => x.GetDoohGeoLocationGroups()).Returns(doohGeoLocationGroups.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.GetDoohGeoLocationGroups(null);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal.TotalItemCount, Is.EqualTo(1));
        }

        [Test]
        public async Task GetDoohGeoLocationGroup_ShouldReturnDoohGeoLocationGroupDetails()
        {
            // Arrange
            var id = 1;
            var doohGeoLocationGroup = new DoohGeoLocationGroup {LocationGroupName = "Belrose"};
            Mock.Mock<IDoohService>().Setup(x => x.GetDoohGeoLocationGroup(id)).Returns(Task.FromResult(doohGeoLocationGroup));

            // Act
            var results = await Controller.GetDoohGeoLocationGroup(id);

            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results, Is.TypeOf<OkNegotiatedContentResult<DoohGeoLocationGroupViewModel>>());
            var content = ((OkNegotiatedContentResult<DoohGeoLocationGroupViewModel>) results).Content;
            Assert.That(content.LocationGroupName, Is.EqualTo(doohGeoLocationGroup.LocationGroupName));
        }

        [Test]
        public async Task GetDoohPanels_ShouldReturnListOfDoohPanels()
        {
            // Arrange
            var doohPanel = new DoohPanel();
            var doohPanels = new List<DoohPanel> {doohPanel};

            Mock.Mock<IDoohService>().Setup(x => x.GetDoohPanels()).Returns(doohPanels.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.GetDoohPanels(null);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal.TotalItemCount, Is.EqualTo(1));
        }

        [Test]
        public async Task GetDoohLocations_ShouldReturnListOfDoohLocations()
        {
            // Arrange
            var doohLocation = new DoohLocation();
            var doohLocations = new List<DoohLocation> {doohLocation};

            Mock.Mock<IDoohService>().Setup(x => x.GetDoohLocations()).Returns(doohLocations.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.GetDoohLocations(null);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal.TotalItemCount, Is.EqualTo(1));
        }

        [Test]
        public async Task GetDoohPanelLocations_ShouldReturnListOfDoohPanelLocations()
        {
            // Arrange
            var doohPanelLocation = new DoohPanelLocation();
            var doohLocations = new List<DoohPanelLocation> {doohPanelLocation};

            Mock.Mock<IDoohService>().Setup(x => x.GetDoohPanelLocations()).Returns(doohLocations.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.GetDoohPanelLocations(null);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal.TotalItemCount, Is.EqualTo(1));
        }

        [Test]
        public async Task PostDoohPanelLocation_ShouldReturnOk()
        {
            // Arrange
            var model = new DoohPanelLocationCreateViewModel {DoohPanelId = 1, DoohLocationId = 1, PartnerId = 1, PanelUrl = "www.wjshome.com"};

            var mockedDoohService = Mock.Mock<IDoohService>();
            mockedDoohService.Setup(x => x.GetDoohPanel(model.DoohPanelId.Value)).ReturnsAsync(new DoohPanel());
            mockedDoohService.Setup(x => x.GetDoohLocation(model.DoohLocationId.Value)).ReturnsAsync(new DoohLocation());
            mockedDoohService.Setup(x => x.GetDoohPanelLocation(It.IsAny<int>())).ReturnsAsync(new DoohPanelLocation());

            Mock.Mock<IPartnerService>().Setup(x => x.GetPartner(model.PartnerId.Value)).ReturnsAsync(new Partner());

            // Act
            var retVal = await Controller.PostDoohPanelLocation(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<DoohPanelLocationViewModel>>());
            mockedDoohService.Verify(x => x.CreateDoohPanelLocation(It.Is<DoohPanelLocation>(doohPanelLocation => doohPanelLocation.PanelUrl == model.PanelUrl)), Times.Once);
        }

        [Test]
        public async Task PatchDoohPanelLocation_ShouldReturnOk()
        {
            // Arrange
            var id = 1;
            var model = new DoohPanelLocationPatchViewModel {PanelLocationName = "WJsHome"};
            Mock.Mock<IDoohService>().Setup(x => x.GetDoohPanelLocation(id)).ReturnsAsync(new DoohPanelLocation());

            // Act
            var retVal = await Controller.PatchDoohPanelLocation(id, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<IDoohService>().Verify(x => x.UpdateDoohPanelLocation(It.Is<DoohPanelLocation>(doohPanelLocation => doohPanelLocation.PanelLocationName == model.PanelLocationName)), Times.Once);
        }

        [Test]
        public async Task DeleteDoohPanelLocation_ShouldReturnOk()
        {
            // Arrange
            var id = 1;
            Mock.Mock<IDoohService>().Setup(x => x.GetDoohPanelLocation(id)).ReturnsAsync(new DoohPanelLocation());

            // Act
            var retVal = await Controller.DeleteDoohPanelLocation(id);

            // Assert
            Assert.That(retVal, Is.TypeOf<StatusCodeResult>());
            Assert.That(((StatusCodeResult) retVal).StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Mock.Mock<IDoohService>().Verify(x => x.DeleteDoohPanelLocation(id), Times.Once);
        }
    }
}
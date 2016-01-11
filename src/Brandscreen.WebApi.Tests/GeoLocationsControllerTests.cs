using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.Services.Strategies.Targets;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Moq;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class GeoLocationsControllerTests : ApiControllerMockingTests<GeoLocationsController>
    {
        [Test]
        public async Task Get_ShouldReturnGeoLocationDetails()
        {
            // Arrange
            var id = 1L;
            var geoLocation = new GeoLocation {GeoLocationCode = "GeoLocationCode"};
            Mock.Mock<IGeoLocationService>().Setup(x => x.GetGeoLocation(id)).Returns(Task.FromResult(geoLocation));

            // Act
            var results = await Controller.Get(id);

            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results, Is.TypeOf<OkNegotiatedContentResult<GeoLocationViewModel>>());
            var content = ((OkNegotiatedContentResult<GeoLocationViewModel>) results).Content;
            Assert.That(content.GeoLocationCode, Is.EqualTo(geoLocation.GeoLocationCode));
        }

        [Test]
        public async Task GetGeoCountry_ShouldReturnGeoCountryDetails()
        {
            // Arrange
            var id = 1;
            var geoCountry = new GeoCountry {CountryName = "Australia"};
            Mock.Mock<IGeoLocationService>().Setup(x => x.GetGeoCountry(id)).ReturnsAsync(geoCountry);

            // Act
            var results = await Controller.GetGeoCountry(id);

            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results, Is.TypeOf<OkNegotiatedContentResult<GeoCountryViewModel>>());
            var content = ((OkNegotiatedContentResult<GeoCountryViewModel>) results).Content;
            Assert.That(content.CountryName, Is.EqualTo(geoCountry.CountryName));
        }

        [Test]
        public async Task GetGeoRegion_ShouldReturnGeoRegionDetails()
        {
            // Arrange
            var id = 1;
            var geoRegion = new GeoRegion {RegionName = "Belrose"};
            Mock.Mock<IGeoLocationService>().Setup(x => x.GetGeoRegion(id)).ReturnsAsync(geoRegion);

            // Act
            var results = await Controller.GetGeoRegion(id);

            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results, Is.TypeOf<OkNegotiatedContentResult<GeoRegionViewModel>>());
            var content = ((OkNegotiatedContentResult<GeoRegionViewModel>) results).Content;
            Assert.That(content.RegionName, Is.EqualTo(geoRegion.RegionName));
        }

        [Test]
        public async Task GetGeoMetro_ShouldReturnGeoMetroDetails()
        {
            // Arrange
            var id = 1;
            var geoMetro = new GeoMetro {MetroName = "Belrose"};
            Mock.Mock<IGeoLocationService>().Setup(x => x.GetGeoMetro(id)).ReturnsAsync(geoMetro);

            // Act
            var results = await Controller.GetGeoMetro(id);

            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results, Is.TypeOf<OkNegotiatedContentResult<GeoMetroViewModel>>());
            var content = ((OkNegotiatedContentResult<GeoMetroViewModel>) results).Content;
            Assert.That(content.MetroName, Is.EqualTo(geoMetro.MetroName));
        }

        [Test]
        public async Task GetGeoCity_ShouldReturnGeoCityDetails()
        {
            // Arrange
            var id = 1;
            var geoCity = new GeoCity {CityName = "Belrose"};
            Mock.Mock<IGeoLocationService>().Setup(x => x.GetGeoCity(id)).ReturnsAsync(geoCity);

            // Act
            var results = await Controller.GetGeoCity(id);

            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results, Is.TypeOf<OkNegotiatedContentResult<GeoCityViewModel>>());
            var content = ((OkNegotiatedContentResult<GeoCityViewModel>) results).Content;
            Assert.That(content.CityName, Is.EqualTo(geoCity.CityName));
        }
    }
}
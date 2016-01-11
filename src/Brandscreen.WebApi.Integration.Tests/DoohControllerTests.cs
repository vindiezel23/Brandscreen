using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using NUnit.Framework;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class DoohControllerTests : IocSupportedTests
    {
        [Test]
        public async Task GetDoohGeoLocationGroups_ShouldReturnListOfDoohGeoLocationGroups()
        {
            // Arrange 
            var url = HostServer.Url + "api/dooh/geolocationgroups";
            var data = new
            {
                PageNumber = 1,
                PageSize = 5
            };

            // Act
            var response = await url.SetQueryParams(data)
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetJsonAsync();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.PageNumber, Is.EqualTo(data.PageNumber));
            Assert.That(response.PageSize, Is.EqualTo(data.PageSize));
        }

        [Test]
        public async Task GetDoohGeoLocationGroup_ShouldReturnDoohGeoLocationGroupDetails()
        {
            // Arrange 
            var url = HostServer.Url + "api/dooh/geolocationgroups/1";

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.GeoCountryId, Is.Not.Null);
            Assert.That(response.GeoLocationId, Is.Not.Null);
        }

        [Test]
        public async Task GetDoohPanels_ShouldReturnListOfDoohPanels()
        {
            // Arrange 
            var url = HostServer.Url + "api/dooh/panels";
            var data = new
            {
                PageNumber = 1,
                PageSize = 5
            };

            // Act
            var response = await url.SetQueryParams(data)
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetJsonAsync();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.PageNumber, Is.EqualTo(data.PageNumber));
            Assert.That(response.PageSize, Is.EqualTo(data.PageSize));
        }

        [Test]
        public async Task GetDoohLocations_ShouldReturnListOfDoohLocations()
        {
            // Arrange 
            var url = HostServer.Url + "api/dooh/locations";
            var data = new
            {
                PageNumber = 1,
                PageSize = 5
            };

            // Act
            var response = await url.SetQueryParams(data)
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetJsonAsync();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.PageNumber, Is.EqualTo(data.PageNumber));
            Assert.That(response.PageSize, Is.EqualTo(data.PageSize));
        }

        [Test]
        public async Task GetDoohPanelLocations_ShouldReturnListOfDoohPanelLocations()
        {
            // Arrange 
            var url = HostServer.Url + "api/dooh/panellocations";
            var data = new
            {
                PageNumber = 1,
                PageSize = 5
            };

            // Act
            var response = await url.SetQueryParams(data)
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetJsonAsync();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.PageNumber, Is.EqualTo(data.PageNumber));
            Assert.That(response.PageSize, Is.EqualTo(data.PageSize));
        }
    }
}
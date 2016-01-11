using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using NUnit.Framework;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class GeoLocationsControllerTests : IocSupportedTests
    {
        [Test]
        public async Task Get_ShouldReturnGeoLocations()
        {
            // Arrange 
            var url = HostServer.Url + "api/geolocations/-2147356321";
            var data = new
            {
                PageNumber = 2,
                PageSize = 5
            };

            // Act
            var response = await url.SetQueryParams(data)
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.GeoCountryId, Is.Not.Null);
            Assert.That(response.GeoLocationCode, Is.Not.Null);
        }
    }
}
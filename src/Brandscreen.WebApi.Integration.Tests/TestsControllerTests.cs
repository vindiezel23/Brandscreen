using System.Threading.Tasks;
using Flurl.Http;
using NUnit.Framework;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class TestsControllerTests : IocSupportedTests
    {
        [Test]
        public async Task Authorize_ShouldReturnError_WhenNoToken()
        {
            // Arrange
            var url = HostServer.Url + "api/tests/authorize";

            // Act
            var response = await url
                .AllowHttpStatus("401")
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.Message, Is.EqualTo("Authorization has been denied for this request."));
        }

        [Test]
        public async Task Authorize_ShouldReturnError_WhenIncorrectToken()
        {
            // Arrange
            var url = HostServer.Url + "api/tests/authorize";

            // Act
            var response = await url
                .AllowHttpStatus("401")
                .WithOAuthBearerToken("incorrect token")
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.Message, Is.EqualTo("Authorization has been denied for this request."));
        }

        [Test]
        public async Task Authorize_ShouldReturnOk_WhenCorrectToken()
        {
            // Arrange
            var url = HostServer.Url + "api/tests/authorize";

            // Act
            var response = await url
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync();

            // Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }
    }
}
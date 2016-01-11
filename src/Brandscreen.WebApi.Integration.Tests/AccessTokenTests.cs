using System.Net;
using System.Threading.Tasks;
using Flurl.Http;
using NUnit.Framework;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    class AccessTokenTests
    {
        private readonly string _tokenUrl = HostServer.Url + "token";

        [Test]
        public async Task GetToken_ShouldReturnBadRequest_WhenIncorrectData()
        {
            // Act
            var response = await _tokenUrl.AllowAnyHttpStatus().PostAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task GetToken_ShouldReturnError_WhenInvalidPassword()
        {
            // Arrange
            var postData = new
            {
                grant_type = "password",
                username = "jwu@brandscreen.com",
                password = "incorrect_password"
            };

            // Act
            var response = await _tokenUrl.AllowHttpStatus("400").PostUrlEncodedAsync(postData).ReceiveJson();

            // Assert
            Assert.That(response.error, Is.EqualTo("invalid_grant"));
            Assert.That(response.error_description, Is.EqualTo("The user name or password is incorrect."));
        }

        [Test]
        public async Task GetToken_ShouldReturnToken_WhenValidCredential()
        {
            // Arrange
            var postData = new
            {
                grant_type = "password",
                username = "jwu@brandscreen.com",
                password = "abcd1234"
            };

            // Act
            var response = await _tokenUrl.PostUrlEncodedAsync(postData).ReceiveJson();

            // Assert
            Assert.That(response.access_token, Is.Not.Empty);
            Assert.That(response.token_type, Is.EqualTo("bearer"));
            Assert.That(response.userName, Is.EqualTo("jwu@brandscreen.com"));
        }
    }
}

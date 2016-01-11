using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using NUnit.Framework;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class DomainListsControllerTests : IocSupportedTests
    {
        [Test]
        public async Task Get_ShouldReturnDomainLists()
        {
            // Arrange 
            var url = HostServer.Url + "api/domainLists/1";
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
            Assert.That(response.Domains, Is.Not.Null);
            Assert.That(response.Domains.PageNumber, Is.EqualTo(data.PageNumber));
            Assert.That(response.Domains.PageSize, Is.EqualTo(data.PageSize));
        }
    }
}
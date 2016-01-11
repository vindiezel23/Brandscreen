using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Brandscreen.Core.Services.Publishers;
using Flurl;
using Flurl.Http;
using NUnit.Framework;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class PublishersControllerTests : IocSupportedTests
    {
        [Test]
        public async Task Get_ShouldReturnDealDetails()
        {
            // Arrange 
            var url = HostServer.Url + "api/publishers";
            var publisherService = Container.Resolve<IPublisherService>();
            var publisher = publisherService.GetPublishers().First();

            // Act
            var response = await url.AppendPathSegment(publisher.PublisherUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.PublisherId, Is.EqualTo(publisher.PublisherId));
            Assert.That(response.PublisherName, Is.EqualTo(publisher.PublisherName));
        }

        [Test]
        public async Task Get_ShouldReturnDealLists()
        {
            // Arrange 
            var url = HostServer.Url + "api/publishers/";
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
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.PageNumber, Is.EqualTo(data.PageNumber));
            Assert.That(response.PageSize, Is.EqualTo(data.PageSize));
        }
    }
}
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Core.Services.Deals;
using Brandscreen.Core.Services.Publishers;
using Flurl;
using Flurl.Http;
using NUnit.Framework;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class DealControllerTests : IocSupportedTests
    {
        [Test]
        public async Task Get_ShouldReturnDealDetails()
        {
            // Arrange 
            var url = HostServer.Url + "api/deals";
            var dealService = Container.Resolve<IDealService>();
            var deal = dealService.GetDeals().First();

            // Act
            var response = await url.AppendPathSegment(deal.DealUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.DealKey, Is.EqualTo(deal.DealKey));
            Assert.That(response.DealName, Is.EqualTo(deal.DealName));
        }

        [Test]
        public async Task Get_ShouldReturnDealLists()
        {
            // Arrange 
            var url = HostServer.Url + "api/deals/";
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

        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/deals/";
            var dealService = Container.Resolve<IDealService>();
            var deal = await dealService.GetDeals().FirstAsync();
            var data = new
            {
                DealName = "TestDealName",
            };

            // Act
            await url.AppendPathSegment(deal.DealUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .PatchUrlEncodedAsync(data);

            // Assert
            Assert.That(data.DealName, Is.EqualTo(deal.DealName));
        }

        [Test]
        public async Task Post_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/deals/";
            var accountService = Container.Resolve<IAccountService>();
            var account = await accountService.GetAccounts().FirstAsync();
            var publishService = Container.Resolve<IPublisherService>();
            var publish = await publishService.GetPublishers().FirstAsync();
            var data = new
            {
                BuyerAccountUuid = account.BuyerAccountUuid,
                PublisherUuid = publish.PublisherUuid,
                DealKey = "testkey",
                DealName = "testname",
                DealType = "Fixed",
                FloorPriceCents = 1,
                UtcStartDateTime = DateTime.Now.AddDays(1),
                UtcEndDateTime = DateTime.Now.AddMonths(1),
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostJsonAsync(data).ReceiveJson();

            // Assert
            Assert.That(response.DealKey, Is.EqualTo(data.DealKey));
            Assert.That(response.DealName, Is.EqualTo(data.DealName));
        }

        [Test]
        public async Task Delete_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/deals/";
            var dealService = Container.Resolve<IDealService>();
            var deal = await dealService.GetDeals().FirstAsync();

            // Act
            await url.AppendPathSegment(deal.DealUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync();

            // Assert
            Assert.That(deal.DealStatusId, Is.EqualTo(5));
        }
    }
}
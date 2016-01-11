using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Core.Services.Advertisers;
using Flurl;
using Flurl.Http;
using NUnit.Framework;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class AdvertisersControllerTests : IocSupportedTests
    {
        private async Task PrepareNewAdvertiser()
        {
            // Arrange 
            var url = HostServer.Url + "api/advertisers/";
            var accountService = Container.Resolve<IAccountService>();
            var account = await accountService.GetAccounts().FirstAsync();
            var data = new
            {
                BuyerAccountUuid = account.BuyerAccountUuid,
                AdvertiserName = "TestAdvertiserName",
                AdvertiserHomepageUrl = "http://www.brandscreen.com",
                IndustryCategoryId = Container.Resolve<IIndustryCategoryService>().GetIndustryCategories().First().IndustryCategoryId
            };

            // Act
            await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostUrlEncodedAsync(data);
        }

        [Test]
        public async Task Get_ShouldReturnListOfAdvertisers()
        {
            // Arrange 
            var url = HostServer.Url + "api/advertisers/";
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
            Assert.That(response.Data.Count, Is.EqualTo(data.PageSize));
        }

        [Test]
        public async Task Get_ShouldReturnAdvertiserDetails()
        {
            // Arrange 
            var url = HostServer.Url + "api/advertisers/";
            var advertiserService = Container.Resolve<IAdvertiserService>();
            var advertiser = await advertiserService.GetAdvertisers().FirstAsync();
            advertiser.AdvertiserName = "AccountsTest";
            await advertiserService.UpdateAdvertiser(advertiser);
            SaveDbChanges();

            // Act
            var response = await url.AppendPathSegment(advertiser.AdvertiserUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response.AdvertiserUuid, Is.EqualTo(advertiser.AdvertiserUuid.ToString()));
            Assert.That(response.AdvertiserName, Is.EqualTo(advertiser.AdvertiserName));
        }

        [Test]
        public async Task Get_ShouldReturnNotFound_WhenInvalidId()
        {
            // Arrange 
            var url = HostServer.Url + "api/advertisers/";

            // Act
            var response = await url.AppendPathSegment(Guid.NewGuid().ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .AllowAnyHttpStatus()
                .GetAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/advertisers/";
            var advertiserService = Container.Resolve<IAdvertiserService>();
            var advertiser = await advertiserService.GetAdvertisers().FirstAsync();
            var data = new
            {
                AdvertiserName = "TestCompanyName",
            };

            // Act
            await url.AppendPathSegment(advertiser.AdvertiserUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .PatchUrlEncodedAsync(data);

            // Assert
            Assert.That(data.AdvertiserName, Is.EqualTo(advertiser.AdvertiserName));
        }

        [Test]
        public async Task Post_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/advertisers/";
            var accountService = Container.Resolve<IAccountService>();
            var account = await accountService.GetAccounts().FirstAsync();
            var data = new
            {
                BuyerAccountUuid = account.BuyerAccountUuid,
                AdvertiserName = "TestAdvertiserName",
                AdvertiserHomepageUrl = "url",
                IndustryCategoryId = Container.Resolve<IIndustryCategoryService>().GetIndustryCategories().First().IndustryCategoryId
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostJsonAsync(data).ReceiveJson();

            // Assert
            Assert.That(response.AdvertiserName, Is.EqualTo(data.AdvertiserName));
            Assert.That(response.AdvertiserHomepageUrl, Is.EqualTo(data.AdvertiserHomepageUrl));
        }

        [Test]
        public async Task Delete_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/advertisers/";
            await PrepareNewAdvertiser();
            var advertiserService = Container.Resolve<IAdvertiserService>();
            var advertiser = await advertiserService.GetAdvertisers().FirstAsync();

            // Act
            await url.AppendPathSegment(advertiser.AdvertiserUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync();

            // Assert
            Assert.That(advertiser.IsDeleted, Is.True);
        }
    }
}
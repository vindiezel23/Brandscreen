using System.Data.Entity;
using System.Linq;
using System.Net;
using Autofac;
using Brandscreen.Core.Services.Brands;
using Brandscreen.Core.Services.Campaigns;
using Flurl;
using Flurl.Http;
using NUnit.Framework;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class CampaignsApiControllerTests : IocSupportedTests
    {
        [Test]
        public async void Get_ShouldReturnCampaignLists()
        {
            // Arrange
            var url = HostServer.Url + "api/campaigns";
            var campaignService = Container.Resolve<ICampaignService>();
            var totalItemCount = campaignService.GetCampaigns().Count(x => x.BuyerAccountId == 2);

            // Act
            var response = await url
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.TotalItemCount, Is.EqualTo(totalItemCount));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data[0].CampaignUuid, Is.InstanceOf<string>());
            Assert.That(response.Data[0].CampaignName, Is.InstanceOf<string>());
            Assert.That(response.Data[0].AgencyReference, Is.InstanceOf<string>());
        }

        [Test]
        public async void Get_ShouldReturnCampaign_WhenCorrectId()
        {
            // Arrange
            var url = HostServer.Url + "api/campaigns";
            var campaignService = Container.Resolve<ICampaignService>();
            var campaign = await campaignService.GetCampaigns().FirstAsync();
            campaign.CampaignName = "CampaignNameTest";
            campaign.AgencyReference = "AgencyReference";
            await campaignService.UpdateCampaign(campaign);
            SaveDbChanges();

            // Act
            var response = await url
                .AppendPathSegment(campaign.CampaignUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.CampaignUuid, Is.InstanceOf<string>());
            Assert.That(response.CampaignName, Is.EqualTo("CampaignNameTest"));
            Assert.That(response.AgencyReference, Is.EqualTo("AgencyReference"));
        }

        [Test]
        public async void Get_ShouldReturnError_WhenIncorrectId()
        {
            // Arrange
            var url = HostServer.Url + "api/campaigns";
            var incorrectUuid = "not_valid_uuid";

            // Act
            var response = await url.AppendPathSegment(incorrectUuid)
                .WithOAuthBearerToken(await TestHelper.Token)
                .AllowHttpStatus("404")
                .GetAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async void Post_ShouldReturnOk()
        {
            // Arrange
            var url = HostServer.Url + "api/campaigns";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var data = new
            {
                BrandUuid = brand.AdvertiserProductUuid.ToString(),
                CampaignName = "test campaign",
                AgencyReference = "",
                Margin = 0,
                BudgetAmount = 4.0,
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostJsonAsync(data).ReceiveJson();

            // Assert
            Assert.That(response.CampaignName, Is.EqualTo(data.CampaignName));
            Assert.That(response.Margin, Is.EqualTo(data.Margin));
            Assert.That(response.BudgetAmount, Is.EqualTo(data.BudgetAmount));
        }

        [Test]
        public async void Patch_ShouldReturnOk()
        {
            // Arrange
            var url = HostServer.Url + "api/campaigns";
            var campaignService = Container.Resolve<ICampaignService>();
            var campaign = await campaignService.GetCampaigns().FirstAsync();
            var data = new
            {
                CampaignName = "TestAdvertiserName",
                Margin = 0,
            };

            // Act
            await url.AppendPathSegment(campaign.CampaignUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .PatchUrlEncodedAsync(data);

            // Assert
            Assert.That(data.CampaignName, Is.EqualTo(campaign.CampaignName));
            Assert.That(data.Margin, Is.EqualTo(campaign.Margin));
        }

        [Test]
        public async void Delete_ShouldReturnOk()
        {
            // Arrange
            var url = HostServer.Url + "api/campaigns";
            var campaignService = Container.Resolve<ICampaignService>();
            var campaign = await campaignService.GetCampaigns().FirstAsync();

            // Act
            await url.AppendPathSegment(campaign.CampaignUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync()
                .ReceiveJson();

            // Assert
            Assert.That(campaign.IsDeleted, Is.True);
        }
    }
}
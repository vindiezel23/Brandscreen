using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services.Brands;
using Brandscreen.Core.Services.Campaigns;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Moq;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class CampaignsApiControllerTests : ApiControllerMockingTests<CampaignsController>
    {
        [Test]
        public async Task Get_ShouldReturnCampaignLists()
        {
            // Arrange
            var campaign = new Campaign {CampaignUuid = Guid.NewGuid(), CampaignName = "My Campaign"};
            var campaign2 = new Campaign {CampaignUuid = Guid.NewGuid(), CampaignName = "My Campaign 2"};
            var campaigns = new List<Campaign> {campaign, campaign2};
            Mock.Mock<ICampaignService>().Setup(x => x.GetCampaigns(It.IsAny<CampaignQueryOptions>())).Returns(campaigns.ToAsyncEnumerable());

            // Act
            var results = await Controller.Get(null);

            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results.Data, Is.Not.Null);
            Assert.That(results.Data.Count(), Is.EqualTo(2));
            Assert.That(results.Data.First().CampaignName, Is.EqualTo(campaigns[0].CampaignName));
            Assert.That(results.Data.First().CampaignUuid, Is.EqualTo(campaigns[0].CampaignUuid));
        }

        [Test]
        public async Task Get_ShouldReturnCampaign_WhenCorrectId()
        {
            // Arrange
            var campaign = new Campaign {CampaignUuid = Guid.NewGuid(), CampaignName = "My Campaign"};
            Mock.Mock<ICampaignService>().Setup(x => x.GetCampaign(It.IsAny<Guid>())).Returns(Task.FromResult(campaign));

            // Act
            var retVal = await Controller.Get(campaign.CampaignUuid);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<CampaignViewModel>>());
            var content = ((OkNegotiatedContentResult<CampaignViewModel>) retVal).Content;
            Assert.That(content.CampaignName, Is.EqualTo(campaign.CampaignName));
            Assert.That(content.CampaignUuid, Is.EqualTo(campaign.CampaignUuid));
        }

        [Test]
        public async Task Post_ShouldReturnOk()
        {
            // Arrange
            var model = new CampaignCreateViewModel
            {
                BrandUuid = Guid.NewGuid()
            };
            Mock.Mock<IBrandService>().Setup(x => x.GetBrand(model.BrandUuid.Value))
                .Returns(Task.FromResult(new AdvertiserProduct()));
            Mock.Mock<ICampaignService>().Setup(x => x.GetCampaign(It.IsAny<Guid>()))
                .Returns(Task.FromResult(new Campaign()));

            // Act
            var retVal = await Controller.Post(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<CampaignViewModel>>());
            Mock.Mock<ICampaignService>().Verify(x => x.CreateCampaign(It.IsAny<Campaign>()), Times.Once);
        }

        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange
            var campaignUuid = Guid.NewGuid();
            var model = new CampaignPatchViewModel {CampaignName = "WJsHome"};
            Mock.Mock<ICampaignService>().Setup(x => x.GetCampaign(campaignUuid))
                .Returns(Task.FromResult(new Campaign()));

            // Act
            var retVal = await Controller.Patch(campaignUuid, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<ICampaignService>().Verify(x => x.UpdateCampaign(It.Is<Campaign>(brand => brand.CampaignName == model.CampaignName)), Times.Once);
        }

        [Test]
        public async Task Delete_ShouldReturnOk()
        {
            // Arrange
            var campaignUuid = Guid.NewGuid();
            Mock.Mock<ICampaignService>().Setup(x => x.GetCampaign(campaignUuid))
                .Returns(Task.FromResult(new Campaign()));

            // Act
            var retVal = await Controller.Delete(campaignUuid);

            // Assert
            Assert.That(retVal, Is.TypeOf<StatusCodeResult>());
            Assert.That(((StatusCodeResult) retVal).StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Mock.Mock<ICampaignService>().Verify(x => x.DeleteCampaign(campaignUuid), Times.Once);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Core.Services.Advertisers;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Moq;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class AdvertisersControllerTests : ApiControllerMockingTests<AdvertisersController>
    {
        [Test]
        public async Task Get_ShouldReturnListOfAdvertisers()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var model = new AdvertiserQueryViewModel {UserId = userId};
            var buyerAccount1 = new BuyerAccount {BuyerAccountId = 1};
            var buyerAccount2 = new BuyerAccount {BuyerAccountId = 2};
            var advertisers = new List<Advertiser>
            {
                new Advertiser {BuyerAccountId = buyerAccount1.BuyerAccountId, BuyerAccount = buyerAccount1},
                new Advertiser {BuyerAccountId = buyerAccount1.BuyerAccountId, BuyerAccount = buyerAccount1},
                new Advertiser {BuyerAccountId = buyerAccount2.BuyerAccountId, BuyerAccount = buyerAccount2}
            };
            Mock.Mock<IAdvertiserService>().Setup(x => x.GetAdvertisers(It.IsAny<AdvertiserQueryOptions>()))
                .Returns(advertisers.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.Get(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal.TotalItemCount, Is.EqualTo(3));
        }

        [Test]
        public async Task Get_ShouldReturnAdvertiserDetails()
        {
            // Arrange
            var advertiserUuid = Guid.NewGuid();
            var buyerAccount1 = new BuyerAccount {BuyerAccountId = 1};
            var advertiser = new Advertiser {BuyerAccountId = buyerAccount1.BuyerAccountId, BuyerAccount = buyerAccount1, AdvertiserName = "WJsHome"};
            Mock.Mock<IAdvertiserService>().Setup(x => x.GetAdvertiser(advertiserUuid))
                .Returns(Task.FromResult(advertiser));

            // Act
            var retVal = await Controller.Get(advertiserUuid);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<AdvertiserViewModel>>());
            var content = ((OkNegotiatedContentResult<AdvertiserViewModel>) retVal).Content;
            Assert.That(content, Is.Not.Null);
            Assert.That(content.AdvertiserName, Is.EqualTo(advertiser.AdvertiserName));
        }

        [Test]
        public async Task Post_ShouldReturnOk()
        {
            // Arrange
            var model = new AdvertiserCreateViewModel {BuyerAccountUuid = Guid.NewGuid(), IndustryCategoryId = 1};
            Mock.Mock<IAccountService>().Setup(x => x.GetAccount(model.BuyerAccountUuid.Value))
                .Returns(Task.FromResult(new BuyerAccount()));
            Mock.Mock<IIndustryCategoryService>().Setup(x => x.GetIndustryCategory(model.IndustryCategoryId.Value))
                .Returns(Task.FromResult(new IndustryCategory()));
            Mock.Mock<IAdvertiserService>().Setup(x => x.GetAdvertiser(It.IsAny<Guid>()))
                .Returns(Task.FromResult(new Advertiser()));

            // Act
            var retVal = await Controller.Post(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<AdvertiserViewModel>>());
            Mock.Mock<IAdvertiserService>().Verify(x => x.CreateAdvertiser(It.IsAny<Advertiser>()), Times.Once);
        }

        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange
            var advertiserUuid = Guid.NewGuid();
            var model = new AdvertiserPatchViewModel {AdvertiserName = "WJsHome"};
            Mock.Mock<IAdvertiserService>().Setup(x => x.GetAdvertiser(advertiserUuid))
                .Returns(Task.FromResult(new Advertiser()));

            // Act
            var retVal = await Controller.Patch(advertiserUuid, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<IAdvertiserService>().Verify(x => x.UpdateAdvertiser(It.Is<Advertiser>(advertiser => advertiser.AdvertiserName == model.AdvertiserName)), Times.Once);
        }

        [Test]
        public async Task Delete_ShouldReturnOk()
        {
            // Arrange
            var advertiserUuid = Guid.NewGuid();
            Mock.Mock<IAdvertiserService>().Setup(x => x.GetAdvertiser(advertiserUuid))
                .Returns(Task.FromResult(new Advertiser()));

            // Act
            var retVal = await Controller.Delete(advertiserUuid);

            // Assert
            Assert.That(retVal, Is.TypeOf<StatusCodeResult>());
            Assert.That(((StatusCodeResult) retVal).StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Mock.Mock<IAdvertiserService>().Verify(x => x.DeleteAdvertiser(advertiserUuid), Times.Once);
        }
    }
}
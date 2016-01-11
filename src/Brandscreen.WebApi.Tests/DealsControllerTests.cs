using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Core.Services.Deals;
using Brandscreen.Core.Services.Publishers;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;
using Moq;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class DealsControllerTests : ApiControllerMockingTests<DealsController>
    {
        [Test]
        public async Task Get_ShouldReturnDealList()
        {
            // Arrange
            var model = new DealQueryViewModel();
            var deal = new Deal {DealUuid = Guid.NewGuid()};
            var deals = new List<Deal> {deal};

            Mock.Mock<IDealService>().Setup(x => x.GetDeals(It.IsAny<DealQueryOptions>())).Returns(deals.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.Get(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<PagedListViewModel<DealListViewModel>>>());
            var content = ((OkNegotiatedContentResult<PagedListViewModel<DealListViewModel>>) retVal).Content;
            Assert.That(content.TotalItemCount, Is.EqualTo(1));
            Assert.That(content.Data.ElementAt(0).DealUuid, Is.EqualTo(deal.DealUuid));
        }

        [Test]
        public async Task Get_ShouldReturnDealDetail()
        {
            // Arrange
            var deal = new Deal {DealUuid = Guid.NewGuid()};
            Mock.Mock<IDealService>().Setup(x => x.GetDeal(deal.DealUuid)).Returns(Task.FromResult(deal));

            // Act
            var retVal = await Controller.Get(deal.DealUuid);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<DealViewModel>>());
            var content = ((OkNegotiatedContentResult<DealViewModel>) retVal).Content;
            Assert.That(content.DealUuid, Is.EqualTo(deal.DealUuid));
        }

        [Test]
        public async Task Post_ShouldReturnOk()
        {
            // Arrange
            var model = new DealCreateViewModel {BuyerAccountUuid = Guid.NewGuid(), PublisherUuid = Guid.NewGuid(), DealKey = "JingWu", DealType = "Fixed"};
            var deal = new Deal();
            Mock.Mock<IAccountService>().Setup(x => x.GetAccount(model.BuyerAccountUuid.Value))
                .Returns(Task.FromResult(new BuyerAccount()));
            Mock.Mock<IPublisherService>().Setup(x => x.GetPublisher(model.PublisherUuid.Value))
                .Returns(Task.FromResult(new Publisher()));
            Mock.Mock<ICurrencyService>().Setup(x => x.GetCurrency(It.IsAny<string>()))
                .Returns(Task.FromResult(new Currency()));
            Mock.Mock<IDealService>().Setup(x => x.CreateDeal(It.IsAny<Deal>()))
                .Returns(Task.FromResult(deal));
            Mock.Mock<IDealService>().Setup(x => x.GetDeal(It.IsAny<Guid>()))
                .Returns(Task.FromResult(deal));

            // Act
            var retVal = await Controller.Post(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<DealViewModel>>());
            Mock.Mock<IDealService>().Verify(x => x.CreateDeal(It.IsAny<Deal>()), Times.Once);
        }

        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange
            var dealUuid = Guid.NewGuid();
            var model = new DealPatchViewModel {DealName = "WJsHome"};
            Mock.Mock<IDealService>().Setup(x => x.GetDeal(dealUuid))
                .Returns(Task.FromResult(new Deal()));

            // Act
            var retVal = await Controller.Patch(dealUuid, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<IDealService>().Verify(x => x.UpdateDeal(It.Is<Deal>(advertiser => advertiser.DealName == model.DealName)), Times.Once);
        }

        [Test]
        public async Task Delete_ShouldReturnOk()
        {
            // Arrange
            var dealUuid = Guid.NewGuid();
            Mock.Mock<IDealService>().Setup(x => x.GetDeal(dealUuid))
                .Returns(Task.FromResult(new Deal()));

            // Act
            var retVal = await Controller.Delete(dealUuid);

            // Assert
            Assert.That(retVal, Is.TypeOf<StatusCodeResult>());
            Assert.That(((StatusCodeResult) retVal).StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Mock.Mock<IDealService>().Verify(x => x.DeleteDeal(dealUuid), Times.Once);
        }
    }
}
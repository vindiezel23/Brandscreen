using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Advertisers;
using Brandscreen.Core.Services.Brands;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Moq;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    public class BrandsControllerTests : ApiControllerMockingTests<BrandsController>
    {
        [Test]
        public async Task Get_ShouldReturnListOfBrands()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var model = new BrandQueryViewModel {UserId = userId};
            var buyerAccount = new BuyerAccount {BuyerAccountId = 1};
            var advertiser = new Advertiser {BuyerAccountId = buyerAccount.BuyerAccountId, BuyerAccount = buyerAccount, AdvertiserId = 1};
            var advertiserProduct1 = new AdvertiserProduct {AdvertiserId = advertiser.AdvertiserId, ProductName = "product a"};
            var advertiserProduct2 = new AdvertiserProduct {AdvertiserId = advertiser.AdvertiserId, ProductName = "product b"};
            var advertiserProducts = new List<AdvertiserProduct> {advertiserProduct1, advertiserProduct2};

            Mock.Mock<IBrandService>().Setup(x => x.GetBrands(It.IsAny<BrandQueryOptions>()))
                .Returns(advertiserProducts.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.Get(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal.TotalItemCount, Is.EqualTo(2));
        }

        [Test]
        public async Task Get_ShouldReturnBrandDetails()
        {
            // Arrange
            var brandUuid = Guid.NewGuid();
            var buyerAccount = new BuyerAccount {BuyerAccountId = 1};
            var advertiser = new Advertiser {BuyerAccountId = buyerAccount.BuyerAccountId, BuyerAccount = buyerAccount, AdvertiserId = 1};
            var advertiserProduct = new AdvertiserProduct {AdvertiserId = advertiser.AdvertiserId, ProductName = "product name"};

            Mock.Mock<IBrandService>().Setup(x => x.GetBrand(brandUuid))
                .Returns(Task.FromResult(advertiserProduct));

            // Act
            var retVal = await Controller.Get(brandUuid);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<BrandViewModel>>());
            var content = ((OkNegotiatedContentResult<BrandViewModel>) retVal).Content;
            Assert.That(content, Is.Not.Null);
            Assert.That(content.BrandName, Is.EqualTo(advertiserProduct.ProductName));
        }

        [Test]
        public async Task Post_ShouldReturnOk()
        {
            // Arrange
            var model = new BrandCreateViewModel
            {
                AdvertiserUuid = Guid.NewGuid(),
                SiteListOption = "AllSites",
                BrandSafetyMode = "RunOnAllSites",
                ProductCategoryId = 1
            };
            Mock.Mock<IAdvertiserService>().Setup(x => x.GetAdvertiser(It.IsAny<Guid>()))
                .Returns(Task.FromResult(new Advertiser()));
            Mock.Mock<IProductCategoryService>().Setup(x => x.GetProductCategory(It.IsAny<int>()))
                .Returns(Task.FromResult(new ProductCategory()));
            Mock.Mock<IBrandService>().Setup(x => x.GetBrand(It.IsAny<Guid>()))
                .Returns(Task.FromResult(new AdvertiserProduct()));

            // Act
            var retVal = await Controller.Post(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<BrandViewModel>>());
            Mock.Mock<IBrandService>().Verify(x => x.CreateBrand(It.IsAny<AdvertiserProduct>()), Times.Once);
        }

        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange
            var brandUuid = Guid.NewGuid();
            var model = new BrandPatchViewModel {BrandName = "WJsHome"};
            Mock.Mock<IBrandService>().Setup(x => x.GetBrand(brandUuid))
                .Returns(Task.FromResult(new AdvertiserProduct()));

            // Act
            var retVal = await Controller.Patch(brandUuid, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<IBrandService>().Verify(x => x.UpdateBrand(It.Is<AdvertiserProduct>(brand => brand.ProductName == model.BrandName)), Times.Once);
        }

        [Test]
        public async Task Delete_ShouldReturnOk()
        {
            // Arrange
            var brandUuid = Guid.NewGuid();
            Mock.Mock<IBrandService>().Setup(x => x.GetBrand(brandUuid))
                .Returns(Task.FromResult(new AdvertiserProduct()));

            // Act
            var retVal = await Controller.Delete(brandUuid);

            // Assert
            Assert.That(retVal, Is.TypeOf<StatusCodeResult>());
            Assert.That(((StatusCodeResult) retVal).StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Mock.Mock<IBrandService>().Verify(x => x.DeleteBrand(brandUuid), Times.Once);
        }
    }
}
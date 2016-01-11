using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Advertisers;
using Brandscreen.Core.Services.Brands;
using Flurl;
using Flurl.Http;
using NUnit.Framework;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class BrandsControllerTests : IocSupportedTests
    {
        private async Task PrepareNewBrand()
        {
            // Arrange
            var url = HostServer.Url + "api/brands/";
            var advertiserService = Container.Resolve<IAdvertiserService>();
            var advertiser = await advertiserService.GetAdvertisers().FirstAsync();
            var data = new
            {
                AdvertiserUuid = advertiser.AdvertiserUuid,
                BrandName = "TestBrandName",
                BrandHomepageUrl = "http://www.brandscreen.com",
                SiteListOption = "1",
                BrandSafetyMode = "0",
                ProductCategoryId = Container.Resolve<IProductCategoryService>().GetProductCategorys().First().ProductCategoryId
            };

            // Act
            await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostUrlEncodedAsync(data);
        }

        [Test]
        public async Task Get_ShouldReturnListOfBrands()
        {
            // Arrange 
            var url = HostServer.Url + "api/brands/";
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
        public async Task Get_ShouldReturnBrandDetails()
        {
            // Arrange 
            var url = HostServer.Url + "api/brands/";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            brand.ProductName = "TestName";
            await brandService.UpdateBrand(brand);
            SaveDbChanges();

            // Act
            var response = await url.AppendPathSegment(brand.AdvertiserProductUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response.BrandUuid, Is.EqualTo(brand.AdvertiserProductUuid.ToString()));
            Assert.That(response.BrandName, Is.EqualTo(brand.ProductName));
        }


        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/brands/";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var data = new
            {
                BrandName = "TestName",
            };

            // Act
            await url.AppendPathSegment(brand.AdvertiserProductUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .PatchUrlEncodedAsync(data);

            // Assert
            Assert.That(data.BrandName, Is.EqualTo(brand.ProductName));
        }

        [Test]
        public async Task Post_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/brands/";
            var advertiserService = Container.Resolve<IAdvertiserService>();
            var advertiser = await advertiserService.GetAdvertisers().FirstAsync();
            var data = new
            {
                AdvertiserUuid = advertiser.AdvertiserUuid,
                BrandName = "TestBrandName",
                BrandHomepageUrl = "http://www.brandscreen.com",
                SiteListOption = "1",
                BrandSafetyMode = "0",
                ProductCategoryId = Container.Resolve<IProductCategoryService>().GetProductCategorys().First().ProductCategoryId
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostJsonAsync(data).ReceiveJson();

            // Assert
            Assert.That(response.BrandName, Is.EqualTo(data.BrandName));
            Assert.That(response.BrandHomepageUrl, Is.EqualTo(data.BrandHomepageUrl));
        }

        [Test]
        public async Task Delete_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/brands/";
            await PrepareNewBrand();
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();

            // Act
            await url.AppendPathSegment(brand.AdvertiserProductUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync();

            // Assert
            Assert.That(brand.IsDeleted, Is.True);
        }
    }
}
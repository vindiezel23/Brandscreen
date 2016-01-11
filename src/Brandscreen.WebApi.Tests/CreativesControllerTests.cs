using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Brands;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Core.Services.Creatives.Vast;
using Brandscreen.Core.Settings;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Moq;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class CreativesControllerTests : ApiControllerMockingTests<CreativesController>
    {
        [Test]
        public async Task Get_ShouldReturnCampaignLists()
        {
            // Arrange
            var creative1 = new Creative {CreativeUuid = Guid.NewGuid(), CreativeName = "creative a"};
            var creative2 = new Creative {CreativeUuid = Guid.NewGuid(), CreativeName = "creative b"};
            var creatives = new List<Creative> {creative1, creative2};
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreatives(It.IsAny<CreativeQueryOptions>())).Returns(creatives.ToAsyncEnumerable());

            // Act
            var results = await Controller.Get(null);

            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results.Data, Is.Not.Null);
            Assert.That(results.Data.Count(), Is.EqualTo(2));
            Assert.That(results.Data.First().CreativeUuid, Is.EqualTo(creatives[0].CreativeUuid));
            Assert.That(results.Data.First().CreativeName, Is.EqualTo(creatives[0].CreativeName));
        }

        [Test]
        public async Task Get_ShouldReturnCampaign_WhenCorrectId()
        {
            // Arrange
            var creative = new Creative
            {
                CreativeUuid = Guid.NewGuid(),
                CreativeName = "creative",
                AdvertiserProduct = new AdvertiserProduct(),
                CreativeFile = new CreativeFile()
            };
            Mock.Mock<IAmazonSettings>().SetupGet(x => x.BucketCreativeUrl).Returns("https://creatives.brandscreen.com");
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreative(creative.CreativeUuid)).Returns(Task.FromResult(creative));

            // Act
            var retVal = await Controller.Get(creative.CreativeUuid);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<CreativeViewModel>>());
            var content = ((OkNegotiatedContentResult<CreativeViewModel>) retVal).Content;
            Assert.That(content.CreativeUuid, Is.EqualTo(creative.CreativeUuid));
            Assert.That(content.CreativeName, Is.EqualTo(creative.CreativeName));
        }

        [Test]
        public async Task Post_ShouldReturnOk()
        {
            // Arrange
            var model = new CreativeCreateViewModel
            {
                BrandUuid = Guid.NewGuid(),
                CreativeName = "WJsHome",
                AdTagTemplateId = 1
            };
            var creative = new Creative
            {
                CreativeUuid = Guid.NewGuid(),
                CreativeName = model.CreativeName,
                AdvertiserProduct = new AdvertiserProduct {AdvertiserProductUuid = model.BrandUuid.Value},
                CreativeFile = new CreativeFile()
            };

            Mock.Mock<IBrandService>().Setup(x => x.GetBrand(model.BrandUuid.Value))
                .Returns(Task.FromResult(creative.AdvertiserProduct));
            Mock.Mock<IAdTagTemplateService>().Setup(x => x.GetAdTagTemplate(model.AdTagTemplateId.Value))
                .Returns(Task.FromResult(new AdTagTemplate {CreativeTypeId = 0}));
            Mock.Mock<ILanguageService>().Setup(x => x.GetLanguage(It.IsAny<string>()))
                .Returns(Task.FromResult(new Language()));
            Mock.Mock<ICreativeService>().Setup(x => x.CreateCreative(It.IsAny<CreativeCreateOptions>()))
                .Returns(Task.FromResult(creative));
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreative(creative.CreativeUuid))
                .Returns(Task.FromResult(creative));
            Mock.Mock<IAmazonSettings>().SetupGet(x => x.BucketCreativeUrl)
                .Returns("https://creatives.brandscreen.com");

            // Act
            var retVal = await Controller.Post(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<CreativeViewModel>>());
        }

        [Test]
        public async Task PostDooh_ShouldReturnOk()
        {
            // Arrange
            var model = new CreativeDoohCreateViewModel
            {
                BrandUuid = Guid.NewGuid(),
                CreativeName = "WJsHome",
                CreativeSizeId = 1
            };
            var creative = new Creative
            {
                CreativeUuid = Guid.NewGuid(),
                CreativeName = model.CreativeName,
                AdvertiserProduct = new AdvertiserProduct {AdvertiserProductUuid = model.BrandUuid.Value},
                CreativeFile = new CreativeFile()
            };

            Mock.Mock<IBrandService>().Setup(x => x.GetBrand(model.BrandUuid.Value))
                .Returns(Task.FromResult(creative.AdvertiserProduct));
            Mock.Mock<ICreativeService>().Setup(x => x.CreateCreative(It.IsAny<CreativeDoohCreateOptions>()))
                .Returns(Task.FromResult(creative));
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreative(creative.CreativeUuid))
                .Returns(Task.FromResult(creative));
            Mock.Mock<ICreativeSizeService>().Setup(x => x.GetCreativeSize(model.CreativeSizeId.Value))
                .Returns(Task.FromResult(new CreativeSize()));
            Mock.Mock<IAmazonSettings>().SetupGet(x => x.BucketCreativeUrl)
                .Returns("https://creatives.brandscreen.com");

            // Act
            var retVal = await Controller.PostDooh(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<CreativeViewModel>>());
        }

        [Test]
        public async Task PostDoohVideo_ShouldReturnOk()
        {
            // Arrange
            var model = new CreativeDoohVideoCreateViewModel
            {
                BrandUuid = Guid.NewGuid(),
                CreativeName = "WJsHome",
                CreativeSizeId = 1
            };
            var creative = new Creative
            {
                CreativeUuid = Guid.NewGuid(),
                CreativeName = model.CreativeName,
                AdvertiserProduct = new AdvertiserProduct {AdvertiserProductUuid = model.BrandUuid.Value},
                CreativeFile = new CreativeFile()
            };

            Mock.Mock<IBrandService>().Setup(x => x.GetBrand(model.BrandUuid.Value))
                .Returns(Task.FromResult(creative.AdvertiserProduct));
            Mock.Mock<ICreativeService>().Setup(x => x.CreateCreative(It.IsAny<CreativeDoohVideoCreateOptions>()))
                .Returns(Task.FromResult(creative));
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreative(creative.CreativeUuid))
                .Returns(Task.FromResult(creative));
            Mock.Mock<ICreativeSizeService>().Setup(x => x.GetCreativeSize(model.CreativeSizeId.Value))
                .Returns(Task.FromResult(new CreativeSize()));
            Mock.Mock<IAmazonSettings>().SetupGet(x => x.BucketCreativeUrl)
                .Returns("https://creatives.brandscreen.com");

            // Act
            var retVal = await Controller.PostDoohVideo(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<CreativeViewModel>>());
        }

        [Test]
        public async Task PostDoohVideoUrl_ShouldReturnOk()
        {
            // Arrange
            var model = new CreativeDoohVideoUrlCreateViewModel
            {
                BrandUuid = Guid.NewGuid(),
                CreativeName = "WJsHome",
                CreativeSizeId = 1
            };
            var creative = new Creative
            {
                CreativeUuid = Guid.NewGuid(),
                CreativeName = model.CreativeName,
                AdvertiserProduct = new AdvertiserProduct {AdvertiserProductUuid = model.BrandUuid.Value},
                CreativeFile = new CreativeFile()
            };

            Mock.Mock<IBrandService>().Setup(x => x.GetBrand(model.BrandUuid.Value))
                .Returns(Task.FromResult(creative.AdvertiserProduct));
            Mock.Mock<ICreativeService>().Setup(x => x.CreateCreative(It.IsAny<CreativeDoohVideoUrlCreateOptions>()))
                .Returns(Task.FromResult(creative));
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreative(creative.CreativeUuid))
                .Returns(Task.FromResult(creative));
            Mock.Mock<ICreativeSizeService>().Setup(x => x.GetCreativeSize(model.CreativeSizeId.Value))
                .Returns(Task.FromResult(new CreativeSize()));
            Mock.Mock<IAmazonSettings>().SetupGet(x => x.BucketCreativeUrl)
                .Returns("https://creatives.brandscreen.com");

            // Act
            var retVal = await Controller.PostDoohVideoUrl(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<CreativeViewModel>>());
        }

        [Test]
        public async Task PostVast_ShouldReturnOk()
        {
            // Arrange
            var model = new CreativeVastCreateViewModel
            {
                BrandUuid = Guid.NewGuid(),
                CreativeName = "WJsHome",
                VastUrl = "http://www.wjshome.com/",
                Direction = "None",
                LanguageCode = "en"
            };
            var creative = new Creative
            {
                CreativeUuid = Guid.NewGuid(),
                CreativeName = model.CreativeName,
                AdvertiserProduct = new AdvertiserProduct {AdvertiserProductUuid = model.BrandUuid.Value},
            };
            var xml = File.ReadAllText("Data/vast2RegularLinear.xml");

            Mock.Mock<IBrandService>().Setup(x => x.GetBrand(model.BrandUuid.Value))
                .Returns(Task.FromResult(creative.AdvertiserProduct));
            Mock.Mock<IVastService>().Setup(x => x.Download(model.VastUrl))
                .Returns(Task.FromResult(xml));
            Mock.Mock<IVastService>().Setup(x => x.Validate(xml))
                .Returns(Task.FromResult(new VastValidationResult(true)));
            Mock.Mock<ILanguageService>().Setup(x => x.GetLanguage(It.IsAny<string>()))
                .Returns(Task.FromResult(new Language()));
            Mock.Mock<ICreativeService>().Setup(x => x.CreateCreative(It.IsAny<CreativeVastCreateOptions>()))
                .Returns(Task.FromResult(creative));
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreative(creative.CreativeUuid))
                .Returns(Task.FromResult(creative));

            // Act
            var retVal = await Controller.PostVast(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<CreativeViewModel>>());
        }

        [Test]
        public async Task PostSwiffy_ShouldReturnOk()
        {
            // Arrange
            var model = new CreativeSwiffyCreateViewModel
            {
                BrandUuid = Guid.NewGuid(),
                CreativeName = "WJsHome",
                LanguageCode = "en",
            };
            var creative = new Creative
            {
                CreativeUuid = Guid.NewGuid(),
                CreativeName = model.CreativeName,
                AdvertiserProduct = new AdvertiserProduct {AdvertiserProductUuid = model.BrandUuid.Value},
            };

            Mock.Mock<IBrandService>().Setup(x => x.GetBrand(model.BrandUuid.Value))
                .Returns(Task.FromResult(creative.AdvertiserProduct));
            Mock.Mock<ILanguageService>().Setup(x => x.GetLanguage(It.IsAny<string>()))
                .Returns(Task.FromResult(new Language()));
            Mock.Mock<ICreativeService>().Setup(x => x.CreateCreative(It.IsAny<CreativeSwiffyCreateOptions>()))
                .Returns(Task.FromResult(creative));
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreative(creative.CreativeUuid))
                .Returns(Task.FromResult(creative));

            // Act
            var retVal = await Controller.PostSwiffy(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<CreativeViewModel>>());
        }

        [Test]
        public async Task PostHtml5_ShouldReturnOk()
        {
            // Arrange
            var model = new CreativeHtml5CreateViewModel
            {
                BrandUuid = Guid.NewGuid(),
                CreativeName = "WJsHome",
                LanguageCode = "en",
            };
            var creative = new Creative
            {
                CreativeUuid = Guid.NewGuid(),
                CreativeName = model.CreativeName,
                AdvertiserProduct = new AdvertiserProduct {AdvertiserProductUuid = model.BrandUuid.Value},
            };

            Mock.Mock<IBrandService>().Setup(x => x.GetBrand(model.BrandUuid.Value))
                .Returns(Task.FromResult(creative.AdvertiserProduct));
            Mock.Mock<ILanguageService>().Setup(x => x.GetLanguage(It.IsAny<string>()))
                .Returns(Task.FromResult(new Language()));
            Mock.Mock<ICreativeService>().Setup(x => x.CreateCreative(It.IsAny<CreativeHtml5CreateOptions>()))
                .Returns(Task.FromResult(creative));
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreative(creative.CreativeUuid))
                .Returns(Task.FromResult(creative));

            // Act
            var retVal = await Controller.PostHtml5(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<CreativeViewModel>>());
        }

        [Test]
        public async Task PostAdTag_ShouldReturnOk()
        {
            // Arrange
            var model = new CreativeAdTagCreateViewModel
            {
                BrandUuid = Guid.NewGuid(),
                CreativeName = "WJsHome",
                CreativeSizeId = 1,
                AdTagTemplateId = 1
            };
            var creative = new Creative
            {
                CreativeUuid = Guid.NewGuid(),
                CreativeName = model.CreativeName,
                AdvertiserProduct = new AdvertiserProduct {AdvertiserProductUuid = model.BrandUuid.Value}
            };

            Mock.Mock<IBrandService>().Setup(x => x.GetBrand(model.BrandUuid.Value))
                .Returns(Task.FromResult(creative.AdvertiserProduct));
            Mock.Mock<IAdTagTemplateService>().Setup(x => x.GetAdTagTemplate(model.AdTagTemplateId.Value))
                .Returns(Task.FromResult(new AdTagTemplate {CreativeTypeId = 0}));
            Mock.Mock<ICreativeSizeService>().Setup(x => x.GetCreativeSize(model.CreativeSizeId.Value))
                .Returns(Task.FromResult(new CreativeSize()));
            Mock.Mock<ILanguageService>().Setup(x => x.GetLanguage(It.IsAny<string>()))
                .Returns(Task.FromResult(new Language()));
            Mock.Mock<ICreativeService>().Setup(x => x.CreateCreative(It.IsAny<CreativeAdTagCreateOptions>()))
                .Returns(Task.FromResult(creative));
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreative(creative.CreativeUuid))
                .Returns(Task.FromResult(creative));

            // Act
            var retVal = await Controller.PostAdTag(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<CreativeViewModel>>());
        }

        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange
            var creativeUuid = Guid.NewGuid();
            var model = new CreativePatchViewModel {CreativeName = "WJsHome"};
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreative(creativeUuid))
                .Returns(Task.FromResult(new Creative()));

            // Act
            var retVal = await Controller.Patch(creativeUuid, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<ICreativeService>().Verify(x => x.UpdateCreative(It.Is<CreativeUpdateOptions>(options => options.NewCreative.CreativeName == model.CreativeName)), Times.Once);
        }

        [Test]
        public async Task Delete_ShouldReturnOk()
        {
            // Arrange
            var creativeUuid = Guid.NewGuid();
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreative(creativeUuid))
                .Returns(Task.FromResult(new Creative()));

            // Act
            var retVal = await Controller.Delete(creativeUuid);

            // Assert
            Assert.That(retVal, Is.TypeOf<StatusCodeResult>());
            Assert.That(((StatusCodeResult) retVal).StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Mock.Mock<ICreativeService>().Verify(x => x.DeleteCreative(creativeUuid), Times.Once);
        }

        [Test]
        public async Task GetParameters_ShouldReturnListOfCreativeParameters()
        {
            // Arrange
            var creativeUuid = Guid.NewGuid();
            var creativeParameters = new List<CreativeParameter>
            {
                new CreativeParameter(),
                new CreativeParameter()
            };
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreative(creativeUuid)).Returns(Task.FromResult(new Creative()));
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreativeParameters(creativeUuid)).Returns(creativeParameters.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.GetParameters(creativeUuid);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<CreativeParameterListViewModel>>());
            var content = ((OkNegotiatedContentResult<CreativeParameterListViewModel>) retVal).Content;
            Assert.That(content.CreativeUuid, Is.EqualTo(creativeUuid));
            Assert.That(content.Data, Is.AssignableTo<IEnumerable<CreativeParameterViewModel>>());
            Assert.That(content.Data.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetReviews_ShouldReturnCreativeReviewList()
        {
            // Arrange
            var creativeUuid = Guid.NewGuid();
            var reviews = new List<CreativeReview>
            {
                new CreativeReview(),
                new CreativeReview()
            };
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreative(creativeUuid))
                .Returns(Task.FromResult(new Creative {UtcModifiedDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)}));
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreativeReviews(creativeUuid))
                .Returns(reviews.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.GetReviews(creativeUuid);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<IEnumerable<CreativeReviewListViewModel>>>());
            var content = ((OkNegotiatedContentResult<IEnumerable<CreativeReviewListViewModel>>) retVal).Content;
            Assert.That(content.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task PutReview_ShouldReturnOk()
        {
            // Arrange
            var creativeUuid = Guid.NewGuid();
            var model = new CreativeReviewViewModel
            {
                PartnerId = 0,
                Status = "Ready",
                CreativeVersion = 0
            };
            Mock.Mock<ICreativeService>().Setup(x => x.GetCreative(creativeUuid))
                .Returns(Task.FromResult(new Creative {UtcModifiedDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)}));

            // Act
            var retVal = await Controller.PutReview(creativeUuid, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<ICreativeService>().Verify(x => x.CreateOrUpdateCreativeReview(It.Is<CreativeReviewModifyOptions>(options => options.CreativeUuid == creativeUuid)), Times.Once);
        }
    }
}
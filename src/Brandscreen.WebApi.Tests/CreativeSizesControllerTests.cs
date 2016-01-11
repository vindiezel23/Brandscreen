using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;
using Moq;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class CreativeSizesControllerTests : ApiControllerMockingTests<CreativeSizesController>
    {
        [Test]
        public async Task Get_ShouldReturnCreativeSizeList()
        {
            // Arrange
            var model = new CreativeSizeQueryViewModel();
            var creativeSize = new CreativeSize {CreativeSizeName = "size"};
            var creativeSizes = new List<CreativeSize> {creativeSize};

            Mock.Mock<ICreativeSizeService>().Setup(x => x.GetCreativeSizes(It.IsAny<CreativeSizeQueryOptions>())).Returns(creativeSizes.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.Get(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<PagedListViewModel<CreativeSizeListViewModel>>>());
            var content = ((OkNegotiatedContentResult<PagedListViewModel<CreativeSizeListViewModel>>) retVal).Content;
            Assert.That(content.TotalItemCount, Is.EqualTo(1));
            Assert.That(content.Data.ElementAt(0).CreativeSizeName, Is.EqualTo(creativeSize.CreativeSizeName));
        }

        [Test]
        public async Task Get_ShouldReturnCreativeSizeDetail()
        {
            // Arrange
            var creativeSize = new CreativeSize {CreativeSizeId = 1};
            Mock.Mock<ICreativeSizeService>().Setup(x => x.GetCreativeSize(creativeSize.CreativeSizeId))
                .ReturnsAsync(creativeSize);

            // Act
            var retVal = await Controller.Get(creativeSize.CreativeSizeId);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<CreativeSizeViewModel>>());
            var content = ((OkNegotiatedContentResult<CreativeSizeViewModel>) retVal).Content;
            Assert.That(content.CreativeSizeId, Is.EqualTo(creativeSize.CreativeSizeId));
        }

        [Test]
        public async Task Post_ShouldReturnOk()
        {
            // Arrange
            const int creativeSizeId = 1;
            var model = new CreativeSizeCreateViewModel {CreativeSizeId = creativeSizeId, CreativeSizeName = "WJsHome", MediaType = "Display"};
            var creativeSize = new CreativeSize {CreativeSizeId = creativeSizeId};

            var creativeSizeQueue = new Queue<CreativeSize>(new List<CreativeSize> {null, creativeSize}); // moq returns
            Mock.Mock<ICreativeSizeService>().Setup(x => x.GetCreativeSize(creativeSizeId))
                .Returns(() => Task.FromResult(creativeSizeQueue.Dequeue()));

            // Act
            var retVal = await Controller.Post(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<CreativeSizeViewModel>>());
            Mock.Mock<ICreativeSizeService>().Verify(x => x.CreateCreativeSize(It.IsAny<CreativeSize>()), Times.Once);
        }

        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange
            var creativeSize = new CreativeSize {CreativeSizeId = 1};
            var model = new CreativeSizePatchViewModel {CreativeSizeName = "WJsHome"};
            Mock.Mock<ICreativeSizeService>().Setup(x => x.GetCreativeSize(creativeSize.CreativeSizeId))
                .ReturnsAsync(creativeSize);

            // Act
            var retVal = await Controller.Patch(creativeSize.CreativeSizeId, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<ICreativeSizeService>().Verify(x => x.UpdateCreativeSize(It.Is<CreativeSize>(y => y.CreativeSizeName == model.CreativeSizeName)), Times.Once);
        }
    }
}
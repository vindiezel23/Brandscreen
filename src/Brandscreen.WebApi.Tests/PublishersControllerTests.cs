using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
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
    public class PublishersControllerTests : ApiControllerMockingTests<PublishersController>
    {
        [Test]
        public async Task Get_ShouldReturnPublisherList()
        {
            // Arrange
            var model = new PublisherQueryViewModel();
            var publisher = new Publisher {PublisherUuid = Guid.NewGuid()};
            var publishers = new List<Publisher> {publisher};

            Mock.Mock<IPublisherService>().Setup(x => x.GetPublishers(It.IsAny<PublisherQueryOptions>())).Returns(publishers.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.Get(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<PagedListViewModel<PublisherListViewModel>>>());
            var content = ((OkNegotiatedContentResult<PagedListViewModel<PublisherListViewModel>>) retVal).Content;
            Assert.That(content.TotalItemCount, Is.EqualTo(1));
            Assert.That(content.Data.ElementAt(0).PublisherUuid, Is.EqualTo(publisher.PublisherUuid));
        }

        [Test]
        public async Task Get_ShouldReturnPublisherDetail_WhenIntegerId()
        {
            // Arrange
            var publisher = new Publisher {PublisherId = 1};
            Mock.Mock<IPublisherService>().Setup(x => x.GetPublisher(publisher.PublisherId)).Returns(Task.FromResult(publisher));

            // Act
            var retVal = await Controller.Get(publisher.PublisherId);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<PublisherViewModel>>());
            var content = ((OkNegotiatedContentResult<PublisherViewModel>) retVal).Content;
            Assert.That(content.PublisherUuid, Is.EqualTo(publisher.PublisherUuid));
        }

        [Test]
        public async Task Get_ShouldReturnPublisherDetail_WhenGuidId()
        {
            // Arrange
            var publisher = new Publisher {PublisherUuid = Guid.NewGuid()};
            Mock.Mock<IPublisherService>().Setup(x => x.GetPublisher(publisher.PublisherUuid)).Returns(Task.FromResult(publisher));

            // Act
            var retVal = await Controller.Get(publisher.PublisherUuid);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<PublisherViewModel>>());
            var content = ((OkNegotiatedContentResult<PublisherViewModel>) retVal).Content;
            Assert.That(content.PublisherUuid, Is.EqualTo(publisher.PublisherUuid));
        }
    }
}
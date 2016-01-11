using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services.Advertisers;
using Brandscreen.Core.Services.Segments;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Moq;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    public class SegmentsControllerTests : ApiControllerMockingTests<SegmentsController>
    {
        [Test]
        public async Task Get_ShouldReturnListOfSegments()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var model = new SegmentQueryViewModel {UserId = userId};
            var buyerAccount = new BuyerAccount {BuyerAccountId = 1};
            var advertiser = new Advertiser {BuyerAccountId = buyerAccount.BuyerAccountId, BuyerAccount = buyerAccount, AdvertiserId = 1};
            var segment1 = new Segment {AdvertiserId = advertiser.AdvertiserId, SegmentName = "segment a"};
            var segment2 = new Segment {AdvertiserId = advertiser.AdvertiserId, SegmentName = "segment b"};
            var segments = new List<Segment> {segment1, segment2};

            Mock.Mock<ISegmentService>().Setup(x => x.GetSegments(It.IsAny<SegmentQueryOptions>()))
                .Returns(segments.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.Get(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal.TotalItemCount, Is.EqualTo(2));
        }

        [Test]
        public async Task Get_ShouldReturnSegmentDetails()
        {
            // Arrange
            var segmentId = 1;
            var buyerAccount = new BuyerAccount {BuyerAccountId = 1};
            var advertiser = new Advertiser {BuyerAccountId = buyerAccount.BuyerAccountId, BuyerAccount = buyerAccount, AdvertiserId = 1};
            var segment = new Segment {AdvertiserId = advertiser.AdvertiserId, SegmentName = "segment name"};

            Mock.Mock<ISegmentService>().Setup(x => x.GetSegment(segmentId))
                .Returns(Task.FromResult(segment));

            // Act
            var retVal = await Controller.Get(segmentId);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<SegmentViewModel>>());
            var content = ((OkNegotiatedContentResult<SegmentViewModel>) retVal).Content;
            Assert.That(content, Is.Not.Null);
            Assert.That(content.SegmentName, Is.EqualTo(segment.SegmentName));
        }

        [Test]
        public async Task PostRemarketings_ShouldReturnOk()
        {
            // Arrange
            var model = new SegmentRemarketingCreateViewModel
            {
                AdvertiserUuid = Guid.NewGuid(),
                Name = "WJsHome",
                Url = "www.google.com",
                RemarketingRecency = 1
            };

            Mock.Mock<IAdvertiserService>().Setup(x => x.GetAdvertiser(It.IsAny<Guid>()))
                .Returns(Task.FromResult(new Advertiser()));
            Mock.Mock<ISegmentService>().Setup(x => x.GetSegment(It.IsAny<int>()))
                .Returns(Task.FromResult(new Segment()));

            // Act
            var retVal = await Controller.PostRemarketings(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<SegmentViewModel>>());
            Mock.Mock<ISegmentService>().Verify(x => x.CreateSegment(It.IsAny<Segment>()), Times.Once);
        }

        [Test]
        public async Task PatchRemarketings_ShouldReturnOk()
        {
            // Arrange
            var id = 1;
            var model = new SegmentRemarketingPatchViewModel
            {
                Name = "WJsHome",
                Url = "www.google.com",
                RemarketingRecency = 1
            };

            Mock.Mock<ISegmentService>().Setup(x => x.GetSegment(id))
                .Returns(Task.FromResult(new Segment()));

            // Act
            var retVal = await Controller.PatchRemarketings(id, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<ISegmentService>().Verify(x => x.UpdateSegment(It.IsAny<Segment>()), Times.Once);
        }

        [Test]
        public async Task PostConversions_ShouldReturnOk()
        {
            // Arrange
            var model = new SegmentConversionCreateViewModel
            {
                AdvertiserUuid = Guid.NewGuid(),
                Name = "WJsHome",
                Url = "www.google.com",
                AttributionModel = ConversionAttributionModelEnum.LastClick.ToString(),
                PostClickLifetime = 1,
                PostClickLifetimePeriod = PeriodTypeEnum.PerDay.ToString(),
                AttributionCountingMode = ConversionAttributionCountingModeEnum.OncePerLifetime.ToString()
            };

            Mock.Mock<IAdvertiserService>().Setup(x => x.GetAdvertiser(It.IsAny<Guid>()))
                .Returns(Task.FromResult(new Advertiser()));
            Mock.Mock<ISegmentService>().Setup(x => x.GetSegment(It.IsAny<int>()))
                .Returns(Task.FromResult(new Segment()));

            // Act
            var retVal = await Controller.PostConversions(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<SegmentViewModel>>());
            Mock.Mock<ISegmentService>().Verify(x => x.CreateSegment(It.IsAny<Segment>()), Times.Once);
        }

        [Test]
        public async Task PatchConversions_ShouldReturnOk()
        {
            // Arrange
            var id = 1;
            var model = new SegmentConversionPatchViewModel
            {
                Name = "WJsHome",
                Url = "www.google.com",
                AttributionModel = ConversionAttributionModelEnum.LastClick.ToString(),
                PostClickLifetime = 1,
                PostClickLifetimePeriod = PeriodTypeEnum.PerDay.ToString(),
                AttributionCountingMode = ConversionAttributionCountingModeEnum.OncePerLifetime.ToString()
            };

            Mock.Mock<ISegmentService>().Setup(x => x.GetSegment(id))
                .Returns(Task.FromResult(new Segment()));

            // Act
            var retVal = await Controller.PatchConversions(id, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<ISegmentService>().Verify(x => x.UpdateSegment(It.IsAny<Segment>()), Times.Once);
        }

        [Test]
        public async Task PostThirdParties_ShouldReturnOk()
        {
            // Arrange
            var model = new SegmentThirdPartyCreateViewModel
            {
                ParentRtbSegmentId = "prefix:parent",
                RtbSegmentId = "prefix:child",
                Name = "WJsHome",
                Description = "WJsHome Description"
            };

            var segment = new Segment();
            Mock.Mock<ISegmentService>().Setup(x => x.GetSegment(model.ParentRtbSegmentId))
                .Returns(Task.FromResult(segment));
            Mock.Mock<ISegmentService>().Setup(x => x.GetSegment(It.IsAny<int>()))
                .Returns(Task.FromResult(segment));

            // Act
            var retVal = await Controller.PostThirdParties(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<SegmentViewModel>>());
            Mock.Mock<ISegmentService>().Verify(x => x.CreateSegment(It.IsAny<Segment>()), Times.Once);
        }

        [Test]
        public async Task PatchThirdParties_ShouldReturnOk()
        {
            // Arrange
            var id = 1;
            var model = new SegmentThirdPartyPatchViewModel
            {
                Name = "WJsHome"
            };

            Mock.Mock<ISegmentService>().Setup(x => x.GetSegment(id))
                .Returns(Task.FromResult(new Segment()));

            // Act
            var retVal = await Controller.PatchThirdParties(id, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<ISegmentService>().Verify(x => x.UpdateSegment(It.IsAny<Segment>()), Times.Once);
        }

        [Test]
        public async Task Delete_ShouldReturnOk()
        {
            // Arrange
            var segmentId = 1;
            Mock.Mock<ISegmentService>().Setup(x => x.GetSegment(segmentId))
                .Returns(Task.FromResult(new Segment()));

            // Act
            var retVal = await Controller.Delete(segmentId);

            // Assert
            Assert.That(retVal, Is.TypeOf<StatusCodeResult>());
            Assert.That(((StatusCodeResult) retVal).StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Mock.Mock<ISegmentService>().Verify(x => x.DeleteSegment(segmentId), Times.Once);
        }
    }
}
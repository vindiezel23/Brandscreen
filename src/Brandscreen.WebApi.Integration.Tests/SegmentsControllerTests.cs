using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Advertisers;
using Brandscreen.Core.Services.Segments;
using Flurl;
using Flurl.Http;
using NUnit.Framework;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class SegmentsControllerTests : IocSupportedTests
    {
        [Test]
        public async Task Get_ShouldReturnSegmentLists()
        {
            // Arrange 
            var url = HostServer.Url + "api/segments/";
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
            Assert.That(response.PageSize, Is.EqualTo(data.PageSize));
        }

        [Test]
        public async Task Get_ShouldReturnSegmentDetails()
        {
            // Arrange 
            var url = HostServer.Url + "api/segments";
            var segmentService = Container.Resolve<ISegmentService>();
            var segment = segmentService.GetSegments().First();

            // Act
            var response = await url.AppendPathSegment(segment.SegmentId.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.SegmentId, Is.EqualTo(segment.SegmentId));
        }

        [Test]
        public async Task PatchRetargetings_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/segments/remarketings";
            var segmentService = Container.Resolve<ISegmentService>();
            var segment = segmentService.GetSegments().First(x => x.SegmentTypeId == 2);
            var data = new
            {
                Name = "test update"
            };

            // Act
            await url.AppendPathSegment(segment.SegmentId.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .PatchUrlEncodedAsync(data);

            // Assert
            Assert.That(data.Name, Is.EqualTo(segment.SegmentName));
        }

        [Test]
        public async Task PatchConversions_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/segments/remarketings";
            var segmentService = Container.Resolve<ISegmentService>();
            var segment = segmentService.GetSegments().First(x => x.SegmentTypeId == 1);
            var data = new
            {
                Name = "test update"
            };

            // Act
            await url.AppendPathSegment(segment.SegmentId.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .PatchUrlEncodedAsync(data);

            // Assert
            Assert.That(data.Name, Is.EqualTo(segment.SegmentName));
        }

        [Test]
        public async Task PatchThirdParties_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/segments/remarketings";
            var segmentService = Container.Resolve<ISegmentService>();
            var segment = segmentService.GetSegments().First(x => x.SegmentTypeId == 3);
            var data = new
            {
                Name = "test update"
            };

            // Act
            await url.AppendPathSegment(segment.SegmentId.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .PatchUrlEncodedAsync(data);

            // Assert
            Assert.That(data.Name, Is.EqualTo(segment.SegmentName));
        }

        [Test]
        public async Task Delete_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/segments";
            var segmentService = Container.Resolve<ISegmentService>();
            var segment = segmentService.GetSegments().First();

            // Act
            var response = await url.AppendPathSegment(segment.SegmentId.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }


        [Test]
        public async Task PostRetargetings_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/segments/remarketings";
            var advertiserService = Container.Resolve<IAdvertiserService>();
            var advertiser = advertiserService.GetAdvertisers().First();
            var data = new
            {
                AdvertiserUuid = advertiser.AdvertiserUuid.ToString(),
                Name = "Segment Name",
                Url = "http://www.google.com",
                RemarketingRecency = 1
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostUrlEncodedAsync(data).ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.AdvertiserUuid, Is.EqualTo(advertiser.AdvertiserUuid.ToString()));
        }

        [Test]
        public async Task PostConversions_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/segments/conversions";
            var advertiserService = Container.Resolve<IAdvertiserService>();
            var advertiser = advertiserService.GetAdvertisers().First();
            var data = new
            {
                AdvertiserUuid = advertiser.AdvertiserUuid.ToString(),
                Name = "Segment Name",
                Url = "http://www.google.com",
                AttributionModel = 2,
                PostClickLifetime = 1,
                PostClickLifetimePeriod = 1,
                AttributionCountingMode = 1
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostUrlEncodedAsync(data).ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.AdvertiserUuid, Is.EqualTo(advertiser.AdvertiserUuid.ToString()));
        }

        [Test]
        public async Task PostThirdParties_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/segments/thirdparties";
            var userPatchData = new
            {
                Claims = new[]
                {
                    new {Type = StandardClaimType.SegmentThirdPartyPrefix, Value = "bk"},
                    new {Type = StandardClaimType.SegmentThirdPartyParent, Value = "bk:123"}
                }
            };
            var data = new
            {
                ParentRtbSegmentId = "bk",
                RtbSegmentId = "bk:123",
                Name = "Segment Name",
            };
            var response = await $"{HostServer.Url}api/memberships/users?email=jwu@brandscreen.com"
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();
            await $"{HostServer.Url}api/memberships/users/{response.Id}"
                .WithOAuthBearerToken(await TestHelper.Token)
                .PatchJsonAsync(userPatchData);

            // Act
            response = await url.WithOAuthBearerToken(await TestHelper.GetAccessTokenAsync("jwu@brandscreen.com", "abcd1234"))
                .PostUrlEncodedAsync(data).ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.SegmentName, Is.EqualTo(data.Name));
        }
    }
}
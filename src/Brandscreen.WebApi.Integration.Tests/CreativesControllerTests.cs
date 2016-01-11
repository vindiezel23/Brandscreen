using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Autofac;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Brands;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Entities;
using Flurl;
using Flurl.Http;
using NUnit.Framework;
using Repository.Pattern.Repositories;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class CreativesControllerTests : IocSupportedTests
    {
        private async Task<string> PrepareNewDisplayCreative()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var content = new MultipartFormDataContent
            {
                {new StringContent(brand.AdvertiserProductUuid.ToString()), "BrandUuid"},
                {new StringContent("38"), "AdTagTemplateId"}, // mobile
                {new StringContent("en"), "LanguageCode"},
                {new StringContent("https://www.brandscreen.com/"), "ClickUrl"},
                {new ByteArrayContent(File.ReadAllBytes("Data/Creatives/test.png")) {Headers = {ContentType = MediaTypeHeaderValue.Parse("image/png")}}, "File", "test.png"},
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .WithHeader("Accept", "*/*")
                .SendAsync(HttpMethod.Post, content).ReceiveJson();
            return response.CreativeUuid;
        }

        private async Task<string> PrepareNewDoohCreative()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/dooh";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var creativeSizeService = Container.Resolve<ICreativeSizeService>();
            var creativeSize = creativeSizeService.GetDoohCreativeSizes().First(x => x.Width == 1080 && x.Height == 134);
            var content = new MultipartFormDataContent
            {
                {new StringContent(brand.AdvertiserProductUuid.ToString()), "BrandUuid"},
                {new StringContent(creativeSize.CreativeSizeId.ToString()), "CreativeSizeId"},
                {new ByteArrayContent(File.ReadAllBytes("Data/Creatives/dooh.jpg")) {Headers = {ContentType = MediaTypeHeaderValue.Parse("image/jpeg")}}, "File", "dooh.jpg"},
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .WithHeader("Accept", "*/*")
                .SendAsync(HttpMethod.Post, content).ReceiveJson();
            return response.CreativeUuid;
        }


        private async Task<string> PrepareNewDoohVideoCreative()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/dooh/video";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var content = new MultipartFormDataContent
            {
                {new StringContent(brand.AdvertiserProductUuid.ToString()), "BrandUuid"},
                {new StringContent("53"), "CreativeSizeId"},
                {new StringContent("SampleVideo_1080x720_1mb"), "CreativeName"},
                {new ByteArrayContent(File.ReadAllBytes("Data/Creatives/SampleVideo_1080x720_1mb.mp4")) {Headers = {ContentType = MediaTypeHeaderValue.Parse("video/mp4")}}, "File", "SampleVideo_1080x720_1mb.mp4"},
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .WithHeader("Accept", "*/*")
                .SendAsync(HttpMethod.Post, content).ReceiveJson();
            return response.CreativeUuid;
        }


        private async Task<string> PrepareNewDoohVideoUrlCreative()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/dooh/videourl";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var content = new MultipartFormDataContent
            {
                {new StringContent(brand.AdvertiserProductUuid.ToString()), "BrandUuid"},
                {new StringContent("53"), "CreativeSizeId"},
                {new StringContent("SampleVideo_1080x720_1mb"), "CreativeName"},
                {new StringContent("http://www.sample-videos.com/video/mp4/720/big_buck_bunny_720p_1mb.mp4"), "VideoUrl"},
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .WithHeader("Accept", "*/*")
                .SendAsync(HttpMethod.Post, content).ReceiveJson();
            return response.CreativeUuid;
        }

        private async Task<string> PrepareNewVastCreative()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/vast";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var postdata = new
            {
                CreativeName = "vast test",
                BrandUuid = brand.AdvertiserProductUuid.ToString(),
                LanguageCode = "en",
                ClickUrl = "https://www.brandscreen.com/",
                VastUrl = "http://demo.tremorvideo.com/proddev/vast/vast2RegularLinear.xml",
                Direction = "None"
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostUrlEncodedAsync(postdata).ReceiveJson();
            return response.CreativeUuid;
        }

        private async Task<string> PrepareNewAdtagCreative()
        {
            // Arrange 
            var adTag = @"<iframe src=""http://d8.zedo.com/jsc/d8/ff2.html?n=1185;c=2980;s=950;d=13;w=180;h=150;l=[INSERT_CLICK_TRACKER_MACRO]"" frameborder=0 marginheight=0 marginwidth=0 scrolling=""no"" allowTransparency=""true"" width=180 height=150></iframe>";
            var url = HostServer.Url + "api/creatives/adtag";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var postdata = new
            {
                CreativeName = "adtag test",
                BrandUuid = brand.AdvertiserProductUuid.ToString(),
                AdTagTemplateId = 22,
                CreativeSizeId = 9,
                LanguageCode = "en",
                ClickUrl = "https://www.brandscreen.com/",
                Adtag = adTag
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostUrlEncodedAsync(postdata).ReceiveJson();
            return response.CreativeUuid;
        }

        private async Task<string> PrepareNewSwiffyCreative()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/swiffy";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var content = new MultipartFormDataContent
            {
                {new StringContent(brand.AdvertiserProductUuid.ToString()), "BrandUuid"},
                {new StringContent("en"), "LanguageCode"},
                {new StringContent("https://www.brandscreen.com/"), "ClickUrl"},
                {new ByteArrayContent(File.ReadAllBytes("Data/Creatives/swiffy.html")) {Headers = {ContentType = MediaTypeHeaderValue.Parse("text/html")}}, "File", "swiffy.html"},
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .WithHeader("Accept", "*/*")
                .SendAsync(HttpMethod.Post, content).ReceiveJson();
            return response.CreativeUuid;
        }

        private async Task<string> PrepareNewHtml5Creative()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/html5";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var content = new MultipartFormDataContent
            {
                {new StringContent(brand.AdvertiserProductUuid.ToString()), "BrandUuid"},
                {new StringContent("en"), "LanguageCode"},
                {new StringContent("https://www.brandscreen.com/"), "ClickUrl"},
                {new ByteArrayContent(File.ReadAllBytes("Data/Creatives/html5-adobeEdge.zip")) {Headers = {ContentType = MediaTypeHeaderValue.Parse("application/octet-stream")}}, "File", "html5-adobeEdge.zip"},
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .WithHeader("Accept", "*/*")
                .SendAsync(HttpMethod.Post, content).ReceiveJson();
            return response.CreativeUuid;
        }

        [Test]
        public async Task PostDooh_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/dooh";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var creativeSizeService = Container.Resolve<ICreativeSizeService>();
            var creativeSize = creativeSizeService.GetDoohCreativeSizes().First(x => x.Width == 1080 && x.Height == 134);
            var content = new MultipartFormDataContent
            {
                {new StringContent(brand.AdvertiserProductUuid.ToString()), "BrandUuid"},
                {new StringContent(creativeSize.CreativeSizeId.ToString()), "CreativeSizeId"},
                {new ByteArrayContent(File.ReadAllBytes("Data/Creatives/dooh.jpg")) {Headers = {ContentType = MediaTypeHeaderValue.Parse("image/jpeg")}}, "File", "dooh.jpg"},
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .WithHeader("Accept", "*/*")
                .SendAsync(HttpMethod.Post, content).ReceiveJson();

            // Assert
            Assert.That(response.CreativeSize.CreativeSizeId, Is.EqualTo(creativeSize.CreativeSizeId));
            Assert.That(response.CreativeName, Is.EqualTo("dooh.jpg"));
            Assert.That(response.CreativeFile.Height, Is.EqualTo(134));
            Assert.That(response.CreativeFile.Width, Is.EqualTo(1080));
        }

        [Test]
        public async Task PostVast_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/vast";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var postdata = new
            {
                CreativeName = "vast test",
                BrandUuid = brand.AdvertiserProductUuid.ToString(),
                LanguageCode = "en",
                ClickUrl = "https://www.brandscreen.com/",
                VastUrl = "http://demo.tremorvideo.com/proddev/vast/vast2RegularLinear.xml",
                Direction = "None"
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostUrlEncodedAsync(postdata).ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        public async Task PostAdtag_ShouldReturnOk()
        {
            // Arrange 
            var adTag = @"<script language=""JavaScript"">
<!--
var RN = new String (Math.random());
var RNS = RN.substring (2,11);
var oas_jx_sitepage = ""test.brandscreen"";
var oas_jx_pos = ""Top"";
var publisher_click = ""<BS_Click_Token>"";
document.write(""<scr"" + ""ipt language=\""JavaScript\"" src=\""http://b3.mookie1.com/RealMedia/ads/adstream_jx.ads/"" + oas_jx_sitepage + ""/1"" + RNS + ""@"" + oas_jx_pos + ""?"" + publisher_click + ""\""></scr"" + ""ipt>"");
// -->
</script>";
            var url = HostServer.Url + "api/creatives/adtag";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var postdata = new
            {
                CreativeName = "adtag test",
                BrandUuid = brand.AdvertiserProductUuid.ToString(),
                AdTagTemplateId = 52,
                CreativeSizeId = 35,
                LanguageCode = "en",
                ClickUrl = "https://www.brandscreen.com/",
                Adtag = adTag
            };
            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostJsonAsync(postdata).ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        public async Task PostSwiffy_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/swiffy";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var content = new MultipartFormDataContent
            {
                {new StringContent(brand.AdvertiserProductUuid.ToString()), "BrandUuid"},
                {new StringContent("en"), "LanguageCode"},
                {new StringContent("www.brandscreen.com"), "ClickUrl"},
                {new ByteArrayContent(File.ReadAllBytes("Data/Creatives/swiffy.html")) {Headers = {ContentType = MediaTypeHeaderValue.Parse("text/html")}}, "File", "swiffy.html"},
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .WithHeader("Accept", "*/*")
                .SendAsync(HttpMethod.Post, content).ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        public async Task PostDoohVideo_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/dooh/video";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var content = new MultipartFormDataContent
            {
                {new StringContent(brand.AdvertiserProductUuid.ToString()), "BrandUuid"},
                {new StringContent("53"), "CreativeSizeId"},
                {new StringContent("SampleVideo_1080x720_1mb"), "CreativeName"},
                {new ByteArrayContent(File.ReadAllBytes("Data/Creatives/SampleVideo_1080x720_1mb.mp4")) {Headers = {ContentType = MediaTypeHeaderValue.Parse("video/mp4")}}, "File", "SampleVideo_1080x720_1mb.mp4"},
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .WithHeader("Accept", "*/*")
                .SendAsync(HttpMethod.Post, content).ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        public async Task PostDoohVideoUrl_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/dooh/videourl";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var content = new MultipartFormDataContent
            {
                {new StringContent(brand.AdvertiserProductUuid.ToString()), "BrandUuid"},
                {new StringContent("53"), "CreativeSizeId"},
                {new StringContent("SampleVideo_1080x720_1mb"), "CreativeName"},
                {new StringContent("http://www.sample-videos.com/video/mp4/720/big_buck_bunny_720p_1mb.mp4"), "VideoUrl"},
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .WithHeader("Accept", "*/*")
                .SendAsync(HttpMethod.Post, content).ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        public async Task PostHtml5_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/html5";
            var brandService = Container.Resolve<IBrandService>();
            var brand = await brandService.GetBrands().FirstAsync();
            var content = new MultipartFormDataContent
            {
                {new StringContent(brand.AdvertiserProductUuid.ToString()), "BrandUuid"},
                {new StringContent("en"), "LanguageCode"},
                {new StringContent("www.brandscreen.com"), "ClickUrl"},
                {new StringContent("http://bcp.crwdcntrl.net/5/c=6679/b=24542263"), "ImpressionUrl"},
                {new ByteArrayContent(File.ReadAllBytes("Data/Creatives/html5-adobeEdge.zip")) {Headers = {ContentType = MediaTypeHeaderValue.Parse("application/octet-stream")}}, "File", "html5-adobeEdge.zip"},
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .WithHeader("Accept", "*/*")
                .SendAsync(HttpMethod.Post, content).ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        public async Task Get_ShouldReturnListOfCreatives()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
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
        public async Task Get_ShouldReturnCreativeDetails()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
            var creativeService = Container.Resolve<ICreativeService>();
            var creative = await creativeService.GetCreatives().FirstAsync();
            var creativeRepository = Container.Resolve<IRepositoryAsync<Creative>>();
            creative.ClickThroughUrl = "https://www.brandscreen.com/";
            creativeRepository.Update(creative);
            SaveDbChanges();

            // Act
            var response = await url.AppendPathSegment(creative.CreativeUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response.CreativeUuid, Is.EqualTo(creative.CreativeUuid.ToString()));
            Assert.That(response.ClickThroughUrl, Is.EqualTo(creative.ClickThroughUrl));
        }

        [Test]
        public async Task GetReviews_ShouldReturnCreativeReviewList()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
            var creativeService = Container.Resolve<ICreativeService>();
            var creative = creativeService.GetCreatives().First();
            var creativeReviewRepository = Container.Resolve<IRepositoryAsync<CreativeReview>>();
            var creativeReview = creativeReviewRepository.Queryable().First(x => x.CreativeId == creative.CreativeId && x.PartnerId == 0);

            // Act
            var response = await url.AppendPathSegment(creative.CreativeUuid.ToString()).AppendPathSegment("reviews")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync().ReceiveJsonList();

            // Assert
            Assert.That(creativeReview.CreativeId, Is.EqualTo(response[0].CreativeId));
            Assert.That(creativeReview.PartnerId, Is.EqualTo(response[0].PartnerId));
        }

        [Test]
        public async Task PutReview_ShouldReturnOk_WhenInteralReview()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
            var creativeUuid = await PrepareNewDisplayCreative();
            var creativeService = Container.Resolve<ICreativeService>();
            var creative = creativeService.GetCreatives().First(x => x.CreativeUuid.ToString() == creativeUuid);
            var version = creative.UtcModifiedDateTime.ToUnixTimeSeconds();
            var data = new
            {
                CreativeVersion = version,
                Status = "Ready",
            };

            // Act
            await url.AppendPathSegment(creative.CreativeUuid.ToString()).AppendPathSegment("review")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutUrlEncodedAsync(data)
                .ReceiveJson();

            // Assert
            Assert.That(creative.CreativeStatusId, Is.EqualTo(2));
        }

        [Test]
        public async Task PutReview_ShouldReturnOk_WhenExchangeReview()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
            var creativeUuid = await PrepareNewDisplayCreative();
            var creativeService = Container.Resolve<ICreativeService>();
            var creative = creativeService.GetCreatives().First(x => x.CreativeUuid.ToString() == creativeUuid);
            var version = creative.UtcModifiedDateTime.ToUnixTimeSeconds();
            var data = new
            {
                CreativeVersion = version,
                PartnerId = 2,
                Status = "Ready",
            };

            // Act
            await url.AppendPathSegment(creative.CreativeUuid.ToString()).AppendPathSegment("review")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutUrlEncodedAsync(new {CreativeVersion = version, Status = "Approved"})
                .ReceiveJson(); // act internal review first
            await url.AppendPathSegment(creative.CreativeUuid.ToString()).AppendPathSegment("review")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutUrlEncodedAsync(data)
                .ReceiveJson(); // act exchange review second

            // Assert
            var creativeReviewRepository = Container.Resolve<IRepositoryAsync<CreativeReview>>();
            var creativeReview = creativeReviewRepository.Queryable().First(x => x.CreativeId == creative.CreativeId && x.PartnerId == 2);
            Assert.That(creativeReview, Is.Not.Null);
            Assert.That(creative.CreativeStatusId, Is.EqualTo(2));
        }

        [Test]
        public async Task GetParameters_ShouldReturnListOfCreativeParameters()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
            var creativeService = Container.Resolve<ICreativeService>();
            var creative = await creativeService.GetCreatives().FirstAsync();

            // Act
            var response = await url.AppendPathSegment(creative.CreativeUuid.ToString()).AppendPathSegment("parameters")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response.CreativeUuid, Is.EqualTo(creative.CreativeUuid.ToString()));
            Assert.That(response.Data, Is.Not.Null);
        }

        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
            var creativeService = Container.Resolve<ICreativeService>();
            var creative = await creativeService.GetCreatives().FirstAsync();
            var creativeRepository = Container.Resolve<IRepositoryAsync<Creative>>();
            creative.ClickThroughUrl = "https://www.brandscreen.com/";
            creativeRepository.Update(creative);
            SaveDbChanges();
            var data = new
            {
                ClickUrl = "https://www.google.com/",
            };

            // Act
            await url.AppendPathSegment(creative.CreativeUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .PatchUrlEncodedAsync(data);

            // Assert
            Assert.That(creative.ClickThroughUrl, Is.StringContaining("www.google.com"));
        }

        [Test]
        public async Task Delete_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
            var creativeService = Container.Resolve<ICreativeService>();
            var creativeUuid = await PrepareNewDisplayCreative();
            var creative = creativeService.GetCreatives().First(x => x.CreativeUuid.ToString() == creativeUuid);

            // Act
            await url.AppendPathSegment(creative.CreativeUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync();

            // Assert
            Assert.That(creative.IsDeleted, Is.True);
        }

        [Test]
        public async Task DeleteDooh_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
            var creativeService = Container.Resolve<ICreativeService>();
            var creativeUuid = await PrepareNewDoohCreative();
            var creative = creativeService.GetCreatives().First(x => x.CreativeUuid.ToString() == creativeUuid);

            // Act
            await url.AppendPathSegment(creative.CreativeUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync();

            // Assert
            Assert.That(creative.IsDeleted, Is.True);
        }

        [Test]
        public async Task DeleteVast_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
            var creativeService = Container.Resolve<ICreativeService>();
            var creativeUuid = await PrepareNewVastCreative();
            var creative = creativeService.GetCreatives().First(x => x.CreativeUuid.ToString() == creativeUuid);

            // Act
            await url.AppendPathSegment(creative.CreativeUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync();

            // Assert
            Assert.That(creative.IsDeleted, Is.True);
        }

        [Test]
        public async Task DeleteSwiffy_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
            var creativeService = Container.Resolve<ICreativeService>();
            var creativeUuid = await PrepareNewSwiffyCreative();
            var creative = creativeService.GetCreatives().First(x => x.CreativeUuid.ToString() == creativeUuid);

            // Act
            await url.AppendPathSegment(creative.CreativeUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync();

            // Assert
            Assert.That(creative.IsDeleted, Is.True);
        }

        [Test]
        public async Task DeleteAdtag_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
            var creativeService = Container.Resolve<ICreativeService>();
            var creativeUuid = await PrepareNewAdtagCreative();
            var creative = creativeService.GetCreatives().First(x => x.CreativeUuid.ToString() == creativeUuid);

            // Act
            await url.AppendPathSegment(creative.CreativeUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync();

            // Assert
            Assert.That(creative.IsDeleted, Is.True);
        }

        [Test]
        public async Task DeleteHtml5_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
            var creativeService = Container.Resolve<ICreativeService>();
            var creativeUuid = await PrepareNewHtml5Creative();
            var creative = creativeService.GetCreatives().First(x => x.CreativeUuid.ToString() == creativeUuid);

            // Act
            await url.AppendPathSegment(creative.CreativeUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync();

            // Assert
            Assert.That(creative.IsDeleted, Is.True);
        }

        [Test]
        public async Task DeleteDoohVideo_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
            var creativeService = Container.Resolve<ICreativeService>();
            var creativeUuid = await PrepareNewDoohVideoCreative();
            var creative = creativeService.GetCreatives().First(x => x.CreativeUuid.ToString() == creativeUuid);

            // Act
            await url.AppendPathSegment(creative.CreativeUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync();

            // Assert
            Assert.That(creative.IsDeleted, Is.True);
        }

        [Test]
        public async Task DeleteDoohVideoUrl_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/creatives/";
            var creativeService = Container.Resolve<ICreativeService>();
            var creativeUuid = await PrepareNewDoohVideoUrlCreative();
            var creative = creativeService.GetCreatives().First(x => x.CreativeUuid.ToString() == creativeUuid);

            // Act
            await url.AppendPathSegment(creative.CreativeUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync();

            // Assert
            Assert.That(creative.IsDeleted, Is.True);
        }
    }
}
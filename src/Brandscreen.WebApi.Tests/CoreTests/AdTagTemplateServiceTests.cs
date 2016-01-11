using System.IO;
using System.Threading.Tasks;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Entities;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests.CoreTests
{
    [TestFixture]
    public class AdTagTemplateServiceTests : MockingTests
    {
        [Test]
        public async Task Parse_ShouldReturnNull_WhenNoParseRegex()
        {
            // Arrange
            var xml = File.ReadAllText("Data/vast2RegularLinear.xml");
            var adTagTemplates = new[]
            {
                new AdTagTemplate
                {
                    AdTagTemplateId = 69,
                    IsActive = true,
                    AdTagTemplateName = "VAST 2.0",
                    TemplatePath = "3PAS/Vast20.format",
                    ParseRegEx = string.Empty
                }
            };
            MockUnitOfWorkRepository<AdTagTemplate>().Setup(x => x.Queryable()).Returns(adTagTemplates.ToAsyncEnumerable());

            // Act
            var result = await Mock.Create<AdTagTemplateService>().Parse(adTagTemplates[0].AdTagTemplateId, xml);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task Parse_ShouldReturnCreativeParameters()
        {
            // Arrange
            var xml = @"<script type=""text/javascript"" language=""javascript"">
var fd_clk = 'http://adsfac.net/link.asp?cc=BRS066.234148.0';
</script>
<script type=""text/javascript"" language=""javascript"" src=""http://adsfac.net/ag.asp?cc=BRS066.234148.0&source=js&ord=[timestamp]""></script>
<script language=""javascript"" type=""text/javascript"" src=""http://n01d04.cumulus-cloud.com/trackers/tag.php?t=js&cid=1332225659&chid=19833&end""></script>
<noscript>
<a href=""http://adsfac.net/link.asp?cc=BRS066.234148.0"" target=""_blank""><img src=""http://adsfac.net/ag.asp?cc=BRS066.234148.0&bk=1&ord=[timestamp]"" width=""728"" height=""90"" border=""0"" alt=""""></a>
</noscript>";
            var adTagTemplates = new[]
            {
                new AdTagTemplate
                {
                    AdTagTemplateId = 70,
                    IsActive = true,
                    AdTagTemplateName = "Facilitate Javascript DMA",
                    TemplatePath = "Facilitate/JavascriptDma.format",
                    ParseRegEx = @"<script .*<script language=""javascript"" type=""text/javascript"" src=""(?<TRACKER_URL>http://n01d04.cumulus-cloud.com/.*)""></script>.*<img src=""http://adsfac.net/ag.asp\?cc=(?<FL_CC>[^&]+)&bk=(?<FL_BK>[^&]+)&.*"" width=""(?<WIDTH>[\d]+)"" height=""(?<HEIGHT>[\d]+)"""
                }
            };
            MockUnitOfWorkRepository<AdTagTemplate>().Setup(x => x.Queryable()).Returns(adTagTemplates.ToAsyncEnumerable());

            // Act
            var result = await Mock.Create<AdTagTemplateService>().Parse(adTagTemplates[0].AdTagTemplateId, xml);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result.ContainsKey("TRACKER_URL"), Is.True);
            Assert.That(result["TRACKER_URL"], Is.EqualTo("http://n01d04.cumulus-cloud.com/trackers/tag.php?t=js&cid=1332225659&chid=19833&end"));
            Assert.That(result.ContainsKey("FL_CC"), Is.True);
            Assert.That(result["FL_CC"], Is.EqualTo("BRS066.234148.0"));
            Assert.That(result.ContainsKey("FL_BK"), Is.True);
            Assert.That(result["FL_BK"], Is.EqualTo("1"));
            Assert.That(result.ContainsKey("WIDTH"), Is.True);
            Assert.That(result["WIDTH"], Is.EqualTo("728"));
            Assert.That(result.ContainsKey("HEIGHT"), Is.True);
            Assert.That(result["HEIGHT"], Is.EqualTo("90"));
        }
    }
}
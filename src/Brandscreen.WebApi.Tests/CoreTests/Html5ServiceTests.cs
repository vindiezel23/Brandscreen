using System;
using System.IO;
using System.Threading.Tasks;
using Brandscreen.Core.Services.Creatives.Html5;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests.CoreTests
{
    [TestFixture]
    public class Html5ServiceTests : MockingTests
    {
        [Test]
        public async Task Extract()
        {
            // Arrange
            var data = File.ReadAllBytes("Data/html5-adobeEdge.zip");
            var path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            if (Directory.Exists(path)) Directory.Delete(path, true);

            // Act
            var result = await Mock.Create<Html5Service>().Extract(data, path);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.HtmlPath, Is.EqualTo("728x90-set-1.html"));
            Assert.That(result.OtherPaths.Count, Is.EqualTo(3));

            if (Directory.Exists(path)) Directory.Delete(path, true);
        }
    }
}
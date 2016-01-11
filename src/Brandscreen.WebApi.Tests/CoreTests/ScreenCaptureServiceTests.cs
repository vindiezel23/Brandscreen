using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Brandscreen.Core.FileSystems;
using Brandscreen.Core.Services.ScreenCaptures;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests.CoreTests
{
    public class ScreenCaptureServiceTests : MockingTests
    {
        [Test]
        public async Task Capture()
        {
            // Arrange
            var html = File.ReadAllText("Data/swiffy.html");
            Mock.Mock<IAppDataFolderRoot>().SetupGet(x => x.RootFolder).Returns(Path.GetTempPath);

            // Act
            var result = await Mock.Create<ScreenCaptureService>().Capture(html, 160, 600, "png");

            // Assert
            Assert.That(result, Is.Not.Null);

            using (var ms = new MemoryStream(result))
            using (var image = Image.FromStream(ms))
            {
                Assert.That(image.Width, Is.EqualTo(160));
                Assert.That(image.Height, Is.EqualTo(600));
            }
        }
    }
}
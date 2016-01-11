using System.IO;
using System.Threading.Tasks;
using Brandscreen.Core.Services.Creatives.Vast;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests.CoreTests
{
    [TestFixture]
    public class VastServiceTests : MockingTests
    {
        [Test]
        public async Task Validate_ShouldReturnTrue_WhenValidXml()
        {
            // Arrange
            var xml = File.ReadAllText("Data/vast2RegularLinear.xml");

            // Act
            var result = await Mock.Create<VastService>().Validate(xml);

            // Assert
            Assert.That(result.Success, Is.True);
        }

        [Test]
        public async Task Validate_ShouldReturnFalse_WhenInvalidXml()
        {
            // Arrange
            var xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<VAST version=""2.0"">
    <Ad>
    </Ad>
</VAST>";

            // Act
            var result = await Mock.Create<VastService>().Validate(xml);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.Error, Is.EqualTo("The required attribute 'id' is missing."));
        }

        [Test]
        public async Task Deserialize()
        {
            // Arrange
            var xml = File.ReadAllText("Data/vast2RegularLinear.xml");

            // Act
            var vast = await Mock.Create<VastService>().Deserialize(xml);

            // Assert
            Assert.That(vast, Is.Not.Null);
            Assert.That(vast.Ad?[0], Is.Not.Null);
            Assert.That(vast.Ad?[0].id, Is.EqualTo("preroll-1"));
        }
    }
}
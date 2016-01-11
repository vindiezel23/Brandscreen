using System.IO;
using System.Threading.Tasks;
using Brandscreen.Core.Services.Creatives.Swiffy;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests.CoreTests
{
    [TestFixture]
    public class SwiffyParserTests : MockingTests
    {
        [Test]
        public async Task Parse()
        {
            // Arrange
            var html = File.ReadAllText("Data/swiffy.html");

            // Act
            var result = await Mock.Create<SwiffyParser>().Parse(html);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Runtime, Is.EqualTo("https://www.gstatic.com/swiffy/v7.2.0/runtime.js"));
            Assert.That(result.Object, Is.StringStarting("swiffyobject"));
            Assert.That(result.Width, Is.EqualTo(160));
            Assert.That(result.Height, Is.EqualTo(600));
        }
    }
}
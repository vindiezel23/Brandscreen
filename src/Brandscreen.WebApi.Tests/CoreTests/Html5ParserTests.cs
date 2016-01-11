using System.IO;
using System.Threading.Tasks;
using Brandscreen.Core.Services.Creatives.Html5;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests.CoreTests
{
    [TestFixture]
    public class Html5ParserTests : MockingTests
    {
        [Test]
        public async Task Parse()
        {
            // Arrange
            var html = File.ReadAllText("Data/html5-adobeEdge.html");

            // Act
            var result = await Mock.Create<Html5Parser>().Parse(html);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Width, Is.EqualTo(728));
            Assert.That(result.Height, Is.EqualTo(90));
        }
    }
}
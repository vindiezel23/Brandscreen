using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services.Strategies.Targets;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;
using Moq;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class VerticalsControllerTests : ApiControllerMockingTests<VerticalsController>
    {
        [Test]
        public async Task Get_ShouldReturnVerticalList()
        {
            // Arrange
            var model = new VerticalQueryViewModel();
            var vertical = new Vertical {VerticalId = 1};
            var verticals = new List<Vertical> {vertical};

            Mock.Mock<IVerticalService>().Setup(x => x.GetVerticals(It.IsAny<VerticalQueryOptions>())).Returns(verticals.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.Get(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<PagedListViewModel<VerticalListViewModel>>>());
            var content = ((OkNegotiatedContentResult<PagedListViewModel<VerticalListViewModel>>) retVal).Content;
            Assert.That(content.TotalItemCount, Is.EqualTo(1));
            Assert.That(content.Data.ElementAt(0).VerticalId, Is.EqualTo(vertical.VerticalId));
        }
    }
}
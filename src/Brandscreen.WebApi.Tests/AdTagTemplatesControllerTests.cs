using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class AdTagTemplatesControllerTests : ApiControllerMockingTests<AdTagTemplatesController>
    {
        [Test]
        public async Task Get_ShouldReturnAdTagTemplateList()
        {
            // Arrange
            var adTagTemplate = new AdTagTemplate {AdTagTemplateId = 1};
            var adTagTemplates = new List<AdTagTemplate> {adTagTemplate};

            Mock.Mock<IAdTagTemplateService>().Setup(x => x.GetAdTagTemplates()).Returns(adTagTemplates.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.Get(null);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<PagedListViewModel<AdTagTemplateListViewModel>>>());
            var content = ((OkNegotiatedContentResult<PagedListViewModel<AdTagTemplateListViewModel>>) retVal).Content;
            Assert.That(content.TotalItemCount, Is.EqualTo(1));
            Assert.That(content.Data.ElementAt(0).AdTagTemplateId, Is.EqualTo(adTagTemplate.AdTagTemplateId));
        }
    }
}
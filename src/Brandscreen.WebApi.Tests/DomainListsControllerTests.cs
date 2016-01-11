using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services.Strategies.Targets;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class DomainListsControllerTests : ApiControllerMockingTests<DomainListsController>
    {
        [Test]
        public async Task Get_ShouldReturnCampaign_WhenCorrectId()
        {
            // Arrange
            var domainList = new DomainList
            {
                DomainListId = 1,
            };
            var domains = new List<Domain>
            {
                new Domain {DomainName = "www.google.com"},
                new Domain {DomainName = "www.baidu.com"}
            };
            Mock.Mock<IDomainListService>().Setup(x => x.GetDomainList(domainList.DomainListId)).Returns(Task.FromResult(domainList));
            Mock.Mock<IDomainListService>().Setup(x => x.GetDomains(domainList.DomainListId)).Returns(domains.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.Get(domainList.DomainListId, new Pagination());

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<DomainListViewModel>>());
            var content = ((OkNegotiatedContentResult<DomainListViewModel>) retVal).Content;
            Assert.That(content.DomainListId, Is.EqualTo(domainList.DomainListId));
            Assert.That(content.Domains, Is.Not.Null);
            Assert.That(content.Domains.TotalItemCount, Is.EqualTo(2));
        }
    }
}
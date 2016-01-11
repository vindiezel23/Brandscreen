using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services.Partners;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    public class PartnersControllerTests : ApiControllerMockingTests<PartnersController>
    {
        [Test]
        public async Task Get_ShouldReturnPartnerList()
        {
            // Arrange
            var partner = new Partner {PartnerName = "Google"};
            var partners = new List<Partner> {partner};

            Mock.Mock<IPartnerService>().Setup(x => x.GetPartners()).Returns(partners.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.Get(null);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal.TotalItemCount, Is.EqualTo(1));
            Assert.That(retVal.Data.ElementAt(0).PartnerName, Is.EqualTo(partner.PartnerName));
        }
    }
}
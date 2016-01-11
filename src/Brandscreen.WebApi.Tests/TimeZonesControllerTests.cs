using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class TimeZonesControllerTests : ApiControllerMockingTests<TimeZonesController>
    {
        [Test]
        public async Task Get_ShouldReturnLanguageList()
        {
            // Arrange
            var timeZone = new TimeZone
            {
                TimeZoneId = 91,
                TimeZoneName = "(GMT-12:00) International Date Line West",
                TimeZoneCode = "Dateline Standard Time",
                GmtOffset = "GMT-12:00"
            };
            var timeZones = new List<TimeZone> {timeZone};

            Mock.Mock<ITimeZoneService>().Setup(x => x.GeTimeZones()).Returns(timeZones.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.Get(null);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<PagedListViewModel<TimeZoneListViewModel>>>());
            var content = ((OkNegotiatedContentResult<PagedListViewModel<TimeZoneListViewModel>>) retVal).Content;
            Assert.That(content.TotalItemCount, Is.EqualTo(1));
            Assert.That(content.Data.ElementAt(0).TimeZoneId, Is.EqualTo(timeZone.TimeZoneId));
        }
    }
}
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
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class DevicesControllerTests : ApiControllerMockingTests<DevicesController>
    {
        [Test]
        public async Task Get_ShouldReturnLanguageList()
        {
            // Arrange
            var device = new Device {DeviceId = 1, DeviceName = "Mobile :: Apple iOS :: iPad :: Unknown Browser"};
            var devices = new List<Device> {device};

            Mock.Mock<IDeviceService>().Setup(x => x.GetDevices()).Returns(devices.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.Get(null);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<PagedListViewModel<DeviceListViewModel>>>());
            var content = ((OkNegotiatedContentResult<PagedListViewModel<DeviceListViewModel>>) retVal).Content;
            Assert.That(content.TotalItemCount, Is.EqualTo(1));
            Assert.That(content.Data.ElementAt(0).DeviceId, Is.EqualTo(device.DeviceId));
        }
    }
}
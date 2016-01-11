using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Core.Services.Placements;
using Brandscreen.Core.Services.Strategies;
using Flurl;
using Flurl.Http;
using NUnit.Framework;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class PlacementControllerTests : IocSupportedTests
    {
        [Test]
        public async Task Put_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/placements";
            var creativeService = Container.Resolve<ICreativeService>();
            var creative = creativeService.GetCreatives().First();
            var strategyService = Container.Resolve<IStrategyService>();
            var strategy = strategyService.GetStrategies().First();
            var data = new
            {
                StrategyUuid = strategy.AdGroupUuid.ToString(),
                CreativeUuid = creative.CreativeUuid.ToString(),
                IsLinking = true,
            };

            // Act
            await url.WithOAuthBearerToken(await TestHelper.Token)
                .PutUrlEncodedAsync(data);

            // Assert
            var placementService = Container.Resolve<IPlacementService>();
            var placement = placementService.GetPlacements().First(x => x.AdGroupId == strategy.AdGroupId && x.CreativeId == creative.CreativeId);
            Assert.That(placement, Is.Not.Null);
        }


        [Test]
        public async Task Get_ShouldReturnPlacementDetails()
        {
            // Arrange 
            var url = HostServer.Url + "api/placements";
            var placementService = Container.Resolve<IPlacementService>();
            var placement = placementService.GetPlacements().First();

            // Act
            var response = await url.AppendPathSegment(placement.PlacementUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.PlacementId, Is.EqualTo(placement.PlacementId));
            Assert.That(response.PlacementStatusId, Is.EqualTo(placement.PlacementStatusId));
        }

        [Test]
        public async Task Get_ShouldReturnPlacementLists()
        {
            // Arrange 
            var url = HostServer.Url + "api/placements/";
            var data = new
            {
                PageNumber = 2,
                PageSize = 5
            };

            // Act
            var response = await url.SetQueryParams(data)
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.PageNumber, Is.EqualTo(data.PageNumber));
            Assert.That(response.PageSize, Is.EqualTo(data.PageSize));
        }
    }
}
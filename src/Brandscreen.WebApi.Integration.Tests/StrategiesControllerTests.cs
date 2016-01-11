using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using Brandscreen.Core.Services.Campaigns;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Entities;
using Flurl;
using Flurl.Http;
using NUnit.Framework;
using Repository.Pattern.Repositories;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class StrategiesControllerTests : IocSupportedTests
    {
        private async Task<string> PrepareNewStrategy()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var brandService = Container.Resolve<ICampaignService>();
            var brand = await brandService.GetCampaigns().FirstAsync();
            var data = new
            {
                CampaignUuid = brand.CampaignUuid.ToString(),
                StrategyName = "test strategy",
                SupplySource = "PublicMarket",
                MediaType = "Display",
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostJsonAsync(data).ReceiveJson();
            return response.StrategyUuid;
        }

        [Test]
        public async void Get_ShouldReturnStrategyList()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyService = Container.Resolve<IStrategyService>();
            var totalItemCount = strategyService.GetStrategies().Count(x => x.BuyerAccountId == 2);

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.TotalItemCount, Is.EqualTo(totalItemCount));
            Assert.That(response.Data, Is.Not.Null);
            for (var i = 0; i < response.Data.Count; i++)
            {
                Assert.That(response.Data[i].CampaignUuid, Is.InstanceOf<string>());
                Assert.That(response.Data[i].StrategyUuid, Is.InstanceOf<string>());
            }
        }

        [Test]
        public async void Get_ShouldReturnAllDoohStrategyList_WhenWithMediaTypeOption()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyService = Container.Resolve<IStrategyService>();
            var totalItemCount = strategyService.GetStrategies().Count(x => x.MediaTypeId == (int) MediaTypeEnum.Dooh);
            var data = new
            {
                UserId = "",
                MediaType = "Dooh"
            };

            // Act
            var response = await url.SetQueryParams(data)
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.TotalItemCount, Is.EqualTo(totalItemCount));
            Assert.That(response.Data, Is.Not.Null);
            for (var i = 0; i < response.Data.Count; i++)
            {
                Assert.That(response.Data[i].CampaignUuid, Is.InstanceOf<string>());
                Assert.That(response.Data[i].StrategyUuid, Is.InstanceOf<string>());
                Assert.That(response.Data[i].MediaType, Is.EqualTo("Dooh"));
            }
        }

        [Test]
        public async void Get_ShouldReturnUnauthorized_WhenWithNonSuperAdminAccount()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var data = new
            {
                UserId = "",
                MediaType = "Dooh"
            };

            // Act
            var response = await url.SetQueryParams(data)
                .WithOAuthBearerToken(await TestHelper.UserToken)
                .AllowAnyHttpStatus()
                .GetAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [Test]
        public async void Get_ShouldReturnStrategy_WhenCorrectId()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyService = Container.Resolve<IStrategyService>();
            var strategy = strategyService.GetStrategies().First();
            strategy.AdGroupName = "AdGroupNameTest";
            var repository = Container.Resolve<IRepositoryAsync<AdGroup>>();
            repository.Update(strategy);
            SaveDbChanges();

            // Act
            var response = await url.AppendPathSegment(strategy.AdGroupUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.StrategyName, Is.EqualTo("AdGroupNameTest"));
            Assert.That(response.StrategyUuid, Is.EqualTo(strategy.AdGroupUuid.ToString()));
        }

        [Test]
        public async void Get_ShouldReturnError_WhenInCorrectId()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var incorrectUuid = Guid.NewGuid().ToString();

            // Act
            var response = await url.AppendPathSegment(incorrectUuid)
                .WithOAuthBearerToken(await TestHelper.Token)
                .AllowHttpStatus("404")
                .GetAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async void Patch_ShouldReturnOk()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyService = Container.Resolve<IStrategyService>();
            var strategy = strategyService.GetStrategies().First();
            var data = new
            {
                StrategyName = "test strategy name"
            };

            // Act
            await url.AppendPathSegment(strategy.AdGroupUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .PatchUrlEncodedAsync(data)
                .ReceiveJson();

            // Assert
            Assert.That(strategy.AdGroupName, Is.EqualTo(data.StrategyName));
        }


        [Test]
        public async void Post_ShouldReturnOk()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var brandService = Container.Resolve<ICampaignService>();
            var brand = await brandService.GetCampaigns().FirstAsync();
            var data = new
            {
                CampaignUuid = brand.CampaignUuid.ToString(),
                StrategyName = "test strategy",
                SupplySource = "PublicMarket",
                MediaType = "Display",
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostJsonAsync(data).ReceiveJson();

            // Assert
            Assert.That(response.StrategyName, Is.EqualTo(data.StrategyName));
            Assert.That(response.SupplySource, Is.EqualTo(data.SupplySource));
            Assert.That(response.MediaType, Is.EqualTo(data.MediaType));
        }

        [Test]
        public async void GetTargetings_ShouldReturnStrategyTargeting_WhenCorrectId()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyService = Container.Resolve<IStrategyService>();
            var strategy = strategyService.GetStrategies().First();

            // Act
            var response = await url.AppendPathSegment(strategy.AdGroupUuid.ToString()).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Empty);
            Assert.That(response.StrategyUuid, Is.EqualTo(strategy.AdGroupUuid.ToString()));
            Assert.That(response.Timestamp, Is.Not.Null);
        }

        [Test]
        public async void PutTargetingDoohGeoLocations_ShouldReturnOK()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyService = Container.Resolve<IStrategyService>();
            var strategy = strategyService.GetStrategies().First();
            var data = new
            {
                Targetings = new[]
                {
                    new
                    {
                        Id = 1,
                        TargetingAction = 1
                    }
                }
            };

            // Act
            await url.AppendPathSegment(strategy.AdGroupUuid.ToString()).AppendPathSegment("targetings/locations")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutJsonAsync(data)
                .ReceiveJson();
            var response = await url.AppendPathSegment(strategy.AdGroupUuid.ToString()).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.DoohGeoLocationGroups, Is.Not.Null);
            var doohGeoLocationGroups = (List<dynamic>) response.DoohGeoLocationGroups;
            Assert.That(doohGeoLocationGroups.Count(x => x.DoohGeoLocationGroupId == 1), Is.EqualTo(1));
        }

        [Test]
        public async void PutTargetingCountries_ShouldReturnOK()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyService = Container.Resolve<IStrategyService>();
            var strategy = strategyService.GetStrategies().First();
            var data = new
            {
                Targetings = new[]
                {
                    new
                    {
                        Id = 4,
                        TargetingAction = 2
                    }
                }
            };

            // Act
            await url.AppendPathSegment(strategy.AdGroupUuid.ToString()).AppendPathSegment("targetings/countries")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutJsonAsync(data)
                .ReceiveJson();
            var response = await url.AppendPathSegment(strategy.AdGroupUuid.ToString()).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.GeoLocations, Is.Not.Null);
            var geoLocations = (List<dynamic>) response.GeoLocations;
            Assert.That(geoLocations.Count(x => x.GeoLocationId == 1201702060), Is.EqualTo(1));
        }

        [Test]
        public async void PutTargetingRegions_ShouldReturnOK()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyService = Container.Resolve<IStrategyService>();
            var strategy = strategyService.GetStrategies().First();
            var data = new
            {
                Targetings = new[]
                {
                    new
                    {
                        Id = 1,
                        TargetingAction = 2
                    }
                }
            };

            // Act
            await url.AppendPathSegment(strategy.AdGroupUuid.ToString()).AppendPathSegment("targetings/regions")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutJsonAsync(data)
                .ReceiveJson();
            var response = await url.AppendPathSegment(strategy.AdGroupUuid.ToString()).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.GeoLocations, Is.Not.Null);
            var geoLocations = (List<dynamic>) response.GeoLocations;
            Assert.That(geoLocations.Count(x => x.GeoLocationId == 1257875848), Is.EqualTo(1));
        }

        [Test]
        public async void PutTargetingCities_ShouldReturnOK()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyService = Container.Resolve<IStrategyService>();
            var strategy = strategyService.GetStrategies().First();

            var data = new
            {
                Targetings = new[]
                {
                    new
                    {
                        Id = 3,
                        TargetingAction = 2
                    }
                }
            };

            // Act
            await url.AppendPathSegment(strategy.AdGroupUuid.ToString()).AppendPathSegment("targetings/cities")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutJsonAsync(data)
                .ReceiveJson();
            var response = await url.AppendPathSegment(strategy.AdGroupUuid.ToString()).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.GeoLocations, Is.Not.Null);
            var geoLocations = (List<dynamic>) response.GeoLocations;
            Assert.That(geoLocations.Count(x => x.GeoLocationId == 954574091), Is.EqualTo(1));
        }

        [Test]
        public async void PutTargetingPostcodes_ShouldReturnOK()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyService = Container.Resolve<IStrategyService>();
            var strategy = strategyService.GetStrategies().First();
            var data = new
            {
                Targetings = new[]
                {
                    new
                    {
                        Id = new
                        {
                            GeoCountryId = 36,
                            Postcode = "2134"
                        },
                        TargetingAction = 2
                    }
                }
            };

            // Act
            await url.AppendPathSegment(strategy.AdGroupUuid.ToString()).AppendPathSegment("targetings/postcodes")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutJsonAsync(data)
                .ReceiveJson();
            var response = await url.AppendPathSegment(strategy.AdGroupUuid.ToString()).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.GeoPostcodes, Is.Not.Null);
            var geoPostcodes = (List<dynamic>) response.GeoPostcodes;
            Assert.That(geoPostcodes.Count(x => x.GeoCountryId == 36 && x.Postcode == "2134"), Is.EqualTo(1));
        }

        [Test]
        public async void PutTargetingLanguages_ShouldReturnOK()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyService = Container.Resolve<IStrategyService>();
            var strategy = strategyService.GetStrategies().First();
            var data = new
            {
                Targetings = new[]
                {
                    new
                    {
                        Id = 239,
                        TargetingAction = 1,
                    }
                }
            };

            // Act
            await url.AppendPathSegment(strategy.AdGroupUuid.ToString()).AppendPathSegment("targetings/languages")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutJsonAsync(data)
                .ReceiveJson();
            var response = await url.AppendPathSegment(strategy.AdGroupUuid.ToString()).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Languages, Is.Not.Null);
            var languages = (List<dynamic>) response.Languages;
            Assert.That(languages.Count(x => x.LanguageId == 239), Is.EqualTo(1));
        }

        [Test]
        public async void PutTargetingVerticals_ShouldReturnOK()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyUuid = await PrepareNewStrategy();
            var data = new
            {
                Targetings = new[]
                {
                    new
                    {
                        Id = 3960,
                        TargetingAction = 2,
                    }
                }
            };

            // Act
            await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings/verticals")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutJsonAsync(data)
                .ReceiveJson();
            var response = await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Verticals, Is.Not.Null);
            var verticals = (List<dynamic>) response.Verticals;
            Assert.That(verticals.Count(x => x.VerticalId == 3960), Is.EqualTo(1));
        }

        [Test]
        public async void PutTargetingSegments_ShouldReturnOK()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyUuid = await PrepareNewStrategy();
            var data = new
            {
                Targetings = new[]
                {
                    new
                    {
                        Id = 2,
                        TargetingAction = 2,
                    }
                }
            };

            // Act
            await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings/segments")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutJsonAsync(data)
                .ReceiveJson();
            var response = await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Segments, Is.Not.Null);
            var segments = (List<dynamic>) response.Segments;
            Assert.That(segments.Count(x => x.SegmentId == 2), Is.EqualTo(1));
        }

        [Test]
        public async void PutTargetingDomainLists_ShouldReturnOK()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyUuid = await PrepareNewStrategy();
            var data = new
            {
                Targetings = new[]
                {
                    new
                    {
                        Id = 1,
                        TargetingAction = 2,
                    }
                }
            };

            // Act
            await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings/domainlists")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutJsonAsync(data)
                .ReceiveJson();
            var response = await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.DomainLists, Is.Not.Null);
            var domainLists = (List<dynamic>) response.DomainLists;
            Assert.That(domainLists.Count(x => x.DomainListId == 1), Is.EqualTo(1));
        }

        [Test]
        public async void PutTargetingPartners_ShouldReturnOK()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyUuid = await PrepareNewStrategy();
            var data = new
            {
                Targetings = new[]
                {
                    new
                    {
                        Id = 1,
                        TargetingAction = 2,
                    }
                }
            };

            // Act
            await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings/partners")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutJsonAsync(data)
                .ReceiveJson();
            var response = await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.SupplySources, Is.Not.Null);
            var supplySources = (List<dynamic>) response.SupplySources;
            Assert.That(supplySources.Count(x => x.PartnerId == 1), Is.EqualTo(1));
        }

        [Test]
        public async void PutTargetingPublishers_ShouldReturnOK()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyUuid = await PrepareNewStrategy();
            var data = new
            {
                Targetings = new[]
                {
                    new
                    {
                        Id = 1,
                        TargetingAction = 2,
                    }
                }
            };

            // Act
            await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings/publishers")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutJsonAsync(data)
                .ReceiveJson();
            var response = await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.SupplySources, Is.Not.Null);
            var supplySources = (List<dynamic>) response.SupplySources;
            Assert.That(supplySources.Count(x => x.PublisherId == 1), Is.EqualTo(1));
        }

        [Test]
        public async void PutTargetingDevices_ShouldReturnOK()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyUuid = await PrepareNewStrategy();
            var data = new
            {
                Targetings = new[]
                {
                    new
                    {
                        Id = 1,
                        TargetingAction = 1,
                    }
                }
            };

            // Act
            await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings/devices")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutJsonAsync(data)
                .ReceiveJson();
            var response = await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Devices, Is.Not.Null);
            var devices = (List<dynamic>) response.Devices;
            Assert.That(devices.Count(x => x.DeviceId == 1), Is.EqualTo(1));
        }

        [Test]
        public async void PutTargetingMobileCarriers_ShouldReturnOK()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyUuid = await PrepareNewStrategy();
            var data = new
            {
                Targetings = new[]
                {
                    new
                    {
                        Id = new
                        {
                            GeoCountryId = 8,
                            Mcc = 276,
                            Mnc = 2
                        },
                        TargetingAction = 1,
                    }
                }
            };

            // Act
            await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings/mobilecarriers")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutJsonAsync(data)
                .ReceiveJson();
            var response = await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.MobileCarriers, Is.Not.Null);
            var mobilecarriers = (List<dynamic>) response.MobileCarriers;
            Assert.That(mobilecarriers.Count(x => x.GeoCountryId == 8), Is.EqualTo(1));
        }

        [Test]
        public async void PutTargetingDayParts_ShouldReturnOK()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyUuid = await PrepareNewStrategy();
            var data = new
            {
                Targetings = new[]
                {
                    new
                    {
                        Id = 100,
                        TargetingAction = 1,
                    }
                }
            };

            // Act
            await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings/dayparts")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutJsonAsync(data)
                .ReceiveJson();
            var response = await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.DayParts, Is.Not.Null);
            var dayparts = (List<dynamic>) response.DayParts;
            Assert.That(dayparts.Count(x => x.DayPartId == 100), Is.EqualTo(1));
        }

        [Test]
        public async void PutTargetingPagePositions_ShouldReturnOK()
        {
            // Arrange
            var url = HostServer.Url + "api/strategies";
            var strategyUuid = await PrepareNewStrategy();
            var data = new
            {
                Targetings = new[]
                {
                    new
                    {
                        Id = 1,
                        TargetingAction = 1,
                    }
                }
            };

            // Act
            await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings/pagepositions")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutJsonAsync(data)
                .ReceiveJson();
            var response = await url.AppendPathSegment(strategyUuid).AppendPathSegment("targetings")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.PagePositions, Is.Not.Null);
            var pagepositions = (List<dynamic>) response.PagePositions;
            Assert.That(pagepositions.Count(x => x.PagePositionId == 1), Is.EqualTo(1));
        }
    }
}
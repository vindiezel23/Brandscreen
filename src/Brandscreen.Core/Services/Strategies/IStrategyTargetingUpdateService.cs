using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Brandscreen.Core.Services.Dooh;
using Brandscreen.Core.Services.Publishers;
using Brandscreen.Core.Services.Strategies.Targets;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services.Strategies
{
    public interface IStrategyTargetingUpdateService : IDependency
    {
        Task SetCountries(StrategyTargetingUpdateOptions<int> options);
        Task SetRegions(StrategyTargetingUpdateOptions<int> options);
        Task SetCities(StrategyTargetingUpdateOptions<int> options);
        Task SetPostcodes(StrategyTargetingUpdateOptions<StrategyTargetingGeoPostcode> options);
        Task SetDoohGeoLocationGroups(StrategyTargetingUpdateOptions<int> options);
        Task SetLanguages(StrategyTargetingUpdateOptions<int> options);
        Task SetVerticals(StrategyTargetingUpdateOptions<int> options);
        Task SetPartners(StrategyTargetingUpdateOptions<int> options);
        Task SetDoohPanelLocations(StrategyTargetingUpdateOptions<int> options);
        Task SetPublishers(StrategyTargetingUpdateOptions<int> options);
        Task SetDomainLists(StrategyTargetingUpdateOptions<int> options);
        Task SetSegments(StrategyTargetingUpdateOptions<int> options);
        Task SetDevices(StrategyTargetingUpdateOptions<int> options);
        Task SetMobileCarriers(StrategyTargetingUpdateOptions<StrategyTargetingMobileCarrier> options);
        Task SetDayParts(StrategyTargetingUpdateOptions<int> options);
        Task SetPagePositions(StrategyTargetingUpdateOptions<int> options);
    }

    public class StrategyTargetingUpdateService : IStrategyTargetingUpdateService
    {
        private readonly IRepositoryAsync<AdGroup> _adGroupRepositoryAsync;
        private readonly IBrandscreenContext _brandscreenContext;
        private readonly ILifetimeScope _container;

        public StrategyTargetingUpdateService(IRepositoryAsync<AdGroup> adGroupRepositoryAsync, IBrandscreenContext brandscreenContext, ILifetimeScope container)
        {
            _adGroupRepositoryAsync = adGroupRepositoryAsync;
            _brandscreenContext = brandscreenContext;
            _container = container;
        }

        public async Task SetCountries(StrategyTargetingUpdateOptions<int> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupGeoLocations)
                .Include(x => x.AdGroupGeoLocations.Select(y => y.GeoLocation))
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupGeoLocations.Where(x => x.GeoLocation != null && options.Targetings.Select(y => y.Id).Contains(x.GeoLocation.GeoCountryId)).ToArray();
            foreach (var adGroupGeoLocation in itemsToRemove)
            {
                adGroupGeoLocation.ObjectState = ObjectState.Deleted;
                strategy.AdGroupGeoLocations.Remove(adGroupGeoLocation);
            }

            // update
            var ids = options.Targetings.Where(x => x.TargetingAction != (TargetingActionEnum) strategy.CountryTargetingMode).Select(x => x.Id).ToArray();
            if (ids.Length > 0)
            {
                // modify or add
                var geoLocations = await _container.Resolve<IGeoLocationService>().GetGeoLocationsByGeoCountryIds(ids).ToListAsync();
                foreach (var geoLocation in geoLocations)
                {
                    var adGroupGeoLocation = itemsToRemove.FirstOrDefault(x => x.GeoLocationId == geoLocation.GeoLocationId);
                    if (adGroupGeoLocation != null)
                    {
                        // using existing record to modify
                        adGroupGeoLocation.ObjectState = ObjectState.Modified;
                    }
                    else
                    {
                        adGroupGeoLocation = new AdGroupGeoLocation
                        {
                            ObjectState = ObjectState.Added,
                            AdGroupId = strategy.AdGroupId,
                            GeoLocationId = geoLocation.GeoLocationId,
                        };
                    }
                    adGroupGeoLocation.TargetingActionId = (int) options.Targetings.Single(x => x.Id == geoLocation.GeoCountryId).TargetingAction; // new targeting action
                    strategy.AdGroupGeoLocations.Add(adGroupGeoLocation);
                }
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task SetRegions(StrategyTargetingUpdateOptions<int> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupGeoLocations)
                .Include(x => x.AdGroupGeoLocations.Select(y => y.GeoLocation))
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupGeoLocations.Where(x => x.GeoLocation?.GeoRegionId != null && options.Targetings.Select(y => y.Id).Contains(x.GeoLocation.GeoRegionId.Value)).ToArray();
            foreach (var adGroupGeoLocation in itemsToRemove)
            {
                adGroupGeoLocation.ObjectState = ObjectState.Deleted;
                strategy.AdGroupGeoLocations.Remove(adGroupGeoLocation);
            }

            // update
            var ids = options.Targetings.Select(x => x.Id).ToArray();
            var geoLocations = await _container.Resolve<IGeoLocationService>().GetGeoLocationsByGeoRegionIds(ids).ToListAsync();
            foreach (var geoLocation in geoLocations)
            {
                // parent
                var defaultTargetingAction = strategy.AdGroupGeoLocations.Where(x => x.GeoLocation != null && x.GeoLocation.GeoCountryId == geoLocation.GeoCountryId && x.GeoLocation.GeoRegionId == null && x.GeoLocation.GeoCityId == null && x.GeoLocation.GeoMetroId == null)
                    .Select(x => x.TargetingActionId) // parent country
                    .Union(new[] {strategy.RegionTargetingMode}) // fallback to default region targeting mode
                    .Cast<TargetingActionEnum>()
                    .First();

                // skip: if the same as default targeting
                var geoRegionId = geoLocation.GeoRegionId.GetValueOrDefault(0);
                var target = options.Targetings.Single(y => y.Id == geoRegionId);
                if (target.TargetingAction == defaultTargetingAction) continue;

                // modify or add
                var adGroupGeoLocation = itemsToRemove.FirstOrDefault(x => x.GeoLocationId == geoLocation.GeoLocationId);
                if (adGroupGeoLocation != null)
                {
                    // using existing record to modify
                    adGroupGeoLocation.ObjectState = ObjectState.Modified;
                }
                else
                {
                    adGroupGeoLocation = new AdGroupGeoLocation
                    {
                        ObjectState = ObjectState.Added,
                        AdGroupId = strategy.AdGroupId,
                        GeoLocationId = geoLocation.GeoLocationId,
                    };
                }
                adGroupGeoLocation.TargetingActionId = (int) target.TargetingAction; // new targeting action
                strategy.AdGroupGeoLocations.Add(adGroupGeoLocation);
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task SetCities(StrategyTargetingUpdateOptions<int> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupGeoLocations)
                .Include(x => x.AdGroupGeoLocations.Select(y => y.GeoLocation))
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupGeoLocations.Where(x => x.GeoLocation?.GeoCityId != null && options.Targetings.Select(y => y.Id).Contains(x.GeoLocation.GeoCityId.Value)).ToArray();
            foreach (var adGroupGeoLocation in itemsToRemove)
            {
                adGroupGeoLocation.ObjectState = ObjectState.Deleted;
                strategy.AdGroupGeoLocations.Remove(adGroupGeoLocation);
            }

            // update
            var ids = options.Targetings.Select(x => x.Id).ToArray();
            var geoLocations = await _container.Resolve<IGeoLocationService>().GetGeoLocationsByGeoCityIds(ids).ToListAsync();
            foreach (var geoLocation in geoLocations)
            {
                // parent
                var defaultTargetingAction = strategy.AdGroupGeoLocations.Where(x => x.GeoLocation != null && x.GeoLocation.GeoRegionId == geoLocation.GeoRegionId && x.GeoLocation.GeoCityId == null && x.GeoLocation.GeoMetroId == null)
                    .Select(x => x.TargetingActionId) // parent region
                    .Union(strategy.AdGroupGeoLocations.Where(x => x.GeoLocation != null && x.GeoLocation.GeoCountryId == geoLocation.GeoCountryId && x.GeoLocation.GeoRegionId == null && x.GeoLocation.GeoCityId == null && x.GeoLocation.GeoMetroId == null)
                        .Select(x => x.TargetingActionId)) // parent country
                    .Union(new[] {strategy.CityTargetingMode}) // fallback to default city targeting mode
                    .Cast<TargetingActionEnum>()
                    .First();

                // skip: if the same as default targeting
                var geoCityId = geoLocation.GeoCityId.GetValueOrDefault(0);
                var target = options.Targetings.Single(y => y.Id == geoCityId);
                if (target.TargetingAction == defaultTargetingAction) continue;

                // modify or add
                var adGroupGeoLocation = itemsToRemove.FirstOrDefault(x => x.GeoLocationId == geoLocation.GeoLocationId);
                if (adGroupGeoLocation != null)
                {
                    // using existing record to modify
                    adGroupGeoLocation.ObjectState = ObjectState.Modified;
                }
                else
                {
                    adGroupGeoLocation = new AdGroupGeoLocation
                    {
                        ObjectState = ObjectState.Added,
                        AdGroupId = strategy.AdGroupId,
                        GeoLocationId = geoLocation.GeoLocationId,
                    };
                }
                adGroupGeoLocation.TargetingActionId = (int) target.TargetingAction; // new targeting action
                strategy.AdGroupGeoLocations.Add(adGroupGeoLocation);
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task SetPostcodes(StrategyTargetingUpdateOptions<StrategyTargetingGeoPostcode> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupGeoPostcodes)
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupGeoPostcodes.Where(x => options.Targetings.Any(y => x.GeoCountryId == y.Id.GeoCountryId && x.Postcode == y.Id.Postcode)).ToArray();
            foreach (var adGroupGeoPostcode in itemsToRemove)
            {
                adGroupGeoPostcode.ObjectState = ObjectState.Deleted;
                strategy.AdGroupGeoPostcodes.Remove(adGroupGeoPostcode);
            }

            // update
            foreach (var strategyTargetingItem in options.Targetings.Where(x => x.TargetingAction == TargetingActionEnum.Targeting || x.TargetingAction == TargetingActionEnum.Avoiding))
            {
                var adGroupGeoPostcode = itemsToRemove.FirstOrDefault(x => x.GeoCountryId == strategyTargetingItem.Id.GeoCountryId && x.Postcode == strategyTargetingItem.Id.Postcode);
                if (adGroupGeoPostcode != null)
                {
                    // using existing record to modify
                    adGroupGeoPostcode.ObjectState = ObjectState.Modified;
                }
                else
                {
                    adGroupGeoPostcode = new AdGroupGeoPostcode
                    {
                        ObjectState = ObjectState.Added,
                        AdGroupId = strategy.AdGroupId,
                        GeoCountryId = strategyTargetingItem.Id.GeoCountryId,
                        Postcode = strategyTargetingItem.Id.Postcode
                    };
                }
                adGroupGeoPostcode.TargetingActionId = (int) strategyTargetingItem.TargetingAction; // new targeting action
                strategy.AdGroupGeoPostcodes.Add(adGroupGeoPostcode);
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task SetDoohGeoLocationGroups(StrategyTargetingUpdateOptions<int> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupGeoLocations)
                .Include(x => x.AdGroupDoohGeoLocationGroups)
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupDoohGeoLocationGroups.Where(x => options.Targetings.Select(y => y.Id).Contains(x.DoohGeoLocationGroupId)).ToArray();
            foreach (var adGroupDoohGeoLocationGroup in itemsToRemove)
            {
                adGroupDoohGeoLocationGroup.ObjectState = ObjectState.Deleted;
                strategy.AdGroupDoohGeoLocationGroups.Remove(adGroupDoohGeoLocationGroup);
            }

            // udpate
            var ids = options.Targetings.Select(x => x.Id).ToArray();
            var doohGeoLocationGroups = await _container.Resolve<IDoohService>().GetDoohGeoLocationGroupsByIds(ids).ToListAsync();
            foreach (var doohGeoLocationGroup in doohGeoLocationGroups)
            {
                // parent
                var defaultTargetingAction = strategy.AdGroupGeoLocations.Where(x => x.GeoLocation != null && x.GeoLocation.GeoRegionId == doohGeoLocationGroup.GeoRegionId && x.GeoLocation.GeoCityId == null && x.GeoLocation.GeoMetroId == null)
                    .Select(x => x.TargetingActionId) // parent region
                    .Union(strategy.AdGroupGeoLocations.Where(x => x.GeoLocation != null && x.GeoLocation.GeoCountryId == doohGeoLocationGroup.GeoCountryId && x.GeoLocation.GeoRegionId == null && x.GeoLocation.GeoCityId == null && x.GeoLocation.GeoMetroId == null)
                        .Select(x => x.TargetingActionId)) // parent country
                    .Union(new[] {strategy.DoohGeoLocationGroupTargetingMode}) // fallback to default dooh geo location targeting mode
                    .Cast<TargetingActionEnum>()
                    .First();

                // skip: if the same as default targeting
                var target = options.Targetings.Single(x => x.Id == doohGeoLocationGroup.DoohGeoLocationGroupId);
                if (target.TargetingAction == defaultTargetingAction) continue;

                // modify or add
                var adGroupDoohGeoLocationGroup = itemsToRemove.FirstOrDefault(x => x.DoohGeoLocationGroupId == doohGeoLocationGroup.DoohGeoLocationGroupId);
                if (adGroupDoohGeoLocationGroup != null)
                {
                    // using existing record to modify
                    adGroupDoohGeoLocationGroup.ObjectState = ObjectState.Modified;
                }
                else
                {
                    adGroupDoohGeoLocationGroup = new AdGroupDoohGeoLocationGroup
                    {
                        ObjectState = ObjectState.Added,
                        AdGroupId = strategy.AdGroupId,
                        DoohGeoLocationGroupId = doohGeoLocationGroup.DoohGeoLocationGroupId
                    };
                }
                adGroupDoohGeoLocationGroup.TargetingActionId = (int) target.TargetingAction; // new targeting action
                strategy.AdGroupDoohGeoLocationGroups.Add(adGroupDoohGeoLocationGroup);
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task SetLanguages(StrategyTargetingUpdateOptions<int> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupLanguages)
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupLanguages.Where(x => options.Targetings.Select(y => y.Id).Contains(x.LanguageId)).ToArray();
            foreach (var adGroupLanguage in itemsToRemove)
            {
                adGroupLanguage.ObjectState = ObjectState.Deleted;
                strategy.AdGroupLanguages.Remove(adGroupLanguage);
            }

            // update
            foreach (var strategyTargetingItem in options.Targetings.Where(x => x.TargetingAction != (TargetingActionEnum) strategy.LanguageTargetingMode))
            {
                var adGroupLanguage = itemsToRemove.FirstOrDefault(x => x.LanguageId == strategyTargetingItem.Id);
                if (adGroupLanguage != null)
                {
                    // using existing record to modify
                    adGroupLanguage.ObjectState = ObjectState.Modified;
                }
                else
                {
                    adGroupLanguage = new AdGroupLanguage
                    {
                        ObjectState = ObjectState.Added,
                        AdGroupId = strategy.AdGroupId,
                        LanguageId = strategyTargetingItem.Id
                    };
                }
                adGroupLanguage.TargetingActionId = (int) strategyTargetingItem.TargetingAction; // new targeting action
                strategy.AdGroupLanguages.Add(adGroupLanguage);
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task SetVerticals(StrategyTargetingUpdateOptions<int> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupVerticals)
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupVerticals.Where(x => options.Targetings.Select(y => y.Id).Contains(x.VerticalId)).ToArray();
            foreach (var adGroupVertical in itemsToRemove)
            {
                adGroupVertical.ObjectState = ObjectState.Deleted;
                strategy.AdGroupVerticals.Remove(adGroupVertical);
            }

            // sort: from top to down by checking parent vertical
            var allVerticals = await _container.Resolve<IVerticalService>().GetVerticals().ToListAsync();
            var ids = options.Targetings.Select(x => x.Id).ToArray();
            var verticals = allVerticals.Where(x => ids.Contains(x.VerticalId)).ToList();
            Func<Vertical, int> findOrder = vertical =>
            {
                var order = 0;
                while (vertical.ParentVerticalId.HasValue)
                {
                    order++;
                    vertical = vertical.Vertical_ParentVerticalId;
                }
                return order;
            };
            var orderedVerticals = verticals.Select(x => new {Order = findOrder(x), Vertical = x})
                .OrderBy(x => x.Order)
                .Select(x => x.Vertical)
                .ToList();

            // update
            var defaultTargetingModes = new[] {strategy.Vertical1TargetingMode, strategy.Vertical2TargetingMode, strategy.Vertical3TargetingMode};
            foreach (var vertical in orderedVerticals)
            {
                // parent
                var source = Enumerable.Empty<int>();
                var level = 0;
                var currentVertical = vertical;
                while (currentVertical.ParentVerticalId.HasValue)
                {
                    var parentVertical = currentVertical.Vertical_ParentVerticalId;
                    source = source.Union(strategy.AdGroupVerticals.Where(x => x.VerticalId == parentVertical.VerticalId).Select(x => x.TargetingActionId));
                    currentVertical = currentVertical.Vertical_ParentVerticalId;
                    level++;
                }
                source = source.Union(new[] {defaultTargetingModes.ElementAt(level)}); // the default targeting mode depending on what level the vertical is
                var defaultTargetingAction = source
                    .Cast<TargetingActionEnum>()
                    .First();

                // skip: if the same as default targeting
                var target = options.Targetings.Single(y => y.Id == vertical.VerticalId);
                if (target.TargetingAction == defaultTargetingAction) continue;

                // modify or add
                var adGroupVertical = itemsToRemove.FirstOrDefault(x => x.VerticalId == vertical.VerticalId);
                if (adGroupVertical != null)
                {
                    // using existing record to modify
                    adGroupVertical.ObjectState = ObjectState.Modified;
                }
                else
                {
                    adGroupVertical = new AdGroupVertical
                    {
                        ObjectState = ObjectState.Added,
                        AdGroupId = strategy.AdGroupId,
                        VerticalId = vertical.VerticalId
                    };
                }
                adGroupVertical.TargetingActionId = (int) target.TargetingAction; // new targeting action
                strategy.AdGroupVerticals.Add(adGroupVertical);
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task SetPartners(StrategyTargetingUpdateOptions<int> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupSupplySources)
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupSupplySources.Where(x => options.Targetings.Select(y => y.Id).Contains(x.PartnerId)).ToArray();
            foreach (var adGroupSupplySource in itemsToRemove)
            {
                adGroupSupplySource.ObjectState = ObjectState.Deleted;
                strategy.AdGroupSupplySources.Remove(adGroupSupplySource);
            }

            // update
            foreach (var strategyTargetingItem in options.Targetings.Where(x => x.TargetingAction != (TargetingActionEnum) strategy.ExchangeTargetingMode))
            {
                var adGroupSupplySource = itemsToRemove.FirstOrDefault(x => x.PartnerId == strategyTargetingItem.Id);
                if (adGroupSupplySource != null)
                {
                    // using existing record to modify
                    adGroupSupplySource.ObjectState = ObjectState.Modified;
                }
                else
                {
                    adGroupSupplySource = new AdGroupSupplySource
                    {
                        ObjectState = ObjectState.Added,
                        AdGroupId = strategy.AdGroupId,
                        PartnerId = strategyTargetingItem.Id,
                        PublisherId = -1
                    };
                }
                adGroupSupplySource.TargetingActionId = (int) strategyTargetingItem.TargetingAction; // new targeting action
                strategy.AdGroupSupplySources.Add(adGroupSupplySource);
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task SetDoohPanelLocations(StrategyTargetingUpdateOptions<int> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupSupplySources)
                .Include(x => x.AdGroupDoohPanelLocations)
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupDoohPanelLocations.Where(x => options.Targetings.Select(y => y.Id).Contains(x.DoohPanelLocationId)).ToArray();
            foreach (var adGroupDoohPanelLocation in itemsToRemove)
            {
                adGroupDoohPanelLocation.ObjectState = ObjectState.Deleted;
                strategy.AdGroupDoohPanelLocations.Remove(adGroupDoohPanelLocation);
            }

            // update
            var ids = options.Targetings.Select(x => x.Id).ToArray();
            var doohPanelLocations = await _container.Resolve<IDoohService>().GetDoohPanelLocationsByIds(ids).ToListAsync();
            foreach (var doohPanelLocation in doohPanelLocations)
            {
                // parent
                var defaultTargetingAction = strategy.AdGroupSupplySources.Where(x => x.PartnerId == doohPanelLocation.PartnerId)
                    .Select(x => x.TargetingActionId) // parent exchange
                    .Union(new[] {(int) TargetingActionEnum.Targeting}) // fallback to default dooh panel location targeting mode
                    .Cast<TargetingActionEnum>()
                    .First();

                // skip: if the same as default targeting
                var target = options.Targetings.Single(x => x.Id == doohPanelLocation.DoohPanelLocationId);
                if (target.TargetingAction == defaultTargetingAction) continue;

                var adGroupDoohPanelLocation = itemsToRemove.FirstOrDefault(x => x.DoohPanelLocationId == doohPanelLocation.DoohPanelLocationId);
                if (adGroupDoohPanelLocation != null)
                {
                    // using existing record to modify
                    adGroupDoohPanelLocation.ObjectState = ObjectState.Modified;
                }
                else
                {
                    adGroupDoohPanelLocation = new AdGroupDoohPanelLocation
                    {
                        ObjectState = ObjectState.Added,
                        AdGroupId = strategy.AdGroupId,
                        DoohPanelLocationId = doohPanelLocation.DoohPanelLocationId
                    };
                }
                adGroupDoohPanelLocation.TargetingActionId = (int) target.TargetingAction; // new targeting action
                strategy.AdGroupDoohPanelLocations.Add(adGroupDoohPanelLocation);
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task SetPublishers(StrategyTargetingUpdateOptions<int> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupSupplySources)
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupSupplySources.Where(x => options.Targetings.Select(y => y.Id).Contains(x.PublisherId)).ToArray();
            foreach (var adGroupSupplySource in itemsToRemove)
            {
                adGroupSupplySource.ObjectState = ObjectState.Deleted;
                strategy.AdGroupSupplySources.Remove(adGroupSupplySource);
            }

            // update
            var ids = options.Targetings.Select(x => x.Id).ToArray();
            var publishers = await _container.Resolve<IPublisherService>().GetPublishers().Where(x => ids.Contains(x.PublisherId)).ToListAsync();
            foreach (var publisher in publishers)
            {
                // parent
                var defaultTargetingAction = strategy.AdGroupSupplySources.Where(x => x.PartnerId == publisher.PartnerId && x.PublisherId == -1)
                    .Select(x => x.TargetingActionId) // parent country
                    .Union(new[] {strategy.PublisherTargetingMode}) // fallback to default publisher targeting mode
                    .Cast<TargetingActionEnum>()
                    .First();

                // skip: if the same as default targeting
                var target = options.Targetings.Single(y => y.Id == publisher.PublisherId);
                if (target.TargetingAction == defaultTargetingAction) continue;

                // modify or add
                var adGroupSupplySource = itemsToRemove.FirstOrDefault(x => x.PublisherId == publisher.PublisherId);
                if (adGroupSupplySource != null)
                {
                    // using existing record to modify
                    adGroupSupplySource.ObjectState = ObjectState.Modified;
                }
                else
                {
                    adGroupSupplySource = new AdGroupSupplySource
                    {
                        ObjectState = ObjectState.Added,
                        AdGroupId = strategy.AdGroupId,
                        PartnerId = publisher.PartnerId,
                        PublisherId = publisher.PublisherId
                    };
                }
                adGroupSupplySource.TargetingActionId = (int) target.TargetingAction; // new targeting action
                strategy.AdGroupSupplySources.Add(adGroupSupplySource);
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task SetDomainLists(StrategyTargetingUpdateOptions<int> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupDomainLists)
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupDomainLists.Where(x => options.Targetings.Select(y => y.Id).Contains(x.DomainListId)).ToArray();
            foreach (var adGroupDomainList in itemsToRemove)
            {
                adGroupDomainList.ObjectState = ObjectState.Deleted;
                strategy.AdGroupDomainLists.Remove(adGroupDomainList);
            }

            // update
            foreach (var strategyTargetingItem in options.Targetings)
            {
                var adGroupDomainList = itemsToRemove.FirstOrDefault(x => x.DomainListId == strategyTargetingItem.Id);
                if (adGroupDomainList != null)
                {
                    // using existing record to modify
                    adGroupDomainList.ObjectState = ObjectState.Modified;
                }
                else
                {
                    adGroupDomainList = new AdGroupDomainList
                    {
                        ObjectState = ObjectState.Added,
                        AdGroupId = strategy.AdGroupId,
                        DomainListId = strategyTargetingItem.Id
                    };
                }
                adGroupDomainList.TargetingActionId = (int) strategyTargetingItem.TargetingAction; // new targeting action
                strategy.AdGroupDomainLists.Add(adGroupDomainList);
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task SetSegments(StrategyTargetingUpdateOptions<int> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupSegments)
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupSegments.Where(x => options.Targetings.Select(y => y.Id).Contains(x.SegmentId)).ToArray();
            foreach (var adGroupSegment in itemsToRemove)
            {
                adGroupSegment.ObjectState = ObjectState.Deleted;
                strategy.AdGroupSegments.Remove(adGroupSegment);
            }

            // update: only accept targeting or avoiding action
            foreach (var strategyTargetingItem in options.Targetings.Where(x => x.TargetingAction == TargetingActionEnum.Targeting || x.TargetingAction == TargetingActionEnum.Avoiding))
            {
                var adGroupSegment = itemsToRemove.FirstOrDefault(x => x.SegmentId == strategyTargetingItem.Id);
                if (adGroupSegment != null)
                {
                    // using existing record to modify
                    adGroupSegment.ObjectState = ObjectState.Modified;
                }
                else
                {
                    adGroupSegment = new AdGroupSegment
                    {
                        ObjectState = ObjectState.Added,
                        AdGroupId = strategy.AdGroupId,
                        SegmentId = strategyTargetingItem.Id
                    };
                }
                adGroupSegment.TargetingActionId = (int) strategyTargetingItem.TargetingAction; // new targeting action
                strategy.AdGroupSegments.Add(adGroupSegment);
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task SetDevices(StrategyTargetingUpdateOptions<int> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupDevices)
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupDevices.Where(x => options.Targetings.Select(y => y.Id).Contains(x.DeviceId)).ToArray();
            foreach (var adGroupDevice in itemsToRemove)
            {
                adGroupDevice.ObjectState = ObjectState.Deleted;
                strategy.AdGroupDevices.Remove(adGroupDevice);
            }

            // update
            foreach (var strategyTargetingItem in options.Targetings.Where(x => x.TargetingAction != (TargetingActionEnum) strategy.DeviceTargetingMode))
            {
                var adGroupLanguage = itemsToRemove.FirstOrDefault(x => x.DeviceId == strategyTargetingItem.Id);
                if (adGroupLanguage != null)
                {
                    // using existing record to modify
                    adGroupLanguage.ObjectState = ObjectState.Modified;
                }
                else
                {
                    adGroupLanguage = new AdGroupDevice
                    {
                        ObjectState = ObjectState.Added,
                        AdGroupId = strategy.AdGroupId,
                        DeviceId = strategyTargetingItem.Id
                    };
                }
                adGroupLanguage.TargetingActionId = (int) strategyTargetingItem.TargetingAction; // new targeting action
                strategy.AdGroupDevices.Add(adGroupLanguage);
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task SetMobileCarriers(StrategyTargetingUpdateOptions<StrategyTargetingMobileCarrier> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupMobileCarriers)
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupMobileCarriers.Where(x => options.Targetings.Any(y => x.GeoCountryId == y.Id.GeoCountryId && x.Mcc == y.Id.Mcc && x.Mnc == y.Id.Mnc)).ToArray();
            foreach (var adGroupMobileCarrier in itemsToRemove)
            {
                adGroupMobileCarrier.ObjectState = ObjectState.Deleted;
                strategy.AdGroupMobileCarriers.Remove(adGroupMobileCarrier);
            }

            // update
            foreach (var strategyTargetingItem in options.Targetings.Where(x => x.TargetingAction != (TargetingActionEnum) strategy.MobileCarrierTargetingMode))
            {
                var adGroupMobileCarrier = itemsToRemove.FirstOrDefault(x => x.GeoCountryId == strategyTargetingItem.Id.GeoCountryId && x.Mcc == strategyTargetingItem.Id.Mcc && x.Mnc == strategyTargetingItem.Id.Mnc);
                if (adGroupMobileCarrier != null)
                {
                    // using existing record to modify
                    adGroupMobileCarrier.ObjectState = ObjectState.Modified;
                }
                else
                {
                    adGroupMobileCarrier = new AdGroupMobileCarrier
                    {
                        ObjectState = ObjectState.Added,
                        AdGroupId = strategy.AdGroupId,
                        GeoCountryId = strategyTargetingItem.Id.GeoCountryId,
                        Mcc = strategyTargetingItem.Id.Mcc,
                        Mnc = strategyTargetingItem.Id.Mnc
                    };
                }
                adGroupMobileCarrier.TargetingActionId = (int) strategyTargetingItem.TargetingAction; // new targeting action
                strategy.AdGroupMobileCarriers.Add(adGroupMobileCarrier);
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task SetDayParts(StrategyTargetingUpdateOptions<int> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupDayParts)
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupDayParts.Where(x => options.Targetings.Select(y => y.Id).Contains(x.DayPartId)).ToArray();
            foreach (var adGroupDayPart in itemsToRemove)
            {
                adGroupDayPart.ObjectState = ObjectState.Deleted;
                strategy.AdGroupDayParts.Remove(adGroupDayPart);
            }

            // update
            foreach (var strategyTargetingItem in options.Targetings.Where(x => x.TargetingAction != (TargetingActionEnum) strategy.DayPartTargetingMode))
            {
                var adGroupDayPart = itemsToRemove.FirstOrDefault(x => x.DayPartId == strategyTargetingItem.Id);
                if (adGroupDayPart != null)
                {
                    // using existing record to modify
                    adGroupDayPart.ObjectState = ObjectState.Modified;
                }
                else
                {
                    adGroupDayPart = new AdGroupDayPart
                    {
                        ObjectState = ObjectState.Added,
                        AdGroupId = strategy.AdGroupId,
                        DayPartId = strategyTargetingItem.Id
                    };
                }
                adGroupDayPart.TargetingActionId = (int) strategyTargetingItem.TargetingAction; // new targeting action
                strategy.AdGroupDayParts.Add(adGroupDayPart);
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task SetPagePositions(StrategyTargetingUpdateOptions<int> options)
        {
            // load
            var strategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.AdGroupPagePositions)
                .FirstAsync(x => x.AdGroupUuid == options.StrategyUuid);

            // remove
            var itemsToRemove = strategy.AdGroupPagePositions.Where(x => options.Targetings.Select(y => y.Id).Contains(x.PagePositionId)).ToArray();
            foreach (var adGroupPagePosition in itemsToRemove)
            {
                adGroupPagePosition.ObjectState = ObjectState.Deleted;
                strategy.AdGroupPagePositions.Remove(adGroupPagePosition);
            }

            // update
            foreach (var strategyTargetingItem in options.Targetings.Where(x => x.TargetingAction != (TargetingActionEnum) strategy.PagePositionTargetingMode))
            {
                var adGroupDayPart = itemsToRemove.FirstOrDefault(x => x.PagePositionId == strategyTargetingItem.Id);
                if (adGroupDayPart != null)
                {
                    // using existing record to modify
                    adGroupDayPart.ObjectState = ObjectState.Modified;
                }
                else
                {
                    adGroupDayPart = new AdGroupPagePosition
                    {
                        ObjectState = ObjectState.Added,
                        AdGroupId = strategy.AdGroupId,
                        PagePositionId = strategyTargetingItem.Id
                    };
                }
                adGroupDayPart.TargetingActionId = (int) strategyTargetingItem.TargetingAction; // new targeting action
                strategy.AdGroupPagePositions.Add(adGroupDayPart);
            }

            // save
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }
    }
}
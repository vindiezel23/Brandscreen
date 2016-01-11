using System;
using System.Data.Entity;
using System.Linq;
using Autofac;
using Brandscreen.Core.Services.Strategies.Targets;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services.Strategies
{
    public interface IStrategyTargetingService : IDependency
    {
        IQueryable<AdGroupBrandSafety> GetBrandSafeties(Guid id);
        IQueryable<AdGroupDayPart> GetDayParts(Guid id);
        IQueryable<AdGroupDeal> GetDeals(Guid id);
        IQueryable<AdGroupDevice> GetDevices(Guid id);
        IQueryable<AdGroupDomainList> GetDomainLists(Guid id);
        IQueryable<AdGroupDoohGeoLocationGroup> GetDoohGeoLocationGroups(Guid id);
        IQueryable<AdGroupGeoLocation> GetGeoLocations(Guid id);
        IQueryable<AdGroupGeoPostcode> GetGeoPostcodes(Guid id);
        IQueryable<AdGroupInventory> GetInventories(Guid id);
        IQueryable<AdGroupLanguage> GetLanguages(Guid id);
        IQueryable<AdGroupMobileCarrier> GetMobileCarriers(Guid id);
        IQueryable<AdGroupPagePosition> GetPagePositions(Guid id);
        IQueryable<AdGroupSegment> GetSegments(Guid id);
        IQueryable<AdGroupSupplySource> GetSupplySources(Guid id);
        IQueryable<AdGroupDoohPanelLocation> GetDoohPanelLocations(Guid id);
        IQueryable<AdGroupVertical> GetVerticals(Guid id);
        IQueryable<AdGroupPartnerSeat> GetPartnerSeats(Guid id);
    }

    public class StrategyTargetingService : IStrategyTargetingService
    {
        private readonly ILifetimeScope _container;

        public StrategyTargetingService(ILifetimeScope container)
        {
            _container = container;
        }

        public IQueryable<AdGroupBrandSafety> GetBrandSafeties(Guid id)
        {
            var source = _container.Resolve<IRepositoryAsync<AdGroupBrandSafety>>().Queryable();
            return source.Include(x => x.BrandSafetyType)
                .Where(x => x.AdGroup.AdGroupUuid == id)
                .OrderBy(x => x.TargetingActionId);
        }

        public IQueryable<AdGroupDayPart> GetDayParts(Guid id)
        {
            var source = _container.Resolve<IRepositoryAsync<AdGroupDayPart>>().Queryable();
            return source.Include(x => x.DayPart)
                .Where(x => x.AdGroup.AdGroupUuid == id)
                .OrderBy(x => x.TargetingActionId);
        }

        public IQueryable<AdGroupDeal> GetDeals(Guid id)
        {
            var source = _container.Resolve<IRepositoryAsync<AdGroupDeal>>().Queryable();
            return source.Where(x => x.AdGroup.AdGroupUuid == id)
                .Include(x => x.Deal)
                .OrderBy(x => x.TargetingActionId);
        }

        public IQueryable<AdGroupDevice> GetDevices(Guid id)
        {
            var source = _container.Resolve<IRepositoryAsync<AdGroupDevice>>().Queryable();
            return source.Include(x => x.Device)
                .Where(x => x.AdGroup.AdGroupUuid == id)
                .OrderBy(x => x.TargetingActionId);
        }

        public IQueryable<AdGroupDomainList> GetDomainLists(Guid id)
        {
            var strategy = _container.Resolve<IRepositoryAsync<AdGroup>>().Queryable()
                .Include(x => x.Campaign.AdvertiserProduct)
                .First(x => x.AdGroupUuid == id);

            // retrieve all domain lists relevant to the strategy
            var domainLists = _container.Resolve<IRepositoryAsync<DomainList>>().Queryable()
                .Include(x => x.AdGroupDomainLists)
                .Include(x => x.CampaignDomainLists)
                .Include(x => x.AdvertiserProductDomainLists)
                .Include(x => x.AdvertiserDomainLists)
                .Include(x => x.BuyerAccountDomainLists)
                .Where(x => x.AdGroupDomainLists.Any(y => y.AdGroupId == strategy.AdGroupId) ||
                            x.CampaignDomainLists.Any(y => y.CampaignId == strategy.CampaignId) ||
                            x.AdvertiserProductDomainLists.Any(y => y.AdvertiserProductId == strategy.Campaign.AdvertiserProductId) ||
                            x.AdvertiserDomainLists.Any(y => y.AdvertiserId == strategy.Campaign.AdvertiserProduct.AdvertiserId) ||
                            x.BuyerAccountDomainLists.Any(y => y.BuyerAccountId == strategy.BuyerAccountId) ||
                            (x.AdGroupId == strategy.AdGroupId && x.DomainListType == (int) DomainListTypeEnum.AdGroupAvoidingList) ||
                            x.DomainListType == (int) DomainListTypeEnum.SystemBlackList)
                .ToList();

            // build targeting domain lists by using higher priority targeting action 
            // AdGroupDomainLists > CampaignDomainLists > AdvertiserProductDomainLists > AdvertiserDomainLists > BuyerAccountDomainLists
            var targetingDomainLists = domainLists.Select(x => new
            {
                DomainList = x,
                TargetingActionId = x.AdGroupDomainLists.SingleOrDefault(y => y.AdGroupId == strategy.AdGroupId)?.TargetingActionId ??
                                    x.CampaignDomainLists.SingleOrDefault(y => y.CampaignId == strategy.CampaignId)?.TargetingActionId ??
                                    x.AdvertiserProductDomainLists.SingleOrDefault(y => y.AdvertiserProductId == strategy.Campaign.AdvertiserProductId)?.TargetingActionId ??
                                    x.AdvertiserDomainLists.SingleOrDefault(y => y.AdvertiserId == strategy.Campaign.AdvertiserProduct.AdvertiserId)?.TargetingActionId ??
                                    x.BuyerAccountDomainLists.SingleOrDefault(y => y.BuyerAccountId == strategy.BuyerAccountId)?.TargetingActionId ??
                                    (int) TargetingActionEnum.Avoiding // TargetingAction.Avoiding for both DomainListType.AdGroupAvoidingList and DomainListType.SystemBlackList
            });

            // return AdGroupDomainList list to keep consistency as other targeting methods
            var source = targetingDomainLists.Select(x => new AdGroupDomainList
            {
                AdGroupId = strategy.AdGroupId,
                DomainListId = x.DomainList.DomainListId,
                TargetingActionId = x.TargetingActionId,
            });
            return source.OrderBy(x => x.TargetingActionId).AsQueryable();
        }

        public IQueryable<AdGroupDoohGeoLocationGroup> GetDoohGeoLocationGroups(Guid id)
        {
            var source = _container.Resolve<IRepositoryAsync<AdGroupDoohGeoLocationGroup>>().Queryable();
            return source.Where(x => x.AdGroup.AdGroupUuid == id)
                .OrderBy(x => x.TargetingActionId);
        }

        public IQueryable<AdGroupGeoLocation> GetGeoLocations(Guid id)
        {
            var source = _container.Resolve<IRepositoryAsync<AdGroupGeoLocation>>().Queryable();
            return source.Where(x => x.AdGroup.AdGroupUuid == id)
                .Include(x => x.GeoLocation)
                .OrderBy(x => x.TargetingActionId);
        }

        public IQueryable<AdGroupGeoPostcode> GetGeoPostcodes(Guid id)
        {
            var source = _container.Resolve<IRepositoryAsync<AdGroupGeoPostcode>>().Queryable();
            return source.Where(x => x.AdGroup.AdGroupUuid == id)
                .OrderBy(x => x.TargetingActionId);
        }

        public IQueryable<AdGroupInventory> GetInventories(Guid id)
        {
            var source = _container.Resolve<IRepositoryAsync<AdGroupInventory>>().Queryable();
            return source.Where(x => x.AdGroup.AdGroupUuid == id)
                .OrderBy(x => x.TargetingActionId);
        }

        public IQueryable<AdGroupLanguage> GetLanguages(Guid id)
        {
            var source = _container.Resolve<IRepositoryAsync<AdGroupLanguage>>().Queryable();
            return source.Include(x => x.Language)
                .Where(x => x.AdGroup.AdGroupUuid == id)
                .OrderBy(x => x.TargetingActionId);
        }

        public IQueryable<AdGroupMobileCarrier> GetMobileCarriers(Guid id)
        {
            var source = _container.Resolve<IRepositoryAsync<AdGroupMobileCarrier>>().Queryable();
            return source.Where(x => x.AdGroup.AdGroupUuid == id)
                .OrderBy(x => x.TargetingActionId);
        }

        public IQueryable<AdGroupPagePosition> GetPagePositions(Guid id)
        {
            var source = _container.Resolve<IRepositoryAsync<AdGroupPagePosition>>().Queryable();
            return source.Include(x => x.PagePosition)
                .Where(x => x.AdGroup.AdGroupUuid == id)
                .OrderBy(x => x.TargetingActionId);
        }

        public IQueryable<AdGroupSegment> GetSegments(Guid id)
        {
            var source = _container.Resolve<IRepositoryAsync<AdGroupSegment>>().Queryable();
            return source.Where(x => x.AdGroup.AdGroupUuid == id)
                .Include(x => x.Segment)
                .OrderBy(x => x.TargetingActionId);
        }

        public IQueryable<AdGroupSupplySource> GetSupplySources(Guid id)
        {
            var source = _container.Resolve<IRepositoryAsync<AdGroupSupplySource>>().Queryable();
            return source.Where(x => x.AdGroup.AdGroupUuid == id)
                .OrderBy(x => x.TargetingActionId);
        }

        public IQueryable<AdGroupDoohPanelLocation> GetDoohPanelLocations(Guid id)
        {
            var source = _container.Resolve<IRepositoryAsync<AdGroupDoohPanelLocation>>().Queryable();
            return source.Where(x => x.AdGroup.AdGroupUuid == id)
                .OrderBy(x => x.TargetingActionId);
        }

        public IQueryable<AdGroupVertical> GetVerticals(Guid id)
        {
            var verticals = _container.Resolve<IVerticalService>().GetVerticals();
            var targetingVerticals = _container.Resolve<IRepositoryAsync<AdGroupVertical>>().Queryable().Where(x => x.AdGroup.AdGroupUuid == id).ToList();

            var topLevelVerticals = verticals.Where(x => !x.ParentVerticalId.HasValue && x.IabReference == null).ToList();
            if (topLevelVerticals.All(x => targetingVerticals.Any(y => x.VerticalId == y.VerticalId && y.TargetingActionId == (int) TargetingActionEnum.Targeting)))
            {
                // remove all top level verticals as they are all targeting by default
                targetingVerticals.RemoveAll(x => topLevelVerticals.Any(y => y.VerticalId == x.VerticalId));
            }

            var topLevelIabVerticals = verticals.Where(x => !x.ParentVerticalId.HasValue && x.IabReference != null).ToList();
            if (topLevelIabVerticals.All(x => targetingVerticals.Any(y => x.VerticalId == y.VerticalId && y.TargetingActionId == (int) TargetingActionEnum.Targeting)))
            {
                // remove all top level iab verticals as they are all targeting by default
                targetingVerticals.RemoveAll(x => topLevelIabVerticals.Any(y => y.VerticalId == x.VerticalId));
            }

            return targetingVerticals.AsQueryable();
        }

        public IQueryable<AdGroupPartnerSeat> GetPartnerSeats(Guid id)
        {
            var strategies = _container.Resolve<IRepositoryAsync<AdGroup>>().Queryable();
            var buyerAccountApplicationParameters = _container.Resolve<IRepositoryAsync<BuyerAccountApplicationParameter>>().Queryable();
            var partnerDefaultBuyers = _container.Resolve<IRepositoryAsync<PartnerDefaultBuyer>>().Queryable();
            var buyerAccountApplicationPartners = _container.Resolve<IRepositoryAsync<BuyerAccountApplicationPartner>>().Queryable();

            // notice: logic migrated from BuyerAccountPartnerSeatView and AdGroupTargetingView
            var query =
                from strategy in strategies
                    .Where(x => x.AdGroupUuid == id)
                from partner in buyerAccountApplicationPartners
                    .Where(x => x.BuyerAccountId == strategy.BuyerAccountId)
                    .Where(x => x.Partner.MediaTypeId == strategy.MediaTypeId || (new[] {1, 2, 3}.Contains(strategy.MediaTypeId) && x.Partner.MediaTypeId == null))
                from parameter in buyerAccountApplicationParameters
                    .Where(x => x.BuyerAccountId == partner.BuyerAccountId && x.PackageKey == partner.PackageKey && x.Key == "BuyerID" && !string.IsNullOrEmpty(x.Value))
                    .DefaultIfEmpty() // left join
                from buyer in partnerDefaultBuyers
                    .Where(x => x.PartnerId == partner.PartnerId)
                    .DefaultIfEmpty() // left join
                select new {Partner = partner, Parameter = parameter, Buyer = buyer};

            var source = query.OrderBy(x => x.Partner.PartnerId).ToList(); // execute the query
            var retVal = source.Select(x => new AdGroupPartnerSeat
            {
                PartnerId = x.Partner.PartnerId,
                TargetingActionId = (int) TargetingActionEnum.Targeting,
                BuyerId = $"{x.Partner.PartnerId}|1|{x.Parameter?.Value ?? x.Buyer?.BuyerId ?? "0"}"
            });
            return retVal.AsQueryable();
        }
    }
}
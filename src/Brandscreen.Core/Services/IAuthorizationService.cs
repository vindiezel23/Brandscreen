using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using Autofac;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Users;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Microsoft.Owin;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services
{
    public interface IAuthorizationService : IDependency
    {
        bool CanAccessEverything();
        bool CanWriteUser(Guid userId);
        bool CanReadUser(Guid userId);
        bool CanWriteBuyerAccount(Guid buyerAccountUuid);
        bool CanReadBuyerAccount(Guid buyerAccountUuid);
        bool CanWriteAdvertiser(Guid advertiserUuid);
        bool CanReadAdvertiser(Guid advertiserUuid);
        bool CanWriteBrand(Guid brandUuid);
        bool CanReadBrand(Guid brandUuid);
        bool CanWriteCampaign(Guid campaignUuid);
        bool CanReadCampaign(Guid campaignUuid);
        bool CanWriteStrategy(Guid strategyUuid);
        bool CanReadStrategy(Guid strategyUuid);
        bool CanWriteCreative(Guid creativeUuid);
        bool CanReadCreative(Guid creativeUuid);
        bool CanWriteDeal(Guid dealUuid);
        bool CanReadDeal(Guid dealUuid);
        bool CanReadDomainList(int domainListId);
        bool CanReadSegment(int segmentId);
        bool CanWriteSegment(int segmentId);
        bool CanReadPlacement(Guid placementUuid);
        bool CanWriteDoohPanelLocation(int doohPanelLocationId);

        string[] GetClaimValues(string claimType);
    }

    public class AuthorizationService : IAuthorizationService
    {
        private readonly ILifetimeScope _container;
        private readonly IOwinContext _owinContext;

        public AuthorizationService(ILifetimeScope container, IOwinContext owinContext)
        {
            _container = container;
            _owinContext = owinContext;
        }

        public bool CanAccessEverything()
        {
            var currentUser = _owinContext.Authentication.User;
            return currentUser.IsInRole(StandardRole.SuperAdministrator) || currentUser.IsInRole(StandardRole.SystemAdministrator);
        }

        public bool CanWriteUser(Guid userId)
        {
            if (CanAccessEverything()) return true;

            return _owinContext.GetCurrentUserId() == userId;
        }

        public bool CanReadUser(Guid userId)
        {
            if (CanWriteUser(userId)) return true;

            // check if current user is AgencyAdministrator of any BuyerAccount of the user
            var currentUserBuyerRoles = _owinContext.GetCurrentUserBuyerRoles();
            var userBuyerAccountIds = _container.Resolve<IUserService>().GetUserBuyerRoles(userId).Select(x => x.BuyerAccountId).ToList();
            return currentUserBuyerRoles.Any(x => x.RoleName == StandardRole.Administrator && userBuyerAccountIds.Any(id => id == x.BuyerId));
        }

        public bool CanWriteBuyerAccount(Guid buyerAccountUuid)
        {
            if (CanAccessEverything()) return true;

            // check if current user is AgencyAdministrator of the BuyerAccount
            var currentUserBuyerRoles = _owinContext.GetCurrentUserBuyerRoles();
            return currentUserBuyerRoles.Any(x => x.RoleName == StandardRole.Administrator && x.BuyerUuid == buyerAccountUuid);
        }

        public bool CanReadBuyerAccount(Guid buyerAccountUuid)
        {
            if (CanWriteBuyerAccount(buyerAccountUuid)) return true;

            // check if current user has any role of the BuyerAccount
            var currentUserBuyerRoles = _owinContext.GetCurrentUserBuyerRoles();
            return currentUserBuyerRoles.Any(x => x.BuyerUuid == buyerAccountUuid);
        }

        public bool CanWriteAdvertiser(Guid advertiserUuid)
        {
            if (CanAccessEverything()) return true;

            var advertiser = _container.Resolve<IRepositoryAsync<Advertiser>>().Queryable().Include(x => x.UserAdvertiserRoles).FirstOrDefault(x => x.AdvertiserUuid == advertiserUuid);
            if (advertiser == null) return true;
            return CanWriteAdvertiser(advertiser.UserAdvertiserRoles, advertiser.BuyerAccountId);
        }

        private bool CanWriteAdvertiser(IEnumerable<UserAdvertiserRole> userAdvertiserRoles, int buyerAccountId)
        {
            // check if current user is AgencyAdministrator of the advertiser's BuyerAccount
            // or has AdvertiserFullUser permission of the advertiser
            var buyerRole = _owinContext.GetCurrentUserBuyerRoles().FirstOrDefault(x => x.BuyerId == buyerAccountId);
            if (buyerRole != null)
            {
                if (buyerRole.RoleName == StandardRole.Administrator) return true;
                if (buyerRole.RoleName == StandardRole.User)
                {
                    var currentUserId = _owinContext.GetCurrentUserId();
                    if (userAdvertiserRoles.Any(x => x.UserId == currentUserId && x.RoleName == StandardPermission.AdvertiserFullUser)) return true;
                }
            }

            return false;
        }

        public bool CanReadAdvertiser(Guid advertiserUuid)
        {
            if (CanAccessEverything()) return true;

            var advertiser = _container.Resolve<IRepositoryAsync<Advertiser>>().Queryable().Include(x => x.UserAdvertiserRoles).FirstOrDefault(x => x.AdvertiserUuid == advertiserUuid);
            if (advertiser == null) return true;
            return CanWriteAdvertiser(advertiser.UserAdvertiserRoles, advertiser.BuyerAccountId) ||
                   CanReadAdvertiser(advertiser.UserAdvertiserRoles, advertiser.BuyerAccountId);
        }

        private bool CanReadAdvertiser(IEnumerable<UserAdvertiserRole> userAdvertiserRoles, int buyerAccountId)
        {
            // check if current user has AdvertiserLimitedUser permission of the advertiser
            var buyerRole = _owinContext.GetCurrentUserBuyerRoles().FirstOrDefault(x => x.BuyerId == buyerAccountId);
            return buyerRole != null &&
                   buyerRole.RoleName == StandardRole.User &&
                   userAdvertiserRoles.Any(x => x.UserId == _owinContext.GetCurrentUserId() && x.RoleName == StandardPermission.AdvertiserLimitedUser);
        }

        public bool CanWriteBrand(Guid brandUuid)
        {
            if (CanAccessEverything()) return true;

            var brand = _container.Resolve<IRepositoryAsync<AdvertiserProduct>>().Queryable().Include(x => x.Advertiser.UserAdvertiserRoles).FirstOrDefault(x => x.AdvertiserProductUuid == brandUuid);
            if (brand == null) return true;
            return CanWriteAdvertiser(brand.Advertiser.UserAdvertiserRoles, brand.BuyerAccountId);
        }

        public bool CanReadBrand(Guid brandUuid)
        {
            if (CanAccessEverything()) return true;

            var brand = _container.Resolve<IRepositoryAsync<AdvertiserProduct>>().Queryable().Include(x => x.Advertiser.UserAdvertiserRoles).FirstOrDefault(x => x.AdvertiserProductUuid == brandUuid);
            if (brand == null) return true;
            return CanWriteAdvertiser(brand.Advertiser.UserAdvertiserRoles, brand.BuyerAccountId) ||
                   CanReadAdvertiser(brand.Advertiser.UserAdvertiserRoles, brand.BuyerAccountId);
        }

        public bool CanWriteCampaign(Guid campaignUuid)
        {
            if (CanAccessEverything()) return true;

            var campaign = _container.Resolve<IRepositoryAsync<Campaign>>().Queryable().Include(x => x.AdvertiserProduct.Advertiser.UserAdvertiserRoles).FirstOrDefault(x => x.CampaignUuid == campaignUuid);
            if (campaign == null) return true;
            return CanWriteAdvertiser(campaign.AdvertiserProduct.Advertiser.UserAdvertiserRoles, campaign.BuyerAccountId);
        }

        public bool CanReadCampaign(Guid campaignUuid)
        {
            if (CanAccessEverything()) return true;

            var campaign = _container.Resolve<IRepositoryAsync<Campaign>>().Queryable().Include(x => x.AdvertiserProduct.Advertiser.UserAdvertiserRoles).FirstOrDefault(x => x.CampaignUuid == campaignUuid);
            if (campaign == null) return true;
            return CanWriteAdvertiser(campaign.AdvertiserProduct.Advertiser.UserAdvertiserRoles, campaign.BuyerAccountId) ||
                   CanReadAdvertiser(campaign.AdvertiserProduct.Advertiser.UserAdvertiserRoles, campaign.BuyerAccountId);
        }

        public bool CanWriteStrategy(Guid strategyUuid)
        {
            if (CanAccessEverything()) return true;

            var strategy = _container.Resolve<IRepositoryAsync<AdGroup>>().Queryable().Include(x => x.Campaign.AdvertiserProduct.Advertiser.UserAdvertiserRoles).FirstOrDefault(x => x.AdGroupUuid == strategyUuid);
            if (strategy == null) return true;
            return CanWriteAdvertiser(strategy.Campaign.AdvertiserProduct.Advertiser.UserAdvertiserRoles, strategy.BuyerAccountId);
        }

        public bool CanReadStrategy(Guid strategyUuid)
        {
            if (CanAccessEverything()) return true;

            var strategy = _container.Resolve<IRepositoryAsync<AdGroup>>().Queryable().Include(x => x.Campaign.AdvertiserProduct.Advertiser.UserAdvertiserRoles).FirstOrDefault(x => x.AdGroupUuid == strategyUuid);
            if (strategy == null) return true;
            return CanWriteAdvertiser(strategy.Campaign.AdvertiserProduct.Advertiser.UserAdvertiserRoles, strategy.BuyerAccountId) ||
                   CanReadAdvertiser(strategy.Campaign.AdvertiserProduct.Advertiser.UserAdvertiserRoles, strategy.BuyerAccountId);
        }

        public bool CanWriteCreative(Guid creativeUuid)
        {
            if (CanAccessEverything()) return true;

            var creative = _container.Resolve<IRepositoryAsync<Creative>>().Queryable().Include(x => x.AdvertiserProduct.Advertiser.UserAdvertiserRoles).FirstOrDefault(x => x.CreativeUuid == creativeUuid);
            if (creative == null) return true;
            return CanWriteAdvertiser(creative.AdvertiserProduct.Advertiser.UserAdvertiserRoles, creative.BuyerAccountId);
        }

        public bool CanReadCreative(Guid creativeUuid)
        {
            if (CanAccessEverything()) return true;

            var creative = _container.Resolve<IRepositoryAsync<Creative>>().Queryable().Include(x => x.AdvertiserProduct.Advertiser.UserAdvertiserRoles).FirstOrDefault(x => x.CreativeUuid == creativeUuid);
            if (creative == null) return true;
            return CanWriteAdvertiser(creative.AdvertiserProduct.Advertiser.UserAdvertiserRoles, creative.BuyerAccountId) ||
                   CanReadAdvertiser(creative.AdvertiserProduct.Advertiser.UserAdvertiserRoles, creative.BuyerAccountId);
        }

        public bool CanWriteDeal(Guid dealUuid)
        {
            var deal = _container.Resolve<IRepositoryAsync<Deal>>().Queryable().Include(x => x.BuyerAccount).FirstOrDefault(x => x.DealUuid == dealUuid);
            if (deal == null) return true;
            return CanWriteBuyerAccount(deal.BuyerAccount.BuyerAccountUuid);
        }

        public bool CanReadDeal(Guid dealUuid)
        {
            var deal = _container.Resolve<IRepositoryAsync<Deal>>().Queryable().Include(x => x.BuyerAccount).FirstOrDefault(x => x.DealUuid == dealUuid);
            if (deal == null) return true;
            return CanReadBuyerAccount(deal.BuyerAccount.BuyerAccountUuid);
        }

        public bool CanReadDomainList(int domainListId)
        {
            var domainList = _container.Resolve<IRepositoryAsync<DomainList>>().Queryable().FirstOrDefault(x => x.DomainListId == domainListId);
            if (domainList == null) return true;
            if (!domainList.AdGroupId.HasValue && !domainList.BuyerAccountId.HasValue) return true; // the domain list has no owner

            var canRead = false;
            if (domainList.AdGroupId.HasValue)
            {
                var strategyUuid = _container.Resolve<IRepositoryAsync<AdGroup>>().Find(domainList.AdGroupId.Value).AdGroupUuid;
                canRead = CanReadStrategy(strategyUuid);
            }
            if (!canRead && domainList.BuyerAccountId.HasValue)
            {
                var buyerAccountUuid = _container.Resolve<IRepositoryAsync<BuyerAccount>>().Find(domainList.BuyerAccountId.Value).BuyerAccountUuid;
                return CanReadBuyerAccount(buyerAccountUuid);
            }
            return canRead;
        }

        public bool CanReadSegment(int segmentId)
        {
            if (CanAccessEverything()) return true;

            var segment = _container.Resolve<IRepositoryAsync<Segment>>().Queryable().FirstOrDefault(x => x.SegmentId == segmentId);
            if (segment == null) return true;
            if (!segment.AdvertiserId.HasValue && !segment.BuyerAccountId.HasValue) return true; // the segment has no owner

            var canRead = false;
            if (segment.AdvertiserId.HasValue)
            {
                var advertiserUuid = _container.Resolve<IRepositoryAsync<Advertiser>>().Find(segment.AdvertiserId.Value).AdvertiserUuid;
                canRead = CanReadAdvertiser(advertiserUuid);
            }
            if (!canRead && segment.BuyerAccountId.HasValue)
            {
                var buyerAccountUuid = _container.Resolve<IRepositoryAsync<BuyerAccount>>().Find(segment.BuyerAccountId.Value).BuyerAccountUuid;
                return CanReadBuyerAccount(buyerAccountUuid);
            }
            return canRead;
        }

        public bool CanWriteSegment(int segmentId)
        {
            if (CanAccessEverything()) return true;

            var segment = _container.Resolve<IRepositoryAsync<Segment>>().Queryable().FirstOrDefault(x => x.SegmentId == segmentId);
            if (segment == null) return true;

            var canWrite = AuthorizationServiceExtensions.CanWriteSegment(this, segment.RtbSegmentId); // note: this is an extension authorization
            if (!canWrite && segment.AdvertiserId.HasValue)
            {
                var advertiserUuid = _container.Resolve<IRepositoryAsync<Advertiser>>().Find(segment.AdvertiserId.Value).AdvertiserUuid;
                canWrite = CanWriteAdvertiser(advertiserUuid);
            }
            if (!canWrite && segment.BuyerAccountId.HasValue)
            {
                var buyerAccountUuid = _container.Resolve<IRepositoryAsync<BuyerAccount>>().Find(segment.BuyerAccountId.Value).BuyerAccountUuid;
                canWrite = CanWriteBuyerAccount(buyerAccountUuid);
            }
            return canWrite;
        }

        public bool CanReadPlacement(Guid placementUuid)
        {
            var placement = _container.Resolve<IRepositoryAsync<Placement>>().Queryable().FirstOrDefault(x => x.PlacementUuid == placementUuid);
            if (placement == null) return true;

            var strategy = _container.Resolve<IRepositoryAsync<AdGroup>>().Find(placement.AdGroupId);
            var creative = _container.Resolve<IRepositoryAsync<Creative>>().Find(placement.CreativeId);
            return CanReadStrategy(strategy.AdGroupUuid) && CanReadCreative(creative.CreativeUuid);
        }

        public bool CanWriteDoohPanelLocation(int doohPanelLocationId)
        {
            if (CanAccessEverything()) return true;

            var doohPanelLocation = _container.Resolve<IRepositoryAsync<DoohPanelLocation>>().Find(doohPanelLocationId);
            if (doohPanelLocation == null) return true;

            return AuthorizationServiceExtensions.CanWriteDoohPanelLocation(this, doohPanelLocation.PartnerId); // note: this is an extension authorization
        }

        public string[] GetClaimValues(string claimType)
        {
            return _owinContext.Authentication.User.Claims.Where(x => x.Type == claimType && x.ValueType == ClaimValueTypes.String)
                .Select(x => x.Value)
                .ToArray();
        }
    }

    /// <summary>
    /// Extension methods contains authorization basing on claims
    /// </summary>
    public static class AuthorizationServiceExtensions
    {
        public static bool CanWriteSegment(this IAuthorizationService authorizationService, string rtbSegmentId)
        {
            if (authorizationService.CanAccessEverything()) return true;

            if (string.IsNullOrEmpty(rtbSegmentId)) return true;

            var prefixes = authorizationService.GetClaimValues(StandardClaimType.SegmentThirdPartyPrefix); // get prefixes from claims
            return prefixes.Any(x => rtbSegmentId == x || rtbSegmentId.StartsWith($"{x}:"));
        }

        public static bool CanWriteDoohPanelLocation(this IAuthorizationService authorizationService, int partnerId)
        {
            if (authorizationService.CanAccessEverything()) return true;

            var partnerIds = authorizationService.GetClaimValues(StandardClaimType.DoohPanelLocationOwner).Select(int.Parse);
            return partnerIds.Contains(partnerId);
        }
    }
}
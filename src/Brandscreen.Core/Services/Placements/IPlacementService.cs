using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Brandscreen.Core.Services.Campaigns;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Brandscreen.Framework.Services;
using LinqKit;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services.Placements
{
    public interface IPlacementService : IDependency
    {
        IQueryable<Placement> GetPlacements();
        IQueryable<Placement> GetPlacements(PlacementQueryOptions options);
        Task<Placement> GetPlacement(Guid id);

        Task ModifyPlacement(PlacementModifyOptions options);
    }

    public class PlacementService : IPlacementService
    {
        private readonly IRepositoryAsync<Placement> _placementRepositoryAsync;
        private readonly IStrategyService _strategyService;
        private readonly ICreativeService _creativeService;
        private readonly IClock _clock;
        private readonly IBrandscreenContext _brandscreenContext;

        private static readonly Expression<Func<Placement, bool>> PredicateNotDelete =
            x => !x.IsDeleted && x.PlacementStatusId != (int) CampaignStatusEnum.Deleted && !x.Creative.IsDeleted && !x.AdGroup.IsDeleted && !x.BuyerAccount.IsDeleted;

        public PlacementService(IRepositoryAsync<Placement> placementRepositoryAsync, IStrategyService strategyService, ICreativeService creativeService, IClock clock, IBrandscreenContext brandscreenContext)
        {
            _placementRepositoryAsync = placementRepositoryAsync;
            _strategyService = strategyService;
            _creativeService = creativeService;
            _clock = clock;
            _brandscreenContext = brandscreenContext;
        }

        public IQueryable<Placement> GetPlacements()
        {
            var source = _placementRepositoryAsync.Queryable()
                .Where(PredicateNotDelete);
            return source.OrderBy(x => x.PlacementId);
        }

        public IQueryable<Placement> GetPlacements(PlacementQueryOptions options)
        {
            var source = GetPlacements();

            if (options.BuyerAccountIds.Count > 0 || options.UserIds.Count > 0)
            {
                var predicate = PredicateBuilder.False<Placement>();
                if (options.BuyerAccountIds.Count > 0)
                {
                    // filter by BuyerAccountId when user is AgencyAdministrator
                    predicate = predicate.Or(x => options.BuyerAccountIds.Contains(x.BuyerAccountId));
                }
                if (options.UserIds.Count > 0)
                {
                    // filter by UserAdvertiserRoles when user is AgencyUser
                    var userPredicate = PredicateBuilder.True<Placement>()
                        .And(x => x.AdGroup.Campaign.AdvertiserProduct.Advertiser.UserAdvertiserRoles.Any(r => options.UserIds.Contains(r.UserId)))
                        .And(x => x.Creative.AdvertiserProduct.Advertiser.UserAdvertiserRoles.Any(r => options.UserIds.Contains(r.UserId)));
                    predicate = predicate.Or(userPredicate);
                }
                source = source.AsExpandable().Where(predicate);
            }

            if (options.StrategyUuid.HasValue)
            {
                source = source.Where(x => x.AdGroup.AdGroupUuid == options.StrategyUuid.Value);
            }

            if (options.CreativeUuid.HasValue)
            {
                source = source.Where(x => x.Creative.CreativeUuid == options.CreativeUuid.Value);
            }

            if (!string.IsNullOrEmpty(options.Text))
            {
                source = source.Where(x => x.AdGroup.AdGroupName.Contains(options.Text) || x.Creative.CreativeName.Contains(options.Text));
            }

            return source;
        }

        public Task<Placement> GetPlacement(Guid id)
        {
            var source = _placementRepositoryAsync.Queryable()
                .Where(PredicateNotDelete)
                .Include(x => x.BuyerAccount)
                .Include(x => x.AdGroup)
                .Include(x => x.Creative);
            return source.FirstOrDefaultAsync(x => x.PlacementUuid == id);
        }

        public async Task ModifyPlacement(PlacementModifyOptions options)
        {
            var placement = await _placementRepositoryAsync.Queryable()
                .FirstOrDefaultAsync(x => x.Creative.CreativeUuid == options.CreativeUuid && x.AdGroup.AdGroupUuid == options.StrategyUuid);

            if (options.IsLinking)
            {
                // link
                if (placement == null)
                {
                    // create
                    var creative = await _creativeService.GetCreative(options.CreativeUuid);
                    var strategy = await _strategyService.GetStrategy(options.StrategyUuid);
                    placement = new Placement
                    {
                        PlacementUuid = IdentityValue.GenerateNewId(),
                        CreativeId = creative.CreativeId,
                        AdGroupId = strategy.AdGroupId,
                        BuyerAccountId = strategy.BuyerAccountId,
                        PlacementStatusId = (int) CreativeStatusEnum.Live,
                        UtcCreatedDateTime = _clock.UtcNow,
                        UtcModifiedDateTime = _clock.UtcNow
                    };
                    _placementRepositoryAsync.Insert(placement);
                }
                else
                {
                    // update
                    placement.IsDeleted = false;
                    placement.PlacementStatusId = (int) CreativeStatusEnum.Live;
                    placement.UtcModifiedDateTime = _clock.UtcNow;
                    _placementRepositoryAsync.Update(placement);
                }
                await _brandscreenContext.SaveChangesAsync();
                return;
            }

            // unlink
            if (placement != null && (!placement.IsDeleted || placement.PlacementStatusId != (int) CampaignStatusEnum.Deleted))
            {
                placement.IsDeleted = true;
                placement.PlacementStatusId = (int) CampaignStatusEnum.Deleted;
                placement.UtcModifiedDateTime = _clock.UtcNow;
                _placementRepositoryAsync.Update(placement);
                await _brandscreenContext.SaveChangesAsync();
            }
        }
    }
}
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Brandscreen.Core.Services.Brands;
using Brandscreen.Core.Services.Campaigns;
using Brandscreen.Core.Services.Reports;
using Brandscreen.Core.Settings;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Brandscreen.Framework.Services;
using LinqKit;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services.Strategies
{
    public interface IStrategyService : IDependency
    {
        Task<AdGroup> GetStrategy(Guid id);
        IQueryable<AdGroup> GetStrategies();
        IQueryable<AdGroup> GetStrategies(StrategyQueryOptions options);

        Task CreateStrategy(AdGroup strategy);
        Task UpdateStrategy(StrategyUpdateOptions strategyUpdateOptions);
        Task DeleteStrategy(Guid id);
    }

    public class StrategyService : IStrategyService
    {
        private readonly IRepositoryAsync<AdGroup> _adGroupRepositoryAsync;
        private readonly IRepositoryAsync<Campaign> _campaignRepositoryAsync;
        private readonly IBrandscreenContext _brandscreenContext;
        private readonly IClock _clock;
        private readonly IStrategySettings _strategySettings;

        private static readonly Expression<Func<AdGroup, bool>> PredicateNotDelete =
            x => !x.IsDeleted && !x.Campaign.IsDeleted && !x.Campaign.AdvertiserProduct.IsDeleted && !x.Campaign.AdvertiserProduct.Advertiser.IsDeleted && !x.BuyerAccount.IsDeleted;

        public StrategyService(IRepositoryAsync<AdGroup> adGroupRepositoryAsync,
            IRepositoryAsync<Campaign> campaignRepositoryAsync,
            IBrandscreenContext brandscreenContext,
            IClock clock,
            IStrategySettings strategySettings)
        {
            _adGroupRepositoryAsync = adGroupRepositoryAsync;
            _campaignRepositoryAsync = campaignRepositoryAsync;
            _brandscreenContext = brandscreenContext;
            _clock = clock;
            _strategySettings = strategySettings;
        }

        public Task<AdGroup> GetStrategy(Guid id)
        {
            return _adGroupRepositoryAsync.Queryable()
                .Include(x => x.BuyerAccount)
                .Include(x => x.Campaign)
                .Include(x => x.Campaign.AdvertiserProduct)
                .Where(PredicateNotDelete)
                .FirstOrDefaultAsync(x => x.AdGroupUuid == id);
        }

        public IQueryable<AdGroup> GetStrategies()
        {
            var source = _adGroupRepositoryAsync.Queryable()
                .Where(PredicateNotDelete)
                .Include(x => x.Campaign)
                .OrderBy(x => x.AdGroupName);
            return source;
        }

        public IQueryable<AdGroup> GetStrategies(StrategyQueryOptions options)
        {
            var source = GetStrategies();

            if (options.BuyerAccountIds.Count > 0 || options.UserIds.Count > 0)
            {
                var predicate = PredicateBuilder.False<AdGroup>();
                if (options.BuyerAccountIds.Count > 0)
                {
                    // filter by BuyerAccountId when user is AgencyAdministrator
                    predicate = predicate.Or(x => options.BuyerAccountIds.Contains(x.BuyerAccountId));
                }
                if (options.UserIds.Count > 0)
                {
                    // filter by UserAdvertiserRoles when user is AgencyUser
                    predicate = predicate.Or(x => x.Campaign.AdvertiserProduct.Advertiser.UserAdvertiserRoles.Any(r => options.UserIds.Contains(r.UserId)));
                }
                source = source.AsExpandable().Where(predicate);
            }

            if (options.AdvertiserUuid.HasValue)
            {
                source = source.Where(x => x.Campaign.AdvertiserProduct.Advertiser.AdvertiserUuid == options.AdvertiserUuid.Value);
            }

            if (options.BrandUuid.HasValue)
            {
                source = source.Where(x => x.Campaign.AdvertiserProduct.AdvertiserProductUuid == options.BrandUuid.Value);
            }

            if (options.CampaignUuid.HasValue)
            {
                source = source.Where(x => x.Campaign.CampaignUuid == options.CampaignUuid.Value);
            }

            if (options.CreativeUuid.HasValue)
            {
                source = source.Where(x => x.Placements.Any(placement => !placement.IsDeleted && placement.PlacementStatusId != (int) CampaignStatusEnum.Deleted && placement.Creative.CreativeUuid == options.CreativeUuid.Value));
            }

            if (options.PartnerId.HasValue)
            {
                source = source.Where(x => x.AdGroupSupplySources.Any(adGroupSupplySource => adGroupSupplySource.PartnerId == options.PartnerId.Value));
            }

            if (options.StrategyStatusId.HasValue)
            {
                source = source.Where(x => x.AdGroupStatusId == options.StrategyStatusId.Value);
            }

            if (options.MediaTypeId.HasValue)
            {
                source = source.Where(x => x.MediaTypeId == options.MediaTypeId.Value);
            }

            if (!string.IsNullOrEmpty(options.Text))
            {
                source = source.Where(x => x.AdGroupName.Contains(options.Text));
            }

            return source;
        }

        public async Task CreateStrategy(AdGroup strategy)
        {
            strategy.AdGroupUuid = IdentityValue.GenerateNewId();
            strategy.AdGroupStatusId = (int) CampaignStatusEnum.Pending;
            strategy.UtcCreatedDateTime = _clock.UtcNow;

            strategy.UseBrandscreenVertical = true;
            strategy.BypassClassificationHide = false;

            strategy.UseLocalTimeBudgeting = true;
            strategy.UseLocalCurrencyBudgeting = true;

            // goal
            strategy.BudgetPeriodId = (int) StrategyTypeEnum.OngoingMonthly;
            strategy.GoalTypeId = (int) (strategy.MediaTypeId == (int) MediaTypeEnum.Dooh ? GoalTypeEnum.Impressions : GoalTypeEnum.Actions);
            strategy.PacingStyleId = (int) PacingStyleEnum.Evenly;
            strategy.PacingStyleOptionId = (int) PacingStyleEvenlyModeEnum.Normal;
            strategy.UtcOriginalStartDateTime = _clock.UtcNow;
            strategy.UtcStartDateTime = _clock.UtcNow;
            strategy.UtcEndDateTime = null;

            // constraint
            strategy.UniqueConstraintAmount = 0;
            strategy.UniqueConstraintPeriodId = (int) UniqueConstraintPeriodEnum.PerDay;
            strategy.SpendConstraintPeriodId = (int) PeriodTypeEnum.PerDay;

            // targetting mode
            strategy.LanguageTargetingMode = (int) TargetingActionEnum.Targeting;
            strategy.DeviceTargetingMode = (int) TargetingActionEnum.Targeting;
            strategy.DayPartTargetingMode = (int) TargetingActionEnum.Targeting;
            strategy.PagePositionTargetingMode = (int) TargetingActionEnum.Targeting;
            strategy.MobileCarrierTargetingMode = (int) TargetingActionEnum.Targeting;

            strategy.CountryTargetingMode = (int) TargetingActionEnum.Avoiding;
            strategy.RegionTargetingMode = (int) TargetingActionEnum.Avoiding;
            strategy.CityTargetingMode = (int) TargetingActionEnum.Avoiding;
            strategy.PostcodeTargetingMode = (int) TargetingActionEnum.Avoiding;
            strategy.DoohGeoLocationGroupTargetingMode = (int) TargetingActionEnum.Avoiding;

            strategy.Vertical1TargetingMode = (int) TargetingActionEnum.Avoiding;
            strategy.Vertical2TargetingMode = (int) TargetingActionEnum.Avoiding;
            strategy.Vertical3TargetingMode = (int) TargetingActionEnum.Avoiding;

            strategy.ExchangeTargetingMode = (int) TargetingActionEnum.Avoiding;
            strategy.SiteTargetingMode = (int) TargetingActionEnum.Avoiding;
            strategy.PublisherTargetingMode = (int) TargetingActionEnum.Avoiding;

            // brand safety
            var campaign = await _campaignRepositoryAsync.Queryable()
                .Include(x => x.BuyerAccount)
                .Include(x => x.AdvertiserProduct)
                .FirstAsync(x => x.CampaignId == strategy.CampaignId);
            if (campaign.AdvertiserProduct.BrandSafetyModeId != (int) BrandSafetyModeEnum.PageLevelSafety)
            {
                strategy.PageLevelBrandSafetyLevel = 0d;
            }
            else
            {
                strategy.PageLevelBrandSafetyLevel = Regex.IsMatch(campaign.BuyerAccount.CompanyName, _strategySettings.RegexBrandSafetyBypassingAccounts, RegexOptions.Compiled | RegexOptions.IgnoreCase)
                    ? _strategySettings.BrandSafetyLevelForBypassingAccounts
                    : 100d;
            }

            // optimisation
            strategy.UseBinomialFilter = false; // TODO:

            // save
            _adGroupRepositoryAsync.Insert(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task UpdateStrategy(StrategyUpdateOptions strategyUpdateOptions)
        {
            var strategy = strategyUpdateOptions.NewStrategy;
            var originalStrategy = await _adGroupRepositoryAsync.Queryable()
                .Include(x => x.BuyerAccount)
                .Include(x => x.AdGroupPerformances)
                .FirstAsync(x => x.AdGroupUuid == strategy.AdGroupUuid);

            if (strategy.BudgetAmount != originalStrategy.BudgetAmount)
            {
                var currencyId = originalStrategy.BuyerAccount.CurrencyId.GetValueOrDefault(0);
                var maxBudgetAmount = MonetaryValueHelper.GetMaxBudgetAmount(currencyId);
                if (strategy.BudgetAmount > maxBudgetAmount)
                {
                    throw new BrandscreenException($"BudgetAmount cannot exceed {maxBudgetAmount}.");
                }

                var interval = ((StrategyTypeEnum) originalStrategy.BudgetPeriodId).ToTimeSpan().ToInterval();
                var intervalValue = _clock.UtcNow.ToLocalTime().ToIntervalValue(interval);
                var adGroupPerformance = originalStrategy.AdGroupPerformances.FirstOrDefault(x => x.IntervalId == (int) interval && x.IntervalValue == intervalValue) ?? new AdGroupPerformance();
                var spend = adGroupPerformance.SpendLocalMicros.MicrosToDollars();
                if (strategy.BudgetAmount < spend)
                {
                    throw new BrandscreenException($"BudgetAmount cannot be less than spend amount {spend}.");
                }
            }

            // save
            strategy.UtcModifiedDateTime = _clock.UtcNow;
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task DeleteStrategy(Guid id)
        {
            var strategy = await GetStrategy(id);
            strategy.IsDeleted = true;
            strategy.UtcModifiedDateTime = _clock.UtcNow;
            _adGroupRepositoryAsync.Update(strategy);
            await _brandscreenContext.SaveChangesAsync();
        }
    }
}
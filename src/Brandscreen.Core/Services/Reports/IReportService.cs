using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using Brandscreen.Analytics.Entities;
using Brandscreen.Framework;
using Repository.Pattern.Ef6;
using Repository.Pattern.UnitOfWork;

namespace Brandscreen.Core.Services.Reports
{
    public interface IReportService : IDependency
    {
        Task<IReport> GetAdvertiserReport(ReportCriteria reportCriteria);
        Task<IReport> GetBrandReport(ReportCriteria reportCriteria);
        Task<IReport> GetCampaignReport(ReportCriteria reportCriteria);
        Task<IReport> GetStrategyReport(ReportCriteria reportCriteria);
    }

    public class ReportService : IReportService
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public ReportService(IIndex<Type, IUnitOfWorkAsync> unitOfWorkIndex)
        {
            _unitOfWork = unitOfWorkIndex[typeof (IBrandscreenAnalyticsContext)];
        }

        public async Task<IReport> GetAdvertiserReport(ReportCriteria reportCriteria)
        {
            var source = GetReportSouce<AdAnalyticsReportId>();
            source = source.FilterBy(reportCriteria);

            if (reportCriteria.Level == ReportLevelEnum.Daily)
            {
                return (await source.GroupBy(x => new
                {
                    Date = x.LocalDate,
                    x.AdvertiserId,
                    x.AdvertiserName,
                }).ToListAsync())
                    .AggregateReport()
                    .OrderBy(x => x.KeyData.Date)
                    .ThenBy(x => x.KeyData.AdvertiserName)
                    .ToReport(reportCriteria);
            }

            // summary
            return (await source.GroupBy(x => new
            {
                x.AdvertiserId,
                x.AdvertiserName,
            }).ToListAsync())
                .AggregateReport()
                .OrderBy(x => x.KeyData.AdvertiserName)
                .ToReport(reportCriteria);
        }

        public async Task<IReport> GetBrandReport(ReportCriteria reportCriteria)
        {
            var source = GetReportSouce<AdAnalyticsReportId>();
            source = source.FilterBy(reportCriteria);

            if (reportCriteria.Level == ReportLevelEnum.Daily)
            {
                return (await source.GroupBy(x => new
                {
                    Date = x.LocalDate,
                    x.AdvertiserId,
                    x.AdvertiserName,
                    BrandId = x.AdvertiserProductId,
                    BrandName = x.ProductName,
                }).ToListAsync())
                    .AggregateReport()
                    .OrderBy(x => x.KeyData.Date)
                    .ThenBy(x => x.KeyData.AdvertiserName)
                    .ThenBy(x => x.KeyData.BrandName)
                    .ToReport(reportCriteria);
            }

            // summary
            return (await source.GroupBy(x => new
            {
                x.AdvertiserId,
                x.AdvertiserName,
                BrandId = x.AdvertiserProductId,
                BrandName = x.ProductName,
            }).ToListAsync())
                .AggregateReport()
                .OrderBy(x => x.KeyData.AdvertiserName)
                .ThenBy(x => x.KeyData.BrandName)
                .ToReport(reportCriteria);
        }

        public async Task<IReport> GetCampaignReport(ReportCriteria reportCriteria)
        {
            var source = GetReportSouce<AdAnalyticsReportId>();
            source = source.FilterBy(reportCriteria);

            if (reportCriteria.Level == ReportLevelEnum.Daily)
            {
                return (await source.GroupBy(x => new
                {
                    Date = x.LocalDate,
                    x.AdvertiserId,
                    x.AdvertiserName,
                    BrandId = x.AdvertiserProductId,
                    BrandName = x.ProductName,
                    x.CampaignId,
                    x.CampaignName,
                }).ToListAsync())
                    .AggregateReport()
                    .OrderBy(x => x.KeyData.Date)
                    .ThenBy(x => x.KeyData.AdvertiserName)
                    .ThenBy(x => x.KeyData.BrandName)
                    .ThenBy(x => x.KeyData.CampaignName)
                    .ToReport(reportCriteria);
            }

            // summary
            return (await source.GroupBy(x => new
            {
                x.AdvertiserId,
                x.AdvertiserName,
                BrandId = x.AdvertiserProductId,
                BrandName = x.ProductName,
                x.CampaignId,
                x.CampaignName,
            }).ToListAsync())
                .AggregateReport()
                .OrderBy(x => x.KeyData.AdvertiserName)
                .ThenBy(x => x.KeyData.BrandName)
                .ThenBy(x => x.KeyData.CampaignName)
                .ToReport(reportCriteria);
        }

        public async Task<IReport> GetStrategyReport(ReportCriteria reportCriteria)
        {
            var source = GetReportSouce<AdAnalyticsReportId>();
            source = source.FilterBy(reportCriteria);

            if (reportCriteria.Level == ReportLevelEnum.Daily)
            {
                // daily
                return (await source.GroupBy(x => new
                {
                    Date = x.LocalDate,
                    StrategyName = x.AdGroupName,
                    StrategyId = x.AdGroupId,
                    x.AdvertiserId,
                    x.AdvertiserName,
                    BrandId = x.AdvertiserProductId,
                    BrandName = x.ProductName,
                    x.CampaignId,
                    x.CampaignName,
                    x.CampaignStatusName
                }).ToListAsync())
                    .AggregateReport()
                    .OrderBy(x => x.KeyData.Date)
                    .ThenBy(x => x.KeyData.AdvertiserName)
                    .ThenBy(x => x.KeyData.BrandName)
                    .ThenBy(x => x.KeyData.CampaignName)
                    .ThenBy(x => x.KeyData.StrategyName)
                    .ToReport(reportCriteria);
            }

            // summary
            return (await source.GroupBy(x => new
            {
                StrategyName = x.AdGroupName,
                StrategyId = x.AdGroupId,
                x.AdvertiserId,
                x.AdvertiserName,
                BrandId = x.AdvertiserProductId,
                BrandName = x.ProductName,
                x.CampaignId,
                x.CampaignName,
                x.CampaignStatusName
            }).ToListAsync())
                .AggregateReport()
                .OrderBy(x => x.KeyData.AdvertiserName)
                .ThenBy(x => x.KeyData.BrandName)
                .ThenBy(x => x.KeyData.CampaignName)
                .ThenBy(x => x.KeyData.StrategyName)
                .ToReport(reportCriteria);
        }

        private IQueryable<T> GetReportSouce<T>() where T : Entity
        {
            var repository = _unitOfWork.RepositoryAsync<T>();
            var source = repository.Queryable();
            return source;
        }
    }
}
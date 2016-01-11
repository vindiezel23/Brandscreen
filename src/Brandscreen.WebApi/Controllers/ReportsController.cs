using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Brandscreen.Core.Services.Reports;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Mappings;
using Castle.Core.Logging;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Report management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/reports")]
    public class ReportsController : ApiController
    {
        private readonly IMappingEngine _mapping;
        private readonly IReportService _reportService;

        public ReportsController(IMappingEngine mapping, IReportService reportService)
        {
            _mapping = mapping;
            _reportService = reportService;

            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        /// <summary>
        /// Retrieves advertiser report.
        /// </summary>
        [HttpGet]
        [Route("advertisers/{reportLevel=summary}/{reportScope=null}/{reportScopeId=null}")]
        public async Task<ReportViewModel> GetAdvertiserReport([FromUri] ReportCriteriaViewModel reportCriteriaViewModel)
        {
            var reportCriteria = _mapping.Map<ReportCriteria>(reportCriteriaViewModel);
            reportCriteria.Type = ReportTypeEnum.Advertiser;
            var report = await _reportService.GetAdvertiserReport(reportCriteria).ConfigureAwait(false);
            return _mapping.Map<ReportViewModel>(report, reportCriteriaViewModel);
        }

        /// <summary>
        /// Retrieves brand report.
        /// </summary>
        [HttpGet]
        [Route("brands/{reportLevel=summary}/{reportScope=null}/{reportScopeId=null}")]
        public async Task<ReportViewModel> GetBrandReport([FromUri] ReportCriteriaViewModel reportCriteriaViewModel)
        {
            var reportCriteria = _mapping.Map<ReportCriteria>(reportCriteriaViewModel);
            reportCriteria.Type = ReportTypeEnum.Brand;
            var report = await _reportService.GetBrandReport(reportCriteria).ConfigureAwait(false);
            return _mapping.Map<ReportViewModel>(report, reportCriteriaViewModel);
        }

        /// <summary>
        /// Retrieves campaign report.
        /// </summary>
        [HttpGet]
        [Route("campaigns/{reportLevel=summary}/{reportScope=null}/{reportScopeId=null}")]
        public async Task<ReportViewModel> GetCampaignReport([FromUri] ReportCriteriaViewModel reportCriteriaViewModel)
        {
            var reportCriteria = _mapping.Map<ReportCriteria>(reportCriteriaViewModel);
            reportCriteria.Type = ReportTypeEnum.Campaign;
            var report = await _reportService.GetCampaignReport(reportCriteria).ConfigureAwait(false);
            return _mapping.Map<ReportViewModel>(report, reportCriteriaViewModel);
        }

        /// <summary>
        /// Retrieves strategy report.
        /// </summary>
        [HttpGet]
        [Route("strategies/{reportLevel=summary}/{reportScope=null}/{reportScopeId=null}")]
        public async Task<ReportViewModel> GetStrategyReport([FromUri] ReportCriteriaViewModel reportCriteriaViewModel)
        {
            var reportCriteria = _mapping.Map<ReportCriteria>(reportCriteriaViewModel);
            reportCriteria.Type = ReportTypeEnum.Strategy;
            var report = await _reportService.GetStrategyReport(reportCriteria).ConfigureAwait(false);
            return _mapping.Map<ReportViewModel>(report, reportCriteriaViewModel);
        }
    }
}
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac;
using Autofac.Integration.WebApi;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Reports;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Castle.Core.Logging;

namespace Brandscreen.WebApi.Filters
{
    public class ReportsActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public ReportsActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;

            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            // check if request is from god
            if (_authorizationService.CanAccessEverything()) return;

            // check if scope is set
            var model = actionContext.ActionArguments["reportCriteriaViewModel"] as ReportCriteriaViewModel;
            if (model == null) return;
            if (!model.ReportScope.HasValue || !model.ReportScopeId.HasValue)
            {
                model.ReportScope = null;
                model.ReportScopeId = null;
                return;
            }

            // check buyer role against scope
            switch (model.ReportScope.Value)
            {
                case ReportScopeEnum.Buyer:
                    if (!_authorizationService.CanReadBuyerAccount(model.ReportScopeId.Value))
                    {
                        actionContext.SetUnauthorizedResponse();
                    }
                    break;
                case ReportScopeEnum.Advertiser:
                {
                    if (!_authorizationService.CanReadAdvertiser(model.ReportScopeId.Value))
                    {
                        actionContext.SetUnauthorizedResponse();
                    }
                    break;
                }
                case ReportScopeEnum.Brand:
                {
                    if (!_authorizationService.CanReadBrand(model.ReportScopeId.Value))
                    {
                        actionContext.SetUnauthorizedResponse();
                    }
                    break;
                }
                case ReportScopeEnum.Campaign:
                {
                    if (!_authorizationService.CanReadCampaign(model.ReportScopeId.Value))
                    {
                        actionContext.SetUnauthorizedResponse();
                    }
                    break;
                }
                case ReportScopeEnum.Strategy:
                {
                    if (!_authorizationService.CanReadStrategy(model.ReportScopeId.Value))
                    {
                        actionContext.SetUnauthorizedResponse();
                    }
                    break;
                }
            }
        }

        public void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
        }

        /// <summary>
        /// Autofac Module
        /// </summary>
        public class FilterModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                // path: api/reports*
                builder.RegisterType<ReportsActionFilter>()
                    .AsWebApiActionFilterFor<ReportsController>()
                    .InstancePerLifetimeScope();
            }
        }
    }
}
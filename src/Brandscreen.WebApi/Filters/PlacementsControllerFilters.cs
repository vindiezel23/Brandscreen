using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac;
using Autofac.Integration.WebApi;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Microsoft.Owin;

namespace Brandscreen.WebApi.Filters
{
    public class PlacementsGetListAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IOwinContext _owinContext;
        private readonly IAuthorizationService _authorizationService;

        public PlacementsGetListAuthorizationFilter(IOwinContext owinContext, IAuthorizationService authorizationService)
        {
            _owinContext = owinContext;
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var currentUserId = _owinContext.GetCurrentUserId();
            var userId = actionContext.GetOrSetQueryString("userId", currentUserId);
            if (!_authorizationService.CanReadUser(userId))
            {
                actionContext.SetUnauthorizedResponse();
                return;
            }

            var queryString = actionContext.Request.RequestUri.ParseQueryString();

            Guid buyerAccountUuid;
            var hasBuyerAccountUuid = Guid.TryParse(queryString["buyerAccountUuid"], out buyerAccountUuid);
            if (hasBuyerAccountUuid && !_authorizationService.CanReadBuyerAccount(buyerAccountUuid))
            {
                actionContext.SetUnauthorizedResponse();
                return;
            }

            Guid strategyUuidUuid;
            var hasStrategyUuidUuid = Guid.TryParse(queryString["strategyUuid"], out strategyUuidUuid);
            if (hasStrategyUuidUuid && !_authorizationService.CanReadStrategy(strategyUuidUuid))
            {
                actionContext.SetUnauthorizedResponse();
                return;
            }

            Guid campaignUuid;
            var hasCampaignUuid = Guid.TryParse(queryString["campaignUuid"], out campaignUuid);
            if (hasCampaignUuid && !_authorizationService.CanReadCampaign(campaignUuid))
            {
                actionContext.SetUnauthorizedResponse();
            }
        }

        /// <summary>
        /// Autofac Module
        /// </summary>
        public class FilterModule : Module
        {
#pragma warning disable 4014
            protected override void Load(ContainerBuilder builder)
            {
                // path: GET api/placements
                builder.RegisterType<PlacementsGetListAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<PlacementsController>(x => x.Get(default(PlacementQueryViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class PlacementsGetDetailAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public PlacementsGetDetailAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var placementUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanReadPlacement(placementUuid))
            {
                actionContext.SetUnauthorizedResponse();
            }
        }

        /// <summary>
        /// Autofac Module
        /// </summary>
        public class FilterModule : Module
        {
#pragma warning disable 4014
            protected override void Load(ContainerBuilder builder)
            {
                // path: GET api/placements/{id:guid}
                builder.RegisterType<PlacementsGetDetailAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<PlacementsController>(x => x.Get(default(Guid)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class PlacementsPutActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public PlacementsPutActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as PlacementPutViewModel;
            if (model?.StrategyUuid != null)
            {
                if (!_authorizationService.CanWriteStrategy(model.StrategyUuid.Value))
                {
                    actionContext.SetUnauthorizedResponse();
                    return;
                }
            }

            if (model?.CreativeUuid != null)
            {
                if (!_authorizationService.CanWriteCreative(model.CreativeUuid.Value))
                {
                    actionContext.SetUnauthorizedResponse();
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
#pragma warning disable 4014
            protected override void Load(ContainerBuilder builder)
            {
                // path: PUT api/placements
                builder.RegisterType<PlacementsPutActionFilter>()
                    .AsWebApiActionFilterFor<PlacementsController>(x => x.Put(default(PlacementPutViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }
}
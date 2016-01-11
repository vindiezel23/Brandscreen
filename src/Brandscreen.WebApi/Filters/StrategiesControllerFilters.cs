using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac;
using Autofac.Integration.WebApi;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Microsoft.Owin;

namespace Brandscreen.WebApi.Filters
{
    public class StrategiesGetListAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IOwinContext _owinContext;
        private readonly IAuthorizationService _authorizationService;

        public StrategiesGetListAuthorizationFilter(IOwinContext owinContext, IAuthorizationService authorizationService)
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

            Guid advertiserUuid;
            var hasAdvertiserUuid = Guid.TryParse(queryString["advertiserUuid"], out advertiserUuid);
            if (hasAdvertiserUuid && !_authorizationService.CanReadAdvertiser(advertiserUuid))
            {
                actionContext.SetUnauthorizedResponse();
                return;
            }

            Guid brandUuid;
            var hasBrandUuid = Guid.TryParse(queryString["brandUuid"], out brandUuid);
            if (hasBrandUuid && !_authorizationService.CanReadBrand(brandUuid))
            {
                actionContext.SetUnauthorizedResponse();
                return;
            }

            Guid campaignUuid;
            var hasCampaignUuid = Guid.TryParse(queryString["campaignUuid"], out campaignUuid);
            if (hasCampaignUuid && !_authorizationService.CanReadCampaign(campaignUuid))
            {
                actionContext.SetUnauthorizedResponse();
                return;
            }

            Guid creativeUuid;
            var hasCreativeUuid = Guid.TryParse(queryString["creativeUuid"], out creativeUuid);
            if (hasCreativeUuid && !_authorizationService.CanReadCreative(creativeUuid))
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
                // path: GET api/strategies
                builder.RegisterType<StrategiesGetListAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.Get(default(StrategyQueryViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class StrategiesGetDetailAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public StrategiesGetDetailAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var strategyUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanReadStrategy(strategyUuid))
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
                // path: GET api/strategies/{id:guid}
                builder.RegisterType<StrategiesGetDetailAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.Get(default(Guid)))
                    .InstancePerLifetimeScope();

                // path: GET api/strategies/{id:guid}/targetings
                builder.RegisterType<StrategiesGetDetailAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.GetTargetings(default(Guid)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class StrategiesPostActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public StrategiesPostActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as StrategyCreateViewModel;
            if (model?.CampaignUuid != null)
            {
                if (!_authorizationService.CanWriteCampaign(model.CampaignUuid.Value))
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
                // path: POST api/strategies
                builder.RegisterType<StrategiesPostActionFilter>()
                    .AsWebApiActionFilterFor<StrategiesController>(x => x.Post(default(StrategyCreateViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class StrategiesPatchActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public StrategiesPatchActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var strategyUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanWriteStrategy(strategyUuid))
            {
                actionContext.SetUnauthorizedResponse();
                return;
            }

            var model = actionContext.ActionArguments["model"] as StrategyPatchViewModel;
            if (model != null)
            {
                if (model.PacingStyleId == (int) PacingStyleEnum.Unrestrained ||
                    model.UsePacing.HasValue ||
                    model.UsePricing.HasValue ||
                    model.PacingVersion.HasValue ||
                    model.PricingVersion.HasValue)
                {
                    if (!_authorizationService.CanAccessEverything())
                    {
                        // only god can update these values
                        actionContext.SetUnauthorizedResponse();
                    }
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
                // path: PATCH api/strategies/{id:guid}
                builder.RegisterType<StrategiesPatchActionFilter>()
                    .AsWebApiActionFilterFor<StrategiesController>(x => x.Patch(default(Guid), default(StrategyPatchViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class StrategiesPutTargetingsAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public StrategiesPutTargetingsAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var strategyUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanWriteStrategy(strategyUuid))
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
                // path: PUT api/strategies/{id:guid}/targetings/countries
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutTargetingCountries(default(Guid), default(StrategyTargetingCountryPutViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/strategies/{id:guid}/targetings/regions
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutTargetingRegions(default(Guid), default(StrategyTargetingRegionPutViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/strategies/{id:guid}/targetings/cities
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutTargetingCities(default(Guid), default(StrategyTargetingCityPutViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/strategies/{id:guid}/targetings/postcodes
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutTargetingPostcodes(default(Guid), default(StrategyTargetingPostcodePutViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/strategies/{id:guid}/targetings/locations
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutTargetingDoohGeoLocations(default(Guid), default(StrategyTargetingDoohGeoLocationPutViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/strategies/{id:guid}/targetings/languages
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutTargetingLanguages(default(Guid), default(StrategyTargetingLanguagePutViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/strategies/{id:guid}/targetings/verticals
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutTargetingVerticals(default(Guid), default(StrategyTargetingVerticalPutViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/strategies/{id:guid}/targetings/partners
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutTargetingPartners(default(Guid), default(StrategyTargetingPartnerPutViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/strategies/{id:guid}/targetings/doohpanellocations
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutDoohPanelLocations(default(Guid), default(StrategyTargetingDoohPanelLocationPutViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/strategies/{id:guid}/targetings/publishers
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutTargetingPublishers(default(Guid), default(StrategyTargetingPublisherPutViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/strategies/{id:guid}/targetings/domainlists
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutTargetingDomainLists(default(Guid), default(StrategyTargetingDomainListPutViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/strategies/{id:guid}/targetings/segments
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutTargetingSegments(default(Guid), default(StrategyTargetingSegmentPutViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/strategies/{id:guid}/targetings/devices
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutTargetingDevices(default(Guid), default(StrategyTargetingDevicePutViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/strategies/{id:guid}/targetings/mobilecarriers
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutTargetingMobileCarriers(default(Guid), default(StrategyTargetingMobileCarrierPutViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/strategies/{id:guid}/targetings/dayparts
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutTargetingDayParts(default(Guid), default(StrategyTargetingDayPartPutViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/strategies/{id:guid}/targetings/pagepositions
                builder.RegisterType<StrategiesPutTargetingsAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<StrategiesController>(x => x.PutTargetingPagePositions(default(Guid), default(StrategyTargetingPagePositionPutViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class StrategiesPutTargetingDomainListsActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public StrategiesPutTargetingDomainListsActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as StrategyTargetingDomainListPutViewModel;
            if (model?.Targetings == null) return;

            var domainListIds = model.Targetings.Select(x => x.Id);
            if (domainListIds.Any(domainListId => !_authorizationService.CanReadDomainList(domainListId)))
            {
                actionContext.SetUnauthorizedResponse();
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
                // path: PUT api/strategies/{id:guid}/targetings/domainlists
                builder.RegisterType<StrategiesPutTargetingDomainListsActionFilter>()
                    .AsWebApiActionFilterFor<StrategiesController>(x => x.PutTargetingDomainLists(default(Guid), default(StrategyTargetingDomainListPutViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class StrategiesPutTargetingSegmentsActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public StrategiesPutTargetingSegmentsActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as StrategyTargetingDomainListPutViewModel;
            if (model?.Targetings == null) return;

            var segmentIds = model.Targetings.Select(x => x.Id);
            if (segmentIds.Any(segmentId => !_authorizationService.CanReadSegment(segmentId)))
            {
                actionContext.SetUnauthorizedResponse();
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
                // path: PUT api/strategies/{id:guid}/targetings/segments
                builder.RegisterType<StrategiesPutTargetingDomainListsActionFilter>()
                    .AsWebApiActionFilterFor<StrategiesController>(x => x.PutTargetingSegments(default(Guid), default(StrategyTargetingSegmentPutViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }
}
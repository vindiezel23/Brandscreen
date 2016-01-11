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
    public class CampaignsGetListAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IOwinContext _owinContext;
        private readonly IAuthorizationService _authorizationService;

        public CampaignsGetListAuthorizationFilter(IOwinContext owinContext, IAuthorizationService authorizationService)
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
                // path: GET api/campaigns
                builder.RegisterType<CampaignsGetListAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<CampaignsController>(x => x.Get(default(CampaignQueryViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class CampaignsGetDetailAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public CampaignsGetDetailAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var campaignUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanReadCampaign(campaignUuid))
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
                // path: GET api/campaigns/{id:guid}
                builder.RegisterType<CampaignsGetDetailAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<CampaignsController>(x => x.Get(default(Guid)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class CampaignsPostActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public CampaignsPostActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as CampaignCreateViewModel;
            if (model?.BrandUuid != null)
            {
                if (!_authorizationService.CanWriteBrand(model.BrandUuid.Value))
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
                // path: POST api/campaigns
                builder.RegisterType<CampaignsPostActionFilter>()
                    .AsWebApiActionFilterFor<CampaignsController>(x => x.Post(default(CampaignCreateViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class CampaignsPatchDeleteAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public CampaignsPatchDeleteAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var campaignUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanWriteCampaign(campaignUuid))
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
                // path: PATCH api/campaigns/{id:guid}
                builder.RegisterType<CampaignsPatchDeleteAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<CampaignsController>(x => x.Patch(default(Guid), default(CampaignPatchViewModel)))
                    .InstancePerLifetimeScope();

                // path: DELETE api/campaigns/{id:guid}
                builder.RegisterType<CampaignsPatchDeleteAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<BrandsController>(x => x.Delete(default(Guid)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }
}
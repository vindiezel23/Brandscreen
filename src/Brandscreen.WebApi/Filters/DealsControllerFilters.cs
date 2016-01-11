using System;
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
    public class DealsGetListAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IOwinContext _owinContext;

        public DealsGetListAuthorizationFilter(IAuthorizationService authorizationService, IOwinContext owinContext)
        {
            _authorizationService = authorizationService;
            _owinContext = owinContext;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            // allowing super/system admin queries anything
            if (_authorizationService.CanAccessEverything()) return;

            // default to current user
            var currentUserId = _owinContext.GetCurrentUserId();
            var userId = actionContext.GetOrSetQueryString("userId", currentUserId);
            if (!_authorizationService.CanReadUser(userId))
            {
                actionContext.SetUnauthorizedResponse();
            }

            var buyerAccountUuid = actionContext.GetQueryString<Guid?>("buyerAccountUuid");
            if (buyerAccountUuid.HasValue && !_authorizationService.CanReadBuyerAccount(buyerAccountUuid.Value))
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
                // path: GET api/deals
                builder.RegisterType<DealsGetListAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<DealsController>(x => x.Get(default(DealQueryViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class DealsGetDetailAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public DealsGetDetailAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var dealUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanReadDeal(dealUuid))
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
                // path: GET api/deals/{id:guid}
                builder.RegisterType<DealsGetDetailAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<DealsController>(x => x.Get(default(Guid)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class DealsPostActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public DealsPostActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as DealCreateViewModel;
            if (model?.BuyerAccountUuid != null)
            {
                if (!_authorizationService.CanWriteBuyerAccount(model.BuyerAccountUuid.Value))
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
                // path: POST api/deals
                builder.RegisterType<DealsPostActionFilter>()
                    .AsWebApiActionFilterFor<DealsController>(x => x.Post(default(DealCreateViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class DealsPatchDeleteAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public DealsPatchDeleteAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var dealUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanWriteAdvertiser(dealUuid))
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
                // path: PATCH api/deals/{id:guid}
                builder.RegisterType<DealsPatchDeleteAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<DealsController>(x => x.Patch(default(Guid), default(DealPatchViewModel)))
                    .InstancePerLifetimeScope();

                // path: DELETE api/deals/{id:guid}
                builder.RegisterType<DealsPatchDeleteAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<DealsController>(x => x.Delete(default(Guid)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }
}
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
    public class AdvertisersGetListAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IOwinContext _owinContext;
        private readonly IAuthorizationService _authorizationService;

        public AdvertisersGetListAuthorizationFilter(IOwinContext owinContext, IAuthorizationService authorizationService)
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
                // path: GET api/advertisers
                builder.RegisterType<AdvertisersGetListAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<AdvertisersController>(x => x.Get(default(AdvertiserQueryViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class AdvertisersGetDetailAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public AdvertisersGetDetailAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var advertiserUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanReadAdvertiser(advertiserUuid))
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
                // path: GET api/advertisers/{id:guid}
                builder.RegisterType<AdvertisersGetDetailAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<AdvertisersController>(x => x.Get(default(Guid)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class AdvertisersPatchDeleteAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public AdvertisersPatchDeleteAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var advertiserUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanWriteAdvertiser(advertiserUuid))
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
                // path: PATCH api/advertisers/{id:guid}
                builder.RegisterType<AdvertisersPatchDeleteAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<AdvertisersController>(x => x.Patch(default(Guid), default(AdvertiserPatchViewModel)))
                    .InstancePerLifetimeScope();

                // path: DELETE api/advertisers/{id:guid}
                builder.RegisterType<AdvertisersPatchDeleteAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<AdvertisersController>(x => x.Delete(default(Guid)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class AdvertisersPostActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public AdvertisersPostActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as AdvertiserCreateViewModel;
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
                // path: POST api/advertisers
                builder.RegisterType<AdvertisersPostActionFilter>()
                    .AsWebApiActionFilterFor<AdvertisersController>(x => x.Post(default(AdvertiserCreateViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }
}
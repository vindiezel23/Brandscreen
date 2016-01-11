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
    public class BrandsGetListAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IOwinContext _owinContext;

        public BrandsGetListAuthorizationFilter(IOwinContext owinContext, IAuthorizationService authorizationService)
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
                // path: GET api/brands
                builder.RegisterType<BrandsGetListAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<BrandsController>(x => x.Get(default(BrandQueryViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class BrandsGetDetailAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public BrandsGetDetailAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var brandUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanReadBrand(brandUuid))
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
                // path: GET api/brands/{id:guid}
                builder.RegisterType<BrandsGetDetailAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<BrandsController>(x => x.Get(default(Guid)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class BrandsPostActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public BrandsPostActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as BrandCreateViewModel;
            if (model?.AdvertiserUuid != null)
            {
                if (!_authorizationService.CanWriteAdvertiser(model.AdvertiserUuid.Value))
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
                // path: POST api/brands
                builder.RegisterType<BrandsPostActionFilter>()
                    .AsWebApiActionFilterFor<BrandsController>(x => x.Post(default(BrandCreateViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class BrandsPatchDeleteAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public BrandsPatchDeleteAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var brandUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanWriteBrand(brandUuid))
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
                // path: PATCH api/brands/{id:guid}
                builder.RegisterType<BrandsPatchDeleteAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<BrandsController>(x => x.Patch(default(Guid), default(BrandPatchViewModel)))
                    .InstancePerLifetimeScope();

                // path: DELETE api/brands/{id:guid}
                builder.RegisterType<BrandsPatchDeleteAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<BrandsController>(x => x.Delete(default(Guid)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }
}
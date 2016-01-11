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
    public class CreativesGetListAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IOwinContext _owinContext;
        private readonly IAuthorizationService _authorizationService;

        public CreativesGetListAuthorizationFilter(IOwinContext owinContext, IAuthorizationService authorizationService)
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

            Guid strategyUuid;
            var hasStrategyUuid = Guid.TryParse(queryString["strategyUuid"], out strategyUuid);
            if (hasStrategyUuid && !_authorizationService.CanReadStrategy(strategyUuid))
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
                // path: GET api/creatives
                builder.RegisterType<CreativesGetListAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<CreativesController>(x => x.Get(default(CreativeQueryViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class CreativesGetDetailAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public CreativesGetDetailAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var creativeUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanReadCreative(creativeUuid))
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
                // path: GET api/creatives/{id:guid}
                builder.RegisterType<CreativesGetDetailAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<CreativesController>(x => x.Get(default(Guid)))
                    .InstancePerLifetimeScope();

                // path: GET api/creatives/{id:guid}/parameters
                builder.RegisterType<CreativesGetDetailAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<CreativesController>(x => x.GetParameters(default(Guid)))
                    .InstancePerLifetimeScope();

                // path: GET api/creatives/{id:guid}/reviews
                builder.RegisterType<CreativesGetDetailAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<CreativesController>(x => x.GetReviews(default(Guid)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class CreativesPostActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public CreativesPostActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as CreativeCreateViewModel;
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
                // path: POST api/creatives
                builder.RegisterType<CreativesPostActionFilter>()
                    .AsWebApiActionFilterFor<CreativesController>(x => x.Post(default(CreativeCreateViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class CreativesPostDoohActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public CreativesPostDoohActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var actionArgument = actionContext.ActionArguments["model"];
            var brandUuid = (actionArgument as CreativeDoohCreateViewModel)?.BrandUuid ??
                            (actionArgument as CreativeDoohVideoCreateViewModel)?.BrandUuid ??
                            (actionArgument as CreativeDoohVideoUrlCreateViewModel)?.BrandUuid;
            if (brandUuid != null)
            {
                if (!_authorizationService.CanWriteBrand(brandUuid.Value))
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
                // path: POST api/creatives/dooh
                builder.RegisterType<CreativesPostDoohActionFilter>()
                    .AsWebApiActionFilterFor<CreativesController>(x => x.PostDooh(default(CreativeDoohCreateViewModel)))
                    .InstancePerLifetimeScope();

                // path: POST api/creatives/dooh/video
                builder.RegisterType<CreativesPostDoohActionFilter>()
                    .AsWebApiActionFilterFor<CreativesController>(x => x.PostDoohVideo(default(CreativeDoohVideoCreateViewModel)))
                    .InstancePerLifetimeScope();

                // path: POST api/creatives/dooh/videourl
                builder.RegisterType<CreativesPostDoohActionFilter>()
                    .AsWebApiActionFilterFor<CreativesController>(x => x.PostDoohVideoUrl(default(CreativeDoohVideoUrlCreateViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class CreativesPostVastActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public CreativesPostVastActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as CreativeVastCreateViewModel;
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
                // path: POST api/creatives/vast
                builder.RegisterType<CreativesPostVastActionFilter>()
                    .AsWebApiActionFilterFor<CreativesController>(x => x.PostVast(default(CreativeVastCreateViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class CreativesPostSwiffyActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public CreativesPostSwiffyActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as CreativeSwiffyCreateViewModel;
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
                // path: POST api/creatives/swiffy
                builder.RegisterType<CreativesPostSwiffyActionFilter>()
                    .AsWebApiActionFilterFor<CreativesController>(x => x.PostSwiffy(default(CreativeSwiffyCreateViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class CreativesPostHtml5ActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public CreativesPostHtml5ActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as CreativeHtml5CreateViewModel;
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
                // path: POST api/creatives/html5
                builder.RegisterType<CreativesPostHtml5ActionFilter>()
                    .AsWebApiActionFilterFor<CreativesController>(x => x.PostHtml5(default(CreativeHtml5CreateViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class CreativesPostAdTagActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public CreativesPostAdTagActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as CreativeAdTagCreateViewModel;
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
                // path: POST api/creatives/adtag
                builder.RegisterType<CreativesPostAdTagActionFilter>()
                    .AsWebApiActionFilterFor<CreativesController>(x => x.PostAdTag(default(CreativeAdTagCreateViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class CreativesPatchDeleteAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public CreativesPatchDeleteAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var creativeUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanWriteCreative(creativeUuid))
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
                // path: PATCH api/creatives/{id:guid}
                builder.RegisterType<CreativesPatchDeleteAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<CreativesController>(x => x.Patch(default(Guid), default(CreativePatchViewModel)))
                    .InstancePerLifetimeScope();

                // path: DELETE api/creatives/{id:guid}
                builder.RegisterType<CreativesPatchDeleteAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<CreativesController>(x => x.Delete(default(Guid)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class CreativesReviewPutAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public CreativesReviewPutAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            if (!_authorizationService.CanAccessEverything())
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
                // path: PUT api/creatives/{id:guid}/review
                builder.RegisterType<CreativesReviewPutAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<CreativesController>(x => x.PutReview(default(Guid), default(CreativeReviewViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }
}
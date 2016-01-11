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
    public class SegmentsGetListAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IOwinContext _owinContext;

        public SegmentsGetListAuthorizationFilter(IOwinContext owinContext, IAuthorizationService authorizationService)
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
                // path: GET api/segments
                builder.RegisterType<SegmentsGetListAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<SegmentsController>(x => x.Get(default(SegmentQueryViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class SegmentsGetDetailAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public SegmentsGetDetailAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var segmentId = actionContext.GetRouteData<int>("id");
            if (!_authorizationService.CanReadSegment(segmentId))
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
                // path: GET api/segments/{id:int}
                builder.RegisterType<SegmentsGetDetailAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<SegmentsController>(x => x.Get(default(int)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class SegmentsPostActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public SegmentsPostActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var argument = actionContext.ActionArguments["model"];
            var advertiserUuid = (argument as SegmentRemarketingCreateViewModel)?.AdvertiserUuid ??
                                 (argument as SegmentConversionCreateViewModel)?.AdvertiserUuid;
            if (advertiserUuid != null)
            {
                if (!_authorizationService.CanWriteAdvertiser(advertiserUuid.Value))
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
                // path: POST api/segments/remarketings
                builder.RegisterType<SegmentsPostActionFilter>()
                    .AsWebApiActionFilterFor<SegmentsController>(x => x.PostRemarketings(default(SegmentRemarketingCreateViewModel)))
                    .InstancePerLifetimeScope();

                // path: POST api/segments/conversions
                builder.RegisterType<SegmentsPostActionFilter>()
                    .AsWebApiActionFilterFor<SegmentsController>(x => x.PostConversions(default(SegmentConversionCreateViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class SegmentsPatchDeleteAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public SegmentsPatchDeleteAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var segmentId = actionContext.GetRouteData<int>("id");
            if (!_authorizationService.CanWriteSegment(segmentId))
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
                // path: PATCH api/segments/remarketings/{id:int}
                builder.RegisterType<SegmentsPatchDeleteAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<SegmentsController>(x => x.PatchRemarketings(default(int), default(SegmentRemarketingPatchViewModel)))
                    .InstancePerLifetimeScope();

                // path: PATCH api/segments/conversions/{id:int}
                builder.RegisterType<SegmentsPatchDeleteAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<SegmentsController>(x => x.PatchConversions(default(int), default(SegmentConversionPatchViewModel)))
                    .InstancePerLifetimeScope();

                // path: PATCH api/segments/thirdparties/{id:int}
                builder.RegisterType<SegmentsPatchDeleteAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<SegmentsController>(x => x.PatchThirdParties(default(int), default(SegmentThirdPartyPatchViewModel)))
                    .InstancePerLifetimeScope();

                // path: DELETE api/segments/{id:int}
                builder.RegisterType<SegmentsPatchDeleteAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<SegmentsController>(x => x.Delete(default(int)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class SegmentsPostThirdPartiesActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public SegmentsPostThirdPartiesActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var segmentThirdPartyCreateViewModel = actionContext.ActionArguments["model"] as SegmentThirdPartyCreateViewModel;
            if (segmentThirdPartyCreateViewModel != null)
            {
                if (!_authorizationService.CanWriteSegment(segmentThirdPartyCreateViewModel.ParentRtbSegmentId))
                {
                    actionContext.SetUnauthorizedResponse();
                    return;
                }

                if (!_authorizationService.CanWriteSegment(segmentThirdPartyCreateViewModel.RtbSegmentId))
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
                // path: POST api/segments/thirdparties
                builder.RegisterType<SegmentsPostThirdPartiesActionFilter>()
                    .AsWebApiActionFilterFor<SegmentsController>(x => x.PostThirdParties(default(SegmentThirdPartyCreateViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }
}
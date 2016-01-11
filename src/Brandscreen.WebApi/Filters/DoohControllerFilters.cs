using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac;
using Autofac.Integration.WebApi;
using Brandscreen.Core.Services;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;

namespace Brandscreen.WebApi.Filters
{
    public class DoohPostPanelLocationFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public DoohPostPanelLocationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as DoohPanelLocationCreateViewModel;
            if (model?.PartnerId != null)
            {
                if (!_authorizationService.CanWriteDoohPanelLocation(model.PartnerId.Value))
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
                // path: POST api/dooh/panellocations
                builder.RegisterType<DoohPostPanelLocationFilter>()
                    .AsWebApiActionFilterFor<DoohController>(x => x.PostDoohPanelLocation(default(DoohPanelLocationCreateViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class DoohPatchDeletePanelLocationAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public DoohPatchDeletePanelLocationAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var doohPanelLocationId = actionContext.GetRouteData<int>("id");
            if (!_authorizationService.CanWriteDoohPanelLocation(doohPanelLocationId))
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
                // path: PATCH api/dooh/panellocations/{id:int}
                builder.RegisterType<DoohPatchDeletePanelLocationAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<DoohController>(x => x.PatchDoohPanelLocation(default(int), default(DoohPanelLocationPatchViewModel)))
                    .InstancePerLifetimeScope();

                // path: DELETE api/dooh/panellocations/{id:int}
                builder.RegisterType<DoohPatchDeletePanelLocationAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<DoohController>(x => x.DeleteDoohPanelLocation(default(int)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }
}
using System.Web.Http.Controllers;
using Autofac;
using Autofac.Integration.WebApi;
using Brandscreen.Core.Services;
using Brandscreen.WebApi.Controllers;

namespace Brandscreen.WebApi.Filters
{
    public class MembershipsControllerFilters : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public MembershipsControllerFilters(IAuthorizationService authorizationService)
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
                builder.RegisterType<MembershipsControllerFilters>()
                    .AsWebApiAuthorizationFilterFor<MembershipsController>()
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }
}
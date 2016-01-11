using System.Web.Http.Controllers;
using Autofac;
using Autofac.Integration.WebApi;
using Brandscreen.Core.Services;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;

namespace Brandscreen.WebApi.Filters
{
    public class CreativeSizesUpdateAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public CreativeSizesUpdateAuthorizationFilter(IAuthorizationService authorizationService)
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
                // path: POST api/creativesizes
                builder.RegisterType<CreativeSizesUpdateAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<CreativeSizesController>(x => x.Post(default(CreativeSizeCreateViewModel)))
                    .InstancePerLifetimeScope();

                // path: PATCH api/creativesizes
                builder.RegisterType<CreativeSizesUpdateAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<CreativeSizesController>(x => x.Patch(default(int), default(CreativeSizePatchViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }
}
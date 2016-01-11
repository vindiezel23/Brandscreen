using System.Web.Http.Controllers;
using Autofac;
using Autofac.Integration.WebApi;
using Brandscreen.Core.Services;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Filters
{
    public class DomainListsGetDetailAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public DomainListsGetDetailAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var domainListId = actionContext.GetRouteData<int>("id");
            if (!_authorizationService.CanReadDomainList(domainListId))
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
                // path: GET api/domainlists/{id:int}
                builder.RegisterType<DomainListsGetDetailAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<DomainListsController>(x => x.Get(default(int), default(Pagination)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }
}
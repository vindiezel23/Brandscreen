using System;
using System.Web.Http.Controllers;
using Autofac;
using Autofac.Integration.WebApi;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Microsoft.Owin;

namespace Brandscreen.WebApi.Filters
{
    public class AccountsGetListAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IOwinContext _owinContext;
        private readonly IAuthorizationService _authorizationService;

        public AccountsGetListAuthorizationFilter(IOwinContext owinContext, IAuthorizationService authorizationService)
        {
            _owinContext = owinContext;
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            // allowing super/system admin queries anything
            if (_authorizationService.CanAccessEverything()) return;

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
                // path: GET api/accounts
                builder.RegisterType<AccountsGetListAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<AccountsController>(x => x.Get(default(AccountQueryViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class AccountsPatchAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public AccountsPatchAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var buyerAccountUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanWriteBuyerAccount(buyerAccountUuid))
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
                // path: PATCH api/accounts/{id:guid}
                builder.RegisterType<AccountsPatchAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<AccountsController>(x => x.Patch(default(Guid), default(AccountPatchViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class AccountsGetDetailAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public AccountsGetDetailAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var buyerAccountUuid = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanReadBuyerAccount(buyerAccountUuid))
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
                // path: GET api/accounts/{id:guid}
                builder.RegisterType<AccountsGetDetailAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<AccountsController>(x => x.Get(default(Guid)))
                    .InstancePerLifetimeScope();

                // path: GET api/accounts/{id:guid}/status
                builder.RegisterType<AccountsGetDetailAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<AccountsController>(x => x.GetStatus(default(Guid)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class AccountsPostAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public AccountsPostAuthorizationFilter(IAuthorizationService authorizationService)
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
                // path: POST api/accounts
                builder.RegisterType<AccountsPostAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<AccountsController>(x => x.Post(default(AccountCreateViewModel)))
                    .InstancePerLifetimeScope();

                // path: PATCH api/accounts/{id}/terms
                builder.RegisterType<AccountsPostAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<AccountsController>(x => x.PatchTerms(default(Guid), default(AccountTermsPatchViewModel)))
                    .InstancePerLifetimeScope();

                // path: PUT api/accounts/{id}/status
                builder.RegisterType<AccountsPostAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<AccountsController>(x => x.PutStatus(default(Guid), default(AccountStatusViewModel)))
                    .InstancePerLifetimeScope();

                // path: DELETE api/accounts/{id}
                builder.RegisterType<AccountsPostAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<AccountsController>(x => x.Delete(default(Guid)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }
}
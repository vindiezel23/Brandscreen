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
    public class UsersGetListAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IOwinContext _owinContext;

        public UsersGetListAuthorizationFilter(IAuthorizationService authorizationService, IOwinContext owinContext)
        {
            _authorizationService = authorizationService;
            _owinContext = owinContext;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            // allowing super/system admin queries anything
            if (_authorizationService.CanAccessEverything()) return;

            // default to current user
            // note: only AgencyAdministrator is allowed so call CanWriteUser
            var currentUserId = _owinContext.GetCurrentUserId();
            var userId = actionContext.GetOrSetQueryString("userId", currentUserId);
            if (!_authorizationService.CanWriteUser(userId))
            {
                actionContext.SetUnauthorizedResponse();
            }

            // note: only AgencyAdministrator is allowed so call CanWriteBuyerAccount
            var buyerAccountUuid = actionContext.GetQueryString<Guid?>("buyerAccountUuid");
            if (buyerAccountUuid.HasValue && !_authorizationService.CanWriteBuyerAccount(buyerAccountUuid.Value))
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
                // path: GET api/users
                builder.RegisterType<UsersGetListAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<UsersController>(x => x.Get(default(UserQueryViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class UsersGetDetailAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public UsersGetDetailAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var userId = actionContext.GetRouteData<Guid>("id");
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
                // path: GET api/users/{id:guid}
                builder.RegisterType<UsersGetDetailAuthorizationFilter>()
                    .AsWebApiAuthorizationFilterFor<UsersController>(x => x.Get(default(Guid)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class UsersPostActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public UsersPostActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as UserCreateViewModel;
            if (model?.BuyerAccountUuid != null && !_authorizationService.CanWriteBuyerAccount(model.BuyerAccountUuid.Value))
            {
                actionContext.SetUnauthorizedResponse();
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
                // path: POST api/users
                builder.RegisterType<UsersPostActionFilter>()
                    .AsWebApiActionFilterFor<UsersController>(controller => controller.Post(default(UserCreateViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class UsersPatchAuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public UsersPatchAuthorizationFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var userId = actionContext.GetRouteData<Guid>("id");
            if (!_authorizationService.CanWriteUser(userId))
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
                // path: PATCH api/users
                builder.RegisterType<UsersPostActionFilter>()
                    .AsWebApiActionFilterFor<UsersController>(controller => controller.Patch(default(Guid), default(UserPatchViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }

    public class UsersDeleteActionFilter : IAutofacActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public UsersDeleteActionFilter(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var model = actionContext.ActionArguments["model"] as UserDeleteViewModel;
            if (model?.BuyerAccountUuid != null && !_authorizationService.CanWriteBuyerAccount(model.BuyerAccountUuid.Value))
            {
                actionContext.SetUnauthorizedResponse();
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
                // path: POST api/users
                builder.RegisterType<UsersDeleteActionFilter>()
                    .AsWebApiActionFilterFor<UsersController>(controller => controller.Delete(default(Guid), default(UserDeleteViewModel)))
                    .InstancePerLifetimeScope();
            }
#pragma warning restore
        }
    }
}
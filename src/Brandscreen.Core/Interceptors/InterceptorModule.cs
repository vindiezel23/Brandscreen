using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using Brandscreen.Core.Settings;
using Brandscreen.Framework;
using Castle.DynamicProxy;

namespace Brandscreen.Core.Interceptors
{
    public class InterceptorModule : Module
    {
        private const string InterceptorsPropertyName = "Autofac.Extras.DynamicProxy2.RegistrationExtensions.InterceptorsPropertyName";

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new ProfilingInterceptor(context.Resolve<ISiteSettings>())).SingleInstance();
        }

        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            if (registration.Activator.LimitType.IsAssignableTo<IDependency>() ||
                ProxyUtil.IsProxyType(registration.Activator.LimitType))
            {
                SetInterceptors(registration, typeof (ProfilingInterceptor));
            }
        }

        private void SetInterceptors(IComponentRegistration registration, params Type[] interceptorServiceTypes)
        {
            var interceptorServices = interceptorServiceTypes.Select(t => new TypedService(t)).ToArray();

            object existing;
            if (registration.Metadata.TryGetValue(InterceptorsPropertyName, out existing))
            {
                registration.Metadata[InterceptorsPropertyName] = ((IEnumerable<Service>) existing).Concat(interceptorServices).Distinct();
            }
            else
            {
                registration.Metadata.Add(InterceptorsPropertyName, interceptorServices);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Castle.Components.DictionaryAdapter;

namespace Brandscreen.Framework.Settings
{
    internal class SettingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DictionaryAdapterFactory>().As<IDictionaryAdapterFactory>().SingleInstance();
            builder.RegisterSource(new SettingsRegistrationSource());
        }
    }

    public class SettingsRegistrationSource : IRegistrationSource
    {
        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            var serviceWithType = service as IServiceWithType;
            if (serviceWithType != null &&
                serviceWithType.ServiceType.IsInterface &&
                serviceWithType.ServiceType.Namespace != null &&
                serviceWithType.ServiceType.Namespace.EndsWith("Settings") &&
                serviceWithType.ServiceType.Name.EndsWith("Settings"))
            {
                yield return RegistrationBuilder
                    .ForDelegate((context, parameters) => context.Resolve<IDictionaryAdapterFactory>().GetAdapter(serviceWithType.ServiceType, new SettingWrapper(ConfigurationManager.AppSettings)))
                    .As(serviceWithType.ServiceType)
                    .SingleInstance()
                    .CreateRegistration();
            }
        }

        public bool IsAdapterForIndividualComponents
        {
            get { return false; }
        }
    }
}
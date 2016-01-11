using System.Linq;
using Autofac;
using Brandscreen.Core.Settings;
using Brandscreen.Framework.Environment.AutofacUtil;

namespace Brandscreen.Core.MiniBuss
{
    public class ServiceBusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // assemblies
            var assemblies = AutofacAssemblyStore.GetAssemblies();

            builder.RegisterType<ServiceBus>()
                .As<IServiceBus>()
                .SingleInstance()
                .OnActivated(args =>
                {
                    var siteSettings = args.Context.Resolve<ISiteSettings>();
                    var messageTypes = assemblies.SelectMany(x => x.ExportedTypes).Where(x => typeof (IMessage).IsAssignableFrom(x) && !x.IsInterface);
                    foreach (var messageType in messageTypes)
                    {
                        args.Instance.RegisterMessageEndpoint(messageType, siteSettings.QueueEndPoint);
                    }
                });
        }
    }
}
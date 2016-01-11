using System.Collections.Generic;
using Autofac;
using AutoMapper;
using AutoMapper.Mappers;
using Brandscreen.Framework.Environment.AutofacUtil;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Mappings
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // warming up the mapper to trigger PlatformAdapter loads extra things
            Mapper.Initialize(configuration => { });

            // assemblies
            var assemblies = AutofacAssemblyStore.GetAssemblies();

            // depend by ConfigurationStore
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => type.IsSubclassOf(typeof (Profile)))
                .As<Profile>()
                .SingleInstance();

            // depend by ConfigurationStore
            builder.RegisterInstance(new TypeMapFactory())
                .As<ITypeMapFactory>()
                .SingleInstance();

            // depend by ConfigurationStore
            MapperRegistry.Mappers.Add(new PagedListMapper());
            builder.RegisterInstance(MapperRegistry.Mappers)
                .As<IEnumerable<IObjectMapper>>();

            // depend by MappingEngine
            builder.RegisterType<ConfigurationStore>()
                .AsImplementedInterfaces()
                .SingleInstance()
                .OnActivating(args =>
                {
                    // add profiles
                    foreach (var profile in args.Context.Resolve<IEnumerable<Profile>>())
                    {
                        args.Instance.AddProfile(profile);
                    }
                });

            // depdend by MappingEngineWrapper
            // Note: there is constructor specified for MappingEngine
            // Because it uses the most parameters constructor in unit test project by supplying mocking parameter objects which is unwanted
            builder.RegisterType<MappingEngine>()
                .UsingConstructor(typeof (IConfigurationProvider))
                .AsSelf()
                .SingleInstance();

            // MappingEngine wrapper
            builder.RegisterType<MappingEngineWrapper>()
                .As<IMappingEngine>()
                .InstancePerLifetimeScope();
        }
    }
}
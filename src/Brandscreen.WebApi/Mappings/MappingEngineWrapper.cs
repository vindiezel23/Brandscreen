using System;
using System.Linq.Expressions;
using System.Reflection;
using Autofac;
using AutoMapper;

namespace Brandscreen.WebApi.Mappings
{
    /// <summary>
    /// This wrapper provided per http request service constructor during mapping
    /// </summary>
    public class MappingEngineWrapper : IMappingEngine
    {
        private readonly MappingEngine _inner;
        private readonly ILifetimeScope _container;

        public MappingEngineWrapper(MappingEngine inner, ILifetimeScope container)
        {
            _inner = inner;
            _container = container;
        }

        public void Dispose()
        {
            // never dispose inner mapping engine since it is singleton, lifetime of which is controlled by autofac container
        }

        public TDestination Map<TDestination>(object source)
        {
            return Map<TDestination>(source, DefaultMappingOptions);
        }

        public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts)
        {
            var mappedObject = default(TDestination);
            if (source != null)
            {
                var sourceType = source.GetType();
                var destinationType = typeof (TDestination);

                mappedObject = (TDestination) Map(source, sourceType, destinationType, opts);
            }
            return mappedObject;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            Type modelType = typeof (TSource);
            Type destinationType = typeof (TDestination);

            return (TDestination) Map(source, modelType, destinationType, DefaultMappingOptions);
        }

        public TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        {
            Type modelType = typeof (TSource);
            Type destinationType = typeof (TDestination);

            var options = new MappingOperationOptions<TSource, TDestination>();
            opts(options);

            return (TDestination) MapCore(source, modelType, destinationType, options);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Map(source, destination, DefaultMappingOptions);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        {
            Type modelType = typeof (TSource);
            Type destinationType = typeof (TDestination);

            var options = new MappingOperationOptions<TSource, TDestination>();
            opts(options);

            return (TDestination) MapCore(source, destination, modelType, destinationType, options);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Map(source, sourceType, destinationType, DefaultMappingOptions);
        }

        public object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
        {
            var options = new MappingOperationOptions();

            opts(options);

            return MapCore(source, sourceType, destinationType, options);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return Map(source, destination, sourceType, destinationType, DefaultMappingOptions);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
        {
            var options = new MappingOperationOptions();

            opts(options);

            return MapCore(source, destination, sourceType, destinationType, options);
        }

        public void DynamicMap<TSource, TDestination>(TSource source, TDestination destination)
        {
            Type modelType = typeof (TSource);
            Type destinationType = typeof (TDestination);

            DynamicMap(source, destination, modelType, destinationType);
        }

        public TDestination DynamicMap<TDestination>(object source)
        {
            Type modelType = source?.GetType() ?? typeof (object);
            Type destinationType = typeof (TDestination);

            return (TDestination) DynamicMap(source, modelType, destinationType);
        }

        public object DynamicMap(object source, Type sourceType, Type destinationType)
        {
            var typeMap = ConfigurationProvider.ResolveTypeMap(source, null, sourceType, destinationType);

            var options = new MappingOperationOptions {CreateMissingTypeMaps = true};
            SetDefaultServiceCtor(options);
            var context = new ResolutionContext(typeMap, source, sourceType, destinationType, options, this);

            return ((IMappingEngineRunner) _inner).Map(context);
        }

        public TDestination DynamicMap<TSource, TDestination>(TSource source)
        {
            Type modelType = typeof (TSource);
            Type destinationType = typeof (TDestination);

            return (TDestination) DynamicMap(source, modelType, destinationType);
        }

        public void DynamicMap(object source, object destination, Type sourceType, Type destinationType)
        {
            var typeMap = ConfigurationProvider.ResolveTypeMap(source, destination, sourceType, destinationType);

            var options = new MappingOperationOptions {CreateMissingTypeMaps = true};
            SetDefaultServiceCtor(options);
            var context = new ResolutionContext(typeMap, source, destination, sourceType, destinationType, options, this);

            ((IMappingEngineRunner) _inner).Map(context);
        }

        public Expression CreateMapExpression(Type sourceType, Type destinationType, System.Collections.Generic.IDictionary<string, object> parameters = null, params MemberInfo[] membersToExpand)
        {
            return _inner.CreateMapExpression(sourceType, destinationType, parameters, membersToExpand);
        }

        public IConfigurationProvider ConfigurationProvider => _inner.ConfigurationProvider;

        private object MapCore(object source, Type sourceType, Type destinationType, MappingOperationOptions options)
        {
            TypeMap typeMap = ConfigurationProvider.ResolveTypeMap(source, null, sourceType, destinationType);

            SetDefaultServiceCtor(options);
            var context = new ResolutionContext(typeMap, source, sourceType, destinationType, options, this);

            return ((IMappingEngineRunner) _inner).Map(context);
        }

        private object MapCore(object source, object destination, Type sourceType, Type destinationType, MappingOperationOptions options)
        {
            TypeMap typeMap = ConfigurationProvider.ResolveTypeMap(source, destination, sourceType, destinationType);

            SetDefaultServiceCtor(options);
            var context = new ResolutionContext(typeMap, source, destination, sourceType, destinationType, options, this);

            return ((IMappingEngineRunner) _inner).Map(context);
        }

        private void DefaultMappingOptions(IMappingOperationOptions opts)
        {
            opts.ConstructServicesUsing(_container.Resolve);
        }

        private void SetDefaultServiceCtor(MappingOperationOptions options)
        {
            if (options.ServiceCtor == null) DefaultMappingOptions(options);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Autofac;
using AutoMapper;
using AutoMapper.Internal;
using Brandscreen.Framework.Caching;
using PagedList;

namespace Brandscreen.WebApi.Paginations
{
    public class PagedListMapper : IObjectMapper
    {
        public object Map(ResolutionContext context, IMappingEngineRunner mapper)
        {
            var container = (ILifetimeScope) context.Options.ServiceCtor(typeof (ILifetimeScope));
            var cacheManager = container.Resolve<ICacheManager>(TypedParameter.From(GetType()));

            // create destination value by passing source value as IPagedList
            var createDestination = cacheManager.Get($"lambda-{GetType().Name}-create_{context.DestinationType.FullName}", acquireContext =>
            {
                var constructorInfo = context.DestinationType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, CallingConventions.HasThis, new[] {typeof (IPagedList)}, new ParameterModifier[0]);
                var parameter = Expression.Parameter(typeof (object));
                var parameterConvert = Expression.Convert(parameter, typeof (IPagedList));
                var @new = Expression.New(constructorInfo, parameterConvert);
                return Expression.Lambda<Func<object, object>>(@new, parameter).Compile();
            });
            var destinationValue = createDestination(context.SourceValue);

            // mapping data object
            var sourceItemType = context.SourceType.GenericTypeArguments[0];
            var destinationItemType = context.DestinationType.GenericTypeArguments[0];
            var enumerableSourceItemType = typeof (IEnumerable<>).MakeGenericType(sourceItemType);
            var enumerableDestinationItemType = typeof (IEnumerable<>).MakeGenericType(destinationItemType);
            var typeContext = context.CreateTypeContext(null, context.SourceValue, null, enumerableSourceItemType, enumerableDestinationItemType);
            var data = mapper.Map(typeContext);

            // set data: using expression tree instead of reflection, and have the compiled lambda cached (much better performance)
            var setData = cacheManager.Get($"lambda-{GetType().Name}-set_data-from_{context.SourceType.FullName}-to_{context.DestinationType.FullName}", acquireContext =>
            {
                var instance = Expression.Parameter(typeof (object), "model");
                var instanceConvert = Expression.Convert(instance, context.DestinationType);
                var value = Expression.Parameter(typeof (object), "data");
                var valueConvert = Expression.Convert(value, enumerableDestinationItemType);
                var property = Expression.Property(instanceConvert, "Data");
                var setMethod = ((PropertyInfo) property.Member).GetSetMethod();
                var call = Expression.Call(instanceConvert, setMethod, valueConvert);
                return Expression.Lambda<Action<object, object>>(call, instance, value).Compile();
            });
            setData(destinationValue, data); // set the value

            // reflection way to set data
//            var dataProp = context.DestinationType.GetProperty("Data");
//            dataProp.SetValue(destinationValue, data);

            return destinationValue;
        }

        public bool IsMatch(ResolutionContext context)
        {
            return context.SourceType.IsEnumerableType() &&
                   context.SourceType.IsSubclassOf(typeof (PagedListMetaData)) &&
                   context.DestinationType.IsGenericType &&
                   context.DestinationType.GetGenericTypeDefinition() == typeof (PagedListViewModel<>);
        }
    }
}
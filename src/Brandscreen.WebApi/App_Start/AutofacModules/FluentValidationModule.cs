using System;
using Autofac;
using Brandscreen.Framework.Environment.AutofacUtil;
using FluentValidation;

namespace Brandscreen.WebApi.AutofacModules
{
    public class FluentValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // assemblies
            var assemblies = AutofacAssemblyStore.GetAssemblies();

            // validators: types derived from AbstractValidator<>
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof (AbstractValidator<>))
                .Keyed(type => type.BaseType?.GenericTypeArguments[0], typeof (IValidator))
                .SingleInstance();
        }
    }

    /// <summary>
    /// Validator factory provides the validator instance by resoving from autofac container.
    /// </summary>
    /// <remarks>
    /// Validator should only directly depend on singleton instance. For other lifetime instance should use self-created child scope from ILifetimeScope.
    /// </remarks>
    internal class FluentValidationValidatorFactory : IValidatorFactory
    {
        private readonly ILifetimeScope _container;

        public FluentValidationValidatorFactory(ILifetimeScope container)
        {
            _container = container;
        }

        public IValidator<T> GetValidator<T>()
        {
            return (IValidator<T>) GetValidator(typeof (T));
        }

        public IValidator GetValidator(Type type)
        {
            object retVal;
            if (_container.TryResolveKeyed(type, typeof (IValidator), out retVal))
            {
                return (IValidator) retVal;
            }
            return null;
        }
    }
}
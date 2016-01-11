using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Core.Services.Strategies.Targets;
using FluentValidation;

namespace Brandscreen.WebApi.Models
{
    public class StrategyTargetingCityPutViewModel
    {
        public IList<StrategyTargetingItemViewModel<int>> Targetings { get; set; }
    }

    public class StrategyTargetingCityPutViewModelValidator : AbstractValidator<StrategyTargetingCityPutViewModel>
    {
        public StrategyTargetingCityPutViewModelValidator(ILifetimeScope container)
        {
            RuleFor(x => x.Targetings)
                .NotEmpty();

            RuleFor(x => x.Targetings)
                .Must(targetings =>
                {
                    using (var scope = container.BeginLifetimeScope())
                    {
                        var ids = targetings.Select(x => x.Id).ToArray();
                        var geoLocations = scope.Resolve<IGeoLocationService>().GetGeoLocationsByGeoCityIds(ids);
                        return geoLocations.Count() == ids.Length;
                    }
                })
                .WithMessage("{PropertyName} contain invalid geo city id(s).")
                .When(x => x.Targetings != null && x.Targetings.Count > 0);
        }
    }

    public class StrategyTargetingCityPutViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<StrategyTargetingCityPutViewModel, StrategyTargetingUpdateOptions<int>>()
                .ForMember(dst => dst.StrategyUuid, opt => opt.ResolveUsing(result => (Guid) result.Context.Options.Items["id"]));
        }
    }
}
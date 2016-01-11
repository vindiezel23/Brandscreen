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
    public class StrategyTargetingPostcodePutViewModel
    {
        public IList<StrategyTargetingItemViewModel<StrategyTargetingGeoPostcodeViewModel>> Targetings { get; set; }
    }

    public class StrategyTargetingPostcodePutViewModelValidator : AbstractValidator<StrategyTargetingPostcodePutViewModel>
    {
        public StrategyTargetingPostcodePutViewModelValidator(ILifetimeScope container)
        {
            RuleFor(x => x.Targetings)
                .NotEmpty();

            RuleFor(x => x.Targetings)
                .Must(targetings =>
                {
                    using (var scope = container.BeginLifetimeScope())
                    {
                        var ids = targetings.Select(x => x.Id.GeoCountryId.GetValueOrDefault(0)).Distinct().ToArray();
                        var geoLocations = scope.Resolve<IGeoLocationService>().GetGeoLocationsByGeoCountryIds(ids);
                        return geoLocations.Count() == ids.Length;
                    }
                })
                .WithMessage("{PropertyName} contain invalid geo postcode id(s).")
                .When(x => x.Targetings != null && x.Targetings.Count > 0 && x.Targetings.All(y => y.Id != null));
        }
    }

    public class StrategyTargetingPostcodePutViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<StrategyTargetingPostcodePutViewModel, StrategyTargetingUpdateOptions<StrategyTargetingGeoPostcode>>()
                .ForMember(dst => dst.StrategyUuid, opt => opt.ResolveUsing(result => (Guid) result.Context.Options.Items["id"]));
        }
    }
}
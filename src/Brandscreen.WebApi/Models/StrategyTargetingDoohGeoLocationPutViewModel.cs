using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using Brandscreen.Core.Services.Dooh;
using Brandscreen.Core.Services.Strategies;
using FluentValidation;

namespace Brandscreen.WebApi.Models
{
    public class StrategyTargetingDoohGeoLocationPutViewModel
    {
        public IList<StrategyTargetingItemViewModel<int>> Targetings { get; set; }
    }

    public class StrategyTargetingDoohGeoLocationPutViewModelValidator : AbstractValidator<StrategyTargetingDoohGeoLocationPutViewModel>
    {
        public StrategyTargetingDoohGeoLocationPutViewModelValidator(ILifetimeScope container)
        {
            RuleFor(x => x.Targetings)
                .NotEmpty();

            RuleFor(x => x.Targetings)
                .Must(targetings =>
                {
                    using (var scope = container.BeginLifetimeScope())
                    {
                        var ids = targetings.Select(x => x.Id).ToArray();
                        var doohGeoLocationGroups = scope.Resolve<IDoohService>().GetDoohGeoLocationGroupsByIds(ids);
                        return doohGeoLocationGroups.Count() == ids.Length;
                    }
                })
                .WithMessage("{PropertyName} contain invalid dooh group id(s).")
                .When(x => x.Targetings != null && x.Targetings.Count > 0);
        }
    }

    public class StrategyTargetingDoohGeoLocationPutViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<StrategyTargetingDoohGeoLocationPutViewModel, StrategyTargetingUpdateOptions<int>>()
                .ForMember(dst => dst.StrategyUuid, opt => opt.ResolveUsing(result => (Guid) result.Context.Options.Items["id"]));
        }
    }
}
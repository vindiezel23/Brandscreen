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
    public class StrategyTargetingDoohPanelLocationPutViewModel
    {
        public IList<StrategyTargetingItemViewModel<int>> Targetings { get; set; }
    }

    public class StrategyTargetingDoohPanelLocationPutViewModelValidator : AbstractValidator<StrategyTargetingDoohPanelLocationPutViewModel>
    {
        public StrategyTargetingDoohPanelLocationPutViewModelValidator(ILifetimeScope container)
        {
            RuleFor(x => x.Targetings)
                .NotEmpty();

            RuleFor(x => x.Targetings)
                .Must(targetings =>
                {
                    using (var scope = container.BeginLifetimeScope())
                    {
                        var ids = targetings.Select(x => x.Id).ToArray();
                        var publishers = scope.Resolve<IDoohService>().GetDoohPanelLocationsByIds(ids);
                        return publishers.Count() == ids.Length;
                    }
                })
                .WithMessage("{PropertyName} contain invalid dooh panel location id(s).")
                .When(x => x.Targetings != null && x.Targetings.Count > 0);
        }
    }

    public class StrategyTargetingDoohPanelLocationPutViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<StrategyTargetingDoohPanelLocationPutViewModel, StrategyTargetingUpdateOptions<int>>()
                .ForMember(dst => dst.StrategyUuid, opt => opt.ResolveUsing(result => (Guid) result.Context.Options.Items["id"]));
        }
    }
}
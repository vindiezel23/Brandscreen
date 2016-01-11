using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using Brandscreen.Core.Services.Segments;
using Brandscreen.Core.Services.Strategies;
using FluentValidation;

namespace Brandscreen.WebApi.Models
{
    public class StrategyTargetingSegmentPutViewModel
    {
        public IList<StrategyTargetingItemViewModel<int>> Targetings { get; set; }
    }

    public class StrategyTargetingSegmentPutViewModelValidator : AbstractValidator<StrategyTargetingSegmentPutViewModel>
    {
        public StrategyTargetingSegmentPutViewModelValidator(ILifetimeScope container)
        {
            RuleFor(x => x.Targetings)
                .NotEmpty();

            RuleFor(x => x.Targetings)
                .Must(targetings =>
                {
                    using (var scope = container.BeginLifetimeScope())
                    {
                        var ids = targetings.Select(x => x.Id).ToArray();
                        var segments = scope.Resolve<ISegmentService>().GetSegments().Where(x => ids.Contains(x.SegmentId));
                        return segments.Count() == ids.Length;
                    }
                })
                .WithMessage("{PropertyName} contain invalid segment id(s).")
                .When(x => x.Targetings != null && x.Targetings.Count > 0);
        }
    }

    public class StrategyTargetingSegmentPutViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<StrategyTargetingSegmentPutViewModel, StrategyTargetingUpdateOptions<int>>()
                .ForMember(dst => dst.StrategyUuid, opt => opt.ResolveUsing(result => (Guid) result.Context.Options.Items["id"]));
        }
    }
}
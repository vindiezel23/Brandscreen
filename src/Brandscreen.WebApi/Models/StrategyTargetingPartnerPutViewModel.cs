using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using Brandscreen.Core.Services.Partners;
using Brandscreen.Core.Services.Strategies;
using FluentValidation;

namespace Brandscreen.WebApi.Models
{
    public class StrategyTargetingPartnerPutViewModel
    {
        public IList<StrategyTargetingItemViewModel<int>> Targetings { get; set; }
    }

    public class StrategyTargetingPartnerPutViewModelValidator : AbstractValidator<StrategyTargetingPartnerPutViewModel>
    {
        public StrategyTargetingPartnerPutViewModelValidator(ILifetimeScope container)
        {
            RuleFor(x => x.Targetings)
                .NotEmpty();

            RuleFor(x => x.Targetings)
                .Must(targetings =>
                {
                    using (var scope = container.BeginLifetimeScope())
                    {
                        var ids = targetings.Select(x => x.Id).ToArray();
                        var partners = scope.Resolve<IPartnerService>().GetPartners().Where(x => ids.Contains(x.PartnerId));
                        return partners.Count() == ids.Length;
                    }
                })
                .WithMessage("{PropertyName} contain invalid partner id(s).")
                .When(x => x.Targetings != null && x.Targetings.Count > 0);
        }
    }

    public class StrategyTargetingPartnerPutViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<StrategyTargetingPartnerPutViewModel, StrategyTargetingUpdateOptions<int>>()
                .ForMember(dst => dst.StrategyUuid, opt => opt.ResolveUsing(result => (Guid) result.Context.Options.Items["id"]));
        }
    }
}
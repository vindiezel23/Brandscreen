using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Strategies;
using FluentValidation;

namespace Brandscreen.WebApi.Models
{
    public class StrategyTargetingLanguagePutViewModel
    {
        public IList<StrategyTargetingItemViewModel<int>> Targetings { get; set; }
    }

    public class StrategyTargetingLanguagePutViewModelValidator : AbstractValidator<StrategyTargetingLanguagePutViewModel>
    {
        public StrategyTargetingLanguagePutViewModelValidator(ILifetimeScope container)
        {
            RuleFor(x => x.Targetings)
                .NotEmpty();

            RuleFor(x => x.Targetings)
                .Must(targetings =>
                {
                    using (var scope = container.BeginLifetimeScope())
                    {
                        var ids = targetings.Select(x => x.Id).ToArray();
                        var doohGeoLocationGroups = scope.Resolve<ILanguageService>().GetLanguages().Where(x => ids.Contains(x.LanguageId));
                        return doohGeoLocationGroups.Count() == ids.Length;
                    }
                })
                .WithMessage("{PropertyName} contain invalid language id(s).")
                .When(x => x.Targetings != null && x.Targetings.Count > 0);
        }
    }

    public class StrategyTargetingLanguagePutViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<StrategyTargetingLanguagePutViewModel, StrategyTargetingUpdateOptions<int>>()
                .ForMember(dst => dst.StrategyUuid, opt => opt.ResolveUsing(result => (Guid) result.Context.Options.Items["id"]));
        }
    }
}
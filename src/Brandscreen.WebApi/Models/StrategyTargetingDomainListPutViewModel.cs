using System;
using System.Collections.Generic;
using Autofac;
using AutoMapper;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Core.Services.Strategies.Targets;
using FluentValidation;
using FluentValidation.Results;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class StrategyTargetingDomainListPutViewModel
    {
        public IList<StrategyTargetingItemViewModel<int>> Targetings { get; set; }
    }

    public class StrategyTargetingDomainListPutViewModelValidator : AbstractValidator<StrategyTargetingDomainListPutViewModel>
    {
        public StrategyTargetingDomainListPutViewModelValidator(ILifetimeScope container)
        {
            RuleFor(x => x.Targetings)
                .NotEmpty();

            Custom(model =>
            {
                if (model.Targetings == null || model.Targetings.Count == 0) return null;

                var targetings = model.Targetings;
                using (var scope = container.BeginLifetimeScope())
                {
                    var domainListService = scope.Resolve<IDomainListService>();
                    foreach (var strategyTargetingItemViewModel in targetings)
                    {
                        var domainList = domainListService.GetDomainList(strategyTargetingItemViewModel.Id).WaitAndUnwrapException();
                        if (domainList == null)
                        {
                            return new ValidationFailure("Targetings", "Targetings contain invalid domain list id(s).");
                        }

                        if (domainList.DomainListType == (int) DomainListTypeEnum.SystemBlackList && strategyTargetingItemViewModel.TargetingAction == TargetingActionEnum.Targeting)
                        {
                            return new ValidationFailure("Targetings", $"Cannot target system black list - {strategyTargetingItemViewModel.Id}.");
                        }

                        if (domainList.DomainListType == (int) DomainListTypeEnum.CortexWhiteList && strategyTargetingItemViewModel.TargetingAction == TargetingActionEnum.Avoiding)
                        {
                            return new ValidationFailure("Targetings", $"Cannot avoid system white list - {strategyTargetingItemViewModel.Id}.");
                        }
                    }

                    // all good
                    return null;
                }
            });
        }
    }

    public class StrategyTargetingDomainListPutViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<StrategyTargetingDomainListPutViewModel, StrategyTargetingUpdateOptions<int>>()
                .ForMember(dst => dst.StrategyUuid, opt => opt.ResolveUsing(result => (Guid) result.Context.Options.Items["id"]));
        }
    }
}
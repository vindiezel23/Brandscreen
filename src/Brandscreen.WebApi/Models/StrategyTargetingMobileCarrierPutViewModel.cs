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
    public class StrategyTargetingMobileCarrierPutViewModel
    {
        public IList<StrategyTargetingItemViewModel<StrategyTargetingMobileCarrierViewModel>> Targetings { get; set; }
    }

    public class StrategyTargetingMobileCarrierPutViewModelValidator : AbstractValidator<StrategyTargetingMobileCarrierPutViewModel>
    {
        public StrategyTargetingMobileCarrierPutViewModelValidator(ILifetimeScope container)
        {
            RuleFor(x => x.Targetings)
                .NotEmpty();

            RuleFor(x => x.Targetings)
                .Must(targetings =>
                {
                    using (var scope = container.BeginLifetimeScope())
                    {
                        var mobileCarrierService = scope.Resolve<IMobileCarrierService>();
                        return targetings.Select(x => x.Id)
                            .Select(id => mobileCarrierService.GetMobileCarriers().Count(x => x.GeoCountryId == id.GeoCountryId && x.Mcc == id.Mcc && x.Mnc == id.Mnc))
                            .All(count => count > 0);
                    }
                })
                .WithMessage("{PropertyName} contain invalid mobile carrier id(s).")
                .When(x => x.Targetings != null && x.Targetings.Count > 0);
        }

        public struct MyStruct
        {
            public int GeoCountryId { get; set; }
            public int Mcc { get; set; }
            public int Mnc { get; set; }
        }
    }

    public class StrategyTargetingMobileCarrierPutViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<StrategyTargetingMobileCarrierPutViewModel, StrategyTargetingUpdateOptions<StrategyTargetingMobileCarrier>>()
                .ForMember(dst => dst.StrategyUuid, opt => opt.ResolveUsing(result => (Guid) result.Context.Options.Items["id"]));
        }
    }
}
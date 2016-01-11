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
    public class StrategyTargetingDevicePutViewModel
    {
        public IList<StrategyTargetingItemViewModel<int>> Targetings { get; set; }
    }

    public class StrategyTargetingDevicePutViewModelValidator : AbstractValidator<StrategyTargetingDevicePutViewModel>
    {
        public StrategyTargetingDevicePutViewModelValidator(ILifetimeScope container)
        {
            RuleFor(x => x.Targetings)
                .NotEmpty();

            RuleFor(x => x.Targetings)
                .Must(targetings =>
                {
                    using (var scope = container.BeginLifetimeScope())
                    {
                        var ids = targetings.Select(x => x.Id).ToArray();
                        var devices = scope.Resolve<IDeviceService>().GetDevices().Where(x => ids.Contains(x.DeviceId));
                        return devices.Count() == ids.Length;
                    }
                })
                .WithMessage("{PropertyName} contain invalid device id(s).")
                .When(x => x.Targetings != null && x.Targetings.Count > 0);
        }
    }

    public class StrategyTargetingDevicePutViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<StrategyTargetingDevicePutViewModel, StrategyTargetingUpdateOptions<int>>()
                .ForMember(dst => dst.StrategyUuid, opt => opt.ResolveUsing(result => (Guid) result.Context.Options.Items["id"]));
        }
    }
}
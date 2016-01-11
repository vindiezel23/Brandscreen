using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services.Strategies;

namespace Brandscreen.WebApi.Models
{
    public class StrategyTargetingItemViewModel<T> : IValidatableObject
    {
        [Required]
        public T Id { get; set; }

        /// <summary>
        /// Unspecified, Avoiding, or Targeting.
        /// </summary>
        [Required]
        [EnumDataType(typeof (TargetingActionEnum))]
        public TargetingActionEnum? TargetingAction { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TargetingAction.HasValue)
            {
                var targetingAction = TargetingAction.Value;
                if (targetingAction != TargetingActionEnum.Unspecified &&
                    targetingAction != TargetingActionEnum.Avoiding &&
                    targetingAction != TargetingActionEnum.Targeting)
                {
                    yield return new ValidationResult("Invalid targeting action.");
                }
            }
        }
    }

    public class StrategyTargetingItemPutViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap(typeof (StrategyTargetingItemViewModel<>), typeof (StrategyTargetingItem<>));
        }
    }
}
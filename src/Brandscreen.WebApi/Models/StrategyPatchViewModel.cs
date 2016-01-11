using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Entities;
using Brandscreen.Framework.Services;
using Brandscreen.WebApi.Mappings;
using FluentValidation;
using Microsoft.Owin;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class StrategyPatchViewModel
    {
        [StringLength(200)]
        public string StrategyName { get; set; }

        public decimal? BudgetAmount { get; set; } // BudgetAmount
        public int? BudgetPeriodId { get; set; } // BudgetPeriodID

        public DateTime? UtcStartDateTime { get; set; } // UtcStartDateTime
        public DateTime? UtcEndDateTime { get; set; } // UtcEndDateTime

        public int? GoalTypeId { get; set; } // GoalTypeID
        public long? GoalTargetQuantity { get; set; } // GoalTargetQuantity
        public decimal? GoalTargetRate { get; set; } // GoalTargetRate

        public decimal? MaxBidCpm { get; set; } // MaxBidCpm
        public decimal? MinBidCpm { get; set; } // MinBidCpm

        public bool? UseBinomialFilter { get; set; } // UseBinomialFilter
        public double? MinSloRate { get; set; } // MinSloRate
        public double? MaxSloRate { get; set; } // MaxSloRate

        public int? SpendConstraintPeriodId { get; set; } // SpendConstraintPeriodID
        public decimal? SpendConstraintAmount { get; set; } // SpendConstraintAmount
        public int? UniqueConstraintPeriodId { get; set; } // UniqueConstraintPeriodID
        public int? UniqueConstraintAmount { get; set; } // UniqueConstraintAmount

        public int? FrequencyGroupId { get; set; } // FrequencyGroupID

        public int? ClassificationProviderId { get; set; } // ClassificationProviderID
        public int? BrandSafetyProviderId { get; set; } // BrandSafetyProviderID
        public int? ViewabilityProviderId { get; set; } // ViewabilityProviderID
        public int? SuspiciousActivityProviderId { get; set; } // SuspiciousActivityProviderID
        public int? ViewablePercentage { get; set; } // ViewablePercentage

        public int? PacingStyleId { get; set; } // PacingStyleID
        public int? PacingStyleOptionId { get; set; } // PacingStyleOptionID

        /// <summary>
        /// Super/System administrator only.
        /// </summary>
        public bool? UsePacing { get; set; } // UsePacing

        /// <summary>
        /// Super/System administrator only.
        /// </summary>
        public bool? UsePricing { get; set; } // UsePricing

        /// <summary>
        /// Super/System administrator only.
        /// </summary>
        public int? PacingVersion { get; set; } // PacingVersion

        /// <summary>
        /// Super/System administrator only.
        /// </summary>
        public int? PricingVersion { get; set; } // PricingVersion
    }

    public class StrategyPatchViewModelValidator : AbstractValidator<StrategyPatchViewModel>
    {
        private const decimal MinGoalTargetRate = 0.01m;
        private const decimal MaxGoalTargetRate = 100000000m;

        private const int MinGoalTargetQuantityCpm = 1000;
        private const int MinGoalTargetQuantityCpc = 1;
        private const int MinGoalTargetQuantityCpa = 1;

        public const int MinFrequencyAmount = 1;
        public const int MaxFrequencyAmount = 100;

        private const decimal MaxSpendConstraintAmount = 100000000;

        public StrategyPatchViewModelValidator(IClock clock)
        {
            RuleFor(x => x.UtcStartDateTime)
                .Must(startTime => startTime.HasValue)
                .When(x => x.BudgetPeriodId.HasValue);

            RuleFor(x => x.UtcEndDateTime)
                .Must((model, endTime) => endTime.HasValue && endTime.Value >= model.UtcStartDateTime)
                .When(x => x.BudgetPeriodId == (int) StrategyTypeEnum.SingleFlight);

            RuleFor(x => x.UtcEndDateTime.Value)
                .Must(endTime => endTime > clock.UtcNow)
                .When(x => x.UtcEndDateTime.HasValue);

            When(x => x.GoalTypeId.HasValue, () =>
            {
                RuleFor(x => x.BudgetAmount)
                    .NotNull();

                RuleFor(x => x.GoalTargetRate)
                    .NotNull()
                    .InclusiveBetween(MinGoalTargetRate, MaxGoalTargetRate)
                    .LessThanOrEqualTo(model => model.BudgetAmount);

                RuleFor(x => x.GoalTargetQuantity)
                    .NotNull();
            });

            RuleFor(x => x.GoalTargetQuantity)
                .GreaterThanOrEqualTo(MinGoalTargetQuantityCpm)
                .When(x => x.GoalTypeId == (int) GoalTypeEnum.Impressions);
            RuleFor(x => x.GoalTargetQuantity)
                .GreaterThanOrEqualTo(MinGoalTargetQuantityCpc)
                .When(x => x.GoalTypeId == (int) GoalTypeEnum.Clicks);
            RuleFor(x => x.GoalTargetQuantity)
                .GreaterThanOrEqualTo(MinGoalTargetQuantityCpa)
                .When(x => x.GoalTypeId == (int) GoalTypeEnum.Actions);

            When(x => x.MaxBidCpm.HasValue || x.MinBidCpm.HasValue, () =>
            {
                RuleFor(x => x.MaxBidCpm)
                    .NotNull()
                    .GreaterThanOrEqualTo(MinGoalTargetRate);

                RuleFor(x => x.MinBidCpm)
                    .NotNull()
                    .LessThanOrEqualTo(x => x.MaxBidCpm)
                    .GreaterThanOrEqualTo(0);
            });

            When(x => x.UseBinomialFilter == true && x.GoalTypeId == (int) GoalTypeEnum.Clicks, () =>
            {
                RuleFor(x => x.MinSloRate)
                    .NotNull()
                    .InclusiveBetween(0, 1);

                RuleFor(x => x.MaxSloRate)
                    .NotNull()
                    .InclusiveBetween(0, 1)
                    .GreaterThanOrEqualTo(x => x.MinSloRate);
            });

            When(x => x.UseBinomialFilter == true && x.GoalTypeId == (int) GoalTypeEnum.Actions, () =>
            {
                RuleFor(x => x.MinSloRate)
                    .NotNull()
                    .InclusiveBetween(0, 1);
            });

            RuleFor(x => x.SpendConstraintAmount)
                .ExclusiveBetween(0, MaxSpendConstraintAmount)
                .When(x => x.PacingStyleId == (int) PacingStyleEnum.Fixed);

            RuleFor(x => x.UniqueConstraintAmount)
                .LessThanOrEqualTo(MaxFrequencyAmount)
                .When(x => x.UniqueConstraintAmount.HasValue);
        }
    }

    public class StrategyPatchViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<StrategyPatchViewModel, AdGroup>()
                .ForMember(dst => dst.AdGroupName, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.StrategyName));
                    opt.MapFrom(src => src.StrategyName);
                })
                .ForAllMembers(opt => opt.Condition(ctx => !ctx.IsSourceValueNull)); // for partial updates

            CreateMap<StrategyPatchViewModel, StrategyUpdateOptions>()
                .ForMember(dst => dst.NewStrategy, opt => opt.ResolveUsing(result =>
                {
                    var strategyUuid = (Guid) result.Context.Options.Items["id"];
                    var strategy = result.Context.Resolve<IStrategyService>().GetStrategy(strategyUuid).WaitAndUnwrapException();
                    return result.Context.Engine.Map((StrategyPatchViewModel) result.Value, strategy); // using above mapping
                }))
                .ForMember(dst => dst.UserId, opt => opt.ResolveUsing(result => result.Context.Resolve<IOwinContext>().GetCurrentUserId()));
        }
    }
}
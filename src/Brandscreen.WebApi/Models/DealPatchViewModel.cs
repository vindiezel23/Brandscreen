using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Deals;
using Brandscreen.Entities;
using Brandscreen.Framework.Services;
using Brandscreen.WebApi.Mappings;
using FluentValidation;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class DealPatchViewModel
    {
        [StringLength(500)]
        public string DealName { get; set; } // DealName

        /// <summary>
        /// Fixed, or Floor.
        /// </summary>
        [EnumDataType(typeof (DealTypeEnum))]
        public string DealType { get; set; }

        public int? FloorPriceCents { get; set; } // FloorPriceCents
        public int? CeilingPriceCents { get; set; } // CeilingPriceCents

        public DateTime? UtcStartDateTime { get; set; } // UtcStartDateTime
        public DateTime? UtcEndDateTime { get; set; } // UtcEndDateTime

        public string CurrencyCode { get; set; }
    }

    public class DealPatchViewModelValidator : AbstractValidator<DealPatchViewModel>
    {
        public DealPatchViewModelValidator(IClock clock)
        {
            // 3 rules for updating type and price

            RuleFor(x => x.DealType)
                .NotNull()
                .When(RequireUpdateDealTypeAndPrice);

            RuleFor(x => x.FloorPriceCents)
                .NotNull()
                .ExclusiveBetween(0, 9999999)
                .When(RequireUpdateDealTypeAndPrice);

            RuleFor(x => x.CeilingPriceCents)
                .NotNull()
                .ExclusiveBetween(0, 9999999)
                .GreaterThanOrEqualTo(x => x.FloorPriceCents)
                .When(x =>
                {
                    DealTypeEnum dealType;
                    return RequireUpdateDealTypeAndPrice(x) && Enum.TryParse(x.DealType, true, out dealType) && dealType == DealTypeEnum.Floor;
                });

            // 2 rules for updating time

            RuleFor(x => x.UtcStartDateTime)
                .GreaterThan(x => clock.UtcNow)
                .When(ReqruieUpdateDealTime);

            RuleFor(x => x.UtcEndDateTime)
                .GreaterThan(x => x.UtcStartDateTime)
                .When(ReqruieUpdateDealTime);
        }

        private bool RequireUpdateDealTypeAndPrice(DealPatchViewModel model)
        {
            return !string.IsNullOrEmpty(model.DealType) || model.FloorPriceCents.HasValue || model.CeilingPriceCents.HasValue;
        }

        private bool ReqruieUpdateDealTime(DealPatchViewModel model)
        {
            return model.UtcStartDateTime.HasValue || model.UtcEndDateTime.HasValue;
        }
    }

    public class DealPatchViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<DealPatchViewModel, Deal>()
                .ForMember(x => x.DealTypeId, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.DealType));
                    opt.MapFrom(src => Enum.Parse(typeof (DealTypeEnum), src.DealType, true));
                })
                .ForMember(dst => dst.DealType, opt => opt.Ignore())
                .ForMember(dst => dst.CurrencyId, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.CurrencyCode));
                    opt.ResolveUsing(result =>
                    {
                        var source = (DealPatchViewModel) result.Value;
                        var currency = result.Context.Resolve<ICurrencyService>().GetCurrencyOrDefault(source.CurrencyCode).WaitAndUnwrapException();
                        return currency.CurrencyId;
                    });
                })
                .AfterMap((model, deal) =>
                {
                    if (deal.DealTypeId == (int) DealTypeEnum.Fixed)
                    {
                        // set to the same if fixed type of deal
                        deal.CeilingPriceCents = deal.FloorPriceCents;
                    }
                })
                .ForAllMembers(opt => opt.Condition(ctx => !ctx.IsSourceValueNull)); // for partial updates
        }
    }
}
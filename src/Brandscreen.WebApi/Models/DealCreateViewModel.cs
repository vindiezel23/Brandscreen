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
    public class DealCreateViewModel
    {
        [Required]
        public Guid? BuyerAccountUuid { get; set; }

        [Required]
        public Guid? PublisherUuid { get; set; }

        [Required]
        [StringLength(50)]
        public string DealKey { get; set; } // DealKey

        [Required]
        [StringLength(500)]
        public string DealName { get; set; } // DealName

        /// <summary>
        /// Fixed, or Floor.
        /// </summary>
        [Required]
        [EnumDataType(typeof (DealTypeEnum))]
        public string DealType { get; set; }

        [Required]
        public int? FloorPriceCents { get; set; } // FloorPriceCents

        public int? CeilingPriceCents { get; set; } // CeilingPriceCents

        [Required]
        public DateTime? UtcStartDateTime { get; set; } // UtcStartDateTime

        [Required]
        public DateTime? UtcEndDateTime { get; set; } // UtcEndDateTime

        /// <summary>
        /// AUD by default
        /// </summary>
        public string CurrencyCode { get; set; }
    }

    public class DealCreateViewModelValidator : AbstractValidator<DealCreateViewModel>
    {
        public DealCreateViewModelValidator(IClock clock)
        {
            RuleFor(x => x.FloorPriceCents)
                .ExclusiveBetween(0, 9999999);

            RuleFor(x => x.CeilingPriceCents)
                .ExclusiveBetween(0, 9999999)
                .GreaterThanOrEqualTo(x => x.FloorPriceCents)
                .When(x =>
                {
                    DealTypeEnum dealType;
                    return Enum.TryParse(x.DealType, true, out dealType) && dealType == DealTypeEnum.Floor;
                });

            RuleFor(x => x.UtcStartDateTime)
                .GreaterThan(x => clock.UtcNow);

            RuleFor(x => x.UtcEndDateTime)
                .GreaterThan(x => x.UtcStartDateTime);
        }
    }

    public class DealCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<DealCreateViewModel, Deal>()
                .ForMember(x => x.DealTypeId, opt => opt.MapFrom(src => Enum.Parse(typeof (DealTypeEnum), src.DealType, true)))
                .ForMember(x => x.DealType, opt => opt.Ignore())
                .ForMember(dst => dst.CurrencyId, opt =>
                {
                    opt.ResolveUsing(result =>
                    {
                        var source = (DealCreateViewModel) result.Value;
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
                });
        }
    }
}
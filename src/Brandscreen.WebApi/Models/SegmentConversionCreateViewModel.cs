using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services.Advertisers;
using Brandscreen.Core.Services.Segments;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;
using FluentValidation;
using Nito.AsyncEx.Synchronous;
using static Brandscreen.Core.Services.EnumHelper;
using static Brandscreen.Core.Services.UrlHelper;

namespace Brandscreen.WebApi.Models
{
    public class SegmentConversionCreateViewModel
    {
        [Required]
        public Guid? AdvertiserUuid { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Url { get; set; }

        /// <summary>
        /// LastEntryInPath, or LastClick.
        /// </summary>
        [Required]
        [EnumDataType(typeof (ConversionAttributionModelEnum))]
        public string AttributionModel { get; set; }

        public int? PostViewLifetime { get; set; } // ConversionPostViewLifetime

        /// <summary>
        /// PerMinute, PerHour, PerDay, PerWeek, or PerMonth.
        /// </summary>
        [EnumDataType(typeof (PeriodTypeEnum))]
        public string PostViewLifetimePeriod { get; set; } // ConversionPostViewLifetimePeriodID

        [Required]
        public int? PostClickLifetime { get; set; } // ConversionPostClickLifetime

        /// <summary>
        /// PerMinute, PerHour, PerDay, PerWeek, or PerMonth.
        /// </summary>
        [Required]
        [EnumDataType(typeof (PeriodTypeEnum))]
        public string PostClickLifetimePeriod { get; set; } // ConversionPostClickLifetimePeriodID

        /// <summary>
        /// EveryEvent, OncePerSession, OncePerRecency, or OncePerLifetime.
        /// </summary>
        [Required]
        [EnumDataType(typeof (ConversionAttributionCountingModeEnum))]
        public string AttributionCountingMode { get; set; } // ConversionAttributionCountingModeID

        public int? AttributionCountingRecency { get; set; } // ConversionAttributionCountingRecency

        /// <summary>
        /// PerMinute, PerHour, PerDay, PerWeek, or PerMonth.
        /// </summary>
        [EnumDataType(typeof (PeriodTypeEnum))]
        public string AttributionCountingRecencyPeriod { get; set; } // ConversionAttributionCountingRecencyPeriodID
    }

    public class SegmentConversionCreateViewModelValidator : AbstractValidator<SegmentConversionCreateViewModel>
    {
        public SegmentConversionCreateViewModelValidator()
        {
            RuleFor(x => x.Url)
                .MustAsync(IsValidUrl)
                .When(x => !string.IsNullOrEmpty(x.Url))
                .WithMessage("{PropertyName} is invalid.");

            When(x => AssertStringEnum(x.AttributionModel, ConversionAttributionModelEnum.LastEntryInPath), () =>
            {
                RuleFor(x => x.PostViewLifetime)
                    .NotNull();

                RuleFor(x => x.PostViewLifetimePeriod)
                    .NotNull();
            });

            RuleFor(x => x.PostViewLifetime)
                .InclusiveBetween(1, 129600)
                .When(x => AssertStringEnum(x.AttributionModel, ConversionAttributionModelEnum.LastEntryInPath) && AssertStringEnum(x.PostViewLifetimePeriod, PeriodTypeEnum.PerMinute));

            RuleFor(x => x.PostViewLifetime)
                .InclusiveBetween(1, 2160)
                .When(x => AssertStringEnum(x.AttributionModel, ConversionAttributionModelEnum.LastEntryInPath) && AssertStringEnum(x.PostViewLifetimePeriod, PeriodTypeEnum.PerHour));

            RuleFor(x => x.PostViewLifetime)
                .InclusiveBetween(1, 90)
                .When(x => AssertStringEnum(x.AttributionModel, ConversionAttributionModelEnum.LastEntryInPath) && AssertStringEnum(x.PostViewLifetimePeriod, PeriodTypeEnum.PerDay));

            RuleFor(x => x.PostViewLifetime)
                .InclusiveBetween(1, 12)
                .When(x => AssertStringEnum(x.AttributionModel, ConversionAttributionModelEnum.LastEntryInPath) && AssertStringEnum(x.PostViewLifetimePeriod, PeriodTypeEnum.PerWeek));

            RuleFor(x => x.PostViewLifetime)
                .InclusiveBetween(1, 3)
                .When(x => AssertStringEnum(x.AttributionModel, ConversionAttributionModelEnum.LastEntryInPath) && AssertStringEnum(x.PostViewLifetimePeriod, PeriodTypeEnum.PerMonth));

            RuleFor(x => x.PostClickLifetime)
                .InclusiveBetween(1, 129600)
                .When(x => AssertStringEnum(x.PostClickLifetimePeriod, PeriodTypeEnum.PerMinute));

            RuleFor(x => x.PostClickLifetime)
                .InclusiveBetween(1, 2160)
                .When(x => AssertStringEnum(x.PostClickLifetimePeriod, PeriodTypeEnum.PerHour));

            RuleFor(x => x.PostClickLifetime)
                .InclusiveBetween(1, 90)
                .When(x => AssertStringEnum(x.PostClickLifetimePeriod, PeriodTypeEnum.PerDay));

            RuleFor(x => x.PostClickLifetime)
                .InclusiveBetween(1, 12)
                .When(x => AssertStringEnum(x.PostClickLifetimePeriod, PeriodTypeEnum.PerWeek));

            RuleFor(x => x.PostClickLifetime)
                .InclusiveBetween(1, 3)
                .When(x => AssertStringEnum(x.PostClickLifetimePeriod, PeriodTypeEnum.PerMonth));

            When(x => AssertStringEnum(x.AttributionCountingMode, ConversionAttributionCountingModeEnum.OncePerRecency), () =>
            {
                RuleFor(x => x.AttributionCountingRecency)
                    .NotNull();

                RuleFor(x => x.AttributionCountingRecencyPeriod)
                    .NotNull();
            });

            RuleFor(x => x.AttributionCountingRecency)
                .InclusiveBetween(1, 129600)
                .When(x => AssertStringEnum(x.AttributionCountingMode, ConversionAttributionCountingModeEnum.OncePerRecency) && AssertStringEnum(x.AttributionCountingRecencyPeriod, PeriodTypeEnum.PerMinute));

            RuleFor(x => x.AttributionCountingRecency)
                .InclusiveBetween(1, 2160)
                .When(x => AssertStringEnum(x.AttributionCountingMode, ConversionAttributionCountingModeEnum.OncePerRecency) && AssertStringEnum(x.AttributionCountingRecencyPeriod, PeriodTypeEnum.PerHour));

            RuleFor(x => x.AttributionCountingRecency)
                .InclusiveBetween(1, 90)
                .When(x => AssertStringEnum(x.AttributionCountingMode, ConversionAttributionCountingModeEnum.OncePerRecency) && AssertStringEnum(x.AttributionCountingRecencyPeriod, PeriodTypeEnum.PerDay));

            RuleFor(x => x.AttributionCountingRecency)
                .InclusiveBetween(1, 12)
                .When(x => AssertStringEnum(x.AttributionCountingMode, ConversionAttributionCountingModeEnum.OncePerRecency) && AssertStringEnum(x.AttributionCountingRecencyPeriod, PeriodTypeEnum.PerWeek));

            RuleFor(x => x.AttributionCountingRecency)
                .InclusiveBetween(1, 3)
                .When(x => AssertStringEnum(x.AttributionCountingMode, ConversionAttributionCountingModeEnum.OncePerRecency) && AssertStringEnum(x.AttributionCountingRecencyPeriod, PeriodTypeEnum.PerMonth));
        }
    }

    public class SegmentConversionCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<SegmentConversionCreateViewModel, Segment>()
                .ConstructUsing(ctx =>
                {
                    var source = (SegmentConversionCreateViewModel) ctx.SourceValue;
                    if (!source.AdvertiserUuid.HasValue) throw new InvalidOperationException("AdvertiserUuid is required."); // shouldn't happen

                    var advertiserService = ctx.Resolve<IAdvertiserService>();
                    var advertiser = advertiserService.GetAdvertiser(source.AdvertiserUuid.Value).WaitAndUnwrapException();

                    var retVal = new Segment
                    {
                        BuyerAccountId = advertiser.BuyerAccountId,
                        AdvertiserId = advertiser.AdvertiserId,
                        SegmentTypeId = (int) SegmentTypeEnum.Conversion
                    };
                    return retVal;
                })
                .ForMember(dst => dst.SegmentName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.SegmentDescription, opt => opt.MapFrom(src => ToClearUrl(src.Url)))
                .ForMember(dst => dst.ConversionAttributionModelId, opt => opt.MapFrom(src => Parse<ConversionAttributionModelEnum>(src.AttributionModel)))
                .ForMember(dst => dst.AttributionModel, opt => opt.Ignore()) // see above line
                .ForMember(dst => dst.ConversionPostViewLifetime, opt =>
                {
                    opt.PreCondition(src => AssertStringEnum(src.AttributionModel, ConversionAttributionModelEnum.LastEntryInPath));
                    opt.MapFrom(src => src.PostViewLifetime);
                })
                .ForMember(dst => dst.ConversionPostViewLifetimePeriodId, opt =>
                {
                    opt.PreCondition(src => AssertStringEnum(src.AttributionModel, ConversionAttributionModelEnum.LastEntryInPath));
                    opt.MapFrom(src => Parse<PeriodTypeEnum>(src.PostViewLifetimePeriod));
                })
                .ForMember(dst => dst.ConversionPostClickLifetime, opt => opt.MapFrom(src => src.PostClickLifetime))
                .ForMember(dst => dst.ConversionPostClickLifetimePeriodId, opt => opt.MapFrom(src => Parse<PeriodTypeEnum>(src.PostClickLifetimePeriod)))
                .ForMember(dst => dst.ConversionAttributionCountingModeId, opt => opt.MapFrom(src => Parse<ConversionAttributionCountingModeEnum>(src.AttributionCountingMode)))
                .ForMember(dst => dst.AttributionCountingMode, opt => opt.Ignore()) // see above line
                .ForMember(dst => dst.ConversionAttributionCountingRecency, opt =>
                {
                    opt.PreCondition(src => AssertStringEnum(src.AttributionCountingMode, ConversionAttributionCountingModeEnum.OncePerRecency));
                    opt.MapFrom(src => src.AttributionCountingRecency);
                })
                .ForMember(dst => dst.ConversionAttributionCountingRecencyPeriodId, opt =>
                {
                    opt.PreCondition(src => AssertStringEnum(src.AttributionCountingMode, ConversionAttributionCountingModeEnum.OncePerRecency));
                    opt.MapFrom(src => Parse<PeriodTypeEnum>(src.AttributionCountingRecencyPeriod));
                });
        }
    }
}
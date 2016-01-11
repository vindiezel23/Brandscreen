using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services.Advertisers;
using Brandscreen.Core.Services.Segments;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;
using FluentValidation;
using Nito.AsyncEx.Synchronous;
using static Brandscreen.Core.Services.UrlHelper;

namespace Brandscreen.WebApi.Models
{
    public class SegmentRemarketingCreateViewModel
    {
        [Required]
        public Guid? AdvertiserUuid { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Url { get; set; }

        [Required]
        [Range(1, 90)]
        public int? RemarketingRecency { get; set; }
    }

    public class SegmentRemarketingCreateViewModelValidator : AbstractValidator<SegmentRemarketingCreateViewModel>
    {
        public SegmentRemarketingCreateViewModelValidator()
        {
            RuleFor(x => x.Url)
                .MustAsync(IsValidUrl)
                .When(x => !string.IsNullOrEmpty(x.Url))
                .WithMessage("{PropertyName} is invalid.");
        }
    }

    public class SegmentRemarketingCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<SegmentRemarketingCreateViewModel, Segment>()
                .ConstructUsing(ctx =>
                {
                    var source = (SegmentRemarketingCreateViewModel) ctx.SourceValue;
                    if (!source.AdvertiserUuid.HasValue) throw new InvalidOperationException("AdvertiserUuid is required."); // shouldn't happen

                    var advertiserService = ctx.Resolve<IAdvertiserService>();
                    var advertiser = advertiserService.GetAdvertiser(source.AdvertiserUuid.Value).WaitAndUnwrapException();

                    var retVal = new Segment
                    {
                        BuyerAccountId = advertiser.BuyerAccountId,
                        AdvertiserId = advertiser.AdvertiserId,
                        SegmentTypeId = (int) SegmentTypeEnum.Remarketing
                    };
                    return retVal;
                })
                .ForMember(dst => dst.SegmentName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.SegmentDescription, opt => opt.MapFrom(src => ToClearUrl(src.Url)))
                .ForMember(dst => dst.RemarketingRecency, opt => opt.MapFrom(src => src.RemarketingRecency));
        }
    }
}
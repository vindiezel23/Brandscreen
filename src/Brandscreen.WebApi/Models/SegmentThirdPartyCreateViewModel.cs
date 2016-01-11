using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services.Campaigns;
using Brandscreen.Core.Services.Segments;
using Brandscreen.Entities;
using Brandscreen.Framework.Services;
using FluentValidation;

namespace Brandscreen.WebApi.Models
{
    public class SegmentThirdPartyCreateViewModel
    {
        public string ParentRtbSegmentId { get; set; }

        [Required]
        [StringLength(24)]
        public string RtbSegmentId { get; set; }

        /// <summary>
        /// Defaults to RtbSegmentId if empty
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Range(0d, 1000000d)]
        public decimal? Cost { get; set; }

        public bool? Selectable { get; set; }

        public bool? HasChildren { get; set; }

        public DateTime? ExpiryDate { get; set; }
    }

    public class SegmentThirdPartyCreateViewModelValidator : AbstractValidator<SegmentThirdPartyCreateViewModel>
    {
        public SegmentThirdPartyCreateViewModelValidator(IClock clock)
        {
            RuleFor(x => x.ExpiryDate)
                .GreaterThan(clock.UtcNow)
                .When(x => x.ExpiryDate.HasValue);
        }
    }

    public class SegmentThirdPartyCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<SegmentThirdPartyCreateViewModel, Segment>()
                .ConstructUsing(ctx =>
                {
                    var parentSegment = (Segment) ctx.Options.Items["parentSegment"];
                    var retVal = new Segment
                    {
                        SegmentParentId = parentSegment.SegmentId,
                        ThirdPartyParentId = parentSegment.SegmentId,
                        TargetGeographyCountryId = parentSegment.TargetGeographyCountryId,
                        SegmentStatusId = (int) CampaignStatusEnum.Live,
                        SegmentTypeId = (int) SegmentTypeEnum.ThirdParty,
                        Priority = 1
                    };
                    return retVal;
                })
                .ForMember(dst => dst.RtbSegmentId, opt => opt.MapFrom(src => src.RtbSegmentId))
                .ForMember(dst => dst.SegmentName, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Name) ? src.Name : src.RtbSegmentId))
                .ForMember(dst => dst.SegmentDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.ThirdPartyCost, opt => opt.MapFrom(src => src.Cost)) // currency ???
                .ForMember(dst => dst.ThirdPartySelectable, opt => opt.MapFrom(src => src.Selectable))
                .ForMember(dst => dst.ThirdPartyHasChildren, opt => opt.MapFrom(src => src.HasChildren))
                .ForMember(dst => dst.UtcSegmentExpiryDate, opt => opt.MapFrom(src => src.ExpiryDate));
        }
    }
}
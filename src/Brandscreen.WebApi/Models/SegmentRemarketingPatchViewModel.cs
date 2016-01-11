using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Entities;
using FluentValidation;
using static Brandscreen.Core.Services.UrlHelper;

namespace Brandscreen.WebApi.Models
{
    public class SegmentRemarketingPatchViewModel
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Url { get; set; }

        [Range(1, 90)]
        public int? RemarketingRecency { get; set; }
    }

    public class SegmentRemarketingPatchViewModelValidator : AbstractValidator<SegmentRemarketingPatchViewModel>
    {
        public SegmentRemarketingPatchViewModelValidator()
        {
            RuleFor(x => x.Url)
                .MustAsync(IsValidUrl)
                .When(x => !string.IsNullOrEmpty(x.Url))
                .WithMessage("{PropertyName} is invalid.");
        }
    }

    public class SegmentRemarketingPatchViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<SegmentRemarketingPatchViewModel, Segment>()
                .ForMember(dst => dst.SegmentName, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.Name));
                    opt.MapFrom(src => src.Name);
                })
                .ForMember(dst => dst.SegmentDescription, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.Url));
                    opt.MapFrom(src => ToClearUrl(src.Url));
                })
                .ForAllMembers(opt => opt.Condition(ctx => !ctx.IsSourceValueNull)); // for partial updates
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class SegmentThirdPartyPatchViewModel
    {
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

    public class SegmentThirdPartyPatchViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<SegmentThirdPartyPatchViewModel, Segment>()
                .ForMember(dst => dst.SegmentName, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.Name));
                    opt.MapFrom(src => src.Name);
                })
                .ForMember(dst => dst.SegmentDescription, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.Description));
                    opt.MapFrom(src => src.Description);
                })
                .ForMember(dst => dst.ThirdPartyCost, opt =>
                {
                    opt.PreCondition(src => src.Cost.HasValue);
                    opt.MapFrom(src => src.Cost); // currency ???
                })
                .ForMember(dst => dst.ThirdPartySelectable, opt =>
                {
                    opt.PreCondition(src => src.Selectable.HasValue);
                    opt.MapFrom(src => src.Selectable);
                })
                .ForMember(dst => dst.ThirdPartyHasChildren, opt =>
                {
                    opt.PreCondition(src => src.HasChildren.HasValue);
                    opt.MapFrom(src => src.HasChildren);
                })
                .ForMember(dst => dst.UtcSegmentExpiryDate, opt =>
                {
                    opt.PreCondition(src => src.ExpiryDate.HasValue);
                    opt.MapFrom(src => src.ExpiryDate);
                })
                .ForAllMembers(opt => opt.Condition(ctx => !ctx.IsSourceValueNull)); // for partial updates
        }
    }
}
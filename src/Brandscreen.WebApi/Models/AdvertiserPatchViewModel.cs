using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class AdvertiserPatchViewModel
    {
        [StringLength(100, MinimumLength = 1)]
        public string AdvertiserName { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public string AdvertiserHomepageUrl { get; set; }

        public int? IndustryCategoryId { get; set; }
    }

    public class AdvertiserPatchViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdvertiserPatchViewModel, Advertiser>()
                .ForAllMembers(opt => opt.Condition(ctx => !ctx.IsSourceValueNull)); // for partial updates
        }
    }
}
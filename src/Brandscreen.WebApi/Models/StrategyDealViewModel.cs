using System;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyDealViewModel
    {
        public Guid DealUuid { get; set; }
        public int TargetingActionId { get; set; } // TargetingActionID
    }

    public class StrategyDealViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupDeal, StrategyDealViewModel>()
                .ForMember(dst => dst.DealUuid, opt => opt.MapFrom(src => src.Deal.DealUuid));
        }
    }
}
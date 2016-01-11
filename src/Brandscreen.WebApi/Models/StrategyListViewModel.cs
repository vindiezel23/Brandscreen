using System;
using AutoMapper;
using Brandscreen.Core.Services.Campaigns;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyListViewModel
    {
        public Guid StrategyUuid { get; set; }
        public string StrategyName { get; set; }
        public Guid CampaignUuid { get; set; }
        public string GoalType { get; set; }
        public string FlightType { get; set; }
        public decimal BudgetAmount { get; set; }
        public DateTime? UtcStartDateTime { get; set; }
        public DateTime? UtcEndDateTime { get; set; }
        public string StrategyStatus { get; set; }
        public string MediaType { get; set; }
    }

    public class StrategyListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroup, StrategyListViewModel>()
                .ForMember(dst => dst.StrategyUuid, opt => opt.MapFrom(src => src.AdGroupUuid))
                .ForMember(dst => dst.StrategyName, opt => opt.MapFrom(src => src.AdGroupName))
                .ForMember(dst => dst.CampaignUuid, opt => opt.MapFrom(src => src.Campaign.CampaignUuid))
                .ForMember(dst => dst.GoalType, opt => opt.MapFrom(src => (GoalTypeEnum) src.GoalTypeId))
                .ForMember(dst => dst.FlightType, opt => opt.MapFrom(src => src.BudgetPeriodId == 0 && src.UtcStartDateTime.HasValue && src.UtcEndDateTime.HasValue ? FlightTypeEnum.SingleFlight : (FlightTypeEnum) src.BudgetPeriodId))
                .ForMember(dst => dst.StrategyStatus, opt => opt.MapFrom(src => (CampaignStatusEnum) src.AdGroupStatusId))
                .ForMember(dst => dst.MediaType, opt => opt.MapFrom(src => (MediaTypeEnum) src.MediaTypeId));
        }
    }
}
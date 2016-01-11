using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyPartnerSeatViewModel
    {
        public int PartnerId { get; set; }
        public string BuyerId { get; set; }
        public int TargetingActionId { get; set; }
    }

    public class StrategyPartnerSeatViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupPartnerSeat, StrategyPartnerSeatViewModel>();
        }
    }
}
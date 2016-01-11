using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategySupplySourceViewModel
    {
        public int PartnerId { get; set; } // PartnerID (Primary key)
        public int PublisherId { get; set; } // PublisherID (Primary key) 
        public int TargetingActionId { get; set; } // TargetingActionID
    }

    public class StrategySupplySourceViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupSupplySource, StrategySupplySourceViewModel>();
        }
    }
}
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyVerticalViewModel
    {
        public int VerticalId { get; set; } // VerticalID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
    }

    public class StrategyVerticalViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupVertical, StrategyVerticalViewModel>();
        }
    }
}
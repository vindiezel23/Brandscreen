using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyDoohPanelLocationViewModel
    {
        public int DoohPanelLocationId { get; set; } // DoohPanelLocationID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
    }

    public class StrategyDoohPanelLocationViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupDoohPanelLocation, StrategyDoohPanelLocationViewModel>();
        }
    }
}
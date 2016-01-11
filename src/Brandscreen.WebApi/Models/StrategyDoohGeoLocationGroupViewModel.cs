using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyDoohGeoLocationGroupViewModel
    {
        public int DoohGeoLocationGroupId { get; set; } // DoohGeoLocationGroupID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID 
    }

    public class StrategyDoohGeoLocationGroupViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupDoohGeoLocationGroup, StrategyDoohGeoLocationGroupViewModel>();
        }
    }
}
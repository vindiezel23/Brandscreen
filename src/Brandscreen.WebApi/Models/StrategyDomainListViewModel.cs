using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyDomainListViewModel
    {
        public int DomainListId { get; set; } // DomainListID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID 
    }

    public class StrategyDomainListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupDomainList, StrategyDomainListViewModel>();
        }
    }
}
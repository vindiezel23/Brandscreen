using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyInventoryViewModel
    {
        public long InventoryId { get; set; } // InventoryID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public bool IsUploaded { get; set; } // IsUploaded
    }

    public class StrategyInventoryViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupInventory, StrategyInventoryViewModel>();
        }
    }
}
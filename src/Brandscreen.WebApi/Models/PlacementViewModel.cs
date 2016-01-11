using System;
using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;

namespace Brandscreen.WebApi.Models
{
    public class PlacementViewModel
    {
        public Guid PlacementUuid { get; set; } // PlacementUuid
        public int PlacementStatusId { get; set; } // PlacementStatusID
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime

        public Guid BuyerAccountUuid { get; set; }
        public Guid StrategyUuid { get; set; }
        public Guid CreativeUuid { get; set; }

        public int PlacementId { get; set; } // PlacementID (Primary key)
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public int StrategyId { get; set; } // AdGroupID
        public int CreativeId { get; set; } // CreativeID
    }

    public class PlacementViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Placement, PlacementViewModel>()
                .ConstructUsing(context =>
                {
                    var placement = (Placement) context.SourceValue;
                    var isGod = context.Resolve<IAuthorizationService>().CanAccessEverything();
                    var retVal = new PlacementViewModel
                    {
                        // security concern: only show short id in god mode
                        PlacementId = isGod ? placement.PlacementId : -1,
                        BuyerAccountId = isGod ? placement.BuyerAccountId : -1,
                        StrategyId = isGod ? placement.AdGroupId : -1,
                        CreativeId = isGod ? placement.CreativeId : -1
                    };
                    return retVal;
                })
                .ForMember(dst => dst.BuyerAccountUuid, opt => opt.MapFrom(src => src.BuyerAccount.BuyerAccountUuid))
                .ForMember(dst => dst.StrategyUuid, opt => opt.MapFrom(src => src.AdGroup.AdGroupUuid))
                .ForMember(dst => dst.CreativeUuid, opt => opt.MapFrom(src => src.Creative.CreativeUuid));
        }
    }
}
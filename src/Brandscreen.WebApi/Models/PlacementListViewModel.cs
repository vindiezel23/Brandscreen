using System;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class PlacementListViewModel
    {
        public Guid PlacementUuid { get; set; } // PlacementUuid
        public int PlacementStatusId { get; set; } // PlacementStatusID
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
    }

    public class PlacementListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Placement, PlacementListViewModel>();
        }
    }
}
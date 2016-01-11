using System;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class DealListViewModel
    {
        public Guid DealUuid { get; set; } // DealUuid
        public string DealKey { get; set; } // DealKey
        public string DealName { get; set; } // DealName
        public int DealTypeId { get; set; } // DealTypeID
        public DateTime UtcStartDateTime { get; set; } // UtcStartDateTime
        public DateTime UtcEndDateTime { get; set; } // UtcEndDateTime
        public int DealStatusId { get; set; } // DealStatusID
    }

    public class DealListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Deal, DealListViewModel>();
        }
    }
}
using System;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class PublisherListViewModel
    {
        public int PublisherId { get; set; } // PublisherID (Primary key)
        public Guid PublisherUuid { get; set; } // PublisherUuid
        public string PublisherName { get; set; } // PublisherName
        public int PartnerId { get; set; } // PartnerID
        public string PartnerKey { get; set; } // PartnerKey
        public int PrivateMarketModeId { get; set; } // PrivateMarketModeID
    }

    public class PublisherListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Publisher, PublisherListViewModel>();
        }
    }
}
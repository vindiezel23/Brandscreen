using System;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class PublisherViewModel
    {
        public int PublisherId { get; set; } // PublisherID (Primary key)
        public Guid PublisherUuid { get; set; } // PublisherUuid
        public string PublisherName { get; set; } // PublisherName
        public int PartnerId { get; set; } // PartnerID
        public string PartnerKey { get; set; } // PartnerKey
        public int PrivateMarketModeId { get; set; } // PrivateMarketModeID

        public PartnerViewModel Partner { get; set; }
    }

    public class PublisherViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Publisher, PublisherViewModel>();
        }
    }
}
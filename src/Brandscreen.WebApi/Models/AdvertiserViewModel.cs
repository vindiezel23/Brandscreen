using System;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class AdvertiserViewModel
    {
        public Guid AdvertiserUuid { get; set; } // AdvertiserUuid
        public string AdvertiserName { get; set; } // AdvertiserName
        public string AdvertiserHomepageUrl { get; set; } // AdvertiserHomepageUrl
        public int IndustryCategoryId { get; set; } // IndustryCategoryID
        public int AdTagServerId { get; set; } // AdTagServerID
        public int PixelTagServerId { get; set; } // PixelTagServerID
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
    }

    public class AdvertiserViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Advertiser, AdvertiserViewModel>();
        }
    }
}
using System;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class AdvertiserListViewModel
    {
        public Guid AdvertiserUuid { get; set; } // AdvertiserUuid
        public string AdvertiserName { get; set; } // AdvertiserName
        public string AdvertiserHomepageUrl { get; set; } // AdvertiserHomepageUrl
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
    }

    public class AdvertiserListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Advertiser, AdvertiserListViewModel>();
        }
    }
}
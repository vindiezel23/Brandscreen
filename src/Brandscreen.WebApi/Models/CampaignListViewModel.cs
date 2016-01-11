using System;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class CampaignListViewModel
    {
        public Guid CampaignUuid { get; set; }
        public string CampaignName { get; set; }
        public string AgencyReference { get; set; }
    }

    public class CampaignListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Campaign, CampaignListViewModel>();
        }
    }
}
using System;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class CampaignViewModel
    {
        public Guid CampaignUuid { get; set; }
        public Guid BuyerAccountUuid { get; set; }
        public Guid BrandUuid { get; set; }
        public string CampaignName { get; set; }
        public string AgencyReference { get; set; }
        public string CompanyName { get; set; }
        public decimal Margin { get; set; }
        public decimal BudgetAmount { get; set; }
    }

    public class CampaignViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Campaign, CampaignViewModel>()
                .ForMember(dst => dst.CompanyName, opt => opt.MapFrom(src => src.BuyerAccount.CompanyName))
                .ForMember(dst => dst.BuyerAccountUuid, opt => opt.MapFrom(src => src.BuyerAccount.BuyerAccountUuid))
                .ForMember(dst => dst.BrandUuid, opt => opt.MapFrom(src => src.AdvertiserProduct.AdvertiserProductUuid));
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services.Brands;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class CampaignCreateViewModel
    {
        [Required]
        public Guid? BrandUuid { get; set; }

        [Required]
        [StringLength(200)]
        public string CampaignName { get; set; }

        [StringLength(50)]
        public string AgencyReference { get; set; }

        [Range(0d, 1d)]
        public decimal Margin { get; set; }

        [Range(0d, 1000000d)]
        public decimal BudgetAmount { get; set; }
    }

    public class CampaignCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CampaignCreateViewModel, Campaign>()
                .ConstructUsing(ctx =>
                {
                    var source = (CampaignCreateViewModel) ctx.SourceValue;
                    if (!source.BrandUuid.HasValue) throw new InvalidOperationException("BrandUuid is required."); // shouldn't happen

                    var brandService = ctx.Resolve<IBrandService>();
                    var brand = brandService.GetBrand(source.BrandUuid.Value).WaitAndUnwrapException();

                    var retVal = new Campaign
                    {
                        BuyerAccountId = brand.BuyerAccountId,
                        AdvertiserProductId = brand.AdvertiserProductId
                    };
                    return retVal;
                })
                .ForMember(dst => dst.BuyerAccountId, opt => opt.Ignore()) // as mapped in ConstructUsing
                .ForMember(dst => dst.AdvertiserProductId, opt => opt.Ignore()); // as mapped in ConstructUsing
        }
    }
}
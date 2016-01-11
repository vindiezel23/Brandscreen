using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class CampaignPatchViewModel
    {
        [StringLength(200)]
        public string CampaignName { get; set; }

        [StringLength(50)]
        public string AgencyReference { get; set; }

        [Range(0d, 1d)]
        public decimal? Margin { get; set; }

        [Range(0d, 1000000d)]
        public decimal? BudgetAmount { get; set; }
    }

    public class CampaignPatchViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CampaignPatchViewModel, Campaign>()
                .ForAllMembers(opt => opt.Condition(ctx => !ctx.IsSourceValueNull)); // for partial updates
        }
    }
}
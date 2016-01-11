using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services.Campaigns;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;
using FluentValidation;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class StrategyCreateViewModel
    {
        [Required]
        public Guid? CampaignUuid { get; set; }

        [Required]
        [StringLength(200)]
        public string StrategyName { get; set; }

        /// <summary>
        /// PublicMarket, or PrivateMarket
        /// </summary>
        [Required]
        [EnumDataType(typeof (SupplySourceEnum))]
        public string SupplySource { get; set; }

        /// <summary>
        /// Display, Video, Mobile, Facebook, or Dooh
        /// </summary>
        [Required]
        [EnumDataType(typeof (MediaTypeEnum))]
        public string MediaType { get; set; }
    }

    public class StrategyCreateViewModelValidator : AbstractValidator<StrategyCreateViewModel>
    {
        public StrategyCreateViewModelValidator()
        {
            RuleFor(x => x.MediaType)
                .Must(x =>
                {
                    MediaTypeEnum mediaType;
                    return !Enum.TryParse(x, true, out mediaType) || mediaType == MediaTypeEnum.Display || mediaType == MediaTypeEnum.Video;
                })
                .When(x =>
                {
                    SupplySourceEnum supplySource;
                    return Enum.TryParse(x.SupplySource, true, out supplySource) && supplySource == SupplySourceEnum.PrivateMarket;
                })
                .WithMessage("Private deal only allowed for Display or Video strategy.");
        }
    }

    public class StrategyCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<StrategyCreateViewModel, AdGroup>()
                .ConstructUsing(ctx =>
                {
                    var source = (StrategyCreateViewModel) ctx.SourceValue;
                    if (!source.CampaignUuid.HasValue) throw new InvalidOperationException("CampaignUuid is required."); // shouldn't happen

                    var campaignService = ctx.Resolve<ICampaignService>();
                    var campaign = campaignService.GetCampaign(source.CampaignUuid.Value).WaitAndUnwrapException();

                    var retVal = new AdGroup
                    {
                        CampaignId = campaign.CampaignId,
                        BuyerAccountId = campaign.BuyerAccountId,
                    };
                    return retVal;
                })
                .ForMember(dst => dst.AdGroupName, opt => opt.MapFrom(src => src.StrategyName))
                .ForMember(dst => dst.SupplySourceId, opt => opt.MapFrom(src => Enum.Parse(typeof (SupplySourceEnum), src.SupplySource, true)))
                .ForMember(dst => dst.SupplySource, opt => opt.Ignore())
                .ForMember(dst => dst.MediaTypeId, opt => opt.MapFrom(src => Enum.Parse(typeof (MediaTypeEnum), src.MediaType, true)))
                .ForMember(dst => dst.MediaType, opt => opt.Ignore());
        }
    }
}
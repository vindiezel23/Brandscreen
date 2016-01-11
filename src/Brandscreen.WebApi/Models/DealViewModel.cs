using System;
using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Deals;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;

namespace Brandscreen.WebApi.Models
{
    public class DealViewModel
    {
        public Guid DealUuid { get; set; } // DealUuid
        public string DealKey { get; set; } // DealKey
        public string DealName { get; set; } // DealName
        public int PublisherId { get; set; } // PublisherID
        public int DealTypeId { get; set; } // DealTypeID
        public int FloorPriceCents { get; set; } // FloorPriceCents
        public int CeilingPriceCents { get; set; } // CeilingPriceCents
        public DateTime UtcStartDateTime { get; set; } // UtcStartDateTime
        public DateTime UtcEndDateTime { get; set; } // UtcEndDateTime
        public int DealStatusId { get; set; } // DealStatusID
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime? UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public int CurrencyId { get; set; } // CurrencyID
        public string PublishersName { get; set; } // PublishersName
        public int DealModeId { get; set; } // DealModeID
        public string OverrideDisplayUrl { get; set; } // OverrideDisplayUrl
        public int? VerticalId { get; set; } // VerticalID
        public string DealReference { get; set; } // DealReference

        public int BuyerAccountId { get; set; }
        public int DealId { get; set; }

        public string CurrencyCode { get; set; }
        public string PartnerId { get; set; }
    }

    public class DealViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Deal, DealViewModel>()
                .ConstructUsing(context =>
                {
                    var deal = (Deal) context.SourceValue;
                    var isGod = context.Resolve<IAuthorizationService>().CanAccessEverything();
                    var retVal = new DealViewModel
                    {
                        // security concern: only show short id in god mode
                        BuyerAccountId = isGod ? deal.BuyerAccountId : -1,
                        DealId = isGod ? deal.DealId : -1,
                    };
                    return retVal;
                })
                .ForMember(dst => dst.BuyerAccountId, opt => opt.Ignore()) // as mapped in ConstructUsing
                .ForMember(dst => dst.DealId, opt => opt.Ignore()) // as mapped in ConstructUsing
                .ForMember(dst => dst.CurrencyCode, opt => opt.MapFrom(src => src.Currency.Iso4217Code))
                .ForMember(dst => dst.PartnerId, opt => opt.MapFrom(src => src.DealModeId == (int) DealModeEnum.ExchangeDeal ? src.Publisher.PartnerId : (int) PartnerEnum.BrandscreenForPublishers));
        }
    }
}
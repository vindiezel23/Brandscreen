using System;
using AutoMapper;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class AccountViewModel
    {
        public Guid BuyerAccountUuid { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string BuyingGroupName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }

        public string CountryCode { get; set; }
        public string CurrencyCode { get; set; }
        public string LanguageCode { get; set; }
        public string TimeZone { get; set; }

        public DateTime? TermsConditionsAgreedDate { get; set; } // TermsConditionsAgreedDate
        public bool IsAgent { get; set; } // IsAgent
        public decimal CreditLimit { get; set; } // CreditLimit
        public DateTime? TrialEndDate { get; set; } // TrialEndDate
        public Guid? CommercialContactUserId { get; set; } // CommercialContactUserID
        public int? PaymentTermsId { get; set; } // PaymentTermsID
        public int? BillingCycleId { get; set; } // BillingCycleID
        public decimal Brokerage { get; set; } // Brokerage
        public bool IsActive { get; set; } // IsActive
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public decimal BrandSafetyFee { get; set; } // BrandSafetyFee
        public decimal ServiceFee { get; set; } // ServiceFee
        public string Website { get; set; } // Website
        public int? MonthlyCreditId { get; set; } // MonthlyCreditID
        public string BillingContactEmail { get; set; } // BillingContactEmail
        public int ClickFilteringModeId { get; set; } // ClickFilteringModeID
        public decimal DefaultImpressionFee { get; set; } // DefaultImpressionFee
        public decimal MarkupMultiplier { get; set; } // MarkupMultiplier
    }

    public class AccountViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<BuyerAccount, AccountViewModel>()
                .ForMember(dst => dst.CompanyType, opt => opt.MapFrom(src => (CompanyTypeEnum) src.CompanyTypeId))
                .ForMember(dst => dst.CountryCode, opt => opt.MapFrom(src => src.Country.Iso3166Code))
                .ForMember(dst => dst.CurrencyCode, opt => opt.MapFrom(src => src.Currency.Iso4217Code))
                .ForMember(dst => dst.LanguageCode, opt => opt.MapFrom(src => src.Language.Iso4646Code))
                .ForMember(dst => dst.TimeZone, opt => opt.MapFrom(src => src.TimeZone.TimeZoneName));
        }
    }
}
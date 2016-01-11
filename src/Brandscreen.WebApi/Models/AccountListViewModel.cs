using System;
using AutoMapper;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class AccountListViewModel
    {
        public Guid BuyerAccountUuid { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }

        public string CountryCode { get; set; }
        public string CurrencyCode { get; set; }
        public string LanguageCode { get; set; }
        public string TimeZone { get; set; }
    }

    public class AccountListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<BuyerAccount, AccountListViewModel>()
                .ForMember(dst => dst.CompanyType, opt => opt.MapFrom(src => (CompanyTypeEnum) src.CompanyTypeId))
                .ForMember(dst => dst.CountryCode, opt => opt.MapFrom(src => src.Country.Iso3166Code))
                .ForMember(dst => dst.CurrencyCode, opt => opt.MapFrom(src => src.Currency.Iso4217Code))
                .ForMember(dst => dst.LanguageCode, opt => opt.MapFrom(src => src.Language.Iso4646Code))
                .ForMember(dst => dst.TimeZone, opt => opt.MapFrom(src => src.TimeZone.TimeZoneName));
        }
    }
}
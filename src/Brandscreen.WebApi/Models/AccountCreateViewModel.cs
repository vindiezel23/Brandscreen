using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class AccountCreateViewModel
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 1)]
        public string CompanyName { get; set; }

        /// <summary>
        /// MediaAgency, TradingDesk, AdNetwork, or Other
        /// </summary>
        [Required]
        [EnumDataType(typeof (CompanyTypeEnum))]
        public string CompanyType { get; set; }

        /// <summary>
        /// AU by default
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// AUD by default
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// en-AU by default
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// AUS Eastern Standard Time by default
        /// </summary>
        public string TimeZoneCode { get; set; }

        [StringLength(120, MinimumLength = 1)]
        public string BuyingGroupName { get; set; }

        [StringLength(150, MinimumLength = 1)]
        public string AddressLine1 { get; set; }

        [StringLength(150, MinimumLength = 1)]
        public string AddressLine2 { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string City { get; set; }

        [StringLength(25, MinimumLength = 1)]
        public string StateProvince { get; set; }

        [StringLength(10, MinimumLength = 1)]
        public string PostalCode { get; set; }

        [StringLength(250, MinimumLength = 1)]
        public string Website { get; set; }

        [StringLength(250, MinimumLength = 1)]
        public string BillingContactEmail { get; set; }
    }

    public class AccountCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AccountCreateViewModel, BuyerAccount>()
                .ForMember(dst => dst.CompanyTypeId, opt => opt.MapFrom(src => Enum.Parse(typeof (CompanyTypeEnum), src.CompanyType, true)))
                .ForMember(dst => dst.CompanyType, opt => opt.Ignore())
                .ForMember(dst => dst.CountryId, opt =>
                {
                    opt.ResolveUsing(result =>
                    {
                        var source = (AccountCreateViewModel) result.Value;
                        var country = result.Context.Resolve<ICountryService>().GetCountryOrDefault(source.CountryCode).WaitAndUnwrapException();
                        return country.CountryId;
                    });
                })
                .ForMember(dst => dst.CurrencyId, opt =>
                {
                    opt.ResolveUsing(result =>
                    {
                        var source = (AccountCreateViewModel) result.Value;
                        var currency = result.Context.Resolve<ICurrencyService>().GetCurrencyOrDefault(source.CurrencyCode).WaitAndUnwrapException();
                        return currency.CurrencyId;
                    });
                })
                .ForMember(dst => dst.LanguageId, opt =>
                {
                    opt.ResolveUsing(result =>
                    {
                        var source = (AccountCreateViewModel) result.Value;
                        var language = result.Context.Resolve<ILanguageService>().GetLanguageOrDefault(source.LanguageCode).WaitAndUnwrapException();
                        return language.LanguageId;
                    });
                })
                .ForMember(dst => dst.TimeZoneId, opt =>
                {
                    opt.ResolveUsing(result =>
                    {
                        var source = (AccountCreateViewModel) result.Value;
                        var timeZone = result.Context.Resolve<ITimeZoneService>().GetTimeZoneOrDefault(source.TimeZoneCode).WaitAndUnwrapException();
                        return timeZone.TimeZoneId;
                    });
                });
        }
    }
}
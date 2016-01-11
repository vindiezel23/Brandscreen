using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class AccountPatchViewModel
    {
        [StringLength(120, MinimumLength = 1)]
        public string CompanyName { get; set; }

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

        public string CountryCode { get; set; }
        public string LanguageCode { get; set; }
        public string TimeZoneCode { get; set; }
    }

    public class AccountPatchViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AccountPatchViewModel, BuyerAccount>()
                .ForMember(dst => dst.CountryId, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.CountryCode));
                    opt.ResolveUsing(result =>
                    {
                        var source = (AccountPatchViewModel) result.Value;
                        var country = result.Context.Resolve<ICountryService>().GetCountryOrDefault(source.CountryCode).WaitAndUnwrapException();
                        return country.CountryId;
                    });
                })
                .ForMember(dst => dst.LanguageId, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.LanguageCode));
                    opt.ResolveUsing(result =>
                    {
                        var source = (AccountPatchViewModel) result.Value;
                        var language = result.Context.Resolve<ILanguageService>().GetLanguageOrDefault(source.LanguageCode).WaitAndUnwrapException();
                        return language.LanguageId;
                    });
                })
                .ForMember(dst => dst.TimeZoneId, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.TimeZoneCode));
                    opt.ResolveUsing(result =>
                    {
                        var source = (AccountPatchViewModel) result.Value;
                        var timeZone = result.Context.Resolve<ITimeZoneService>().GetTimeZoneOrDefault(source.TimeZoneCode).WaitAndUnwrapException();
                        return timeZone.TimeZoneId;
                    });
                })
                .ForAllMembers(opt => opt.Condition(ctx => !ctx.IsSourceValueNull)); // for partial updates
        }
    }
}
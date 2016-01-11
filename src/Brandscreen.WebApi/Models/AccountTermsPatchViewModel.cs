using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class AccountTermsPatchViewModel
    {
        [Range(0d, 1000000d)]
        public decimal? CreditLimit { get; set; } // CreditLimit

        [Range(0d, 1000000d)]
        public decimal? BrandSafetyFee { get; set; } // BrandSafetyFee

        [Range(0d, 1000000d)]
        public decimal? ServiceFee { get; set; } // ServiceFee

        public string CurrencyCode { get; set; }
    }

    public class AccountTermsPatchViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AccountTermsPatchViewModel, BuyerAccount>()
                .ForMember(dst => dst.CurrencyId, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.CurrencyCode));
                    opt.ResolveUsing(result =>
                    {
                        var source = (AccountTermsPatchViewModel) result.Value;
                        var currency = result.Context.Resolve<ICurrencyService>().GetCurrencyOrDefault(source.CurrencyCode).WaitAndUnwrapException();
                        return currency.CurrencyId;
                    });
                })
                .ForAllMembers(opt => opt.Condition(ctx => !ctx.IsSourceValueNull)); // for partial updates
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class AdvertiserCreateViewModel
    {
        [Required]
        public Guid? BuyerAccountUuid { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string AdvertiserName { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string AdvertiserHomepageUrl { get; set; }

        [Required]
        public int? IndustryCategoryId { get; set; }
    }

    public class AdvertiserCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdvertiserCreateViewModel, Advertiser>()
                .ForMember(dst => dst.BuyerAccountId, opt => opt.ResolveUsing(result =>
                {
                    var source = (AdvertiserCreateViewModel) result.Value;
                    if (!source.BuyerAccountUuid.HasValue) throw new InvalidOperationException("BuyerAccountUuid is required."); // shouldn't happen

                    var accountService = result.Context.Resolve<IAccountService>();
                    return accountService.GetAccount(source.BuyerAccountUuid.Value).WaitAndUnwrapException().BuyerAccountId;
                }));
        }
    }
}
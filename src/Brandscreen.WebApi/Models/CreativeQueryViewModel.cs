using System;
using System.Linq;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Core.Services.Users;
using Brandscreen.WebApi.Mappings;
using Brandscreen.WebApi.Paginations;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class CreativeQueryViewModel : Pagination
    {
        public Guid? UserId { get; set; }
        public Guid? BuyerAccountUuid { get; set; }
        public Guid? AdvertiserUuid { get; set; }
        public Guid? BrandUuid { get; set; }
        public Guid? StrategyUuid { get; set; }

        /// <summary>
        /// Filter by ad tag template media type id.
        /// </summary>
        public int? MediaTypeId { get; set; }

        /// <summary>
        /// Filter by creative name.
        /// </summary>
        public string Text { get; set; }
    }

    public class CreativeQueryViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeQueryViewModel, CreativeQueryOptions>()
                .ConstructUsing(ctx =>
                {
                    var source = (CreativeQueryViewModel) ctx.SourceValue;
                    var retVal = new CreativeQueryOptions();

                    // UserId
                    if (source.UserId.HasValue)
                    {
                        var userId = source.UserId.Value;
                        var isAddedAsUserId = false;
                        var userBuyerRoles = ctx.Resolve<IUserService>().GetUserBuyerRoles(userId).ToList();
                        foreach (var userBuyerRole in userBuyerRoles)
                        {
                            if (userBuyerRole.RoleName == StandardRole.Administrator)
                            {
                                // match Advertiser.BuyerAccountId if user is AgencyAdministrator
                                retVal.BuyerAccountIds.Add(userBuyerRole.BuyerAccountId);
                            }
                            else if (!isAddedAsUserId && userBuyerRole.RoleName == StandardRole.User)
                            {
                                // match Advertiser.UserAdvertiserRoles if user is AgencyUser
                                retVal.UserIds.Add(userId);
                                isAddedAsUserId = true;
                            }
                        }
                    }

                    // BuyerAccountUuid
                    if (source.BuyerAccountUuid.HasValue)
                    {
                        var buyerAccountId = ctx.Resolve<IAccountService>().GetAccount(source.BuyerAccountUuid.Value).WaitAndUnwrapException().BuyerAccountId;
                        if (!retVal.BuyerAccountIds.Contains(buyerAccountId))
                        {
                            retVal.BuyerAccountIds.Add(buyerAccountId);
                        }
                    }

                    return retVal;
                })
                .ForMember(dst => dst.AdvertiserUuid, opt => opt.MapFrom(src => src.AdvertiserUuid))
                .ForMember(dst => dst.BrandUuid, opt => opt.MapFrom(src => src.BrandUuid));
        }
    }
}
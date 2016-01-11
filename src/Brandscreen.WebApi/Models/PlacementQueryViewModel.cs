using System;
using System.Linq;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Core.Services.Placements;
using Brandscreen.Core.Services.Users;
using Brandscreen.WebApi.Mappings;
using Brandscreen.WebApi.Paginations;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class PlacementQueryViewModel : Pagination
    {
        public Guid? UserId { get; set; }
        public Guid? BuyerAccountUuid { get; set; }
        public Guid? StrategyUuid { get; set; }
        public Guid? CampaignUuid { get; set; }

        /// <summary>
        /// Filter by strategy name or creative name.
        /// </summary>
        public string Text { get; set; }
    }

    public class PlacementQueryViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<PlacementQueryViewModel, PlacementQueryOptions>()
                .ConstructUsing(ctx =>
                {
                    var source = (PlacementQueryViewModel) ctx.SourceValue;
                    var retVal = new PlacementQueryOptions();

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
                });
        }
    }
}
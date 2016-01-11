using System;
using System.Linq;
using AutoMapper;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Core.Services.Deals;
using Brandscreen.Core.Services.Users;
using Brandscreen.WebApi.Mappings;
using Brandscreen.WebApi.Paginations;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class DealQueryViewModel : Pagination
    {
        public Guid? UserId { get; set; }
        public Guid? BuyerAccountUuid { get; set; }

        /// <summary>
        /// Filter by deal name.
        /// </summary>
        public string Text { get; set; }
    }

    public class DealQueryViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<DealQueryViewModel, DealQueryOptions>()
                .ConstructUsing(ctx =>
                {
                    var source = (DealQueryViewModel) ctx.SourceValue;
                    var retVal = new DealQueryOptions();

                    // UserId
                    if (source.UserId.HasValue)
                    {
                        var userId = source.UserId.Value;
                        var userBuyerRoles = ctx.Resolve<IUserService>().GetUserBuyerRoles(userId).ToList();
                        foreach (var userBuyerRole in userBuyerRoles)
                        {
                            retVal.BuyerAccountIds.Add(userBuyerRole.BuyerAccountId);
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

                    if (source.UserId.HasValue && !source.BuyerAccountUuid.HasValue && retVal.BuyerAccountIds.Count == 0)
                    {
                        // note: just to make sure specified user is not any admin of any buyer account
                        // the service method should return empty user list
                        retVal.BuyerAccountIds.Add(-1);
                    }

                    return retVal;
                });
        }
    }
}
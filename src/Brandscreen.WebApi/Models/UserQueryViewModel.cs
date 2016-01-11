using System;
using System.Linq;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Core.Services.Users;
using Brandscreen.WebApi.Mappings;
using Brandscreen.WebApi.Paginations;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class UserQueryViewModel : Pagination
    {
        /// <summary>
        /// Filter by specified user's buyer accounts where the user is AgencyAdministrator.
        /// Super/System admins can set to anyone, otherwise leave it null or set to the request user id.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Filter by specified buyer account.
        /// </summary>
        public Guid? BuyerAccountUuid { get; set; }

        /// <summary>
        /// Filter by email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Filter by first name or last name.
        /// </summary>
        public string Text { get; set; }
    }

    public class UserQueryViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<UserQueryViewModel, UserQueryOptions>()
                .ConstructUsing(ctx =>
                {
                    var source = (UserQueryViewModel) ctx.SourceValue;

                    var retVal = new UserQueryOptions();

                    if (source.UserId.HasValue)
                    {
                        // retrieve all users under specified user's buyer accounts where the user is AgencyAdministrator
                        var userBuyerRoles = ctx.Resolve<IUserService>().GetUserBuyerRoles(source.UserId.Value)
                            .Where(x => x.RoleName == StandardRole.Administrator)
                            .ToList();
                        foreach (var userBuyerRole in userBuyerRoles)
                        {
                            retVal.BuyerAccountIds.Add(userBuyerRole.BuyerAccountId);
                        }
                    }

                    if (source.BuyerAccountUuid.HasValue)
                    {
                        // retrieve all users under specified buyer account
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
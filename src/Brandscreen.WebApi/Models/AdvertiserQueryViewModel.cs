using System;
using System.Linq;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Advertisers;
using Brandscreen.Core.Services.Users;
using Brandscreen.WebApi.Mappings;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Models
{
    public class AdvertiserQueryViewModel : Pagination
    {
        /// <summary>
        /// Super/System admins can set to anyone, otherwise leave null or set to the request user id.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Filter by advertiser name.
        /// </summary>
        public string Text { get; set; }
    }

    public class AdvertiserQueryViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdvertiserQueryViewModel, AdvertiserQueryOptions>()
                .ConstructUsing(ctx =>
                {
                    var source = (AdvertiserQueryViewModel) ctx.SourceValue;
                    var retVal = new AdvertiserQueryOptions();

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

                    return retVal;
                });
        }
    }
}
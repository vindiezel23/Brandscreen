using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Core.Services.Campaigns;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Core.Services.Users;
using Brandscreen.WebApi.Mappings;
using Brandscreen.WebApi.Paginations;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class StrategyQueryViewModel : Pagination
    {
        public Guid? UserId { get; set; }
        public Guid? BuyerAccountUuid { get; set; }
        public Guid? AdvertiserUuid { get; set; }
        public Guid? BrandUuid { get; set; }
        public Guid? CampaignUuid { get; set; }
        public Guid? CreativeUuid { get; set; }
        public int? PartnerId { get; set; }

        /// <summary>
        /// Pending, Live, Paused, Completed, Deleted, Suspended, or Draft
        /// </summary>
        [EnumDataType(typeof (CampaignStatusEnum))]
        public string StrategyStatus { get; set; }

        /// <summary>
        /// Display, Video, Mobile, Facebook, or Dooh
        /// </summary>
        [EnumDataType(typeof (MediaTypeEnum))]
        public string MediaType { get; set; }

        /// <summary>
        /// Filter by strategy name.
        /// </summary>
        public string Text { get; set; }
    }

    public class StrategyQueryViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<StrategyQueryViewModel, StrategyQueryOptions>()
                .ConstructUsing(ctx =>
                {
                    var source = (StrategyQueryViewModel) ctx.SourceValue;
                    var retVal = new StrategyQueryOptions();

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
                .ForMember(dst => dst.BrandUuid, opt => opt.MapFrom(src => src.BrandUuid))
                .ForMember(dst => dst.CampaignUuid, opt => opt.MapFrom(src => src.CampaignUuid))
                .ForMember(dst => dst.StrategyStatusId, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.StrategyStatus));
                    opt.MapFrom(src => Enum.Parse(typeof (CampaignStatusEnum), src.StrategyStatus, true));
                })
                .ForMember(dst => dst.MediaTypeId, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.MediaType));
                    opt.MapFrom(src => Enum.Parse(typeof (MediaTypeEnum), src.MediaType, true));
                });
        }
    }
}
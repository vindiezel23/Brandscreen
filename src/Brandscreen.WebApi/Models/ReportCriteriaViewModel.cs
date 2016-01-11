using System;
using System.Linq;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Reports;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;
using Brandscreen.WebApi.Paginations;
using Microsoft.Owin;
using Repository.Pattern.Repositories;

namespace Brandscreen.WebApi.Models
{
    public class ReportCriteriaViewModel : Pagination
    {
        public ReportLevelEnum ReportLevel { get; set; }
        public ReportScopeEnum? ReportScope { get; set; }
        public Guid? ReportScopeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class ReportCriteriaViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<ReportCriteriaViewModel, ReportCriteria>()
                .ForMember(dst => dst.Type, opt => opt.Ignore())
                .ForMember(dst => dst.Level, opt => opt.MapFrom(src => src.ReportLevel))
                .ForMember(dst => dst.LocalFromDateTime, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dst => dst.LocalToDateTime, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dst => dst.BuyerAccounts, opt =>
                {
                    opt.PreCondition(src => src.ReportScope == ReportScopeEnum.Buyer || !src.ReportScope.HasValue);
                    opt.ResolveUsing(result =>
                    {
                        var src = (ReportCriteriaViewModel) result.Value;
                        var repo = result.Context.Resolve<IRepositoryAsync<BuyerAccount>>();

                        // using specified: Buyer
                        if (src.ReportScope == ReportScopeEnum.Buyer && src.ReportScopeId.HasValue)
                        {
                            var buyerAccounts = repo.Queryable().Where(x => x.BuyerAccountUuid == src.ReportScopeId.Value).ToList();
                            if (buyerAccounts.Count > 0) return buyerAccounts;
                        }

                        // security critical: using default buyer account ids to limit the scope if no scope supplied
                        var buyerRoles = result.Context.Resolve<IOwinContext>().GetCurrentUserBuyerRoles();
                        return buyerRoles.Select(x => repo.Find(x.BuyerId)).ToList();
                    });
                })
                .ForMember(dst => dst.Advertiser, opt =>
                {
                    opt.PreCondition(src => src.ReportScope == ReportScopeEnum.Advertiser && src.ReportScopeId.HasValue);
                    opt.ResolveUsing(result =>
                    {
                        var repo = result.Context.Resolve<IRepositoryAsync<Advertiser>>();
                        return repo.Queryable().FirstOrDefault(x => x.AdvertiserUuid == ((ReportCriteriaViewModel) result.Value).ReportScopeId);
                    });
                })
                .ForMember(dst => dst.AdvertiserProduct, opt =>
                {
                    opt.PreCondition(src => src.ReportScope == ReportScopeEnum.Brand && src.ReportScopeId.HasValue);
                    opt.ResolveUsing(result =>
                    {
                        var repo = result.Context.Resolve<IRepositoryAsync<AdvertiserProduct>>();
                        return repo.Queryable().FirstOrDefault(x => x.AdvertiserProductUuid == ((ReportCriteriaViewModel) result.Value).ReportScopeId);
                    });
                })
                .ForMember(dst => dst.Campaign, opt =>
                {
                    opt.PreCondition(src => src.ReportScope == ReportScopeEnum.Campaign && src.ReportScopeId.HasValue);
                    opt.ResolveUsing(result =>
                    {
                        var repo = result.Context.Resolve<IRepositoryAsync<Campaign>>();
                        return repo.Queryable().FirstOrDefault(x => x.CampaignUuid == ((ReportCriteriaViewModel) result.Value).ReportScopeId);
                    });
                })
                .ForMember(dst => dst.AdGroup, opt =>
                {
                    opt.PreCondition(src => src.ReportScope == ReportScopeEnum.Strategy && src.ReportScopeId.HasValue);
                    opt.ResolveUsing(result =>
                    {
                        var repo = result.Context.Resolve<IRepositoryAsync<AdGroup>>();
                        return repo.Queryable().FirstOrDefault(x => x.AdGroupUuid == ((ReportCriteriaViewModel) result.Value).ReportScopeId);
                    });
                });
        }
    }
}
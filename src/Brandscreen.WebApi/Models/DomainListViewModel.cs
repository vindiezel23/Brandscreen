using System.Collections;
using AutoMapper;
using Brandscreen.Core.Services.Strategies.Targets;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;
using Brandscreen.WebApi.Paginations;
using Castle.Components.DictionaryAdapter;
using PagedList;

namespace Brandscreen.WebApi.Models
{
    public class DomainListViewModel
    {
        public int DomainListId { get; set; } // DomainListID (Primary key)
        public string DomainListName { get; set; } // DomainListName
        public string DomainListType { get; set; }
        public string Description { get; set; } // Description
        public string Owner { get; set; } // Owner
        public int? SiteCount { get; set; } // SiteCount

        public PagedListViewModel<string> Domains { get; set; }
    }

    public class DomainListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<DomainList, DomainListViewModel>()
                .ForMember(dst => dst.DomainListType, opt => opt.MapFrom(src => (DomainListTypeEnum) src.DomainListType))
                .ForMember(dst => dst.Domains, opt => opt.ResolveUsing(result =>
                {
                    // mapping domains using pagination
                    var dictionaryAdapterFactory = result.Context.Resolve<IDictionaryAdapterFactory>();
                    var pagination = dictionaryAdapterFactory.GetAdapter<IPagination>(result.Context.Options.Items as IDictionary);
                    var domainList = (DomainList) result.Value;
                    var domains = result.Context.Resolve<IDomainListService>()
                        .GetDomains(domainList.DomainListId)
                        .ToPagedList(pagination.PageNumber, pagination.PageSize);
                    return result.Context.Engine.Map<PagedListViewModel<string>>(domains); // use below map: Domain -> string
                }));

            CreateMap<Domain, string>()
                .ConstructUsing(domain => domain.DomainName);
        }
    }
}
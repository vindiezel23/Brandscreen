using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Brandscreen.Core.Services.Reports;
using Brandscreen.WebApi.Mappings;
using Brandscreen.WebApi.Paginations;
using Castle.Components.DictionaryAdapter;
using PagedList;

namespace Brandscreen.WebApi.Models
{
    public class ReportViewModel : PagedListMetaData
    {
        public ReportViewModel(IPagedList<object> pagedList) : base(pagedList)
        {
            Data = pagedList;
        }

        public string ReportType { get; set; }
        public string ReportLevel { get; set; }
        public IEnumerable<object> Data { get; set; }
    }

    public class ReportViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<IReport, ReportViewModel>()
                .ConstructUsing(ctx =>
                {
                    var dictionaryAdapterFactory = ctx.Resolve<IDictionaryAdapterFactory>();
                    var pagination = dictionaryAdapterFactory.GetAdapter<IPagination>(ctx.Options.Items as IDictionary);
                    var source = (IReport) ctx.SourceValue;
                    var data = source.Data.ToPagedList(pagination.PageNumber, pagination.PageSize);
                    return new ReportViewModel(data);
                })
                .ForMember(dst => dst.Data, opt => opt.Ignore()); // as it is mapped in ConstructUsing
        }
    }
}
using AutoMapper;
using Brandscreen.Core.Services.Strategies.Targets;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Models
{
    public class VerticalQueryViewModel : Pagination
    {
        public bool? IsTopLevel { get; set; }
        public bool? HasIabReference { get; set; }
        public string Text { get; set; }
    }

    public class VerticalQueryViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<VerticalQueryViewModel, VerticalQueryOptions>();
        }
    }
}
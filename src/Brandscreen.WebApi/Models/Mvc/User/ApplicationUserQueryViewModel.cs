using AutoMapper;
using Brandscreen.Core.Services.Memberships;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Models.Mvc.User
{
    public class ApplicationUserQueryViewModel : Pagination.Twenty
    {
        public string Text { get; set; }
    }

    public class ApplicationUserQueryViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationUserQueryViewModel, ApplicationUserQueryOptions>();
        }
    }
}
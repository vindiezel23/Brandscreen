using System;
using AutoMapper;
using Brandscreen.Core.Security;

namespace Brandscreen.WebApi.Models
{
    public class ApplicationUserListViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class ApplicationUserListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationUser, ApplicationUserListViewModel>();
        }
    }
}
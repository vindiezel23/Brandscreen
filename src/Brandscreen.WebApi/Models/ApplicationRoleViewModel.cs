using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Brandscreen.WebApi.Models
{
    public class ApplicationRoleViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }

    public class ApplicationRoleViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<IdentityRole, ApplicationRoleViewModel>();
        }
    }
}
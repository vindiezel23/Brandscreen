using System.Collections.Generic;
using AutoMapper;
using Brandscreen.Core.Services.Memberships;

namespace Brandscreen.WebApi.Models.Mvc.User
{
    public class ApplicationUserUpdateViewModel
    {
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<ApplicationUserClaimModifyViewModel> Claims { get; set; }
    }

    public class ApplicationUserUpdateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationUserUpdateViewModel, ApplicationUserUpdateOptions>()
                .ForMember(dst => dst.UserId, opt => opt.ResolveUsing(result => result.Context.Options.Items["id"]));
        }
    }
}
using System;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Users;
using Brandscreen.WebApi.Mappings;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models.Mvc.User
{
    public class ApplicationUserListViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool HasBrandscreenAccount { get; set; }
    }

    public class ApplicationUserListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationUser, ApplicationUserListViewModel>()
                .ForMember(dst => dst.HasBrandscreenAccount, opt => opt.ResolveUsing(result =>
                {
                    var source = (ApplicationUser) result.Value;
                    var user = result.Context.Resolve<IUserService>().GetUser(Guid.Parse(source.Id)).WaitAndUnwrapException();
                    return user != null;
                }));
        }
    }
}
using System.Security.Principal;
using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.WebApi.Helpers;
using Brandscreen.WebApi.Mappings;

namespace Brandscreen.WebApi.Models.Mvc.Account
{
    public class CurrentUserViewModel
    {
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }
    }

    public class CurrentUserViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<IIdentity, CurrentUserViewModel>()
                .ForMember(dst => dst.IsAdmin, opt => opt.ResolveUsing(result => result.Context.Resolve<IAuthorizationService>().CanAccessEverything()))
                .ForMember(dst => dst.Token, opt => opt.ResolveUsing((result, identity) => AntiForgeryTokenHelper.GenerateAntiForgeryToken()));
        }
    }
}
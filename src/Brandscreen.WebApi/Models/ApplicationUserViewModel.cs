using System;
using System.Collections.Generic;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Memberships;
using Brandscreen.WebApi.Mappings;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class ApplicationUserViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<ApplicationUserClaimViewModel> Claims { get; set; }
    }

    public class ApplicationUserViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ConstructUsing(context =>
                {
                    var source = (ApplicationUser) context.SourceValue;
                    var id = Guid.Parse(source.Id);
                    var membershipService = context.Resolve<IMembershipService>();
                    var retVal = new ApplicationUserViewModel
                    {
                        Roles = membershipService.GetUserRoles(id).WaitAndUnwrapException(),
                        Claims = context.Engine.Map<IEnumerable<ApplicationUserClaimViewModel>>(membershipService.GetUserClaims(id).WaitAndUnwrapException())
                    };
                    return retVal;
                })
                .ForMember(dst => dst.Roles, opt => opt.Ignore()) // as mapped above
                .ForMember(dst => dst.Claims, opt => opt.Ignore()); // as mapped above
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Autofac;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Memberships;
using FluentValidation;
using Microsoft.AspNet.Identity;

namespace Brandscreen.WebApi.Models
{
    public class ApplicationUserPatchViewModel
    {
        [MinLength(8)]
        public string Password { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public IEnumerable<ApplicationUserClaimModifyViewModel> Claims { get; set; }
    }

    public class ApplicationUserPatchViewModelValidator : AbstractValidator<ApplicationUserPatchViewModel>
    {
        public ApplicationUserPatchViewModelValidator(ILifetimeScope container)
        {
            RuleFor(x => x.Roles)
                .Must(roles =>
                {
                    using (var scope = container.BeginLifetimeScope())
                    {
                        var applicationRoleManager = scope.Resolve<ApplicationRoleManager>();
                        return roles.All(role => applicationRoleManager.RoleExists(role));
                    }
                })
                .When(x => x.Roles != null)
                .WithMessage("Roles contain invalid role.");
        }
    }

    public class ApplicationUserPatchViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationUserPatchViewModel, ApplicationUserUpdateOptions>()
                .ForMember(dst => dst.UserId, opt => opt.ResolveUsing(result => result.Context.Options.Items["id"]))
                .ForAllMembers(opt => opt.Condition(ctx => !ctx.IsSourceValueNull)); // for partial updates
        }
    }
}
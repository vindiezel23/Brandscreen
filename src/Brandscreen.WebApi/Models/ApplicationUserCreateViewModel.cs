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
    public class ApplicationUserCreateViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public IEnumerable<ApplicationUserClaimModifyViewModel> Claims { get; set; }
    }

    public class ApplicationUserCreateViewModelValidator : AbstractValidator<ApplicationUserCreateViewModel>
    {
        public ApplicationUserCreateViewModelValidator(ILifetimeScope container)
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

    public class ApplicationUserCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationUserCreateViewModel, ApplicationUserCreateOptions>();
        }
    }
}
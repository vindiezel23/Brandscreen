using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Autofac;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.WebApi.Mappings;
using FluentValidation;
using Microsoft.Owin;
using static Brandscreen.Core.Services.UrlHelper;

namespace Brandscreen.WebApi.Models
{
    public class CreativeDoohVideoUrlCreateViewModel
    {
        [StringLength(500)]
        [Required]
        public string CreativeName { get; set; }

        [Required]
        public Guid? BrandUuid { get; set; }

        [Required]
        public int? CreativeSizeId { get; set; }

        [Required]
        [StringLength(500)]
        public string VideoUrl { get; set; }
    }

    public class CreativeDoohVideoUrlCreateViewModelValidator : AbstractValidator<CreativeDoohVideoUrlCreateViewModel>
    {
        public CreativeDoohVideoUrlCreateViewModelValidator(ILifetimeScope container)
        {
            RuleFor(x => x.CreativeSizeId)
                .Must(id =>
                {
                    using (var scope = container.BeginLifetimeScope())
                    {
                        var sizes = scope.Resolve<ICreativeSizeService>().GetDoohCreativeSizes();
                        return sizes.Any(x => x.CreativeSizeId == id);
                    }
                })
                .When(x => x.CreativeSizeId.HasValue)
                .WithMessage("{PropertyName} is an invalid dooh creative size id.");

            RuleFor(x => x.VideoUrl)
                .MustAsync(IsValidUrl)
                .When(x => !string.IsNullOrEmpty(x.VideoUrl))
                .WithMessage("{PropertyName} is invalid.");
        }
    }

    public class CreativeDoohVideoUrlCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeDoohVideoUrlCreateViewModel, CreativeDoohVideoUrlCreateOptions>()
                .ForMember(dst => dst.UserId, opt => opt.ResolveUsing(result => result.Context.Resolve<IOwinContext>().GetCurrentUserId()));
        }
    }
}
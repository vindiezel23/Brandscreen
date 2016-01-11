using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Autofac;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Core.Settings;
using Brandscreen.WebApi.Mappings;
using FluentValidation;
using Microsoft.Owin;
using MultipartDataMediaFormatter.Infrastructure;

namespace Brandscreen.WebApi.Models
{
    public class CreativeDoohCreateViewModel
    {
        /// <summary>
        /// Default to file name if empty.
        /// </summary>
        [StringLength(500)]
        public string CreativeName { get; set; }

        [Required]
        public Guid? BrandUuid { get; set; }

        [Required]
        public int? CreativeSizeId { get; set; }

        /// <summary>
        /// Image.
        /// </summary>
        [Required]
        public HttpFile File { get; set; }
    }

    public class CreativeDoohCreateViewModelValidator : AbstractValidator<CreativeDoohCreateViewModel>
    {
        private static readonly string[] ImageContentTypes = {"image/gif", "image/png", "image/jpeg"};

        public CreativeDoohCreateViewModelValidator(ILifetimeScope container, ICreativeSettings creativeSettings)
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

            RuleFor(x => x.File.MediaType)
                .Must(ImageContentTypes.Contains)
                .When(x => x.File != null)
                .WithMessage("Uploaded file must be image(gif, png, or jpeg).");

            RuleFor(x => x.File.Buffer)
                .Must(x => x.Length <= creativeSettings.MaxDoohImageSizeInKb*1024)
                .When(x => x.File != null && creativeSettings.MaxDoohImageSizeInKb > 0) // set MaxDoohFileSizeInKb zero to bypass size checking
                .WithMessage($"Uploaded file size exceeds {creativeSettings.MaxDoohImageSizeInKb}KB limit.");
        }
    }

    public class CreativeDoohCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeDoohCreateViewModel, CreativeDoohCreateOptions>()
                .ForMember(dst => dst.CreativeName, opt => opt.ResolveUsing(model => !string.IsNullOrEmpty(model.CreativeName) ? model.CreativeName : model.File.FileName))
                .ForMember(dst => dst.FileName, opt => opt.MapFrom(src => src.File.FileName))
                .ForMember(dst => dst.FileType, opt => opt.MapFrom(src => src.File.MediaType))
                .ForMember(dst => dst.FileData, opt => opt.MapFrom(src => src.File.Buffer))
                .ForMember(dst => dst.UserId, opt => opt.ResolveUsing(result => result.Context.Resolve<IOwinContext>().GetCurrentUserId()));
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Core.Settings;
using Brandscreen.WebApi.Mappings;
using FluentValidation;
using Microsoft.Owin;
using MultipartDataMediaFormatter.Infrastructure;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class CreativeCreateViewModel
    {
        /// <summary>
        /// Default to file name if empty.
        /// </summary>
        [StringLength(500)]
        public string CreativeName { get; set; }

        [Required]
        public Guid? BrandUuid { get; set; }

        [Required]
        public int? AdTagTemplateId { get; set; }

        /// <summary>
        /// en-AU by default
        /// </summary>
        [Required]
        public string LanguageCode { get; set; }

        [Required]
        [StringLength(500)]
        public string ClickUrl { get; set; }

        [StringLength(500)]
        public string ImpressionUrl { get; set; }

        /// <summary>
        /// Image, or flash.
        /// </summary>
        [Required]
        public HttpFile File { get; set; }
    }

    public class CreativeCreateViewModelValidator : AbstractValidator<CreativeCreateViewModel>
    {
        public CreativeCreateViewModelValidator(ICreativeSettings creativeSettings)
        {
            RuleFor(x => x.ImpressionUrl)
                .Matches(creativeSettings.RegexBeaconUrl);

            RuleFor(x => x.File.MediaType)
                .Must(ValidateMediaType)
                .When(x => x.File != null)
                .WithMessage("Uploaded file must be image or flash.");
        }

        private static bool ValidateMediaType(string mediaType)
        {
            return !string.IsNullOrEmpty(mediaType) &&
                   (mediaType.StartsWith("image/") || mediaType.Equals("application/x-shockwave-flash", StringComparison.OrdinalIgnoreCase));
        }
    }

    public class CreativeCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeCreateViewModel, CreativeCreateOptions>()
                .ForMember(dst => dst.LanguageId, opt =>
                {
                    opt.ResolveUsing(result =>
                    {
                        var source = (CreativeCreateViewModel) result.Value;
                        var language = result.Context.Resolve<ILanguageService>().GetLanguageOrDefault(source.LanguageCode).WaitAndUnwrapException();
                        return language.LanguageId;
                    });
                })
                .ForMember(dst => dst.CreativeName, opt => opt.ResolveUsing(model => !string.IsNullOrEmpty(model.CreativeName) ? model.CreativeName : model.File.FileName))
                .ForMember(dst => dst.FileName, opt => opt.MapFrom(src => src.File.FileName))
                .ForMember(dst => dst.FileType, opt => opt.MapFrom(src => src.File.MediaType))
                .ForMember(dst => dst.FileData, opt => opt.MapFrom(src => src.File.Buffer))
                .ForMember(dst => dst.CreativeType, opt => opt.MapFrom(src => src.File.MediaType.StartsWith("image/") ? CreativeTypeEnum.Image : CreativeTypeEnum.Flash))
                .ForMember(dst => dst.UserId, opt => opt.ResolveUsing(result => result.Context.Resolve<IOwinContext>().GetCurrentUserId()));
        }
    }
}
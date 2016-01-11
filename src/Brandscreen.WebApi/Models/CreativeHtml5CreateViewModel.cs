using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
    public class CreativeHtml5CreateViewModel
    {
        /// <summary>
        /// Default to file name if empty.
        /// </summary>
        [StringLength(500)]
        public string CreativeName { get; set; }

        [Required]
        public Guid? BrandUuid { get; set; }

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
        /// Html5 zip file.
        /// </summary>
        [Required]
        public HttpFile File { get; set; }
    }

    public class CreativeHtml5CreateViewModelValidator : AbstractValidator<CreativeHtml5CreateViewModel>
    {
        private static readonly string[] ZipContentTypes = {"application/zip", "application/x-zip-compressed", "application/octet-stream"};

        public CreativeHtml5CreateViewModelValidator(ICreativeSettings creativeSettings)
        {
            RuleFor(x => x.ImpressionUrl)
                .Matches(creativeSettings.RegexBeaconUrl);

            RuleFor(x => x.File.MediaType)
                .Must(ZipContentTypes.Contains)
                .When(x => x.File != null)
                .WithMessage("Uploaded file must be zip html5.");

            RuleFor(x => x.File.FileName)
                .Must(x => x != null && x.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                .When(x => x.File != null)
                .WithMessage("Uploaded file must be zip html5.");
        }
    }

    public class CreativeHtml5CreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeHtml5CreateViewModel, CreativeHtml5CreateOptions>()
                .ForMember(dst => dst.LanguageId, opt =>
                {
                    opt.ResolveUsing(result =>
                    {
                        var source = (CreativeHtml5CreateViewModel) result.Value;
                        var language = result.Context.Resolve<ILanguageService>().GetLanguageOrDefault(source.LanguageCode).WaitAndUnwrapException();
                        return language.LanguageId;
                    });
                })
                .ForMember(dst => dst.CreativeName, opt => opt.ResolveUsing(model => !string.IsNullOrEmpty(model.CreativeName) ? model.CreativeName : model.File.FileName))
                .ForMember(dst => dst.FileName, opt => opt.MapFrom(src => src.File.FileName))
                .ForMember(dst => dst.FileType, opt => opt.MapFrom(src => src.File.MediaType))
                .ForMember(dst => dst.FileData, opt => opt.MapFrom(src => src.File.Buffer))
                .ForMember(dst => dst.UserId, opt => opt.ResolveUsing(result => result.Context.Resolve<IOwinContext>().GetCurrentUserId()));
        }
    }
}
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
    public class CreativeSwiffyCreateViewModel
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
        /// Swiffy html file.
        /// </summary>
        [Required]
        public HttpFile File { get; set; }
    }

    public class CreativeSwiffyCreateViewModelValidator : AbstractValidator<CreativeSwiffyCreateViewModel>
    {
        public CreativeSwiffyCreateViewModelValidator(ICreativeSettings creativeSettings)
        {
            RuleFor(x => x.ImpressionUrl)
                .Matches(creativeSettings.RegexBeaconUrl);

            RuleFor(x => x.File.MediaType)
                .Equal("text/html")
                .When(x => x.File != null)
                .WithMessage("Uploaded file must be swiffy html.");
        }
    }

    public class CreativeSwiffyCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeSwiffyCreateViewModel, CreativeSwiffyCreateOptions>()
                .ForMember(dst => dst.LanguageId, opt =>
                {
                    opt.ResolveUsing(result =>
                    {
                        var source = (CreativeSwiffyCreateViewModel) result.Value;
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
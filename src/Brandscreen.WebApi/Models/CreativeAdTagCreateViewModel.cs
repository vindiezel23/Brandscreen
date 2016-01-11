using System;
using System.ComponentModel.DataAnnotations;
using Autofac;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.WebApi.Mappings;
using FluentValidation;
using Microsoft.Owin;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class CreativeAdTagCreateViewModel
    {
        [Required]
        [StringLength(500)]
        public string CreativeName { get; set; }

        [Required]
        public Guid? BrandUuid { get; set; }

        [Required]
        public int? AdTagTemplateId { get; set; }

        [Required]
        public int? CreativeSizeId { get; set; }

        /// <summary>
        /// en-AU by default
        /// </summary>
        [Required]
        public string LanguageCode { get; set; }

        [Required]
        [StringLength(500)]
        public string ClickUrl { get; set; }

        [Required]
        [StringLength(int.MaxValue/2)]
        public string AdTag { get; set; }
    }

    public class CreativeAdTagCreateViewModelValidator : AbstractValidator<CreativeAdTagCreateViewModel>
    {
        public CreativeAdTagCreateViewModelValidator(ILifetimeScope container)
        {
            RuleFor(x => x.AdTag)
                .Must(IsValidGeneric3PasAdTag)
                .When(x =>
                {
                    // note: to avoid hardcode id using service to retrieve it
                    using (var scope = container.BeginLifetimeScope())
                    {
                        return x.AdTagTemplateId == scope.Resolve<IAdTagTemplateService>().GetGeneric3PasAdTagTemplate().WaitAndUnwrapException().AdTagTemplateId;
                    }
                });
        }

        private static bool IsValidGeneric3PasAdTag(string adTag)
        {
            return adTag.Contains("doubleclick.net") ||
                   adTag.Contains("%%REDIRECT_URL%%") || adTag.Contains("{{REDIRECT_URL}}") || adTag.Contains("REDIRECT_URL_ESC") || adTag.Contains("REDIRECT_URL_ESC_ESC") ||
                   adTag.Contains("%%CLICK_URL%%") || adTag.Contains("{{CLICK_URL}}") || adTag.Contains("%%CLICK_URL_ESC%%") ||
                   adTag.Contains("{{CLICK_URL_ESC}}") || adTag.Contains("%%CLICK_URL_ESC_ESC%%") || adTag.Contains("{{CLICK_URL_ESC_ESC}}");
        }
    }

    public class CreativeAdTagCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeAdTagCreateViewModel, CreativeAdTagCreateOptions>()
                .ForMember(dst => dst.LanguageId, opt =>
                {
                    opt.ResolveUsing(result =>
                    {
                        var source = (CreativeAdTagCreateViewModel) result.Value;
                        var language = result.Context.Resolve<ILanguageService>().GetLanguageOrDefault(source.LanguageCode).WaitAndUnwrapException();
                        return language.LanguageId;
                    });
                })
                .ForMember(dst => dst.UserId, opt => opt.ResolveUsing(result => result.Context.Resolve<IOwinContext>().GetCurrentUserId()));
        }
    }
}
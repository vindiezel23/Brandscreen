using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Core.Settings;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;
using FluentValidation;
using Microsoft.Owin;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class CreativePatchViewModel
    {
        [StringLength(500)]
        public string CreativeName { get; set; }

        public string LanguageCode { get; set; }

        [StringLength(500)]
        public string ClickUrl { get; set; }

        [StringLength(500)]
        public string ImpressionUrl { get; set; }

        public bool? IsSsl { get; set; }

        [Range(0d, 1000d)]
        public decimal? CreativeHostingFee { get; set; }
    }

    public class CreativePatchViewModelValidator : AbstractValidator<CreativePatchViewModel>
    {
        public CreativePatchViewModelValidator(ICreativeSettings creativeSettings)
        {
            RuleFor(x => x.ImpressionUrl)
                .Matches(creativeSettings.RegexBeaconUrl);
        }
    }

    public class CreativePatchViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativePatchViewModel, Creative>()
                .ForMember(dst => dst.LanguageId, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.LanguageCode));
                    opt.ResolveUsing(result =>
                    {
                        var source = (CreativePatchViewModel) result.Value;
                        var language = result.Context.Resolve<ILanguageService>().GetLanguageOrDefault(source.LanguageCode).WaitAndUnwrapException();
                        return language.LanguageId;
                    });
                })
                .ForMember(dst => dst.BeaconUrl, opt => opt.MapFrom(src => src.ImpressionUrl))
                .ForAllMembers(opt => opt.Condition(ctx => !ctx.IsSourceValueNull)); // for partial updates

            CreateMap<CreativePatchViewModel, CreativeUpdateOptions>()
                .ForMember(dst => dst.NewCreative, opt => opt.ResolveUsing(result =>
                {
                    var creativeUuid = (Guid) result.Context.Options.Items["id"];
                    var creative = result.Context.Resolve<ICreativeService>().GetCreative(creativeUuid).WaitAndUnwrapException();
                    return result.Context.Engine.Map((CreativePatchViewModel) result.Value, creative); // using above mapping
                }))
                .ForMember(dst => dst.ClickUrl, opt => opt.MapFrom(src => src.ClickUrl))
                .ForMember(dst => dst.UserId, opt => opt.ResolveUsing(result => result.Context.Resolve<IOwinContext>().GetCurrentUserId()));
        }
    }
}
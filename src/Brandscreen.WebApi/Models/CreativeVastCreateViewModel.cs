using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.WebApi.Mappings;
using Microsoft.Owin;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class CreativeVastCreateViewModel
    {
        [Required]
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
        public string VastUrl { get; set; }

        [Required]
        [StringLength(500)]
        public string ClickUrl { get; set; }

        /// <summary>
        /// None, Up, Down, Left, Right, UpLeft, UpRight, DownLeft, or DownRight
        /// </summary>
        [Required]
        [EnumDataType(typeof (ExpandableDirectionEnum))]
        public string Direction { get; set; }
    }

    public class CreativeVastCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeVastCreateViewModel, CreativeVastCreateOptions>()
                .ForMember(dst => dst.LanguageId, opt =>
                {
                    opt.ResolveUsing(result =>
                    {
                        var source = (CreativeVastCreateViewModel) result.Value;
                        var language = result.Context.Resolve<ILanguageService>().GetLanguageOrDefault(source.LanguageCode).WaitAndUnwrapException();
                        return language.LanguageId;
                    });
                })
                .ForMember(dst => dst.Direction, opt => opt.MapFrom(src => Enum.Parse(typeof (ExpandableDirectionEnum), src.Direction, true)))
                .ForMember(dst => dst.UserId, opt => opt.ResolveUsing(result => result.Context.Resolve<IOwinContext>().GetCurrentUserId()));
        }
    }
}
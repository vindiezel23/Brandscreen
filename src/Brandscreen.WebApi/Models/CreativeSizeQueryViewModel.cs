using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Models
{
    public class CreativeSizeQueryViewModel : Pagination
    {
        /// <summary>
        /// Display, Video, Mobile, Facebook, or Dooh.
        /// </summary>
        [EnumDataType(typeof (MediaTypeEnum))]
        public string MediaType { get; set; }
    }

    public class CreativeSizeQueryViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeSizeQueryViewModel, CreativeSizeQueryOptions>()
                .ForMember(dst => dst.MediaTypeId, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.MediaType));
                    opt.MapFrom(src => Enum.Parse(typeof (MediaTypeEnum), src.MediaType, true));
                });
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class CreativeSizeCreateViewModel
    {
        [Required]
        public int? CreativeSizeId { get; set; }

        [Required]
        [StringLength(200)]
        public string CreativeSizeName { get; set; } // CreativeSizeName

        [Required]
        [Range(0, int.MaxValue)]
        public int? Height { get; set; } // Height

        [Required]
        [Range(0, int.MaxValue)]
        public int? Width { get; set; } // Width

        [Required]
        [Range(0d, 1d)]
        public decimal? Score { get; set; } // Score

        [Required]
        public bool? IsUniversalAdPackage { get; set; } // IsUniversalAdPackage

        /// <summary>
        /// Display, Video, Mobile, Facebook, or Dooh
        /// </summary>
        [Required]
        [EnumDataType(typeof (MediaTypeEnum))]
        public string MediaType { get; set; }
    }

    public class CreativeSizeCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeSizeCreateViewModel, CreativeSize>()
                .ForMember(dst => dst.MediaTypeId, opt => opt.MapFrom(src => Enum.Parse(typeof (MediaTypeEnum), src.MediaType, true)));
        }
    }
}
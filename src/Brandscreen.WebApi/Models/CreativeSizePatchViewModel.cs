using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class CreativeSizePatchViewModel
    {
        [StringLength(200)]
        public string CreativeSizeName { get; set; } // CreativeSizeName

        [Range(0, int.MaxValue)]
        public int? Height { get; set; } // Height

        [Range(0, int.MaxValue)]
        public int? Width { get; set; } // Width

        [Range(0d, 1d)]
        public decimal? Score { get; set; } // Score

        public bool? IsActive { get; set; } // IsActive

        public bool? IsUniversalAdPackage { get; set; } // IsUniversalAdPackage
    }

    public class CreativeSizePatchViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeSizePatchViewModel, CreativeSize>()
                .ForAllMembers(opt => opt.Condition(ctx => !ctx.IsSourceValueNull)); // for partial updates
        }
    }
}
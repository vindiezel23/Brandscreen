using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class CreativeSizeViewModel
    {
        public int CreativeSizeId { get; set; } // CreativeSizeID (Primary key)
        public string CreativeSizeName { get; set; } // CreativeSizeName
        public int? Height { get; set; } // Height
        public int? Width { get; set; } // Width
        public decimal? Score { get; set; } // Score
        public bool? IsActive { get; set; } // IsActive
        public bool? IsUniversalAdPackage { get; set; } // IsUniversalAdPackage
        public int MediaTypeId { get; set; } // MediaTypeID 
    }

    public class CreativeSizeViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeSize, CreativeSizeViewModel>();
        }
    }
}
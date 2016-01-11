using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class CreativeSizeListViewModel
    {
        public int CreativeSizeId { get; set; } // CreativeSizeID (Primary key)
        public string CreativeSizeName { get; set; } // CreativeSizeName
        public int? Height { get; set; } // Height
        public int? Width { get; set; } // Width
        public int MediaTypeId { get; set; } // MediaTypeID 
    }

    public class CreativeSizeListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeSize, CreativeSizeListViewModel>();
        }
    }
}
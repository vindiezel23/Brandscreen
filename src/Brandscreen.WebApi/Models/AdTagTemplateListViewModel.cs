using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class AdTagTemplateListViewModel
    {
        public int AdTagTemplateId { get; set; } // AdTagTemplateID (Primary key)
        public string AdTagTemplateName { get; set; } // AdTagTemplateName
        public string TemplatePath { get; set; } // TemplatePath
        public int CreativeTypeId { get; set; } // CreativeTypeID
        public int MediaTypeId { get; set; } // MediaTypeID
    }

    public class AdTagTemplateListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdTagTemplate, AdTagTemplateListViewModel>();
        }
    }
}
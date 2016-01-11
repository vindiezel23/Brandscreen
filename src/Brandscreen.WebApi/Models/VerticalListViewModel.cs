using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class VerticalListViewModel
    {
        public int VerticalId { get; set; } // VerticalID (Primary key)
        public int? ParentVerticalId { get; set; } // ParentVerticalID
        public string VerticalName { get; set; } // VerticalName
        public string VerticalPath { get; set; } // VerticalPath
        public string IabReference { get; set; } // IABReference
    }

    public class VerticalListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Vertical, VerticalListViewModel>();
        }
    }
}
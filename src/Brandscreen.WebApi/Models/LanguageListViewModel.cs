using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class LanguageListViewModel
    {
        public int LanguageId { get; set; } // LanguageID (Primary key)
        public string Iso4646Code { get; set; } // ISO4646Code
        public string LanguageName { get; set; } // LanguageName
        public string LocalizedLanguageName { get; set; } // LocalizedLanguageName
    }

    public class LanguageListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Language, LanguageListViewModel>();
        }
    }
}
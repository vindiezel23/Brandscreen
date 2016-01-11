using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class StrategyLanguageViewModel
    {
        public int LanguageId { get; set; } // LanguageID (Primary key)
        public int TargetingActionId { get; set; } // TargetingActionID
        public string LanguageIso4646Code { get; set; } // Language.ISO4646Code
    }

    public class StrategyLanguageViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdGroupLanguage, StrategyLanguageViewModel>();
        }
    }
}
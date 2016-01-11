using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class DoohPanelLocationPatchViewModel
    {
        [StringLength(128)]
        public string PanelUrl { get; set; } // PanelUrl

        [StringLength(255)]
        public string PanelLocationName { get; set; } // PanelLocationName

        public long? AudienceSize { get; set; } // AudienceSize
    }

    public class DoohPanelLocationPatchViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<DoohPanelLocationPatchViewModel, DoohPanelLocation>()
                .ForAllMembers(opt => opt.Condition(ctx => !ctx.IsSourceValueNull)); // for partial updates
        }
    }
}
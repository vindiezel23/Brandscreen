using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class DoohPanelLocationCreateViewModel
    {
        [Required]
        public int? DoohPanelId { get; set; } // DoohPanelID

        [Required]
        public int? DoohLocationId { get; set; } // DoohLocationID

        [Required]
        [StringLength(128)]
        public string PanelUrl { get; set; } // PanelUrl

        [Required]
        public string PanelId { get; set; } // PanelID

        [Required]
        [StringLength(255)]
        public string PanelLocationName { get; set; } // PanelLocationName

        public long? AudienceSize { get; set; } // AudienceSize

        [Required]
        public int? PartnerId { get; set; } // PartnerID
    }

    public class DoohPanelLocationCreateViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<DoohPanelLocationCreateViewModel, DoohPanelLocation>();
        }
    }
}
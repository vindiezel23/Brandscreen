using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class DoohPanelLocationViewModel
    {
        public int DoohPanelLocationId { get; set; } // DOOHPanelLocationID (Primary key)
        public int DoohPanelId { get; set; } // DoohPanelID
        public int DoohLocationId { get; set; } // DoohLocationID
        public string PanelUrl { get; set; } // PanelUrl
        public string PanelId { get; set; } // PanelID
        public string PanelLocationName { get; set; } // PanelLocationName
        public long? AudienceSize { get; set; } // AudienceSize
        public int PartnerId { get; set; } // PartnerID
    }

    public class DoohPanelLocationViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<DoohPanelLocation, DoohPanelLocationViewModel>();
        }
    }
}
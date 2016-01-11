using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services.Placements;

namespace Brandscreen.WebApi.Models
{
    public class PlacementPutViewModel
    {
        [Required]
        public Guid? StrategyUuid { get; set; }

        [Required]
        public Guid? CreativeUuid { get; set; }

        /// <summary>
        /// A flag indicating to link or unlink.
        /// </summary>
        [Required]
        public bool? IsLinking { get; set; }
    }

    public class PlacementPutViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<PlacementPutViewModel, PlacementModifyOptions>();
        }
    }
}
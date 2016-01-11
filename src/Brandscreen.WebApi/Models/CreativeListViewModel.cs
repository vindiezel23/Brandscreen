using System;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class CreativeListViewModel
    {
        public Guid CreativeUuid { get; set; } // CreativeUuid
        public int BuyerAccountId { get; set; } // BuyerAccountID
        public string CreativeName { get; set; } // CreativeName
        public int CreativeTypeId { get; set; } // CreativeTypeID
        public int CreativeSizeId { get; set; } // CreativeSizeID
        public int? CreativeFileId { get; set; } // CreativeFileID
        public int? AdTagTemplateId { get; set; } // AdTagTemplateID
        public int CreativeStatusId { get; set; } // CreativeStatusID
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
        public int LanguageId { get; set; } // LanguageID
        public int AdvertiserProductId { get; set; } // AdvertiserProductID
        public int ThumbnailStatusId { get; set; } // ThumbnailStatusID
    }

    public class CreativeListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Creative, CreativeListViewModel>();
        }
    }
}
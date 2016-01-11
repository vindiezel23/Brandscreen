using System;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class CreativeFileViewModel
    {
        public int CreativeFileId { get; set; } // CreativeFileID (Primary key)
        public string FileName { get; set; } // FileName
        public int FileSize { get; set; } // FileSize
        public string FileExtension { get; set; } // FileExtension
        public int? Width { get; set; } // Width
        public int? Height { get; set; } // Height
        public DateTime CreatedDateTime { get; set; } // CreatedDateTime
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
    }

    public class CreativeFileViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeFile, CreativeFileViewModel>();
        }
    }
}
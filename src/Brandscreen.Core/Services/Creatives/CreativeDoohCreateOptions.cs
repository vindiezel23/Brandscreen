using System;

namespace Brandscreen.Core.Services.Creatives
{
    public class CreativeDoohCreateOptions
    {
        public Guid BrandUuid { get; set; }
        public string CreativeName { get; set; }
        public int CreativeSizeId { get; set; }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }

        public Guid UserId { get; set; }
    }
}
using System;

namespace Brandscreen.Core.Services.Creatives
{
    public class CreativeCreateOptions
    {
        public Guid BrandUuid { get; set; }
        public string CreativeName { get; set; }
        public int AdTagTemplateId { get; set; }
        public int LanguageId { get; set; }

        public string ClickUrl { get; set; }
        public string ImpressionUrl { get; set; }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }

        public CreativeTypeEnum CreativeType { get; set; }

        public Guid UserId { get; set; }
    }
}
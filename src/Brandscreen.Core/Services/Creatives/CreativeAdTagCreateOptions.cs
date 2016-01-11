using System;

namespace Brandscreen.Core.Services.Creatives
{
    public class CreativeAdTagCreateOptions
    {
        public Guid BrandUuid { get; set; }
        public int AdTagTemplateId { get; set; }
        public int CreativeSizeId { get; set; }
        public string CreativeName { get; set; }
        public int LanguageId { get; set; }

        public string ClickUrl { get; set; }

        public string AdTag { get; set; }

        public Guid UserId { get; set; }
    }
}
using System;

namespace Brandscreen.Core.Services.Creatives
{
    public class CreativeVastCreateOptions
    {
        public Guid BrandUuid { get; set; }
        public string CreativeName { get; set; }
        public int LanguageId { get; set; }

        public string VastUrl { get; set; }
        public string VastXml { get; set; }

        public string ClickUrl { get; set; }

        public ExpandableDirectionEnum Direction { get; set; }

        public Guid UserId { get; set; }
    }
}
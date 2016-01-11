using System;

namespace Brandscreen.Core.Services.Creatives
{
    public class CreativeDoohVideoUrlCreateOptions
    {
        public Guid BrandUuid { get; set; }
        public string CreativeName { get; set; }
        public int CreativeSizeId { get; set; }

        public string VideoUrl { get; set; }

        public Guid UserId { get; set; }
    }
}
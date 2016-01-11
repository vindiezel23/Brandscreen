using System;
using Brandscreen.Entities;

namespace Brandscreen.Core.Services.Creatives
{
    public class CreativeUpdateOptions
    {
        public Creative NewCreative { get; set; }
        public string ClickUrl { get; set; }
        public Guid UserId { get; set; }
    }
}
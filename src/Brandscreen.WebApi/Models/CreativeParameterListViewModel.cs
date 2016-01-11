using System;
using System.Collections.Generic;

namespace Brandscreen.WebApi.Models
{
    public class CreativeParameterListViewModel
    {
        public Guid CreativeUuid { get; set; }
        public DateTime Timestamp { get; set; }
        public IEnumerable<CreativeParameterViewModel> Data { get; set; }
    }
}
using System.Collections.Generic;

namespace Brandscreen.Core.Services.Creatives.Html5
{
    public class Html5ExtractResult
    {
        public Html5ExtractResult()
        {
            OtherPaths = new List<string>();
        }

        public bool Success { get; set; }
        public string Error { get; set; }

        public string BasePath { get; set; }
        public string HtmlPath { get; set; }
        public IList<string> OtherPaths { get; set; }
    }
}
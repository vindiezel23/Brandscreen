namespace Brandscreen.Core.Services.Creatives.Html5
{
    public class Html5ParseResult
    {
        public bool Success { get; set; }
        public string Error { get; set; }

        public string Html { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
    }
}
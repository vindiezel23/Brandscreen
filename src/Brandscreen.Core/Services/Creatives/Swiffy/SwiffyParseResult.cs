namespace Brandscreen.Core.Services.Creatives.Swiffy
{
    public class SwiffyParseResult
    {
        public bool Success { get; set; }
        public string Error { get; set; }

        public string Runtime { get; set; }
        public string Object { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
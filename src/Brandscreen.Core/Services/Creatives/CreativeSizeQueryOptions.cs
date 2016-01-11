namespace Brandscreen.Core.Services.Creatives
{
    public class CreativeSizeQueryOptions
    {
        public int? MediaTypeId { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public int Discrepancy { get; set; }
    }
}
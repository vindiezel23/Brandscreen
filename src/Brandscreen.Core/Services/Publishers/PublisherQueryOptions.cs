namespace Brandscreen.Core.Services.Publishers
{
    public class PublisherQueryOptions : QueryOptions
    {
        public int? PartnerId { get; set; }

        public string PartnerKey { get; set; }
    }
}
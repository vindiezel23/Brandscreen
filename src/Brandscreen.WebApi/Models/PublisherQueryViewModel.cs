using AutoMapper;
using Brandscreen.Core.Services.Publishers;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Models
{
    public class PublisherQueryViewModel : Pagination
    {
        public int? PartnerId { get; set; }

        public string PartnerKey { get; set; }

        /// <summary>
        /// Filter by publisher name.
        /// </summary>
        public string Text { get; set; }
    }

    public class PublisherQueryViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<PublisherQueryViewModel, PublisherQueryOptions>();
        }
    }
}
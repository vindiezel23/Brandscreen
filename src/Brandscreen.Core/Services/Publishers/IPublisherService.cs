using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services.Publishers
{
    public interface IPublisherService : IDependency
    {
        Task<Publisher> GetPublisher(int id);
        Task<Publisher> GetPublisher(Guid id);
        IQueryable<Publisher> GetPublishers();
        IQueryable<Publisher> GetPublishers(PublisherQueryOptions options);
    }

    public class PublisherService : IPublisherService
    {
        private readonly IRepositoryAsync<Publisher> _publisherRepositoryAsync;

        public PublisherService(IRepositoryAsync<Publisher> publisherRepositoryAsync)
        {
            _publisherRepositoryAsync = publisherRepositoryAsync;
        }

        public Task<Publisher> GetPublisher(int id)
        {
            return _publisherRepositoryAsync.Queryable()
                .Include(x => x.Partner)
                .FirstOrDefaultAsync(x => x.PublisherId == id && x.IsActive);
        }

        public Task<Publisher> GetPublisher(Guid id)
        {
            return _publisherRepositoryAsync.Queryable()
                .Include(x => x.Partner)
                .FirstOrDefaultAsync(x => x.PublisherUuid == id && x.IsActive);
        }

        public IQueryable<Publisher> GetPublishers()
        {
            return _publisherRepositoryAsync.Queryable()
                .Where(x => x.IsActive)
                .OrderBy(x => x.PublisherName);
        }

        public IQueryable<Publisher> GetPublishers(PublisherQueryOptions options)
        {
            var source = GetPublishers();

            if (options.PartnerId.HasValue)
            {
                source = source.Where(x => x.PartnerId == options.PartnerId);
            }

            if (!string.IsNullOrEmpty(options.PartnerKey))
            {
                source = source.Where(x => x.PartnerKey.StartsWith(options.PartnerKey));
            }

            if (!string.IsNullOrEmpty(options.Text))
            {
                source = source.Where(x => x.PublisherName.Contains(options.Text));
            }

            return source;
        }
    }
}
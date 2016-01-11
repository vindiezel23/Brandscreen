using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services.Strategies.Targets
{
    public interface IDomainListService : IDependency
    {
        IQueryable<DomainList> GetDomainLists();
        Task<DomainList> GetDomainList(int id);

        IQueryable<Domain> GetDomains(int domainListId);
    }

    public class DomainListService : IDomainListService
    {
        private readonly IRepositoryAsync<DomainList> _domainListRepositoryAsync;
        private readonly IRepositoryAsync<Domain> _domainRepositoryAsync;

        public DomainListService(IRepositoryAsync<DomainList> domainListRepositoryAsync, IRepositoryAsync<Domain> domainRepositoryAsync)
        {
            _domainListRepositoryAsync = domainListRepositoryAsync;
            _domainRepositoryAsync = domainRepositoryAsync;
        }

        public IQueryable<DomainList> GetDomainLists()
        {
            var source = _domainListRepositoryAsync.Queryable();
            return source.OrderBy(x => x.DomainListName);
        }

        public Task<DomainList> GetDomainList(int id)
        {
            var source = GetDomainLists();
            return source.Include(x => x.BuyerAccount)
                .FirstOrDefaultAsync(x => x.DomainListId == id);
        }

        public IQueryable<Domain> GetDomains(int domainListId)
        {
            var source = _domainRepositoryAsync.Queryable()
                .Where(x => x.DomainListId == domainListId)
                .OrderBy(x => x.DomainName);
            return source;
        }
    }
}
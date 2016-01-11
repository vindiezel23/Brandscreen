using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Brandscreen.Framework.Caching;
using Brandscreen.Framework.Services;
using Repository.Pattern.Repositories;
using TimeSpan = System.TimeSpan;

namespace Brandscreen.Core.Services.Partners
{
    public interface IPartnerService : IDependency
    {
        IQueryable<Partner> GetPartners();
        Task<Partner> GetPartner(int id);
    }

    public class PartnerService : IPartnerService
    {
        private readonly IRepositoryAsync<Partner> _partnerRepositoryAsync;
        private readonly ICacheManager _cacheManager;
        private readonly IClock _clock;

        public PartnerService(IRepositoryAsync<Partner> partnerRepositoryAsync, ICacheManager cacheManager, IClock clock)
        {
            _partnerRepositoryAsync = partnerRepositoryAsync;
            _cacheManager = cacheManager;
            _clock = clock;
        }

        public IQueryable<Partner> GetPartners()
        {
            var retVal = _cacheManager.Get(GetType(), context =>
            {
                context.Monitor(_clock.When(TimeSpan.FromMinutes(10))); // cache for 10 mins
                var source = _partnerRepositoryAsync.Queryable();
                return source.OrderBy(x => x.PartnerName).ToList();
            });
            return retVal.ToAsyncEnumerable();
        }

        public Task<Partner> GetPartner(int id)
        {
            var source = GetPartners();
            return source.FirstOrDefaultAsync(x => x.PartnerId == id);
        }
    }
}
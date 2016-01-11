using System.Linq;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services.Strategies.Targets
{
    public interface IMobileCarrierService : IDependency
    {
        IQueryable<MobileCarrier> GetMobileCarriers();
    }

    public class MobileCarrierService : IMobileCarrierService
    {
        private readonly IRepositoryAsync<MobileCarrier> _mobileCarrierRepositoryAsync;

        public MobileCarrierService(IRepositoryAsync<MobileCarrier> mobileCarrierRepositoryAsync)
        {
            _mobileCarrierRepositoryAsync = mobileCarrierRepositoryAsync;
        }

        public IQueryable<MobileCarrier> GetMobileCarriers()
        {
            var source = _mobileCarrierRepositoryAsync.Queryable();
            return source.OrderBy(x => x.MobileCarrierName);
        }
    }
}
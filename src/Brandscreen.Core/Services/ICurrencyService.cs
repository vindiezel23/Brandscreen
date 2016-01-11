using System.Linq;
using System.Threading.Tasks;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Brandscreen.Framework.Caching;
using Brandscreen.Framework.Services;
using Repository.Pattern.Repositories;
using TimeSpan = System.TimeSpan;

namespace Brandscreen.Core.Services
{
    public interface ICurrencyService : IDependency
    {
        IQueryable<Currency> GetCurrencies();
        Task<Currency> GetCurrency(int id);
        Task<Currency> GetCurrency(string code);
    }

    public class CurrencyService : ICurrencyService
    {
        private readonly IRepositoryAsync<Currency> _currencyRepositoryAsync;
        private readonly ICacheManager _cacheManager;
        private readonly IClock _clock;

        public CurrencyService(IRepositoryAsync<Currency> currencyRepositoryAsync, ICacheManager cacheManager, IClock clock)
        {
            _currencyRepositoryAsync = currencyRepositoryAsync;
            _cacheManager = cacheManager;
            _clock = clock;
        }

        public IQueryable<Currency> GetCurrencies()
        {
            var retVal = _cacheManager.Get(GetType(), context =>
            {
                context.Monitor(_clock.When(TimeSpan.FromMinutes(10))); // cache for 10 mins
                return _currencyRepositoryAsync.Queryable().OrderBy(x => x.CurrencyName).ToList();
            });
            return retVal.AsQueryable();
        }

        public Task<Currency> GetCurrency(int id)
        {
            return Task.FromResult(GetCurrencies().FirstOrDefault(x => x.CurrencyId == id));
        }

        public Task<Currency> GetCurrency(string code)
        {
            return Task.FromResult(GetCurrencies().FirstOrDefault(x => x.Iso4217Code == code));
        }
    }

    public static class CurrencyServiceExtensions
    {
        public static Task<Currency> GetDefaultCurrency(this ICurrencyService currencyService)
        {
            return currencyService.GetCurrency("AUD");
        }

        public static async Task<Currency> GetCurrencyOrDefault(this ICurrencyService currencyService, string code)
        {
            if (string.IsNullOrEmpty(code)) return await currencyService.GetDefaultCurrency();
            return await currencyService.GetCurrency(code) ?? await currencyService.GetDefaultCurrency();
        }
    }
}
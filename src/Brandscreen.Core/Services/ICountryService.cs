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
    public interface ICountryService : IDependency
    {
        IQueryable<Country> GetCountries();
        Task<Country> GetCountry(int id);
        Task<Country> GetCountry(string code);
    }

    public class CountryService : ICountryService
    {
        private readonly IRepositoryAsync<Country> _countryRepositoryAsync;
        private readonly ICacheManager _cacheManager;
        private readonly IClock _clock;

        public CountryService(IRepositoryAsync<Country> countryRepositoryAsync, ICacheManager cacheManager, IClock clock)
        {
            _countryRepositoryAsync = countryRepositoryAsync;
            _cacheManager = cacheManager;
            _clock = clock;
        }

        public IQueryable<Country> GetCountries()
        {
            var retVal = _cacheManager.Get(GetType(), context =>
            {
                context.Monitor(_clock.When(TimeSpan.FromMinutes(10))); // cache for 10 mins
                return _countryRepositoryAsync.Queryable().OrderBy(x => x.CountryName).ToList();
            });
            return retVal.AsQueryable();
        }

        public Task<Country> GetCountry(int id)
        {
            return Task.FromResult(GetCountries().FirstOrDefault(x => x.CountryId == id));
        }

        public Task<Country> GetCountry(string code)
        {
            return Task.FromResult(GetCountries().FirstOrDefault(x => x.Iso3166Code.Trim() == code));
        }
    }

    public static class CountryServiceExtensions
    {
        public static Task<Country> GetDefaultCountry(this ICountryService countryService)
        {
            return countryService.GetCountry("AU");
        }

        public static async Task<Country> GetCountryOrDefault(this ICountryService countryService, string code)
        {
            if (string.IsNullOrEmpty(code)) return await countryService.GetDefaultCountry();
            return await countryService.GetCountry(code) ?? await countryService.GetDefaultCountry();
        }
    }
}
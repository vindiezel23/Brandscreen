using System.Linq;
using System.Threading.Tasks;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Brandscreen.Framework.Caching;
using Brandscreen.Framework.Services;
using Repository.Pattern.Repositories;
using TimeSpan = System.TimeSpan;

namespace Brandscreen.Core.Services
{
    public interface ILanguageService : IDependency
    {
        IQueryable<Language> GetLanguages();
        Task<Language> GetLanguage(int id);
        Task<Language> GetLanguage(string code);
    }

    public class LanguageService : ILanguageService
    {
        private readonly IRepositoryAsync<Language> _languageRepositoryAsync;
        private readonly ICacheManager _cacheManager;
        private readonly IClock _clock;

        public LanguageService(IRepositoryAsync<Language> languageRepositoryAsync, ICacheManager cacheManager, IClock clock)
        {
            _languageRepositoryAsync = languageRepositoryAsync;
            _cacheManager = cacheManager;
            _clock = clock;
        }

        public IQueryable<Language> GetLanguages()
        {
            var retVal = _cacheManager.Get(GetType(), context =>
            {
                context.Monitor(_clock.When(TimeSpan.FromMinutes(10))); // cache for 10 mins
                return _languageRepositoryAsync.Queryable().OrderBy(x => x.LanguageName).ToList();
            });
            return retVal.ToAsyncEnumerable();
        }

        public Task<Language> GetLanguage(int id)
        {
            return Task.FromResult(GetLanguages().FirstOrDefault(x => x.LanguageId == id));
        }

        public Task<Language> GetLanguage(string code)
        {
            return Task.FromResult(GetLanguages().FirstOrDefault(x => x.Iso4646Code == code));
        }
    }

    public static class LanguageServiceExtensions
    {
        public static Task<Language> GetDefaultLanguage(this ILanguageService languageService)
        {
            return languageService.GetLanguage("en-AU");
        }

        public static async Task<Language> GetLanguageOrDefault(this ILanguageService languageService, string code)
        {
            if (string.IsNullOrEmpty(code)) return await languageService.GetDefaultLanguage();
            return await languageService.GetLanguage(code) ?? await languageService.GetDefaultLanguage();
        }
    }
}
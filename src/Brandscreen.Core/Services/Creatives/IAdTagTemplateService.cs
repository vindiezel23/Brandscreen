using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Brandscreen.Framework.Caching;
using Brandscreen.Framework.Services;
using Repository.Pattern.Repositories;
using TimeSpan = System.TimeSpan;

namespace Brandscreen.Core.Services.Creatives
{
    public interface IAdTagTemplateService : IDependency
    {
        IQueryable<AdTagTemplate> GetAdTagTemplates();
        Task<AdTagTemplate> GetAdTagTemplate(int id);

        Task<IDictionary<string, string>> Parse(int id, string adTag);
    }

    public class AdTagTemplateService : IAdTagTemplateService
    {
        private readonly IRepositoryAsync<AdTagTemplate> _adTagTemplateRepositoryAsync;
        private readonly ICacheManager _cacheManager;
        private readonly IClock _clock;

        public AdTagTemplateService(IRepositoryAsync<AdTagTemplate> adTagTemplateRepositoryAsync, ICacheManager cacheManager, IClock clock)
        {
            _adTagTemplateRepositoryAsync = adTagTemplateRepositoryAsync;
            _cacheManager = cacheManager;
            _clock = clock;
        }

        public IQueryable<AdTagTemplate> GetAdTagTemplates()
        {
            var retVal = _cacheManager.Get(GetType(), context =>
            {
                context.Monitor(_clock.When(TimeSpan.FromMinutes(10))); // cache for 10 mins
                return _adTagTemplateRepositoryAsync.Queryable().Where(x => x.IsActive).OrderBy(x => x.Position).ToList();
            });
            return retVal.ToAsyncEnumerable();
        }

        public Task<AdTagTemplate> GetAdTagTemplate(int id)
        {
            return Task.FromResult(GetAdTagTemplates().FirstOrDefault(x => x.AdTagTemplateId == id));
        }

        public async Task<IDictionary<string, string>> Parse(int id, string adTag)
        {
            var adTagTemplate = await GetAdTagTemplate(id);
            if (string.IsNullOrEmpty(adTagTemplate.ParseRegEx)) return null;

            var regex = new Regex(adTagTemplate.ParseRegEx, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var match = regex.Match(adTag);
            if (!match.Success) return null;

            var retVal = new Dictionary<string, string>();
            foreach (var groupName in regex.GetGroupNames())
            {
                int groupNumber;
                if (int.TryParse(groupName, out groupNumber)) continue; // only capture named group

                var value = match.Groups[groupName].Value;
                if (match.Groups[groupName].Captures.Cast<Capture>().Any(capture => capture.Value != value))
                {
                    // all captures for the same group must be the same
                    // normally only have one capture per group
                    // e.g. cannot have two different 'WIDTH'
                    return null;
                }

                if (!string.IsNullOrEmpty(value))
                {
                    // bypass empty value
                    retVal.Add(groupName, value);
                }
            }
            return retVal;
        }
    }

    public static class AdTagTemplateServiceExtensions
    {
        public static Task<AdTagTemplate> GetFacebookAdTagTemplate(this IAdTagTemplateService adTagTemplateService)
        {
            return adTagTemplateService.GetAdTagTemplate(45); // hardcode id
        }

        public static Task<AdTagTemplate> GetOutlookAdTagTemplate(this IAdTagTemplateService adTagTemplateService)
        {
            return adTagTemplateService.GetAdTagTemplate(64); // hardcode id
        }

        public static Task<AdTagTemplate> GetGeneric3PasAdTagTemplate(this IAdTagTemplateService adTagTemplateService)
        {
            return adTagTemplateService.GetAdTagTemplate(66); // hardcode id
        }

        public static Task<AdTagTemplate> GetDoohAdTagTemplate(this IAdTagTemplateService adTagTemplateService)
        {
            return adTagTemplateService.GetAdTagTemplate(67); // hardcode id
        }

        public static Task<AdTagTemplate> GetVastAdTagTemplate(this IAdTagTemplateService adTagTemplateService)
        {
            return adTagTemplateService.GetAdTagTemplate(69); // hardcode id
        }

        public static Task<AdTagTemplate> GetSwiffyAdTagTemplate(this IAdTagTemplateService adTagTemplateService)
        {
            return adTagTemplateService.GetAdTagTemplate(71); // hardcode id
        }

        public static Task<AdTagTemplate> GetHtml5AdTagTemplate(this IAdTagTemplateService adTagTemplateService)
        {
            return adTagTemplateService.GetAdTagTemplate(72); // hardcode id
        }
    }
}
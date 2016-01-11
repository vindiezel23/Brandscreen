using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using Brandscreen.Framework.Caching;
using Brandscreen.WebApi.Areas.HelpPage.ModelDescriptions;
using Brandscreen.WebApi.Jsons;

namespace Brandscreen.WebApi.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        private readonly ICacheManager _cacheManager;
        private readonly HttpConfiguration _configuration;

        private static readonly object SyncLock = new object();
        private static bool _isInitialized;

        public HelpController(HttpConfiguration config, ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
            _configuration = config;
        }

        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = _configuration.Services.GetDocumentationProvider();
            var apiDescriptions = _configuration.Services.GetApiExplorer().ApiDescriptions;
            return PartialView(apiDescriptions);
        }

        public ActionResult Api(string apiId)
        {
            if (string.IsNullOrEmpty(apiId)) return JsonResultEx.Create(HttpStatusCode.NotFound);

            var apiModel = _configuration.GetHelpPageApiModel(apiId);
            if (apiModel != null)
            {
                return PartialView(apiModel);
            }

            return JsonResultEx.Create(HttpStatusCode.NotFound);
        }

        public ActionResult ResourceModel(string modelName)
        {
            if (string.IsNullOrEmpty(modelName)) return JsonResultEx.Create(HttpStatusCode.NotFound);

            var modelDescriptionGenerator = _configuration.GetModelDescriptionGenerator();
            ModelDescription modelDescription;
            if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
            {
                return PartialView(modelDescription);
            }

            if (!TryInitialize()) return JsonResultEx.Create(HttpStatusCode.NotFound);

            // retry
            if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
            {
                return PartialView(modelDescription);
            }
            return JsonResultEx.Create(HttpStatusCode.NotFound);
        }

        private bool TryInitialize()
        {
            if (_isInitialized) return false;

            lock (SyncLock)
            {
                if (_isInitialized) return false;

                return _cacheManager.Get(GetType(), context =>
                {
                    // force to generate all models
                    var apiIds = _configuration.Services.GetApiExplorer().ApiDescriptions.Select(x => x.GetFriendlyId());
                    foreach (var apiId in apiIds)
                    {
                        _configuration.GetHelpPageApiModel(apiId);
                    }

                    _isInitialized = true;
                    return true;
                });
            }
        }
    }
}
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Language management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/languages")]
    public class LanguagesController : ApiController
    {
        private readonly ILanguageService _languageService;
        private readonly IMappingEngine _mapping;

        public LanguagesController(ILanguageService languageService, IMappingEngine mapping)
        {
            _languageService = languageService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of languages.
        /// </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof (PagedListViewModel<LanguageListViewModel>))]
        public async Task<IHttpActionResult> Get([FromUri] Pagination model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var languages = await _languageService.GetLanguages().ToPagedListAsync(model).ConfigureAwait(false);
            var retVal = _mapping.Map<PagedListViewModel<LanguageListViewModel>>(languages);
            return Ok(retVal);
        }
    }
}
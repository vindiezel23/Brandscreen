using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Ad tag template management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/adtagtemplates")]
    public class AdTagTemplatesController : ApiController
    {
        private readonly IAdTagTemplateService _adTagTemplateService;
        private readonly IMappingEngine _mapping;

        public AdTagTemplatesController(IAdTagTemplateService adTagTemplateService, IMappingEngine mapping)
        {
            _adTagTemplateService = adTagTemplateService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of ad tag templates.
        /// </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof (PagedListViewModel<AdTagTemplateListViewModel>))]
        public async Task<IHttpActionResult> Get([FromUri] Pagination model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adTagTemplates = await _adTagTemplateService.GetAdTagTemplates().ToPagedListAsync(model).ConfigureAwait(false);
            var retVal = _mapping.Map<PagedListViewModel<AdTagTemplateListViewModel>>(adTagTemplates);
            return Ok(retVal);
        }
    }
}
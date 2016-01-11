using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Brandscreen.Core.Services.Partners;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Partner management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/partners")]
    public class PartnersController : ApiController
    {
        private readonly IPartnerService _partnerService;
        private readonly IMappingEngine _mapping;

        public PartnersController(IPartnerService partnerService, IMappingEngine mapping)
        {
            _partnerService = partnerService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of partners.
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<PagedListViewModel<PartnerViewModel>> Get([FromUri] Pagination model)
        {
            var partners = await _partnerService.GetPartners().ToPagedListAsync(model).ConfigureAwait(false);
            return _mapping.Map<PagedListViewModel<PartnerViewModel>>(partners);
        }
    }
}
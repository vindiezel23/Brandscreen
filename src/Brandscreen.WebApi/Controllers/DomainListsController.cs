using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Services.Strategies.Targets;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;
using Brandscreen.WebApi.Mappings;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Domain list management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/domainlists")]
    public class DomainListsController : ApiController
    {
        private readonly IDomainListService _domainListService;
        private readonly IMappingEngine _mapping;

        public DomainListsController(IDomainListService domainListService, IMappingEngine mapping)
        {
            _domainListService = domainListService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves details of a domain list by id.
        /// </summary>
        [HttpGet]
        [Route("{id:int}", Name = "DomainLists.GetById")]
        [ResponseType(typeof (DomainListViewModel))]
        public async Task<IHttpActionResult> Get(int id, [FromUri] Pagination pagination)
        {
            var domainList = await _domainListService.GetDomainList(id).ConfigureAwait(false);
            if (domainList == null)
            {
                return NotFound();
            }

            // note: domain list object contains list of domains
            // pagination is for paged list of domains as some domain list(e.g. 5001) contains over 500,000 domains
            var retVal = _mapping.Map<DomainListViewModel>(domainList, pagination);
            return Ok(retVal);
        }
    }
}
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Services.Publishers;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Publisher management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/publishers")]
    public class PublishersController : ApiController
    {
        private readonly IPublisherService _publisherService;
        private readonly IMappingEngine _mapping;

        public PublishersController(IPublisherService publisherService, IMappingEngine mapping)
        {
            _publisherService = publisherService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of publishers.
        /// </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof (PagedListViewModel<PublisherListViewModel>))]
        public async Task<IHttpActionResult> Get([FromUri] PublisherQueryViewModel model)
        {
            model = model ?? new PublisherQueryViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var publisherQueryOptions = _mapping.Map<PublisherQueryOptions>(model);
            var publishers = await _publisherService.GetPublishers(publisherQueryOptions).ToPagedListAsync(model).ConfigureAwait(false);
            var retVal = _mapping.Map<PagedListViewModel<PublisherListViewModel>>(publishers);
            return Ok(retVal);
        }

        /// <summary>
        /// Retrieves details of a publisher by id.
        /// </summary>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof (PublisherViewModel))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var publisher = await _publisherService.GetPublisher(id).ConfigureAwait(false);
            if (publisher == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<PublisherViewModel>(publisher);
            return Ok(retVal);
        }

        /// <summary>
        /// Retrieves details of a publisher by guid.
        /// </summary>
        [HttpGet]
        [Route("{guid:guid}")]
        [ResponseType(typeof (PublisherViewModel))]
        public async Task<IHttpActionResult> Get(Guid guid)
        {
            var publisher = await _publisherService.GetPublisher(guid).ConfigureAwait(false);
            if (publisher == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<PublisherViewModel>(publisher);
            return Ok(retVal);
        }
    }
}
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Entities;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Creative size management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/creativesizes")]
    public class CreativeSizesController : ApiController
    {
        private readonly ICreativeSizeService _creativeSizeService;
        private readonly IMappingEngine _mapping;

        public CreativeSizesController(ICreativeSizeService creativeSizeService, IMappingEngine mapping)
        {
            _creativeSizeService = creativeSizeService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of creative sizes.
        /// </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof (PagedListViewModel<CreativeSizeListViewModel>))]
        public async Task<IHttpActionResult> Get([FromUri] CreativeSizeQueryViewModel model)
        {
            model = model ?? new CreativeSizeQueryViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creativeSizeQueryOptions = _mapping.Map<CreativeSizeQueryOptions>(model);
            var creativeSizes = await _creativeSizeService.GetCreativeSizes(creativeSizeQueryOptions).ToPagedListAsync(model).ConfigureAwait(false);
            var retVal = _mapping.Map<PagedListViewModel<CreativeSizeListViewModel>>(creativeSizes);
            return Ok(retVal);
        }

        /// <summary>
        /// Retrieves detail of a creative size by id.
        /// </summary>
        [HttpGet]
        [Route("{id:int}", Name = "CreativeSizes.GetById")]
        [ResponseType(typeof (CreativeSizeViewModel))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var creativeSize = await _creativeSizeService.GetCreativeSize(id).ConfigureAwait(false);
            if (creativeSize == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<CreativeSizeViewModel>(creativeSize);
            return Ok(retVal);
        }

        /// <summary>
        /// Creates a new creative size.
        /// </summary>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof (CreativeSizeViewModel))]
        public async Task<IHttpActionResult> Post(CreativeSizeCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _creativeSizeService.GetCreativeSize(model.CreativeSizeId.GetValueOrDefault(0)) != null)
            {
                return BadRequest("The specified creative size id is already taken.");
            }

            // map
            var creativeSize = _mapping.Map<CreativeSize>(model);
            await _creativeSizeService.CreateCreativeSize(creativeSize).ConfigureAwait(false);
            creativeSize = await _creativeSizeService.GetCreativeSize(creativeSize.CreativeSizeId).ConfigureAwait(false);
            var creativeSizeViewModel = _mapping.Map<CreativeSizeViewModel>(creativeSize);
            return CreatedAtRoute("CreativeSizes.GetById", new {Id = creativeSizeViewModel.CreativeSizeId}, creativeSizeViewModel);
        }

        /// <summary>
        /// Updates a creative size.
        /// </summary>
        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Patch(int id, CreativeSizePatchViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creativeSize = await _creativeSizeService.GetCreativeSize(id).ConfigureAwait(false);
            if (creativeSize == null)
            {
                return NotFound();
            }

            _mapping.Map(model, creativeSize);
            await _creativeSizeService.UpdateCreativeSize(creativeSize).ConfigureAwait(false);
            return Ok();
        }
    }
}
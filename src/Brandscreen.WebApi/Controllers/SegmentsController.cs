using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Advertisers;
using Brandscreen.Core.Services.Segments;
using Brandscreen.Entities;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Segment management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/segments")]
    public class SegmentsController : ApiController
    {
        private readonly ISegmentService _segmentService;
        private readonly IAdvertiserService _advertiserService;
        private readonly IMappingEngine _mapping;

        public SegmentsController(ISegmentService segmentService, IAdvertiserService advertiserService, IMappingEngine mapping)
        {
            _segmentService = segmentService;
            _advertiserService = advertiserService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of segments.
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<PagedListViewModel<SegmentListViewModel>> Get([FromUri] SegmentQueryViewModel model)
        {
            var segmentQueryOptions = _mapping.Map<SegmentQueryOptions>(model);
            var deals = await _segmentService.GetSegments(segmentQueryOptions).ToPagedListAsync(model).ConfigureAwait(false);
            return _mapping.Map<PagedListViewModel<SegmentListViewModel>>(deals);
        }

        /// <summary>
        /// Retrieves details of a segment by id.
        /// </summary>
        [HttpGet]
        [Route("{id:int}", Name = "Segments.GetById")]
        [ResponseType(typeof (SegmentViewModel))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var segment = await _segmentService.GetSegment(id).ConfigureAwait(false);
            if (segment == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<SegmentViewModel>(segment);
            return Ok(retVal);
        }

        /// <summary>
        /// Creates a remarketing segment.
        /// </summary>
        [HttpPost]
        [Route("remarketings")]
        [ResponseType(typeof (SegmentViewModel))]
        public async Task<IHttpActionResult> PostRemarketings(SegmentRemarketingCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var advertiser = await _advertiserService.GetAdvertiser(model.AdvertiserUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (advertiser == null)
            {
                return BadRequest("The specified advertiser was not found.");
            }

            var segment = _mapping.Map<Segment>(model);
            await _segmentService.CreateSegment(segment).ConfigureAwait(false);

            segment = await _segmentService.GetSegment(segment.SegmentId).ConfigureAwait(false);
            var segmentViewModel = _mapping.Map<SegmentViewModel>(segment);
            return CreatedAtRoute("Segments.GetById", new {Id = segmentViewModel.SegmentId}, segmentViewModel);
        }

        /// <summary>
        /// Updates a remarketing segment.
        /// </summary>
        [HttpPatch]
        [Route("remarketings/{id:int}")]
        public async Task<IHttpActionResult> PatchRemarketings(int id, SegmentRemarketingPatchViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var segment = await _segmentService.GetSegment(id).ConfigureAwait(false);
            if (segment == null)
            {
                return NotFound();
            }

            _mapping.Map(model, segment);
            await _segmentService.UpdateSegment(segment).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Creates a conversion segment.
        /// </summary>
        [HttpPost]
        [Route("conversions")]
        [ResponseType(typeof (SegmentViewModel))]
        public async Task<IHttpActionResult> PostConversions(SegmentConversionCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var advertiser = await _advertiserService.GetAdvertiser(model.AdvertiserUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (advertiser == null)
            {
                return BadRequest("The specified advertiser was not found.");
            }

            var segment = _mapping.Map<Segment>(model);
            await _segmentService.CreateSegment(segment).ConfigureAwait(false);

            segment = await _segmentService.GetSegment(segment.SegmentId).ConfigureAwait(false);
            var segmentViewModel = _mapping.Map<SegmentViewModel>(segment);
            return CreatedAtRoute("Segments.GetById", new {Id = segmentViewModel.SegmentId}, segmentViewModel);
        }

        /// <summary>
        /// Updates a conversion segment.
        /// </summary>
        [HttpPatch]
        [Route("conversions/{id:int}")]
        public async Task<IHttpActionResult> PatchConversions(int id, SegmentConversionPatchViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var segment = await _segmentService.GetSegment(id).ConfigureAwait(false);
            if (segment == null)
            {
                return NotFound();
            }

            _mapping.Map(model, segment);
            await _segmentService.UpdateSegment(segment).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Creates a third party segment.
        /// </summary>
        [HttpPost]
        [Route("thirdparties")]
        [ResponseType(typeof (SegmentViewModel))]
        public async Task<IHttpActionResult> PostThirdParties(SegmentThirdPartyCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(model.ParentRtbSegmentId))
            {
                var claim = Request.GetOwinContext().Authentication.User.Claims.Where(x => x.Type == StandardClaimType.SegmentThirdPartyParent)
                    .FirstOrDefault(x => x.Value.StartsWith(model.RtbSegmentId.Split(':')[0]));
                if (claim == null)
                {
                    return BadRequest($"The default parent segment for {model.RtbSegmentId} was not found.");
                }

                // default parent
                model.ParentRtbSegmentId = claim.Value;
            }

            var parentSegment = await _segmentService.GetSegment(model.ParentRtbSegmentId).ConfigureAwait(false);
            if (parentSegment == null)
            {
                return BadRequest("The specified parent segment was not found.");
            }
            if (model.ParentRtbSegmentId.Split(':')[0] != model.RtbSegmentId.Split(':')[0])
            {
                return BadRequest("The rtb segment prefix must be the same as its parent.");
            }

            var segment = _mapping.Map<Segment>(model, options => options.Items.Add(nameof(parentSegment), parentSegment));
            await _segmentService.CreateSegment(segment).ConfigureAwait(false);

            segment = await _segmentService.GetSegment(segment.SegmentId).ConfigureAwait(false);
            var segmentViewModel = _mapping.Map<SegmentViewModel>(segment);
            return CreatedAtRoute("Segments.GetById", new {Id = segmentViewModel.SegmentId}, segmentViewModel);
        }

        /// <summary>
        /// Updates a third party segment.
        /// </summary>
        [HttpPatch]
        [Route("thirdparties/{id:int}")]
        public async Task<IHttpActionResult> PatchThirdParties(int id, SegmentThirdPartyPatchViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var segment = await _segmentService.GetSegment(id).ConfigureAwait(false);
            if (segment == null)
            {
                return NotFound();
            }

            _mapping.Map(model, segment);
            await _segmentService.UpdateSegment(segment).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Deletes a segment by id.
        /// </summary>
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var segment = await _segmentService.GetSegment(id).ConfigureAwait(false);
            if (segment == null)
            {
                return NotFound();
            }

            await _segmentService.DeleteSegment(id).ConfigureAwait(false);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
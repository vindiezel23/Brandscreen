using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Brands;
using Brandscreen.Core.Services.Creatives;
using Brandscreen.Core.Services.Creatives.Vast;
using Brandscreen.Framework.Services;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;
using Castle.Core.Logging;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Creative management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/creatives")]
    public class CreativesController : ApiController
    {
        private readonly ICreativeService _creativeService;
        private readonly ICreativeSizeService _creativeSizeService;
        private readonly IBrandService _brandService;
        private readonly IAdTagTemplateService _adTagTemplateService;
        private readonly IVastService _vastService;
        private readonly IMappingEngine _mapping;
        private readonly IClock _clock;

        public CreativesController(ICreativeService creativeService, ICreativeSizeService creativeSizeService, IBrandService brandService, IAdTagTemplateService adTagTemplateService, IVastService vastService, IMappingEngine mapping, IClock clock)
        {
            _creativeService = creativeService;
            _creativeSizeService = creativeSizeService;
            _brandService = brandService;
            _adTagTemplateService = adTagTemplateService;
            _vastService = vastService;
            _mapping = mapping;
            _clock = clock;

            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        /// <summary>
        /// Retrieves list of creatives.
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<PagedListViewModel<CreativeListViewModel>> Get([FromUri] CreativeQueryViewModel model)
        {
            var creativeQueryOptions = _mapping.Map<CreativeQueryOptions>(model);
            var creatives = await _creativeService.GetCreatives(creativeQueryOptions).ToPagedListAsync(model).ConfigureAwait(false);
            return _mapping.Map<PagedListViewModel<CreativeListViewModel>>(creatives);
        }

        /// <summary>
        /// Retrieves details of a creative by id.
        /// </summary>
        [HttpGet]
        [Route("{id:guid}", Name = "Creatives.GetById")]
        [ResponseType(typeof (CreativeViewModel))]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var creative = await _creativeService.GetCreative(id).ConfigureAwait(false);
            if (creative == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<CreativeViewModel>(creative);
            return Ok(retVal);
        }

        /// <summary>
        /// Creates a creative.
        /// </summary>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof (CreativeViewModel))]
        public async Task<IHttpActionResult> Post(CreativeCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = await _brandService.GetBrand(model.BrandUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (brand == null)
            {
                return BadRequest("The specified brand was not found.");
            }

            var adTagTemplate = await _adTagTemplateService.GetAdTagTemplate(model.AdTagTemplateId.GetValueOrDefault(0)).ConfigureAwait(false);
            if (adTagTemplate == null)
            {
                return BadRequest("The specified template was not found.");
            }

            var creativeCreateOptions = _mapping.Map<CreativeCreateOptions>(model);
            if (adTagTemplate.CreativeTypeId != (int) creativeCreateOptions.CreativeType)
            {
                return BadRequest($"The specified template cannot apply to the creative type {creativeCreateOptions.CreativeType}.");
            }

            try
            {
                var creative = await _creativeService.CreateCreative(creativeCreateOptions).ConfigureAwait(false);
                creative = await _creativeService.GetCreative(creative.CreativeUuid).ConfigureAwait(false); // reload
                var creativeViewModel = _mapping.Map<CreativeViewModel>(creative);
                return CreatedAtRoute("Creatives.GetById", new {Id = creativeViewModel.CreativeUuid}, creativeViewModel);
            }
            catch (BrandscreenException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Creates a digital-out-of-home creative.
        /// </summary>
        [HttpPost]
        [Route("dooh")]
        [ResponseType(typeof (CreativeViewModel))]
        public async Task<IHttpActionResult> PostDooh(CreativeDoohCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = await _brandService.GetBrand(model.BrandUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (brand == null)
            {
                return BadRequest("The specified brand was not found.");
            }

            var creativeSize = await _creativeSizeService.GetCreativeSize(model.CreativeSizeId.GetValueOrDefault(0)).ConfigureAwait(false);
            if (creativeSize == null)
            {
                return BadRequest("The specified creative size was not found.");
            }

            var creativeDoohCreateOptions = _mapping.Map<CreativeDoohCreateOptions>(model);
            try
            {
                var creative = await _creativeService.CreateCreative(creativeDoohCreateOptions).ConfigureAwait(false);
                creative = await _creativeService.GetCreative(creative.CreativeUuid).ConfigureAwait(false); // reload
                var creativeViewModel = _mapping.Map<CreativeViewModel>(creative);
                return CreatedAtRoute("Creatives.GetById", new {Id = creativeViewModel.CreativeUuid}, creativeViewModel);
            }
            catch (BrandscreenException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Creates a digital-out-of-home video creative.
        /// </summary>
        [HttpPost]
        [Route("dooh/video")]
        [ResponseType(typeof (CreativeViewModel))]
        public async Task<IHttpActionResult> PostDoohVideo(CreativeDoohVideoCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = await _brandService.GetBrand(model.BrandUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (brand == null)
            {
                return BadRequest("The specified brand was not found.");
            }

            var creativeSize = await _creativeSizeService.GetCreativeSize(model.CreativeSizeId.GetValueOrDefault(0)).ConfigureAwait(false);
            if (creativeSize == null)
            {
                return BadRequest("The specified creative size was not found.");
            }

            var creativeDoohVideoCreateOptions = _mapping.Map<CreativeDoohVideoCreateOptions>(model);
            try
            {
                var creative = await _creativeService.CreateCreative(creativeDoohVideoCreateOptions).ConfigureAwait(false);
                creative = await _creativeService.GetCreative(creative.CreativeUuid).ConfigureAwait(false); // reload
                var creativeViewModel = _mapping.Map<CreativeViewModel>(creative);
                return CreatedAtRoute("Creatives.GetById", new {Id = creativeViewModel.CreativeUuid}, creativeViewModel);
            }
            catch (BrandscreenException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Creates a digital-out-of-home video url creative.
        /// </summary>
        [HttpPost]
        [Route("dooh/videourl")]
        [ResponseType(typeof (CreativeViewModel))]
        public async Task<IHttpActionResult> PostDoohVideoUrl(CreativeDoohVideoUrlCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = await _brandService.GetBrand(model.BrandUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (brand == null)
            {
                return BadRequest("The specified brand was not found.");
            }

            var creativeSize = await _creativeSizeService.GetCreativeSize(model.CreativeSizeId.GetValueOrDefault(0)).ConfigureAwait(false);
            if (creativeSize == null)
            {
                return BadRequest("The specified creative size was not found.");
            }

            var creativeDoohVideoUrlCreateOptions = _mapping.Map<CreativeDoohVideoUrlCreateOptions>(model);
            try
            {
                var creative = await _creativeService.CreateCreative(creativeDoohVideoUrlCreateOptions).ConfigureAwait(false);
                creative = await _creativeService.GetCreative(creative.CreativeUuid).ConfigureAwait(false); // reload
                var creativeViewModel = _mapping.Map<CreativeViewModel>(creative);
                return CreatedAtRoute("Creatives.GetById", new {Id = creativeViewModel.CreativeUuid}, creativeViewModel);
            }
            catch (BrandscreenException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Creates a vast creative.
        /// </summary>
        [HttpPost]
        [Route("vast")]
        [ResponseType(typeof (CreativeViewModel))]
        public async Task<IHttpActionResult> PostVast(CreativeVastCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = await _brandService.GetBrand(model.BrandUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (brand == null)
            {
                return BadRequest("The specified brand was not found.");
            }

            var vastXml = await _vastService.Download(model.VastUrl).ConfigureAwait(false);
            var vastValidationResult = await _vastService.Validate(vastXml).ConfigureAwait(false);
            if (!vastValidationResult.Success)
            {
                Logger.Warn($"vast content is invalid at {model.VastUrl} with error {vastValidationResult.Error} with content {vastXml}.");
                ModelState.AddModelError("VastUrl", $"VastUrl is invalid with error {vastValidationResult.Error}.");
                return BadRequest(ModelState);
            }

            var creativeVastCreateOptions = _mapping.Map<CreativeVastCreateOptions>(model);
            creativeVastCreateOptions.VastXml = vastXml; // set vast xml
            try
            {
                var creative = await _creativeService.CreateCreative(creativeVastCreateOptions).ConfigureAwait(false);
                creative = await _creativeService.GetCreative(creative.CreativeUuid).ConfigureAwait(false); // reload
                var creativeViewModel = _mapping.Map<CreativeViewModel>(creative);
                return CreatedAtRoute("Creatives.GetById", new {Id = creativeViewModel.CreativeUuid}, creativeViewModel);
            }
            catch (BrandscreenException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Creates a swiffy creative.
        /// </summary>
        [HttpPost]
        [Route("swiffy")]
        [ResponseType(typeof (CreativeViewModel))]
        public async Task<IHttpActionResult> PostSwiffy(CreativeSwiffyCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = await _brandService.GetBrand(model.BrandUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (brand == null)
            {
                return BadRequest("The specified brand was not found.");
            }

            var creativeSwiffyCreateOptions = _mapping.Map<CreativeSwiffyCreateOptions>(model);
            try
            {
                var creative = await _creativeService.CreateCreative(creativeSwiffyCreateOptions).ConfigureAwait(false);
                creative = await _creativeService.GetCreative(creative.CreativeUuid).ConfigureAwait(false); // reload
                var creativeViewModel = _mapping.Map<CreativeViewModel>(creative);
                return CreatedAtRoute("Creatives.GetById", new {Id = creativeViewModel.CreativeUuid}, creativeViewModel);
            }
            catch (BrandscreenException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Creates a html5 creative.
        /// </summary>
        [HttpPost]
        [Route("html5")]
        [ResponseType(typeof (CreativeViewModel))]
        public async Task<IHttpActionResult> PostHtml5(CreativeHtml5CreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = await _brandService.GetBrand(model.BrandUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (brand == null)
            {
                return BadRequest("The specified brand was not found.");
            }

            var creativeHtml5CreateOptions = _mapping.Map<CreativeHtml5CreateOptions>(model);
            try
            {
                var creative = await _creativeService.CreateCreative(creativeHtml5CreateOptions).ConfigureAwait(false);
                creative = await _creativeService.GetCreative(creative.CreativeUuid).ConfigureAwait(false); // reload
                var creativeViewModel = _mapping.Map<CreativeViewModel>(creative);
                return CreatedAtRoute("Creatives.GetById", new {Id = creativeViewModel.CreativeUuid}, creativeViewModel);
            }
            catch (BrandscreenException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Creates an ad tag creative.
        /// </summary>
        [HttpPost]
        [Route("adtag")]
        [ResponseType(typeof (CreativeViewModel))]
        public async Task<IHttpActionResult> PostAdTag(CreativeAdTagCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = await _brandService.GetBrand(model.BrandUuid.GetValueOrDefault(Guid.Empty)).ConfigureAwait(false);
            if (brand == null)
            {
                return BadRequest("The specified brand was not found.");
            }

            var adTagTemplate = await _adTagTemplateService.GetAdTagTemplate(model.AdTagTemplateId.GetValueOrDefault(0)).ConfigureAwait(false);
            if (adTagTemplate == null)
            {
                return BadRequest("The specified template was not found.");
            }

            var creativeSize = await _creativeSizeService.GetCreativeSize(model.CreativeSizeId.GetValueOrDefault(0)).ConfigureAwait(false);
            if (creativeSize == null)
            {
                return BadRequest("The specified creative size was not found.");
            }

            var creativeAdTagCreateOptions = _mapping.Map<CreativeAdTagCreateOptions>(model);
            try
            {
                var creative = await _creativeService.CreateCreative(creativeAdTagCreateOptions).ConfigureAwait(false);
                creative = await _creativeService.GetCreative(creative.CreativeUuid).ConfigureAwait(false); // reload
                var creativeViewModel = _mapping.Map<CreativeViewModel>(creative);
                return CreatedAtRoute("Creatives.GetById", new {Id = creativeViewModel.CreativeUuid}, creativeViewModel);
            }
            catch (BrandscreenException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Updates a creative.
        /// </summary>
        [HttpPatch]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Patch(Guid id, CreativePatchViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creative = await _creativeService.GetCreative(id).ConfigureAwait(false);
            if (creative == null)
            {
                return NotFound();
            }

            var creativeUpdateOptions = _mapping.Map<CreativeUpdateOptions>(model, options => options.Items.Add(nameof(id), id));
            await _creativeService.UpdateCreative(creativeUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Deletes a creative.
        /// </summary>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var creative = await _creativeService.GetCreative(id).ConfigureAwait(false);
            if (creative == null)
            {
                return NotFound();
            }

            await _creativeService.DeleteCreative(id).ConfigureAwait(false);
            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Retrieves list of creative parameters by id.
        /// </summary>
        [HttpGet]
        [Route("{id:guid}/parameters")]
        [ResponseType(typeof (CreativeParameterListViewModel))]
        public async Task<IHttpActionResult> GetParameters(Guid id)
        {
            var creative = await _creativeService.GetCreative(id).ConfigureAwait(false);
            if (creative == null)
            {
                return NotFound();
            }

            var creativeParameters = await _creativeService.GetCreativeParameters(id).ToListAsync().ConfigureAwait(false);
            var data = _mapping.Map<IEnumerable<CreativeParameterViewModel>>(creativeParameters);
            var retVal = new CreativeParameterListViewModel
            {
                CreativeUuid = id,
                Timestamp = _clock.UtcNow,
                Data = data
            };
            return Ok(retVal);
        }

        /// <summary>
        /// Retrieves reviews of a creative by id.
        /// </summary>
        [HttpGet]
        [Route("{id:guid}/reviews")]
        [ResponseType(typeof (IEnumerable<CreativeReviewListViewModel>))]
        public async Task<IHttpActionResult> GetReviews(Guid id)
        {
            var creative = await _creativeService.GetCreative(id).ConfigureAwait(false);
            if (creative == null)
            {
                return NotFound();
            }

            var creativeReviews = await _creativeService.GetCreativeReviews(id).ToListAsync().ConfigureAwait(false);
            var retVal = _mapping.Map<IEnumerable<CreativeReviewListViewModel>>(creativeReviews);
            return Ok(retVal);
        }

        /// <summary>
        /// Reviews a creative by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/review")]
        public async Task<IHttpActionResult> PutReview(Guid id, CreativeReviewViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creative = await _creativeService.GetCreative(id).ConfigureAwait(false);
            if (creative == null)
            {
                return NotFound();
            }

            // check version
            var creativeVersion = creative.UtcModifiedDateTime.ToUnixTimeSeconds();
            if (creativeVersion != model.CreativeVersion)
            {
                ModelState.AddModelError(nameof(model.CreativeVersion), "Creative version is invalid.");
                return BadRequest(ModelState);
            }

            var creativeReviewModifyOptions = _mapping.Map<CreativeReviewModifyOptions>(model, options => options.Items.Add("creativeUuid", id));
            try
            {
                await _creativeService.CreateOrUpdateCreativeReview(creativeReviewModifyOptions).ConfigureAwait(false);
                return Ok();
            }
            catch (BrandscreenException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
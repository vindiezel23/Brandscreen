using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Advertisers;
using Brandscreen.Core.Services.Brands;
using Brandscreen.Entities;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Brand management.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/brands")]
    public class BrandsController : ApiController
    {
        private readonly IBrandService _brandService;
        private readonly IAdvertiserService _advertiserService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IMappingEngine _mapping;

        public BrandsController(IBrandService brandService, IAdvertiserService advertiserService, IProductCategoryService productCategoryService, IMappingEngine mapping)
        {
            _brandService = brandService;
            _advertiserService = advertiserService;
            _productCategoryService = productCategoryService;
            _mapping = mapping;
        }

        /// <summary>
        /// Retrieves list of brands.
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<PagedListViewModel<BrandListViewModel>> Get([FromUri] BrandQueryViewModel model)
        {
            var brandQueryOptions = _mapping.Map<BrandQueryOptions>(model);
            var brands = await _brandService.GetBrands(brandQueryOptions).ToPagedListAsync(model).ConfigureAwait(false);
            return _mapping.Map<PagedListViewModel<BrandListViewModel>>(brands);
        }

        /// <summary>
        /// Retrieves details of a brand by id.
        /// </summary>
        [HttpGet]
        [Route("{id:guid}", Name = "Brands.GetById")]
        [ResponseType(typeof (BrandViewModel))]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var brand = await _brandService.GetBrand(id).ConfigureAwait(false);
            if (brand == null)
            {
                return NotFound();
            }

            var retVal = _mapping.Map<BrandViewModel>(brand);
            return Ok(retVal);
        }

        /// <summary>
        /// Creates a brand.
        /// </summary>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof (BrandViewModel))]
        public async Task<IHttpActionResult> Post(BrandCreateViewModel model)
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

            var productCategory = await _productCategoryService.GetProductCategory(model.ProductCategoryId.GetValueOrDefault(0)).ConfigureAwait(false);
            if (productCategory == null)
            {
                return BadRequest("The specified product category was not found.");
            }

            var brand = _mapping.Map<AdvertiserProduct>(model);
            await _brandService.CreateBrand(brand).ConfigureAwait(false);

            brand = await _brandService.GetBrand(brand.AdvertiserProductUuid).ConfigureAwait(false);
            var brandViewModel = _mapping.Map<BrandViewModel>(brand);
            return CreatedAtRoute("Brands.GetById", new {Id = brandViewModel.BrandUuid}, brandViewModel);
        }

        /// <summary>
        /// Updates a brand.
        /// </summary>
        [HttpPatch]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Patch(Guid id, BrandPatchViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = await _brandService.GetBrand(id).ConfigureAwait(false);
            if (brand == null)
            {
                return NotFound();
            }

            if (model.ProductCategoryId.HasValue)
            {
                var productCategory = await _productCategoryService.GetProductCategory(model.ProductCategoryId.Value).ConfigureAwait(false);
                if (productCategory == null)
                {
                    return BadRequest("The specified product category was not found.");
                }
            }

            _mapping.Map(model, brand);
            await _brandService.UpdateBrand(brand).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Deletes a brand.
        /// </summary>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var brand = await _brandService.GetBrand(id).ConfigureAwait(false);
            if (brand == null)
            {
                return NotFound();
            }

            await _brandService.DeleteBrand(id).ConfigureAwait(false);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
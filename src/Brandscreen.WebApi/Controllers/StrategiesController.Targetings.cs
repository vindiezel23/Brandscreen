using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Brandscreen.Core.Services.Strategies;
using Brandscreen.WebApi.Models;

namespace Brandscreen.WebApi.Controllers
{
    public partial class StrategiesController
    {
        /// <summary>
        /// Retrieves targeting details of a strategy by id.
        /// </summary>
        [HttpGet]
        [Route("{id:guid}/targetings")]
        [ResponseType(typeof (Dictionary<string, object>))]
        public async Task<IHttpActionResult> GetTargetings(Guid id)
        {
            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var retVal = new Dictionary<string, object>
            {
                ["StrategyUuid"] = id,
                ["Timestamp"] = _clock.UtcNow
            };

            // collect targeting data
            foreach (var call in GetTargetingCalls())
            {
                var result = (IEnumerable) call.Value(_strategyTargetingService, id, _mapping);
                if (result.GetEnumerator().MoveNext())
                {
                    // only add not empty result
                    retVal[call.Key] = result;
                }
            }

            return Ok(retVal);
        }

        /// <summary>
        /// Updates country targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/countries")]
        public async Task<IHttpActionResult> PutTargetingCountries(Guid id, StrategyTargetingCountryPutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<int>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetCountries(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates region targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/regions")]
        public async Task<IHttpActionResult> PutTargetingRegions(Guid id, StrategyTargetingRegionPutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<int>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetRegions(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates city targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/cities")]
        public async Task<IHttpActionResult> PutTargetingCities(Guid id, StrategyTargetingCityPutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<int>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetCities(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates postcode targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/postcodes")]
        public async Task<IHttpActionResult> PutTargetingPostcodes(Guid id, StrategyTargetingPostcodePutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<StrategyTargetingGeoPostcode>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetPostcodes(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates dooh location targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/locations")]
        public async Task<IHttpActionResult> PutTargetingDoohGeoLocations(Guid id, StrategyTargetingDoohGeoLocationPutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<int>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetDoohGeoLocationGroups(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates language targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/languages")]
        public async Task<IHttpActionResult> PutTargetingLanguages(Guid id, StrategyTargetingLanguagePutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<int>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetLanguages(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates vertical targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/verticals")]
        public async Task<IHttpActionResult> PutTargetingVerticals(Guid id, StrategyTargetingVerticalPutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<int>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetVerticals(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates partner targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/partners")]
        public async Task<IHttpActionResult> PutTargetingPartners(Guid id, StrategyTargetingPartnerPutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<int>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetPartners(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates dooh panel location targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/doohpanellocations")]
        public async Task<IHttpActionResult> PutDoohPanelLocations(Guid id, StrategyTargetingDoohPanelLocationPutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<int>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetDoohPanelLocations(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates publisher targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/publishers")]
        public async Task<IHttpActionResult> PutTargetingPublishers(Guid id, StrategyTargetingPublisherPutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<int>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetPublishers(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates domain list targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/domainlists")]
        public async Task<IHttpActionResult> PutTargetingDomainLists(Guid id, StrategyTargetingDomainListPutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<int>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetDomainLists(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates segment targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/segments")]
        public async Task<IHttpActionResult> PutTargetingSegments(Guid id, StrategyTargetingSegmentPutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<int>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetSegments(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates device targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/devices")]
        public async Task<IHttpActionResult> PutTargetingDevices(Guid id, StrategyTargetingDevicePutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<int>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetDevices(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates mobile carrier targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/mobilecarriers")]
        public async Task<IHttpActionResult> PutTargetingMobileCarriers(Guid id, StrategyTargetingMobileCarrierPutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<StrategyTargetingMobileCarrier>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetMobileCarriers(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates day part targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/dayparts")]
        public async Task<IHttpActionResult> PutTargetingDayParts(Guid id, StrategyTargetingDayPartPutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<int>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetDayParts(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Updates page position targetings for a strategy by id.
        /// </summary>
        [HttpPut]
        [Route("{id:guid}/targetings/pagepositions")]
        public async Task<IHttpActionResult> PutTargetingPagePositions(Guid id, StrategyTargetingPagePositionPutViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = await _strategyService.GetStrategy(id).ConfigureAwait(false);
            if (strategy == null)
            {
                return NotFound();
            }

            var strategyTargetingUpdateOptions = _mapping.Map<StrategyTargetingUpdateOptions<int>>(model, options => options.Items.Add(nameof(id), id));
            await _strategyTargetingUpdateService.SetPagePositions(strategyTargetingUpdateOptions).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Builds get targeting call functions for IStrategyTargetingService and uses map engine to covert the result to corresponding view model
        /// </summary>
        private IDictionary<string, Func<IStrategyTargetingService, Guid, IMappingEngine, object>> GetTargetingCalls()
        {
            return _cacheManager.Get("GetTargetingCalls", context =>
            {
                // looking for methods' name starts with Get and return IQueryable<T>
                var getMethodInfos = typeof (IStrategyTargetingService).GetMethods()
                    .Where(x => x.Name.StartsWith("Get") && x.ReturnType.IsGenericType && x.ReturnType.GetGenericTypeDefinition() == typeof (IQueryable<>));

                // object Map(object source, Type sourceType, Type destinationType);
                var mapMethodInfo = typeof (IMappingEngine).GetMethod("Map", new[] {typeof (object), typeof (Type), typeof (Type)});

                var retVal = new Dictionary<string, Func<IStrategyTargetingService, Guid, IMappingEngine, object>>();
                foreach (var getMethodInfo in getMethodInfos)
                {
                    // looking for view model type
                    var entityType = getMethodInfo.ReturnType.GetGenericArguments()[0];
                    var viewModelTypeName = $"Strategy{entityType.Name.Substring(7)}ViewModel"; // removes prefix 'AdGroup'
                    var viewModelType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == viewModelTypeName);
                    if (viewModelType == null) continue;

                    // build expression to call the 'Get' Targeting method
                    var p1 = Expression.Parameter(typeof (IStrategyTargetingService), "strategyTargetingService");
                    var p2 = Expression.Parameter(typeof (Guid), "strategyUuid");
                    var p3 = Expression.Parameter(typeof (IMappingEngine), "mapping");
                    var getCall = Expression.Call(p1, getMethodInfo, p2); // returns IQueryable<T>
                    var mapType = typeof (IEnumerable<>).MakeGenericType(viewModelType);
                    var mapCall = Expression.Call(p3, mapMethodInfo, getCall, Expression.Constant(getMethodInfo.ReturnType), Expression.Constant(mapType)); // returns IEnumerable<T>
                    var lambda = Expression.Lambda<Func<IStrategyTargetingService, Guid, IMappingEngine, object>>(mapCall, p1, p2, p3);

                    // cache the call
                    var key = getMethodInfo.Name.Substring(3); // remove prefix 'Get'
                    retVal[key] = lambda.Compile();
                }
                return retVal;
            });
        }
    }
}
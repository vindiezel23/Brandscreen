using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Brandscreen.WebApi.Areas.HelpPage;
using Brandscreen.WebApi.Areas.HelpPage.SampleGeneration;
using Brandscreen.WebApi.Models.Postman;

namespace Brandscreen.WebApi.Controllers
{
    /// <summary>
    /// Based on http://blogs.msdn.com/b/yaohuang1/archive/2012/06/15/using-apiexplorer-to-export-api-information-to-postman-a-chrome-extension-for-testing-web-apis.aspx
    /// Allows api endpoints to be imported into postman
    /// </summary>
    [RoutePrefix("api/postman")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PostmanApiController : ApiController
    {
        /// <summary>
        ///     Produce [POSTMAN](http://www.getpostman.com) related responses
        /// </summary>
        public PostmanApiController()
        {
            // exists for documentation purposes
        }

        private readonly Regex _pathVariableRegEx = new Regex("\\{([A-Za-z0-9-_]+)\\}", RegexOptions.ECMAScript | RegexOptions.Compiled);
        private readonly Regex _urlParameterVariableRegEx = new Regex("=\\{([A-Za-z0-9-_]+)\\}", RegexOptions.ECMAScript | RegexOptions.Compiled);

        /// <summary>
        ///     Get a postman collection of all visible Api
        ///     (Get the [POSTMAN](http://www.getpostman.com) chrome extension)
        /// </summary>
        /// <returns>object describing a POSTMAN collection</returns>
        /// <remarks>Get a postman collection of all visible api</remarks>
        [HttpGet]
        [Route(Name = "GetPostmanCollection")]
        [ResponseType(typeof (PostmanCollectionGet))]
        public IHttpActionResult GetPostmanCollection()
        {
            return Ok(PostmanCollectionForController());
        }

        private PostmanCollectionGet PostmanCollectionForController()
        {
            var requestUri = Request.RequestUri;
            var baseUri = requestUri.Scheme + "://" + requestUri.Host + ":" + requestUri.Port
                          + HttpContext.Current.Request.ApplicationPath;

            var postManCollection = new PostmanCollectionGet
            {
                Id = Guid.NewGuid(),
                Name = "Brandscreen.WebApi",
                Description = "",
                Order = new Collection<Guid>(),
                Timestamp = DateTime.Now.Ticks,
                Folders = new Collection<PostmanFolderGet>(),
                Requests = new Collection<PostmanRequestGet>(),
                Synced = false
            };


            var helpPageSampleGenerator = Configuration.GetHelpPageSampleGenerator();

            var apiExplorer = Configuration.Services.GetApiExplorer();

            var apiDescriptionsByController = apiExplorer.ApiDescriptions.GroupBy(
                description =>
                    description.ActionDescriptor.ActionBinding.ActionDescriptor.ControllerDescriptor.ControllerType);

            foreach (var apiDescriptionsByControllerGroup in apiDescriptionsByController)
            {
                var controllerName = apiDescriptionsByControllerGroup.Key.Name.Replace("Controller", string.Empty);

                var postManFolder = new PostmanFolderGet
                {
                    Id = Guid.NewGuid(),
                    CollectionId = postManCollection.Id,
                    Collection = postManCollection.Id,
                    Name = controllerName,
                    Description = $"Api Methods for {controllerName}",
                    CollectionName = "Brandscreen.WebApi",
                    Order = new Collection<Guid>()
                };

                foreach (var apiDescription in apiDescriptionsByControllerGroup
                    .OrderBy(description => description.HttpMethod, new HttpMethodComparator())
                    .ThenBy(description => description.RelativePath)
                    .ThenBy(description => description.Documentation))
                {
                    TextSample sampleData = null;
                    var sampleDictionary = helpPageSampleGenerator.GetSample(apiDescription, SampleDirection.Request);
                    MediaTypeHeaderValue mediaTypeHeader;
                    if (MediaTypeHeaderValue.TryParse("application/json", out mediaTypeHeader)
                        && sampleDictionary.ContainsKey(mediaTypeHeader))
                    {
                        sampleData = sampleDictionary[mediaTypeHeader] as TextSample;
                    }

                    // scrub curly braces from url parameter values
                    var cleanedUrlParameterUrl = this._urlParameterVariableRegEx.Replace(apiDescription.RelativePath, "=$1-value");

                    // get pat variables from url
                    var pathVariables = this._pathVariableRegEx.Matches(cleanedUrlParameterUrl)
                        .Cast<Match>()
                        .Select(m => m.Value)
                        .Select(s => s.Substring(1, s.Length - 2))
                        .ToDictionary(s => s, s => $"{s}-value");

                    // change format of parameters within string to be colon prefixed rather than curly brace wrapped
                    var postmanReadyUrl = this._pathVariableRegEx.Replace(cleanedUrlParameterUrl, ":$1");

                    // prefix url with base uri
                    var url = baseUri.TrimEnd('/') + "/" + postmanReadyUrl;

                    var request = new PostmanRequestGet
                    {
                        CollectionId = postManCollection.Id,
                        Id = Guid.NewGuid(),
                        Name = apiDescription.RelativePath,
                        Description = apiDescription.Documentation,
                        Url = url,
                        Method = apiDescription.HttpMethod.Method,
                        Headers = "Content-Type: application/json",
                        Data = sampleData?.Text,
                        DataMode = "raw",
                        Time = postManCollection.Timestamp,
                        Synced = false,
                        DescriptionFormat = "markdown",
                        Version = "beta",
                        Responses = new Collection<string>(),
                        PathVariables = pathVariables,
                        Folder = postManFolder.Id
                    };

                    postManFolder.Order.Add(request.Id); // add to the folder
                    postManCollection.Requests.Add(request);
                }

                postManCollection.Folders.Add(postManFolder);
            }

            return postManCollection;
        }
    }

    /// <summary>
    ///     Quick comparer for ordering http methods for display
    /// </summary>
    internal class HttpMethodComparator : IComparer<HttpMethod>
    {
        private readonly string[] _order =
        {
            "GET",
            "POST",
            "PATCH",
            "PUT",
            "DELETE"
        };

        public int Compare(HttpMethod x, HttpMethod y)
        {
            return Array.IndexOf(_order, x.ToString()).CompareTo(Array.IndexOf(_order, y.ToString()));
        }
    }
}
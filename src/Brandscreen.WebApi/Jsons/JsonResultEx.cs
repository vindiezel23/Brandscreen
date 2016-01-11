using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Brandscreen.WebApi.Jsons
{
    public class JsonResultEx : JsonResult
    {
        public HttpStatusCode? StatusCode { get; private set; }

        public string StatusDescription { get; private set; }

        public IList<string> ErrorMessages { get; } = new List<string>();

        public static JsonResultEx Create(object obj = null, HttpStatusCode? statusCode = null, string statusDescription = null)
        {
            var retVal = new JsonResultEx
            {
                StatusCode = statusCode,
                StatusDescription = statusDescription
            };

            var modelStateDictionary = obj as ModelStateDictionary;
            if (modelStateDictionary != null && !modelStateDictionary.IsValid)
            {
                foreach (var modelError in modelStateDictionary.Values.SelectMany(modelState => modelState.Errors))
                {
                    retVal.AddError(modelError.ErrorMessage);
                }
            }

            var identityResult = obj as IdentityResult;
            if (identityResult != null && !identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    retVal.AddError(error);
                }
            }

            if (modelStateDictionary == null && identityResult == null)
            {
                retVal.Data = obj;
            }

            return retVal;
        }

        public static JsonResultEx Create(HttpStatusCode statusCode, string statusDescription = null)
        {
            return Create(null, statusCode, statusDescription);
        }

        public JsonResultEx AddError(string errorMessage)
        {
            ErrorMessages.Add(errorMessage);
            return this;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            // note: ignore request method checking
//            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
//            {
//                throw new InvalidOperationException("This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.");
//            }

            // content type and encoding
            var response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(ContentType) ? "application/json" : ContentType;
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            // skip iis custom error
            response.TrySkipIisCustomErrors = true;

            if (StatusCode.HasValue)
            {
                response.StatusCode = (int) StatusCode.Value;
            }

            if (!string.IsNullOrEmpty(StatusDescription))
            {
                response.StatusDescription = StatusDescription;
            }

            if (StatusCode.HasValue && !IsSuccessStatusCode)
            {
                ErrorMessages.Add(!string.IsNullOrEmpty(StatusDescription) ? StatusDescription : StatusCode.ToString());
            }

            // errors
            if (ErrorMessages.Any())
            {
                Data = new
                {
                    ErrorMessage = string.Join("\n", ErrorMessages),
                    ErrorMessages = ErrorMessages.ToArray()
                };
                if (!StatusCode.HasValue)
                {
                    response.StatusCode = (int) HttpStatusCode.BadRequest; // default status code for error
                }
            }

            if (Data != null)
            {
                response.Write(Data.ToJson());
            }
        }

        public bool IsSuccessStatusCode => StatusCode.HasValue && StatusCode.Value >= HttpStatusCode.OK && StatusCode.Value <= (HttpStatusCode) 299;
    }
}
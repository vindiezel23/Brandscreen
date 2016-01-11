using System.Net;
using System.Net.Http;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Newtonsoft.Json;

namespace Brandscreen.WebApi.Logging
{
    public class WebApiExceptionHandler : ExceptionHandler
    {
        public readonly string Message;

        public WebApiExceptionHandler()
        {
            Message = JsonConvert.SerializeObject(new {Message = "An internal exception occurred. We'll take care of it."});
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new ExceptionResponse
            {
                StatusCode = context.Exception is SecurityException ? HttpStatusCode.Unauthorized : HttpStatusCode.InternalServerError,
                Message = Message,
                Request = context.Request
            };
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
    }

    public class ExceptionResponse : IHttpActionResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public HttpRequestMessage Request { get; set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(StatusCode)
            {
                RequestMessage = Request,
                Content = new StringContent(Message)
            };
            return Task.FromResult(response);
        }
    }
}
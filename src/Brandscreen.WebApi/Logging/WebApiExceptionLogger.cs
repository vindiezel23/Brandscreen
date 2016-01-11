using System.Web.Http.ExceptionHandling;
using Castle.Core.Logging;

namespace Brandscreen.WebApi.Logging
{
    public class WebApiExceptionLogger : ExceptionLogger
    {
        public WebApiExceptionLogger()
        {
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public override void Log(ExceptionLoggerContext context)
        {
            Logger.ErrorFormat(context.Exception, "web api error at {0} {1}", context.Request.Method.Method, context.Request.RequestUri.ToString());
        }
    }
}
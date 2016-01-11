using System;
using Castle.Core.Logging;

namespace Brandscreen.Framework.Exceptions
{
    public class DefaultExceptionPolicy : IExceptionPolicy
    {
        public DefaultExceptionPolicy()
        {
            Logger = NullLogger.Instance;
        }

        public bool HandleException(object sender, Exception exception)
        {
            Logger.Error("An unexpected exception was caught", exception);
            return true;
        }

        public ILogger Logger { get; set; }
    }
}
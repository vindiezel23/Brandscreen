using System;
using Autofac;
using Brandscreen.Framework.Environment;
using Brandscreen.Framework.Services;
using Castle.Core.Logging;

namespace Brandscreen.WebApi.Handlers
{
    public class HostEventsHandler : IHostEvents
    {
        private readonly IClock _clock;
        private int _startTickCount;

        public HostEventsHandler(IClock clock)
        {
            _clock = clock;
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public void Activated(ILifetimeScope container)
        {
            _startTickCount = Environment.TickCount;
            Logger.InfoFormat("Server started at local time {0}", _clock.UtcNow.ToLocalTime());
        }

        public void Terminating()
        {
            Logger.InfoFormat("Server ran for {0} ms", Environment.TickCount - _startTickCount);
            Logger.InfoFormat("Server stopped at local time {0}", _clock.UtcNow.ToLocalTime());
        }
    }
}
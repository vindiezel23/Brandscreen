using Castle.Core.Logging;

namespace Brandscreen.WebApi.Logging
{
    public class CastleToOwinFactoryAdapter : Microsoft.Owin.Logging.ILoggerFactory
    {
        private readonly ILoggerFactory _castleLoggerFactory;

        public CastleToOwinFactoryAdapter(ILoggerFactory castleLoggerFactory)
        {
            _castleLoggerFactory = castleLoggerFactory;
        }

        public Microsoft.Owin.Logging.ILogger Create(string name)
        {
            return new CastleToOwinLoggerAdapter(_castleLoggerFactory.Create(name));
        }
    }
}
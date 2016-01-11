using Autofac;
using Brandscreen.Framework.Events;

namespace Brandscreen.Framework.Environment
{
    public interface IHostEvents : IEventHandler
    {
        void Activated(ILifetimeScope container);
        void Terminating();
    }
}
using System.Collections;
using System.Collections.Generic;

namespace Brandscreen.Framework.Events
{
    public interface IEventBus : IDependency
    {
        IEnumerable Notify(string messageName, IDictionary<string, object> eventData);
    }
}
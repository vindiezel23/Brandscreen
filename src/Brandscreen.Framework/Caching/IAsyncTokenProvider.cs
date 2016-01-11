using System;

namespace Brandscreen.Framework.Caching {
    public interface IAsyncTokenProvider {
        IVolatileToken GetToken(Action<Action<IVolatileToken>> task);
    }
}
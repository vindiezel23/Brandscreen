using System;

namespace Brandscreen.Framework.Caching {
    public interface ICacheHolder : ISingletonDependency {
        ICache<TKey, TResult> GetCache<TKey, TResult>(Type component);
    }
}

namespace Brandscreen.Framework.Caching {
    public interface ICacheContextAccessor {
        IAcquireContext Current { get; set; }
    }
}
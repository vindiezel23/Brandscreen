using System.Collections.Generic;

namespace Brandscreen.Core.DbAsyncWrapper
{
    public static class DbAsyncExtensions
    {
        /// <summary>
        /// Provides a wrapper on top of enumerable to support entity framework async operations
        /// </summary>
        public static DbAsyncEnumerable<T> ToAsyncEnumerable<T>(this IEnumerable<T> enumerable)
        {
            return new DbAsyncEnumerable<T>(enumerable);
        }
    }
}
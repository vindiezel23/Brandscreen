using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Brandscreen.Core.DbAsyncWrapper
{
    public class DbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T>
    {
        public DbAsyncEnumerable(IEnumerable<T> enumerable) : base(enumerable)
        {
        }

        public DbAsyncEnumerable(Expression expression) : base(expression)
        {
        }

        public IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new DbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }

        IQueryProvider IQueryable.Provider => new DbAsyncQueryProvider<T>(this);
    }
}
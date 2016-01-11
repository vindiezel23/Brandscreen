using System.Linq;
using System.Threading.Tasks;
using PagedList;

namespace Brandscreen.WebApi.Paginations
{
    public static class PaginationExtensions
    {
        public static Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> superset, Pagination pagination)
        {
            pagination = pagination ?? new Pagination();
            return PagedList.EntityFramework.PagedList<T>.Create(superset, pagination.PageNumber, pagination.PageSize);
        }

        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> superset, Pagination pagination)
        {
            pagination = pagination ?? new Pagination();
            return superset.ToPagedList(pagination.PageNumber, pagination.PageSize);
        }
    }
}
using System.Collections.Generic;
using PagedList;

namespace Brandscreen.WebApi.Paginations
{
    public class PagedListViewModel<T> : PagedListMetaData
    {
        public PagedListViewModel(IPagedList pagedList) : base(pagedList)
        {
            // this constructor is used by PagedListMapper
        }

        public IEnumerable<T> Data { get; set; }
    }
}
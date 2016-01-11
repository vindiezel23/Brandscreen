namespace Brandscreen.WebApi.Paginations
{
    public interface IPagination
    {
        int PageNumber { get; }
        int PageSize { get; }
    }

    public class Pagination : IPagination
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public class Twenty : Pagination
        {
            public Twenty()
            {
                PageSize = 20;
            }
        }
    }
}
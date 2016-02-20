namespace OS.Business.Domain
{
    public class PaginationFilter
    {
        public PaginationFilter()
        {
            PageSize = int.MaxValue;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
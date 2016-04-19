namespace OS.Web.Models
{
    public class PaginationFilterViewModel
    {
        public PaginationFilterViewModel()
        {
            PageNumber = 0;
            PageSize = int.MaxValue;
        }

        public int PageNumber { get; set; } 
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}
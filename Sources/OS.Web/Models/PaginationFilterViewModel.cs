namespace OS.Web.Models
{
    public class PaginationFilterViewModel
    {
        public PaginationFilterViewModel()
        {
            PageNumber = 0;
            PageSize = 20;
        }

        public int PageNumber { get; set; } 
        public int PageSize { get; set; }
    }
}
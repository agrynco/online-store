using System;

namespace OS.Web.Models
{
    public class PaginationFilterViewModel
    {
        public PaginationFilterViewModel()
        {
            PageNumber = 1;
            PageSize = int.MaxValue;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

        public int GetPagesCount()
        {
            return (int) Math.Ceiling((double) TotalRecords / PageSize);
        }
    }
}
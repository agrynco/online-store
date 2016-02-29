namespace OS.Business.Domain
{
    public class BrandsFilter
    {
        public BrandsFilter()
        {
            PaginationFilter = new PaginationFilter();
        }

        public string SearchTerm { get; set; }

        public PaginationFilter PaginationFilter { get; private set; }
    }
}
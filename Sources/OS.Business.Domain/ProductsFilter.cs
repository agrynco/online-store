namespace OS.Business.Domain
{
    public class ProductsFilter
    {
        public ProductsFilter()
        {
            PaginationFilter = new PaginationFilter();
            IsDeleted = false;
        }

        public int? ParentId { get; set; }
        public string Text { get; set; }

        public PaginationFilter PaginationFilter { get; private set; }

        public bool? Publish { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
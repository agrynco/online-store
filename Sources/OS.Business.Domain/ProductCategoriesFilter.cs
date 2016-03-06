namespace OS.Business.Domain
{
    public class ProductCategoriesFilter
    {
        public ProductCategoriesFilter()
        {
            PaginationFilter = new PaginationFilter();
        }

        public string Text { get; set; }
        public int? ParentId { get; set; }
        public bool IgnoreParentId { get; set; }
        public bool IncludeDeleted { get; set; }
        public PaginationFilter PaginationFilter { get; private set; }
    }
}
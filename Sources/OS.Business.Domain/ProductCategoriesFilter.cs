namespace OS.Business.Domain
{
    public class ProductCategoriesFilter
    {
        public ProductCategoriesFilter(int pageSize) : this()
        {
            PaginationFilter.PageSize = pageSize;
        }

        public ProductCategoriesFilter()
        {
            PaginationFilter = new PaginationFilter();
        }

        public bool IgnoreParentId { get; set; }
        public bool IncludeDeleted { get; set; }
        public PaginationFilter PaginationFilter { get; }
        public int? ParentId { get; set; }
        public bool? Publish { get; set; }

        public string Text { get; set; }
    }
}
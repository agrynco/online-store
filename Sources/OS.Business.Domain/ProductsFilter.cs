using System.Data;

namespace OS.Business.Domain
{
    public class ProductsFilter
    {
        public ProductsFilter()
        {
            PaginationFilter = new PaginationFilter();
        }

        public int? ParentId { get; set; }
        public string Text { get; set; }

        public PaginationFilter PaginationFilter { get; private set; }
    }
}
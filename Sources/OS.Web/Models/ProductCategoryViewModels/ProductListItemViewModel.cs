using OS.Business.Domain;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductListItemViewModel
    {
        public Product Product { get; set; }
        public int? ParentCategoryId { get; set; } 
    }
}
using System.Collections.Generic;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductCategoriesViewModel
    {
        public List<ProductCategoriesBreadCrumbItem> BreadCrumbItems { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
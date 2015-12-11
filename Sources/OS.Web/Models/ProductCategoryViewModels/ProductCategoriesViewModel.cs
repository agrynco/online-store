using System.Collections.Generic;
using OS.Business.Domain;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductCategoriesViewModel
    {
        public List<ProductCategory> ProductCategories { get; set; }

        public List<ProductListItemViewModel> ProductsFromLevelUpProductCategory { get; set; } 

        public ProductCategory LevelUpProductCategory { get; set; }
    }
}
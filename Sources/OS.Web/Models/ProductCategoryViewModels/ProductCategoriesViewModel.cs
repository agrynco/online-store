using System.Collections.Generic;
using OS.Business.Domain;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductCategoryListItemViewModel
    {
        public ProductCategory ProductCategory { get; set; }
    }

    public class ProductCategoriesViewModel
    {
        public ProductCategoriesViewModel()
        {
            Filter = new ProductCategoriesFilterViewModel();
            PathToRoot = new List<ProductCategoryListItemViewModel>();
        }

        public ProductCategoriesFilterViewModel Filter { get; set; }

        public List<ProductCategoryListItemViewModel> Categories { get; set; }

        public List<ProductCategoryListItemViewModel> PathToRoot { get; set; } 
    }
}
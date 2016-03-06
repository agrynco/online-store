using System.Collections.Generic;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductCategoriesApiViewModel
    {
        public ProductCategoriesApiViewModel()
        {
            PathToRoot = new List<ProductCategoryListItemViewModel>();
            data = new List<ProductCategoryListItemViewModel>();
        }

        public List<ProductCategoryListItemViewModel> data { get; set; }

        public List<ProductCategoryListItemViewModel> PathToRoot { get; set; }
    }
}
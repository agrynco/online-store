using System.Collections.Generic;

namespace OS.Web.Models.ProductCategoryViewModels
{
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
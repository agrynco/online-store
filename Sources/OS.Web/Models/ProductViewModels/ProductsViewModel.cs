using System.Collections.Generic;

namespace OS.Web.Models.ProductViewModels
{
    public class ProductsViewModel
    {
        public ProductsViewModel()
        {
            Filter = new ProductsFilterViewModel();
        }

        public ProductsFilterViewModel Filter { get; set; }

        public List<ProductListItemViewModel> Products { get; set; }  
    }
}
using OS.Web.Models.ProductCategoryViewModels;

namespace OS.Web.Models.ProductViewModels
{
    public class ProductsFilterViewModel : PaginationFilterViewModel
    {
        public ProductsFilterViewModel()
        {
            Category = new AutoCompleteProductCategoryFilterItemViewModel();
        }

        public AutoCompleteProductCategoryFilterItemViewModel Category { get; set; } 
    }
}
using OS.Web.Models.ProductCategoryViewModels;

namespace OS.Web.Models.ProductViewModels
{
    public class ProductsFilterViewModel : PaginationFilterViewModel
    {
        public ProductsFilterViewModel(int categoryId) : this()
        {
            Category.Id = categoryId;
        }

        public ProductsFilterViewModel()
        {
            Category = new AutoCompleteProductCategoryFilterItemViewModel();
        }

        public AutoCompleteProductCategoryFilterItemViewModel Category { get; set; } 
    }
}
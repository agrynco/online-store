using System.ComponentModel.DataAnnotations;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductCategoriesFilterViewModel : PaginationFilterViewModel
    {
        public ProductCategoriesFilterViewModel()
        {
            ParentCategory = new AutoCompleteProductCategoryFilterItemViewModel();
        }

        [Display(Name = "Назва")]
        public string Name { get; set; }

        public AutoCompleteProductCategoryFilterItemViewModel ParentCategory { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductCategoriesFilterViewModel
    {
        public ProductCategoriesFilterViewModel()
        {
            PaginationFilter = new PaginationFilterViewModel();
        }

        public PaginationFilterViewModel PaginationFilter { get; set; }

        [Display(Name = "Назва")]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        [Display(Name = "Батьківська категорія")]
        public string ParentCategoryName { get; set; }
    }
}
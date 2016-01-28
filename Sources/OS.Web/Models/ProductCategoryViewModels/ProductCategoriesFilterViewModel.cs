using System.ComponentModel.DataAnnotations;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductCategoriesFilterViewModel : PaginationFilterViewModel
    {
        [Display(Name = "Назва")]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        [Display(Name = "Батьківська категорія")]
        public string ParentCategoryName { get; set; }
    }
}
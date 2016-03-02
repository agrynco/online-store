using System.ComponentModel.DataAnnotations;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductCategoryAutocompleteItem
    {
        public int? Id { get; set; }

        [Display(Name = "Категорія")]
        [Required(ErrorMessage = "Поле {0} обов'язкове")]
        public string Name { get; set; }
        public string[] ParentCategories { get; set; }
    }
}
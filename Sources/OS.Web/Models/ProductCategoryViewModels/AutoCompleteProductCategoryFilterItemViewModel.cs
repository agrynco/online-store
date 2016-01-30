using System.ComponentModel.DataAnnotations;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class AutoCompleteProductCategoryFilterItemViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Категорія")]
        public string Name { get; set; }
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductCategoryCreateOrEditViewModel : BaseCreateOrEditViewModel
    {
        [Required(ErrorMessage = "Поле Назва обов'язкове")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
    }
}
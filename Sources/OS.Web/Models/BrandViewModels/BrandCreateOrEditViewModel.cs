using System.ComponentModel.DataAnnotations;

namespace OS.Web.Models.BrandViewModels
{
    public class BrandCreateOrEditViewModel : BaseCreateOrEditViewModel
    {
        [Display(Name = "Назва")]
        [Required(ErrorMessage = "Поле {0} обов'язкове")]
        public string Name { get; set; }
    }
}
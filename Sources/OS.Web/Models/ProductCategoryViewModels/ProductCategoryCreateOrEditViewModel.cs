using System.ComponentModel.DataAnnotations;
using System.Web;
using OS.Business.Domain;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductCategoryCreateOrEditViewModel : BaseCreateOrEditViewModel
    {
        [Required(ErrorMessage = "Поле Назва обов'язкове")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }

        [Display(Name = "Публікувати")]
        public bool Publish { get; set; }

        public Photo Photo { get; set; }

        public HttpPostedFileBase PostedPhoto { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductCategoryCreateOrEditViewModel : BaseCreateOrEditVireModel
    {
        [Required]
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductCategorySelectorViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }
        public string[] ParentCategories { get; set; }
    }
}
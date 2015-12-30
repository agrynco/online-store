using OS.Business.Domain;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class LevelUpProductCategoryViewModel
    {
        public int Id { get; set; } 
        public ProductCategory[] ParentCategories { get; set; }
    }
}
using OS.Business.Domain;

namespace OS.Web.Models
{
    public class HorizontalCategoryItemViewModel
    {
        public ProductCategory ProductCategory { get; set; } 
        public bool IsSelected { get; set; }
    }
}
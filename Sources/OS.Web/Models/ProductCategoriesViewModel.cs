using System.Collections.Generic;
using OS.Business.Domain;

namespace OS.Web.Models
{
    public class ProductCategoriesViewModel
    {
        public List<ProductCategory> ProductCategories { get; set; }

        public ProductCategory LevelUpProductCategory { get; set; }
    }
}
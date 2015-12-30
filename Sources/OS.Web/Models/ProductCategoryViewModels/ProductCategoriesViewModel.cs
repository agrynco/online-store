using System.Collections.Generic;
using OS.Business.Domain;

namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductCategoriesViewModel
    {
        public ProductCategoriesViewModel()
        {
            LevelUpCategories = new List<ProductCategory>();
        }

        public IList<ProductCategory> ProductCategories { get; set; }

        public IList<ProductListItemViewModel> ProductsFromLevelUpProductCategory { get; set; } 

        public ProductCategoriesFilterViewModel Filter { get; set; }

        /// <summary>
        /// This is the <see cref="ProductCategory.Id"/> of the parent category for the <see cref="ProductCategoriesFilterViewModel.ParentId"/>
        /// to make a user able to return to the upper category
        /// </summary>
        public int? LevelUpProductCategoryId { get; set; }

        public IList<ProductCategory> LevelUpCategories { get; set; }
    }
}
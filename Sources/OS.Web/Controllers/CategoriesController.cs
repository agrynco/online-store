using System.Collections.Generic;
using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;

namespace OS.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ProductCategoriesBL _productCategoriesBL;

        public CategoriesController(ProductCategoriesBL productCategoriesBL)
        {
            _productCategoriesBL = productCategoriesBL;
        }

        [ChildActionOnly]
        public ActionResult VerticalCategorySelector()
        {
            PagedProductCategoryListResult rootCategories = _productCategoriesBL.SearchByFilter(new ProductCategoriesFilter
                {
                    ParentId = null,
                    IgnoreParentId = false,
                    IncludeDeleted = false
                });

            VerticalCategorySelectorViewModel model = new VerticalCategorySelectorViewModel();
            model.Categories = new List<VerticalCategorySelectorItemViewModel>();

            foreach (ProductCategory productCategory in rootCategories.Entities)
            {
                VerticalCategorySelectorItemViewModel verticalCategorySelectorItemViewModel = new VerticalCategorySelectorItemViewModel
                    {
                        Id = productCategory.Id,
                        Name = productCategory.Name,
                        ProductsCount = productCategory.Products.Count
                    };
                model.Categories.Add(verticalCategorySelectorItemViewModel);

                AddChildCategories(verticalCategorySelectorItemViewModel.ChildCategories, productCategory);
            }

            return PartialView("_verticalCategorySelector", model);
        }

        private void AddChildCategories(List<VerticalCategorySelectorItemViewModel> verticalCategorySelectorItemViewModels, ProductCategory parentCategory)
        {
            PagedProductCategoryListResult childCategories = _productCategoriesBL.SearchByFilter(new ProductCategoriesFilter
                {
                    ParentId = parentCategory.Id,
                    IgnoreParentId = false,
                    IncludeDeleted = false
                });
                
            foreach (ProductCategory productCategory in childCategories.Entities)
            {
                VerticalCategorySelectorItemViewModel verticalCategorySelectorItemViewModel = new VerticalCategorySelectorItemViewModel
                {
                    Id = productCategory.Id,
                    Name = productCategory.Name,
                    ProductsCount = productCategory.Products.Count
                };
                verticalCategorySelectorItemViewModels.Add(verticalCategorySelectorItemViewModel);

                AddChildCategories(verticalCategorySelectorItemViewModel.ChildCategories, productCategory);
            }
        }
    }
}
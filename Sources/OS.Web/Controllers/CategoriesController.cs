using System.Collections.Generic;
using System.Linq;
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
            int? categoryId = null;
            if (TempData["CategoryId"] != null)
            {
                categoryId = (int) TempData["CategoryId"];
            }

            PagedProductCategoryListResult rootCategories = _productCategoriesBL.SearchByFilter(new ProductCategoriesFilter
                {
                    ParentId = null,
                    IgnoreParentId = false,
                    IncludeDeleted = false,
                    Publish = true
                });

            VerticalCategorySelectorViewModel model = new VerticalCategorySelectorViewModel();
            model.Categories = new List<VerticalCategorySelectorItemViewModel>();

            foreach (ProductCategory productCategory in rootCategories.Entities)
            {
                VerticalCategorySelectorItemViewModel verticalCategorySelectorItemViewModel = new VerticalCategorySelectorItemViewModel
                    {
                        Id = productCategory.Id,
                        Name = productCategory.Name,
                        Selected = productCategory.Id == categoryId
                    };
                model.Categories.Add(verticalCategorySelectorItemViewModel);

                AddChildCategories(verticalCategorySelectorItemViewModel.ChildCategories, productCategory, categoryId);
            }

            return PartialView("_verticalCategorySelector", model);
        }

        private void AddChildCategories(List<VerticalCategorySelectorItemViewModel> verticalCategorySelectorItemViewModels,
            ProductCategory parentCategory, int? categoryId)
        {
            PagedProductCategoryListResult childCategories = _productCategoriesBL.SearchByFilter(new ProductCategoriesFilter
                {
                    ParentId = parentCategory.Id,
                    IgnoreParentId = false,
                    IncludeDeleted = false,
                    Publish = true
                });

            foreach (ProductCategory productCategory in childCategories.Entities)
            {
                VerticalCategorySelectorItemViewModel verticalCategorySelectorItemViewModel = new VerticalCategorySelectorItemViewModel
                    {
                        Id = productCategory.Id,
                        Name = productCategory.Name,
                        Selected = productCategory.Id == categoryId
                    };
                verticalCategorySelectorItemViewModels.Add(verticalCategorySelectorItemViewModel);

                AddChildCategories(verticalCategorySelectorItemViewModel.ChildCategories, productCategory, categoryId);
            }
        }
    }
}
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
            List<ProductCategory> rootCategories = _productCategoriesBL.GetCategories(null);

            VerticalCategorySelectorViewModel model = new VerticalCategorySelectorViewModel();
            model.Categories = new List<VerticalCategorySelectorItemViewModel>();

            foreach (ProductCategory productCategory in rootCategories)
            {
                VerticalCategorySelectorItemViewModel verticalCategorySelectorItemViewModel = new VerticalCategorySelectorItemViewModel
                    {
                        Id = productCategory.Id,
                        Name = productCategory.Name
                    };
                model.Categories.Add(verticalCategorySelectorItemViewModel);

                AddChildCategories(verticalCategorySelectorItemViewModel.ChildCategories, productCategory);
            }

            return PartialView("_verticalCategorySelector", model);
        }

        private void AddChildCategories(List<VerticalCategorySelectorItemViewModel> verticalCategorySelectorItemViewModels, ProductCategory parentCategory)
        {

            foreach (ProductCategory productCategory in parentCategory.ChildCategories)
            {
                VerticalCategorySelectorItemViewModel verticalCategorySelectorItemViewModel = new VerticalCategorySelectorItemViewModel
                {
                    Id = productCategory.Id,
                    Name = productCategory.Name
                };
                verticalCategorySelectorItemViewModels.Add(verticalCategorySelectorItemViewModel);

                AddChildCategories(verticalCategorySelectorItemViewModel.ChildCategories, productCategory);
            }
        }
    }
}
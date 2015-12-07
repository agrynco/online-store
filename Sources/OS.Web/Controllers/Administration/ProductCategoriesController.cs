#region Usings
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Web.Models.ProductCategoryViewModels;
using OS.Web.Models.ProductViewModels;
#endregion

namespace OS.Web.Controllers.Administration
{
    public class ProductCategoriesController : BaseAdminController
    {
        private readonly ProductCategoriesBL _productCategoriesBL;

        public ProductCategoriesController(ProductCategoriesBL productCategoriesBL)
        {
            _productCategoriesBL = productCategoriesBL;
        }

        public ActionResult Index(int? parentId)
        {
            ProductCategoriesViewModel viewModel = new ProductCategoriesViewModel
                {
                    ProductCategories = _productCategoriesBL.GetCategories(parentId),
                    ProductsFromLevelUpProductCategory = parentId.HasValue ? _productCategoriesBL.GetProducts(parentId.Value) : new List<Product>()
                };

            if (parentId != null)
            {
                viewModel.LevelUpProductCategory = _productCategoriesBL.GetCategory(parentId.Value);
            }

            return View(viewModel);
        }

        public ActionResult Delete(int categoryId)
        {
            _productCategoriesBL.Delete(categoryId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create(int? parentId)
        {
            ProductCategoryCreateOrEditViewModel model = new ProductCategoryCreateOrEditViewModel();
            model.ParentId = parentId;
            return View("Edit", model);
        }

        public ActionResult Edit(int categoryId)
        {
            ProductCategory productCategory = _productCategoriesBL.GetCategory(categoryId);

            ProductCategoryCreateOrEditViewModel model = new ProductCategoryCreateOrEditViewModel
                {
                    Name = productCategory.Name,
                    ParentId = productCategory.ParentId,
                    Id = productCategory.Id
                };

            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Save(ProductCategoryCreateOrEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!model.Id.HasValue && _productCategoriesBL.GetCategories(model.ParentId).Any(productCategory => productCategory.Name == model.Name))
                {
                    ModelState.AddModelError("Name", "Така категорія вже існує");
                }

                if (ModelState.IsValid)
                {
                    ProductCategory productCategory;

                    if (model.Id.HasValue)
                    {
                        productCategory = _productCategoriesBL.GetCategory(model.Id.Value);
                        productCategory.Name = model.Name;

                        _productCategoriesBL.Update(productCategory);
                    }
                    else
                    {
                        productCategory = new ProductCategory
                            {
                                ParentId = model.ParentId,
                                Name = model.Name
                            };
                        _productCategoriesBL.Create(productCategory);
                    }

                    return RedirectToAction("Index", new
                        {
                            parentId = model.ParentId
                        });
                }
            }

            return View("Edit", model);
        }

        [HttpGet]
        public ActionResult CreateProduct(int categoryId)
        {
            ProductCreateOrEditViewModel model = new ProductCreateOrEditViewModel();

            return View("ProductEdit", model);
        }
    }
}
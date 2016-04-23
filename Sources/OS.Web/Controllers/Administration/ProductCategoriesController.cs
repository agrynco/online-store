using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using MvcSiteMapProvider.Web.Mvc.Filters;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Web.Models.ProductCategoryViewModels;

namespace OS.Web.Controllers.Administration
{
    public class ProductCategoriesController : BaseAdminController
    {
        private readonly ProductCategoriesBL _productCategoriesBL;

        public ProductCategoriesController(ProductCategoriesBL productCategoriesBL)
        {
            _productCategoriesBL = productCategoriesBL;
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Index([FromUri] int? parentId)
        {
            object parentCategoryIdObject = TempData[Constants.TempDataKeys.PRODUCT_CATEGORIES_PARENT_ID];

            int? parentCategoryId = (int?) parentCategoryIdObject ?? parentId;


            List<ProductCategory> parentCategories = new List<ProductCategory>();
            if (parentCategoryId.HasValue)
            {
                parentCategories.AddRange(_productCategoriesBL.GetParentCategories(parentCategoryId.Value));
                parentCategories.Add(_productCategoriesBL.GetById(parentCategoryId.Value));
            }

            List<ProductCategoriesBreadCrumbItem> breadCrumbs = new List<ProductCategoriesBreadCrumbItem>(
                parentCategories.Select(x => new ProductCategoriesBreadCrumbItem
                    {
                        Id = x.Id,
                        Name = x.Name
                    }));

            ProductCategoriesBreadCrumbItem rootCategoriesBreadCrumbItem = new ProductCategoriesBreadCrumbItem
                {
                    Id = null,
                    Name = ".."
                };
            breadCrumbs.Insert(0, rootCategoriesBreadCrumbItem);

            ProductCategoriesViewModel model = new ProductCategoriesViewModel
                {
                    BreadCrumbItems = breadCrumbs,
                    ParentCategoryId = parentCategoryId
                };

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ProductCategory productCategory = _productCategoriesBL.GetById(id);
            return View(new ProductCategoryCreateOrEditViewModel
                {
                    ParentId = productCategory.ParentId,
                    Id = productCategory.Id,
                    Name = productCategory.Name,
                    Description = productCategory.Description,
                    Publish = productCategory.Publish
                });
        }

        [System.Web.Mvc.HttpPost]
        [SiteMapCacheRelease]
        public ActionResult Save(ProductCategoryCreateOrEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_productCategoriesBL.GetCategories(model.ParentId).Any(productCategory => productCategory.Name == model.Name && productCategory.Id != model.Id))
                {
                    ModelState.AddModelError("Name", "Така категорія вже існує");
                }

                if (ModelState.IsValid)
                {
                    ProductCategory productCategory;

                    if (model.Id.HasValue)
                    {
                        productCategory = _productCategoriesBL.GetById(model.Id.Value);
                        productCategory.Name = model.Name;
                        productCategory.Description = model.Description;

                        _productCategoriesBL.Update(productCategory);
                        if (productCategory.Publish != model.Publish)
                        {
                            _productCategoriesBL.SetPublish(productCategory.Id, model.Publish);
                        }
                    }
                    else
                    {
                        productCategory = new ProductCategory
                            {
                                ParentId = model.ParentId,
                                Name = model.Name,
                                Description = model.Description,
                                Publish = model.Publish
                            };
                        _productCategoriesBL.Create(productCategory);
                    }

                    ProductCategoriesFilterViewModel filterViewModel = new ProductCategoriesFilterViewModel();
                    filterViewModel.ParentCategory.Id = model.ParentId;

                    if (model.ParentId.HasValue)
                    {
                        filterViewModel.ParentCategory.Name = _productCategoriesBL.GetById(model.ParentId.Value).Name;
                    }

                    TempData[Constants.TempDataKeys.PRODUCT_CATEGORIES_PARENT_ID] = model.ParentId;
                    return RedirectToAction("Index");
                }
            }

            return View("Edit", model);
        }

        [SiteMapCacheRelease]
        public ActionResult Create(int? parentCategoryId)
        {
            return View("Edit", new ProductCategoryCreateOrEditViewModel
                {
                    ParentId = parentCategoryId
                });
        }
    }
}
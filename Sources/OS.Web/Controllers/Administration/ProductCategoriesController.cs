using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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


        public ActionResult Index(ProductCategoriesFilterViewModel filter)
        {
            if (TempData[Constants.TempDataKeys.PRODUCT_CATEGORIES_FILTER_VIEW_MODEL] != null)
            {
                filter = (ProductCategoriesFilterViewModel)TempData[Constants.TempDataKeys.PRODUCT_CATEGORIES_FILTER_VIEW_MODEL];
            }

            ProductCategoriesViewModel model = new ProductCategoriesViewModel
                {
                    Filter = filter
                };

            if (ModelState.IsValid)
            {
                if (filter.ParentId.HasValue)
                {
                    ModelState.RemoveStateFor(filter, viewModel => filter.ParentCategoryName);
                    model.Filter.ParentCategoryName = _productCategoriesBL.GetById(filter.ParentId.Value).Name;
                    List<ProductCategory> parentCategories = _productCategoriesBL.GetParentCategories(filter.ParentId.Value);
                    parentCategories.ForEach(category => model.PathToRoot.Insert(0, new ProductCategoryListItemViewModel
                        {
                            ProductCategory = category
                        }));
                }

                ProductCategoriesFilter productCategoriesFilter = new ProductCategoriesFilter
                    {
                        IgnoreParentId = false,
                        ParentId = filter.ParentId,
                        Text = filter.Name
                    };
                productCategoriesFilter.PaginationFilter.PageNumber = filter.PageNumber;
                productCategoriesFilter.PaginationFilter.PageSize = filter.PageSize;

                PagedProductCategoryListResult pagedProductCategoryListResult = _productCategoriesBL.SearchByFilter(productCategoriesFilter);

                model.Categories = pagedProductCategoryListResult.Entities.Select(entity => new ProductCategoryListItemViewModel
                    {
                        ProductCategory = entity
                    }).ToList();

                return View(model);
            }

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
                    Description = productCategory.Description
                });
        }

        [HttpPost]
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
                    }
                    else
                    {
                        productCategory = new ProductCategory
                            {
                                ParentId = model.ParentId,
                                Name = model.Name,
                                Description = model.Description
                            };
                        _productCategoriesBL.Create(productCategory);
                    }

                    ProductCategoriesFilterViewModel filterViewModel = new ProductCategoriesFilterViewModel();
                    filterViewModel.ParentId = model.ParentId;
                    TempData[Constants.TempDataKeys.PRODUCT_CATEGORIES_FILTER_VIEW_MODEL] = filterViewModel;
                    return RedirectToAction("Index", filterViewModel);
                }
            }

            return View("Edit", model);
        }

        public ActionResult Delete(int id)
        {
            int? parentId = _productCategoriesBL.GetParentId(id);
            _productCategoriesBL.Delete(id);

            ProductCategoriesFilterViewModel filterViewModel = new ProductCategoriesFilterViewModel();
            filterViewModel.ParentId = parentId;
            TempData[Constants.TempDataKeys.PRODUCT_CATEGORIES_FILTER_VIEW_MODEL] = filterViewModel;
            return RedirectToAction("Index", filterViewModel);
        }

        public ActionResult Create(int? parentcategoryid)
        {
            return View("Edit", new ProductCategoryCreateOrEditViewModel
                {
                    ParentId = parentcategoryid
                });
        }
    }
}
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
                productCategoriesFilter.PaginationFilter.PageNumber = filter.PaginationFilter.PageNumber;
                productCategoriesFilter.PaginationFilter.PageSize = filter.PaginationFilter.PageSize;

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
            throw new System.NotImplementedException();
        }

        public ActionResult Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
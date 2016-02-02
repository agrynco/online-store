using System.Linq;
using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Web.Models.ProductViewModels;

namespace OS.Web.Controllers.Administration
{
    public class ProductsController : BaseAdminController
    {
        private readonly ProductCategoriesBL _productCategoriesBL;
        private readonly ProductsBL _productsBL;

        public ProductsController(ProductCategoriesBL productCategoriesBL,
            ProductsBL productsBL)
        {
            _productCategoriesBL = productCategoriesBL;
            _productsBL = productsBL;
        }

        public ActionResult Index(ProductsFilterViewModel filter)
        {
            if (TempData[Constants.TempDataKeys.PRODUCTS_FILTER_VIEW_MODEL] != null)
            {
                filter = (ProductsFilterViewModel) TempData[Constants.TempDataKeys.PRODUCTS_FILTER_VIEW_MODEL];
            }

            ProductsViewModel model = new ProductsViewModel
                {
                    Filter = filter
                };

            if (ModelState.IsValid)
            {
                ModelState.RemoveStateFor(filter, viewModel => filter.Category.Name);
                if (filter.Category.Id.HasValue)
                {
                    filter.Category.Name = _productCategoriesBL.GetById(filter.Category.Id.Value).Name;
                }

                ProductsFilter productsFilter = new ProductsFilter
                    {
                        ParentId = filter.Category.Id
                    };
                productsFilter.PaginationFilter.PageNumber = filter.PageNumber;
                productsFilter.PaginationFilter.PageSize = filter.PageSize;

                PagedProductListResult pagedProductListResult = _productsBL.Search(productsFilter);

                model.Products = pagedProductListResult.Entities.Select(entity => new ProductListItemViewModel
                    {
                        Product = entity,
                        CategoryId = filter.Category.Id
                    }).ToList();
            }

            return View(model);
        }

        public ActionResult Delete(int id, int? categoryid)
        {
            _productsBL.Delete(id);

            ProductsFilterViewModel filterViewModel = new ProductsFilterViewModel();
            filterViewModel.Category.Id = categoryid;
            TempData[Constants.TempDataKeys.PRODUCTS_FILTER_VIEW_MODEL] = filterViewModel;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id, int? categoryId)
        {
            Product product = _productsBL.GetById(id);

            ProductCreateOrEditViewModel model = new ProductCreateOrEditViewModel
                {
                    Name = product.Name,
                    Description = product.Description,
                    Product = product,
                    Id = product.Id,
                    BrandName = product.Brand.Name,
                    CountryName = product.CountryProducer.Name,
                    OwnerCategoryId = categoryId
                };

            return View(model);
        }
    }
}
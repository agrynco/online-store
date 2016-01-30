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
                        Product = entity
                    }).ToList();
            }

            return View(model);
        }
    }
}
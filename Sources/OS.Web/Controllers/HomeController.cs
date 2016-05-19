using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Configuration;
using OS.Web.Models;
using OS.Web.Models.ProductViewModels;

namespace OS.Web.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        private readonly ProductCategoriesBL _productCategoriesBL;
        private readonly ProductsBL _productsBL;

        public HomeController(ProductCategoriesBL productCategoriesBL, ProductsBL productsBL)
        {
            _productCategoriesBL = productCategoriesBL;
            _productsBL = productsBL;
        }

        public ActionResult Index(string searchTerm, int? parentCategoryId, int? pageNumber)
        {
            HomePageViewModel viewModel = BuildHomePageViewModel(searchTerm, parentCategoryId, pageNumber);

            return View(viewModel);
        }

        private HomePageViewModel BuildHomePageViewModel(string searchTerm, int? parentCategoryId, int? pageNumber)
        {
            HomePageViewModel viewModel = new HomePageViewModel();
            viewModel.RootCategories = _productCategoriesBL.GetCategories(null).Select(productCategory => new HorizontalCategoryItemViewModel
                {
                    ProductCategory = productCategory,
                    IsSelected = false
                }).ToList();

            viewModel.SelectedCategory = null;
            ProductsFilter productsFilter = new ProductsFilter
                {
                    Text = searchTerm,
                    Publish = true,
                    ParentId = parentCategoryId
                };
            productsFilter.PaginationFilter.PageNumber = pageNumber == null ? 1 : pageNumber.Value;
            productsFilter.PaginationFilter.PageSize = ApplicationSettings.Instance.AppSettings.DefaultPageSize;

            PagedProductListResult pagedProductListResult = _productsBL.Get(productsFilter);
            viewModel.Products = pagedProductListResult.Entities;
            viewModel.PaginationFilterViewModel = new HomePagePaginationFilterViewModel
                {
                    PageNumber = productsFilter.PaginationFilter.PageNumber,
                    TotalRecords = pagedProductListResult.TotalRecords,
                    PageSize = productsFilter.PaginationFilter.PageSize,
                    SearchTerm = searchTerm,
                    ParentCategoryId = parentCategoryId
                };
            if (parentCategoryId.HasValue)
            {
                viewModel.ParentCategories = _productCategoriesBL.GetParentCategories(parentCategoryId.Value);
                viewModel.ParentCategories.Add(_productCategoriesBL.GetById(parentCategoryId.Value));
            }
            else
            {
                viewModel.ParentCategories = new List<ProductCategory>();
            }

            return viewModel;
        }

        [Route("categories/{categoryId:int}/products/{productId:int}")]
        public ActionResult Details(int productId, int categoryId)
        {
            ViewData["category"] = categoryId;
            ProductDetailsViewModel viewModel = new ProductDetailsViewModel
                {
                    CategoryId = categoryId,
                    Product = _productsBL.GetById(productId, Request.IsAuthenticated ? User.Identity.Name : null, Request.UserHostAddress)
                };
            viewModel.ParentCategories = _productCategoriesBL.GetParentCategories(categoryId);
            viewModel.ParentCategories.Add(_productCategoriesBL.GetById(categoryId));

            return View("Details", viewModel);
        }
    }
}
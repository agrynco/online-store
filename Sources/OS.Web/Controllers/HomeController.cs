﻿using System.Linq;
using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
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

        public ActionResult Index(string searchTerm, int? pageNumber)
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
                    Publish = true
                };
            productsFilter.PaginationFilter.PageNumber = pageNumber == null ? 1 : pageNumber.Value;
            productsFilter.PaginationFilter.PageSize = 20;

            PagedProductListResult pagedProductListResult = _productsBL.Get(productsFilter);
            viewModel.Products = pagedProductListResult.Entities;
            viewModel.PaginationFilterViewModel = new PaginationFilterViewModel
                {
                    PageNumber = productsFilter.PaginationFilter.PageNumber,
                    TotalRecords = pagedProductListResult.TotalRecords,
                    PageSize = productsFilter.PaginationFilter.PageSize,
                };

            return View(viewModel);
        }

        [Route("categories/{categoryId:int}")]
        public ActionResult ChangeCategory(int categoryId)
        {
            TempData["CategoryId"] = categoryId;
            HomePageViewModel viewModel = new HomePageViewModel();
            viewModel.RootCategories = _productCategoriesBL.GetCategories(null).Select(productCategory => new HorizontalCategoryItemViewModel
            {
                ProductCategory = productCategory,
                IsSelected = productCategory.Id == categoryId
            }).ToList();

            viewModel.SelectedCategory = _productCategoriesBL.GetById(categoryId);
            viewModel.Products = _productsBL.Get(new ProductsFilter
            {
                ParentId = categoryId,
                Publish = true
            }).Entities;

            return View("Index", viewModel);
        }

        [Route("categories/{categoryId:int}/products/{productId:int}")]
        public ActionResult Details(int productId, int categoryId)
        {
            ViewData["category"] = categoryId;
            ProductDetailsViewModel model = new ProductDetailsViewModel
            {
                CategoryId = categoryId,
                Product = _productsBL.GetById(productId, Request.IsAuthenticated ? User.Identity.Name : null, Request.UserHostAddress)
            };
            return View("Details", model);
        }
    }
}
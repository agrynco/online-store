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
        private readonly TextContentsBL _textContentsBL;

        public HomeController(ProductCategoriesBL productCategoriesBL, ProductsBL productsBL, TextContentsBL textContentsBL)
        {
            _productCategoriesBL = productCategoriesBL;
            _productsBL = productsBL;
            _textContentsBL = textContentsBL;
        }

        [Route("robots.txt")]
        public string RobotsTxt()
        {
            TextContent textContent = _textContentsBL.Get(TextContentCode.RobotsTxt);
            return textContent != null ? textContent.Text : string.Empty;
        }

        public ActionResult Index(string searchTerm, int? parentCategoryId, int? pageNumber)
        {
            Product product = _productsBL.GetByCode(searchTerm);
            if (product != null)
            {
                return RedirectToAction("Details", new
                    {
                        productId = product.Id,
                        categoryId = product.Categories.First().Id
                    });
            }

            HomePageViewModel viewModel = BuildHomePageViewModel(searchTerm, parentCategoryId, pageNumber);

            return View(viewModel);
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditPropductCategoryArticle(int categoryId)
        {
            ProductCategory productCategory = _productCategoriesBL.GetById(categoryId);
            ProductCategoryArticleEditViewModel model = new ProductCategoryArticleEditViewModel
                {
                    Id = productCategory.Id,
                    Text = productCategory.Article
                };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "admin")]
        public ActionResult Save(ProductCategoryArticleEditViewModel model)
        {
            ProductCategory productCategory = _productCategoriesBL.GetById(model.Id.Value);
            productCategory.Article = model.Text;
            _productCategoriesBL.Update(productCategory);

            return RedirectToAction("Index", new
                {
                    parentCategoryId = model.Id.Value
                });
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
                viewModel.SelectedCategory = _productCategoriesBL.GetById(parentCategoryId.Value);
                viewModel.ParentCategories.Add(viewModel.SelectedCategory);

                viewModel.ChildCategories = _productCategoriesBL.SearchByFilter(new ProductCategoriesFilter
                    {
                        ParentId = parentCategoryId,
                        IncludeDeleted = false,
                        Publish = true,
                        PaginationFilter =
                            {
                                PageNumber = 1,
                                PageSize = 300
                            }
                    }).Entities;
            }
            else
            {
                viewModel.ParentCategories = new List<ProductCategory>();
                viewModel.ChildCategories = new List<ProductCategory>();
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
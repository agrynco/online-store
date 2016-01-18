using System.Linq;
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

        public ActionResult Index()
        {
            HomePageViewModel viewModel = new HomePageViewModel();
            viewModel.RootCategories = _productCategoriesBL.GetCategories(null).Select(productCategory => new HorizontalCategoryItemViewModel
            {
                ProductCategory = productCategory,
                IsSelected = false
            }).ToList();

            viewModel.SelectedCategory = null;
            viewModel.Products = _productsBL.Get(null);

            return View(viewModel);
        }

        [Route("categories/{categoryId:int}")]
        public ActionResult ChangeCategory(int categoryId)
        {
            HomePageViewModel viewModel = new HomePageViewModel();
            viewModel.RootCategories = _productCategoriesBL.GetCategories(null).Select(productCategory => new HorizontalCategoryItemViewModel
            {
                ProductCategory = productCategory,
                IsSelected = productCategory.Id == categoryId
            }).ToList();

            viewModel.SelectedCategory = _productCategoriesBL.GetById(categoryId);
            viewModel.Products = _productsBL.Get(new ProductsFilter
            {
                ParentId = categoryId
            });

            return View("Index", viewModel);
        }

        [Route("categories/{categoryId:int}/products/{productId:int}")]
        public ActionResult Details(int productId, int categoryId)
        {
            ProductDetailsViewModel model = new ProductDetailsViewModel
            {
                CategoryId = categoryId,
                Product = _productsBL.GetById(productId)
            };
            return View("Details", model);
        }
    }
}
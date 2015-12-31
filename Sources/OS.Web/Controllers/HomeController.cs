#region Usings
using System.Linq;
using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Web.Models;
#endregion

namespace OS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductCategoriesBL _productCategoriesBL;
        private readonly ProductsBL _productsBL;

        public HomeController(ProductCategoriesBL productCategoriesBL, ProductsBL productsBL)
        {
            _productCategoriesBL = productCategoriesBL;
            _productsBL = productsBL;
        }

        public virtual ActionResult Index()
        {
            HomePageViewModel viewModel = new HomePageViewModel();

            viewModel.RootCategories = _productCategoriesBL.GetCategories(null).Select(productCategory => new HorizontalCategoryItemViewModel
                {
                    ProductCategory = productCategory,
                    IsSelected = false
                }).ToList();

            viewModel.Products = _productsBL.Get(null);

            return View(viewModel);
        }

        public ActionResult ChangeCategory(int categoryId)
        {
            HomePageViewModel viewModel = new HomePageViewModel();
            viewModel.RootCategories = _productCategoriesBL.GetCategories(null).Select(productCategory => new HorizontalCategoryItemViewModel
                {
                    ProductCategory = productCategory,
                    IsSelected = productCategory.Id == categoryId
                }).ToList();

            viewModel.SelectedCategory = viewModel.RootCategories.Single(productCategory => productCategory.ProductCategory.Id == categoryId).ProductCategory;
            viewModel.Products = _productsBL.Get(new ProductsFilter
                {
                    ParentId = categoryId
                });

            return View("Index", viewModel);
        }
    }
}
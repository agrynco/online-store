#region Usings
using System.Linq;
using System.Web.Mvc;
using OS.Business.Logic;
using OS.Web.Models;
#endregion

namespace OS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductCategoriesBL _productCategoriesBL;

        public HomeController(ProductCategoriesBL productCategoriesBL)
        {
            _productCategoriesBL = productCategoriesBL;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            HomePageViewModel viewModel = new HomePageViewModel();

            viewModel.HorizontalCategorySelectorViewModel.RootCategories = _productCategoriesBL.GetRootCategories();

            return View(viewModel);
        }

        public ActionResult ChangeCategory(int categoryId)
        {
            HomePageViewModel viewModel = new HomePageViewModel();

            viewModel.HorizontalCategorySelectorViewModel.RootCategories = _productCategoriesBL.GetRootCategories();
            viewModel.SelectedCategory = viewModel.HorizontalCategorySelectorViewModel.RootCategories.Single(productCategory => productCategory.Id == categoryId);

            return View("Index", viewModel);
        }
    }
}
#region Usings
using System.Linq;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using OS.Business.Logic;
using OS.Web.Models;
#endregion

namespace OS.Web.Controllers
{
    public class BaseLayoutController<TViewModel> : Controller
        where TViewModel : HorizontalCategorySelectorViewModel, new ()
    {
        private readonly ProductCategoriesBL _productCategoriesBL;

        public BaseLayoutController(ProductCategoriesBL productCategoriesBL)
        {
            _productCategoriesBL = productCategoriesBL;
        }

        private TViewModel CreateInstanceOfViewModel()
        {
            return new TViewModel();
        }
        
        public ActionResult Index()
        {
            TViewModel viewModel = CreateInstanceOfViewModel();

            viewModel.RootCategories = _productCategoriesBL.GetRootCategories().Select(productCategory => new HorizontalCategoryItemViewModel
                {
                    ProductCategory = productCategory,
                    IsSelected = false
                }).ToList();

            return View(viewModel);
        }

        public ActionResult ChangeCategory(int categoryId)
        {
            TViewModel viewModel = CreateInstanceOfViewModel();
            viewModel.RootCategories = _productCategoriesBL.GetRootCategories().Select(productCategory => new HorizontalCategoryItemViewModel
                {
                    ProductCategory = productCategory,
                    IsSelected = productCategory.Id == categoryId
                }).ToList();

            viewModel.SelectedCategory = viewModel.RootCategories.Single(productCategory => productCategory.ProductCategory.Id == categoryId).ProductCategory;

            return View("Index", viewModel);
        }
    }
}
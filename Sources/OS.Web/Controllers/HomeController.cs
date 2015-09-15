#region Usings
using System.Collections.Generic;
using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
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

            IList<ProductCategory> productCategories = _productCategoriesBL.GetRootCategories();

            return View();
        }
    }
}
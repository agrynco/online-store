#region Usings
using System.Web.Mvc;
using OS.Business.Logic;
using OS.Web.Models;
#endregion

namespace OS.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly ProductCategoriesBL _productCategoriesBL;

        public AboutController(ProductCategoriesBL productCategoriesBL)
        {
            _productCategoriesBL = productCategoriesBL;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
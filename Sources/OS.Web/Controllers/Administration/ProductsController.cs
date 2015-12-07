using System.Web.Mvc;
using OS.Web.Models.ProductViewModels;

namespace OS.Web.Controllers.Administration
{
    public class ProductsController : BaseAdminController
    {
        [HttpGet]
        public ActionResult Create(int categoryId)
        {
            ProductCreateOrEditViewModel model = new ProductCreateOrEditViewModel();

            return View(model);
        }
    }
}
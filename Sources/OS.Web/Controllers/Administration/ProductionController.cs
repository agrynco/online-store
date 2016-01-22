using System.Web.Mvc;

namespace OS.Web.Controllers.Administration
{
    public class ProductionController : BaseAdminController
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
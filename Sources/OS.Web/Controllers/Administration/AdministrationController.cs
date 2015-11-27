using System.Web.Mvc;

namespace OS.Web.Controllers.Administration
{
    public class AdministrationController : BaseAdminController
    {
        public ActionResult Home()
        {
            return View();
        }
    }
}
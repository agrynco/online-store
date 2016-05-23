using System.Web.Mvc;

namespace OS.Web.Controllers.Administration
{
    public class CurrenciesController : BaseAdminController
    {
        [Route("administration/currencies")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
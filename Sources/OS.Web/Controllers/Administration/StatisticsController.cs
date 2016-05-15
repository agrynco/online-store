using System.Web.Mvc;

namespace OS.Web.Controllers.Administration
{
    public class StatisticsController : BaseAdminController
    {
        public ActionResult ProductViewFrequency()
        {
            return View();
        }
    }
}
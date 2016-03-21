using System.Web.Mvc;

namespace OS.Web.Controllers
{
    public class NotFoundController : Controller
    {
        [Route("notfound")]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}
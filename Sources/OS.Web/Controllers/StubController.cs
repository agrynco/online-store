#region Usings
using System.Web.Mvc;
#endregion

namespace OS.Web.Controllers
{
    public class StubController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
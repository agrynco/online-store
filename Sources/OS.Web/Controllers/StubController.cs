#region Usings
using System.Web.Mvc;
#endregion

namespace OS.Web.Controllers
{
    public class StubController : Controller
    {
        // GET: Stub
        public ActionResult Index()
        {
            return View();
        }
    }
}
#region Usings
using System.Web.Mvc;
#endregion

namespace OS.Web.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }
    }
}
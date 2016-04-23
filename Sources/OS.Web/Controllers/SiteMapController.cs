using System.Web.Mvc;
using MvcSiteMapProvider.Web.Mvc.Filters;

namespace OS.Web.Controllers
{
    public class SiteMapController : Controller
    {
        [SiteMapCacheRelease]
        public ActionResult Index()
        {
            return View();
        }
    }
}
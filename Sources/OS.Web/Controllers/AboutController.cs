#region Usings
using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
#endregion

namespace OS.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly HtmlContentsBL _htmlContentsBL;

        public AboutController(HtmlContentsBL htmlContentsBL)
        {
            _htmlContentsBL = htmlContentsBL;
        }

        public ActionResult Index()
        {
            HtmlContent htmlContent = _htmlContentsBL.GetByCode(HtmlContentCode.About);

            return View(htmlContent);
        }
    }
}
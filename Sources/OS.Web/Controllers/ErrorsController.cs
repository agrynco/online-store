using System;
using System.Web.Mvc;

namespace OS.Web.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("notfound")]
        public ActionResult NotFound()
        {
            return View();
        }

        [Route("servererror")]
        public ActionResult ServerError()
        {
            Exception ex = Server.GetLastError();
            return View(new HandleErrorInfo(ex, "", ""));
        }
    }
}
using System.Web.Mvc;

namespace OS.Web.Controllers.Administration
{
    [Authorize(Roles = "admin")]
    [RoutePrefix("administration")]
    public class BaseAdminController : Controller
    {
    }
}
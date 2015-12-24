using System.Web.Mvc;

namespace OS.Web.Controllers.Administration
{
    [Authorize(Roles = "admin" )]
    public class BaseAdminController : Controller
    {
    }
}
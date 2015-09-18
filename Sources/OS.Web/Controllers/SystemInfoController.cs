#region Usings
using System.Reflection;
using System.Web.Mvc;
using OS.Web.Models;
#endregion

namespace OS.Web.Controllers
{
    public class SystemInfoController : Controller
    {
        public ActionResult Index()
        {
            SystemInfoViewModel viewModel = new SystemInfoViewModel();

            viewModel.AssemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();

            return View(viewModel);
        }
    }
}
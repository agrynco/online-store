using System.Web.Mvc;
using System.Web.UI;
using OS.Business.Logic;
using File = OS.Business.Domain.File;

namespace OS.Web.Controllers
{
    public class FilesController : Controller
    {
        private readonly FilesBL _filesBl;

        public FilesController(FilesBL filesBL)
        {
            _filesBl = filesBL;
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Client, VaryByParam = "id")]
        public ActionResult GetFileContent(int id)
        {
            File file = _filesBl.GetFile(id);

            return new FileContentResult(file.Data, file.ContentContentType.ToString());
        }
    }
}
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using OS.Business.Domain;
using OS.Business.Logic;
using File = OS.Business.Domain.File;

namespace OS.Web.Controllers
{
    public class FilesController : Controller
    {
        private readonly FilesBL _filesBl;
        private readonly PhotosBL _photosBL;

        public FilesController(FilesBL filesBL, PhotosBL photosBL)
        {
            _filesBl = filesBL;
            _photosBL = photosBL;
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Client, VaryByParam = "id")]
        public ActionResult GetFileContent(int id)
        {
            File file = _filesBl.GetFile(id);

            return new FileContentResult(file.Data, file.ContentContentType.ToString());
        }

        [Route("photos/{id}")]
        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Client, VaryByParam = "id")]
        public FileResult GetWhaterMarkedPhoto(int id)
        {
            Photo photo = _photosBL.GetById(id, Request.Url.Host);

            return new FileContentResult(photo.WaterMarked.Data, MimeMapping.GetMimeMapping(photo.FileName));
        }
    }
}
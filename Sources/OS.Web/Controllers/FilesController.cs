using System.Net.Http.Headers;
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
        private readonly ProductPhotosBL _productPhotosBL;

        public FilesController(FilesBL filesBL, ProductPhotosBL productPhotosBL)
        {
            _filesBl = filesBL;
            _productPhotosBL = productPhotosBL;
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Client, VaryByParam = "id")]
        public ActionResult GetFileContent(int id)
        {
            File file = _filesBl.GetFile(id);

            return new FileContentResult(file.Data, file.ContentContentType.ToString());
        }

        [Route("productphotos/{id}")]
        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Client, VaryByParam = "id")]
        public FileResult GetWhaterMarkedPhoto(int id)
        {
            Photo photo = _productPhotosBL.GetById(id, Request.Url.Host);

            return new FileContentResult(photo.WaterMarked.Data, MimeMapping.GetMimeMapping(photo.FileName));
        }
    }
}
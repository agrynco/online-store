using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Configuration;

namespace OS.Web.Controllers.Api
{
    [RoutePrefix("api/photos")]
    public class PhotosController : ApiController
    {
        private readonly PhotosBL _photosBL;

        public PhotosController(PhotosBL photosBL)
        {
            _photosBL = photosBL;
        }

        [Route("{id}/whatermarked")]
        public HttpResponseMessage GetWaterMarkedPhoto(int id)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.NotFound);

            Photo photo = _photosBL.GetById(id, Request.RequestUri.Host);

            if (photo != null)
            {
                result.StatusCode = HttpStatusCode.OK;

                result.Content = new ByteArrayContent(
                    ApplicationSettings.Instance.AppSettings.UseWatermarks
                        ? photo.WaterMarked.Data
                        : photo.Data);

                result.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(photo.FileName));
            }

            return result;
        }
    }
}
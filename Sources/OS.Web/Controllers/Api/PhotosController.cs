using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using OS.Business.Domain;
using OS.Business.Logic;

namespace OS.Web.Controllers.Api
{
    [RoutePrefix("api/productphotos")]
    public class PhotosController : ApiController
    {
        private readonly PhotosBL _photosBL;

        public PhotosController(PhotosBL photosBL)
        {
            _photosBL = photosBL;
        }

        [Route("{id}")]
        public HttpResponseMessage GetWaterMarkedPhoto(int id)
        {
            Photo photo = _photosBL.GetById(id);
            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(photo.WaterMarked.Data)
                };
            responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(photo.FileName));

            return responseMessage;
        }
    }
}
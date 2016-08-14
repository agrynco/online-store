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
    public class ProductPhotosController : ApiController
    {
        private readonly ProductPhotosBL _productPhotosBL;

        public ProductPhotosController(ProductPhotosBL productPhotosBL)
        {
            _productPhotosBL = productPhotosBL;
        }

        [Route("{id}")]
        public HttpResponseMessage GetWaterMarkedPhoto(int id)
        {
            Photo photo = _productPhotosBL.GetById(id);
            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            responseMessage.Content = new ByteArrayContent(photo.WaterMarked.Data);
            responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(photo.FileName));

            return responseMessage;
        }
    }
}
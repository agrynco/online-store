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
            ProductPhoto productPhoto = _productPhotosBL.GetById(id);
            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            responseMessage.Content = new ByteArrayContent(productPhoto.WaterMarked.Data);
            responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(productPhoto.FileName));

            return responseMessage;
        }
    }
}
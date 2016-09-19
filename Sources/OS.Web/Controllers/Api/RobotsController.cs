using System.Net;
using System.Net.Http;
using System.Web.Http;
using OS.Business.Domain;
using OS.Business.Logic;

namespace OS.Web.Controllers.Api
{
    public class RobotsController : BaseApiController
    {
        private readonly TextContentsBL _textContentsBL;

        public RobotsController(TextContentsBL textContentsBL)
        {
            _textContentsBL = textContentsBL;
        }

        [Route("robots.txt")]
        [AllowAnonymous]
        public HttpResponseMessage Get()
        {
            TextContent textContent = _textContentsBL.Get(TextContentCode.RobotsTxt);
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(textContent.Text, System.Text.Encoding.UTF8, "text/plain");
            return resp;
        }
    }
}
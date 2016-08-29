using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OS.Web.Controllers.Api
{
    public class RobotsController : BaseApiController
    {
        [Route("robots.txt")]
        [AllowAnonymous]
        public HttpResponseMessage Get()
        {
            string result = "dfh asdfghksajdgf kasjdfg kjasgfdkjsagfd jksgdfjksgfajksgf kjasgf kjskdfjgaskjfg aksjfdg";
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
            return resp;
        }
    }
}
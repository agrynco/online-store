using System.Web.Http;

namespace OS.Web.Controllers.Api
{
    [Authorize(Roles = "admin")]
    public class BaseApiController : ApiController
    {
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OS.Business.Logic;

namespace OS.Web.Controllers.Api
{
    public class BrandsController : ApiController
    {
        private readonly BrandsBL _brandsBL;

        public BrandsController(BrandsBL brandsBL)
        {
            _brandsBL = brandsBL;
        }

        public List<string> Get(string term)
        {
            return _brandsBL.Find(term).Select(brand => brand.Name).ToList();
        } 
    }
}
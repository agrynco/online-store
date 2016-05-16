using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OS.Business.Domain;
using OS.Business.Logic;

namespace OS.Web.Controllers.Api
{
    [RoutePrefix("api/brands")]
    public class BrandsController : BaseApiController
    {
        private readonly BrandsBL _brandsBL;

        public BrandsController(BrandsBL brandsBL)
        {
            _brandsBL = brandsBL;
        }

        [Route("autocomplete")]
        public List<string> Get(string term)
        {
            return _brandsBL.Find(term).Select(brand => brand.Name).ToList();
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _brandsBL.Delete(id);
        }

        [Route]
        public object Get()
        {
            return new
                {
                    data = _brandsBL.Find(new BrandsFilter()).Entities.Select(x => new object[] {x.Id, x.Name})
                };
        }
    }
}
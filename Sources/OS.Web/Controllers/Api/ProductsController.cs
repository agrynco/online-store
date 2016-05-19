using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OS.Business.Domain;
using OS.Business.Logic;

namespace OS.Web.Controllers.Api
{
    [RoutePrefix("api/products")]
    public class ProductsController : BaseApiController
    {
        private readonly ProductsBL _productsBL;

        public ProductsController(ProductsBL productsBL)
        {
            _productsBL = productsBL;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("autocomplete")]
        public List<string> Get(string term)
        {
            return _productsBL.Get(new ProductsFilter
                {
                    Text = term
                }).Entities.Select(x => x.Name).ToList();
        }

        [HttpPut]
        [Route("{id}/publish/{value}")]
        public void SetPublish([FromUri] int id, [FromUri] bool value)
        {
            Product product = _productsBL.GetById(id);
            product.Publish = value;
            _productsBL.Update(product);
        }
    }
}
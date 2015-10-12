#region Usings
using System.Collections.Generic;
using System.Web.Http;
using OS.Business.Domain;
using OS.Business.Logic;
#endregion

namespace OS.Web.Controllers.Api
{
    public class CategoriesController : ApiController
    {
        private readonly ProductCategoriesBL _productCategoriesBL;

        public CategoriesController(ProductCategoriesBL productCategoriesBL)
        {
            _productCategoriesBL = productCategoriesBL;
        }

        [Route("top")]
        public IList<ProductCategory> GetRootCategories()
        {
            return _productCategoriesBL.GetRootCategories();
        }
    }
}
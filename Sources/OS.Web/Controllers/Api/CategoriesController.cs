#region Usings
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Web.Models.ProductCategoryViewModels;
#endregion

namespace OS.Web.Controllers.Api
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private readonly ProductCategoriesBL _productCategoriesBL;

        public CategoriesController(ProductCategoriesBL productCategoriesBL)
        {
            _productCategoriesBL = productCategoriesBL;
        }

        [Route("root")]
        public IList<ProductCategory> GetRootCategories()
        {
            return _productCategoriesBL.GetCategories(null);
        }

        [Route("autocomplete")]
        [HttpGet]
        public IList<ProductCategoryAutocompleteItem> SearchCategories(string term)
        {
            List<ProductCategory> productCategories = _productCategoriesBL.SearchCategories(term);

            List<ProductCategoryAutocompleteItem> result = productCategories.Select(category => new ProductCategoryAutocompleteItem
                {
                    Id = category.Id,
                    Name = category.Name,
                    ParentCategories = _productCategoriesBL.GetParentCategories(category.Id).Select(parentCategory => parentCategory.Name).ToArray()
                }).ToList();

            return result;
        }
    }
}
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

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _productCategoriesBL.Delete(id);
        }

        [Route("{id}/subcategories")]
        public ProductCategoriesApiViewModel GetChildCategories(int? id)
        {
            List<ProductCategory> productCategories = _productCategoriesBL.GetCategories(id).Where(entity => !entity.IsDeleted).ToList();

            ProductCategoriesApiViewModel apiViewModel = new ProductCategoriesApiViewModel();
            apiViewModel.data.AddRange(productCategories.Select(BuildProductCategoryListItemViewModel));

            if (id.HasValue)
            {
                List<ProductCategory> parentCategories = _productCategoriesBL.GetParentCategories(id.Value);
                parentCategories.Add(_productCategoriesBL.GetById(id.Value));

                apiViewModel.PathToRoot.AddRange(parentCategories.Select(BuildProductCategoryListItemViewModel));
            }

            return apiViewModel;
        }

        private static ProductCategoryListItemViewModel BuildProductCategoryListItemViewModel(ProductCategory x)
        {
            return new ProductCategoryListItemViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                    Publish = x.Publish,
                    IsDeleted = x.IsDeleted
                };
        }

        [HttpPut]
        [Route("{id}/togglePublish")]
        public void TogglePublish(int id)
        {
            ProductCategory productCategory = _productCategoriesBL.GetById(id);
            _productCategoriesBL.SetPublish(id, !productCategory.Publish);
        }
    }
}
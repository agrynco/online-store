#region Usings
using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;
#endregion

namespace OS.Business.Logic
{
    public class ProductCategoriesBL
    {
        private readonly IProductCategoriesRepository _productCategoriesRepository;

        public ProductCategoriesBL(IProductCategoriesRepository productCategoriesRepository)
        {
            _productCategoriesRepository = productCategoriesRepository;
        }

        public IList<ProductCategory> GetCategories(int? parentId)
        {
            return _productCategoriesRepository.GetCategories(parentId).ToList();
        }

        public ProductCategory GetCategory(int id)
        {
            return _productCategoriesRepository.GetById(id);
        }

        public void Update(ProductCategory productCategory)
        {
            _productCategoriesRepository.Update(productCategory);
        }

        public void Create(ProductCategory productCategory)
        {
            _productCategoriesRepository.Add(productCategory);
        }

        public void Delete(int categoryId)
        {
            _productCategoriesRepository.Delete(categoryId);
        }

        public List<Product> GetProducts(int categoryId)
        {
            return _productCategoriesRepository.GetById(categoryId).Products.ToList();
        }
    }
}
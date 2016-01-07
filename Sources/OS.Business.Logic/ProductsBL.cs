using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class ProductsBL
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IProductCategoriesRepository _productCategoriesRepository;

        public ProductsBL(IProductsRepository productsRepository, 
            IProductCategoriesRepository productCategoriesRepository)
        {
            _productsRepository = productsRepository;
            _productCategoriesRepository = productCategoriesRepository;
        }

        public List<Product> Get(ProductsFilter filter)
        {
            return _productsRepository.Get(filter).ToList();
        }

        public void Create(Product product)
        {
            _productsRepository.Add(product);
        }

        public Product GetById(int id)
        {
            return _productsRepository.GetById(id);
        }

        public List<Product> GetByIds(IEnumerable<int> ids)
        {
            return _productsRepository.GetByIds(ids).ToList();
        } 

        public void Update(Product product)
        {
            _productsRepository.Update(product);
        }

        public void Delete(int productId)
        {
            Product product = _productsRepository.GetById(productId);
            _productsRepository.Delete(product);
        }
    }
}
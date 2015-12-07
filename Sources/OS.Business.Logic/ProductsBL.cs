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

        public void Create(Product product)
        {
            _productsRepository.Add(product);
        }
    }
}
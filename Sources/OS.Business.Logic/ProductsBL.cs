using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class ProductsBL
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsBL(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
    }
}
#region Usings
using OS.DAL.Abstract;
#endregion

namespace OS.DAL.EF
{
    public class OnlineStoreDbContext : IOnlineStoreDbContext
    {
        private readonly IProductCategoriesRepository _categoriesRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly EntityFrameworkDbContext _entityFrameworkDbContext;

        public OnlineStoreDbContext(EntityFrameworkDbContext entityFrameworkDbContext, 
            IProductCategoriesRepository categoriesRepository,
            IProductsRepository productsRepository)
        {
            _entityFrameworkDbContext = entityFrameworkDbContext;
            _categoriesRepository = categoriesRepository;
            _productsRepository = productsRepository;
        }

        public IProductCategoriesRepository CategoriesRepository
        {
            get { return _categoriesRepository; }
        }

        public IProductsRepository ProductsRepository
        {
            get { return _productsRepository; }
        }

        public int SaveChanges()
        {
            return _entityFrameworkDbContext.SaveChanges();
        }
    }
}
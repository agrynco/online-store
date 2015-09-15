#region Usings
using OS.DAL.Abstract;
#endregion

namespace OS.DAL.EF
{
    public class OnlineStoreDbContext : IOnlineStoreDbContext
    {
        private readonly IProductCategoriesRepository _categoriesRepository;
        private readonly EntityFrameworkDbContext _entityFrameworkDbContext;

        public OnlineStoreDbContext(EntityFrameworkDbContext entityFrameworkDbContext, IProductCategoriesRepository categoriesRepository)
        {
            _entityFrameworkDbContext = entityFrameworkDbContext;
            _categoriesRepository = categoriesRepository;
        }


        public IProductCategoriesRepository CategoriesRepository
        {
            get { return _categoriesRepository; }
        }

        public int SaveChanges()
        {
            return _entityFrameworkDbContext.SaveChanges();
        }
    }
}
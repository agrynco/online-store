#region Usings
using OS.DAL.Abstract;
#endregion

namespace OS.DAL.EF
{
    public class OnlineStoreDbContext : IOnlineStoreDbContext
    {
        private readonly EntityFrameworkDbContext _entityFrameworkDbContext;

        public OnlineStoreDbContext(EntityFrameworkDbContext entityFrameworkDbContext, IProductCategoriesRepository categoriesRepository)
        {
            _entityFrameworkDbContext = entityFrameworkDbContext;
            CategoriesRepository = categoriesRepository;
        }


        public IProductCategoriesRepository CategoriesRepository { get; }

        public int SaveChanges()
        {
            return _entityFrameworkDbContext.SaveChanges();
        }
    }
}
#region Usings
using System.Data.Entity;
using OS.Business.Domain;
using OS.DAL.Abstract;
#endregion

namespace OS.DAL.EF
{
    public class OnlineStoreDbContext : DbContext, IOnlineStoreDbContext
    {
        private readonly IProductCategoriesRepository _categoriesRepository;

        public OnlineStoreDbContext() : this("OnlineStore")
        {
        }

        public OnlineStoreDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            _categoriesRepository = new ProductCategoriesRepository(this);
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        IProductCategoriesRepository IOnlineStoreDbContext.CategoriesRepository
        {
            get { return _categoriesRepository; }
        }
    }
}
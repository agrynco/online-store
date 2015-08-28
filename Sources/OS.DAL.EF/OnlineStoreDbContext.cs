#region Usings
using System.Data.Entity;
using OS.Business.Domain;
#endregion

namespace OS.DAL.EF
{
    public class OnlineStoreDbContext : DbContext
    {
        public OnlineStoreDbContext() : this("OnlineStore")
        {
        }

        public OnlineStoreDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
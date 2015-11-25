#region Usings
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using OS.Business.Domain;
#endregion

namespace OS.DAL.EF
{
    public class EntityFrameworkDbContext : IdentityDbContext<ApplicationUser>
    {
        public EntityFrameworkDbContext() : this("OnlineStore")
        {
        }

        public EntityFrameworkDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
#region Usings
using System.Data.Entity;
using System.Reflection;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(GetType()));
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<File> Files { get; set; } 
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<ContentContentType> ContentContentTypes { get; set; }

        public DbSet<ContactInfo> ContactInfos { get; set; }

    }
}
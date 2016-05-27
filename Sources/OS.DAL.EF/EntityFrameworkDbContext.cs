#region Usings
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNet.Identity.EntityFramework;
using OS.Business.Domain;
using OS.DAL.Abstract.Exceptions;
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
            Database.Log = message => Debug.WriteLine(message);
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<ContentContentType> ContentContentTypes { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<HtmlContent> HtmlContents { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductMetaData> ProductMetaData { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductViewingInfo> ProductViewingInfos { get; set; }
        public DbSet<UserHostAddress> UserHostAddresses { get; set; }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessage = string.Empty;
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}",
                            validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new DALException(errorMessage, ex);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(GetType()));
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            base.Dispose(disposing);
        }
    }
}
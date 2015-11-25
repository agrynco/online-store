using Microsoft.AspNet.Identity.EntityFramework;
using OS.Business.Domain;
using OS.Configuration;

namespace OS.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString, throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext(ApplicationSettings.Instance.DbSettings.ApplicationConnectionString);
        }
    }
}
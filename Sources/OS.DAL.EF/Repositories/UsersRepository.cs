using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class UsersRepository : OnlineStoreCrudRepository<ApplicationUser, string>, IUsersRepository
    {
        public UsersRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public IQueryable<ApplicationUser> GetAdministrators()
        {
            IdentityRole adminRole = EntityFrameworkDbContext.Roles.Single(role => role.Name == "admin");

            IQueryable<ApplicationUser> result = GetAll().Where(user => user.Roles.Select(role => role.RoleId).Contains(adminRole.Id));

            return result;
        }
    }
}
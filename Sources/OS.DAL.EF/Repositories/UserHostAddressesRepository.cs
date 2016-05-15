using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class UserHostAddressesRepository : OnlineStoreCrudRepository<UserHostAddress>, IUserHostAddressesRepository
    {
        public UserHostAddressesRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public UserHostAddress GetByUserHostAddress(string userHostAddress)
        {
            return DbSet.SingleOrDefault(entity => entity.IpAddress == userHostAddress);
        }
    }
}
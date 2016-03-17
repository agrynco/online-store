using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract.Core;

namespace OS.DAL.Abstract
{
    public interface IUsersRepository : ICRUDRepository<ApplicationUser, string>
    {
        IQueryable<ApplicationUser> GetAdministrators();
    }
}
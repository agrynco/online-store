using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class PersonsRepository : OnlineStoreCRUDRepository<Person>, IPersonsRepository
    {
        public PersonsRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class ContactInfosRepository : BaseOnlineStoreCRUDRepository<ContactInfo>, IContactInfosRepository
    {
        public ContactInfosRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
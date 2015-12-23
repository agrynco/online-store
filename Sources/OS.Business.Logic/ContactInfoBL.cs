using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class ContactInfoBL
    {
        private readonly IContactInfosRepository _contactInfosRepository;

        public ContactInfoBL(IContactInfosRepository contactInfosRepository)
        {
            _contactInfosRepository = contactInfosRepository;
        }

        public ContactInfo Get()
        {
            return _contactInfosRepository.GetAll().Single();
        }
    }
}
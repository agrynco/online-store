using System.Security.Cryptography.X509Certificates;
using OS.Business.Domain;

namespace OS.DAL.Abstract
{
    public interface IContactInfosRepository : IOnlineStoreRepository<ContactInfo>
    {
    }
}
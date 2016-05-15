using OS.Business.Domain;

namespace OS.DAL.Abstract
{
    public interface IUserHostAddressesRepository : IOnlineStoreRepository<UserHostAddress>
    {
        UserHostAddress GetByUserHostAddress(string userHostAddress);
    }
}
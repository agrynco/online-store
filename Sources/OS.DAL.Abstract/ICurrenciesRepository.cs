using OS.Business.Domain;

namespace OS.DAL.Abstract
{
    public interface ICurrenciesRepository : IOnlineStoreRepository<Currency>
    {
        Currency GetMainCurrency();
    }
}
using System;
using OS.Business.Domain;

namespace OS.DAL.Abstract
{
    public interface ICurrencyRatesRepository : IOnlineStoreRepository<CurrencyRate>
    {
        CurrencyRate GetActualRate(int currencyId, DateTime date);
    }
}
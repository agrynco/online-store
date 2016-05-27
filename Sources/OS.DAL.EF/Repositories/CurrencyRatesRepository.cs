using System;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class CurrencyRatesRepository : OnlineStoreCrudRepository<CurrencyRate>, ICurrencyRatesRepository
    {
        public CurrencyRatesRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public CurrencyRate GetActualRate(int currencyId, DateTime date)
        {
            return (from currencyRate in DbSet
                where currencyRate.DateOfRate ==
                      (from maxCurrencyRate in DbSet
                          where currencyRate.CurrencyId == currencyId && maxCurrencyRate.DateOfRate <= date
                          select maxCurrencyRate).Max(maxCurrencyRate => maxCurrencyRate.DateOfRate)
                select currencyRate).SingleOrDefault();
        }
    }
}
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
                      (from currencyRate1 in DbSet where currencyRate1.DateOfRate <= date && currencyRate1.CurrencyId == currencyId select currencyRate1).Max(currencyRate1 => currencyRate1.DateOfRate)
                select currencyRate).SingleOrDefault();
        }
    }
}
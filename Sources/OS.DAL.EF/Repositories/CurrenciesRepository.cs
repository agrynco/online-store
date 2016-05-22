using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class CurrenciesRepository : NamedEntitiesRepository<Currency>, ICurrenciesRepository
    {
        public CurrenciesRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public Currency GetMainCurrency()
        {
            return DbSet.Single(currency => !currency.IsDeleted && currency.IsMain);
        }
    }
}
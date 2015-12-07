using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class CountriesRepository : BaseOnlineStoreCRUDRepository<Country>, ICountriesRepository
    {
        public CountriesRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
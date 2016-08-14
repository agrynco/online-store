using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class BrandsRepository : OnlineStoreCRUDRepository<Brand>, IBrandsRepository
    {
        public BrandsRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
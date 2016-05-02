using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class ProductMetaDataRepository : OnlineStoreCrudRepository<ProductMetaData>, IProductMetaDataRepository
    {
        public ProductMetaDataRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
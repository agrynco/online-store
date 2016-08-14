using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class ProductViewingInfosRepository : OnlineStoreCRUDRepository<ProductViewingInfo>, IProductViewingInfosRepository
    {
        public ProductViewingInfosRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public ProductViewingInfo Get(int productId, int userHostAddressId)
        {
            return DbSet.SingleOrDefault(entity => entity.ProductId == productId && entity.UserHostAddressId == userHostAddressId);
        }
    }
}
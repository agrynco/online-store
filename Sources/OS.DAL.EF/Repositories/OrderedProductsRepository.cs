using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class OrderedProductsRepository : BaseOnlineStoreCRUDRepository<OrderedProduct>, IOrderedProductsRepository
    {
        public OrderedProductsRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
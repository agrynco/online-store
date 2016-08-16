using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class OrderedProductsRepository : OnlineStoreCRUDRepository<OrderedProduct>, IOrderedProductsRepository
    {
        public OrderedProductsRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
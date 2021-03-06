using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class OrdersRepository : OnlineStoreCRUDRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
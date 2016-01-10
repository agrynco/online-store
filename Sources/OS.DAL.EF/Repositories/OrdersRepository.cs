using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class OrdersRepository : BaseOnlineStoreCRUDRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
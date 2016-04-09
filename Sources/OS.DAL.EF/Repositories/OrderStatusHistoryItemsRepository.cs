using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class OrderStatusHistoryItemsRepository : OnlineStoreCrudRepository<OrderStatusHistoryItem>, IOrderStatusHistoryItemsRepository
    {
        public OrderStatusHistoryItemsRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
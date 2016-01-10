using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class OrderStatusHistoryItemsRepository : BaseOnlineStoreCRUDRepository<OrderStatusHistoryItem>, IOrderStatusHistoryItemsRepository
    {
        public OrderStatusHistoryItemsRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
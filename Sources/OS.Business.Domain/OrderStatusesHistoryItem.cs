using System;

namespace OS.Business.Domain
{
    public class OrderStatusHistoryItem : IdentityEntity
    {
        public OrderStatus Status { get; set; }
        public int OrderId { get; set; }
    }
}
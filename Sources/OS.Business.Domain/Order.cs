using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OS.Business.Domain
{
    public class Order : IdentityEntity
    {
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual IList<OrderedProduct> OrderedProducts { get; set; }

        public virtual IList<OrderStatusHistoryItem> OrderStatusesHistory { get; set; }
        public virtual Person Person { get; set; }

        [NotMapped]
        public OrderStatus? Status
        {
            get
            {
                OrderStatusHistoryItem orderStatusHistoryItem = OrderStatusesHistory.LastOrDefault();
                return orderStatusHistoryItem != null ? orderStatusHistoryItem.Status : (OrderStatus?) null;
            }
        }

        public decimal TotalAmount { get; set; }

        public string AdditionalComment { get; set; }
    }
}
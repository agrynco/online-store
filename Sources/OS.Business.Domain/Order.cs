using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OS.Business.Domain
{
    public class Order : IdentityEntity
    {
        public IList<OrderedProduct> OrderedProducts { get; set; }

        [NotMapped]
        public OrderStatus? Status
        {
            get
            {
                OrderStatusHistoryItem orderStatusHistoryItem = OrderStatusesHistory.LastOrDefault();
                return orderStatusHistoryItem != null ? orderStatusHistoryItem.Status : (OrderStatus?) null;
            }
        }

        public IList<OrderStatusHistoryItem> OrderStatusesHistory { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public Person Person { get; set; }
    }
}
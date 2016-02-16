using System.Collections.Generic;
using OS.Business.Domain;

namespace OS.Web.Models
{
    public class ProductToBuyDescriptor
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public int CategoryId { get; set; }
    }

    public class ConsumerBasketViewModel
    {
        public IList<ProductToBuyDescriptor> ProductToByDescriptors { get; set; }
    }
}
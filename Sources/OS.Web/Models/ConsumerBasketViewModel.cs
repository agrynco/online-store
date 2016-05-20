using System.Collections.Generic;
using OS.Business.Domain;

namespace OS.Web.Models
{
    public class ProductToBuyDescriptor
    {
        public int CategoryId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class ConsumerBasketViewModel
    {
        public ConsumerBasketViewModel()
        {
            ProductToByDescriptors = new List<ProductToBuyDescriptor>();
        }

        public bool? AfterBuy { get; set; }

        public List<ProductToBuyDescriptor> ProductToByDescriptors { get; private set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace OS.Business.Domain
{
    public class OrderedProduct : IdentityEntity
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        public decimal PriceAtTheTimeOfPurchase { get; set; }

        [Required]
        public virtual Order Order { get; set; }

        public int OrderId { get; set; }
    }
}
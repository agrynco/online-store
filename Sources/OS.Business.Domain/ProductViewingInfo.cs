namespace OS.Business.Domain
{
    public class ProductViewingInfo : IdentityEntity
    {
        public int Count { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual UserHostAddress UserHostAddress { get; set; }
        public int UserHostAddressId { get; set; }
        public string UserId { get; set; }
    }
}
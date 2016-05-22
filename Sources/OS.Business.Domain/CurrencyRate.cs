using System;

namespace OS.Business.Domain
{
    public class CurrencyRate : IdentityEntity
    {
        public virtual Currency Currency { get; set; }
        public int CurrencyId { get; set; }
        public DateTime DateOfRate { get; set; }
        public decimal Rate { get; set; }
    }
}
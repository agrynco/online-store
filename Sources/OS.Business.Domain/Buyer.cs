namespace OS.Business.Domain
{
    public class Buyer : IdentityEntity
    {
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
}
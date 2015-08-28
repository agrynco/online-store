namespace OS.Business.Domain
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }

    public class Entity<TId> : IEntity<TId>
    {
        public TId Id { get; set; }
    }
}
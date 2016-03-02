using System;

namespace OS.Business.Domain
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime? Created { get; set; }
        DateTime? Updated { get; set; }
        DateTime? Deleted { get; set; }
    }

    public class Entity<TId> : IEntity<TId>
    {
        public TId Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
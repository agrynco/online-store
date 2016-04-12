using System;

namespace OS.Business.Domain
{
    public interface IEntity
    {
        object Id { get; set; }    
    }

    public interface IEntity<TId> : IEntity
    {
        new TId Id { get; set; }
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

        object IEntity.Id
        {
            get { return Id; }
            set { Id = (TId) value; }
        }
    }
}
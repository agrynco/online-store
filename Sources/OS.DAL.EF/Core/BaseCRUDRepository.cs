#region Usings
using System;
using System.Data.Entity;
using OS.Business.Domain;
using OS.DAL.Abstract.Core;
#endregion

namespace OS.DAL.EF.Core
{
    public class BaseCRUDRepository<TDbContext, TEntity, TEntityId> : BaseReadOnlyRepository<TDbContext, TEntity, TEntityId>,
        ICRUDRepository<TEntity, TEntityId>
        where TEntity : class, IEntity<TEntityId>
        where TDbContext : DbContext
    {
        public BaseCRUDRepository(TDbContext entityFrameworkDbContext)
            : base(entityFrameworkDbContext)
        {
        }

        public TEntity Add(TEntity entity)
        {
            entity.Created = DateTime.UtcNow;
            TEntity addedEntity = DbSet.Add(entity);
            EntityFrameworkDbContext.SaveChanges();
            return addedEntity;
        }

        public virtual void Delete(params TEntityId[] id)
        {
            foreach (TEntityId entityId in id)
            {
                Delete(GetById(entityId));
            }
        }

        public virtual void Delete(params TEntity[] entities)
        {
            DbSet.RemoveRange(entities);
            EntityFrameworkDbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            EntityFrameworkDbContext.Entry(entity).State = EntityState.Modified;
            EntityFrameworkDbContext.SaveChanges();
        }
    }
}
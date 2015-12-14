﻿#region Usings
using System.Data.Entity;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract.Core;
#endregion

namespace OS.DAL.EF.Core
{
    public class BaseCRUDRepository<TDbContext, TEntity, TEntityId> : BaseReadOnlyRepository<TDbContext, TEntity, TEntityId>,
        ICRUDRepository<TEntity, TEntityId>
        where TEntity : Entity<TEntityId>
        where TDbContext : DbContext
    {
        public BaseCRUDRepository(TDbContext entityFrameworkDbContext)
            : base(entityFrameworkDbContext)
        {
        }

        public TEntity Add(TEntity entity)
        {
            TEntity addedEntity = DbSet.Add(entity);
            EntityFrameworkDbContext.SaveChanges();
            return addedEntity;
        }

        public void Delete(params TEntityId[] id)
        {
            var entities = GetAll().Where(entity => id.Contains(entity.Id)).ToArray();
            Delete(entities);
        }

        public virtual void Delete(params TEntity[] entities)
        {
            DbSet.RemoveRange(entities);
            EntityFrameworkDbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            EntityFrameworkDbContext.Entry(entity).State = EntityState.Modified;
            EntityFrameworkDbContext.SaveChanges();
        }
    }
}
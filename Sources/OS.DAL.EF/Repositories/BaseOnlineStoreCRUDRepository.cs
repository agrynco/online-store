using System;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.EF.Core;

namespace OS.DAL.EF.Repositories
{
    public class BaseOnlineStoreCRUDRepository<TEntity, TEntityId> : BaseCRUDRepository<EntityFrameworkDbContext, TEntity, TEntityId>
        where TEntity: class, IEntity<TEntityId>
    {
        public BaseOnlineStoreCRUDRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public override void Delete(params TEntity[] entities)
        {
            foreach (TEntity entity in entities)
            {
                entity.IsDeleted = true;
                entity.Deleted = DateTime.UtcNow;
                Update(entity);
            }
        }

        public override IQueryable<TEntity> GetAll()
        {
            return GetAll(false);
        }

        public IQueryable<TEntity> GetAll(bool includeDeleted)
        {
            return base.GetAll().Where(entity => includeDeleted || entity.IsDeleted == false);
        }

        public override void Update(TEntity entity)
        {
            entity.Updated = DateTime.UtcNow;
            base.Update(entity);
        }
    }

    public class BaseOnlineStoreCRUDRepository<TEntity> : BaseOnlineStoreCRUDRepository<TEntity, int> 
        where TEntity : Entity<int>
    {
        public BaseOnlineStoreCRUDRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
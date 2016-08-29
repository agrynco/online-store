using System;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;
using OS.DAL.EF.Core;

namespace OS.DAL.EF.Repositories
{
    public class OnlineStoreCRUDRepository<TEntity, TEntityId> : BaseCRUDRepository<EntityFrameworkDbContext, TEntity, TEntityId>,
        IOnlineStoreCRUDRepository<TEntity, TEntityId>
        where TEntity : class, IEntity<TEntityId>
    {
        public OnlineStoreCRUDRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public void Delete(bool permanently, params TEntity[] entities)
        {
            if (!permanently)
            {
                foreach (TEntity entity in entities)
                {
                    entity.IsDeleted = true;
                    entity.Deleted = DateTime.UtcNow;
                    Update(entity);
                }
            }
            else
            {
                Delete(entities);
            }
        }

        public void Delete(bool permanently, params TEntityId[] entityIds)
        {
            Delete(permanently, GetAll(true).Where(entity => entityIds.Contains(entity.Id)).ToArray());
        }

        public override IQueryable<TEntity> GetAll()
        {
            return GetAll(false);
        }

        public IQueryable<TEntity> GetAll(bool includeDeleted)
        {
            return base.GetAll().Where(entity => includeDeleted || entity.IsDeleted == false);
        }

        public override void Update(TEntity entity, bool save = true)
        {
            entity.Updated = DateTime.UtcNow;
            base.Update(entity, save);
        }
    }

    public class OnlineStoreCRUDRepository<TEntity> : OnlineStoreCRUDRepository<TEntity, int>
        where TEntity : Entity<int>
    {
        public OnlineStoreCRUDRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
#region Usings
using System.Data.Entity;
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
        public BaseCRUDRepository(TDbContext dbContext)
            : base(dbContext)
        {
        }

        public TEntity Add(TEntity entity)
        {
            TEntity addedEntity = DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();
            return addedEntity;
        }

        public void Delete(TEntityId id)
        {
            TEntity entity = GetById(id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
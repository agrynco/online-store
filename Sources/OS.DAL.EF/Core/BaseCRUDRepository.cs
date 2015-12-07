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
        public BaseCRUDRepository(TDbContext entityFrameworkDbContext)
            : base(entityFrameworkDbContext)
        {
        }

        public TEntity Add(TEntity entity)
        {
            TEntity addedEntity = EntityFrameworkDbContext.Set<TEntity>().Add(entity);
            EntityFrameworkDbContext.SaveChanges();
            return addedEntity;
        }

        public void Delete(TEntityId id)
        {
            TEntity entity = GetById(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            EntityFrameworkDbContext.Set<TEntity>().Remove(entity);
            EntityFrameworkDbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            EntityFrameworkDbContext.Set<TEntity>().Attach(entity);
            EntityFrameworkDbContext.Entry(entity).State = EntityState.Modified;
            EntityFrameworkDbContext.SaveChanges();
        }
    }
}
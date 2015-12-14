#region Usings
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using OS.Business.Domain;
using OS.DAL.Abstract.Core;
#endregion

namespace OS.DAL.EF.Core
{
    public class BaseReadOnlyRepository<TDbContext, TEntity, TEntityId> : BaseRepository<TDbContext>, IReadOnlyRepository<TEntity, TEntityId>
        where TEntity : Entity<TEntityId>
        where TDbContext : DbContext
    {
        public BaseReadOnlyRepository(TDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
            DbSet = EntityFrameworkDbContext.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; private set; }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = EntityFrameworkDbContext.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).AsQueryable();
            }

            return query.AsQueryable();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return EntityFrameworkDbContext.Set<TEntity>().AsQueryable();
        }

        public virtual TEntity GetById(TEntityId id)
        {
            return EntityFrameworkDbContext.Set<TEntity>().Find(id);
        }
    }
}
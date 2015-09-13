#region Usings
using System;
using System.Linq;
using System.Linq.Expressions;
using OS.Business.Domain;
#endregion

namespace OS.DAL.Abstract.Core
{
    public interface IReadOnlyRepository<TEntity, TEntityId> where TEntity : Entity<TEntityId>
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IQueryable<TEntity> GetAll();
        TEntity GetById(TEntityId id);
    }
}
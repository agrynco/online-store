using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract.Core;

namespace OS.DAL.Abstract
{
    public interface IOnlineStoreCRUDRepository<TEntity, TEntityId> : ICRUDRepository<TEntity, TEntityId>
        where TEntity : class, IEntity<TEntityId>
    {
        void Delete(bool permanently, params TEntity[] entities);
        void Delete(bool permanently, params TEntityId[] entityIds);
        IQueryable<TEntity> GetAll(bool includeDeleted);
    }
    public interface IOnlineStoreRepository<TEntity> : IOnlineStoreCRUDRepository<TEntity, int> where TEntity : class, IEntity<int>
    {
    }
}
#region Usings
using OS.Business.Domain;
#endregion

namespace OS.DAL.Abstract.Core
{
    public interface ICRUDRepository<TEntity, TEntityId> : IReadOnlyRepository<TEntity, TEntityId> where TEntity : IEntity<TEntityId>
    {
        TEntity Add(TEntity entity);
        void Delete(params TEntityId[] id);
        void Delete(params TEntity[] entities);
        void Update(TEntity entity);
    }
}
#region Usings
using OS.Business.Domain;
#endregion

namespace OS.DAL.Abstract.Core
{
    public interface ICRUDRepository<TEntity, TEntityId> : IReadOnlyRepository<TEntity, TEntityId> where TEntity : Entity<TEntityId>
    {
        TEntity Add(TEntity entity);
        void Delete(TEntityId id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
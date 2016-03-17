using OS.Business.Domain;
using OS.DAL.Abstract.Core;

namespace OS.DAL.Abstract
{
    public interface IOnlineStoreRepository<TEntity> : ICRUDRepository<TEntity, int> where TEntity : IEntity<int>
    {
    }
}
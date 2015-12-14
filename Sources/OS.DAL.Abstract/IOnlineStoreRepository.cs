#region Usings
using OS.Business.Domain;
using OS.DAL.Abstract.Core;
#endregion

namespace OS.DAL.Abstract
{
    public interface IOnlineStoreRepository<TEntity> : ICRUDRepository<TEntity, int> where TEntity : Entity<int>
    {
    }
}
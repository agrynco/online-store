using OS.Business.Domain;

namespace OS.DAL.Abstract
{
    public interface INamedEntitiesRepository<TNamedEntity> : IOnlineStoreRepository<TNamedEntity> where TNamedEntity : NamedEntity
    {
        TNamedEntity GetByName(string name);
    }
}
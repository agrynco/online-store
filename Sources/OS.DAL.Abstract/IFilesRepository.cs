#region Usings
using OS.Business.Domain;
#endregion

namespace OS.DAL.Abstract
{
    public interface IFilesRepository : IOnlineStoreRepository<File>
    {
    }
}
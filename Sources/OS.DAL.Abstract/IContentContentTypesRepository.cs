#region Usings
using OS.Business.Domain;
#endregion

namespace OS.DAL.Abstract
{
    public interface IContentContentTypesRepository : IOnlineStoreRepository<ContentContentType>
    {
        ContentContentType Get(int contentId, int contentTypeId);
    }
}
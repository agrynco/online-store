using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class ContentContentTypesRepository : BaseOnlineStoreCRUDRepository<ContentContentType>, IContentContentTypesRepository
    {
        public ContentContentTypesRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public ContentContentType Get(int contentId, int contentTypeId)
        {
            return GetAll().Single(contentContentType => contentContentType.ContentId == contentId && contentContentType.ContentTypeId == contentTypeId);
        }
    }
}
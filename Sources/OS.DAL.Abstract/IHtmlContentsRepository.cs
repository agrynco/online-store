using OS.Business.Domain;

namespace OS.DAL.Abstract
{
    public interface IHtmlContentsRepository : IOnlineStoreRepository<HtmlContent>
    {
        HtmlContent GetByCode(HtmlContentCode htmlContentCode);
    }
}
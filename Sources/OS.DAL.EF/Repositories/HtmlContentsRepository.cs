using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class HtmlContentsRepository : OnlineStoreCrudRepository<HtmlContent>, IHtmlContentsRepository
    {
        public HtmlContentsRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public HtmlContent GetByCode(HtmlContentCode htmlContentCode)
        {
            return DbSet.SingleOrDefault(entity => entity.Code == htmlContentCode);
        }
    }
}
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class TextContentsRepository : OnlineStoreCRUDRepository<TextContent>, ITextContentsRepository {
        public TextContentsRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
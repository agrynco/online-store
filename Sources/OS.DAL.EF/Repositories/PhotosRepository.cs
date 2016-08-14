using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class PhotosRepository : OnlineStoreCRUDRepository<Photo>, IPhotosRepository
    {
        public PhotosRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
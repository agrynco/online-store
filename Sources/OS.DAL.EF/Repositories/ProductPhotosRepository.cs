using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class ProductPhotosRepository : OnlineStoreCRUDRepository<ProductPhoto>, IProductPhotosRepository
    {
        public ProductPhotosRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
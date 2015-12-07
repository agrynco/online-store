using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class ProductsRepository : BaseOnlineStoreCRUDRepository<Product>, IProductsRepository
    {
        public ProductsRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
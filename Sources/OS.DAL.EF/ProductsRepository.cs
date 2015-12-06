using OS.Business.Domain;
using OS.DAL.Abstract;
using OS.DAL.EF.Core;

namespace OS.DAL.EF
{
    public class ProductsRepository : BaseCRUDRepository<EntityFrameworkDbContext, Product, int>, IProductsRepository
    {
        public ProductsRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
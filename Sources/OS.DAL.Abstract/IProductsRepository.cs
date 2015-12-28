#region Usings
using System.Linq;
using OS.Business.Domain;
#endregion

namespace OS.DAL.Abstract
{
    public interface IProductsRepository : IOnlineStoreRepository<Product>
    {
        IQueryable<Product> Get(ProductsFilter filter);
    }
}
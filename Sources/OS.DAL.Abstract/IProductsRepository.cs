#region Usings
using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
#endregion

namespace OS.DAL.Abstract
{
    public interface IProductsRepository : IOnlineStoreRepository<Product>
    {
        IQueryable<Product> Get(ProductsFilter filter);
        IQueryable<Product> GetByIds(IEnumerable<int> ids);
        IQueryable<Product> SearchByFilter(ProductsFilter filter);
        Product GetByCode(string code);
    }
}
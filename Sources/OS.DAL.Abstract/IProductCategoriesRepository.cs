#region Usings
using System.Linq;
using OS.Business.Domain;
#endregion

namespace OS.DAL.Abstract
{
    public interface IProductCategoriesRepository : IOnlineStoreRepository<ProductCategory>
    {
        IQueryable<ProductCategory> GetCategories(int? parentId);
    }
}
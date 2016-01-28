using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;

namespace OS.DAL.Abstract
{
    public interface IProductCategoriesRepository : IOnlineStoreRepository<ProductCategory>
    {
        IQueryable<ProductCategory> GetCategories(int? parentId);
        IQueryable<ProductCategory> SearchCategories(string searchTerm);
        IList<ProductCategory> GetParentCategories(int categoryId);
        IQueryable<ProductCategory> SearchByFilter(ProductCategoriesFilter filter);
    }
}
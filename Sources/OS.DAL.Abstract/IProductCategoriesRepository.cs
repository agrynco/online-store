using System;
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
        IList<ProductCategory> GetCategories(int? parentId, int[] orders, bool isDeleted);
        IQueryable<ProductCategory> SearchByFilter(ProductCategoriesFilter filter);
        int? GetParentId(int id);
        void IterateFromDownToUp(int id, Action<ProductCategory> action);
        int GetMaxOrder(int? parentId, bool isDeleted);
    }
}
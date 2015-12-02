#region Usings
using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;
#endregion

namespace OS.Business.Logic
{
    public class ProductCategoriesBL
    {
        private readonly IOnlineStoreDbContext _onlineStoreDbContext;

        public ProductCategoriesBL(IOnlineStoreDbContext onlineStoreDbContext)
        {
            _onlineStoreDbContext = onlineStoreDbContext;
        }

        public IList<ProductCategory> GetCategories(int? parentId)
        {
            return _onlineStoreDbContext.CategoriesRepository.GetCategories(parentId).ToList();
        }

        public ProductCategory GetCategory(int id)
        {
            return _onlineStoreDbContext.CategoriesRepository.GetById(id);
        }
    }
}
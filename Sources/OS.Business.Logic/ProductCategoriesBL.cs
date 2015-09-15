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

        public IList<ProductCategory> GetRootCategories()
        {
            return _onlineStoreDbContext.CategoriesRepository.GetRootCategories().ToList();
        }
    }
}
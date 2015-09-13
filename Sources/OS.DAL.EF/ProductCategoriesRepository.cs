#region Usings
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;
using OS.DAL.EF.Core;
#endregion

namespace OS.DAL.EF
{
    public class ProductCategoriesRepository : BaseCRUDRepository<OnlineStoreDbContext, ProductCategory, int>, IProductCategoriesRepository
    {
        public ProductCategoriesRepository(OnlineStoreDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<ProductCategory> GetRootCategories()
        {
            return DbContext.ProductCategories.Where(productCategory => productCategory.Parent == null);
        }
    }
}
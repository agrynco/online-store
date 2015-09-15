#region Usings
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;
using OS.DAL.EF.Core;
#endregion

namespace OS.DAL.EF
{
    public class ProductCategoriesRepository : BaseCRUDRepository<EntityFrameworkDbContext, ProductCategory, int>, IProductCategoriesRepository
    {
        public ProductCategoriesRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public IQueryable<ProductCategory> GetRootCategories()
        {
            return EntityFrameworkDbContext.ProductCategories.Where(productCategory => productCategory.Parent == null);
        }
    }
}
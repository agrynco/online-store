#region Usings
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;
#endregion

namespace OS.DAL.EF.Repositories
{
    public class ProductCategoriesRepository : BaseOnlineStoreCRUDRepository<ProductCategory>, IProductCategoriesRepository
    {
        public ProductCategoriesRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public IQueryable<ProductCategory> GetCategories(int? parentId)
        {
            return EntityFrameworkDbContext.ProductCategories.Where(productCategory => productCategory.ParentId == parentId);
        }
    }
}
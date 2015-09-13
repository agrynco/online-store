#region Usings
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract.Core;
#endregion

namespace OS.DAL.Abstract
{
    public interface IProductCategoriesRepository : ICRUDRepository<ProductCategory, int>
    {
        IQueryable<ProductCategory> GetRootCategories();
    }
}
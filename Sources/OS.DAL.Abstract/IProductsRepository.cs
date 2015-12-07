#region Usings
using OS.Business.Domain;
using OS.DAL.Abstract.Core;
#endregion

namespace OS.DAL.Abstract
{
    public interface IProductsRepository : ICRUDRepository<Product, int>
    {
    }
}
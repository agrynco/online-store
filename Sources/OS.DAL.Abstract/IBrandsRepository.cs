using OS.Business.Domain;
using OS.DAL.Abstract.Core;

namespace OS.DAL.Abstract
{
    public interface IBrandsRepository : ICRUDRepository<Brand, int>
    {
    }
}
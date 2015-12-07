using OS.Business.Domain;
using OS.DAL.Abstract.Core;

namespace OS.DAL.Abstract
{
    public interface ICountriesRepository : ICRUDRepository<Country, int>
    {
    }
}
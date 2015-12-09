#region Usings
using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
using OS.Business.Logic.Exceptions;
using OS.DAL.Abstract;
#endregion

namespace OS.Business.Logic
{
    public class BrandsBL
    {
        private readonly IBrandsRepository _brandsRepository;

        public BrandsBL(IBrandsRepository brandsRepository)
        {
            _brandsRepository = brandsRepository;
        }

        public List<Brand> Find(string searchTerm)
        {
            return _brandsRepository.GetAll().Where(brand => brand.Name.Contains(searchTerm)).ToList();
        }

        public Brand GetByName(string name)
        {
            Brand result = _brandsRepository.GetAll().SingleOrDefault(brand => brand.Name == name);

            if (result == null)
            {
                throw new ThereIsNoBrandWithNameException(name);
            }

            return result;
        }
    }
}
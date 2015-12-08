using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;

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
    }
}
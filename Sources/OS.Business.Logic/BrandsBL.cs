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

        public PagedBrandListResult Find(BrandsFilter filter)
        {
            IQueryable<Brand> query = _brandsRepository.GetAll().OrderBy(x => x.Name);

            PagedBrandListResult result = new PagedBrandListResult();
            if (filter != null && !string.IsNullOrEmpty(filter.SearchTerm))
            {
                query = query.Where(x => x.Name.Contains(filter.SearchTerm));
            }

            result.TotalRecords = query.Count();
            result.Entities.AddRange(query.Skip((filter.PaginationFilter.PageNumber - 1) * filter.PaginationFilter.PageSize).Take(filter.PaginationFilter.PageSize));

            return result;
        }

        public Brand GetById(int id)
        {
            return _brandsRepository.GetById(id);
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

        public void Update(Brand brand)
        {
            _brandsRepository.Update(brand);
        }

        public void Add(Brand brand)
        {
            _brandsRepository.Add(brand);
        }

        public void Delete(int id)
        {
            _brandsRepository.Delete(id);
        }
    }
}
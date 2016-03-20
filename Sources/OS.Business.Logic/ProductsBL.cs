using System;
using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class ProductsBL
    {
        private readonly IProductsRepository _productsRepository;
        
        public ProductsBL(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public PagedProductListResult Get(ProductsFilter filter)
        {
            IQueryable<Product> query = _productsRepository.Get(filter).OrderBy(entity => entity.Name);

            PagedProductListResult result = new PagedProductListResult();
            result.TotalRecords = query.Count();
            result.Entities.AddRange(query.Skip(filter.PaginationFilter.PageNumber * filter.PaginationFilter.PageSize).Take(filter.PaginationFilter.PageSize));

            return result;
        }

        public void Create(Product product)
        {
            _productsRepository.Add(product);
        }

        public Product GetById(int id)
        {
            return _productsRepository.GetById(id);
        }

        public List<Product> GetByIds(IEnumerable<int> ids)
        {
            return _productsRepository.GetByIds(ids).ToList();
        } 

        public void Update(Product product)
        {
            _productsRepository.Update(product);
        }

        public void Delete(int productId)
        {
            Product product = _productsRepository.GetById(productId);
            _productsRepository.Delete(product);
        }

        public Product GetByCode(string code)
        {
            return _productsRepository.GetByCode(code);
        }
    }
}
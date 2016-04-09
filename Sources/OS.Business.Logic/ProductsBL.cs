using System;
using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
using OS.Business.Logic.Exceptions;
using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class ProductsBL
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IProductPhotosRepository _productPhotosRepository;

        public ProductsBL(IProductsRepository productsRepository, IProductPhotosRepository productPhotosRepository)
        {
            _productsRepository = productsRepository;
            _productPhotosRepository = productPhotosRepository;
        }

        public PagedProductListResult Get(ProductsFilter filter)
        {
            IQueryable<Product> query = _productsRepository.Get(filter).OrderBy(entity => entity.Name);

            PagedProductListResult result = new PagedProductListResult();
            result.TotalRecords = query.Count();
            result.Entities.AddRange(query.Skip(filter.PaginationFilter.PageNumber * filter.PaginationFilter.PageSize).Take(filter.PaginationFilter.PageSize));

            return result;
        }

        public Product GetByName(string name)
        {
            return _productsRepository.GetByName(name);
        }

        public void DeletePermanently(int productId)
        {
            Product product = _productsRepository.GetById(productId);
            if (!product.IsDeleted)
            {
                throw new CanNotDeletePermanentlyNotMarkedToDeleteException(product);
            }

            _productPhotosRepository.Delete(true, product.Photos.ToArray());
            _productsRepository.Delete(true, productId);
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
            _productsRepository.Delete(false, product);
        }

        public Product GetByCode(string code)
        {
            return _productsRepository.GetByCode(code);
        }
    }
}
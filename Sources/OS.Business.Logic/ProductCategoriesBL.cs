#region Usings
using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;
#endregion

namespace OS.Business.Logic
{
    public class ProductCategoriesBL
    {
        private readonly IProductCategoriesRepository _productCategoriesRepository;

        public ProductCategoriesBL(IProductCategoriesRepository productCategoriesRepository)
        {
            _productCategoriesRepository = productCategoriesRepository;
        }

        public List<ProductCategory> GetCategories(int? parentId)
        {
            return _productCategoriesRepository.GetCategories(parentId).OrderBy(x => x.Name).ToList();
        }

        public List<ProductCategory> SearchCategories(string searchTerm)
        {
            return _productCategoriesRepository.SearchCategories(searchTerm).OrderBy(x => x.Name).ToList();
        }

        /// <summary>
        /// Returns full path to the root
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>List of the <see cref="ProductCategory"/>First category is on the upper level</returns>
        public List<ProductCategory> GetParentCategories(int categoryId)
        {
            return _productCategoriesRepository.GetParentCategories(categoryId).OrderBy(category => category.Name).ToList();
        }

        public ProductCategory GetById(int id)
        {
            return _productCategoriesRepository.GetById(id);
        }

        public PagedProductCategoryListResult SearchByFilter(ProductCategoriesFilter filter)
        {
            IQueryable<ProductCategory> query = _productCategoriesRepository.SearchByFilter(filter).OrderBy(entity => entity.Name);

            PagedProductCategoryListResult result = new PagedProductCategoryListResult();
            result.TotalRecords = query.Count();
            result.Entities.AddRange(query.Skip(filter.PaginationFilter.PageNumber * filter.PaginationFilter.PageSize).Take(filter.PaginationFilter.PageSize));

            return result;
        }

        public void Update(ProductCategory productCategory)
        {
            _productCategoriesRepository.Update(productCategory);
        }

        public void Create(ProductCategory productCategory)
        {
            _productCategoriesRepository.Add(productCategory);
        }

        public void Delete(int categoryId)
        {
            _productCategoriesRepository.Delete(categoryId);
        }

        public void Add(Product product, ProductCategory owner)
        {
            if (!product.Categories.Contains(owner))
            {
                product.Categories.Add(owner);
            }
        }

        public int? GetParentId(int id)
        {
            return _productCategoriesRepository.GetParentId(id);
        }
    }
}
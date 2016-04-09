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
        private readonly IProductsRepository _productsRepository;

        public ProductCategoriesBL(IProductCategoriesRepository productCategoriesRepository, IProductsRepository productsRepository)
        {
            _productCategoriesRepository = productCategoriesRepository;
            _productsRepository = productsRepository;
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
            return _productCategoriesRepository.GetParentCategories(categoryId).ToList();
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

        public void Delete(int id)
        {
            _productCategoriesRepository.IterateFromDownToUp(id, category => _productCategoriesRepository.Delete(false, category.Id));
        }

        public void SetPublish(int id, bool publish)
        {
            _productCategoriesRepository.IterateFromDownToUp(id, category =>
            {
                List<Product> products = _productsRepository.Get(new ProductsFilter
                    {
                        ParentId = id
                    }).ToList();

                foreach (Product product in products)
                {
                    product.Publish = publish;
                    _productsRepository.Update(product);
                }

                category.Publish = publish;
                _productCategoriesRepository.Update(category);
            });
        }

        public void Add(Product product, ProductCategory owner)
        {
            if (!product.Categories.Contains(owner))
            {
                product.Categories.Add(owner);
            }
        }
    }
}
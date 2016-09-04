#region Usings
using System;
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
            return _productCategoriesRepository.GetCategories(parentId).Where(category => !category.IsDeleted).OrderBy(x => x.Order).ToList();
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
            IQueryable<ProductCategory> query = _productCategoriesRepository.SearchByFilter(filter).OrderBy(entity => entity.Order);

            PagedProductCategoryListResult result = new PagedProductCategoryListResult();
            result.TotalRecords = query.Count();
            result.Entities.AddRange(query.Skip((filter.PaginationFilter.PageNumber - 1)* filter.PaginationFilter.PageSize).Take(filter.PaginationFilter.PageSize));

            return result;
        }

        public void Update(ProductCategory productCategory)
        {
            _productCategoriesRepository.Update(productCategory);
        }

        public void Create(ProductCategory productCategory)
        {
            int maxOrder = _productCategoriesRepository.GetMaxOrder(productCategory.ParentId, false);
            productCategory.Order = maxOrder + 1;
            _productCategoriesRepository.Add(productCategory);
        }

        public void Delete(int id)
        {
            _productCategoriesRepository.IterateFromDownToUp(id, category =>
            {
                List<Product> products = _productsRepository.Get(new ProductsFilter
                    {
                        ParentId = category.Id
                    }).ToList();

                products.ForEach(product => _productsRepository.Delete(false, product));

                int maxOrder = _productCategoriesRepository.GetMaxOrder(category.ParentId, true);
                category.Order = maxOrder + 1;
                category.IsDeleted = true;
                category.Deleted = DateTime.UtcNow;

                _productCategoriesRepository.Update(category);
            });
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

        public void Reorder(int? parentId, ProductCategoryReorderInfo[] productCategoryReorderInfos)
        {
            IList<ProductCategory> productCategories = _productCategoriesRepository.GetCategories(parentId, productCategoryReorderInfos.Select(x => x.OldOrder).ToArray(), false);

            List<ProductCategoryReorderInfo2Category> categoryReorderInfo2CategoryMappings = productCategories.Select(c => new ProductCategoryReorderInfo2Category
                {
                    CategoryReorderInfo = productCategoryReorderInfos.Single(x => x.OldOrder == c.Order),
                    ProductCategory = c
                }).ToList();

            ShiftOrdersOutOfLastOrder(parentId, false, productCategories);

            foreach (ProductCategoryReorderInfo2Category productCategoryReorderInfo2Category in categoryReorderInfo2CategoryMappings)
            {
                productCategoryReorderInfo2Category.ProductCategory.Order = productCategoryReorderInfo2Category.CategoryReorderInfo.NewOrder;
                _productCategoriesRepository.Update(productCategoryReorderInfo2Category.ProductCategory);
            }
        }

        private void ShiftOrdersOutOfLastOrder(int? parentId, bool isDeleted, IList<ProductCategory> productCategories)
        {
            int maxOrder = _productCategoriesRepository.GetMaxOrder(parentId, isDeleted);
            for (int i = 0; i < productCategories.Count; i++)
            {
                productCategories[i].Order = maxOrder + 1 + i;
                _productCategoriesRepository.Update(productCategories[i]);
            }
        }
    }
}
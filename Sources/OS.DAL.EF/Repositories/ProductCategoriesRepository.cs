#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;
#endregion

namespace OS.DAL.EF.Repositories
{
    public class ProductCategoriesRepository : OnlineStoreCrudRepository<ProductCategory>, IProductCategoriesRepository
    {
        public ProductCategoriesRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public IQueryable<ProductCategory> GetCategories(int? parentId)
        {
            return GetAll(true).Where(productCategory => productCategory.ParentId == parentId);
        }

        public IQueryable<ProductCategory> SearchCategories(string searchTerm)
        {
            IQueryable<ProductCategory> query = GetAll();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(entity => entity.Name.Contains(searchTerm));
            }

            return query;
        }

        public IList<ProductCategory> GetParentCategories(int categoryId)
        {
            ProductCategory category = GetById(categoryId);

            IList<ProductCategory> result = new List<ProductCategory>();

            int? parentId = category.ParentId;

            while (parentId != null)
            {
                ProductCategory parentCategory = GetById(parentId.Value);
                result.Insert(0, parentCategory);

                parentId = parentCategory.ParentId;
            }

            return result;
        }

        public IQueryable<ProductCategory> SearchByFilter(ProductCategoriesFilter filter)
        {
            IQueryable<ProductCategory> query = GetAll();

            if (!filter.IgnoreParentId)
            {
                query = query.Where(category => category.ParentId == filter.ParentId);
            }

            if (!filter.IncludeDeleted)
            {
                query = query.Where(category => !category.IsDeleted);
            }

            if (!string.IsNullOrEmpty(filter.Text))
            {
                query = query.Where(category => category.Name.Contains(filter.Text));
            }

            if (filter.Publish.HasValue)
            {
                query = query.Where(category => category.Publish == filter.Publish.Value);
            }

            return query;
        }

        public int? GetParentId(int id)
        {
            return GetById(id).ParentId;
        }
        
        public void IterateFromDownToUp(int id, Action<ProductCategory> action)
        {
            List<ProductCategory> productCategories = GetCategories(id).ToList();
            foreach (ProductCategory productCategory in productCategories)
            {
                IterateFromDownToUp(productCategory.Id, action);
                action(productCategory);
            }
            action(GetById(id));
        }
    }
}
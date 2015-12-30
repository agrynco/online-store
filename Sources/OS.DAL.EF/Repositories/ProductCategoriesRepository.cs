#region Usings
using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;
#endregion

namespace OS.DAL.EF.Repositories
{
    public class ProductCategoriesRepository : BaseOnlineStoreCRUDRepository<ProductCategory>, IProductCategoriesRepository
    {
        public ProductCategoriesRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public IQueryable<ProductCategory> GetCategories(int? parentId)
        {
            return GetAll().Where(productCategory => productCategory.ParentId == parentId);
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

        public IList<ProductCategory> SearchByFilter(ProductCategoriesFilter filter)
        {
            IQueryable<ProductCategory> query = GetAll();

            if (!filter.IgnoreParentId)
            {
                query = GetCategories(filter.ParentId);
            }

            if (!string.IsNullOrEmpty(filter.Text))
            {
                query = query.Where(category => category.Name.Contains(filter.Text));
            }

            return query.ToList();
        }
    }
}
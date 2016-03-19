using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class ProductsRepository : BaseOnlineStoreCRUDRepository<Product>, IProductsRepository
    {
        public ProductsRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public IQueryable<Product> Get(ProductsFilter filter)
        {
            IQueryable<Product> result = GetAll();

            if (filter != null)
            {
                if (filter.ParentId != null)
                {
                    result = result.Where(product => product.Categories.Any(category => category.Id == filter.ParentId.Value));
                }

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    result = result.Where(product => product.Name.Contains(filter.Text));
                }
            }

            return result;
        }

        public IQueryable<Product> GetByIds(IEnumerable<int> ids)
        {
            return DbSet.Where(product => ids.Contains(product.Id));
        }

        public IQueryable<Product> SearchByFilter(ProductsFilter filter)
        {
            IQueryable<Product> query = GetAll();

            if (filter.ParentId.HasValue)
            {
                query = query.Where(product => product.Categories.Select(category => category.Id).Contains(filter.ParentId.Value));
            }

            if (!string.IsNullOrEmpty(filter.Text))
            {
                query = query.Where(product => product.Name.Contains(filter.Text));
            }

            return query;
        }

        public Product GetByCode(string code)
        {
            return GetAll().SingleOrDefault(entity => entity.Code == code);
        }
    }
}
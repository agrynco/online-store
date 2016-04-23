using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class ProductsRepository : OnlineStoreCrudRepository<Product>, IProductsRepository
    {
        public ProductsRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public IQueryable<Product> Get(ProductsFilter filter)
        {
            IQueryable<Product> query = GetAll();

            if (filter != null)
            {
                if (filter.ParentId != null)
                {
                    query = query.Where(product => product.Categories.Any(category => category.Id == filter.ParentId.Value));
                }

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(product => product.Name.Contains(filter.Text));
                }

                if (filter.Publish.HasValue)
                {
                    query = query.Where(product => product.Publish == filter.Publish.Value);
                }

                if (filter.IsDeleted.HasValue)
                {
                    query = query.Where(product => product.IsDeleted == filter.IsDeleted.Value);
                }
            }

            return query;
        }

        public IQueryable<Product> GetByIds(IEnumerable<int> ids)
        {
            return DbSet.Where(product => ids.Contains(product.Id));
        }

        public Product GetByCode(string code)
        {
            return GetAll().SingleOrDefault(entity => entity.Code == code);
        }

        public Product GetByName(string name)
        {
            return GetAll(true).SingleOrDefault(entity => entity.Name == name);
        }
    }
}
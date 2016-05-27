using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public override IQueryable<Product> GetAll()
        {
            return base.GetAll().Include(product => product.MetaData);
        }

        public override Product GetById(int id)
        {
            return GetAll(true).SingleOrDefault(product => product.Id == id);
        }

        public IQueryable<Product> GetByIds(IEnumerable<int> ids)
        {
            return DbSet.Where(product => ids.Contains(product.Id)).Include(product => product.MetaData);
        }

        public Product GetByCode(string code)
        {
            return GetAll().SingleOrDefault(entity => entity.Code == code);
        }

        public Product GetByName(string name)
        {
            return GetAll(true).SingleOrDefault(entity => entity.Name == name);
        }

        public int UpdatePricesInMainCurrency()
        {
            Currency mainCurrency = EntityFrameworkDbContext.Currencies.SingleOrDefault(x => !x.IsDeleted && x.IsMain);
            if (mainCurrency == null)
            {
                throw new ArgumentNullException("There is no main currency in the system!");
            }
            var productsWithCurrencyRate = from product in DbSet
                join cr in
                    (from currencyRate in EntityFrameworkDbContext.CurrencyRates
                        where currencyRate.DateOfRate ==
                              (from currencyRate1 in EntityFrameworkDbContext.CurrencyRates select currencyRate1).Max(currencyRate1 => currencyRate1.DateOfRate)
                        select currencyRate) on product.CurrencyIdOfThePrice equals cr.CurrencyId
                select new {Product = product, CurrencyRate = cr};

            productsWithCurrencyRate.ToList().ForEach(x =>
            {
                x.Product.PriceInTheMainCurrency = x.Product.Price * x.CurrencyRate.Rate;
                Update(x.Product, false);
            });
            return EntityFrameworkDbContext.SaveChanges();
        }
    }
}
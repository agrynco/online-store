using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using OS.Business.Domain;
using OS.Business.Logic.Exceptions;
using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class ProductsBL
    {
        private readonly ICurrenciesRepository _currenciesRepository;
        private readonly ICurrencyRatesRepository _currencyRatesRepository;
        private readonly IProductPhotosRepository _productPhotosRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IProductViewingInfosRepository _productViewingInfosRepository;
        private readonly IUserHostAddressesRepository _userHostAddressesRepository;
        private readonly IUserStore<ApplicationUser> _usersStore;

        public ProductsBL(IProductsRepository productsRepository, IProductPhotosRepository productPhotosRepository,
            IUserHostAddressesRepository userHostAddressesRepository, IProductViewingInfosRepository productViewingInfosRepository,
            IUserStore<ApplicationUser> usersStore, ICurrenciesRepository currenciesRepository,
            ICurrencyRatesRepository currencyRatesRepository)
        {
            _productsRepository = productsRepository;
            _productPhotosRepository = productPhotosRepository;
            _userHostAddressesRepository = userHostAddressesRepository;
            _productViewingInfosRepository = productViewingInfosRepository;
            _usersStore = usersStore;
            _currenciesRepository = currenciesRepository;
            _currencyRatesRepository = currencyRatesRepository;
        }

        public PagedProductListResult Get(ProductsFilter filter)
        {
            IQueryable<Product> query = _productsRepository.Get(filter).OrderBy(entity => entity.Name);

            PagedProductListResult result = new PagedProductListResult();
            result.TotalRecords = query.Count();
            result.Entities.AddRange(query.Skip((filter.PaginationFilter.PageNumber - 1) * filter.PaginationFilter.PageSize).Take(filter.PaginationFilter.PageSize));

            return result;
        }

        public Product GetByName(string name)
        {
            return _productsRepository.GetByName(name);
        }

        public decimal CalculatePriceInTheMainCurrency(int currencyIdOfThePrice, decimal price)
        {
            return CalculatePriceInTheMainCurrency(currencyIdOfThePrice, price, DateTime.Now);
        }

        public void UpdatePricesInMainCurrency()
        {
            _productsRepository.UpdatePricesInMainCurrency();
        }

        public decimal CalculatePriceInTheMainCurrency(int currencyIdOfThePrice, decimal price, DateTime date)
        {
            Currency mainCurrency = _currenciesRepository.GetMainCurrency();
            if (currencyIdOfThePrice == mainCurrency.Id)
            {
                return price;
            }

            CurrencyRate currencyRate = _currencyRatesRepository.GetActualRate(currencyIdOfThePrice, date);
            return currencyRate.Rate * price;
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

        public Product GetById(int id, string userName, string ipAddress)
        {
            UserHostAddress userHostAddress = _userHostAddressesRepository.GetByUserHostAddress(ipAddress);
            if (userHostAddress == null)
            {
                userHostAddress = new UserHostAddress
                    {
                        IpAddress = ipAddress
                    };
                userHostAddress = _userHostAddressesRepository.Add(userHostAddress);
            }

            ApplicationUser applicationUser = !string.IsNullOrEmpty(userName) ? _usersStore.FindByNameAsync(userName).Result : null;

            ProductViewingInfo productViewingInfo = _productViewingInfosRepository.Get(id, userHostAddress.Id);
            if (productViewingInfo != null)
            {
                productViewingInfo.Count++;
                productViewingInfo.User = applicationUser;
                _productViewingInfosRepository.Update(productViewingInfo);
            }
            else
            {
                productViewingInfo = new ProductViewingInfo
                    {
                        UserHostAddress = userHostAddress,
                        ProductId = id,
                        Count = 1,
                        User = applicationUser
                    };

                _productViewingInfosRepository.Add(productViewingInfo);
            }

            return _productsRepository.GetById(id);
        }

        public List<ProductViewingInfo> GetProductViewingInfos()
        {
            return _productViewingInfosRepository.GetAll().ToList();
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
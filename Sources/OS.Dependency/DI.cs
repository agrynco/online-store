﻿#region Usings
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Configuration;
using OS.DAL.Abstract;
using OS.DAL.EF;
using OS.DAL.EF.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web;
#endregion

namespace OS.Dependency
{
    public static class DI
    {
        private static Container _container;

        public static void Configure(Container container)
        {
            _container = container;

            var lifeStyle = new WebRequestLifestyle();

            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(_container.GetInstance<EntityFrameworkDbContext>()));

            container.Register(() => new EntityFrameworkDbContext(ApplicationSettings.Instance.DbSettings.ApplicationConnectionString), lifeStyle);

            Register<IProductCategoriesRepository, ProductCategoriesRepository>(lifeStyle);
            Register<IOnlineStoreDbContext, OnlineStoreDbContext>(lifeStyle);
            Register<ProductCategoriesBL>(lifeStyle);

            Register<IProductsRepository, ProductsRepository>(lifeStyle);
            Register<ProductsBL>(lifeStyle);

            Register<ICountriesRepository, CountriesRepository>(lifeStyle);
            Register<CountriesBL>(lifeStyle);

            Register<IBrandsRepository, BrandsRepository>(lifeStyle);
            Register<BrandsBL>(lifeStyle);
        }

        private static void Register<TImplementation>(ScopedLifestyle lifestyle)
            where TImplementation : class
        {
            _container.Register<TImplementation>(lifestyle);
        }

        private static void Register<TService, TImplementation>(ScopedLifestyle lifestyle) 
            where TService : class 
            where TImplementation : class, TService
        {
            _container.Register<TService, TImplementation>(lifestyle);
        }

        public static T Resolve<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
    }
}
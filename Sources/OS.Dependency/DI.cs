#region Usings
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Configuration;
using OS.DAL.Abstract;
using OS.DAL.EF;
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

            container.Register<IProductCategoriesRepository, ProductCategoriesRepository>(lifeStyle);
            container.Register<IOnlineStoreDbContext, OnlineStoreDbContext>(lifeStyle);
            container.Register<ProductCategoriesBL>(lifeStyle);
            
        }

        public static T Resolve<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
    }
}
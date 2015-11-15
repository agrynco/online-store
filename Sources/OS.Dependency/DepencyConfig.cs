#region Usings
using OS.Business.Logic;
using OS.Configuration;
using OS.DAL.Abstract;
using OS.DAL.EF;
using SimpleInjector;
using SimpleInjector.Integration.Web;
#endregion

namespace OS.Dependency
{
    public static class DepencyConfig
    {
        public static void Configure(Container container)
        {
            var lifeStyle = new WebRequestLifestyle();

            container.Register(() => new EntityFrameworkDbContext(ApplicationSettings.Instance.DbSettings.ApplicationConnectionString), lifeStyle);
            container.Register<IProductCategoriesRepository, ProductCategoriesRepository>(lifeStyle);
            container.Register<IOnlineStoreDbContext, OnlineStoreDbContext>(lifeStyle);
            container.Register<ProductCategoriesBL>(lifeStyle);
        }
    }
}
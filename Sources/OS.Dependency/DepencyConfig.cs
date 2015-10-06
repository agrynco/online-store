using Ninject;
using OS.Business.Logic;
using OS.Configuration;
using OS.DAL.Abstract;
using OS.DAL.EF;

namespace OS.Dependency
{
    public static class DepencyConfig
    {
        public static void Configure(IKernel kernel)
        {
            kernel.Bind<EntityFrameworkDbContext>().ToSelf().WithConstructorArgument("nameOrConnectionString",
            ApplicationSettings.Instance.DbSettings.ApplicationConnectionString);
            kernel.Bind<IProductCategoriesRepository>().To<ProductCategoriesRepository>();
            kernel.Bind<IOnlineStoreDbContext>().To<OnlineStoreDbContext>();
            kernel.Bind<ProductCategoriesBL>().ToSelf();
        }
    }
}
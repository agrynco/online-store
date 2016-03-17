#region Usings
using System.Net;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Business.Logic.Mailing;
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
        private static bool _isConfigured;
        private static readonly Lifestyle _LIFE_STYLE = HttpContext.Current != null ? new WebRequestLifestyle() : Lifestyle.Singleton;

        public static Container Container
        {
            get
            {
                if (!_isConfigured)
                {
                    throw new OnlineStoreDependencyException("No one of methods \"Configure\" was called");
                }

                return _container;
            }
        }

        public static void Configure()
        {
            Container container = new Container();
            Configure(container);
        }

        public static void Configure(Container container)
        {
            _container = container;
            _isConfigured = true;

            _container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(_container.GetInstance<EntityFrameworkDbContext>()));

            _container.Register(() => new EntityFrameworkDbContext(ApplicationSettings.Instance.DbSettings.ApplicationConnectionString), _LIFE_STYLE);

            Register<IProductCategoriesRepository, ProductCategoriesRepository>();
            Register<IOnlineStoreDbContext, OnlineStoreDbContext>();
            Register<ProductCategoriesBL>();

            Register<IProductsRepository, ProductsRepository>();
            Register<ProductsBL>();

            Register<ICountriesRepository, CountriesRepository>();
            Register<CountriesBL>();

            Register<IBrandsRepository, BrandsRepository>();
            Register<BrandsBL>();

            Register<IFilesRepository, FilesRepository>();
            Register<FilesBL>();

            Register<IContentsRepository, ContentsRepository>();
            Register<ContentsBl>();

            Register<IContentTypesRepository, ContentTypesRepository>();

            Register<IContentContentTypesRepository, ContentContentTypesRepository>();
            Register<ContentContentTypesBL>();

            Register<IProductPhotosRepository, ProductPhotosRepository>();
            Register<ProductPhotosBL>();

            Register<IContactInfosRepository, ContactInfosRepository>();
            Register<ContactInfoBL>();

            Register<IOrdersRepository, OrdersRepository>();
            Register<OrdersBL>();

            Register<IPersonsRepository, PersonsRepository>();

            Register<IOrderStatusHistoryItemsRepository, OrderStatusHistoryItemsRepository>();

            Register<IOrderedProductsRepository, OrderedProductsRepository>();

            Register<IUsersRepository, UsersRepository>();

            _container.Register<IMailService>(() => new MailService(
                ApplicationSettings.Instance.MailServiceSettings.Host,
                ApplicationSettings.Instance.MailServiceSettings.Port,
                ApplicationSettings.Instance.MailServiceSettings.EnableSsl,
                new NetworkCredential
                    {
                        UserName = ApplicationSettings.Instance.MailServiceSettings.FromAddress,
                        Password = ApplicationSettings.Instance.MailServiceSettings.FromPassword
                    }), _LIFE_STYLE);
        }

        public static void Register<TImplementation>()
            where TImplementation : class
        {
            Container.Register<TImplementation>(_LIFE_STYLE);
        }

        private static void Register<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            Container.Register<TService, TImplementation>(_LIFE_STYLE);
        }

        public static T Resolve<T>() where T : class
        {
            if (!_isConfigured)
            {
                Configure();
            }

            return _container.GetInstance<T>();
        }
    }
}
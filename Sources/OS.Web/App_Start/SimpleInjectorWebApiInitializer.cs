#region Usings
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using OS.Business.Domain;
using OS.DAL.EF;
using OS.Dependency;
using OS.Web.App_Start;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using WebActivator;
#endregion

[assembly: PostApplicationStartMethod(typeof (SimpleInjectorWebApiInitializer), "Initialize")]

namespace OS.Web.App_Start
{
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers();
            //container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            //container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            DI.Configure(container);

            //container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(applicationDbContext), new WebRequestLifestyle());

            container.RegisterPerWebRequest<UserManager<ApplicationUser, string>>(
                () => new UserManager<ApplicationUser, string>(new UserStore<ApplicationUser>(DI.Resolve<EntityFrameworkDbContext>())));

            container.Register<IAuthenticationManager>(() =>
                AdvancedExtensions.IsVerifying(container)
                    ? new OwinContext(new Dictionary<string, object>()).Authentication
                    : HttpContext.Current.GetOwinContext().Authentication);
        }
    }
}
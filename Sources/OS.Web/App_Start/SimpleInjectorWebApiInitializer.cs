using System.Web.Mvc;
using OS.Dependency;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
[assembly: WebActivator.PostApplicationStartMethod(typeof(OS.Web.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace OS.Web.App_Start
{
    using SimpleInjector;
    
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
       
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
//            GlobalConfiguration.Configuration.DependencyResolver =
//                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            DepencyConfig.Configure(container);
        }
    }
}
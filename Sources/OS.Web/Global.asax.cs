#region Usings
using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using OS.Configuration;
using Serilog;
using Serilog.Exceptions;
#endregion

namespace OS.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("ApplicationName", ApplicationSettings.Instance.AppSettings.ApplicationName)
                .Enrich.WithProperty("Environment", ApplicationSettings.Instance.AppSettings.Environment)
                .Enrich.WithMachineName()
                .Enrich.WithProcessId()
                .Enrich.WithThreadId()
                //.Enrich.WithExceptionDetails()
                .WriteTo.Seq(ApplicationSettings.Instance.AppSettings.SeqUrl)
                .CreateLogger();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        { 
        }

        protected void Application_EndRequest()
        {
            //if (Context.Response.StatusCode == 404)
            //{
            //    Response.Clear();

            //    var routeData = new RouteData();
            //    //rd.DataTokens["area"] = "AreaName"; // In case controller is in another area
            //    routeData.Values["controller"] = "ErrorsController";
            //    routeData.Values["action"] = "Index";

            //    IController controller = new ErrorsController();
            //    controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
            //}
        }
    }
}
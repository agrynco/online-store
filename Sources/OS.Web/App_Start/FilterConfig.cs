using System.Web.Mvc;
using Serilog;

namespace OS.Web
{
    public class OnlineStoreHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            bool exceptionHandled = filterContext.ExceptionHandled;

            base.OnException(filterContext);
            if (!exceptionHandled)
            {
                var controllerName = (string) filterContext.RouteData.Values["controller"];
                var actionName = (string) filterContext.RouteData.Values["action"];
                //var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                Log.Error("{@ExceptionDetails}", new
                    {
                        Controller = controllerName,
                        Action = actionName,
                        ExceptionMessage = filterContext.Exception.Message,
                        filterContext.Exception.StackTrace,
                        filterContext.Exception.Source
                    });
            }
        }
    }

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new OnlineStoreHandleErrorAttribute());
        }
    }
}
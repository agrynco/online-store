using System.Web.Mvc;
using Elmah;

namespace OS.Web
{
    public class ElmahHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var exceptionHandled = filterContext.ExceptionHandled;

            base.OnException(filterContext);

            // signal ELMAH to log the exception
            if (!exceptionHandled && filterContext.ExceptionHandled)
                ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);
        }
    }

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ElmahHandleErrorAttribute());
        }
    }
}
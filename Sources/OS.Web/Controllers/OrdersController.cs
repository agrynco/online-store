using System.Web.Mvc;
using OS.Business.Logic;

namespace OS.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrdersBL _ordersBL;

        public OrdersController(OrdersBL ordersBL)
        {
            _ordersBL = ordersBL;
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}
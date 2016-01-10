using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using OS.Business.Logic;
using OS.Web.Models;

namespace OS.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrdersBL _ordersBL;

        public OrdersController(OrdersBL ordersBL)
        {
            _ordersBL = ordersBL;
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(EditOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpCookie consumerBasketRawDataCookie = Request.Cookies["ConsumerBasket"];
                
                List<ProductInBasketViewModel> productInBasketViewModels = JsonConvert.DeserializeObject<List<ProductInBasketViewModel>>(
                    HttpContext.Server.UrlDecode(consumerBasketRawDataCookie.Value));

                _ordersBL.CreateOrder(new CreateOrderQuery
                    {
                        Person = new CreateOrderQuery.AddPersonQuery
                            {
                                Email = model.Email,
                                MiddleName = model.MiddleName,
                                LastName = model.LastName,
                                PhoneNumber = model.PhoneNumber,
                                FirstName = model.FirstName
                            },
                        OrderedProducts = new List<CreateOrderQuery.AddOrderedProductQuery>(
                            productInBasketViewModels.Select(
                                p => new CreateOrderQuery.AddOrderedProductQuery
                                    {
                                        ProductId  = p.Id,
                                        Quantity = p.Quantity
                                    }).ToList())
                    });

                return RedirectToAction("OrderDetails");
            }

            return View(model);
        }

        public ActionResult OrderDetails()
        {
            HttpCookie cookie = new HttpCookie("ConsumerBasket");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Set(cookie);

            return View();
        }
    }
}
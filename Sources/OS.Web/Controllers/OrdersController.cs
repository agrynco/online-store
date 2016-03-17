using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Web.Models;
using OS.Web.Models.MailTempplateModels;
using RazorEngine;

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
        public ActionResult Create()
        {
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Create(EditOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpCookie consumerBasketRawDataCookie = Request.Cookies["ConsumerBasket"];

                List<ProductInBasketViewModel> productInBasketViewModels = JsonConvert.DeserializeObject<List<ProductInBasketViewModel>>(
                    HttpContext.Server.UrlDecode(consumerBasketRawDataCookie.Value));

                Order order = _ordersBL.CreateOrder(new CreateOrderQuery
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
                                        ProductId = p.Id,
                                        Quantity = p.Quantity
                                    }).ToList())
                    });
                TempData[Constants.TempDataKeys.ORDER_ID] = order.Id;
                return RedirectToAction("OrderDetails", new {orderId = order.Id});
            }

            return View("Edit", model);
        }

        public ActionResult OrderDetails(int orderId)
        {
            HttpCookie cookie = new HttpCookie("ConsumerBasket");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Set(cookie);

            if (TempData[Constants.TempDataKeys.ORDER_ID] != null)
            {
                orderId = (int) TempData[Constants.TempDataKeys.ORDER_ID];
            }

            Order order = _ordersBL.GetById(orderId);
            OrderDetailsViewModel viewModel = new OrderDetailsViewModel
                {
                    Order = order
                };

            return View(viewModel);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Web.Models;

namespace OS.Web.Controllers
{
    public class ConsumerBasketController : Controller
    {
        private readonly ProductsBL _productsBL;

        public ConsumerBasketController(ProductsBL productsBL)
        {
            _productsBL = productsBL;
        }

        public ActionResult Index()
        {
            HttpCookie consumerBasketRawDataCookie = Request.Cookies["ConsumerBasket"];

            ConsumerBasketViewModel consumerBasketViewModel = new ConsumerBasketViewModel();

            if (consumerBasketRawDataCookie != null)
            {
                List<ProductInBasketViewModel> productInBasketViewModels = JsonConvert.DeserializeObject<List<ProductInBasketViewModel>>(
                    HttpContext.Server.UrlDecode(consumerBasketRawDataCookie.Value));
            
                List<Product> products = _productsBL.GetByIds(productInBasketViewModels.Select(x => x.Id));

                consumerBasketViewModel.ProductToByDescriptors.AddRange(products.Select(product =>
                {
                    ProductInBasketViewModel productInBasketViewModel = productInBasketViewModels.Single(x => x.Id == product.Id);
                    return new ProductToBuyDescriptor
                        {
                            Product = product,
                            Quantity = productInBasketViewModel.Quantity,
                            CategoryId = productInBasketViewModel.CategoryId
                        };
                }));
            }
            
            return View(consumerBasketViewModel);
        }
    }
}
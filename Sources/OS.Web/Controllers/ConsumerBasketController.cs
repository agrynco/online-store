using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Index(string consumerBasketProductIds)
        {
            List<ProductInBasketViewModel> productInBasketViewModels = JsonConvert.DeserializeObject<List<ProductInBasketViewModel>>(consumerBasketProductIds);

            ConsumerBasketViewModel consumerBasketViewModel = new ConsumerBasketViewModel();

            if (!string.IsNullOrEmpty(consumerBasketProductIds))
            {
                List<Product> products = _productsBL.GetByIds(productInBasketViewModels.Select(x => x.Id));

                consumerBasketViewModel.ProductToByDescriptors = products.Select(product => new ProductToBuyDescriptor
                    {
                        Product = product,
                        Quantity = productInBasketViewModels.Single(x => x.Id == product.Id).Quantity
                }).ToList();
            }
            return View(consumerBasketViewModel);
        }
    }
}
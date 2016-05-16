using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Web.Models.Statistics;

namespace OS.Web.Controllers.Api
{
    [RoutePrefix("api/statistics")]
    public class StatisticsController : BaseApiController
    {
        private readonly ProductsBL _productsBL;

        public StatisticsController(ProductsBL productsBL)
        {
            _productsBL = productsBL;
        }

        [HttpGet]
        [Route("products/vewfrequency")]
        public object ProductViewFrequency()
        {
            List<ProductViewingInfo> productViewFrequency = _productsBL.GetProductViewingInfos();
            return new
                {
                    data = productViewFrequency.Select(x => new ProductViewFreqencyViewModel
                        {
                            IpAddress = x.UserHostAddress.IpAddress,
                            LastViewDate = x.Count == 1 ? x.Created.Value : x.Updated.Value,
                            ProductId = x.ProductId,
                            ProductName = x.Product.Name,
                            ViewCount = x.Count,
                            UserId = x.UserId
                        }).ToList()
                };
        }
    }
}
#region Usings
using System.Web.Mvc;
using OS.Business.Logic;
using OS.Web.Models;
#endregion

namespace OS.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseLayoutController<HomePageViewModel>
    {
        public HomeController(ProductCategoriesBL productCategoriesBL) : base(productCategoriesBL)
        {
        }
    }
}
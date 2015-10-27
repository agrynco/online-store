#region Usings
using OS.Business.Logic;
using OS.Web.Models;
#endregion

namespace OS.Web.Controllers
{
    public class HomeController : BaseLayoutController<HomePageViewModel>
    {
        public HomeController(ProductCategoriesBL productCategoriesBL) : base(productCategoriesBL)
        {
        }
    }
}
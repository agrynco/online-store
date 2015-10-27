#region Usings
using OS.Business.Logic;
using OS.Web.Models;
#endregion

namespace OS.Web.Controllers
{
    public class AboutController : BaseLayoutController<HorizontalCategorySelectorViewModel>
    {
        public AboutController(ProductCategoriesBL productCategoriesBL) : base(productCategoriesBL)
        {
        }
    }
}
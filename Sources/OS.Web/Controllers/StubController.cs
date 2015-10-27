#region Usings
using OS.Business.Logic;
using OS.Web.Models;
#endregion

namespace OS.Web.Controllers
{
    public class StubController : BaseLayoutController<HorizontalCategorySelectorViewModel>
    {
        public StubController(ProductCategoriesBL productCategoriesBL) : base(productCategoriesBL)
        {
        }
    }
}
#region Usings
using OS.Business.Logic;
using OS.Web.Models;
#endregion

namespace OS.Web.Controllers
{
    public class ContactInfoController : BaseLayoutController<HorizontalCategorySelectorViewModel>
    {
        public ContactInfoController(ProductCategoriesBL productCategoriesBL) : base(productCategoriesBL)
        {
        }
    }
}
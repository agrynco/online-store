#region Usings
using System.Web.Mvc;
using OS.Business.Logic;
#endregion

namespace OS.Web.Controllers
{
    public class ContactInfoController : Controller
    {
        private readonly ContactInfoBL _contactInfoBl;

        public ContactInfoController(ContactInfoBL contactInfoBl)
        {
            _contactInfoBl = contactInfoBl;
        }

        public ActionResult Index()
        {
            return View(_contactInfoBl.Get());
        }
    }
}